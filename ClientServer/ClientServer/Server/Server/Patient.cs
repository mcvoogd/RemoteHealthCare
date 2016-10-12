using System;

namespace Server.Server
{
    public class Patient
    {
        public string Name { get; set; }
        public int ClientId { get; set; }
        public bool IsOnline { get; set; }

        public Patient(int clientId, bool isOnline, string name = "Patient")
        {
            Name = name;
            ClientId = clientId;
            IsOnline = isOnline;
        }

        public override string ToString()
        {
            switch (IsOnline)
            {
                case true:
                    return $"{Name} - Online";
                case false:
                    return $"{Name} - Offline";
                default:
                    return $"User error";
            }
        }
    }
}