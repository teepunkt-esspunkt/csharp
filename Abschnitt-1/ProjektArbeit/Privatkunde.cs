using System;
using System.Collections.Generic;
using System.Linq;
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

        // Constructor
        public Privatkunde(string vorname, string nachname, DateTime geburtsdatum, string telefonnummer, string email, Adresse adresse, int anzahlKonten) : base(telefonnummer, email, adresse, anzahlKonten)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtsdatum = geburtsdatum;

        }

        // Methode zum Privatkunden Anlegen
        internal static void PrivatkundeAnlegen()
        {
            // Leerzeile damit es nicht so an dem vorangegangenen Text klebt
            Console.WriteLine("");

            //Regex Pattern fuer Vor- und Nachname
            string  pattern = @"^[A-Za-zÖÄÜöäü]{2,}(?:[-\s'][A-Za-zÖÄÜöäü]+)?$";
            Regex regexName = new Regex(pattern);

            // Attribute
            string vorname;
            string nachname;

            //Vorname (Mit Throw New ArgumentException, welcher Weg ist besser?)
            while(true)
            { 
                Console.Write("Bitte Vornamen eingeben: ");
                
                try
                {
                    bool istGueltig;
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
                catch(ArgumentException ae)
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
                    bool istGueltig;
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
            //while (true)
            //{
                Console.Write("Bitte Geburtsdatum im Format \"JJJJ.MM.TT\"eingeben: ");
                string geburtsdatum = Console.ReadLine();


            //}

            // TODO: +49 vorbelegen, nur zahlen und leerzeichen und 1 / oder -
            Console.Write("Bitte Telefonnummer eingeben: ");
            string telefonnummer = Console.ReadLine();
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
