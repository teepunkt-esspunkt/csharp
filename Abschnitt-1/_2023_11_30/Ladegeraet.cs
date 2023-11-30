using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2023_11_30
{
    internal class Ladegeraet
    {
        private Zustand zustand;
        private int ladestand;

        public Ladegeraet()
        {
            
            this.zustand = NichtLadend.getNichtLadend(); // ba
        }

        public void setZustand(Zustand zustand)
        {
            // TODO
        }
        public int getLadestand()
        {
            //TODO
            return this.ladestand;
        }
        public void ausloesen()
        {
            //TODO
        }
    }

    internal class NichtLadend : Zustand
    {
        private NichtLadend()
        {

        }
        public override void bearbeiten(Ladegeraet ladegeraet)
        {
            if(ladegeraet.getLadestand() >= 20 && ladegeraet.getLadestand() < 100)
            {
                ladegeraet.setZustand(NormalLadend.getNormalLadend());
            }
        }
        public static NichtLadend getNichtLadend()
        {
            //TODO
            return new NichtLadend();
        }
    }
    internal class NormalLadend : Zustand
    {
        public override void bearbeiten(Ladegeraet ladegeraet)
        {
            // TODO
        }
        public static NichtLadend getNormalLadend()
        {
            //TODO
            return new NormalLadend();
        }

    }
    internal class SchnellLadend : Zustand
    {
        private SchnellLadend()
        {

        }

        public override void bearbeiten(Ladegeraet ladegeraet)
        {
            //TODO
        }

        public static SchnellLadend getSchnellLadend()
        { 
            //TODO
            return new SchnellLadend(); 
        }

    }
}
