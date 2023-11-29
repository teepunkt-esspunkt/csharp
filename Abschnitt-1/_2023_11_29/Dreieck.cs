using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_29
{
    internal class Dreieck : Figur
    {
        private double a;
        private double b;
        private double gamma;
        private Punkt eckPunkt;
        public Dreieck(double a, double b, double gamma, Punkt eckPunkt, Punkt center)
            : base(center)
        {
            this.a = a;
            this.b = b;
            this.gamma = gamma;
            this.eckPunkt = eckPunkt;
        }
        public double A
        {
            get { return a; }
            set { a = value; }
        }
        public double B
        {
            get { return b; }
            set { b = value; }
        }
        public double Gamma
        {
            get { return gamma; }
            set { gamma = value; }
        }
        public Punkt Eckpunkt
        {
            get { return eckPunkt; }
            set { eckPunkt = value; }
        }
        public override string ToString()
        {
            return $"{base.ToString()} : {this.eckPunkt.ToString()}:{this.a}:{this.b}:{this.gamma}";
        }

        public override double Area()
        {
            return .5 * this.a * this.b * Math.Sin(this.gamma);
        }
        public override double Perimeter()
        {
            return this.a + this.b + C;
        }
        public double C
        {
            get { return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2) - 2 * a * b * Math.Cos(gamma)); }
        }
    }
}
