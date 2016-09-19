using System.Collections.Generic;
using System.Linq;

namespace Server.TinyDB
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
            var temp = _measurements.Where(m => m.Time > startTime && m.Time < endTime).ToList();
            temp.Sort();
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
            var temp = _measurements.Where(m => m.Time > time).ToList();
            temp.Sort();
            return temp;
        }

        public List<Measurement> GetMeasurementsBeforeTime(SimpleTime time)
        {
            var temp = _measurements.Where(m => m.Time < time).ToList();

            temp.Sort();
            return temp;
        }
    }
}
