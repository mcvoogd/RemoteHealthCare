using System;
using System.Linq;
using Server.TinyDB;

namespace Server.BigDB
{
    public class Client
    {
        public Client(string name, string password, string tunnelId, int uniqueId, bool isDoctor,
            TinyDataBase tinyDataBase, bool isOnline)
        {
            IsOnline = isOnline;
            Name = name;
            Password = password;
            TunnelId = tunnelId;
            TinyDataBaseBase = tinyDataBase;
            IsDoctor = isDoctor;
            ClientStatus = Status.CONNECTED;
            UniqueId = uniqueId == 0 ? GetUniqueId(name, password) : uniqueId;
            Console.WriteLine($"Chosen id : {UniqueId}");
        }
        public bool IsOnline { get; set; }
        public string Name { get; set; }
        public TinyDataBase TinyDataBaseBase { get; set; }
        public string TunnelId { get; set; }
        public int UniqueId { get; set; }
        public string Password { get; set; }
        protected Status ClientStatus { get; set; }
        public bool IsDoctor { get; set; }

        protected Status GetStatus()
        {
            return ClientStatus;
        }

        protected void SetStatus(Status newStatus)
        {
            ClientStatus = newStatus;
        }

        public int GetUniqueId(string username, string password)
        {
            if ((username == null) && (password == null)) return 0;
            var nameV = GetStringInNumbers(username);
            var passwordV = GetStringInNumbers(password);

            return (nameV*397) ^ passwordV;
        }

        public int GetStringInNumbers(string text)
        {
            var nameArray = text.ToCharArray();
            return nameArray.Sum(c => (int) c%32);
        }

        protected enum Status
        {
            NOT_CONNECTED,
            CONNECTED,
            READY_TO_GO,
            BIKING,
            FINISHED
        }
    }
}