using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataScreen.Classes
{
    class Measurement
    {
        public int Pulse { get; set; }
        public int Rotations { get; set; }
        public int Speed { get; set; }
        public int Power { get; set; }
        public int Burned { get; set; }
        public int Time { get; set; }
        public int ReachedPower { get; set; }
        public int Distance { get; set; }

        public Measurement(int pulse, int rotations, int speed, int power, int burned, int time, int reachedpower,
            int distance)
        {
            this.Pulse = pulse;
            this.Rotations = rotations;
            this.Speed = speed;
            this.Power = power;
            this.Burned = burned;
            this.Time = time;
            this.ReachedPower = reachedpower;
            this.Distance = distance;
        }
     }
}
