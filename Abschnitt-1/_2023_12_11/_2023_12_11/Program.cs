namespace _2023_12_11
{
    /**
     * Datentypen:
     *      - Einfache Datentypen (Primitive Datentypen)
     *      - Arrays
     *      - Klassen
     *      - Interfaces
     *      - Enums
     *      -(structs)
     *  API - Dateien
     *      - Dateibasierte Anwendungen
     *          ->Lesen aus Dateien und schreiben in Dateien
     *          
     *          
     *      
     */
    internal class Program
    {
        static void Main(string[] args) 
        {
            Mitarbeiter p = new Mitarbeiter(); // K.Fischer
            //KundenKonto k1 = new KundenKonto(); // nummer
            //KundenKonto k2 = new KundenKonto(); // nummer

            Kunde k1 = new Kunde(); // name = Knut
            k1.addKonto();
            k1.SetzeAnsprechpartner(p);
            Kunde k2 = new Kunde(); // Katrin
            k2.addKonto();
            k2.SetzeAnsprechpartner(p);
        
        }

    }

    internal class Person
    {
        private string name;

    }

    internal class KundenKonto
    {
        private string nummer;
    }

    internal class Kunde : Person
    {
        private Mitarbeiter ansprechpartner;
        private KundenKonto[] kontenliste = new KundenKonto[3];
        private int kontenZaehler = 0;
        public void addKonto()
        {
            if(kontenZaehler < 3)
            {
                kontenliste[kontenZaehler] = new KundenKonto();
            }
            kontenZaehler++;
        }

        public void SetzeAnsprechpartner(Mitarbeiter m)
        {
            this.ansprechpartner = m;
        }
        //public void addKonto2(KundenKonto kk)
        //{
        //    if (kontenZaehler < 3)
        //    {
        //        kontenliste[kontenZaehler] = kk;// new KundenKonto();
        //    }
        //    kontenZaehler++;
        //}
        //public KundenKonto GetFirstKonto()
        //{
        //    return kontenliste[0];
        //}
        

    }

    internal class Mitarbeiter : Person
    {

    }
}