using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContractServiceLib.Interface;

namespace NotifyWebService
{
    /// <summary>
    /// 服务的实现
    /// Tips：
    /// 实现发布订阅,要注意：每个信道在调用后不要回收，否则会在回调时报错
    /// </summary>
    //[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class PushService : IPushService
    {
        public void Regist()
        {
            IPushCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            //添加到管理列表中
            ChannelManager.Instance.Add(callbackChannel);

        }

        public void UnRegist()
        {
            IPushCallback callbackChannel = OperationContext.Current.GetCallbackChannel<IPushCallback>();
            //从管理列表中移除
            ChannelManager.Instance.Remove(callbackChannel);
        }
    }
}