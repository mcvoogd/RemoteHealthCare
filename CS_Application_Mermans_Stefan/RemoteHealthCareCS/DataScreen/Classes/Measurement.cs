using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataScreen.Classes
{
     public class Measurement
     {
        public int Pulse { get; set; }
        public int Rotations { get; set; }
        public int Speed { get; set; }
        public double Distance { get; set; }
        public int Power { get; set; }
        public int Burned { get; set; }
        public SimpleTime Time { get; set; }
        public int ReachedPower { get; set; }
        public readonly string OrigionString;

        public Measurement(int pulse, int rotations, int speed, int power, double distance, int burned, SimpleTime time, int reachedpower)
        {
            this.Pulse = pulse;
            this.Rotations = rotations;
            this.Speed = speed;
            this.Distance = distance;
            this.Power = power;
            this.Burned = burned;
            this.Time = time;
            this.ReachedPower = reachedpower;
        }

        public Measurement(int pulse, int rotations, int speed, int power, double distance, int burned, SimpleTime time, int reachedpower, string origin)
        {
            this.Pulse = pulse;
            this.Rotations = rotations;
            this.Speed = speed;
            this.Distance = distance;
            this.Power = power;
            this.Burned = burned;
            this.Time = time;
            this.ReachedPower = reachedpower;
            this.OrigionString = origin;    
        }
    }


    public struct SimpleTime
    {
        public readonly int Minutes;
        public readonly int Seconds;

        public SimpleTime(int min, int sec)
        {
            Minutes = min;
            Seconds = sec;
        }

        public override string ToString()
        {
            return $"{Minutes:00}:{Seconds:00}";
        }
    }
}