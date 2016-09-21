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
        public int UniqueId { get; set; }
        protected status ClientStatus { get; set; }
        protected enum status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string tunnelId, int uniqueId, TinyDataBase tinyDataBase)
        {
            this.Name = name;
            this.TunnelId = tunnelId;
            this.UniqueId = uniqueId;
            this.TinyDataBaseBase = tinyDataBase;
            ClientStatus = status.CONNECTED;
        }

        protected status GetStatus() { return ClientStatus; }
        protected void SetStatus(status newStatus) { ClientStatus = newStatus; }
    }
}
