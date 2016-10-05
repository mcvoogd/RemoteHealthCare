﻿using System;

namespace Doctor.Classes
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
            if (Time == other.Time)
                return 0;
            if (Time > other.Time)
                return 1;
            if (Time < other.Time)
                return -1;
            return 0;
        }
    }
}