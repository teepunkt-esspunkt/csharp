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
        private readonly string name; // UML: -name: String {final}
        private double preis;       

        public Artikel(string name, double preis) // UML: +Artikel(name : String, preis : double)
        {
            this.name = name;
            this.preis = preis;
        }
        public double Preis
        {
            get { return preis; }
        }
    }
    internal class Warenkorb
    {
        private ArrayList artikels = new ArrayList();
        public void ArtikelHinzufuegen(Artikel a, int stueckzahl) //UML: +ArtikelHinzufuege(a : Artikel, stueckzahl : int) : void
        {
            for(int i = 0; i < stueckzahl;i++)
            {
                artikels.Add(a);
            }
        }
        public double Gesamtwert()
        {
            double sum = 0;
            foreach(Artikel a in  artikels)
            {
                sum += a.Preis;
                return sum;
            }
        }
    }
}
