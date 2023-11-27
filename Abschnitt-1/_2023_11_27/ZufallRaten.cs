using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal static class ZufallRaten
    {
        private static int ergebnis;
        private static int versuche = 0;
        static ZufallRaten()
        {
            Random zufall = new Random();
            ergebnis = zufall.Next(0, 101);
           
        }
        public static void ZufallRatenStart()
        {
            Console.WriteLine("Ich habe eine Zufallszahl zwischen 0 und 100 generiert! Bitte errate Sie!");
            bool erraten = false;

            while (erraten == false)
            {
                try
                {
                    int zahl = int.Parse(Console.ReadLine());
                    if (zahl < ergebnis)
                    {
                        Console.WriteLine("Die eingegebene Zahl ist zu klein.");
                        versuche++;
                    }
                    else if (zahl > ergebnis)
                    {
                        Console.WriteLine("Die eingegebene Zahl ist zu groß.");
                        versuche++;
                    }
                    else
                    {
                        erraten = true;
                        Console.WriteLine($"RICHTIG! Mit {versuche} Versuchen");
                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Ungueltige eingabe!");
                }
            }
        }
    }
}

/**
 * 
 * 
            int ergebnis = zufall.Next(0, 101);
            Console.WriteLine(ergebnis);
            
            //int zahl;
          

           
*/