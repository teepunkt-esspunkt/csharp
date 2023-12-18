using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    internal class Transaktion
    {
        public string TransIban { get; set; }
        public DateTime Zeitstempel { get; set; }
        public string Transaktionsart { get; set; }
        public string Beschreibungstext { get; set; }
        public decimal Betrag { get; set; }


        public static void TransaktionslisteAbsteigendAnzeigen()
        {
            Console.WriteLine("Transaktionsliste absteigend sortiert nach Zeitstempel:");

            foreach (var bank in Bank.AlleBanken())
            {
                foreach (var kunde in bank.Kunden)
                {
                    foreach (var konto in kunde.Konten)
                    {
                        foreach (var transaktion in konto.Transaktionen.OrderByDescending(t => t.Zeitstempel))
                        {
                            Console.WriteLine($"IBAN: {transaktion.TransIban}, Zeitstempel: {transaktion.Zeitstempel}, Transaktionsart: {transaktion.Transaktionsart}, Beschreibung: {transaktion.Beschreibungstext}, Betrag: {transaktion.Betrag}");
                        }
                    }
                }
            }
        }

    }
}
