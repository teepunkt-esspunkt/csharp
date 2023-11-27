using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal static class MaxDiv
    {

        public static void MaxDivGo()
        {
            bool eingabenKorrekt = false;
            while (!eingabenKorrekt)
            {


                try
                {
                    Console.WriteLine("Bitte die maximale Zahl eingeben.");
                    int max = int.Parse(Console.ReadLine());
                    Console.WriteLine("Bitte durch die zu dividierende Zahl eingeben");
                    int div = int.Parse(Console.ReadLine());
                    eingabenKorrekt = true;
                    for (int i = 0; i <= max; i++)
                    {
                        if (i % div == 0)
                        {
                            Console.WriteLine(i);
                        }
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Ungueltige Eingabe!");
                }
            }
        }
    }
}
