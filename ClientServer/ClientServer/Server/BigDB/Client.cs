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
        public string tunnelID { get; set; }
        public string uniqueID { get; set; }
        protected status clientStatus { get; set; }
        protected enum status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string tunnelID, string uniqueID, TinyDataBase tinyDataBase)
        {
            this.Name = name;
            this.tunnelID = tunnelID;
            this.uniqueID = uniqueID;
            this.TinyDataBaseBase = tinyDataBase;
            clientStatus = status.CONNECTED;
        }

        protected status GetStatus() { return clientStatus; }
        protected void SetStatus(status newStatus) { clientStatus = newStatus; }
    }
}
