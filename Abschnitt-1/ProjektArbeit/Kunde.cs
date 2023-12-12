using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    
    internal class Kunde
    {
        private int kundennummer;

        private string telefonnummer;

        private string email;
        private Adresse adresse;

        private Konto[] konten =  new Konto[10];
    }
}
