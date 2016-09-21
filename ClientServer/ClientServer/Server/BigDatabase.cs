using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class BigDatabase
    {
        public List<Client> ClientRegister { get; set; }

        public BigDatabase()
        {
            ClientRegister = new List<Client>();
        }

        public void put (Client client)
        {
            var alreadyThere = false;
            foreach (var c in ClientRegister)
            {
                if (c.Equals(client))
                {
                    alreadyThere = true;
                    break;
                }
            }

            if (!alreadyThere) { ClientRegister.Add(client); }
            //Maybe add a clienthandler on the else.
        }
    }
}
