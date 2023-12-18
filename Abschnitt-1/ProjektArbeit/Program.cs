namespace ProjektArbeit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Privatkunde pk1 = new Privatkunde
           ("Tony", "Montana", new DateTime(1999, 12, 12),
           "511 655457", "T@M.de", new Adresse("Backstreet", "12", 30245, "mexico"),
           3, Bank.HauptZentrale);
            Firmenkunde fk1 = new Firmenkunde
           ("Tony", "511 655457", "T@M.de", 
           new Adresse("Backstreet", "12", 30245, "mexico"), 
           3, 
           Bank.HauptZentrale, new Ansprechpartner("Antonio", "Gustavson", "800 451478"));

            while (true)
            {

                // Anzeigen der Auswahlmoeglichkeiten
                MenuAufruf();
                //Auswahl treffen
                MenuWahl();
            }
        }

        // Anzeige der Auswahlmoeglichkeiten, Hauptmenu
        internal static void MenuAufruf()
        {
            Console.WriteLine("");
            Console.WriteLine("(01) Privatkunde anlegen");
            Console.WriteLine("(02) Firmenkunde anlegen");
            Console.WriteLine("(03) Konto anlegen und Kundennummer zuordnen");
            Console.WriteLine("(04) Kunde mit Konten anzeigen (Auswahl durch Kundennummer)");
            Console.WriteLine("(05) Kunde mit Konten anzeigen (Auswahl durch Namen)");
            Console.WriteLine("(06) Konto anzeigen (Auswahl durch IBAN)");
            Console.WriteLine("(07) Alle Kunden unsortiert anzeigen");
            Console.WriteLine("(08) Alle Kunden sortiert nach aufsteigender Kundenummer anzeigen");
            Console.WriteLine("(09) Alle Konten unsortiert anzeigen");
            Console.WriteLine("(0) Beenden");
            Console.WriteLine("");
        }
        // Auswahl treffen im Hauptmenu
        internal static void MenuWahl()
        {
            int menueWahl;
            try
            {
                menueWahl = int.Parse(Console.ReadLine());

                switch (menueWahl)
                {
                    case 1:
                        Privatkunde.PrivatkundeAnlegen();
                        break;
                    case 2:
                        Firmenkunde.FirmenkundeAnlegen();
                        break;
                    case 3:
                        Konto.KontoAnlegen();
                        break;
                    case 4:
                        Kunde.KundenMitKontoAnzeigenAuswahl();
                        break;
                    case 5:
                        Kunde.KundenMitKontoAnzeigenAuswahl();
                        break;
                    case 6:
                        Konto.IbanSuche();
                        break;
                    case 7:
                        Kunde.AlleKundenAnzeigen();
                        break;
                    case 8:
                        Kunde.AlleKundenAnzeigenSortieren();
                        break;
                    case 9:
                        Konto.AlleKonten();
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        throw new Exception();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ungueltige Auswahl! Bitte 0 - 9 waehlen");
            }
        }
    }
}