using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Server.TinyDB;


namespace Server.BigDB
{
    class Client
    {

        public string Name { get; set; }
        public TinyDataBase TinyDataBaseBase { get; set; }
        public string TunnelId { get; set; }
        public int UniqueId { get; set; }
        public string Password { get; set; }
        protected Status ClientStatus { get; set; }
        protected enum Status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string password, string tunnelId, TinyDataBase tinyDataBase)
        {
            this.Name = name;
            this.Password = password;
            this.TunnelId = tunnelId;
            this.UniqueId = GetUniqueId();
            this.TinyDataBaseBase = tinyDataBase;
            ClientStatus = Status.CONNECTED;
        }

        protected Status GetStatus() { return ClientStatus; }
        protected void SetStatus(Status newStatus) { ClientStatus = newStatus; }

        public int GetUniqueId()
        {
            if (Name == null && Password == null) return 0;
            var nameV = GetStringInNumbers(Name);
            var passwordV = GetStringInNumbers(Password);
            Console.WriteLine("Made a new ID : " + (nameV*397 ^ passwordV));

            return nameV*397 ^ passwordV;
        }

        public int GetStringInNumbers(string text)
        {
            var nameArray = Name.ToCharArray();
            return nameArray.Sum(c => (int) c%32);
        }
    }
}
