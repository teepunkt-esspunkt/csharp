using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    internal class Privatkunde : Kunde
    {
        private string vorname;
        private string nachname;
        private DateTime geburtsdatum;

        public Privatkunde(string vorname, string nachname, DateTime geburtsdatum, string telefonnummer, string email, Adresse adresse, int anzahlKonten) : base(telefonnummer, email, adresse, anzahlKonten)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtsdatum = geburtsdatum;

        }

        internal static void PrivatkundeAnlegen()
        {
            string vorname;
            while(true)
            { 
                Console.Write("Bitte Vornamen eingeben: ");
                string eingabe = Console.ReadLine();
                if(eingabe.Length >= 2 && eingabe.All(char.IsLetter)) 
                {
                    vorname = eingabe;
                    break;
                }
                else
                {
                    Console.WriteLine("Name darf nur aus Buchstaben bestehen, keine Umlaute oder Sonderzeichen, keine Leerzeichen und der Name muss mindestens 2 Zeichen lang sein")
                }
            }

            Console.Write("Bitte Nachnamen eingeben: ");
            string nachname = Console.ReadLine();
            //Console.Write("Bitte Geburtsdatum im Format \"JJJJ.MM.TT\"eingeben: ");
            //string geburtsdatum = Console.ReadLine();
            Console.Write("Bitte das Jahr der Geburt eingeben: ");
            string geburtsjahr = Console.ReadLine();
            Console.Write("Bitte den Monat der Geburt eingeben: ");
            string geburtsmonat = Console.ReadLine();
            Console.Write("Bitte den Tag der Geburt eingeben: ");
            string geburtstag = Console.ReadLine();
            Console.Write("Bitte Telefonnummer eingeben: ");
            string telefonnummer = Console.ReadLine();
            Console.Write("Bitte EMail eingeben: ");
            string email = Console.ReadLine();
            Console.Write("Bitte Strasse eingeben: ");
            string strasse = Console.ReadLine();
            Console.Write("Bitte Hausnummer eingeben: ");
            string hsnr = Console.ReadLine();
            Console.Write("Bitte Postleitzahl eingeben: ");
            string plz = Console.ReadLine();
            Console.Write("Bitte Ort eingeben: ");
            string ort = Console.ReadLine();
            Console.Write("Bitte Anzahl der gewünschten Konten eingeben: ");
            string anzahl = Console.ReadLine();

        }
    }
  
}
