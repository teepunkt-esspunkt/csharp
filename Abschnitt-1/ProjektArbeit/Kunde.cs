using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    
    internal abstract class Kunde
    {
        private readonly int maxKonten = 10;

        private int kundennummer = 1;

        private string telefonnummer;

        private string email;
        private Adresse adresse;

        private List<Konto> konten;

        public Kunde(string telefonnummer, string email, Adresse adresse, int anzahlKonten)
        {
            this.kundennummer = kundennummer++;
            this.telefonnummer = telefonnummer;
            this.email = email;
            this.adresse = adresse;
            this.konten = new List<Konto>(anzahlKonten);
            

        }
    }
}
