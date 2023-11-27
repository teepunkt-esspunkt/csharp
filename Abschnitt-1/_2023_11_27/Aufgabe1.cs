using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_27
{
    internal class Aufgabe1
    {
        private static int ReadInt2(int lower, int upper)
        {
            /**
             * Eine Zahl zwischen lower (inklusiv) und upper (exklusiv) soll aus der Tastatur eingelesen werden
             * Eine fehlerhafte Eingabe soll behandelt werden
             */

            string eingabe = Console.ReadLine();
            int ausgabe = -1;
            try
            {
                ausgabe = int.Parse(eingabe);
            } catch (FormatException ex)
            {
                Console.WriteLine("Fehlerhafte Eingabe!");
                ReadInt2(lower, upper);
            }
            if(ausgabe >= lower && ausgabe < upper)
            {
                return ausgabe;
            }
            else
            {
                Console.WriteLine("Fehlerhafte Eingabe!");
                return ReadInt2(lower, upper);
            }
        }

        private static int ReadInt(string prompt, int lower, int upper)
        {
            int zahl = upper;

            Console.Write("Zahl: ");
            try
            {
                zahl = int.Parse(Console.ReadLine());
                if (zahl < upper && zahl >= lower)
                    return zahl;
               
                Console.WriteLine($"Zahl muss in dem Intervall[{lower}, {upper}[ liegen ");
                return ReadInt(prompt, lower, upper);
                
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return ReadInt(prompt, lower, upper);
            }
        }


        public static void Guess()
        {
            int zufallszahl = new Random().Next(101);

            Console.WriteLine("Ich habe eine Zufallszahl zwischen 0 und 100 generiert! Bitte errate Sie!");

            int zahl = -101;
            int anzahlVersuche = 0;

            //while (zufallszahl != zahl) ;
            for( ; zufallszahl != zahl; )
            {
                Console.Write("Zahl: ");
                zahl = int.Parse(Console.ReadLine());
                anzahlVersuche++;

                if (zufallszahl > zahl)

                    Console.WriteLine("Zufallszahl ist groesser!");

                else if (zufallszahl < zahl)
                    Console.WriteLine("Zufallszahl ist kleiner!");

                else
                {
                    Console.WriteLine($"Geschafft! Anzahl an Versuchen = {anzahlVersuche} ");
                    //break;
                }
            } 
            
        }
        public static void Guess2()
        {
            int zufallszahl = new Random().Next(101);

            Console.WriteLine("Ich habe eine Zufallszahl zwischen 0 und 100 generiert! Bitte errate Sie!");

            int zahl = -101;
            int anzahlVersuche = 0;

            //while (zufallszahl != zahl) ;
            for (; zufallszahl != zahl;)
            {
                
                zahl = ReadInt("Zahl: ", 0, 101);
                anzahlVersuche++;

                if (zufallszahl > zahl)

                    Console.WriteLine("Zufallszahl ist groesser!");

                else if (zufallszahl < zahl)
                    Console.WriteLine("Zufallszahl ist kleiner!");

                else
                {
                    Console.WriteLine($"Geschafft! Anzahl an Versuchen = {anzahlVersuche} ");
                    //break;
                }
            }

        }
    }
}
