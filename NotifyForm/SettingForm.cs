using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NotifyForm.Core;

namespace NotifyForm
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }
        public SettingInfo CurrentSettingInfo { get; set; }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CurrentSettingInfo.IP = tbIP.Text;
            CurrentSettingInfo.Port = int.Parse(tbPort.Text);
            CurrentSettingInfo.IsRealCloseApp = cbExit.Checked;
            CurrentSettingInfo.Save();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            CurrentSettingInfo = SettingInfo.Load();
            tbIP.Text = CurrentSettingInfo.IP;
            tbPort.Text = CurrentSettingInfo.Port.ToString();
            cbExit.Checked = CurrentSettingInfo.IsRealCloseApp;
        }
    }
}
