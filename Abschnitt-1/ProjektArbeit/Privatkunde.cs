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
        
    }
  
}
