using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NotifyForm
{
    public static class CrossThread
    {
        /// <summary>
        /// 跨线程访问控件 在控件上执行委托
        /// </summary>
        /// <param name="ctl">控件</param>
        /// <param name="del">执行的委托</param>
        public static void CrossThreadCalls(this Control ctl, ThreadStart del)
        {
            if (!ctl.IsHandleCreated || ctl.IsDisposed || ctl.Disposing)
                return;
            if (del == null)
                return;
            if (ctl.InvokeRequired)
                ctl.Invoke(del, null);
            else
                del();
        }
    }
}
