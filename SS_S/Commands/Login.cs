using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotifyLib;
using SuperSocket.SocketBase.Command;

namespace SS_S.Commands
{
    public class Login : CommandBase<NoticeSession, MessageInfo>
    {
        public override void ExecuteCommand(NoticeSession session, MessageInfo requestInfo)
        {
            session.UserName = requestInfo.Body;
        }
    }
}
