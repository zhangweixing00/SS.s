using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace LXGlass.SocketService.Commands
{

    public class CHECK : CommandBase<WeChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(WeChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters.Count() != 1)
            {
                session.Send("The wrong format\r\n");
            }
            else
            {
                string sn = requestInfo.Parameters[0].ToString();
                if (string.IsNullOrWhiteSpace(sn))
                    session.Send("The wrong sn\r\n");
                else
                {
                    //已用此SN注册的连接会替换Sesion
                    var session_client = session.AppServer.GetAllSessions().Where(c => c.SN == sn);
                    if (session_client != null)
                    {
                        foreach (var item in session_client)
                        {
                            item.Send("new check,To close the connection for you\r\n");
                            item.Close();
                        }
                    }

                    session.isLogin = true;
                    session.SN = sn;
                    try
                    {
                        var MsgList = GlobalWeChatMsgList.GetList();
                        if (MsgList.Count > 0)
                        {
                            var query = from c in MsgList where c.sn == sn select c;
                            if (query != null)
                            {
                                if (query.Count() != 0)
                                {
                                    query.First().session = session;
                                }
                                //LogHelper.WriteLog("关闭连接:" + query.First().session);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog("Session:"+ex.Message);
                    }
                    session.Send("success\r\n");
                }
            }
        }
    }
}
