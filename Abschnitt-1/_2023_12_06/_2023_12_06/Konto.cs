using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_12_06
{
    internal abstract class Konto
    {
        private readonly Kunde inhaber;
        private readonly string iban;
        private double kontostand;
        //private double sparzins;


        public Kunde Inhaber
        {
            get { return inhaber; }
            //set { inhaber = value; }
        }
        public string Iban
        {
            get { return iban; }
            //set { iban = value; }
        }
        public double Kontostand
        {
            get { return kontostand; }
            set { kontostand = value; }
        }
        //public double Sparzins
        //{
        //    get { return sparzins; }
        //    set { sparzins = value; }
        //}
        public Konto(Kunde inhaber, string iban, double kontostand)
        {

            if (kontostand < 0)
                throw new ArgumentException("Mit negativen Betrag Konto eroeffnen ist nicht zulaessig! : " + kontostand);
            this.inhaber = inhaber;

            this.iban = iban;
            this.kontostand = kontostand;
            //this.sparzins = sparzins;
        }

        public override string ToString() => inhaber.ToString() + ":" + iban + ":" + kontostand;

        public void Einzahlen(double betrag)
        {
            if (betrag <= 0)
                throw new ArgumentException("Einzuzahlender Betrag muss nicht-negative Zahl sein! : " + betrag);
            this.kontostand += betrag;
        }

        public abstract bool Auszahlen(double betrag);
        public bool ueberweisen(Konto empfaenger, double betrag)
        {
            if(this.iban == empfaenger.iban)
            {
                return false;
            }
            if (this.Auszahlen(betrag))
            {
                empfaenger.Einzahlen(betrag);
                return true;
            }
            return false;

        }




    }
}
