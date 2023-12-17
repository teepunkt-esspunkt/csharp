using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    // Konten Klasse
    internal class Konto
    {
        // Fuer die Generierung der Kontonummer
        private static Random zufall = new Random();
        // Attribute
        private string iban;
        private decimal kontostand;
        private double kontonummer;


        // Properties
        public string Iban
        {
            get { return iban; }
            set { iban = value; }
        }
        public decimal Kontostand
        { 
            get { return kontostand; }
            set { kontostand = value; } 
        }
        public double Kontonummer
        {
            get { return kontonummer; }
            set { kontonummer = value; }
        }

        // Konstruktor
        public Konto(string iban, decimal kontostand, double kontonummer)
        {
            this.iban = iban;
            this.kontostand = kontostand;
            this.kontonummer = kontonummer;
           
        }

        // Automatische Kontenerstellung bei aufruf von PrivatkundeAnlegen() oder FirmenkundeAnlegen
        public static Konto KontoAnlegenAuto(Kunde kunde)
        {
            decimal kontostand = 0;
            double kontonummer = KontonummerGenerieren();
            string bic;
            // Wenn Kunde keine BIC hat, Hauptzentrale verwenden (da es in er Kundenerstellung verwendet wird)
            if (kunde.Bank != null && kunde.Bank.Bic != null)
            {
                bic = kunde.Bank.Bic;
            }
            else
            {
                bic = Bank.HauptZentrale.Bic;
            }
            string iban = $"DE 89 {bic} {kontonummer}";
            return (new Konto(iban, kontostand, kontonummer));
        }

        //public static Konto KontoAnlegen()
        //{
            
        //    Console.Write("Bitte Startkapital eintragen: ");
        //    try
        //    {
        //        decimal kontostand = decimal.Parse(Console.ReadLine());
        //        if(kontostand < 0)
        //        {
        //            throw new ArgumentException("Startkapital darf nicht negativ sein.");
        //        }
        //    }
        //    catch (ArgumentException ae)
        //    {
        //        Console.WriteLine(ae.Message);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Bitte gueltigen Betrag eingeben");
        //    }
        //    double kontonummer = KontonummerGenerieren();
        //    string bic;
         
        //    if (kunde.Bank != null && kunde.Bank.Bic != null)
        //    {
        //        bic = kunde.Bank.Bic;
        //    }
        //    else
        //    {
        //        bic = Bank.HauptZentrale.Bic;
        //    }
        //    string iban = $"DE 89 {bic} {kontonummer}";
        //    return (new Konto(iban, kontostand, kontonummer));
        //}





        public static double KontonummerGenerieren()
        {
            return (zufall.NextDouble() * (9999999999 - 1000000000) + 1000000000);
        }

    }
}
