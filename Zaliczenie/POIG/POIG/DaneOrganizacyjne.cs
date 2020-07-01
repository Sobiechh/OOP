using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POIG
{
    static class DaneOrganizacyjne
    {
        public static int maxLudzi = 0;
        public static int maxLudziZamknieta = 10;

        public static readonly List<(int iloscOsob, decimal stawkaOsobowa)> Koszt = new List<(int iloscOsob, decimal stawkaOsobowa)>();

        public const int stawkaWyzywienie = 200;

        static DaneOrganizacyjne()
        {
            Koszt.Add((20, 200));
            Koszt.Add((30, 300));
            Koszt.Add((60, 600));
            Koszt.Add((80, 800));
            Koszt.Add((200, 1000));
            Koszt.Add((300, 1450));
            Koszt.Add((500, 1900));
            Koszt.Add((700, 2300));
            Koszt.Add((1_000, 5000));
            Koszt.Add((2_000, 6000));
            Koszt.Add((3_000, 7000));
            Koszt.Add((5_000, 1000000));
            Koszt.Add((10_000, 1500000));
            Koszt.Add((15_000, 2000000));
            Koszt.Add((20_000, 2500000));
            Koszt.Add((30_000, 3000000));
            Koszt.Add((50_000, 5000000));

            maxLudzi = Koszt.Max(el => el.iloscOsob);
            //maxLudzi = 13;
        }

    }
}
