﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//przestrzeń nazw dla wejścia wyjścia między innymi zapisa na dysku
using System.IO;

namespace Lab1
{
    static class Archiwizacja
    {

        public static void ZapisPilkarzyDoPliku(string plik, Person[] pilkarze)
        {
            using (StreamWriter stream = new StreamWriter(plik))
            {
                foreach (var p in pilkarze)
                    stream.WriteLine(p.ToFileFormat());
                stream.Close();
            }
        }
        public static Person[] CzytajPilkarzyZPliku(string plik)
        {
            Person[] pilkarze = null;
            if (File.Exists(plik))
            {
                var sPilkarze = File.ReadAllLines(plik);
                var n = sPilkarze.Length;
                if (n > 0)
                {
                    pilkarze = new Person[n];
                    for (int i = 0; i < n; i++)
                        pilkarze[i] = Person.CreateFromString(sPilkarze[i]);
                    return pilkarze;
                }


            }
            return pilkarze;
        }

    }
}
