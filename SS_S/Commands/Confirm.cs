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

    public class Confirm : CommandBase<NoticeSession, MessageInfo>
    {
        public override void ExecuteCommand(NoticeSession session, MessageInfo requestInfo)
        {
            //MessageInfo info = requestInfo.ToMessageInfo();
        }
        //public override void ExecuteCommand(NoticeSession session, BinaryRequestInfo requestInfo)
        //{
        //}
    }
}
