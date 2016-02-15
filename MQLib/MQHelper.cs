using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace MQLib
{
    public class MQHelper
    {
        public static void sendComplexMsg<T>(T msg)
        {
            //实例化MessageQueue,并指向现有的一个名称为VideoQueue队列  
            MessageQueue MQ = new MessageQueue(@".\private$\MsgQueue");
            //MQ.Send("消息测试", "测试消息");  
            System.Messaging.Message message = new System.Messaging.Message();
            message.Label = "复杂消息lable";
            message.Body = msg;// new MsgModel("1", "消息1");
            MQ.Send(message);

            //Console.WriteLine("成功发送消息，" + DateTime.Now);
        }

        public static T receiveComplexMsg<T>()
        {
            MessageQueue MQ = new MessageQueue(@".\private$\MsgQueue");
            //调用MessageQueue的Receive方法接收消息  
            if (MQ.GetAllMessages().Length > 0)
            {
                System.Messaging.Message message = MQ.Receive(TimeSpan.FromSeconds(5));
                if (message != null)
                {
                    message.Formatter = new System.Messaging.XmlMessageFormatter(new Type[] { typeof(T) });//消息类型转换  
                    T msg = (T)message.Body;
                    return msg;
                }
            }

            return default(T);
        }

        /// <summary>  
        /// 创建消息队列  
        /// </summary>  
        /// <param name="name">消息队列名称</param>  
        /// <returns></returns>  
        public static void CreateNewQueue(string name)
        {
            if (!System.Messaging.MessageQueue.Exists(".\\private$\\" + name))//检查是否已经存在同名的消息队列  
            {

                System.Messaging.MessageQueue mq = System.Messaging.MessageQueue.Create(".\\private$\\" + name);
                 Console.WriteLine("创建成功");
            }
            else
            {
                //System.Messaging.MessageQueue.Delete(".\\private$\\" + name);//删除一个消息队列  
                Console.WriteLine("已存在");
            }
        }
    }
}
