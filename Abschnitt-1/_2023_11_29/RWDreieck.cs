using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_29
{
    internal class RWDreieck : Dreieck
    {
        public RWDreieck(double a, double b, Punkt ep, Punkt mp)
        :base(a, b, Math.PI/2, ep, mp)
        {

        }
    }
}
