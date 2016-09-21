using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Server.TinyDB;


namespace BigDB
{
    class Client
    {

        public string name { get; set; }
        public TinyDataBase TinyDataBaseBase { get; set; }
        public string tunnelID { get; set; }
        public int uniqueID { get; set; }
        protected status clientStatus { get; set; }
        protected enum status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string tunnelID, int uniqueID, TinyDataBase tinyDataBase)
        {
            this.name = name;
            this.tunnelID = tunnelID;
            this.uniqueID = uniqueID;
            this.TinyDataBaseBase = tinyDataBase;
            clientStatus = status.CONNECTED;
        }

        protected status getStatus() { return clientStatus; }
        protected void setStatus(status newStatus) { clientStatus = newStatus; }
    }
}
