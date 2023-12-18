using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    internal class Transaktion
    {
        public string IBAN { get; set; }
        public DateTime Zeitstempel { get; set; }
        public string Transaktionsart { get; set; }
        public string Beschreibungstext { get; set; }
        public decimal Betrag { get; set; }

    }
}
