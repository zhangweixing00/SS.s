using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services.Protocols;

namespace ContractServiceLib.Common
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.3038")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "AgentServiceSoap", Namespace = "http://tempuri.org/")]
    public partial class Service : SoapHttpClientProtocol
    {

        public Service(string url = "")
        {
            this.Url = string.IsNullOrEmpty(url) ? "http://172.25.20.43:5001/AgentService.asmx" : url;
        }

        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Invoke", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public object[] Invoke(string url, string methodName, string className, object[] args)
        {
            return this.Invoke("Invoke", new object[] { url, methodName, className, args });
        }
    }
}
