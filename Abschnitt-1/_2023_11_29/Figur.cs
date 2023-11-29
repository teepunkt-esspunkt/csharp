using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_29
{
    /**
     * Abstrakte Klassen können nicht instanziiert werden - new ....
     * (base geht aber objekte kann man nicht erstellen)
     * Eine abstrakte Klasse darf abstrakte Methoden beinhalten
     * 
     * 
     */
    internal abstract class Figur
    {
        protected Punkt mittelpunkt;

        public Punkt Mittelpunkt
        {
            get { return this.mittelpunkt; }
            set {  this.mittelpunkt = value;}
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
