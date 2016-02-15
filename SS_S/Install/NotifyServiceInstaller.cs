﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace SS_S.Install
{
    [RunInstaller(true)]
    public partial class NotifyServiceInstaller : System.Configuration.Install.Installer
    {
        private ServiceInstaller serviceInstaller;
        private ServiceProcessInstaller processInstaller;

        public NotifyServiceInstaller()
        {
            InitializeComponent();
            processInstaller = new ServiceProcessInstaller();
            serviceInstaller = new ServiceInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Automatic;
            serviceInstaller.ServiceName = ConfigurationManager.AppSettings["ServiceName"].ToString();
            serviceInstaller.Description = ConfigurationManager.AppSettings["ServiceDescription"].ToString();

            //依赖的服务
            //var servicesDependedOn = new List<string> { "tcpip" };
            //var servicesDependedOnConfig = ConfigurationManager.AppSettings["ServicesDependedOn"];

            //if (!string.IsNullOrEmpty(servicesDependedOnConfig))
            //    servicesDependedOn.AddRange(servicesDependedOnConfig.Split(new char[] { ',', ';' }));

            //serviceInstaller.ServicesDependedOn = servicesDependedOn.ToArray();

            Installers.Add(serviceInstaller);
            Installers.Add(processInstaller);

        }
    }
}
