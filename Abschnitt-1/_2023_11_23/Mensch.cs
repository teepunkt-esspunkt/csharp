using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
Die Klasse Person soll noch mit einem weiteren Attribute versehen werden - geschlecht
Definiere für die Darstellubng von Geschlechtern einen Aufzaehlungstyp - Geschlecht. Die Werte bzw. die Objekte die in Frage kommen
sind Male und Female
In der Klasse Person passe folgende Operationen an
    1. Konstruktor:
        Das Attribut Geschlecht soll auch initialisiert werden
    2. Properties für geschlecht
    3. werteBMIaus:
        Bei der Bewertung soll das Geschlecht beruecksichtig werden
        
                Bewertung für Male
        < 16                Kritisches Untergewicht
        16 ... 18.5         Untergewicht
        18.5 ... 25         Normalgewicht
        25 ... 30           leichters uebergewicht
        > 30                Uebergewicht

                Bewertung für Female
        < 16                Kritisches Untergewicht
        16 ... 18.5         Untergewicht
        18.5 ... 25         Normalgewicht
        25 ... 30           leichters uebergewicht
        > 30                Uebergewicht

*/

namespace _2023_11_23
{
    /**
     * erfasse die Klasse Mensch
     * fuer die BMI Berechnung und Auswertung
     */
    internal class Mensch
    {
        // Attribute
        /**
         * Gewicht in kg
         * Groesse in cm
         * Geburtsdatum
         *          -Hinweis: .NET API für Datum (Date?)
         */


        // Konstruktoren
        /**
         * Ein vollstaendig parameterisierter Konstruktor 
         * fuer die Initialisierung der Attribute
         */

        // Methoden
        /**
         * 1. Berechnung des BMIs
         * 2. Ermittlung des Alters
         * 3. Auswertung
         *      https://www.tk.de/service/app/2002866/bmirechner/bmirechner.app?tkcm=ab
         * 4. ToString
         *      - Textuelle Darstellung und Zustand des Objekts
         */

        double gewicht;
        int groesse;
        
        readonly DateTime geburtsDatum;

        // Properties
        public double Gewicht
        {
            get { return gewicht; }
            set { gewicht = value;}
        }
        public int Groesse
        {
            get { return groesse; }
            set { groesse = value; }
        }
        public DateTime Geburtsdatum
        {
            get { return geburtsDatum; }
            //set { geburtsDatum = value; }
        }
        //public double getGewicht()
        //{
        //    return gewicht;
        //}
        //public void setGewicht(double gewicht)
        //{
        //    this.gewicht = gewicht;
        //}
        //int alter;

        public Mensch(double gewicht, int groesse, DateTime geburtsDatum)
        {
            this.geburtsDatum = geburtsDatum;
            this.groesse = groesse;
            this.gewicht = gewicht;
            GetAlter();
            
        }

        public double GetBMI()
        {
            double groesse_meter = this.groesse / 100.0;

            //return this.gewicht/ (groesse_meter * groesse_meter);
            return this.gewicht / Math.Pow(groesse_meter, 2);
        }
        public int GetAlter()
        {
            int alter = DateTime.Today.Year - this.geburtsDatum.Year;
            int monthToday = DateTime.Today.Month;
            int dayToday = DateTime.Today.Day;
            int monthGebDatum = this.geburtsDatum.Month;
            int dayGebDatum = this.geburtsDatum.Day;

            //if(monthToday < monthGebDatum || monthToday == monthGebDatum && dayToday < dayGebDatum)
            //{
            //    alter--;
            //}
            //this.alter = (monthToday < monthGebDatum || monthToday == monthGebDatum && dayToday < dayGebDatum) ? --alter : alter;
            return (monthToday < monthGebDatum || monthToday == monthGebDatum && dayToday < dayGebDatum) ? --alter : alter;

            //int heutigesJahr = DateTime.Now.Year;

            //int ergebnis = heutigesJahr - geburtsDatum.Year;

            //this.alter = ergebnis;
            //return alter;

        }

        
        public string WerteBMIaus()
        {
            double bmi = GetBMI();
            if (bmi < 16)
                return "Kritisches Untergewicht";
            else if (bmi < 18.5)
                return "Untergewicht";
            else if (bmi < 25)
                return "Normalgewicht";
            else if (bmi < 30)
                return "Leichtes Ubergewicht";
            else
                return "Uebergewicht";
        }
        public override string ToString()
        {

            double bmi = GetBMI();
            //string bmiString = BmiStand(bmi);
            //return "Alter: " + this.alter + ", Groesse: " + this.groesse + ", Gewicht: " + this.gewicht + ", BMI: " + bmi + ", Ihr BMI Zustand: " + bmiString;
            //return "Gewicht = " + this.gewicht + " Kg" + ", Groesse = " + this.groesse + " cm" + ", BMI " + this.getBMI() + ", Geburtsdatum " + this.geburtsDatum + ", Alter = " + this.getAlter();
            return $"Gewicht = {gewicht} Kg, Groesse = {groesse} + cm, BMI = {GetBMI()}, Geburtsdatum = {geburtsDatum}, Alter = {GetAlter()}, Auswertung = {WerteBMIaus()}";
        }
        public string ToCSV()
        {
            return $"{gewicht},{groesse},{geburtsDatum}";
        }

        /**
         * Die Methode soll aus einem String ein Mensch Objekt erzeugen 
         * und das Objekt zurückgeben
         * 
         * Wenn die Gestaltung des Parameters menschstring 
         * der Formel Gewicht,Groesse,Geburtsdatum nicht entspricht
         * dann soll die Methode eine FormatException werfen, 
         * sonst soll aus dem String das ensprechende Mensch Objekt
         * erstellt werden
         * 
         * Hinweis: 
         *      - Ausnahmebehandlung: try - catch - finally
         *      - Ausnahme werfen: throw statement
         *      - API schaut ihr Euch den Datentyp String an (.NET Doku)
         */
        public static Mensch Parse()
        {
            /**
             * aus einem string 3 elemente extrahieren ( mal gucken was string so kann)
             * 
             */
            Console.WriteLine("Bitte menschString eingeben: ");
            string menschString = Console.ReadLine();


            if (menschString.Length >= 10)
            {
                double gewicht;
                int alter;
                DateTime geburtstag;
                string[] werte = menschString.Split(',');

                if (werte.Length == 3)
                {
                    try
                    {
                        gewicht = double.Parse(werte[0]);
                        alter = int.Parse(werte[1]);
                        geburtstag = DateTime.Parse(werte[2]);
                    }
                    catch(FormatException ex)
                    {
                        return Parse();
                    }
                }
                else
                {
                    return Parse();

                }
                return new Mensch(gewicht, alter, geburtstag);
            }
            else 
            { 
                return Parse(); 
            }
        }

    }
    internal class MenschIO
    {
        /** Definiere folgende Methoden
         * 
         * 1. Eine Methode, die aus der Konsole einen Wert 
         * für Geburtsdatum einliest und das Datum Objekt zurückgibt
         * 2. Eine Methode, die aus der Konsole einen Wert 
         * für Gewicht einliest und die Fliesskommazahl zurückgibt
         * 3. Eine Methode, die aus der Konsole einen Wert 
         * für Groesse einliest und als ganze Zahl zurückgibt
         * 4. Eine Methode, die aus der Konsole die Daten für ein 
         * Mensch Objekt einliest und ein Mensch Objekt zurückgibt
         * 
         * Achte auf Werte Überprüfungen
         *                  User erneut auffordern
         *                  oder Exception
         */
        public static DateTime ReadBirthDayFromConsole()
        {


            Console.Write("Geburtsdatum: ");
            try
            {
                return DateTime.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                return ReadBirthDayFromConsole(); // Rekursion
            }
        }

        
        public static DateTime GdAusKonsole()
        {
            DateTime geburtstag;

            while (true)
            {
                Console.Write("Bitte Geburtsdatum eingeben im Format jjjj-mm-tt: ");
                string eingabe = Console.ReadLine();
                if(DateTime.TryParse(eingabe, out  geburtstag))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ungueltige Eingabe!");
                }
            }
            return geburtstag;
        }

        public static double ReadWeightFromConsole(double min, double max)
        {
            Console.Write($"Gewicht in kg [{min} ... {max}]: ");
            try
            {
                double weight =  double.Parse(Console.ReadLine());
                if (weight < min || weight > max)
                {
                    return ReadWeightFromConsole(min, max);
                }
                return weight;
            } 
            catch (FormatException ex)
            {
                return ReadWeightFromConsole(min, max);
            }
        }
        internal static double GewichtAusKonsole()
        {
            double gewicht;
            while (true)
            {
                Console.Write("Bitte Gewicht eingeben: ");
                string eingabe = Console.ReadLine();
                if(double.TryParse(eingabe, out gewicht)) // ??
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ungueltige Eingabe!");
                }
            }
            return gewicht;
        }

        public static int ReadHeightFromConsole(int min, int max)
        {
            Console.Write($"Groesse in cm [{min} ... {max}]: ");
            int height = 0;
            try
            {
                height = int.Parse(Console.ReadLine());
            }
            catch   (FormatException ex)
            {
                return ReadHeightFromConsole(min, max);
            }
            if (height < min || height > max)
                return ReadHeightFromConsole(min, max);
            return height;


        }
        internal static int GroesseAusKonsole()
        {
            int groesse;
            while (true)
            {
                Console.Write("Bitte Groesse in cm eingeben: ");
                string eingabe = Console.ReadLine();
                if (int.TryParse(eingabe, out groesse))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Ungueltige Eingabe!");
                }
            }
            return groesse;
        }

        public static Mensch ReadMenschFromConsole(int minHeight, int maxHeight, double minWeight, double maxWeight)
        {
            return new Mensch(ReadWeightFromConsole(minWeight, maxWeight), ReadHeightFromConsole(minHeight, maxHeight), ReadBirthDayFromConsole());
        }
        internal static Mensch MenschAusKonsole()
        {
            Mensch mensch;
          
                int groesse = GroesseAusKonsole();
                double gewicht = GewichtAusKonsole();
                DateTime gdDatum = GdAusKonsole();

                mensch = new Mensch(gewicht, groesse, gdDatum);
            
            return mensch;
        }


    }
}
