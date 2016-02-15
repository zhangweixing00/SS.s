using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace LXGlass.SocketService.Commands
{
    public class XT : CommandBase<WeChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(WeChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Count() == 1)
            {
                if (requestInfo.Parameters[0] == "&")
                {
                    if (!session.isLogin|| string.IsNullOrWhiteSpace(session.SN))
                        session.Send("no check\r\n");
                    else
                        session.Send("$\r\n");
                }
            }
        }
    }
}
