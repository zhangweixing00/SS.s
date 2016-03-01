using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ECommon.IoC;
using ECommon.Scheduling;
using EQueue.Clients.Consumers;
using EQueue.Protocols;
using EQueueClient.AgentService;

namespace EQueueClient
{
    class Program
    {
        static void Main(string[] args)
        {

            //var service = new ContractServiceLib.Common.WebServiceHelper("http://172.25.20.43:3553/Service.asmx");
            // service.Notify("zhangweixing", "hello" );
            // service.Notify1("zhangweixing","hello" );
            //TestNotifyService();
            //AgentService.AgentServiceSoapClient c = new AgentService.AgentServiceSoapClient();
            //c.Invoke("http://172.25.20.43:3553/Service.asmx", "Notify", "Service", new ArrayOfAnyType() {"zhangweixing","hello" });
            new Service().Invoke("http://172.25.20.43:3553/Service.asmx", "Notify", "Service", new string[] { "zhangweixing", "star" });
            //var messageHandler = new MessageHandler();
            //var consumer1 = new Consumer("Consumer1", "group1").Subscribe("SampleTopic").Start(messageHandler);

            //var scheduleService = ObjectContainer.Resolve<IScheduleService>();
        }

        private static void TestNotifyService()
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
