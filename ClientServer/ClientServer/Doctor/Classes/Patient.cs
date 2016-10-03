using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doctor.Classes
{
    class Patient
    {
        public string naam { get; set; }
        public int clientId { get; set; }

        public Patient(string naam, int clientId)
        {
            this.naam = naam;
            this.clientId = clientId;
        }
    }
}
