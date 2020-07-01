using POIG.KlasyDodatkowe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIG.Wydarzenia
{
    internal class ImprezaOtwarta : Wydarzenie
    {
        public static List<Gosc> ListaGosci = new List<Gosc>();

        public ImprezaOtwarta(string termin, Organizator organiztor, Klient klient, double kosztMuzyczny, string adresImprezy) : base(termin, organiztor, klient, kosztMuzyczny, adresImprezy)
        {
        }

        public void DodajGoscia(string Imie, string Nazwisko, string Adres, uint numerTel)
        {
            if (ListaGosci.Count() != DaneOrganizacyjne.maxLudzi)
            {
                ListaGosci.Add(new Gosc(Imie, Nazwisko, Adres, numerTel));
            }
            else
            {
                Console.WriteLine("Przekroczono maksymalną ilośc ludzi");
            }
        }

        public void UsunGoscia(string Imie, string Nazwisko, string Adres, uint numerTel)
        {
            if (ListaGosci.Count != 0) ListaGosci.Remove(new Gosc(Imie, Nazwisko, Adres, numerTel));
        }

        public override string GenerujRaportKosztow()
        {
            StringBuilder odpowiedz = new StringBuilder();

            var koszt_org = DaneOrganizacyjne.Koszt.SkipWhile(x => x.iloscOsob < ListaGosci.Count()).FirstOrDefault().stawkaOsobowa;
            var cena_wyzywienie = ListaGosci.Count() * DaneOrganizacyjne.stawkaWyzywienie;

            odpowiedz.Append("Koszty organizacyjne: ");
            odpowiedz.Append(koszt_org);
            odpowiedz.Append("\n");

            odpowiedz.Append("Cena za wyzywienie gosci: ");
            odpowiedz.Append(cena_wyzywienie);
            odpowiedz.Append("\n");

            odpowiedz.Append("Cena za obsluge muzyczna: ");
            odpowiedz.Append(_kosztMuzyczny);
            odpowiedz.Append("\n");

            odpowiedz.Append(base.ToString());
            return odpowiedz.ToString();
        }

        public override string GenerujZaproszenia()
        {
            StringBuilder odpowiedz = new StringBuilder();

            odpowiedz.Append("Impreza organizowana przez: ");
            odpowiedz.Append(this._organizator);
            odpowiedz.Append("\n");

            odpowiedz.Append("Impreza Odbędzie sie w : ");
            odpowiedz.Append(this._adresImprezy);
            odpowiedz.Append("\n");

            odpowiedz.Append("Zrealizowana dzięki: ");
            odpowiedz.Append(this._klient);
            odpowiedz.Append("\n");

            return odpowiedz.ToString();
        }

        public override double ObliczKoszt()
        {
            var koszt_org = DaneOrganizacyjne.Koszt.SkipWhile(x => x.iloscOsob < ListaGosci.Count()).FirstOrDefault().stawkaOsobowa;
            double cena_wyzywienie = ListaGosci.Count() * DaneOrganizacyjne.stawkaWyzywienie;


            return (double)koszt_org + cena_wyzywienie + this._kosztMuzyczny;
        }
    }
}
