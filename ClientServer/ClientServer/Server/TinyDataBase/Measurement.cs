using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.TinyDataBase
{
    public class Measurement : IComparable<Measurement>
    {
        public int Pulse { get; set; }
        public int Rotations { get; set; }
        public int Speed { get; set; }
        public double Distance { get; set; }
        public int Power { get; set; }
        public double Burned { get; set; }
        public SimpleTime Time { get; set; }
        public int ReachedPower { get; set; }
        public readonly string OriginString;

        public Measurement(int pulse, int rotations, int speed, int power, double distance, double burned, SimpleTime time, int reachedpower)
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

        public Measurement(int pulse, int rotations, int speed, int power, double distance, double burned, SimpleTime time, int reachedpower, string origin)
        {
            this.Pulse = pulse;
            this.Rotations = rotations;
            this.Speed = speed;
            this.Distance = distance;
            this.Power = power;
            this.Burned = burned;
            this.Time = time;
            this.ReachedPower = reachedpower;
            this.OriginString = origin;
        }

        public int CompareTo(Measurement other)
        {
            if (this.Time == other.Time)
            {
                return 0;
            }
            if (this.Time > other.Time)
            {
                return 1;
            }
            if (this.Time < other.Time)
            {
                return -1;
            }
            return 0;
        }

        public override string ToString()
        {
            return $"Pulse : {Pulse}" +
                   $"\nRotations : {Rotations}" +
                   $"\nSpeed : {Speed}" +
                   $"\nPower : {Power}" +
                   $"\nDistance : {Distance}" +
                   $"\nBurned : {Burned}" +
                   $"\nTime : {Time}" +
                   $"\nReachedPower : {ReachedPower}";
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

        public static bool operator >(SimpleTime first, SimpleTime second)
        {
            if (first.Minutes > second.Minutes)
            {
                return true;
            }
            return first.Seconds > second.Seconds ? true : false ;
        }

        public static bool operator <(SimpleTime first, SimpleTime second)
        {
            if (first.Minutes < second.Minutes)
            {
                return true;
            }
            return first.Seconds < second.Seconds ? true : false;
        }

        public static bool operator ==(SimpleTime first, SimpleTime second)
        {
            if (first.Minutes == second.Minutes && first.Seconds == second.Seconds)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(SimpleTime first, SimpleTime second)
        {
            if (first.Minutes == second.Minutes && first.Seconds == second.Seconds)
            {
                return false;
            }
            return true;
        }

        
    }
}