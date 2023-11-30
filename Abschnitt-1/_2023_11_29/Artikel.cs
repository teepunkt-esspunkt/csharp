using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_29
{
    internal class Artikel
    {
        private readonly String name;// UML: -name: String {final}
        private double preis;

        //UML: +Artikel(name : String, preis : double)
        public Artikel(string name, double preis)
        {
            this.name = name;
            this.preis = preis;
        }

        public double Preis
        {
            get { return preis; }
            set { preis = value; }  
        }
        public String name
        {
            get { return this.name; }
        }

    }

    internal class Warenkorb
    {
        private ArrayList artikels = new ArrayList();

        //UML: +ArtikelHinzufuegen(a : Artikel, steuckzahl : int) : void
        public void ArtikelHinzufuegen(Artikel a, int stueckzahl)
        {
            for(int i = 0; i < stueckzahl; i++)
            {
                artikels.Add(a);
            }
        }
        public double Gesamtwert()
        {
            double sum = 0;

            foreach(Artikel a in artikels)
            {
                sum += a.Preis;
            }
            return sum;
        }
    }
}


/**
 * public void bearbeiten(ladegerät ladegerät)
 * {
 * if(ladegerät.getLadestand() < 100 && ladegerät.getLadestand() > 20)
 * {
 *  ladegerät.setZustand(NormalLadend.getNormalLadend());
 * }
 * }
 */
   
}