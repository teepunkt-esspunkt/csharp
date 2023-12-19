using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
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
            transaktionen = new List<Transaktion>();
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
                    string iban = $"DE89{bic}{kontonummer}";
                    
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
                                string iban = $"DE89{bic}{kontonummer}";
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
        public static Konto IbanSuche(string iban)
        {
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
           Console.WriteLine($"|{"Iban", -26}|{"Kontostand", 12} in Euro|{"Kontonummer", -15}");

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

        public static void AuszahlenAuswahl()
        {
            try
            {
                Konto auszahlendesKonto = IbanSuche();
                if(auszahlendesKonto != null)
                {
                    decimal betrag = 0;
                    string beschreibung = "";
                    while (true)
                    {
                        Console.Write("Bitte Betrag eingeben: ");
                        try
                        {
                            betrag = decimal.Parse(Console.ReadLine());
                            if (betrag > 0 && betrag <= auszahlendesKonto.Kontostand)
                            {
                                Console.Write("Bitte Beschreibung eingeben: ");
                                beschreibung = Console.ReadLine();
                                auszahlendesKonto.Auszahlen(betrag, beschreibung);
                                break;
                            }
                            else if (betrag <= 0)
                            {
                                throw new ArgumentException("Bitte positiven Betrag eingeben");
                            }
                            else if (betrag > auszahlendesKonto.Kontostand)
                            {
                                throw new ArgumentException($"Unzureichendes Guthaben. Maxmimal verfuegbar: {auszahlendesKonto.Kontostand}.");
                            }
                        }
                        catch (ArgumentException ae)
                        {
                            Console.WriteLine(ae.Message);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Ungueltige Eingabe.");
                        }
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler aufgetreten");
            }
        }
        public static void EinzahlenAuswahl()
        {
            try
            {
                Konto einzuzahlendesKonto = IbanSuche();
                if (einzuzahlendesKonto != null)
                {
                    decimal betrag;
                    string beschreibung;
                    while (true)
                    {
                        Console.Write("Betrag eingeben: ");
                        try
                        {
                            betrag = decimal.Parse(Console.ReadLine());
                            if (betrag > 0)
                            {
                                Console.Write("Beschreibung eingeben: ");
                                beschreibung = Console.ReadLine();
                                einzuzahlendesKonto.Einzahlen(betrag, beschreibung);
                                break;
                            }
                            else
                             Console.WriteLine("Bitte positiven Betrag eingeben.");
                        }
                        catch (Exception) 
                        {
                            Console.WriteLine("Ungueltiger Betrag.");
                        }
                    }
                }
                else 
                    Console.WriteLine("Konto nicht gefunden");
            }
            catch (Exception) 
            {
                Console.WriteLine("Fehler aufgetreten");
            }
        }
        public void Einzahlen(decimal betrag, string beschreibung)
        {
            while (true)
            {
                try
                {
                    if (betrag > 0)
                    {
                        kontostand += betrag;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Ungueltige Eingabe");
                }
                Transaktion transaktion = new Transaktion(this.Iban, DateTime.Now, "Einzahlung", beschreibung, betrag);
                //var transaktion = new Transaktion 
                //{
                //    TransIban = this.iban,
                //    Zeitstempel = DateTime.Now, 
                //    Transaktionsart = "Einzahlung", 
                //    Beschreibungstext = beschreibung, 
                //    Betrag = betrag 
                //};
                transaktionen.Add(transaktion);
                break;
            }
        }

        public void Auszahlen(decimal betrag, string beschreibung)
        {
            while (true)
            {
                try
                {
                    if (betrag > 0 && Kontostand >= betrag)
                    {
                        Kontostand -= betrag;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Fehler aufgetreten");
                }
                Transaktion transaktion = new Transaktion(this.Iban, DateTime.Now, "Einzahlung", beschreibung, betrag);
                //var transaktion = new Transaktion 
                //{ 
                //    TransIban = this.iban,
                //    Zeitstempel = DateTime.Now, 
                //    Transaktionsart = "Auszahlung", 
                //    Beschreibungstext = beschreibung, 
                //    Betrag = betrag 
                //};
                Transaktionen.Add(transaktion);
                break;
            }
        }
        public static void KontenSpeichern(string ordnerPfad)
        {
            string speicherPfad = Path.Combine(ordnerPfad, "Kontenliste.csv");
            try
            {
                using (StreamWriter writer = new StreamWriter(speicherPfad))
                {
                    writer.WriteLine("Kundennummer,IBAN,Kontostand,Kontonummer");
                    foreach (var bank in Bank.AlleBanken())
                    {
                        foreach (var kunde in bank.Kunden)
                        {
                            foreach (var konto in kunde.Konten)
                            {
                                writer.WriteLine($"{kunde.Kundennummer},{konto.Iban},{konto.Kontostand},{konto.Kontonummer}");
                            }
                        }
                    }
                }
                Kunde.KundenSpeichern(ordnerPfad);
                Console.WriteLine($"Kontenliste wurde gespeichert in {speicherPfad}");
            }
            catch (Exception)
            {
                Console.WriteLine("Fehler beim Speichern.");
            }
        }
        public static void KontenImportieren(string ordnerPfad)
        {
           // Privatkunde pk1 = new Privatkunde
           //("Tony", "Montana", new DateTime(1999, 12, 12),
           //"511 655457", "T@M.de", new Adresse("Backstreet", "12", 30245, "mexico"),
           //1, Bank.HauptZentrale);
           // Firmenkunde fk1 = new Firmenkunde
           //("Tony", "511 655457", "T@M.de",
           //new Adresse("Backstreet", "12", 30245, "mexico"),
           //1,
           //Bank.HauptZentrale, new Ansprechpartner("Antonio", "Gustavson", "800 451478"));
            string standardPfad = Path.Combine(ordnerPfad, "Kontenliste.csv");
            try
            {
                using (StreamReader reader = new StreamReader(standardPfad))
                {
                    string ersteZeile = reader.ReadLine();

                    while (!reader.EndOfStream)
                    {
                        string zeile = reader.ReadLine();
                        var werte = zeile.Split(',');
                        int kundennummer = int.Parse(werte[0]);
                        string iban = werte[1];
                        decimal kontostand = decimal.Parse(werte[2]);
                        double kontonummer = double.Parse(werte[3]);
                        
                        Kunde.KundennummerSuche(kundennummer).Konten.Add(new Konto (iban, kontostand, kontonummer));
                        //Konto konto = new Konto(iban, kontostand, kontonummer);
                        //pk1.Konten.Add(konto);
                    }
                    Kunde.KundenImportieren(ordnerPfad);
                    Console.WriteLine("Kontenliste wurde erfolgreich importiert");
                }
            }
            catch (Exception)
            {
                Console.WriteLine($"Import nicht erfolgreich");
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
