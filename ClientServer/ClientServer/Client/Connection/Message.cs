using System;

namespace Client.Connection
{
    public class Message : IComparable<Message>
    {
        public Message(int destination, int senderValue, DateTime time, string name,string messageValue)
        {
            Name = name;
            Destination = destination;
            Sender = senderValue;
            Time = time;
            MessageValue = messageValue;
        }

        public string Name { get; set; }
        public string MessageValue { get; set; }
        public DateTime Time { get; set; }
        public int Sender { get; set; }
        public int Destination { get; set; }

        public int CompareTo(Message other)
        {
            return Time.CompareTo(other.Time);
        }
    }
}