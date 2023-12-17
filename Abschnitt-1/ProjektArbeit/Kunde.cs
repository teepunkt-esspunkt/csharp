using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    // Kundenklasse
    internal abstract class Kunde
    {
        // Attribute
        private readonly int maxKonten = 10;
        private int kundennummer = 0;
        private static int neueKundennummer = 1;
        private string telefonnummer;
        private string email;
        private Adresse adresse;
        private List<Konto> konten;
        // Um BIC fuer die Kontoklasse zur Generierung der IBAN zugaenglich zu machen
        private Bank bank;

        // Properties
        public int Kundennummer
        {
            get { return kundennummer; }
            //set { kundennummer=value; }
        }
        public string Telefonnummer
        {
            get { return telefonnummer; }
            set { telefonnummer = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public Adresse Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public List<Konto> Konten
        {
            get { return konten; } 
            set { konten = value; }
        }
        public Bank Bank
        { 
            get { return bank; }
            set { bank = value; }
        }

        // Konstruktor mit Uebergabe vorhandener Adresse
        public Kunde(string telefonnummer, string email, Adresse adresse, int anzahlKonten, Bank bank = null)
        {
            this.kundennummer = neueKundennummer++;
            Telefonnummer = telefonnummer;
            Email = email;
            Adresse = adresse;
            // Konten erstellen
            Konten = new List<Konto>();           
            for (int i = 0; i < anzahlKonten; i++)
            {
                Konto.KontoAnlegen(this);
            }
            // Wenn keine Zweigstelle eingegeben wurde soll der Hauptsitz genommen werden
            Bank = bank ?? Bank.HauptZentrale;
            // Kunde zur Liste der Bank hinzufuegen
            Bank.Kunden.Add(this);
        }

        public static void KundenMitKontoAnzeigenAuswahl()
        {
           
            Console.Write("Bitte Namen oder Kundennummer eingeben: ");
            string eingabe = Console.ReadLine();
            if(int.TryParse(eingabe, out int kundennummer))
            {
                KundenMitKontoAnzeigen(kundennummer);
            }
            else if(!string.IsNullOrEmpty(eingabe))
            {
                KundenMitKontoAnzeigen(eingabe);
            }
           else
            {
                Console.WriteLine("Ungueltige Eingabe.");
            }
            
        }
        public static void KundenMitKontoAnzeigen(int kundennummer)
        {
            Kunde kunde = KundennummerSuche(kundennummer);
            if (kunde != null)
            {
                kunde.Konten.ToString();
            }
            else
            {
                Console.WriteLine("Kunde nicht gefunden.");
            }
        }
        public static void KundenMitKontoAnzeigen(string name)
        {
            Kunde kunde = KundenNamenSuche(name);
            if(kunde != null)
            {
                kunde.Konten.ToString();
            }
            else
            {
                Console.WriteLine("Kunde nicht gefunden");
            }
        }
        public static Kunde KundenNamenSuche(string name)
        {
            foreach (var bank in Bank.AlleBanken())
            {
                Kunde treffer = bank.Kunden.FirstOrDefault(k => k.Name == name);
                if (treffer != null)
                {
                    return treffer;
                }
            }
            return null;
        }
        public static Kunde KundennummerSuche(int kundennummer)
        {
            foreach (var bank in Bank.AlleBanken())
            {
                Kunde treffer = bank.Kunden.FirstOrDefault(k => k.Kundennummer == kundennummer);
                if (treffer != null)
                {
                    return treffer;
                }
            }
            Console.WriteLine("Kunde nicht gefunden.");
            return null;
        }
        
        // Methode fuer Ueberpruefugen (ausser fuer Geburtstag, PLZ, und Anzahl der Konten)
        public static string Pruefen(Regex regex, string aufforderung, string fehlermeldung)
        {
            while (true)
            {
                Console.Write(aufforderung);
                try
                {
                    string eingabe = Console.ReadLine();
                    if (regex.IsMatch(eingabe))
                    {
                        return eingabe;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(fehlermeldung);
                }
            }
        }
        // Pruefung der int variablen, Postleitzahl und Kontozanzahl
        public static int IntPruefen(string aufforderung, int min, int max, string fehlermeldung)
        {
            while (true)
            {
                Console.Write(aufforderung);
                try
                {
                    int eingabe = int.Parse(Console.ReadLine());

                    if (eingabe >= min && eingabe <= max)
                    {
                        return eingabe;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(fehlermeldung);
                }
            }
        }
    }
}
