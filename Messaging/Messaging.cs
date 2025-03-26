using System;
using System.Collections.Generic;
using System.Threading;

namespace Messaging
{
    public class MessageQueue
    {
        private Queue<Message> messages = new Queue<Message>();
        private readonly object lockObj = new object();

        public void AddMessage(Message message)
        {
            lock (lockObj)
            {
                messages.Enqueue(message);
                Monitor.Pulse(lockObj);
            }
        }

        public Message GetMessage()
        {
            lock (lockObj)
            {
                while (messages.Count == 0)
                {
                    Monitor.Wait(lockObj);
                }
                return messages.Dequeue();
            }
        }
    }
}
