using POIG.KlasyDodatkowe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIG.Wydarzenia
{
    abstract class Wydarzenie
    {
        public string _termin { get; private set; }
        public string _adresImprezy { get; private set; }
        public double _kosztMuzyczny { get; private set; }

        public abstract string GenerujZaproszenia();
        public abstract string GenerujRaportKosztow();
        public abstract double ObliczKoszt();

        public Organizator _organizator;
        public Klient _klient;

        protected Wydarzenie(string termin, Organizator organizator, Klient klient, double kosztMuzyczny, string adresImprezy)
        {
            this._termin = termin;
            this._organizator = organizator;
            this._klient = klient;
            this._kosztMuzyczny = kosztMuzyczny;
            this._adresImprezy = adresImprezy;
        }
    }
}
