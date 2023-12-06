namespace _2023_12_06

{
    internal class Test
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Zaehler: ");
            string input = Console.ReadLine();

            double x;
            try // Guarded Region
            {
                x = double.Parse(input);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("Nenner: ");
            input = Console.ReadLine();
            double y;
            try
            {
                y = double.Parse(input);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
                y = 1;
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
                    y = 2;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                y = 3;
            }


            double q;
            try
            {
                q = UmgangMitFehler.Teilen(x, y);
            }
            catch (ArgumentException ex)
            { 
                Console.WriteLine(ex.Message); 
                q = (x > 0) ? double.PositiveInfinity : double.NegativeInfinity;
            }
            
            Console.WriteLine($"q = {q}");
        }
    }
}