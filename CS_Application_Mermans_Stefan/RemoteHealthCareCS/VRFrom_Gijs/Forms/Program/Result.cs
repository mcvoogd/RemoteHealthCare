using System.Collections.Generic;

namespace VRFrom_Gijs.Program
{ 

    public class Clientinfo
    {
        public string file { get; set; }
        public string host { get; set; }
        public string renderer { get; set; }
        public int starttime { get; set; }
        public string user { get; set; }
    }

    public class Fps
    {
        public int time { get; set; }
        public double fps { get; set; }
    }

    public class Data
    {
        public Clientinfo clientinfo { get; set; }
        public string id { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public int lastping { get; set; }
        public List<Fps> fps { get; set; }
        public List<object> features { get; set; }
    }

    public class JsonRawData
    {
        public string id { get; set; }
        public List<Data> data { get; set; }
    }
}