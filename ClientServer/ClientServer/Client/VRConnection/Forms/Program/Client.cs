using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VRFrom_Gijs.Program
{
    class Client : IComparable<Client>
    {
        public string Name { get; set; }
        public string Id { get; set; }

        public Client(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public int CompareTo(Client other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}
