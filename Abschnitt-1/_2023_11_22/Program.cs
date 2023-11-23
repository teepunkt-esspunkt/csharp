using System;

namespace _2023_11_22
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Hello World!");

            double x = 0.0;

            Punkt p = new Punkt(3.0, 4.0);

            Console.WriteLine(p.ToString());

            Console.WriteLine("---------");

            Console.WriteLine(Punkt.ReadPunktFromConsole());

            Punkt q = Punkt.ReadPunktFromConsole();
            Console.WriteLine(q.ToString());
            // ist int jetzt eine Klasse???
            Console.WriteLine(int.MinValue);
            Console.WriteLine(int.MaxValue);

            Console.WriteLine(p.DistanceTo(q));
        }
    }
}