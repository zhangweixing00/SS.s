using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using NotifyForm.Core;

namespace NotifyForm
{
    public partial class ITNotify : Form
    {
        SSClient client;

        //public delegate void MyInvoke(string str);

        public SettingInfo CurrentSetting { get; set; }

        public ITNotify()
        {
            InitializeComponent();
        }

        private void ITNotify_Load(object sender, EventArgs e)
        {
            CurrentSetting = SettingInfo.Load();
            ConnectServer();

            FormSetting();
        }

        private void FormSetting()
        {
            notifyIcon1.Visible = true;
            this.ShowInTaskbar = false;
            this.MaximizeBox = false;
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示                          //AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);
        }

        #region 闪

        public struct FLASHWINFO
        {

            public UInt32 cbSize;
            public IntPtr hwnd;
            public UInt32 dwFlags;
            public UInt32 uCount;
            public UInt32 dwTimeout;
        }
        public const UInt32 FLASHW_STOP = 0;
        public const UInt32 FLASHW_CAPTION = 1;
        public const UInt32 FLASHW_TRAY = 2;
        public const UInt32 FLASHW_ALL = 3;
        public const UInt32 FLASHW_TIMER = 4;
        public const UInt32 FLASHW_TIMERNOFG = 12;
        [DllImport("user32.dll")]
        static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [DllImport("user32.dll")]
        static extern bool FlashWindow(IntPtr handle, bool invert);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        public void ReShow()
        {
            IntPtr handle = this.Handle;// new System.Windows.Interop.WindowInteropHelper(this).Handle;
            if (this.WindowState == FormWindowState.Minimized || handle != GetForegroundWindow())
            {
                this.WindowState = FormWindowState.Normal;

                FLASHWINFO fInfo = new FLASHWINFO();

                fInfo.cbSize = Convert.ToUInt32(Marshal.SizeOf(fInfo));
                fInfo.hwnd = handle;
                fInfo.dwFlags = FLASHW_TRAY | FLASHW_TIMERNOFG;
                fInfo.uCount = UInt32.MaxValue;
                fInfo.dwTimeout = 0;

                FlashWindowEx(ref fInfo);
            }
        }

        #endregion

        #region 消失
        /// <summary>  
        /// 窗体动画函数    注意：要引用System.Runtime.InteropServices;  
        /// </summary>  
        /// <param name="hwnd">指定产生动画的窗口的句柄</param>  
        /// <param name="dwTime">指定动画持续的时间</param>  
        /// <param name="dwFlags">指定动画类型，可以是一个或多个标志的组合。</param>  
        /// <returns></returns>
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        //下面是可用的常量，根据不同的动画效果声明自己需要的  
        private const int AW_HOR_POSITIVE = 0x0001;//自左向右显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_HOR_NEGATIVE = 0x0002;//自右向左显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_POSITIVE = 0x0004;//自顶向下显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志  
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口，该标志可以在滚动动画和滑动动画中使用。使用AW_CENTER标志时忽略该标志该标志  
        private const int AW_CENTER = 0x0010;//若使用了AW_HIDE标志，则使窗口向内重叠；否则向外扩展  
        private const int AW_HIDE = 0x10000;//隐藏窗口  
        private const int AW_ACTIVE = 0x20000;//激活窗口，在使用了AW_HIDE标志后不要使用这个标志  
        private const int AW_SLIDE = 0x40000;//使用滑动类型动画效果，默认为滚动动画类型，当使用AW_CENTER标志时，这个标志就被忽略  
        private const int AW_BLEND = 0x80000;//使用淡入淡出效果  

        #endregion


        private void ITNotify_FormClosing(object sender, FormClosingEventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);

            if (e.CloseReason == CloseReason.UserClosing && !CurrentSetting.IsRealCloseApp)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void ITNotify_FormClosed(object sender, FormClosedEventArgs e)
        {
            client.Close();
        }

        //private void ITNotify_Resize(object sender, EventArgs e)
        //{
        //    if (this.WindowState == FormWindowState.Minimized)
        //    {
        //        notifyIcon1.Visible = true;
        //    }
        //    else
        //    {
        //        notifyIcon1.Visible = false;
        //    }
        //}

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
        }



        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            if (sf.ShowDialog() == DialogResult.OK)
            {
                this.CurrentSetting = sf.CurrentSettingInfo;
                ConnectServer();
            }
        }

        private void ConnectServer()
        {
            if (client != null)
            {
                client.Close();
            }


            client = new SSClient()
            {
                Ip = CurrentSetting.IP,
                Port = CurrentSetting.Port
                 ,
                UserName = Environment.UserName
            };

            client.ProcessData = x =>
            {
                if (x.Body != null)
                {
                    this.CrossThreadCalls(ReShow);
                    lbMsg.CrossThreadCalls(() => { lbMsg.Text = x.Body; });
                }
            };

            bool isReady = client.Connect();
            if (isReady)
            {
                tLb.Text = "连接成功";
                tbtnConnect.Enabled = false;

            }
            else
            {
                tLb.Text = "连接失败";
            }
        }

        private void 退出程序ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CurrentSetting.IsRealCloseApp = true;
            this.Close();
        }

        private void tbtnConnect_ButtonClick(object sender, EventArgs e)
        {
            ConnectServer();
        }
    }
}
