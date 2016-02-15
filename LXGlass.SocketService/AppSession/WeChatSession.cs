using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.Common;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

namespace LXGlass.SocketService
{
    /// <summary>
    /// 微信Session
    /// </summary>
    public class WeChatSession:AppSession<WeChatSession>
    {

        /// <summary>
        /// 是否登录
        /// </summary>
        public bool isLogin { get; set; }

        /// <summary>
        /// 机器编码
        /// </summary>
        public string SN { get; set; }
            

        protected override void OnSessionStarted()
        {
            //this.Send("Welcome to SuperSocket WeChat Server\r\n");
        }

        protected override void OnInit()
        {
            //this.Charset = Encoding.GetEncoding("gb2312");
            base.OnInit();
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            LogHelper.WriteLog("收到命令:" + requestInfo.Key.ToString());
            this.Send("不知道如何处理 " + requestInfo.Key.ToString() +" 命令\r\n");
        }


        /// <summary>
        /// 异常捕捉
        /// </summary>
        /// <param name="e"></param>
        protected override void HandleException(Exception e)
        {
            this.Send("\n\r异常信息：{0}", e.Message);
            //base.HandleException(e);
        }

        /// <summary>
        /// 连接关闭
        /// </summary>
        /// <param name="reason"></param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
              
        }
    }
}
