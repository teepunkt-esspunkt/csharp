namespace ProjektArbeit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuAufruf();


        }

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
    }
}