using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ContractServiceLib.Interface
{
    /// <summary>
    /// 简单协议通讯
    /// </summary>
    [ServiceContract]
    public interface IContractService
    {
        /// <summary>
        /// 指定用户发送消息
        /// </summary>
        /// <param name="user"></param>
        /// <param name="info"></param>
        [OperationContract]
        void SendSimpleMessage(string user, string info);

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="info"></param>
        [OperationContract]
        void BroadCast(string info);

        /// <summary>
        /// 系统命令
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="cmdLine"></param>
        /// <returns></returns>
        [OperationContract]
        string[] SysCommand(string sysName, string cmdLine);
    }
}
