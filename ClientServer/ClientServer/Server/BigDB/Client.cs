using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.TinyDB;


namespace Server.BigDB
{
    class Client
    {

        public string Name { get; set; }
        public TinyDataBase TinyDataBaseBase { get; set; }
        public string TunnelId { get; set; }
        public string UniqueId { get; set; }
        protected Status ClientStatus { get; set; }
        protected enum Status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string tunnelId, string uniqueId, TinyDataBase tinyDataBase)
        {
            this.Name = name;
            this.TunnelId = tunnelId;
            this.UniqueId = uniqueId;
            this.TinyDataBaseBase = tinyDataBase;
            ClientStatus = Status.CONNECTED;
        }

        protected Status GetStatus() { return ClientStatus; }
        protected void SetStatus(Status newStatus) { ClientStatus = newStatus; }
    }
}
