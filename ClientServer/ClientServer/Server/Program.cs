using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.TinyDataBase;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleTime time1 = new SimpleTime(10, 10);
            SimpleTime time2 = new SimpleTime(10, 20);
            SimpleTime time3 = new SimpleTime(11, 10);
            
            Console.WriteLine($"is 10:10 > 10:20 : {time1 > time2}");
            Console.WriteLine($"is 10:10 < 10:20 : {time1 < time2}");
            Console.WriteLine($"is 11:10 > 10:20 : {time3 > time2}");
            Console.WriteLine($"is 11:10 < 10:20 : {time3 < time2}");

            Console.WriteLine("--------------------------");
            Measurement m = new Measurement(0, 0, 0, 0, 0, 0, new SimpleTime(10, 10), 0);
            Measurement m1 = new Measurement(0, 0, 0, 0, 0, 0, new SimpleTime(9, 10), 0);

            TinyDataBase.TinyDataBase lijst = new TinyDataBase.TinyDataBase();

            lijst.AddMeasurement(m);
            lijst.AddMeasurement(m1);

            List<Measurement> temp = lijst.GetMeasurementsBetweenTimes(new SimpleTime(10, 00), new SimpleTime(12, 00));
            Console.WriteLine(temp[0] + "\n-------------------------\n" + temp[1]);

        }
    }
}
