using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{

    // Adressen Klasse
    internal class Adresse
    {
        // Eigenschaften
        private string strasse;
        private string hsnr;
        private int plz;
        private string ort;

        // Konstruktor
        public Adresse(string strasse, string hsnr, int plz, string ort)
        {
            this.strasse = strasse;
            this.hsnr = hsnr;
            this.plz = plz;
            this.ort = ort;
        }

        public override string ToString()
        {
            return $"{strasse}, {hsnr}, {plz:D5}, {ort}";
        }

    }

}
