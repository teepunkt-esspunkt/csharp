using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_29
{
    internal class Punkt
    {
        private double x;
        private double y;

        public Punkt(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double X
        {
            get { return x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return y; }
            set { this.y = value; }
        }

        public override string ToString() => $"({this.x} , {this.y})";

        public double DistanceTo(Punkt p) => Math.Sqrt(Math.Pow(this.x - p.x, 2) + Math.Pow(this.y - p.y, 2));
        


    }
}
