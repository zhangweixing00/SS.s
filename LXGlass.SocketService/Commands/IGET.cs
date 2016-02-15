using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace LXGlass.SocketService.Commands
{
    /// <summary>
    /// 客户端来这里确认收到消息
    /// </summary>
    public  class IGET : CommandBase<WeChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(WeChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Count() != 1)
            {
                session.Send("error parameters\r\n");
                return;
            }

            string key = requestInfo.Parameters[0];
            if (string.IsNullOrWhiteSpace(key))
            {
                session.Send("guid is null\r\n");
                return;
            }

            if (key.Substring(key.Length - 1, 1) != "$")
            {
                session.Send("error guid\r\n");
                return;
            }

            try
            {
                Guid guid = new Guid(key.Substring(0, key.Length - 1));
                GlobalWeChatMsgList.RemoveMsg(guid);
                session.Send("success\r\n");
            }
            catch
            {
                session.Send("not validate guid\r\n");
            }

            

        }
    }
}
