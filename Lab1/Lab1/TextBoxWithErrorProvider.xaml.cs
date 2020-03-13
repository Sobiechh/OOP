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

namespace Lab1
{
    /// <summary>
    /// Interaction logic for TextBoxWithErrorProvider.xaml
    /// </summary>
    public partial class TextBoxWithErrorProvider : UserControl
    {
        //ładnie posegeregowane properties
        #region Prop 
        public string Text 
        { 
            get
            {
                return textBox.Text;
            }
            set
            {
                textBox.Text = value; //do textboxa wstaw to co ktos przypisal propertisowi
            }
        }

        public static Brush BrushForAll { get; set; } = Brushes.Green;

        public Brush TextBorderBrush
        {
            get
            {
                return border.BorderBrush;
            }
            set
            {
                border.BorderBrush = value;
            }
        }

        #endregion


        public TextBoxWithErrorProvider()
        {
            InitializeComponent();
            border.BorderBrush = BrushForAll;
        }

        public void SetError(string errorText)
        {
            if(errorText == "")
            {
                border.BorderThickness = new Thickness(0);
                toolTip.Visibility = Visibility.Hidden;
            }
            else
            {
                border.BorderThickness = new Thickness(1);
                TextBlockErrorText.Text = errorText;
                toolTip.Visibility = Visibility.Visible;
            }
        }
    }
}
