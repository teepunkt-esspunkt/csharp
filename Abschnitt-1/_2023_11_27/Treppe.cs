using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal class Treppe
    {

        public static void TreppeBilden()
        {
            int eingabe = 0;
            try
            {
                eingabe = int.Parse(Console.ReadLine());
                int zaehler = 1;
                for(int i = 0; i < eingabe; i++) 
                {
                    Console.Write("+");
                    for(int j = 0; j <= i; j++)
                    {
                        Console.Write("-");
                    }
                    Console.Write("+");
                    Console.WriteLine("");
                    Console.WriteLine("| |");
                    Console.Write("+");
                    Console.Write("---");
                    for(int j = 0; j <= i; j++)
                    {
                        Console.Write("--");
                    }
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Ungueltige Eingabe!");
                TreppeBilden();
            }
        }
    }
}
