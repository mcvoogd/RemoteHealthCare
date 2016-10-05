using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Server
{

  
    class Patient
    {
        public string Name { get; set; }
        public int clientId { get; set; }

        public Patient(string name, int clientId)
        {
            this.Name = name;
            this.clientId = clientId;
        }
    }
}
