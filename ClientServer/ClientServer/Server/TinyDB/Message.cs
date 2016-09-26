using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.TinyDB
{
    class Message : IComparable<Message>
    {
        private string _message;
        private SimpleTime _time;
        private string _sender;
        private string _destination;

        public Message(string destination, string senderValue, SimpleTime time, string messageValue)
        {
            this._destination = destination;
            _sender = senderValue;
            this._time = time;
            this._message = messageValue;
        }

        public string GetSender()
        {
            return _sender;;
        }

        public string GetDestination()
        {
            return _destination;
        }

        public int CompareTo(Message other)
        {
            throw new NotImplementedException();
        }

        public string GetMessage()
        {
            return _message;
        }

        public SimpleTime GetTime()
        {
            return _time;
        }
    }
}
