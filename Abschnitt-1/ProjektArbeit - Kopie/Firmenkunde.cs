using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    internal class Firmenkunde : Kunde
    {
        private string name;
        private Ansprechpartner ansprechpartner;

        public Firmenkunde(string telefonnummer, string email, string strasse, string hsnr, int plz, string ort, int anzahlKonten) : base(telefonnummer, email, strasse, hsnr, plz, ort, anzahlKonten)
        {
        }
    }
}
