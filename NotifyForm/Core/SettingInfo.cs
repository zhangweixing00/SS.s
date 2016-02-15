using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NotifyLib;

namespace NotifyForm.Core
{
    [Serializable]
    public class SettingInfo
    {
        public string IP { get; set; }
        public int Port { get; set; }
        public bool IsRealCloseApp { get; set; }

        public void Save()
        {
            string path = GetSettingIniPath();
            File.WriteAllBytes(path,
                ConvertHelper.SerializeObject(this));
        }
        public static SettingInfo Load()
        {
            string path = GetSettingIniPath();
            if (File.Exists(path))
            {
                byte[] data = File.ReadAllBytes(path);
                if (data != null && data.Length > 0)
                {
                    return ConvertHelper.DeserializeObject(data) as SettingInfo;
                }
            }
            return new SettingInfo()
            {
                IsRealCloseApp = false,
                IP = "172.25.20.47",
                Port = 1111
            };
        }

        private static string GetSettingIniPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "s.si");
        }
    }
}
