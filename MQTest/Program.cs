using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQLib;

namespace MQTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            MQLib.MQHelper.CreateNewQueue("MsgQueue");
            Console.Read();
            while (true)
            {

                MsgModel model = new MsgModel()
                {
                    id = i.ToString(),
                    Name = DateTime.Now.ToString()
                };
                MQLib.MQHelper.sendComplexMsg<MsgModel>(model);
                Console.WriteLine("Send:"+model.ToString());
                i++;
                Thread.Sleep(2000);
            }
        }


    }
}
