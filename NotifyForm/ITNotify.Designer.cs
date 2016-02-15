namespace NotifyForm
{
    partial class ITNotify
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ITNotify));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.lbMsg = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出程序ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tLb = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbtnConnect = new System.Windows.Forms.ToolStripSplitButton();
            this.contextMenuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "IT";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // lbMsg
            // 
            this.lbMsg.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMsg.Location = new System.Drawing.Point(25, 20);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(277, 74);
            this.lbMsg.TabIndex = 1;
            this.lbMsg.Text = "...";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(274, 108);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 35);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "我知道了";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设置ToolStripMenuItem,
            this.退出程序ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 设置ToolStripMenuItem
            // 
            this.设置ToolStripMenuItem.Name = "设置ToolStripMenuItem";
            this.设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.设置ToolStripMenuItem.Text = "设置";
            this.设置ToolStripMenuItem.Click += new System.EventHandler(this.设置ToolStripMenuItem_Click);
            // 
            // 退出程序ToolStripMenuItem
            // 
            this.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem";
            this.退出程序ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出程序ToolStripMenuItem.Text = "退出程序";
            this.退出程序ToolStripMenuItem.Click += new System.EventHandler(this.退出程序ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tLb,
            this.tbtnConnect});
            this.statusStrip1.Location = new System.Drawing.Point(0, 155);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(361, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tLb
            // 
            this.tLb.Name = "tLb";
            this.tLb.Size = new System.Drawing.Size(17, 17);
            this.tLb.Text = "...";
            // 
            // tbtnConnect
            // 
            this.tbtnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnConnect.Image = ((System.Drawing.Image)(resources.GetObject("tbtnConnect.Image")));
            this.tbtnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnConnect.Name = "tbtnConnect";
            this.tbtnConnect.Size = new System.Drawing.Size(32, 20);
            this.tbtnConnect.Text = "连接";
            this.tbtnConnect.ButtonClick += new System.EventHandler(this.tbtnConnect_ButtonClick);
            // 
            // ITNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 177);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lbMsg);
            this.Name = "ITNotify";
            this.Text = "IT";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ITNotify_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ITNotify_FormClosed);
            this.Load += new System.EventHandler(this.ITNotify_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label lbMsg;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出程序ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tLb;
        private System.Windows.Forms.ToolStripSplitButton tbtnConnect;
    }
}

