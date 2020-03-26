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
        private string plikArchiwizacji = "archiwum.txt";

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
            sliderAge.Value = 29;
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
                var biezacyPilkarz = new Person(textBoxErrorName.Text.Trim(), textBoxErrorSurname.Text.Trim(), sliderAge.Value);
                var ifExist = false;
                foreach (var p in listBoxName.Items)
                {
                    var pilkarz = p as Person;
                    if (pilkarz.isTheSame(biezacyPilkarz))
                    {
                        ifExist = true;
                        break;
                    }
                }
                if (!ifExist)
                {
                    listBoxName.Items.Add(biezacyPilkarz);
                    clear();
                }
                else
                {
                    var dialog = MessageBox.Show($"{biezacyPilkarz.ToString()} już jest na liście {Environment.NewLine} Czy wyczyścić formularz?", "Uwaga", MessageBoxButton.OKCancel);
                    if (dialog == MessageBoxResult.OK)
                    {
                        clear();
                    }
                }
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

        //arch przy zamknieciu
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            int n = listBoxName.Items.Count;
            Person[] pilkarze = null;
            if (n > 0)
            {
                pilkarze = new Person[n];
                int index = 0;
                foreach (var o in listBoxName.Items)
                {
                    pilkarze[index++] = o as Person;
                }
                Archiwizacja.ZapisPilkarzyDoPliku(plikArchiwizacji, pilkarze);
            }
        }

        //po wywolaniu okna
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var pilkarze = Archiwizacja.CzytajPilkarzyZPliku(plikArchiwizacji);
            if (pilkarze != null)
                foreach (var p in pilkarze)
                {
                    listBoxName.Items.Add(p);
                }

        }
    }
}