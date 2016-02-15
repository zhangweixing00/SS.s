using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SS_S.Services
{
    [ServiceContract]
    public interface INotifyService
    {
        [OperationContract]
        void SendMessage(byte[] data);

        [OperationContract]
        void SendSimpleMessage(string user,string info);

        [OperationContract]
        void BroadCast(string info);

        [OperationContract]
        string[] SysCommand(string sysName,string cmdLine);


    }
}
