using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_28
{
    internal class Figur
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
    }
}
