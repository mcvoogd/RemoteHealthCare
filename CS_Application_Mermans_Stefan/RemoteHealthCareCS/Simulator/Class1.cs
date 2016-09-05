using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    class SimulatorClass
    {
        private int hartslag = 70;
        private int rondesSeconde = 100;

        public int Hartslag
        {
            get
            {
                return hartslag;
            }

            set
            {
                hartslag = value;
            }
        }

        public int RondesSeconde
        {
            get
            {
                return rondesSeconde;
            }

            set
            {
                rondesSeconde = value;
            }
        }
    }
}
