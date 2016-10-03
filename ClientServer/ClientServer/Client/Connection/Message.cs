using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Connection
{
    public class Message : IComparable<Message>
    {
        public string MessageValue { get; set; }
        public DateTime Time { get; set; }
        public string Sender { get; set; }
        public string Destination { get; set; }

        public Message(string destination, string senderValue, DateTime time, string messageValue)
        {
            this.Destination = destination;
            Sender = senderValue;
            this.Time = time;
            this.MessageValue = messageValue;
        }

        public int CompareTo(Message other)
        {
           return this.Time.CompareTo(other.Time);
        }

    }
 }

