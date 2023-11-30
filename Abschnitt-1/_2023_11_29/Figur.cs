using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_29
{
    /**
     * Abstrakte klassen können nicht instanziiert werden - new ...
     * Eine abstrakte Klasse darf abstrakte Methoden beinhalten
     */
    internal abstract  class Figur
    {
        protected Punkt mittelpunkt;

        public Punkt Mittelpunkt
        {
            get { return this.mittelpunkt;}
            set { this.mittelpunkt = value; }
        
        }
        public Figur(Punkt mittelpunkt)
        {
            this.mittelpunkt= mittelpunkt;
        }
        public override string ToString() => $"{this.mittelpunkt.ToString()}";

        public abstract double Area(); 
        public abstract double Perimeter();
    }
}
