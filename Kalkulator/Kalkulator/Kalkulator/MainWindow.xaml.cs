using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void numClick(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).Name == "bdelete")
            {
                if (currentEquation.Text.Length > 0)
                {
                    currentEquation.Text = currentEquation.Text.Remove(currentEquation.Text.Length - 1);
                }
            }
            else if (((Button)sender).Name == "bchange")
            {
                if (currentEquation.Text.Substring(0, 1)  == "-")
                {
                    currentEquation.Text = currentEquation.Text.Substring(1,currentEquation.Text.Length-1);
                }
                else
                {
                    currentEquation.Text = "-" + currentEquation.Text;
                }
            }
            else
            {
                currentEquation.Text += ((Button)sender).Content; 
            }
        }

    
        private void opClick(object sender, RoutedEventArgs e)
        {
            String operation = ((Button)sender).Content.ToString();
            
            if (operation == "=")
            {
                Calculate();
            }
            else if (operation == "+")
            {

            }
        }


        void Calculate()
        {

        }


        public MainWindow()
        {
            InitializeComponent();
            
        }

        
    }
}
