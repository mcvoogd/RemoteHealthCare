using System.Collections.Generic;
using System.Linq;

namespace Server.TinyDB
{
    public class MeasurementSystem
    {
        public readonly List<Measurement> _measurements;

        public MeasurementSystem()
        {
            _measurements = new List<Measurement>();
        }

        public List<Measurement> GetMeasurementsBetweenTimes(SimpleTime startTime, SimpleTime endTime)
        {
            var temp = _measurements.Where(m => (m.Time > startTime) && (m.Time < endTime)).ToList();
            temp.Sort();
            return temp;
        }

        public void AddMeasurement(Measurement m)
        {
            if (m != null)
                _measurements.Add(m);
        }

        public List<Measurement> GetAllMeasurements()
        {
            return _measurements;
        }

        public bool Contains(Measurement m)
        {
            return _measurements.Contains(m);
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