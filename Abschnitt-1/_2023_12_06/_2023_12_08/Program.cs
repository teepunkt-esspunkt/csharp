namespace _2023_12_05
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }



    internal class Essel
    {
        public void Foo()
        {

        }
    }

    internal interface Pferd
    {
        public void Foo()
        {

        }
    }

    /**
     * Interfaces (Neue Features) dürfen:
     * 
     * 1. statische Methroden definieren:
     *              - dürfen aber nicht abstract sein!
     * 2. Interfaces dürfen für Methoden "default" Implementation anbieten
     */
    internal interface I
    {
        public static void M()
        {

        }

        public void F()
        {

        }
    }

    internal interface I1
    {
        public void M1();
    }

    internal interface I2
    {
        public void M2();
    }

    internal interface I3 : I1, I2
    {
        public void M3();
    }

    internal class C : I1
    {
        public void M1()
        {
            //TODO
        }
    }
    internal class Maultier : Essel, Pferd, I
    {

    }
    internal class C2 : I3
    {
        public void M1()
        {
            // TODO
        }

        public void M2()
        {
            // TODO
        }

        public void M3()
        {
            // TODO
        }
    }
}