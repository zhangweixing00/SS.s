using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace LXGlass.SocketService
{
    /// <summary>
    /// 微信服务
    /// </summary>
    //[WeChatCheckCommandFilter]
    public  class WeChatServer:AppServer<WeChatSession>
    {
        //异步向客户端发送未确认的消息线程对象
        System.Threading.Thread th = null;


        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            LogHelper.WriteLog("WeChat服务启动");
            th = new System.Threading.Thread(new ThreadSendMsg().DoWork);
            th.IsBackground = true;
            th.Start();
            base.OnStarted();

        }

        protected override void OnStopped()
        {
            LogHelper.WriteLog("WeChat服务停止");
            //关闭线程
            if (th != null)
            {
                if (th.ThreadState != System.Threading.ThreadState.Stopped)
                    th.Abort();
            }
            base.OnStopped();
        }

        /// <summary>
        /// 新的连接
        /// </summary>
        /// <param name="session"></param>
        protected override void OnNewSessionConnected(WeChatSession session)
        {
            //LogHelper.WriteLog("WeChat服务新加入的连接:" + session.LocalEndPoint.Address.ToString());
            base.OnNewSessionConnected(session);
        }

    }
}
