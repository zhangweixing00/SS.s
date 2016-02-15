using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace LXGlass.SocketService
{
    /// <summary>
    /// 客户端上传图片命令
    /// </summary>
    public class IMG : CommandBase<WeChatSession, StringRequestInfo>
    {

        public override void ExecuteCommand(WeChatSession session, StringRequestInfo requestInfo)
        {
            //LogHelper.WriteLog("收到命令："+requestInfo.Key+",sn:"+requestInfo.Parameters[0]+",url:"+requestInfo.Parameters[1]);
            if (requestInfo.Parameters.Count() != 3)
            {
                session.Send("-1");
                return;
            }
            string sn = requestInfo[0].ToString();
            if (string.IsNullOrWhiteSpace(sn))
            {
                session.Send("-2");
                return;
            }
            string open_id = requestInfo.Parameters[2];
            try
            {
               
                var guid = Guid.NewGuid();
                GlobalWeChatMsgList.AddMsg(guid, requestInfo[1].ToString(), open_id, sn, session);
                //LogHelper.WriteLog(string.Format("--guid:{0}--pic:{1}--open_id:{2}--sn:{3}--", guid, requestInfo.Parameters[1].ToString(), open_id, sn));

               // client.First().Send(requestInfo[1].ToString() + " " + guid.ToString() + " " + open_id + "$\r\n");
                session.Send("0");
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog("IMG出错："+ex.Message);
                session.Send("-3");
            }
        }
    }
}
