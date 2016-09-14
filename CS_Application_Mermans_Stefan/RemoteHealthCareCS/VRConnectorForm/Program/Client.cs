using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRConnectorForm.Program
{
    class Client : IComparable<Client>
    {
        public string name { get; set; }
        public string ID { get; set; }

        public Client(String ID, String name)
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
