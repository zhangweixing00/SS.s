using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ContractServiceLib.Interface;
using log4net;

namespace NotifyLogService
{
    /// <summary>
    /// Log
    /// </summary>
    public class LogService :ContractServiceLib.Interface.IContractService
    {
        protected ILog Loggor;
        public LogService()
        {
            Loggor = LogManager.GetLogger("loggor");
        }
        void IContractService.BroadCast(string info)
        {
            Loggor.DebugFormat("BroadCast:{0}", info);
        }

        void IContractService.SendSimpleMessage(string user, string info)
        {
            Loggor.DebugFormat("SendSimpleMessageTo {0}:{1}",user, info);
        }

        string[] IContractService.SysCommand(string sysName, string cmdLine)
        {
            Loggor.DebugFormat("SysCommand {0}:{1}", sysName, cmdLine);
            return new string[]{ };
        }
    }
}
