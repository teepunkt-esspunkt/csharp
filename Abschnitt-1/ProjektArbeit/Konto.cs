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

        public static Konto KontoAnlegen(Kunde kunde)
        {
           
            
            decimal kontostand = 0;
            double kontonummer = KontonummerGenerieren();
            string bic;
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

        public static double KontonummerGenerieren()
        {
            return (zufall.NextDouble() * (9999999999 - 1000000000) + 1000000000);
        }

    }
}
