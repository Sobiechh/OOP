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
        int oper; //which operation
        string strOper;
        bool is_first = true; //to single num oper
        double firstNum, secondNum = 0.0;

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
                var regex = new Regex(@"^[0-9]*(?:\.[0-9]*)?$"); //zeby nie dodawac milion kropek
                if (regex.IsMatch(currentEquation.Text + "." ))
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
            string operation = ((Button)sender).Content.ToString(); //oper potem do string
            if(is_first)
            {
                try
                {
                    firstNum = double.Parse(currentEquation.Text.ToString(), CultureInfo.InvariantCulture);
                    is_first = false;
                }
                catch { }
            }
            
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
            else if (operation == "x^2")
            {
                oper = 5;
            }
            else if (operation == "sqrt(x)")
            {
                oper = 6;
            }
            else if (operation == "1/x")
            {
                oper = 7;
            }
            else if (operation == "%")
            {
                oper = 8;
            }
            //result
            else if(operation == "=")
            {
                Calculate();
            }
            
            if (operation != "=") currentEquation.Text = "";
            
            infoText.Text += operation;
            strOper = operation;
        }


        void Calculate()
        {
            try
            {
                secondNum = double.Parse(infoText.Text.Split(new string[] { strOper }, StringSplitOptions.None)[1], CultureInfo.InvariantCulture);
                is_first = true;
            }
            catch{}

            //infoText.Text = $"Pierwsze: {firstNum}, Drugie: {secondNum}";

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

        void Calculate2() //single num op
        {
            double num, res=0.0;
            if(is_first)
            {
                num = firstNum;
            }
            else
            {
                num = secondNum;
            }

            switch (oper)
            {
                case 5:
                    res = num * num;
                    break;
                case 6:
                    res = Math.Sqrt(num);
                    break;
                case 7:
                    res = 1 / num;
                    break;
                case 8:
                    res = num / 100;
                    break;
                default:
                    res = 0;
                    break;
            }
        }
            public MainWindow()
        {
            InitializeComponent();   
        }

        
    }
}