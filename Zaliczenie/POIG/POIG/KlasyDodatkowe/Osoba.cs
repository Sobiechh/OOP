using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIG.KlasyDodatkowe
{
    class Osoba
    {
        public string _imie { get;  set; }
        public string _nazwisko { get; set; }
        public string _adres { get; set; }
        public uint _numerTelefonu { get; protected set; }

        public Osoba()
        { }

        protected Osoba(string imie, string nazwisko, string adres, uint numerTelefonu)
        {
            if (string.IsNullOrWhiteSpace(imie)) throw new ArgumentException("Nieprawidłowe imię");
            if (string.IsNullOrWhiteSpace(nazwisko)) throw new ArgumentException("Nieprawidłowe nazwisko");
            if (string.IsNullOrWhiteSpace(adres)) throw new ArgumentException("Nieprawidłowy adres");

            _imie = imie;
            _nazwisko = nazwisko;
            _adres = adres;
            _numerTelefonu = numerTelefonu;
        }


        public override string ToString()
        {
            return $"Imie: {_imie}, Nazwisko: {_nazwisko}, Adres: {_adres} \n Numer telefonu: {_numerTelefonu}";
        }
    }
}
