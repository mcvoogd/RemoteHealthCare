using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Server.TinyDB;


namespace Server.BigDB
{
    public class Client
    {

        public string Name { get; set; }
        public TinyDataBase TinyDataBaseBase { get; set; }
        public string TunnelId { get; set; }
        public int UniqueId { get; set; }
        public string Password { get; set; }
        protected Status ClientStatus { get; set; }
        protected enum Status { NOT_CONNECTED, CONNECTED, READY_TO_GO, BIKING, FINISHED };

        public Client(string name, string password, string tunnelId, int clientId, TinyDataBase tinyDataBase)
        {
            this.Name = name;
            this.Password = password;
            this.TunnelId = tunnelId;
            this.TinyDataBaseBase = tinyDataBase;
            ClientStatus = Status.CONNECTED;
            if(clientId == 0)
            this.UniqueId = GetUniqueId(name, password);
            else
            {
                this.UniqueId = clientId;
            }
            Console.WriteLine($"Chosen id : {UniqueId}" );
        }

        protected Status GetStatus() { return ClientStatus; }
        protected void SetStatus(Status newStatus) { ClientStatus = newStatus; }

        public int GetUniqueId(string username, string password)
        {
            if (username == null && password == null) return 0;
            var nameV = GetStringInNumbers(username);
            var passwordV = GetStringInNumbers(password);
            //Console.WriteLine("Made a new ID : " + (nameV * 397 ^ passwordV));

            return nameV * 397 ^ passwordV;
        }

        public int GetStringInNumbers(string text)
        {
            var nameArray = text.ToCharArray();
            return nameArray.Sum(c => (int)c % 32);
        }

    }
}
