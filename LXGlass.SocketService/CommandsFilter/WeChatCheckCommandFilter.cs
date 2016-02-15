using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;
using SuperSocket.SocketBase.Metadata;

namespace LXGlass.SocketService
{
    /// <summary>
    /// 微信命令监视器-执行命令前调用
    /// </summary>
    public class WeChatCheckCommandFilter : CommandFilterAttribute
    {
        /// <summary>
        /// 执行命令前调用
        /// </summary>
        /// <param name="commandContext"></param>
        public override void OnCommandExecuted(CommandExecutingContext commandContext)
        {
            WeChatSession session = commandContext.Session as WeChatSession;

            if (session != null && !session.isLogin)
            {
                //判断当前命令是否为LOGIN
                if (!commandContext.RequestInfo.Key.Equals("CHECK"))
                {
                    session.Send("not authorization");
                    //取消执行当前命令
                    commandContext.Cancel = true;
                }
            }
        }

        /// <summary>
        /// 命令结束后调用
        /// </summary>
        /// <param name="commandContext"></param>
        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
            //throw new NotImplementedException();
        }
    }
}
