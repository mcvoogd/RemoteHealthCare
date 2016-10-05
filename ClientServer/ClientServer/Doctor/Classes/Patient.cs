using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Classes
{
    /// <summary>
    ///  don't know the original intention for this class, but I will use it to indicate what patient the doctor is connected to -Stefan
    /// </summary>
    public class Patient
    {
        public string naam { get; set; }
        public int clientId { get; set; }

        public Patient(int clientId, string naam = "Patient")
        {
            this.naam = naam;
            this.clientId = clientId;
        }
    }
}
