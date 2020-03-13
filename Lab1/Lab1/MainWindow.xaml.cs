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
            textBoxError.Text = "działa";
        }

        private void clear()
        {
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            sliderAge.Value = 0;
        }

        private void clearColors()
        {
            textBoxSurname.Background = textBoxName.Background = labelAge.Background = default;
            borderAge.BorderBrush = borderSurname.BorderBrush = default;
            textBoxName.ToolTip = textBoxSurname.ToolTip = labelAge.ToolTip = default;
        }

        private void Check()
        {
            bool nameCorrect = textBoxName.Text.Length != 0 & textBoxName.Text.All(char.IsLetter) ? true : false;
            bool surnameCorrect = textBoxSurname.Text.Length != 0 & textBoxSurname.Text.All(char.IsLetter) ? true : false;
            bool ageCorrect = sliderAge.Value != 0 ? true : false;
            var box_b = new SolidColorBrush(Color.FromRgb(255, 167, 187));
            var border_b = System.Windows.Media.Brushes.Red;

            if (nameCorrect & surnameCorrect & ageCorrect)
            {
                listBoxName.Items.Add(new Person(textBoxName.Text.ToString(), textBoxSurname.Text.ToString(), sliderAge.Value));
                clear();
                clearColors();
            }
            if(nameCorrect)
            {
                clearColors();
            }
            if (surnameCorrect)
            {
                clearColors();
            }
            if (ageCorrect)
            {
                clearColors();
            }
            if (!nameCorrect)
            {
                textBoxName.Background = box_b;
                //borderName.BorderBrush = border_b;
                textBoxName.ToolTip = "Nieprawidłowe imie";
            }
            if (!surnameCorrect)
            {
                textBoxSurname.Background = box_b;
                borderSurname.BorderBrush = border_b;
                textBoxSurname.ToolTip = "Nieprawidłowe nazwisko";
            }
            if (!ageCorrect)
            {
                borderAge.Background = box_b;
                borderAge.BorderBrush = border_b;
                labelAge.ToolTip = "Nieprawidłowy wiek";
            }
        }

        private bool IsNoEmpty(TextBoxWithErrorProvider tb)
        {
            if(tb.Text.Trim() != "")
            {
                tb.SetError("");
                return true;
            }
            tb.SetError("Pole nei może być puste");
            return false;
        }

        private void buttonAdd_Click(object sender, RoutedEventArgs e)
        {
            Check();
            if(IsNoEmpty(textBoxError) & IsNoEmpty(textBoxError1))
            {

            }
        }

        private void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            Person person_selected = listBoxName.SelectedItem as Person;
            var select_id = listBoxName.SelectedIndex;
            try
            {
                person_selected.name = textBoxName.Text.ToString();
                person_selected.surname = textBoxSurname.Text.ToString();
                person_selected.age = Convert.ToDouble(labelAgeValue.Content.ToString());
                listBoxName.Items.Insert(select_id, person_selected.ToString());
                listBoxName.Items.Remove(listBoxName.SelectedItem);

                clear();
                clearColors();
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
                textBoxName.Text = person.name.ToString();
                textBoxSurname.Text = person.surname.ToString();
                labelAgeValue.Content = person.age.ToString();
            }
            catch
            {

            }
        }

    }
}
