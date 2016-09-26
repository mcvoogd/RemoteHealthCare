using System;

namespace Server.TinyDB
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
        public dynamic Message { get; set; }

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
            this.Message = GetMessageToSend();
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

        private dynamic GetMessageToSend()
        {
            dynamic toSend = new
            {
                id = "measurement/add",
                data = new
                {
                    pulse = Pulse,
                    rotations = Rotations,
                    speed = Speed,
                    distance = Distance,
                    power = Power,
                    burned = Burned,
                    time = Time,
                    reachedpower = ReachedPower
                }
            };
               return toSend;
        }
    }


    public struct SimpleTime
    {
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is SimpleTime && Equals((SimpleTime) obj);
        }

        public bool Equals(SimpleTime other)
        {
            return Minutes == other.Minutes && Seconds == other.Seconds;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Minutes*397) ^ Seconds;
            }
        }

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
            if (first.Minutes == second.Minutes)
            {
                return first.Seconds > second.Seconds ? true : false;
            }
            return false;
        }

        public static bool operator <(SimpleTime first, SimpleTime second)
        {
            if (first.Minutes < second.Minutes)
            {
                return true;
            }
            if (first.Minutes == second.Minutes)
            {
                return first.Seconds < second.Seconds ? true : false;
            }
            return false;
        }

        public static bool operator ==(SimpleTime first, SimpleTime second)
        {
            return first.Minutes == second.Minutes && first.Seconds == second.Seconds;
        }
        public static bool operator !=(SimpleTime first, SimpleTime second)
        {
            return first.Minutes != second.Minutes || first.Seconds != second.Seconds;
        }
    }
}