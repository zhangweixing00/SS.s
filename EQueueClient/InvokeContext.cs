﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Web.Services.Protocols;

namespace EQueueClient
{
    // <summary>  
    /// 动态调用WCF的工具类库  
    /// </summary>  
    public class InvokeContext
    {

        #region Wcf服务工厂  
        public static T CreateWCFServiceByURL<T>(string url)
        {
            return CreateWCFServiceByURL<T>(url, "wsHttpBinding");
        }


        public static T CreateWCFServiceByURL<T>(string url, string bing)
        {
            if (string.IsNullOrEmpty(url)) throw new NotSupportedException("this url isn`t Null or Empty!");
            EndpointAddress address = new EndpointAddress(url);
            Binding binding = CreateBinding(bing);
            ChannelFactory<T> factory = new ChannelFactory<T>(binding, address);
            return factory.CreateChannel();
        }
        #endregion

        #region 创建传输协议  
        /// <summary>  
        /// 创建传输协议  
        /// </summary>  
        /// <param name="binding">传输协议名称</param>  
        /// <returns></returns>  
        private static Binding CreateBinding(string binding)
        {
            Binding bindinginstance = null;
            if (binding.ToLower() == "basichttpbinding")
            {
                BasicHttpBinding ws = new BasicHttpBinding();
                ws.MaxBufferSize = 2147483647;
                ws.MaxBufferPoolSize = 2147483647;
                ws.MaxReceivedMessageSize = 2147483647;
                ws.ReaderQuotas.MaxStringContentLength = 2147483647;
                ws.CloseTimeout = new TimeSpan(0, 10, 0);
                ws.OpenTimeout = new TimeSpan(0, 10, 0);
                ws.ReceiveTimeout = new TimeSpan(0, 10, 0);
                ws.SendTimeout = new TimeSpan(0, 10, 0);

                bindinginstance = ws;
            }
            else if (binding.ToLower() == "netnamedpipebinding")
            {
                NetNamedPipeBinding ws = new NetNamedPipeBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "netpeertcpbinding")
            {
                NetPeerTcpBinding ws = new NetPeerTcpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "nettcpbinding")
            {
                NetTcpBinding ws = new NetTcpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                ws.Security.Mode = SecurityMode.None;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "wsdualhttpbinding")
            {
                WSDualHttpBinding ws = new WSDualHttpBinding();
                ws.MaxReceivedMessageSize = 65535000;

                bindinginstance = ws;
            }
            else if (binding.ToLower() == "webhttpbinding")
            {
                //WebHttpBinding ws = new WebHttpBinding();  
                //ws.MaxReceivedMessageSize = 65535000;  
                //bindinginstance = ws;  
            }
            else if (binding.ToLower() == "wsfederationhttpbinding")
            {
                WSFederationHttpBinding ws = new WSFederationHttpBinding();
                ws.MaxReceivedMessageSize = 65535000;
                bindinginstance = ws;
            }
            else if (binding.ToLower() == "wshttpbinding")
            {
                WSHttpBinding ws = new WSHttpBinding(SecurityMode.None);
                ws.MaxReceivedMessageSize = 65535000;
                ws.Security.Message.ClientCredentialType = System.ServiceModel.MessageCredentialType.Windows;
                ws.Security.Transport.ClientCredentialType = System.ServiceModel.HttpClientCredentialType.Windows;
                bindinginstance = ws;
            }
            return bindinginstance;

        }
        #endregion

        public static object ExecuteMethod<T>(string pUrl, string pMethodName, params object[] pParams)
        {
            EndpointAddress address = new EndpointAddress(pUrl);
            Binding bindinginstance = null;
            NetTcpBinding ws = new NetTcpBinding();
            ws.MaxReceivedMessageSize = 20971520;
            ws.Security.Mode = SecurityMode.None;
            bindinginstance = ws;
            using (ChannelFactory<T> channel = new ChannelFactory<T>(bindinginstance, address))
            {
                T instance = channel.CreateChannel();
                using (instance as IDisposable)
                {
                    try
                    {
                        Type type = typeof(T);
                        MethodInfo mi = type.GetMethod(pMethodName);
                        return mi.Invoke(instance, pParams);
                    }
                    catch (TimeoutException)
                    {
                        (instance as ICommunicationObject).Abort();
                        throw;
                    }
                    catch (CommunicationException)
                    {
                        (instance as ICommunicationObject).Abort();
                        throw;
                    }
                    catch (Exception vErr)
                    {
                        (instance as ICommunicationObject).Abort();
                        throw;
                    }
                }
            }
        }

        public static object[] ExecuteMethodDirectly(string pUrl, string pMethodName, params object[] pParams)
        {
            return new WebServiceHelper(pUrl).ExecuteMethodDirectly(pMethodName, pParams);
        }

    }
}
