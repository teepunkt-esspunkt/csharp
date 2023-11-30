using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_29
{
    internal class Rechteck
    {
        private double breite;
        private double laenge;
        private Punkt mittelpunkt;
        public double Breite
        {
            get { return this.breite;} set { this.breite = value; }    
        }
        public double Laenge
        { get { return this.laenge;} set { this.laenge = value;} }
        public Punkt Mittelpunkt
        {
            get { return this.mittelpunkt; }
            set { this.mittelpunkt = value; }
        }

        public Rechteck(double breite, double laenge, Punkt mittelpunkt )
        {
            this.breite = breite;
            this.laenge = laenge;   
            this.mittelpunkt= mittelpunkt;
        }
        public override string ToString() => $"{this.breite}:{this.laenge}:{this.mittelpunkt.ToString()}";
        public double Area() =>this.breite * this.laenge;
        public double Perimeter() => 2 * (this.breite + this.laenge);
       
    }
}
