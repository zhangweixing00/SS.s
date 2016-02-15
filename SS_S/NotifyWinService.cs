using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using SS_S.Messages;
using SS_S.Services;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using NotifyLib;
using System.IO;

namespace SS_S
{
    partial class NotifyWinService : ServiceBase
    {
        /// <summary>
        /// 通过BootStrap启动Socket服务
        /// </summary>
        private IBootstrap m_Bootstrap;

        private WcfServiceHelper serviceHelper;


        public System.Timers.Timer m_Dispacher;
        public bool isOk = true;
        log4net.ILog logger;

        public NotifyServer nserver
        {
            get
            {
               return m_Bootstrap.AppServers.ToList()[0] as NotifyServer;
            }
        }
        private void InitConfig()
        {
            string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config");
            log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo(path));
            logger = log4net.LogManager.GetLogger("logger");
        }
        public NotifyWinService()
        {
            File.AppendAllText(@"D:\345.txt", "aa");
            InitializeComponent();
            InitConfig();
            logger.Debug("OO");
            m_Bootstrap = BootstrapFactory.CreateBootstrap();
            serviceHelper = new WcfServiceHelper();
            m_Dispacher = new System.Timers.Timer();
            m_Dispacher.Interval = 500;
            m_Dispacher.Elapsed += M_Dispacher_Elapsed;

        }

        private void M_Dispacher_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (MessageEqueue.ServerMainQueue.Count == 0)
            {
                return;
            }
            var msgInfo = MessageEqueue.ServerMainQueue.Dequeue();
            if (msgInfo.Body == "quit")
            {
                OnStop();
            }

            var sessionList = nserver.GetAllSessions().Where(x => msgInfo.UserName == "" || x.UserName.Equals(msgInfo.UserName, StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var session in sessionList)
            {
                byte[] data = msgInfo.ToBytes();
                session.Send(data, 0, data.Length);
            }
        }

        protected override void OnStart(string[] args)
        {
            if (!m_Bootstrap.Initialize())
            {
                logger.Debug("InitializeFail!");
                return;
            }
            var result = m_Bootstrap.Start();
            switch (result)
            {
                case StartResult.Failed:

                    logger.Debug("无法启动服务，更多错误信息请查看日志");
                   // Console.ReadKey();
                    return;
                case StartResult.None:

                    logger.Debug("没有服务器配置，请检查你的配置！");
                    //Console.ReadKey();
                    return;
                case StartResult.PartialSuccess:

                    logger.Debug("一些服务启动成功，但是还有一些启动失败，更多错误信息请查看日志");
                    break;
                case StartResult.Success:
                    logger.Debug("服务已经开始！");
                    break;
            }
            serviceHelper.Start();

            m_Dispacher.Start();
        }

        protected override void OnStop()
        {
            m_Bootstrap.Stop();
            m_Dispacher.Stop();
            serviceHelper.Close();
            base.OnStop();
        }
        protected override void OnShutdown()
        {
            m_Bootstrap.Stop();
            m_Dispacher.Close();
            //serviceHelper.Close();
            base.OnShutdown();
        }
    }
}
