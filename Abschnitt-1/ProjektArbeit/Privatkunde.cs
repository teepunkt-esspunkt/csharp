using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    // Privatkunden Klasse, Erbt von Kunde.
    internal class Privatkunde : Kunde
    {
        // Attribute
        private string vorname;
        private string nachname;
        private DateTime geburtsdatum;

        // Properties
        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }

        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            set { geburtsdatum = value; }
        }
        // Constructor
        public Privatkunde(string vorname, string nachname, DateTime geburtsdatum, string telefonnummer, string email, Adresse adresse, int anzahlKonten) : base(telefonnummer, email, adresse, anzahlKonten)
        {
            Vorname = vorname;
            Nachname = nachname;
            Geburtsdatum = geburtsdatum;

        }

        // Methode zum Privatkunden Anlegen
        public static void PrivatkundeAnlegen()
        {
            //// Leerzeile damit es nicht so an dem vorangegangenen Text klebt
            //Console.WriteLine("");

            //Regex Pattern fuer Vor- und Nachname
            string patternName = @"^[A-Za-zÖÄÜöäü]{2,}(?:[-\s'][A-Za-zÖÄÜöäü]+)?$";
            Regex regexName = new Regex(patternName);
            // Regex Pattern fuer Telefonnummer
            string patternTele = @"^[\d\s]+[-/]?[\d\s]*$";
            Regex regexTele = new Regex(patternTele);

            // Attribute
            // werden ein weiteres mal benötigt, da auf die Attribute der Klasse noch nicht zugegriffen werden kann bevor sie nicht initialisiert, instanziert wird
            // diese Methode soll das Privatkunde Objekt erst erstellen
            string vorname;
            string nachname;
            DateTime geburtsdatum;
            string telefonnummer;


            //Vorname (Mit Throw New ArgumentException, welcher Weg ist besser?)
            while (true)
            {
                Console.Write("Bitte Vornamen eingeben: ");

                try
                {
                    string eingabe = Console.ReadLine();
                    if (regexName.IsMatch(eingabe))
                    {
                        vorname = eingabe;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Name darf nur aus alphabetischen Zeichen bestehen, und muss mindestens 2 Zeichen lang sein");
                }
            }
            // Nachname (Ohne Throw New... Welcher Weg ist besser?)
            while (true)
            {
                Console.Write("Bitte Nachname eingeben: ");

                try
                {
                    string eingabe = Console.ReadLine();
                    if (regexName.IsMatch(eingabe))
                    {
                        nachname = eingabe;
                        break;
                    }
                    // ist das hier ueberhaupt noetig? zZz
                    //else
                    //{
                    //    throw new ArgumentException();
                    //}
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Name darf nur aus alphabetischen Zeichen bestehen, und muss mindestens 2 Zeichen lang sein");
                }
            }

            // Geburtsdatum
            while (true)
            {
                Console.Write("Bitte Geburtsdatum im Format \"JJJJ.MM.TT\" oder \"TT.MM.JJJJ\" eingeben: ");
                
                try
                {
                    DateTime eingabe = DateTime.Parse(Console.ReadLine());
                   
                    if (DateTime.Now >  eingabe)
                    {
                        if (MINDESTALTER > 0 && MINDESTALTER < (DateTime.Now.Year)
                        {

                        }
                        geburtsdatum = eingabe;
                        break;
                    }

                    else
                    {
                        throw new ArgumentException();
                    }
                   
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ungueltige Eingabe");
                }
                catch (ArgumentException)
                {
                    Console.Write("Datum darf nicht in der Zukunft liegen");
                }
            }
            // +49 vorbelegt, nur zahlen und leerzeichen und ein Sonderzeichen / oder -
            while (true)
            {
                Console.Write("Bitte Telefonnummer eingeben: (+49) ");
                try
                {
                    string eingabe = Console.ReadLine();
                    if(regexTele.IsMatch(eingabe))
                    {
                        telefonnummer = eingabe;
                        break;
                    }
                    else { throw new ArgumentException(); }
                    
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Ungueltige Eingabe. Nur Zahlen, Leerzeichen und maximal 1 / oder -");
                }
            }

            // Heere we GooO
            Console.Write("Bitte EMail eingeben: ");
            string email = Console.ReadLine();

            //wie name
            Console.Write("Bitte Strasse eingeben: ");
            string strasse = Console.ReadLine();

            // ezpz
            Console.Write("Bitte Hausnummer eingeben: ");
            string hsnr = Console.ReadLine();

            //ezpziest
            Console.Write("Bitte Postleitzahl eingeben: ");
            string plz = Console.ReadLine();

            // wie name(?)
            Console.Write("Bitte Ort eingeben: ");
            string ort = Console.ReadLine();
            // _
            Console.Write("Bitte Anzahl der gewünschten Konten eingeben: ");
            string anzahl = Console.ReadLine();

        }
    }
  
}
