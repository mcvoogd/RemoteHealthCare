using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Client
    {
        protected string name { get; set; }
        //portected tinyDatabase clientData { get; set; }
        protected string tunnelID { get; set; }
        protected string uniqueID { get; set; }
        protected status clientStatus { get; set; }
        protected enum status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string tunnelID, string uniqueID /* tinyDataBase clientData*/)
        {
            this.name = name;
            this.tunnelID = tunnelID;
            this.uniqueID = uniqueID;
            //this.clientData = clientData;}
            clientStatus = status.CONNECTED;
        }
    }
}
