using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

/**
 * 
 * Aufgabe:
 *          -Die Klasse Person soll noch mit einem weiteren Attribut versehen werden - geschlecht.
 *         
 *         Definiere für die Darstellung von Geschlechtern einen Aufzählungstyp - Geschlecht. Die Werte bzw. die Objekte, die in Frage 
 *         kommen sind: Male und Female. 
 *         
 *         In der Klasse Person, passe folgende Operatioenen an:
 *         
 *          1. Konstruktor:
 *                          Das Attribut geschlecht soll auch initialisiert werden
 *          2. Properties für geschlecht
 *          3. werteBMIAus:
 *                          -Bei der Bewertung soll das Geschlecht berücksichtigt werden.
 *                          
 *                         Die Bewertung für Male
 *                          
 *                           < 16       -> Kritisches Untergewicht
 *                          
 *                         16 ...  18.5 -> Untergewicht
 *                          
 *                         18.5 ... 25 -> Normal Gewicht
 *                          
 *                          25 ... 30 -> Leichtes Übergewicht
 *                          
 *                          > 30 -> Übergewicht
 *                          
 *                        Die Bewertung für Female
 *                          
 *                           < 15       -> Kritisches Untergewicht
 *                          
 *                         15 ...  17.5 -> Untergewicht
 *                          
 *                         17.5 ... 24 -> Normal Gewicht
 *                          
 *                          24 ... 29 -> Leichtes Übergewicht
 *                          
 *                          > 29 -> Übergewicht
 */

namespace _2023_12_11Aufgabe
{
    internal enum EGeschlecht
    {
        MALE = 1,
        FEMALE = 2
    }

    internal enum BMIAuswertung
    {
        NONE = 0,
        KRITISCHES_UNTERGEWICHT = 1,
        UNTERGEWICHT = 2,
        NORMALGEWICHT = 3,
        LEICHTES_UEBERGEWICHT = 4,
        UEBERGEWICHT = 5
    }
    /**
     * Erfasse die Klasse Mensch für die BMI Berechnung und BMI Auswertung
     */
    internal class Mensch
    {
        // Attribute
        /**
         * Gewicht in kg
         * Größe in cm
         * Geburtsdatum
         *                  -Hinweis: .NET API für Datum (Date?)
         */
        double gewicht;
        int groesse;
        readonly DateTime geburtsdatum;
        readonly EGeschlecht geschlecht;

        //Properties
        public EGeschlecht Geschlecht { get { return geschlecht; } }



        public double Gewicht
        {
            get { return gewicht; }
            set { gewicht = value; }
        }
        public int Groesse
        {
            get { return groesse; }
            set { groesse = value; }
        }

        public DateTime Geburtsdatum
        {


            get
            {

                return geburtsdatum;
            }


        }





        //public double getGewicht() { return gewicht; }
        //public void setGewicht(double gewicht) {this.gewicht = gewicht;}


        //Konstruktoren

        /**
         * Ein vollständig parameterisierter Konstruktor für die Initialisierung der Attribute
         */
        public Mensch(double gewicht, int groesse, DateTime geburtsdatum, EGeschlecht gesch)
        {
            this.gewicht = gewicht;
            this.groesse = groesse;
            this.geburtsdatum = geburtsdatum;
            this.geschlecht = gesch;
        }
        //Methoden
        /**
         * 1. Berechnung des BMIs
         * 2. Alter Berechnung 
         * 3. Auswertung 
         *          https://www.tk.de/service/app/2002866/bmirechner/bmirechner.app
         * 4. ToString
         *              -Textuelle Darstellung vom Zustand des Objekts
         * 
         */
        public double GetBMI()
        {
            double groesse_meter = this.groesse / 100.0;// 185 / 100.0 = 1.85
                                                        // return this.gewicht/ (groesse_meter * groesse_meter);
            return this.gewicht / Math.Pow(groesse_meter, 2);
        }

        public int GetAlter()
        {
            int alter = DateTime.Today.Year - this.geburtsdatum.Year;

            int monthToday = DateTime.Today.Month;
            int dayToday = DateTime.Today.Day;
            int monthGebDatum = this.geburtsdatum.Month;
            int dayGebDatum = this.geburtsdatum.Day;

            //if (monthToday < monthGebDatum || monthToday == monthGebDatum && dayToday < dayGebDatum) alter--;

            // etwas = (Boolean expression) ? exp1 : exp2;
            return (monthToday < monthGebDatum || monthToday == monthGebDatum && dayToday < dayGebDatum) ? --alter : alter;

        }
        /**
         * String Interpolation...
         */
        public override string ToString()
        {
            return $"Gewicht = {gewicht} Kg, Groesse = {groesse} cm, BMI = {GetBMI()}, Geburtsdatum = {geburtsdatum} und Alter = {GetAlter()}, Auswertung = {WerteBMIAus()}";
        }
        public string ToCSV()
        {
            return $"{gewicht},{groesse},{geburtsdatum}";
        }
        public BMIAuswertung WerteBMIAus()
        {
            double bmi = GetBMI();

            switch (this.geschlecht)
            {
                case EGeschlecht.MALE:
                    if (bmi < 16)
                        return BMIAuswertung.KRITISCHES_UNTERGEWICHT;
                    else if (bmi < 18.5)
                        return BMIAuswertung.UNTERGEWICHT;
                    else if (bmi < 25)
                        return BMIAuswertung.NORMALGEWICHT;
                    else if (bmi < 30)
                        return BMIAuswertung.LEICHTES_UEBERGEWICHT;
                    else
                        return BMIAuswertung.UEBERGEWICHT;

                case EGeschlecht.FEMALE:
                    if (bmi < 15)
                        return BMIAuswertung.KRITISCHES_UNTERGEWICHT;
                    else if (bmi < 17.5)
                        return BMIAuswertung.UNTERGEWICHT;
                    else if (bmi < 24)
                        return BMIAuswertung.NORMALGEWICHT;
                    else if (bmi < 29)
                        return BMIAuswertung.LEICHTES_UEBERGEWICHT;
                    else
                        return BMIAuswertung.UEBERGEWICHT;
                default:
                    return 0;
            }



        }
        /**
         * Die Methode soll aus einem String ein Mensch Objekt erzeugen und das Objekt zurückgeben. 
         * 
         * Wenn die Gestaltung des Parameters menschstring der Format Gewicht,Groesse,Geburtsdatum nicht entspricht, dann soll die Methode
         * eine FormatFormatException werfen, sonst soll dem String das entsprechende Mensch Objekt erzeugt und zurück gegeben werden.
         * 
         * 
         * Hinweis:
         *          - Ausnahmebehnadlung: try - catch - finally
         *          - Ausnahme werfen: throw statement
         *          - API: schaut Ihr Euch den Datentyp String an (.NET Doku)
         */

        public static Mensch Parse(string menschString)
        {
            //TODO
            return null;
        }

    }

    internal class MenschIO
    {
        /**
         * Definiere folgende Methoden
         * 
         * 1. Eine Methode, die aus der Konsole einen Wert für Geburtsdatum einliest und das Datum Objekt zurückgibt.
         * 2. Eine Methode, die aus der Konsole einen Wert für  Gewicht einliest und die Fließkommazahl zurückgibt
         * 3. Eine Methode, die aus der Konsole ein einen Wert für Größe einliest  und das ganze Zahl zurückgibt
         * 4. Eine Methode, die aus der Konsole die Daten für ein Mensch Objekt einliest und das Mensch Objekt zurückgibt.
         * 
         * Achte auf Werte Überprüfungen:
         *                                  User erneut auffordern oder
         *                                  Exception...
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
                return ReadBirthDayFromConsole(); //Rekursion
            }

        }

        public static double ReadWeightFromConsole(double min, double max)
        {
            Console.Write($"Gewicht in kg [{min} ... {max}]: ");
            try
            {
                double weight = double.Parse(Console.ReadLine());
                if (weight < min || weight > max)
                    return ReadWeightFromConsole(min, max);
                return weight;
            }
            catch (FormatException ex)
            {
                return ReadWeightFromConsole(min, max);
            }

        }
        public static int ReadHeightFromConsole(int min, int max)
        {
            Console.Write($"Groesse in cm [{min} ... {max}]: ");
            int height = 0;

            try
            {
                height = int.Parse(Console.ReadLine());
            }
            catch (FormatException ex)
            {
                return ReadHeightFromConsole(min, max);
            }

            if (height < min || height > max)
                return ReadHeightFromConsole(min, max);
            return height;
        }
        public static Mensch ReadMenschFromConsole(double minWeight, double maxWeight, int minHeight, int maxHeight)
        {
            return new Mensch(ReadWeightFromConsole(minWeight, maxWeight), ReadHeightFromConsole(minHeight, maxHeight), ReadBirthDayFromConsole(), EGeschlecht.MALE);
        }
    }
}
