using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRconnector_Menno_Martijn
{
    class Packet
    {
        String id { get;  set;}
        String[] commands { get; set; }

        public Packet(String id, String[] commands)
        {
            this.id = id;
            this.commands = commands;
        }
    }
}
