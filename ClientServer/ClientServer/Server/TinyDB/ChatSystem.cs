using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.TinyDB
{
    class ChatSystem
    {
        private readonly List<Message> _messages;

        public ChatSystem()
        {
            _messages = new List<Message>();
        }

        public List<Message> GetMessagesBetweenTimes(SimpleTime startTime, SimpleTime endTime)
        {
            var temp = _messages.Where(m => m.Time > startTime && m.Time < endTime).ToList();
            temp.Sort();
            return temp;
        }

        public void AddMessage(Message m)
        {
            if (m != null)
            {
                this._messages.Add(m);
            }
        }

        public List<Message> GetAllMessages()
        {
            return _messages;
        }

        public bool Contains(Message m)
        {
            return _messages.Contains(m);
        }

        public List<Message> GetMessagesAfterTime(SimpleTime time)
        {
            var temp = _messages.Where(m => m.Time > time).ToList();
            temp.Sort();
            return temp;
        }

        public List<Message> GetMessagesBeforeTime(SimpleTime time)
        {
            var temp = _messages.Where(m => m.Time < time).ToList();

            temp.Sort();
            return temp;
        }
    }
}
