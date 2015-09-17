namespace DouBanDownLoad
{
    partial class FrmMain
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnstart = new System.Windows.Forms.Button();
            this.txturl = new System.Windows.Forms.TextBox();
            this.fbpath = new System.Windows.Forms.FolderBrowserDialog();
            this.btnpath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lvstate = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnstart
            // 
            this.btnstart.Location = new System.Drawing.Point(375, 173);
            this.btnstart.Name = "btnstart";
            this.btnstart.Size = new System.Drawing.Size(113, 23);
            this.btnstart.TabIndex = 0;
            this.btnstart.Text = "启动";
            this.btnstart.UseVisualStyleBackColor = true;
            this.btnstart.Click += new System.EventHandler(this.btnstart_Click);
            // 
            // txturl
            // 
            this.txturl.Location = new System.Drawing.Point(12, 12);
            this.txturl.Name = "txturl";
            this.txturl.Size = new System.Drawing.Size(476, 21);
            this.txturl.TabIndex = 2;
            this.txturl.Text = "填入地址列表";
            this.txturl.TextChanged += new System.EventHandler(this.txturl_TextChanged);
            // 
            // btnpath
            // 
            this.btnpath.Location = new System.Drawing.Point(12, 173);
            this.btnpath.Name = "btnpath";
            this.btnpath.Size = new System.Drawing.Size(114, 23);
            this.btnpath.TabIndex = 3;
            this.btnpath.Text = "选择保存文件夹";
            this.btnpath.UseVisualStyleBackColor = true;
            this.btnpath.Click += new System.EventHandler(this.btnpath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 211);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "当前未选择路径";
            this.label1.TextChanged += new System.EventHandler(this.label1_TextChanged);
            // 
            // lvstate
            // 
            this.lvstate.FormattingEnabled = true;
            this.lvstate.ItemHeight = 12;
            this.lvstate.Location = new System.Drawing.Point(13, 50);
            this.lvstate.Name = "lvstate";
            this.lvstate.Size = new System.Drawing.Size(475, 112);
            this.lvstate.TabIndex = 5;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 241);
            this.Controls.Add(this.lvstate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnpath);
            this.Controls.Add(this.txturl);
            this.Controls.Add(this.btnstart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "豆瓣相册助手V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnstart;
        private System.Windows.Forms.TextBox txturl;
        private System.Windows.Forms.FolderBrowserDialog fbpath;
        private System.Windows.Forms.Button btnpath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lvstate;
    }
}

