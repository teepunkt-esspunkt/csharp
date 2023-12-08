namespace _2023_12_08Aufgabe
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }

    internal interface SampleProvider
    {
        public string GetType();
        public void FetchSample(double[] messdaten);
        public int SampleSize();
    }

    public class DruckSensor : SampleProvider
    {
        public void FetchSample(double[] messdaten)
        {
            // TODO
        }

        public string GetType()
        {
            return "";
        }

        public int SampleSize()
        {
            return 0;
        }

        public class TemperaturSensor : SampleProvider
        {
            void SampleProvider.FetchSample(double[] messdaten)
            {
                
            }

            string SampleProvider.GetType()
            {
                return "";
            }

            int SampleProvider.SampleSize()
            {
                return 0;
            }
        }
        internal abstract class Filter : SampleProvider
        {
            protected SampleProvider sp;

            public Filter(SampleProvider sp)
            {
                this.sp = sp;
            }
        }

        internal class AvgFilter : Filter
        {
            public AvgFilter(SampleProvider sp) : base(sp)
            {
            }
            public void FetchSample(double[] messdaten)
            {
                this.sp.FetchSample(messdaten);
            }
            public int SampleSize()
            {
                return this.sp.SampleSize();
            }
            public string GetType()
            {
                return this.sp.GetType();
            }
        }
    }


}