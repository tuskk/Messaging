using System;

namespace Messaging
{
    public class Publisher
    {
        private readonly MessageQueue queue;

        public Publisher(MessageQueue queue)
        {
            this.queue = queue;
        }

        public void SendMessage(string content)
        {
            var message = new Message(content);
            queue.AddMessage(message);
            Console.WriteLine($"Sent: {content}");
        }
    }
}
