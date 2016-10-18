using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.TinyDB
{
    public class MeasurementSystem
    {
        public readonly List<Measurement> Measurements;
        public readonly List<List<Measurement>> SessionMeasurementList;

        public MeasurementSystem()
        {
            Measurements = new List<Measurement>();
            SessionMeasurementList = new List<List<Measurement>>();
        }

        // Save the session to the session list and clear the old measurements
        public void SaveSession()
        {
            var newList = new List<Measurement>();
            foreach (var measurement in Measurements)
            {
                newList.Add(measurement);
            }
            Measurements.Clear();

            SessionMeasurementList.Add(newList);
            Console.WriteLine($"SERVER: saved new session: {SessionMeasurementList.Count}");
        }

        public List<Measurement> GetMeasurementsHistory(int index)
        {
            return SessionMeasurementList[index];
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