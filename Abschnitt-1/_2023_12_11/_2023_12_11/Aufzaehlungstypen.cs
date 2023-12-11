using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_12_11
{
    class Aufzaehlungstypen
    {
        static void test()
        {
            bool b = true;
            int x = 13;
            int[] ia = { 1, 2, 3 };
            ia = new int[3];
            string s = new string("avs");
            CC c = new CC();
            II i = new CI();
            EuroMuenzen coins = EuroMuenzen.FUENFZENT;

        }
    }
    internal class CC
    {

    }
    internal interface II
    {

    }
    internal class CI : II
    {

    }
    internal enum EuroMuenzen
    {
        EINZENT,
        ZWEIZENT,
        FUENFZENT,
        ZEHNZENT,
        FUENFIGZENT,
        EINEURO,
        ZWEIEURO
    }
    internal enum WeekDay
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }
}
