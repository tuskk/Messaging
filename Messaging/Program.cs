using System;
using System.Threading;

namespace Messaging
{
    class Program
    {
        static void Main()
        {
            MessageQueue queue = new MessageQueue();
            Publisher publisher = new Publisher(queue);
            Subscriber subscriber = new Subscriber(queue);

            Thread pubThread = new Thread(() => publisher.SendMessage("Hello, World!"));
            Thread subThread = new Thread(subscriber.ReceiveMessage);

            pubThread.Start();
            subThread.Start();

            pubThread.Join();
            subThread.Join();
        }
    }
}
