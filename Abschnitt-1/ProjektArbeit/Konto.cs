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

        // Automatische Kontenerstellung bei Aufruf von PrivatkundeAnlegen oder FirmenkundeAnlegen.
        public static Konto KontoAnlegen(Kunde kunde)
        {
            decimal kontostand = 0;
            Console.Write("Bitte Startkapital eintragen: ");
            try
            {
                kontostand = decimal.Parse(Console.ReadLine());
                if (kontostand < 0)
                {
                    throw new ArgumentException("Startkapital darf nicht negativ sein.");
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine("Bitte gueltigen Betrag eingeben");
            }
            // Kontonummer generieren
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
            // iban generieren
            string iban = $"DE 89 {bic} {kontonummer}";
            // 
            Konto konto = new Konto(iban, kontostand, kontonummer);
            // zur Kontenliste des Kunden hinzufuegen
            kunde.Konten.Add(konto);
            return konto;
        }
        // Ueberladene Methode ohne Parameter fuer die Auswahl aus dem Menu
        public static Konto KontoAnlegen()
        {
            Kunde kunde;
            int kundennummer = 0;
            Console.Write("Bitte Kundennummer eingeben: ");

            try
            {
                kundennummer = int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Bitte gueltige Kundennummer eingeben.");
            }
            kunde = Kunde.KundennummerSuche(kundennummer);

            if (kunde != null)
            {
                decimal kontostand = 0;
                Console.Write("Bitte Startkapital eintragen: ");
                try
                {
                    kontostand = decimal.Parse(Console.ReadLine());
                    if (kontostand < 0)
                    {
                        throw new ArgumentException("Startkapital darf nicht negativ sein.");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Bitte gueltigen Betrag eingeben");
                }

                double kontonummer = KontonummerGenerieren();
                string bic;
                bic = kunde.Bank.Bic;


                string iban = $"DE 89 {bic} {kontonummer}";
                return (new Konto(iban, kontostand, kontonummer));
            }
            else
            {
                return null;
            }
        }
        //public static Kunde KundennummerSuche(int kundennummer)
        //{
        //    foreach (var bank in Bank.AlleBanken())
        //    {
        //        Kunde treffer = bank.Kunden.FirstOrDefault(k => k.Kundennummer == kundennummer);
        //        if(treffer != null)
        //        {
        //            return treffer;
        //        }
        //    }
        //    Console.WriteLine("Kunde nicht gefunden.");
        //    return null;
        //}


        public static double KontonummerGenerieren()
        {
            return (zufall.NextDouble() * (9999999999 - 1000000000) + 1000000000);
        }

        public override string ToString()
        {
            return $"{iban}, {kontostand}";
        }

    }
}
