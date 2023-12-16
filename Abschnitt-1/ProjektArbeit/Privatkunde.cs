using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjektArbeit
{
    // Privatkunden Klasse, Erbt von Kunde.
    internal class Privatkunde : Kunde
    {
        
        // Attribute
        private string vorname;
        private string nachname;
        private DateTime geburtsdatum;
        private string telefonnummer;
        private string email;
        private Adresse adresse;
        private int anzahlKonten;

        // Mindestalter für Kontoerstellung
        private static readonly int Mindestalter = 18;

        // Properties
        public string Vorname
        {
            get { return vorname; }
            set { vorname = value; }
        }
        public string Nachname
        {
            get { return nachname; }
            set { nachname = value; }
        }
        public DateTime Geburtsdatum
        {
            get { return geburtsdatum; }
            //set { geburtsdatum = value; }
        }
        public string Telefonnummer
        {
            get { return telefonnummer; }
            set { telefonnummer = value; }
        }
        public string Email
        {
            get { return email;}
            set { email = value; }
        }
        public Adresse Adresse
        {
            get { return adresse; }
            set { adresse = value; }
        }
        public int AnzahlKonten
        {
            get { return anzahlKonten; }
            set { anzahlKonten = value; }
        }
        // Konstruktor
        public Privatkunde(string vorname, string nachname, DateTime geburtsdatum, string telefonnummer, string email, Adresse adresse, int anzahlKonten) : base(telefonnummer, email, adresse, anzahlKonten)
        {
            Vorname = vorname;
            Nachname = nachname;
            this.geburtsdatum = geburtsdatum;
            Telefonnummer = telefonnummer;
            Email = email;
            Adresse = adresse;
            AnzahlKonten = anzahlKonten;
        }

        // Methode zum Privatkunden Anlegen
        public static Privatkunde PrivatkundeAnlegen()
        {
            // Regexe's
            //Regex Pattern fuer Vor- und Nachname
            string patternName = @"^[A-Za-zÖÄÜöäü]{2,}(?:[-\s'][A-Za-zÖÄÜöäü]+)?$";
            Regex regexName = new Regex(patternName);
            // Regex Pattern fuer Telefonnummer
            string patternTelePriv = @"^(?:\D*\d){7,}[\/\\-]?\d*$";
            Regex regexTelePriv = new Regex(patternTelePriv);
            // Regex Pattern fuer EMail Adresse
            string patternMail = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            Regex regexMail = new Regex(patternMail);
            //Regex Pattern fuer Strasse (nur 1 Zeichen mehr als name)
            string patternStrasse = @"^[A-Za-zÖÄÜöäü]{3,}(?:[-\s'][A-Za-zÖÄÜöäü]+)?$";
            Regex regexStrasse = new Regex(patternStrasse);
            //Regex Pattern fuer Hausnummer (nur 1 Zeichen mehr als name)
            string patternHsnr = @"^(?:[1-9]\d{0,2}|1\d{3})[ \/-]?[A-Za-z]{0,3}$";
            Regex regexHsnr = new Regex(patternHsnr);

            // Usereingaben ueberpruefen
            //string eingabe;
            string vorname = Pruefen(regexName, "Bitte Vornamen eingeben: ", "Vorname darf nur aus alphabetischen Zeichen bestehen, und muss mindestens 2 Zeichen lang sein.");
            string nachname = Pruefen(regexName, "Bitte Nachnamen eingeben: ", "Nachname darf nur aus alphabetischen Zeichen bestehen, und muss mindestens 2 Zeichen lang sein.");
            DateTime gerbutsdatum = GeburtsdatumPruefen();
            string telefonnummer = Pruefen(regexTelePriv, "Bitte Telefonnummer eingeben: (+49) ", "Bitte mit Vorwahl eingeben. Darf nur aus Zahlen, Leerzeichen und maximal ein / oder ein - bestehen.");
            string email = Pruefen(regexMail, "Bitte E-Mail Adresse eingeben: ", "Bitte gueltige E-Mail Adresse eingeben.");
            string strasse = Pruefen(regexStrasse, "Bitte Strasse eingeben: ", "Strasse darf nur aus alphabetischen Zeichen bestehen, und muss mindestens 3 Zeichen lang sein.");
            string hsnr = Pruefen(regexHsnr, "Bitte Hausnummer eingeben: ", "Muss aus einer Zahl gefolgt von 0-3 Buchstaben bestehen. Ein Leerzeichen, ein / oder - stehen ist erlaubt.");
            int plz = IntPruefen("Bitte Postleitzahl eingeben: ", 1067, 99998, "Bitte eine gueltige Postleitzahl zwischen 1067 und 99998 eingeben.");
            string ort = Pruefen(regexName, "Bitte Ort eingeben: ", "Bitte einen gueltigen Ort eingeben. Mindestens 2 alphabetische Zeichen.");
            int anzahlKonten = IntPruefen("Bitte Anzahl der gewuenschten Konten eingeben: ", 1, 10, "Bitte zwischen 1 und 10 waehlen.");
            // Aufruf des Konstruktors
            //DEBUG xxx
            Privatkunde privatkunde = new Privatkunde(vorname, nachname, gerbutsdatum, telefonnummer, email, new Adresse(strasse, hsnr, plz, ort), anzahlKonten);
            Console.WriteLine(privatkunde.ToString());
            return privatkunde;
            //return (new Privatkunde(vorname, nachname, gerbutsdatum, telefonnummer, email, new Adresse(strasse, hsnr, plz, ort), anzahlKonten));
        }

        // Methode fuer Ueberpruefugen (ausser fuer Geburtstag, PLZ, und Anzahl der Konten)
        public static string Pruefen(Regex regex, string aufforderung, string fehlermeldung)
        {
            while (true)
            {
                Console.Write(aufforderung);
                try
                {
                    string eingabe = Console.ReadLine();
                    if (regex.IsMatch(eingabe))
                    {
                        return eingabe;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(fehlermeldung);
                }
            }
        }

        // Ueberpruefung fuer das Geburtsdatum, Datum darf nicht in der Zukunft liegen und Mindestalter muss eingehalten werden
        public static DateTime GeburtsdatumPruefen()
        {
            while (true)
            {
                Console.Write("Bitte Geburtsdatum im Format \"JJJJ.MM.TT\" oder \"TT.MM.JJJJ\" eingeben: ");
                try
                {
                    DateTime eingabeDatum = DateTime.Parse(Console.ReadLine());
                    // Pruefen ob Datum in der Zukunft liegt
                    if (DateTime.Now > eingabeDatum)
                    {
                        // Alter festlegen
                        int alter = DateTime.Now.Year - eingabeDatum.Year;
                        // Ein Jahr abziehen falls der Geburtstag dieses Jahr erst noch kommt
                        if (DateTime.Now < eingabeDatum.AddYears(alter))
                            alter--;
                        // Altersueberpruefung
                        if (alter >= Mindestalter)
                        {
                            return eingabeDatum;
                        }
                        else
                        {
                            throw new ArgumentException($"Mindestalter: {Mindestalter}");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Datum darf nicht in der Zukunft liegen");
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Ungueltige Eingabe");
                }
            }
        }

        // Pruefung der int variablen, Postleitzahl und Kontozanzahl
        public static int IntPruefen(string aufforderung, int min, int max, string fehlermeldung)
        {
            while (true)
            {
                Console.Write(aufforderung);
                try
                {
                    int eingabe = int.Parse(Console.ReadLine());

                    if(eingabe >= min && eingabe <= max)
                    {
                        return eingabe;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine(fehlermeldung);
                }
            }
        }

        public override string ToString()
        {
            return $"{vorname}, {nachname}, {geburtsdatum}, {telefonnummer}, {email}, {adresse}, {anzahlKonten}";
//public Privatkunde(string vorname, string nachname, DateTime geburtsdatum, string telefonnummer, string email, Adresse adresse, int anzahlKonten) : base(telefonnummer, email, adresse, anzahlKonten)
        }
    }
  
}
