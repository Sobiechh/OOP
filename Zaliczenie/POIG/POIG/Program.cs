using POIG.KlasyDodatkowe;
using POIG.Wydarzenia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIG
{
    class Program
    {
        static void Main(string[] args)
        {
            var klient1 = new Klient("Jacek", "Konieczny", "Powstancow 100", 5524242);
            var organiztor1 = new Organizator("Karol", "Małysz", "Superowa 20", 24124124);

            var klient2 = new Klient("Krzysiu", "Golonka", "Słoneczna 2", 5522442);
            var organiztor2 = new Organizator("Martynka", "Robaczek", "Kogucia 400", 29924124);


            var test1 = new ImprezaOtwarta("29.07.19", organiztor1, klient1, 23000, "Przy lesie");
            System.Console.WriteLine(test1);
            double koszt_imprezy1 = test1.ObliczKoszt();
            test1.DodajGoscia("a", "b", "c", 232);
            System.Console.WriteLine(test1.GenerujZaproszenia());
            test1.UsunGoscia("a", "b", "c", 2320);

            var test2 = new UroczystoscZamknieta("29.07.19", organiztor1, klient1, 23000, "Przy lesie");
            System.Console.WriteLine(test2);
            double koszt_imprezy2 = test2.ObliczKoszt();
            test2.DodajGoscia("a", "b", "c", 232);
            test2.DodajGoscia("Krystyna", "Z Gazowni", "Ziemowita 3", 232);
            test2.DodajGoscia("Robus", "Lewandowski", "gdzies w Niemcach", 232);
            test2.DodajGoscia("Robert", "Mateja", "Groska 102", 232);
            test2.DodajGoscia("Halina", "Rydzyk", "Pobozna 2/3", 232);
            System.Console.WriteLine(test2.GenerujZaproszenia());
            test2.UsunGoscia("a", "b", "c", 2320);


            //Przekroczenie maksymalnej liczby ludzi (linia 39 w DaneOrganizacyjne.cs, zmieniłem na 13 do testu)
            //for (uint i = 0; i < 15; i++)
            //{
            //    test1.DodajGoscia("a", "b", "c", i);
            //}

            System.Console.ReadKey();
        }
    }
}
