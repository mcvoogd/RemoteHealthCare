using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class BigDatabase
    {
        List<Client> clientRegister { get; set; }

        public BigDatabase()
        {
            clientRegister = new List<Client>();
        }

        public void put (Client client)
        {
            bool alreadyThere = false;
            foreach (Client c in clientRegister)
            {
                if (c.Equals(client))
                {
                    alreadyThere = true;
                    break;
                }
            }

            if (!alreadyThere) { clientRegister.Add(client); }
            //Maybe add a clienthandler on the else.
        }
    }
}
