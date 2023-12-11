using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_12_11Aufgabe
{


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
            get { return geburtsdatum; }

        }
        public EGeschlecht Geschlecht
        {
            get { return Geschlecht; }
        }


        //public double getGewicht() { return gewicht; }
        //public void setGewicht(double gewicht) {this.gewicht = gewicht;}


        //Konstruktoren

        /**
         * Ein vollständig parameterisierter Konstruktor für die Initialisierung der Attribute
         */
        public Mensch(double gewicht, int groesse, DateTime geburtsdatum, EGeschlecht x)
        {
            this.gewicht = gewicht;
            this.groesse = groesse;
            this.geburtsdatum = geburtsdatum;
            this.geschlecht = x;
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
        public double getBMI()
        {
            double groesse_meter = this.groesse / 100.0;// 185 / 100.0 = 1.85
                                                        // return this.gewicht/ (groesse_meter * groesse_meter);
            return this.gewicht / Math.Pow(groesse_meter, 2);
        }

        public int getAlter()
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
            return $"Gewicht = {gewicht} Kg, Groesse = {groesse} cm, BMI = {getBMI()}, Geburtsdatum = {geburtsdatum} und Alter = {getAlter()}, Auswertung = {werteBMIAus()}";
        }

        public string werteBMIAus()
        {
            double bmi = getBMI();
            switch (this.geschlecht)
            {
                case EGeschlecht.MALE:
                    if (bmi < 16)
                        return "Kritisches Untergewicht";
                    else if (bmi < 18.5)
                        return "Untergewicht";
                    else if (bmi < 25)
                        return "Normalgewicht";
                    else if (bmi < 30)
                        return "Leichtes Übergewicht";
                    else
                        return "Übergewicht";
                case EGeschlecht.FEMALE:

                    if (bmi < 15)
                        return "Kritisches Untergewicht";
                    else if (bmi < 17.5)
                        return "Untergewicht";
                    else if (bmi < 24)
                        return "Normalgewicht";
                    else if (bmi < 29)
                        return "Leichtes Übergewicht";
                    else
                        return "Übergewicht";


            }
            if (this.geschlecht == EGeschlecht.MALE)
            {
                if (bmi < 16)
                    return "Kritisches Untergewicht";
                else if (bmi < 18.5)
                    return "Untergewicht";
                else if (bmi < 25)
                    return "Normalgewicht";
                else if (bmi < 30)
                    return "Leichtes Übergewicht";
                else
                    return "Übergewicht";
            }
            else
            {
                if (this.geschlecht == EGeschlecht.FEMALE)
                {

                }
            }
        }

        
    }
    internal enum EGeschlecht
    {
        MALE,
        FEMALE
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
    }
}
