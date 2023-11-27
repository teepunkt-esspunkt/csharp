using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal static class Quersumme
    {
     
        public static void QuersummeBilden()
        {
            Console.WriteLine("Bitte eine positive ganze Zahl eingeben.");
            string eingabe = Console.ReadLine();
            int ergebnis = 0;

            try
            {
                int zahl = int.Parse(eingabe);

                for(int i = 0; i < eingabe.Length; i++)
                {
                    ergebnis += int.Parse(eingabe[i].ToString());
                }
                Console.WriteLine(ergebnis);

            }
            catch (FormatException ex)
            {
                Console.WriteLine("Ungueltige Eingabe!");
                QuersummeBilden();
            }
        }
    }
}
