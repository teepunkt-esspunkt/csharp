using System;
using System.Collections.Generic;
using System.Globalization;
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
        private List<Transaktion> transaktionen;



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
        public List<Transaktion> Transaktionen
        {
            get { return transaktionen; }
            set { transaktionen = value; }
        }

        // Konstruktor
        public Konto(string iban, decimal kontostand, double kontonummer)
        {
            this.iban = iban;
            this.kontostand = kontostand;
            this.kontonummer = kontonummer;
           
        }

        // Kontenerstellung bei Aufruf von PrivatkundeAnlegen oder FirmenkundeAnlegen.
        public static Konto KontoAnlegen(Kunde kunde)
        {
            while (true)
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
                    
                    Konto konto = new Konto(iban, kontostand, kontonummer);
                    // zur Kontenliste des Kunden hinzufuegen
                    kunde.Konten.Add(konto);
                    return konto;
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);

                }
                catch (Exception e)
                {
                    Console.WriteLine("Bitte gueltigen Betrag eingeben");

                }
            }
        }
        // Ueberladene Methode ohne Parameter fuer die Auswahl aus dem Menu
        public static Konto KontoAnlegen()
        {
            Kunde kunde = null;
            int kundennummer = 0;

            while (true)
            {
                Console.Write("Bitte Kundennummer eingeben: ");
                try
                {
                    kundennummer = int.Parse(Console.ReadLine());
                
                    kunde = Kunde.KundennummerSuche(kundennummer);
                    if (kunde != null && kunde.Konten.Count < kunde.MaxKonten)
                    {
                        while (true)
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
                                double kontonummer = KontonummerGenerieren();
                                string bic;
                                bic = kunde.Bank.Bic;


                                string iban = $"DE 89 {bic} {kontonummer}";
                                Konto konto = new Konto(iban, kontostand, kontonummer);
                                kunde.Konten.Add(konto);
                                return konto;
                            }
                            catch (ArgumentException ae)
                            {
                                Console.WriteLine(ae.Message);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Bitte gueltigen Betrag eingeben");
                            }
                        }
                    }
                    else if (kunde == null)
                    {
                        
                        throw new ArgumentException("Kunde nicht vorhanden.");
                    }
                    else
                    {
                        
                        throw new ArgumentException($"Maximale Anzahl der Konten erreicht.");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Bitte gueltige Kundennummer eingeben.");
                }
            }
        }

        public static Konto IbanSuche()
        {
            Console.WriteLine("Bitte vollstaendige IBAN eingeben.");
            string iban = Console.ReadLine();

            foreach (var bank in Bank.AlleBanken())
            {
                foreach (var kunde in bank.Kunden)
                {
                    foreach (var konto in kunde.Konten)
                    {
                        if (konto.Iban.Contains(iban, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(konto.ToStringPlus());
                            return konto;
                        }
                    }
                }
            }
            Console.WriteLine("Ungueltige IBAN");
            return null;
        }
        
        public static void AlleKonten()
        {
            Console.WriteLine($"|{"Iban", -26} | {"Kontostand", 12} in Euro | {"Kontonummer", -15}");

           foreach (var bank in Bank.AlleBanken())
            {
                foreach(var kunde in bank.Kunden)
                {
                    foreach (var konto in kunde.Konten)
                    {
                        Console.WriteLine(konto.ToStringPlus());
                    }

                }
            }
        }
        public static void EinzahlenAuswahl()
        {
            decimal betrag = 0;
            string beschreibung = "";
            try
            {
                Konto einzuzahlendesKonto = IbanSuche();
                betrag = decimal.Parse(Console.ReadLine());
                beschreibung = Console.ReadLine();
                einzuzahlendesKonto.Einzahlen(betrag, beschreibung);
            }
            catch(Exception)
            {
                Console.WriteLine("Fehler aufgetreten");
            }
        }
        public static void AuszahlenAuswahl()
        {
            decimal betrag = 0;
            string beschreibung = "";
            try
            {
                Konto einzuzahlendesKonto = IbanSuche();
                betrag = decimal.Parse(Console.ReadLine());
                beschreibung = Console.ReadLine();
                einzuzahlendesKonto.Auszahlen(betrag, beschreibung);
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler aufgetreten");
            }
        }
        public void Einzahlen(decimal betrag, string beschreibung)
        {
            try
            {
                betrag = decimal.Parse(Console.ReadLine());
                if (betrag > 0)
                {
                    kontostand += betrag;
                } else
                {
                    throw new ArgumentException("Einzuzahlender Betrag muss positiv sein.");
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
            catch (Exception)
            {
                Console.WriteLine("Ungueltige Eingabe");
            }
            var transaktion = new Transaktion { Zeitstempel = DateTime.Now, Transaktionsart = "Einzahlung", Beschreibungstext = beschreibung, Betrag = betrag };
            Transaktionen.Add(transaktion);
        }
        public void Auszahlen(decimal betrag, string beschreibung)
        {
            if(Kontostand >= betrag)
            {
                Kontostand -= betrag;
                var transaktion = new Transaktion { Zeitstempel = DateTime.Now, Transaktionsart = "Auszahlung", Beschreibungstext = beschreibung, Betrag = betrag };
                Transaktionen.Add(transaktion);
            }
            else
            {
                Console.WriteLine($"Kein ausreichendes Guthaben. Verfügbares Guthaben: {this.kontostand}");
            }
        }
        public static double KontonummerGenerieren()
        {
            return Math.Floor((zufall.NextDouble() * (9999999999 - 1000000000) + 1000000000));
        }

        public override string ToString()
        {
            return $"{iban}, {kontostand}";
        }
        public string ToStringPlus()
        {
            return $"|{Iban, -25}|{Kontostand.ToString("N2"), 15} Euro|{Kontonummer, -15}";
        }

    }
}
