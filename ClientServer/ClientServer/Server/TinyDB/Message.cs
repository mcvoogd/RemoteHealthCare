using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.TinyDB
{
    class Message : IComparable<Message>
    {
        public string MessageValue { get; set; }
        public SimpleTime Time { get; set; }
        public string Sender { get; set; }
        public string Destination { get; set; }

        public Message(string destination, string senderValue, SimpleTime time, string messageValue)
        {
            this.Destination = destination;
            Sender = senderValue;
            this.Time = time;
            this.MessageValue = messageValue;
        }

        public int CompareTo(Message other)
        {
                if (this.Time == other.Time)
                {
                    return 0;
                }
                if (this.Time > other.Time)
                {
                    return 1;
                }
                if (this.Time < other.Time)
                {
                    return -1;
                }
                return 0;
            }
        }
 }

