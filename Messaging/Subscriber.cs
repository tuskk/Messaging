using System;

namespace Messaging
{
    public class Subscriber
    {
        private readonly MessageQueue queue;

        public Subscriber(MessageQueue queue)
        {
            this.queue = queue;
        }

        public void ReceiveMessage()
        {
            var message = queue.GetMessage();
            Console.WriteLine($"Received: {message.Content}");
        }
    }
}
