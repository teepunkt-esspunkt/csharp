using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_12_05
{
    internal class Girokonto : Konto
    {
        private double dispo;
        public Girokonto(Kunde inhaber, string iban, double kontostand, double dispo) : base(inhaber, iban, kontostand)
        {
            if (dispo < 0)
                throw new ArgumentException("Negativer Dispo ist nicht zulässig : " + dispo);
            this.dispo = dispo;
        }

        public double Dispo
        {
            get { return dispo; }
            set { if (value < 0)
                    throw new ArgumentException("Negativer Dispo! : " + dispo);

                    dispo = value; }
        }

        public override string ToString() => base.ToString() + ":" + dispo; 


        public override bool Auszahlen(double betrag)
        {
            if (betrag < 0)
                throw new ArgumentException("Negative Betrag auszuzahlen ist nicht erlaubt! : " + betrag);
            if(betrag <= (Kontostand + dispo))
            {
                Kontostand -= betrag;
                return true;
            }
            return false;
        }

       
    }
}
