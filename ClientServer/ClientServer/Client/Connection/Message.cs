using System;

namespace Client.Connection
{
    public class Message : IComparable<Message>
    {
        public Message(string destination, string senderValue, DateTime time, string messageValue)
        {
            Destination = destination;
            Sender = senderValue;
            Time = time;
            MessageValue = messageValue;
        }

        public string MessageValue { get; set; }
        public DateTime Time { get; set; }
        public string Sender { get; set; }
        public string Destination { get; set; }

        public int CompareTo(Message other)
        {
            return Time.CompareTo(other.Time);
        }
    }
}