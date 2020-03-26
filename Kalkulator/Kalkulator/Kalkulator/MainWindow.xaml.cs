using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class ShowNums
        {
            public string firstNum { get; set; }
            public string secondNum { get; set; }
            public string operation { get; set; }
            public string equals { get; set; }

            public ShowNums(string firstNum, string secondNum, string operation, string equals)
            {
                this.firstNum = firstNum;
                this.secondNum = secondNum;
                this.operation = operation;
                this.equals = equals;
            }

            public override string ToString()
            {
                return $"{firstNum}{operation}{secondNum}{equals}";
            }
        }

      
        int oper; //which operation
        string strOper;
        bool is_first = true; //to single num oper
        double currentNum, firstNum, secondNum = 0.0;
        bool refresh = false; //po wyniku

        private void numClick(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "bdelete")
            {
                if (currentEquation.Text.Length > 0)
                {
                    currentEquation.Text = currentEquation.Text.Remove(currentEquation.Text.Length - 1);
                    infoText.Text = infoText.Text.Remove(infoText.Text.Length - 1);
                }
            }
            else if(((Button)sender).Name == "bdeleteAll")
            {
                try
                {
                    infoText.Text = infoText.Text.Remove(infoText.Text.Length-currentEquation.Text.Length);
                }
                catch
                {

                }
                currentEquation.Text = "";
            }
            else if(((Button)sender).Name == "bclear")
            {
                currentEquation.Text = infoText.Text = "";
            }
            else if(((Button)sender).Name == "bdot")
            {
                var regex = new Regex(@"^[0-9]*(?:\,[0-9]*)?$"); //zeby nie dodawac milion kropek
                if (regex.IsMatch(currentEquation.Text + "," ))
                {
                    currentEquation.Text += ((Button)sender).Content;
                    infoText.Text += ((Button)sender).Content;
                }
            }
            else if (((Button)sender).Name == "bchange")
            {
                try
                {
                    if (currentEquation.Text.Substring(0, 1) == "-")
                    {
                        currentEquation.Text = currentEquation.Text.Substring(1, currentEquation.Text.Length - 1);
                        infoText.Text = infoText.Text.Remove(infoText.Text.Length - (currentEquation.Text.Length + 1));
                        infoText.Text += currentEquation.Text;
                    }
                    else
                    {
                        currentEquation.Text = "-" + currentEquation.Text;
                        infoText.Text = infoText.Text.Remove(infoText.Text.Length - (currentEquation.Text.Length - 1));
                        infoText.Text += currentEquation.Text;
                    }
                }
                catch { }
            }
            else
            {
                currentEquation.Text += ((Button)sender).Content;
                infoText.Text += ((Button)sender).Content;
            }
        }

    
        private void opClick(object sender, RoutedEventArgs e)
        {
            if (refresh)
            {
                infoText.Text = currentEquation.Text;
                refresh = false;
                firstNum = secondNum = 0.0;
            }

            if (is_first)
            {
                try
                {
                    firstNum = double.Parse(currentEquation.Text.ToString());
                    is_first = false;
                }
                catch { }
            }

            try
            {
                currentNum = double.Parse(currentEquation.Text.ToString());
            }
            catch { }
            string operation = ((Button)sender).Content.ToString(); //oper potem do string

            //basic opers
            if (operation == "+")
            { 
                oper = 1;
            }
            else if (operation == "-")
            {
                oper = 2;
            }
            else if (operation == "x")
            {
                oper = 3;
            }
            else if (operation == "/")
            {
                oper = 4;
            }

            //advanced opers 
            if (operation == "x^2")
            {
                singleNum(currentNum * currentNum);
            }
            else if (operation == "sqrt(x)")
            {
                singleNum((Math.Sqrt(currentNum)));
            }
            else if (operation == "1/x")
            {
                singleNum((1 / currentNum));
            }
            else if (operation == "%")
            {
                singleNum(currentNum / 100);
            }

            //result
            else if (operation == "=")
            {
                Calculate();
                refresh = true;
            }

            if (operation == "+" | operation == "-" | operation == "/" | operation == "x")
            {
                currentEquation.Text = "";
                infoText.Text += operation;
            }
            
            strOper = operation;
        }


        void singleNum(double xnum)
        {
            infoText.Text = infoText.Text.Remove(infoText.Text.Length - currentEquation.Text.Length);
            currentEquation.Text = (xnum).ToString();
            infoText.Text += currentEquation.Text;
            if (!is_first)
                firstNum = xnum;
            else
                secondNum = xnum;
        }

        void Calculate()
        {
            try
            {
                secondNum = double.Parse(infoText.Text.Split(new string[] { strOper }, StringSplitOptions.None)[1]);
                is_first = true;
            }
            catch{}

            //test
            infoText.Text = $"Operacja:  {oper} Pierwsze: {firstNum}, Drugie: {secondNum}";

            double result;
            switch (oper)
            {
                case 1:
                    result = firstNum + secondNum;
                    break;
                case 2:
                    result = firstNum - secondNum;
                    break;
                case 3:
                    result = firstNum * secondNum;
                    break;
                case 4:
                    result = firstNum / secondNum;
                    break;
                default:
                    result = 0;
                    break;
            }
            currentEquation.Text =  result.ToString();
        }

            public MainWindow()
        {
            InitializeComponent();   
        }        
    }
}