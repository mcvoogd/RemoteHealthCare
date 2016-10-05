namespace Server.Server
{
    internal class Patient
    {
        public string Name { get; set; }
        public int ClientId { get; set; }

        public Patient(int clientId, string name)
        {
            Name = name;
            ClientId = clientId;
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}