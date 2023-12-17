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
            this.kundennummer = ++kundennummer;
            Telefonnummer = telefonnummer;
            Email = email;
            Adresse = adresse;
            // Konten erstellen
            Konten = new List<Konto>();           
            for (int i = 0; i < anzahlKonten; i++)
            {
                Konten.Add(Konto.KontoAnlegenAuto(this));
            }
            // Wenn keine Zweigstelle eingegeben wurde soll der Hauptsitz genommen werden
            Bank = bank ?? Bank.HauptZentrale;
            // Kunde zur Liste der Bank hinzufuegen
            Bank.KundenHinzufuegen(this);
        }
        public void KontoHinzufuegen(Konto konto)
        {
            Konten.Add(konto);
        }
        //public override string ToString()
        //{
        //    return $"{Kundennummer}, {Telefonnummer}, {Email}, {Adresse}, {konten.Count}";
        //}
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
