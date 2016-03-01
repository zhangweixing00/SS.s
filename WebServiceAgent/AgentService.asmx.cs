using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.Services.Description;
using Microsoft.CSharp;

namespace WebServiceAgent
{
    /// <summary>
    /// AgentService 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class AgentService : System.Web.Services.WebService
    {

        private static string GetClassName(string url)
        {
            string[] parts = url.Split('/');
            string[] pps = parts[parts.Length - 1].Split('.');
            return pps[0];
        }

        [WebMethod]
        public object Invoke(string url, string methodName, string className = "", params object[] args)
        {
            if (className == null || className == "")
            {
                className = GetClassName(url);
            }

            string @namespace = "ServiceBase.WebService.DynamicWebLoad." + ProcessUrl(url);
            string cacheName = string.Format("{0}_{1}", @namespace, className);
            
            Assembly assembly = null;
            if (HttpContext.Current.Cache[cacheName] != null)
            {
                assembly = HttpContext.Current.Cache[cacheName] as Assembly;
            }
            else
            {

                //获取服务描述语言(WSDL)   
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(url + "?WSDL");
                ServiceDescription sd = ServiceDescription.Read(stream);
                ServiceDescriptionImporter sdi = new ServiceDescriptionImporter();
                sdi.AddServiceDescription(sd, "", "");
                CodeNamespace cn = new CodeNamespace(@namespace);
                //生成客户端代理类代码   
                CodeCompileUnit ccu = new CodeCompileUnit();
                ccu.Namespaces.Add(cn);
                sdi.Import(cn, ccu);
                CSharpCodeProvider csc = new CSharpCodeProvider();
                ICodeCompiler icc = csc.CreateCompiler();
                //设定编译器的参数   
                CompilerParameters cplist = new CompilerParameters();
                cplist.GenerateExecutable = false;
                cplist.GenerateInMemory = true;
                cplist.ReferencedAssemblies.Add("System.dll");
                cplist.ReferencedAssemblies.Add("System.XML.dll");
                cplist.ReferencedAssemblies.Add("System.Web.Services.dll");
                cplist.ReferencedAssemblies.Add("System.Data.dll");
                //编译代理类   
                CompilerResults cr = icc.CompileAssemblyFromDom(cplist, ccu);
                if (true == cr.Errors.HasErrors)
                {
                    System.Text.StringBuilder sb = new StringBuilder();
                    foreach (CompilerError ce in cr.Errors)
                    {
                        sb.Append(ce.ToString());
                        sb.Append(System.Environment.NewLine);
                    }
                    throw new Exception(sb.ToString());
                }
                //生成代理实例,并调用方法   
                assembly = cr.CompiledAssembly;
                HttpContext.Current.Cache[cacheName] = assembly;
            }
            Type t = assembly.GetType(@namespace + "." + className, true, true);
            object obj = Activator.CreateInstance(t);
            System.Reflection.MethodInfo mi = t.GetMethod(methodName);
            return mi.Invoke(obj, args);
        }


        private string ProcessUrl(string orginUrl)
        {
            if (string.IsNullOrWhiteSpace(orginUrl))
            {
                return "";
            }
            foreach (char rInvalidChar in Path.GetInvalidFileNameChars())
            {
                orginUrl = orginUrl.Replace(rInvalidChar.ToString(), string.Empty);
            }
           orginUrl= orginUrl.Replace(".", string.Empty);
            return orginUrl;
        }
    }
}
