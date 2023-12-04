// See https://aka.ms/new-console-template for more information
using _2023_11_29;

Console.WriteLine("Hello, World!");

Warenkorb w = new Warenkorb();
w.ArtikelHinzufuegen(new Artikel("Butter Milch", 1.99), 3);
w.ArtikelHinzufuegen(new Artikel("Schokolade", 2.99), 1);

double totalPreis = w.Gesamtwert();