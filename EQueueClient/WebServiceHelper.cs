using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;

namespace EQueueClient
{
    public class WebServiceHelper : SoapHttpClientProtocol
    {
        public WebServiceHelper(string url)
        {
            this.Url = url;
        }
        public object[] ExecuteMethodDirectly(string pMethodName, params object[] pParams)
        {
            return Invoke(pMethodName, pParams);
        }
    }
}
