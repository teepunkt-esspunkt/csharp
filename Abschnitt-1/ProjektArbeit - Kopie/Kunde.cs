using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    // Kundenklasse
    internal abstract class Kunde
    {
        // Eigenschaften
        private readonly int maxKonten = 10;
        private int kundennummer = 1;
        private string telefonnummer;
        private string email;
        private Adresse adresse;
        private List<Konto> konten;

        // Konstruktor mit Uebergabe vorhandener Adresse
        public Kunde(string telefonnummer, string email, Adresse adresse, int anzahlKonten)
        {
            this.kundennummer = kundennummer++;
            this.telefonnummer = telefonnummer;
            this.email = email;
            this.adresse = adresse;
            this.konten = new List<Konto>(anzahlKonten);

        }
        // Konstruktor um AdressenObjekt mitzuerzeugen
        public Kunde(string telefonnummer, string email, string strasse, string hsnr, int plz, string ort, int anzahlKonten)
        {
            this.kundennummer = kundennummer++;
            this.telefonnummer = telefonnummer;
            this.email = email;
            this.adresse = new Adresse(strasse, hsnr, plz, ort);
            this.konten = new List<Konto>(anzahlKonten);
            
        }
    }
}
