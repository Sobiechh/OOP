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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
            //partial - czesc implementacji klasy
    public partial class MainWindow : Window
    {
        private class Person
        {
            public string name = "";
            public string surname = "";
            public double age = 0.0;

            public Person(string name, string surname, double age)
            {
                this.name = name;
                this.surname = surname;
                this.age = age;
            }

            public override string ToString()
            {
                return $"Imie: {name}, Nazwisko: {surname}, Wiek: {age}";
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            //klucz oznacza properties
            //blysakawica - event
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            
            string name = textBoxName.Text.ToString();
            string surname = textBoxSurname.Text.ToString();
            string age = sliderAge.Value.ToString();
            listBoxName.Items.Add($"Imie: {name}, Naziwsko: {surname}, wiek: {age}");
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            string name = textBoxName.Text.ToString();
            string surname = textBoxSurname.Text.ToString();
            string age = sliderAge.Value.ToString();
            var selected = listBoxName.SelectedIndex;
            try
            {
                listBoxName.Items.RemoveAt(selected);
                listBoxName.Items.Insert(selected, $"Imie: {name}, Naziwsko: {surname}, wiek: {age}");
            }
            catch
            {

            }

        }
        private void sliderAge_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            string ageValue = sliderAge.Value.ToString();
            labelAgeValue.Content = $"{ageValue}";
        }

        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
