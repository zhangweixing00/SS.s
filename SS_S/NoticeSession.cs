using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NotifyLib;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
namespace SS_S
{
    public class NoticeSession:AppSession<NoticeSession, MessageInfo>
    {
        /// <summary>
        /// 域名:唯一标识
        /// </summary>
        public string UserName { get; set; }

        protected override void OnSessionStarted()
        {
            base.OnSessionStarted();
           // Send()
        }
        public override void Close(CloseReason reason)
        {
            base.Close(reason);
            Console.WriteLine(reason.ToString());
        }
        protected override void HandleUnknownRequest(MessageInfo requestInfo)
        {
            Console.WriteLine("收到命令:" + requestInfo.Key.ToString());
            //this.Send("不知道如何处理 " + requestInfo.Key.ToString() + " 命令\r\n");
        }


        /// <summary>
        /// 异常捕捉
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            Console.WriteLine("异常:" + e.Message);
            //base.HandleException(e);
        }
    }
}
