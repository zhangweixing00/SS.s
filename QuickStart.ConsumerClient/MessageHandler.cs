using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EQueue.Clients.Consumers;
using EQueue.Protocols;

namespace QuickStart.ConsumerClient
{
    class MessageHandler : IMessageHandler
    {
        private int _handledCount;

        public void Handle(QueueMessage message, IMessageContext context)
        {
            var count = Interlocked.Increment(ref _handledCount);
            if (count % 1000 == 0)
            {
                Console.WriteLine("Total handled {0} messages.", count);
            }
            context.OnMessageHandled(message);
        }
    }
}
