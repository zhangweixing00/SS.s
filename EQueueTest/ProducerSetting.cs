using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommon.Socketing;

namespace EQueueTest
{
    class ProducerSetting
    {
        public string BrokerAddress { get; set; }
        public int BrokerPort { get; set; }
        public int SendMessageTimeoutMilliseconds { get; set; }
        public int UpdateTopicQueueCountInterval { get; set; }

        public ProducerSetting()
        {
            BrokerAddress = SocketUtils.GetLocalIPV4().ToString();
            BrokerPort = 5000;
            SendMessageTimeoutMilliseconds = 1000 * 10;
            UpdateTopicQueueCountInterval = 1000 * 5;
        }
    }
}
