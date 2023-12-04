// See https://aka.ms/new-console-template for more information
using _2023_12_04;

Console.WriteLine(Kunde.GetInstance("Wondmu", "Alemu").ToString());

// Polymorphie
Konto k1 = new Girokonto(Kunde.GetInstance("Bob", "Marley"), "DE6721 344 456 833 16", 500, 10000);
k1.ueberweisen(k1, 100);
k1 = new Sparkonto(Kunde.GetInstance("Alice", "Marley"), "DE921 379 797 979 17", k1.Kontostand, 0.039);

/**
 * Nachmittag:
 *          - Den Code und das Diagramm vom Vormittag nacharbeiten
 *          - Erweiterung:
                            so wie jetzt steht bei der Methode überweisen, es ist möglich, dass Sender und Empfänger Konten gleich sind 
                            (identisch sind - nur ein Konto). 
                            Dies macht in der realen Welt keinen Sinn
            - Vorbereitung:
                            -Ausnahmebehandlung - Exception
                            -Interfaces
 */


