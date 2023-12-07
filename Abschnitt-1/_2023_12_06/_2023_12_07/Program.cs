
namespace _2023_12_07
{
    internal class Program
    {
        static void Main(string[] args)
        {



        }
    }

    /**
     * Ein Interface ist eine Sammlung von abstrakten Methoden
     * Den modifier abstract anzugeben ist optional
     */
    internal interface Eatable
    {
        bool IsTasty(); // Standardmaessig abstract

    }
    internal interface Flyable
    {
        abstract double fly();
    }

    internal abstract class Vehicle
    {
        public abstract double drive();
    }

    internal class Pizza : Eatable
    {
        bool Eatable.IsTasty()
        { 
            return true; 
        }
        
    }
    internal class Plance : Vehicle, Flyable
    {
        
        public override double drive()
        {
            return 646464;
        }
        double Flyable.fly()
        {
            return 64646464;
        }
    }
}