using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase.Protocol;

namespace NotifyLib
{
    [Serializable]
    public class MessageInfo: IRequestInfo
    {
        public SessionInfo UserInfo { get; set; }
        /// <summary>
        /// 消息ID，guid
        /// </summary>
        public string Key { get; set; }

        public string UserName { get; set; }

        public string Id { get; set; }

        public MsgType MessageType { get; set; }

        public dynamic Body { get; set; }

        public DateTime CreateTime { get; }

        public MessageInfo()
        {
            CreateTime = DateTime.Now;
        }
    }

    public enum MsgType : int
    {
        Simple,
        Info,
        XT,
        ACK,
        Login,
        CMD
    }
}
