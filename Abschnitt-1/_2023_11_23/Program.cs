// See https://aka.ms/new-console-template for more information


using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace _2023_11_23

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("!");
            Mensch m1 = new Mensch(new DateTime(2008, 6, 1), 185, 71);
            Console.WriteLine(m1.getBMI());
            Console.WriteLine(m1.ToString());
            //Console.WriteLine(m1.getGewicht());
            Console.Write(m1.Gewicht); //Getter
            m1.Gewicht = 69;
        }
    }

}
