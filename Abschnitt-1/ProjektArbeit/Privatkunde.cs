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
        private DateTime geburtstag;

        public Privatkunde(string vorname, string nachname, DateTime geburtstag, string telefonnummer, string email, Adresse adresse, int anzahlKonten) : base(telefonnummer, email, adresse, anzahlKonten)
        {
            this.vorname = vorname;
            this.nachname = nachname;
            this.geburtstag = geburtstag;

        }

        internal static void PrivatkundeAnlegen()
        {
            Console.Write("Bitte Vornamen eingeben: ");
            string vorname = Console.ReadLine();
            Console.Write("Bitte Nachnamen eingeben: ");
            string nachname = Console.ReadLine();
            Console.Write("Bitte Geburtsdatum eingeben: ");
            string geburtsdatum = Console.ReadLine();
            Console.Write("Bitte Telefonnummer eingeben: ");
            string telefonnummer = Console.ReadLine();
            Console.Write("Bitte EMail eingeben: ");
            string email = Console.ReadLine();
            Console.Write("Bitte Adresse eingeben: ");
            string adresse = Console.ReadLine();
            Console.Write("Bitte Anzahl der gewünschten Konten eingeben: ");
            string anzahl = Console.ReadLine();

        }
    }
  
}
