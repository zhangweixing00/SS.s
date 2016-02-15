using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ContractServiceLib.Interface
{
    /// <summary>
    /// 自定义协议
    /// </summary>
    [ServiceContract]
    public interface ICustomContractService
    {
        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="data"></param>
        [OperationContract]
        void SendMessage(byte[] data);

        /// <summary>
        /// 广播
        /// </summary>
        /// <param name="data"></param>
        [OperationContract]
        void BroadCast(byte[] data);

        /// <summary>
        /// 系统调用
        /// </summary>
        /// <param name="sysName"></param>
        /// <param name="cmdLine"></param>
        /// <returns></returns>
        [OperationContract]
        string[] SysCommand(string sysName, string cmdLine);
    }
}
