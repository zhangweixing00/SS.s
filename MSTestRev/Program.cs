using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MQLib;

namespace MSTestRev
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            Console.Read();
            while (true)
            {
                MsgModel model = MQLib.MQHelper.receiveComplexMsg<MsgModel>();
                Console.WriteLine("Rev:" + model.ToString());
                Thread.Sleep(2000);
            }
        }
    }
}
