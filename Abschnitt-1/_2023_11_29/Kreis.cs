using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace _2023_11_29
{
    internal class Kreis : Figur
    {
        private double radius;
        

        public double Radius
        {
            get { return radius; }
            set { radius = value; }
        }
        
        public Kreis(double radius, Punkt mittelpunkt) : base(mittelpunkt)
        {
  
            this.radius = radius;
            
        }
        public Kreis() : base(new Punkt(0,0))
        {
            this.radius = 1.0;
            
        }
        public Kreis(double radius, double xMp, double yMp) : base(new Punkt(xMp, yMp))
        {
            this.radius = radius;
            
        }

        public override string ToString() => $"{this.radius}:{this.mittelpunkt.ToString()}";
        public double Area() => Math.PI * Math.Pow(this.radius, 2);
        public double Perimeter() => 2 * Math.PI * this.radius;
        //liefert true, falls p innerhalb des Kreises sich befindet, sonst false
        public bool Contains(Punkt p) => this.mittelpunkt.DistanceTo(p) <  this.radius;
        
        
    }
}
