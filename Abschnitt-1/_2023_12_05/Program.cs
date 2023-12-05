// See https://aka.ms/new-console-template for more information
using _2023_12_05;

List<Konto> konten = new List<Konto>(); // Generische Datentypen
konten.Add(new Girokonto(Kunde.GetInstance("Otto", "Meyer"), "DE23", 500, 800));
konten.Add(new Girokonto(Kunde.GetInstance("Boris", "Becker"), "DE48", 0, 0));
konten.Add(new Sparkonto(Kunde.GetInstance("Thomas", "Müller"), "DE52", 46464643000, .039));
Console.WriteLine(konten);
foreach (Konto konto in konten)
    Console.WriteLine(konto.ToString());
Console.WriteLine("......");

konten.ElementAt(1).Einzahlen(100);

konten.ElementAt(2).ueberweisen(konten.ElementAt(1), 3000);
//konten.ElementAt(1).Auszahlen(1000);
Konto sender = konten.ElementAt(2);
Konto receiver = konten.ElementAt(1);

Console.WriteLine($"sender: {sender}");
Console.WriteLine($"Receiver: {receiver}");

receiver.Auszahlen(1000);

foreach (Konto konto in konten)
    Console.WriteLine(konto.ToString());

Console.WriteLine($"sender: {sender}");
Console.WriteLine($"Receiver: {receiver}");

Girokonto gk = new Girokonto(Kunde.GetInstance("VN", "NN"), "DE67", 500, 800);
Girokonto gk_2 = new Girokonto(Kunde.GetInstance("VN2", "NN2"), "DE672", 1000, 1000);

gk.Einzahlen(100);
gk_2.ueberweisen(gk, 200);

Console.WriteLine(gk);
Console.WriteLine(gk_2);

Girokonto gk3 = new Girokonto(Kunde.GetInstance("VN", "NN"), "DE67", 500, 800);

Sparkonto sk = new Sparkonto(Kunde.GetInstance("VN2", "NN2"), "DE672", 1000, .039);

gk3.Einzahlen(100);

Console.WriteLine(sk.ueberweisen(gk3, 100));
Console.WriteLine(gk3);
Console.WriteLine(sk);

//Console.WriteLine($"Thomas: {konten.ElementAt(2)}");
//Console.WriteLine($"Thomas: {konten.ElementAt(1)}");

//Console.WriteLine(Kunde.GetInstance("Wondmu", "Alemu").ToString());

//// Polymorphie
//Konto k1 = new Girokonto(Kunde.GetInstance("Bob", "Marley"), "DE6721 344 456 833 16", 500, 10000);
//k1.ueberweisen(k1, 100);
//Console.WriteLine(((Girokonto)k1).Dispo);
//k1 = new Sparkonto(Kunde.GetInstance("Alice", "Marley"), "DE921 379 797 979 17", k1.Kontostand, 0.039);
//int x = 1050;
//Console.WriteLine((byte)x);

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


//_2023_12_04.Hause.Wohnung.Zimmer toom = new _2023_12_04.Hause.Wohnung.Zimmer();