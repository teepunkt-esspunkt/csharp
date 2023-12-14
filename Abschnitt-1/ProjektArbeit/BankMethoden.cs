using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    internal class BankMethoden
    {
        internal static Privatkunde Anlegen()
        {
            // Leerzeile damit es nicht so an dem vorangegangenen Text klebt
            Console.WriteLine("");

            //Regex Pattern fuer Vor- und Nachname
            string pattern = @"^[A-Za-zÖÄÜöäü]{2,}(?:[-\s'][A-Za-zÖÄÜöäü]+)?$";
            Regex regexName = new Regex(pattern);

            // Attribute
            //string vorname;
            //string nachname;
            //DateTime geburtsdatum;


            //Vorname (Mit Throw New ArgumentException, welcher Weg ist besser?)
            while (true)
            {
                Console.Write("Bitte Vornamen eingeben: ");

                try
                {
                    bool istGueltig;
                    string eingabe = Console.ReadLine();
                    if (regexName.IsMatch(eingabe))
                    {
                        Vorname = eingabe;
                        break;
                    }
                    else
                    {
                        throw new ArgumentException();
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Name darf nur aus alphabetischen Zeichen bestehen, und muss mindestens 2 Zeichen lang sein");
                }
            }
            // Nachname (Ohne Throw New... Welcher Weg ist besser?)
            while (true)
            {
                Console.Write("Bitte Nachname eingeben: ");

                try
                {
                    bool istGueltig;
                    string eingabe = Console.ReadLine();
                    if (regexName.IsMatch(eingabe))
                    {
                        Nachname = eingabe;
                        break;
                    }
                    // ist das hier ueberhaupt noetig? zZz
                    //else
                    //{
                    //    throw new ArgumentException();
                    //}
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine("Name darf nur aus alphabetischen Zeichen bestehen, und muss mindestens 2 Zeichen lang sein");
                }
            }

            // Geburtsdatum
            while (true)
            {
                Console.Write("Bitte Geburtsdatum im Format \"JJJJ.MM.TT\"eingeben: ");
                string eingabe = Console.ReadLine();
                try
                {
                    Geburtsdatum = DateTime.Parse(eingabe);
                }

            }

            // TODO: +49 vorbelegen, nur zahlen und leerzeichen und 1 / oder -
            Console.Write("Bitte Telefonnummer eingeben: ");
            string telefonnummer = Console.ReadLine();
            // Heere we GooO
            Console.Write("Bitte EMail eingeben: ");
            string email = Console.ReadLine();

            //wie name
            Console.Write("Bitte Strasse eingeben: ");
            string strasse = Console.ReadLine();

            // ezpz
            Console.Write("Bitte Hausnummer eingeben: ");
            string hsnr = Console.ReadLine();

            //ezpziest
            Console.Write("Bitte Postleitzahl eingeben: ");
            string plz = Console.ReadLine();

            // wie name(?)
            Console.Write("Bitte Ort eingeben: ");
            string ort = Console.ReadLine();
            // _
            Console.Write("Bitte Anzahl der gewünschten Konten eingeben: ");
            string anzahl = Console.ReadLine();

        }
    }
}
