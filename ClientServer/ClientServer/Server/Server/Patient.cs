namespace Server.Server
{
    internal class Patient
    {
        public string Name { get; set; }
        public int clientId { get; set; }

        public Patient(string name, int clientId)
        {
            Name = name;
            this.clientId = clientId;
        }
    }
}