using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIG.KlasyDodatkowe
{
    class Organizator : Osoba
    {
        public Organizator(string imie, string nazwisko, string adres, uint numerTelefonu) : base(imie, nazwisko, adres, numerTelefonu)
        {
        }
    }
}
