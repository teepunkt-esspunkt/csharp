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
                
                
            }
            catch(FormatException ex)
            {
                Console.WriteLine("Ungueltige Eingabe!");
                TreppeBilden();
            }
            if(eingabe >= 1) 
            {
                Console.WriteLine("+-+");
            }
            for (int i = 0; i < eingabe; i++)
            {
                Console.Write("|");
                for (int j = 0; j <= i * 2; j++)
                {
                    Console.Write(" ");
                }
                //Console.Write(" ");
                Console.WriteLine("|");
                Console.Write("+");

                for (int j = 0; j <= i * 2 +2; j++)
                {
                    Console.Write("-");
                }
                Console.WriteLine("+");
            }
        }
    }
}
