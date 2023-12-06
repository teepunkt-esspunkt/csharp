using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Fehlerarten in der Programmierung
 *                      - Syntax Fehler -> Compiler Fehler
 *                      - Laufzeit Fehler -> Programmabbruch (Crash)
 *                      - Logische Fehler -> Programm läuft normal, macht aber was nicht beabsichtigt ist
 *                  
 *  Fehler Behandlung
 *  Conventional:
 *          - Was sind die Fehlerquellen? (Ursache)
 *                  -> Parameter
 *                  -> Benutzereingabe
 *                  -> ...
 *          - Wenn die Situation eintritt, dann speziellen Wert zurückgeben 
 *
 * Moderner Ansatz:
 *      Exception Mechanismus
 *      - Wenn der Ausnahmefall eintritt, soll ein entsprechendes Objekt geworfen werden
 *      
 *      Vorteile:
 *              1. Die Probleme des konventionelle Ansatz sind behoben
 *              2. Code Trennung:
 *                          - Fehler signalisieren (Error detection)
 *                          - Fehler behandeln (Error Handling)
 *              Lib Code:
 *                      - Die Stellen, wo Klassen und Methoden definiert sind
 *                      - Unterscheiden:
 *                                  - Normal Fall
 *                                  - Fehler Fall -> Signalisieren: throw Statement
 *              Client Code:
 *                      - Die Stellen, wo Klassen und Methoden verwendet werden (Aufruf)
 *                      - Funktionalitäten (Methoden) der Bibliothek (Lib Code) nicht blind verwenden
 *                              - Methoden, die evtl. Exception werfen, sollen "ueberwacht" aufgerufen werden -> Guarded Region (Try Block)
 *                                      -> try block
 *                              - Fehlerbehandlungscode anbieten oder den Fehler weiterleiten
 *              
 *                      
 * 
 */
namespace _2023_12_06
{
    internal class UmgangMitFehler
    {
        public static double Teilen(double a, double b)
        {
            if (b == 0) // Ausnahmefall identifiziert
                throw new ArgumentException("Teilen durch 0 == NONO");
            // Normal Fall
            return a / b;
        }

        public static long Fakul(int n)
        {
            if (n < 0)
                return -1;
            long result = 1;
            for (int i = 2; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }

        public static void Tester()
        {
            Console.WriteLine("Zaehler: ");
            string input = Console.ReadLine();
            double x = double.Parse(input);
            Console.WriteLine("Nenner: ");
            input = Console.ReadLine();
            double y = double.Parse(input);

            double q = Teilen(x, y);
            Console.WriteLine($"q = {q}");
        }
        
    }
}
