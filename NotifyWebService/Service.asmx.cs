using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace NotifyWebService
{
    /// <summary>
    /// Service 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class Service : System.Web.Services.WebService
    {
        ChannelManager channel;
        public Service()
        {
            channel = new ChannelManager();
            List<string> servicesUrl = new List<string>();
            System.Configuration.ConfigurationManager.AppSettings
                .AllKeys.Where(x => x.StartsWith("Service_")).ToList()
                .ForEach(x => servicesUrl.Add(System.Configuration.ConfigurationManager.AppSettings[x]));
            
            foreach (var item in servicesUrl)
            {
                channel.Add(ContractServiceLib.Common.WCFHelper.CreateWCFServiceByURL<ContractServiceLib.Interface.IContractService>(item));
            }
        }
        [WebMethod]
        public void Notify(string user, string msg)
        {
            if (!string.IsNullOrEmpty(user))
            {

            }
            channel.NotifyMessage(user, msg);
        }
    }
}
