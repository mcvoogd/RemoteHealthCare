using System.Collections.Generic;
using System.Linq;

namespace Server.TinyDB
{
    class TinyDataBase
    {
        public MeasurementSystem MeasurementSystem { get; set; }
        public ChatSystem ChatSystem { get; set; }

        public TinyDataBase()
        {
            ChatSystem = new ChatSystem();
            MeasurementSystem = new MeasurementSystem();
        }

     
    }
}
