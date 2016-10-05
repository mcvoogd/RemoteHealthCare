using System;

namespace Client.VRConnection.Forms.Program
{
    internal class Client : IComparable<Client>
    {
        public Client(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
        public string Id { get; set; }

        public int CompareTo(Client other)
        {
            return Name.CompareTo(other.Name);
        }
    }
}