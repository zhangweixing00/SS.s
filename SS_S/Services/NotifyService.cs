using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using NotifyLib;
using SS_S.Messages;

namespace SS_S.Services
{
    public class NotifyService :ContractServiceLib.Interface.IContractService
    {
        /// <summary>
        /// 广播
        /// </summary>
        /// <param name="info"></param>
        public void BroadCast(string info)
        {
            MessageEqueue.ServerMainQueue.Enqueue(new NotifyLib.MessageInfo()
            {
                Id = Guid.NewGuid().ToString(),
                Body = info,
                MessageType = NotifyLib.MsgType.Info,
                UserName = "-1"
            });
        }

        //public void SendMessage(byte[] data)
        //{
        //   var msgInfo= ConvertHelper.ToMessageInfo(data);
        //    if (msgInfo!=null)
        //    {
        //        MessageEqueue.ServerMainQueue.Enqueue(msgInfo);
        //    }
        //}

        public void SendSimpleMessage(string user, string info)
        {
            MessageEqueue.ServerMainQueue.Enqueue(new NotifyLib.MessageInfo()
            {
                Id = Guid.NewGuid().ToString(),
                Body = info,
                MessageType = NotifyLib.MsgType.Info,
                UserName = user
            });
        }

        public string[] SysCommand(string sysName, string cmdLine)
        {
            if (sysName!="star")
            {
                throw new AddressAccessDeniedException("NO　权限");
            }
            switch (cmdLine)
            {
                case "list":
                    return GlobalControl.GlobalControl.MainSSServer.GetSessionUsers();
                default:
                    break;
            }
            return new string[]{ };
        }
    }
}
