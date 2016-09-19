using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.TinyDataBase
{
    class TinyDataBase
    {
        private readonly List<Measurement> _measurements;

        public TinyDataBase()
        {
            _measurements = new List<Measurement>();
        }

        public List<Measurement> GetMeasurementsBetweenTimes(SimpleTime startTime, SimpleTime endTime)
        {
            List<Measurement> temp = new List<Measurement>();
            foreach(Measurement m in _measurements)
            {
                if (m.Time > startTime && m.Time < endTime)
                {
                    temp.Add(m);
                }   
            }

            temp.Sort(); //implemented comparable?
            return temp;
        }

        public void AddMeasurement(Measurement m)
        {
            if (m != null)
            {
                this._measurements.Add(m);
            }
        }

        public List<Measurement> GetMeasurementsAfterTime(SimpleTime time)
        {
            List<Measurement> temp = new List<Measurement>();

            foreach (Measurement m in _measurements)
            {
                if (m.Time > time)
                {
                    temp.Add(m);
                }
            }

            temp.Sort();
            return temp;
        }

        public List<Measurement> GetMeasurementsBeforeTime(SimpleTime time)
        {
            List<Measurement> temp = new List<Measurement>();

            foreach(Measurement m in _measurements)
            {
                if (m.Time < time)
                {
                    temp.Add(m);
                }
            }

            temp.Sort();
            return temp;
        }
    }
}
