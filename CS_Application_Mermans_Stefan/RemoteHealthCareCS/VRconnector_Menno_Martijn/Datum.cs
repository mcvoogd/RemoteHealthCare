using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRconnector_Menno_Martijn
{
    public class Datum
    {
        public Clientinfo clientinfo { get; set; }
        public string id { get; set; }
        public int startTime { get; set; }
        public int endTime { get; set; }
        public int lastping { get; set; }
        public List<Fp> fps { get; set; }
        public List<object> features { get; set; }
    }
}
