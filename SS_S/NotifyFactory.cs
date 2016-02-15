using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using NotifyLib;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace SS_S
{
    public class NotifyFactory : IReceiveFilterFactory<MessageInfo>
    {
        public IReceiveFilter<MessageInfo> CreateFilter(IAppServer appServer, IAppSession appSession, IPEndPoint remoteEndPoint)
        {
            return new MessageReceiveFilter();
        }
    }
}
