using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ECommon.IoC;
using ECommon.Scheduling;
using EQueue.Clients.Consumers;
using EQueue.Protocols;

namespace EQueueClient
{
    class Program
    {
        static void Main(string[] args)
        {


            NotifyService.NotifyServiceClient client = new NotifyService.NotifyServiceClient();

            while (true)
            {
                string txt = Console.ReadLine();

                if (!"quit1".Equals(txt, StringComparison.OrdinalIgnoreCase))
                {
                    client.SendSimpleMessage("zhangweixing", txt);
                }
            }
            //var messageHandler = new MessageHandler();
            //var consumer1 = new Consumer("Consumer1", "group1").Subscribe("SampleTopic").Start(messageHandler);

            //var scheduleService = ObjectContainer.Resolve<IScheduleService>();
        }



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
}
