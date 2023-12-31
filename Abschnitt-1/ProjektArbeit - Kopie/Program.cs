﻿namespace ProjektArbeit
{
    internal class Program
    {
        static void Main(string[] args)
        {

            


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
            Console.WriteLine("(01) Privatkunde anlegen");
            Console.WriteLine("(02) Firmenkunde anlegen");
            Console.WriteLine("(03) Konto anlegen und Kundennummer zuordnen");
            Console.WriteLine("(04) Kunde mit Konten anzeigen (Auswahl durch Kundennummer)");
            Console.WriteLine("(05) Kunde mit Konten anzeigen (Auswahl durch Namen)");
            Console.WriteLine("(06) Konto anzeigen (Auswahl durch IBAN)");
            Console.WriteLine("(07) Alle Kunden unsortiert anzeigen");
            Console.WriteLine("(08) Alle Kunden sortiert nach aufsteigender Kundenummer anzeigen");
            Console.WriteLine("(09) Alle Konten unsortiert anzeigen");
            Console.WriteLine("(10) Beenden");
        }

        // Auswahl treffen im Hauptmenu
        internal static void MenuWahl()
        {
            // als es noch im Main stand, wird das hier noch benoetigt oder brauche ich einen anderen weg??
            bool laeuft = true;

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
                        Console.WriteLine("Auwahl 2");
                        break;
                    case 3:
                        Console.WriteLine("Auswahl 3");
                        break;
                    case 4:
                        Console.WriteLine("Auswahl 4");
                        break;
                    case 5:
                        Console.WriteLine("Auswahl 5");
                        break;
                    case 6:
                        Console.WriteLine("Auswahl 6");
                        break;
                    case 7:
                        Console.WriteLine("Auwahl 7");
                        break;
                    case 8:
                        Console.WriteLine("Auswahl 8");
                        break;
                    case 9:
                        Console.WriteLine("Auswahl 9");
                        break;
                    case 0:
                        Console.WriteLine("Auwahl 0");
                        laeuft = false;
                        break;
                    default:
                        Console.WriteLine("Ungueltige Auswahl! Bitte 0 - 9 waehlen");
                        break;
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        //internal static void PrivatkundAnlegen()
        //{

        //}

    }
}