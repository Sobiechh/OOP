using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//przestrzeń nazw dla wejścia wyjścia między innymi zapisa na dysku
using System.IO;

namespace Lab1
{
    internal class Person
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
        public string ToFileFormat()
        {
            return $"{name}|{surname}|{age}";
        }

        public static Person CreateFromString(string sPilkarz)
        {
            string imie, nazwisko;
            uint wiek;
            var pola = sPilkarz.Split('|');
            if (pola.Length == 3)
            {
                nazwisko = pola[1];
                imie = pola[0];
                wiek = uint.Parse(pola[2]);
                return new Person(imie, nazwisko, wiek);
            }
            throw new Exception("Błędny format danych z pliku");
        }
    }
}