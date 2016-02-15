using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using NotifyLib;
namespace SS_S
{

    public class ACK : CommandBase<NoticeSession, MessageInfo>
    {
        public override string Name
        {
            get
            {
                return "ACK";
            }
        }
        public override void ExecuteCommand(NoticeSession session, MessageInfo requestInfo)
        {
            //MessageInfo info = requestInfo.ToMessageInfo();
            Console.WriteLine("客户端已收到：{0}", requestInfo.Id);
        }
        //public override void ExecuteCommand(NoticeSession session, BinaryRequestInfo requestInfo)
        //{
        //}
    }
}
