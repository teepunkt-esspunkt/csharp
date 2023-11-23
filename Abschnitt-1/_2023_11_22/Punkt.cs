using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_22
{
    internal class Punkt
    {
        //Attribute = Eigenschaft
        double xKoordinate;
        double yKoordinate;

        //Konstruktoren
        internal Punkt(double xK, double yKoordinate)
        {
            this.xKoordinate = xK;
            this.yKoordinate = yKoordinate;

        }
        /**
         * Definiere eine Methode ToString, die eine textuelle Darstellung des Punktes in der Form (xKoordinate, yKoordinate) zurückgibt
         */
                
        internal string ToString() // Objektabhängig
        {

            return "(" + this.xKoordinate + ", " + this.yKoordinate + ")";
        }
        /**
         * Definiere eine Methode, die zwei double Zahlen aus 
         * der Konsole einliest und mit diesen Zahlen ein entsprechendes 
         * PunktObjekt erzeugt
         * und dieses Objekt für den Aufrufer zurück gibt
         * 
         * Hinweis: Schau dir die Dokumentation von Console.WriteLine und Console.ReadLine
         *          string
         *          double
         */

        internal static Punkt ReadPunktFromConsole() // Objektunabhöngig. statische methode
        {
            // Zwei Zahlen aus der Konsole einlesen

            Console.Write("x-koordinate: ");
            string xAsString = Console.ReadLine(); // String wird eingelesen
            Console.Write("y-koordinate: ");
            string yAsString = Console.ReadLine();

            //String -> double: double.Parse(str)

            return new Punkt(double.Parse(xAsString), double.Parse(yAsString)); // parse ist eine statische methode der double

            
        }
        /**
         * 
         * Definiere eine Methode, die den Abstand von dem aktuellen Punkt zu einem 
         * gegebenen Punkt berechnet und den berechneten Wert für den 
         * Aufrufer zurückgibt
         * 
         */
        internal double DistanceTo(Punkt p)
        {
            /*
            double dx = p.xKoordinate - this.xKoordinate;
            double dy = p.yKoordinate - this.yKoordinate;
            double s = Math.Pow(dx, 2) + Math.Pow(dy, 2);
            double d = Math.Sqrt(s);
            */
            return Math.Sqrt(Math.Pow(p.xKoordinate - this.xKoordinate, 2) + Math.Pow(p.yKoordinate - this.yKoordinate, 2));
        }
    }
}
