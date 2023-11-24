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
            Mensch m1 = new Mensch(71, 185, new DateTime(2008, 6, 1));
            Console.WriteLine(m1.GetBMI());
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

            //Mensch konsolenMensch = MenschIO.MenschAusKonsole();
            //Console.WriteLine(konsolenMensch);


            Console.WriteLine("-----------");

            //Console.WriteLine(MenschIO.ReadBirthDayFromConsole());
            //Console.WriteLine($"Geburtsdatum = {MenschIO.ReadBirthDayFromConsole()}");

            //Console.WriteLine($"Gewicht = {MenschIO.ReadWeightFromConsole(40, 360)}");
            //Console.WriteLine($"Groesse = {MenschIO.ReadHeightFromConsole(10, 200)} cm");

            Console.WriteLine($"Mensch = {MenschIO.ReadMenschFromConsole(10, 280, 40, 360).ToCSV()}");
        }
    }

}
