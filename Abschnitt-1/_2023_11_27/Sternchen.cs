using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal class Sternchen
    {
        public static void SternchenBilden()
        {
            Console.Write("Anzahl(>0): ");

            try
            {
                int eingabe = int.Parse(Console.ReadLine());

                for(int i = 0; i < eingabe; i++) 
                {
                    Console.Write("*");
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                SternchenBilden();
            }
        }
    }
}
