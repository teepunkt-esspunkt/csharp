using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal class Kreis
    {
        private double radius;
        private Punkt mittelpunkt;

        public Kreis(double radius, Punkt mittelpunkt)
        {
            this.radius = radius;
            this.mittelpunkt = mittelpunkt;
        }
        public Kreis()
        {
            this.radius = 1.0;
            this.mittelpunkt = new Punkt(0, 0);
        }
        public Kreis(double radius, double xMp, double yMp)
        {
            this.radius=radius;
            this.mittelpunkt = new Punkt(xMp, yMp);

        }
        public override string ToString() => $"{this.radius} : {this.mittelpunkt.ToString()}";
        public double Area() => Math.PI * Math.Pow(this.radius, 2);
        public double Perimeter() => 2 * Math.PI * this.radius;
        public bool Contains(Punkt p) => this.mittelpunkt.DistanceTo(p) < this.radius;


    }
}
