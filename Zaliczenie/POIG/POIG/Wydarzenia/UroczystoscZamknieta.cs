using POIG.KlasyDodatkowe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIG.Wydarzenia
{
    internal class UroczystoscZamknieta : Wydarzenie
    {
        public static List<Gosc> ListaGosci = new List<Gosc>();

        public UroczystoscZamknieta(string termin, Organizator organizator, Klient klient, double kosztMuzyczny, string adresImrpezy) : base(termin, organizator, klient, kosztMuzyczny, adresImrpezy)
        {
        }

        public void DodajGoscia(string Imie, string Nazwisko, string Adres, uint numerTel)
        {
            if(ListaGosci.Count() != DaneOrganizacyjne.maxLudziZamknieta)
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
            if(ListaGosci.Count != 0) ListaGosci.Remove(new Gosc(Imie, Nazwisko, Adres, numerTel));
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

            odpowiedz.Append("!Lista gosci!\n");

            foreach (Gosc gosc in ListaGosci)
            {
                odpowiedz.Append(gosc);
                odpowiedz.Append("\n");
                odpowiedz.Append('*', 100);
                odpowiedz.Append("\n");
            }

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
