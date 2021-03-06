﻿using System;
using System.Linq;
using Server.TinyDB;

namespace Server.BigDB
{
    public class Client
    {
        public Client(string name, string password, string tunnelId, int uniqueId,
            TinyDataBase tinyDataBase, bool isDoctor, int doctorId, bool isOnline)
        {
            IsOnline = isOnline;
            Name = name;
            Password = password;
            TunnelId = tunnelId;
            TinyDataBaseBase = tinyDataBase;
            IsDoctor = isDoctor;
            ClientStatus = Status.CONNECTED;
            DoctorId = doctorId;
            UniqueId = uniqueId == 0 ? GetUniqueId(name, password) : uniqueId;
        }

        public bool IsOnline { get; set; }
        public string Name { get; set; }
        public TinyDataBase TinyDataBaseBase { get; set; }
        public string TunnelId { get; set; }
        public int UniqueId { get; set; }
        public string Password { get; set; }
        protected Status ClientStatus { get; set; }
        public bool IsDoctor { get; set; }
        public int DoctorId { get; set; }

        protected Status GetStatus()
        {
            return ClientStatus;
        }

        protected void SetStatus(Status newStatus)
        {
            ClientStatus = newStatus;
        }

        public static int GetUniqueId(string username, string password)
        {
            if ((username == null) && (password == null)) return 0;
            var nameV = GetStringInNumbers(username);
            var passwordV = GetStringInNumbers(password);

            return (nameV*397) ^ passwordV;
        }

        public static int GetStringInNumbers(string text)
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

        public override string ToString()
        {
            return $"Client: {Name}, Id: {UniqueId}";
        }
    }
}