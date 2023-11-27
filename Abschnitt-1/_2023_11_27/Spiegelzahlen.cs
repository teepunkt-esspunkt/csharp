using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal static class Spiegelzahlen
    {
        

        public static void SpiegelzahlenBilden()
        {
            Console.WriteLine("Bitte eine positive Zahl eingeben.");
            string eingabe = Console.ReadLine();
            string ergebnis = "";

            try
            {
                double zahl = double.Parse(eingabe);

                for(int i = eingabe.Length - 1; i >= 0; i--) 
                {
                    ergebnis += eingabe[i];
                }
                Console.WriteLine(double.Parse(ergebnis));
            }
            catch
            {
                Console.WriteLine("Ungueltige Eingabe!");
                SpiegelzahlenBilden();
            }
        }
    }
}
