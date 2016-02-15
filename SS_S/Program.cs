using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;
using NotifyLib;
using System.ServiceModel;
using SS_S.Services;
using SS_S.Messages;
using SuperSocket.Common;
using System.ServiceProcess;

namespace SS_S
{
    class Program
    {
        /// <summary>
        /// 初始化命令逻辑判断
        /// </summary>
        /// <param name="exeArg"></param>
        /// <returns></returns>
        private static bool Run(string exeArg)
        {
            switch (exeArg.ToLower())
            {
                case ("i"):
                    SelfInstaller.InstallMe();
                    Console.ReadKey();
                    return true;

                case ("u"):
                    SelfInstaller.UninstallMe();
                    Console.ReadKey();
                    return true;

                case ("c"):
                    RunAsConsole();
                    return true;

                default:
                    Console.WriteLine("无效的参数!");
                    return false;
            }
        }

        static void Main(string[] args)
        {

            if (!Environment.UserInteractive) // windows service 
            {
                RunAsService();
                return;
            }

            Console.WriteLine("Welcome to Star's SuperNotifyService!");
            Console.WriteLine("For WinService input I/U , For Console input C !");
            CheckCanSetConsoleColor();
            string line = Console.ReadLine();
            Run(line);
        }

        static void RunAsService()
        {
            ServiceBase[] servicesToRun;

            servicesToRun = new ServiceBase[] { new NotifyWinService() };

            ServiceBase.Run(servicesToRun);
        }

        private static void RunAsConsole()
        {
            Console.WriteLine("初始化...");

            IBootstrap bootstrap = BootstrapFactory.CreateBootstrap();
            if (!bootstrap.Initialize())
            {
                SetConsoleColor(ConsoleColor.Red);
                Console.WriteLine("初始化失败");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("启动中...");

            var result = bootstrap.Start();
            Console.WriteLine("-------------------------------------------------------------------");
            foreach (var server in bootstrap.AppServers)
            {
                if (server.State == ServerState.Running)
                {
                    SetConsoleColor(ConsoleColor.Green);
                    Console.WriteLine("- {0} 运行中", server.Name);
                }
                else
                {
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("- {0} 启动失败", server.Name);
                }
            }

            Console.ResetColor();
            Console.WriteLine("-------------------------------------------------------------------");

            switch (result)
            {
                case StartResult.Failed:
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("无法启动服务，更多错误信息请查看日志");
                    Console.ReadKey();
                    return;
                case StartResult.None:
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("没有服务器配置，请检查你的配置！");
                    Console.ReadKey();
                    return;
                case StartResult.PartialSuccess:
                    SetConsoleColor(ConsoleColor.Red);
                    Console.WriteLine("一些服务启动成功，但是还有一些启动失败，更多错误信息请查看日志");
                    break;
                case StartResult.Success:
                    Console.WriteLine("服务已经开始！");
                    break;
            }

            Console.ResetColor();
            Console.WriteLine("输入'quit'以停止服务");

            var serviceHelper = new WcfServiceHelper();
            serviceHelper.Start();

            NotifyServer nserver = bootstrap.AppServers.ToList()[0] as NotifyServer;
            GlobalControl.GlobalControl.MainSSServer = nserver;
            while (true)
            {
                if (MessageEqueue.ServerMainQueue.Count == 0)
                {
                    continue;
                }
                var msgInfo = MessageEqueue.ServerMainQueue.Dequeue();
                if (msgInfo.Body == "quit")
                {
                    break;
                }

                var sessionList = nserver.GetAllSessions().Where(x => msgInfo.UserName == "-1" || x.UserName.Equals(msgInfo.UserName, StringComparison.OrdinalIgnoreCase)).ToList();
                foreach (var session in sessionList)
                {
                    byte[] data = msgInfo.ToBytes();
                    session.Send(data, 0, data.Length);
                }
            }

            serviceHelper.Close();
        }

        private static bool setConsoleColor;

        /// <summary>
        /// 改变控制台显示的颜色
        /// </summary>
        static void CheckCanSetConsoleColor()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;//前景色
                Console.ResetColor();
                setConsoleColor = true;
            }
            catch
            {
                setConsoleColor = false;
            }
        }

        /// <summary>
        /// 改变控制台前景色
        /// </summary>
        /// <param name="color"></param>
        private static void SetConsoleColor(ConsoleColor color)
        {
            if (setConsoleColor)
                Console.ForegroundColor = color;
        }
    }
}
