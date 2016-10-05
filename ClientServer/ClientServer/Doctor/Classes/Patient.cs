namespace Doctor.Classes
{
    /// <summary>
    ///     don't know the original intention for this class, but I will use it to indicate what patient the doctor is
    ///     connected to -Stefan
    /// </summary>
    public class Patient
    {
        public Patient(int clientId, string name = "Patient")
        {
            this.Name = name;
            this.ClientId = clientId;
        }

        public string Name { get; set; }
        public int ClientId { get; set; }


        public override string ToString()
        {
            return $"{Name}";
        }
    }
}