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
            public string name { get; set; } = "";
            public string surname { get; set; } = "";
            public double age { get; set; } = 0.0;

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
            TextBoxWithErrorProvider.BrushForAll = Brushes.Red; //musi sie to stac przed instancja
            InitializeComponent();
            //klucz oznacza properties
            //blysakawica - event
        }

        private void clear()
        {
            textBoxErrorName.Text = "";
            textBoxErrorSurname.Text = "";
            sliderAge.Value = 0;
        }


        private bool isCorrect(TextBoxWithErrorProvider tb)
        {
            if(!(tb.Text.All(char.IsLetter)))
            {
                tb.SetError("Wprowadź ponownie");
                return false;
            }
            if(tb.Text.Trim() == "")
            {
                tb.SetError("Pole nie może być puste");
                return false;
            }
            tb.SetError("");
            return true;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            if(isCorrect(textBoxErrorName) & isCorrect(textBoxErrorSurname))
            {
                listBoxName.Items.Add(new Person(textBoxErrorName.Text.ToString(), textBoxErrorSurname.Text.ToString(), sliderAge.Value));
                clear();
            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Person person_selected = listBoxName.SelectedItem as Person;
            var select_id = listBoxName.SelectedIndex;
            try
            {
                person_selected.name = textBoxErrorName.Text.ToString();
                person_selected.surname = textBoxErrorSurname.Text.ToString();
                person_selected.age = Convert.ToDouble(labelAgeValue.Content.ToString());
                listBoxName.Items.Insert(select_id, person_selected.ToString());
                listBoxName.Items.Remove(listBoxName.SelectedItem);
                clear();
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
            var selected = listBoxName.SelectedIndex;
            try
            {
                listBoxName.Items.RemoveAt(selected);
                clear();
            }
            catch
            {
                System.Console.WriteLine("Nothing selcted");
            };
        }

        private void listBoxName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                Person person = listBoxName.SelectedItem as Person;
                textBoxErrorName.Text = person.name.ToString();
                textBoxErrorSurname.Text = person.surname.ToString();
                labelAgeValue.Content = person.age.ToString();
            }
            catch
            {

            }
        }

    }
}