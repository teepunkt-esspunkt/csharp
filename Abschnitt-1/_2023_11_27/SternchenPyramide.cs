using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal class SternchenPyramide
    {
        public static void SternchenPyramideBilden()
        {
            int eingabe = 0;
            Console.Write("Baislaenge(>0 und ungerade): ");

            try
            {
                eingabe = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                SternchenPyramideBilden();
            }
            if(eingabe > 0 && eingabe % 2 != 0)
            {
                for (int i = 0; i < eingabe; i++)
                {
                    for (int j = 0; j < eingabe - i; j++)
                    {
                        Console.Write(" ");
                    }
                    for (int k = 0; k < 2 * i + 1; k++)
                    {
                        Console.Write("*");

                    }
                    Console.WriteLine();
                }
                //// Output a asteriks pyramid with the user input as the bottom
                //for (int i = 0; i < eingabe; i++)
                //{
                //    for (int j = 0; j < eingabe - i; j++)
                //    {
                //        Console.Write(" ");
                //    }
                //    for (int k = 0; k < 2 * i + 1; k++)
                //    {
                //        Console.Write("*");
                //    }
                //    Console.WriteLine();
                //}


            }
            else
            {
                Console.WriteLine("Ungueltige Eingabe!");
                SternchenPyramideBilden();
            }
        }
    }
}
