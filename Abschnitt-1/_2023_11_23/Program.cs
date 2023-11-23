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
            Console.WriteLine(m1.Gewicht); //Getter
            m1.Gewicht = 69;
            Console.WriteLine(m1.Gewicht);



            //DateTime neuGD = MenschIO.GdAusKonsole(); 
            //Console.WriteLine(neuGD);

            //double neuGewicht = MenschIO.GewichtAusKonsole();
            //Console.WriteLine(neuGewicht);

            //double neuGroesse = MenschIO.GroesseAusKonsole();
            //Console.WriteLine(neuGroesse);

            Mensch konsolenMensch = MenschIO.MenschAusKonsole();
            Console.WriteLine(konsolenMensch);




        }
    }

}
