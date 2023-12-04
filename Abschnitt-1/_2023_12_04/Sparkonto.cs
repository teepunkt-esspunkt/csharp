using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_12_04
{
    internal class Sparkonto : Konto
    {
        private double zinssatz;
        public Sparkonto(Kunde inhaber, string iban, double kontostand, double zinssatz) : base(inhaber, iban, kontostand)
        {
            this.zinssatz = zinssatz;
        }

       

        public double Zinssatz
        {
            get { return zinssatz; }
            set {
                if (value >= 0)
                    zinssatz = value;
                else
                    throw new ArgumentException("Negativer Zinssatz! : " + value);
                }
        }
        public override string ToString() => base.ToString() + ":" + zinssatz;
        
        public override bool Auszahlen(double betrag)
        {
            if (betrag < 0)
                throw new ArgumentException("Negativer Betrag auszuzahlen ist nicht erlaubt! " + betrag);
            if (betrag < Kontostand)
                return false;
            Kontostand -= betrag;
            return true;
        }

    }
}
