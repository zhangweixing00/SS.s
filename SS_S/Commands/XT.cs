using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotifyLib;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace SS_S
{
    public class XT : CommandBase<NoticeSession, MessageInfo>
    {
        public override void ExecuteCommand(NoticeSession session, MessageInfo requestInfo)
        {
            
        }
    }
}
