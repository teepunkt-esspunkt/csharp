using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_12_04
{
    internal class Kunde
    {
       private string vorname;
       private string nachname;

        private Kunde(string vorname, string nachname)
        {
            this.vorname = vorname;
            this.nachname = nachname;

        }

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

        public static Kunde GetInstance(string vorname, string nachname)
        {
            return new Kunde(vorname, nachname);
        }

        public override string ToString() => nachname + ", " + vorname;

    }
}
