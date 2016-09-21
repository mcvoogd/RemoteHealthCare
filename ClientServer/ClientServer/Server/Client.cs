using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.TinyDB;


namespace Server
{
    class Client
    {
        protected string Name { get; set; }
        protected TinyDataBase ClientData { get; set; }
        protected string TunnelId { get; set; }
        protected string UniqueId { get; set; }
        protected Status ClientStatus { get; set; }
        protected enum Status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string tunnelId, string uniqueId /* tinyDataBase clientData*/)
        {
            this.Name = name;
            this.TunnelId = tunnelId;
            this.UniqueId = uniqueId;
            //this.clientData = clientData;}
            ClientStatus = Status.CONNECTED;
        }
    }
}
