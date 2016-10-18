using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.TinyDB
{
    public class MeasurementSystem
    {
        public readonly List<Measurement> Measurements;
        public readonly List<List<Measurement>> Measurements2;
        public List<HistoryItem> History;

        public MeasurementSystem()
        {
            Measurements = new List<Measurement>();
            Measurements2 = new List<List<Measurement>>();
            History = new List<HistoryItem>();
        }

        //todo historybeter.
        public List<Measurement> GetMeasurementsBetweenTimes(SimpleTime startTime, SimpleTime endTime)
        {
            var temp = Measurements.Where(m => (m.Time > startTime) && (m.Time < endTime)).ToList();
            temp.Sort();
            return temp;
        }

        public List<Measurement> GetMeasurementsBetweenTimesNew(SimpleTime startTime, SimpleTime endTime, int HistoryNumber)
        {
            var temp = Measurements2[HistoryNumber].Where(m => (m.Time > startTime) && (m.Time < endTime)).ToList();
            temp.Sort();
            return temp;
        }

        public void AddMeasurement(Measurement m)
        {
            if (m != null)
                Measurements.Add(m);
        }

        public List<Measurement> GetAllMeasurements()
        {
            return Measurements;
        }

        public bool Contains(Measurement m)
        {
            return Measurements.Contains(m);
        }

        public List<Measurement> GetMeasurementsAfterTime(SimpleTime time)
        {
            var temp = Measurements.Where(m => m.Time > time).ToList();
            temp.Sort();
            return temp;
        }

        public List<Measurement> GetMeasurementsBeforeTime(SimpleTime time)
        {
            var temp = Measurements.Where(m => m.Time < time).ToList();

            temp.Sort();
            return temp;
        }
    }

    public struct HistoryItem
    {
        public SimpleTime StartTime { get; set; }
        public SimpleTime EndTime { get; set; }
        public int HistoryNumber { get; set; }

        public HistoryItem(SimpleTime startTime, SimpleTime endTime, int historynumber)
        {
            StartTime = startTime;
            EndTime = endTime;
            HistoryNumber = historynumber;
        }
    }
}