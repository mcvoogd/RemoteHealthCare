using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRConnectorForm
{
    class Client : IComparable<Client>
    {
        public string ID { get; set; } 
        public string name { get; set; }

        public Client(string ID, string name)
        {
            this.ID = ID;
            this.name = name;
        }

        public int CompareTo(Client other)
        {
            return this.name.CompareTo(other.name);
        }
    }
}
