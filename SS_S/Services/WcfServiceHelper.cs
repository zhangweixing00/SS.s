using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace SS_S.Services
{
    public class WcfServiceHelper
    {
        ServiceHost serviceHost;
        public WcfServiceHelper()
        {
            serviceHost= new ServiceHost(typeof(NotifyService));
        }

        public void Start()
        {
            if (serviceHost.State != CommunicationState.Opened)
            {
                serviceHost.Open();
            }
        }
        public void Close()
        {
            serviceHost.Close();
        }

}
}
