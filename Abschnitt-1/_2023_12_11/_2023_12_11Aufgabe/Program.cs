namespace _2023_12_11Aufgabe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Mensch ben = new Mensch(71, 185, new DateTime(1984, 8, 18), EGeschlecht.MALE);
            Console.WriteLine(ben.ToString());
            // Console.WriteLine(ben.getGewicht());

            Console.Write(ben.Gewicht);//Getter
            ben.Gewicht = 69;//SetterW

            Mensch gusti = new Mensch(88, 187, new DateTime(1984, 8, 18), EGeschlecht.FEMALE);


        }
    }
}

