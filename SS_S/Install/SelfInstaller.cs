using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Configuration.Install;


namespace SS_S
{
    /// <summary>
    /// 安装为Windows Service
    /// </summary>
    public static class SelfInstaller
    {
        private static readonly string _exePath = Assembly.GetExecutingAssembly().Location;


        /// <summary>
        /// 安装服务
        /// </summary>
        /// <returns></returns>
        public static bool InstallMe()
        {
            try
            {
                //托管安装
                ManagedInstallerClass.InstallHelper(new string[] { _exePath });
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 卸载服务
        /// </summary>
        /// <returns></returns>
        public static bool UninstallMe()
        {
            try
            {
                ManagedInstallerClass.InstallHelper(new string[] { "/u", _exePath });
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
