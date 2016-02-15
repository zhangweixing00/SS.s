using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotifyLib;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;
using SuperSocket.SocketBase.Protocol;

namespace SS_S
{
    public class NotifyServer:AppServer<NoticeSession, MessageInfo>
    {
        public NotifyServer(): base(new DefaultReceiveFilterFactory<MessageReceiveFilter, MessageInfo>())
        {

        }
        //public NotifyServer(): base(new NotifyFactory())
        //{

        //}
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnNewSessionConnected(NoticeSession session)
        {
            Console.WriteLine("{0} 已连接！", session.SessionID);
            base.OnNewSessionConnected(session);
        }

        protected override void OnSessionClosed(NoticeSession session, CloseReason reason)
        {
            Console.WriteLine("{0} 已关闭！{1}", session.SessionID,reason.ToString());
            base.OnSessionClosed(session, reason);
        }

        public string[] GetSessionUsers()
        {
            List<string> userList = new List<string>();
            GetAllSessions().ToList().ForEach(x => userList.Add(x.UserName));
            return userList.ToArray();
        }
    }
}
