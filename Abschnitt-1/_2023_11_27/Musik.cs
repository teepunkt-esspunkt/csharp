using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal class Musik
    {
       

        public static void KostenBilden()
        {
            double kosten = 0;
            Console.WriteLine("Bitte Anzahl der gewuenschten Downloads angeben");

            try
            {
                int downloads = int.Parse(Console.ReadLine());

                if(downloads > 35)
                {
                    kosten = 30 * 0.2;
                    for(int i = 36; i <= downloads; i++)
                    {
                        kosten += 0.15; 
                    }
                }
                else if(downloads > 5)
                {
                    for(int i = 5; i < downloads; i++)
                    {
                        kosten += 0.2;
                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ungueltige Eingabe");
                KostenBilden();
            }
            Console.Write($"Gebuehren =  {kosten:F2} EURO");
        }
    }

    
}
