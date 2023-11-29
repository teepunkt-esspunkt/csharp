using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_28
{
    internal class Kreisring : Kreis
    {
        private double radius2;

        public double Radius2
        {
            get {  return radius2; }
            set { radius2 = value; }
        }

        public Kreisring(double radius, double radius2, Punkt mittelpunkt) : base(radius, mittelpunkt)
        {
            this.radius2 = radius2;
        }
        public Kreisring() : base(0, new Punkt(0, 0))
        {

        }
    }
}
