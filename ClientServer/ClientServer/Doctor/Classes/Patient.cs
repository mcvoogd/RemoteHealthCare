namespace Doctor.Classes
{
    /// <summary>
    ///     don't know the original intention for this class, but I will use it to indicate what patient the doctor is
    ///     connected to -Stefan
    /// </summary>
    public class Patient
    {
        public Patient(int clientId, string naam = "Patient")
        {
            this.naam = naam;
            this.clientId = clientId;
        }

        public string naam { get; set; }
        public int clientId { get; set; }
    }
}