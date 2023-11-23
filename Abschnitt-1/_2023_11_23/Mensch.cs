using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


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

        public Mensch(DateTime geburtsDatum, int groesse, double gewicht)
        {
            this.geburtsDatum = geburtsDatum;
            this.groesse = groesse;
            this.gewicht = gewicht;
            getAlter();
            
        }

        public double getBMI()
        {
            double groesse_meter = this.groesse / 100.0;

            //return this.gewicht/ (groesse_meter * groesse_meter);
            return this.gewicht / Math.Pow(groesse_meter, 2);
        }
        public int getAlter()
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
            return alter;

        }

        //internal string BmiStand(double bmi)
        //{
        //    if(this.alter <= 24)
        //    {
        //        if(bmi < 19)
        //        {
        //            return "Untergewicht";
        //        }
        //        else if (bmi >= 19 && bmi <= 24)
        //        {
        //            return "Normalgewicht";
        //        }
        //        else 
        //        { 
        //            return "Uebergewicht"; 
        //        }
        //    }
        //    else if(this.alter >= 25 && this.alter <= 34) 
        //    {
        //        if (bmi < 20)
        //        {
        //            return "Untergewicht";
        //        }
        //        else if (bmi >= 20 && bmi <= 25)
        //        {
        //            return "Normalgewicht";
        //        }
        //        else
        //        {
        //            return "Uebergewicht";
        //        }
        //    }
        //    else if(this.alter >= 35 && this.alter <= 44)
        //    {
        //        if (bmi < 21)
        //        {
        //            return "Untergewicht";
        //        }
        //        else if (bmi >= 21 && bmi <= 26)
        //        {
        //            return "Normalgewicht";
        //        }
        //        else
        //        {
        //            return "Uebergewicht";
        //        }
        //    }
        //    else if (this.alter >= 45 && this.alter <= 54)
        //    {
        //        if (bmi < 22)
        //        {
        //            return "Untergewicht";
        //        }
        //        else if (bmi >= 22 && bmi <= 27)
        //        {
        //            return "Normalgewicht";
        //        }
        //        else
        //        {
        //            return "Uebergewicht";
        //        }
        //    }
        //    else if (this.alter >= 55 && this.alter <= 64)
        //    {
        //        if (bmi < 23)
        //        {
        //            return "Untergewicht";
        //        }
        //        else if (bmi >= 23 && bmi <= 28)
        //        {
        //            return "Normalgewicht";
        //        }
        //        else
        //        {
        //            return "Uebergewicht";
        //        }
        //    }
        //    else
        //    {
        //        if (bmi < 24)
        //        {
        //            return "Untergewicht";
        //        }
        //        else if (bmi >= 24 && bmi <= 29)
        //        {
        //            return "Normalgewicht";
        //        }
        //        else
        //        {
        //            return "Uebergewicht";
        //        }
        //    }
           
        //}
        public string werteBMIaus()
        {
            double bmi = getBMI();
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

            double bmi = getBMI();
            //string bmiString = BmiStand(bmi);
            //return "Alter: " + this.alter + ", Groesse: " + this.groesse + ", Gewicht: " + this.gewicht + ", BMI: " + bmi + ", Ihr BMI Zustand: " + bmiString;
            //return "Gewicht = " + this.gewicht + " Kg" + ", Groesse = " + this.groesse + " cm" + ", BMI " + this.getBMI() + ", Geburtsdatum " + this.geburtsDatum + ", Alter = " + this.getAlter();
            return $"Gewicht = {gewicht} Kg, Groesse = {groesse} + cm, BMI = {getBMI()}, Geburtsdatum = {geburtsDatum}, Alter = {getAlter()}, Auswertung = {werteBMIaus()}";
        }

    }
    internal class MenschIO
    {
        /** Definiere folgende Methoden
         * 
         * 1. Eine Methode, die aus der Konsole einen Wert für Geburtsdatum einliest und das Datum Objekt zurückgibt
         * 2. Eine Methode, die aus der Konsole einen Wert für Gewicht einliest und die Fliesskommazahl zurückgibt
         * 3. Eine Methode, die aus der Konsole einen Wert für Groesse einliest und als ganze Zahl zurückgibt
         * 4. Eine Methode, die aus der Konsole die Daten für ein Mensch Objekt einliest und ein Mensch Objekt zurückgibt
         * 
         * Achte auf Werte Überprüfungen
         *                  User erneut auffordern
         *                  oder Exception
         */
                           
    }
}
