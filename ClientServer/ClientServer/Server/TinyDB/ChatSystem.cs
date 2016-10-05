using System;
using System.Collections.Generic;
using System.Linq;

namespace Server.TinyDB
{
    public class ChatSystem
    {
        public readonly List<Message> Messages;

        public ChatSystem()
        {
            Messages = new List<Message>();
        }

        public List<Message> GetMessagesBetweenTimes(DateTime startTime, DateTime endTime)
        {
            var temp = Messages.Where(m => (m.Time > startTime) && (m.Time < endTime)).ToList();
            temp.Sort();
            return temp;
        }

        public void AddMessage(Message m)
        {
            if (m != null)
                Messages.Add(m);
        }

        public List<Message> GetAllMessages()
        {
            return Messages;
        }

        public bool Contains(Message m)
        {
            return Messages.Contains(m);
        }

        public List<Message> GetMessagesAfterTime(DateTime time)
        {
            var temp = Messages.Where(m => m.Time > time).ToList();
            temp.Sort();
            return temp;
        }

        public List<Message> GetMessagesBeforeTime(DateTime time)
        {
            var temp = Messages.Where(m => m.Time < time).ToList();
            temp.Sort();
            return temp;
        }
    }
}