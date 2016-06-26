namespace SirdRoom.ManageSystem.ClientApplication
{
    partial class FrmLogin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.cbxServer = new System.Windows.Forms.ComboBox();
            this.cbxUsername = new System.Windows.Forms.ComboBox();
            this.cbxPwd = new System.Windows.Forms.ComboBox();
            this.chkServer = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picOk = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除当前服务器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除当前用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picOk)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxServer
            // 
            this.cbxServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(31)))));
            this.cbxServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxServer.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxServer.ForeColor = System.Drawing.Color.White;
            this.cbxServer.FormattingEnabled = true;
            this.cbxServer.Location = new System.Drawing.Point(214, 155);
            this.cbxServer.Name = "cbxServer";
            this.cbxServer.Size = new System.Drawing.Size(194, 25);
            this.cbxServer.TabIndex = 2;
            // 
            // cbxUsername
            // 
            this.cbxUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(31)))));
            this.cbxUsername.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxUsername.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxUsername.ForeColor = System.Drawing.Color.White;
            this.cbxUsername.FormattingEnabled = true;
            this.cbxUsername.Location = new System.Drawing.Point(214, 185);
            this.cbxUsername.Name = "cbxUsername";
            this.cbxUsername.Size = new System.Drawing.Size(194, 25);
            this.cbxUsername.TabIndex = 3;
            this.cbxUsername.SelectedIndexChanged += new System.EventHandler(this.cbxUsername_SelectedIndexChanged);
            // 
            // cbxPwd
            // 
            this.cbxPwd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(31)))));
            this.cbxPwd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxPwd.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxPwd.ForeColor = System.Drawing.Color.White;
            this.cbxPwd.FormattingEnabled = true;
            this.cbxPwd.Location = new System.Drawing.Point(214, 214);
            this.cbxPwd.Name = "cbxPwd";
            this.cbxPwd.Size = new System.Drawing.Size(194, 25);
            this.cbxPwd.TabIndex = 4;
            // 
            // chkServer
            // 
            this.chkServer.AutoSize = true;
            this.chkServer.BackColor = System.Drawing.Color.Transparent;
            this.chkServer.ForeColor = System.Drawing.Color.White;
            this.chkServer.Location = new System.Drawing.Point(234, 245);
            this.chkServer.Name = "chkServer";
            this.chkServer.Size = new System.Drawing.Size(60, 16);
            this.chkServer.TabIndex = 5;
            this.chkServer.Text = "Server";
            this.chkServer.UseVisualStyleBackColor = false;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.BackColor = System.Drawing.Color.Transparent;
            this.checkBox2.ForeColor = System.Drawing.Color.White;
            this.checkBox2.Location = new System.Drawing.Point(302, 245);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 6;
            this.checkBox2.Text = "User";
            this.checkBox2.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(265, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Copyright (C)2015";
            // 
            // picOk
            // 
            this.picOk.Location = new System.Drawing.Point(432, 188);
            this.picOk.Name = "picOk";
            this.picOk.Size = new System.Drawing.Size(42, 17);
            this.picOk.TabIndex = 8;
            this.picOk.TabStop = false;
            this.picOk.Click += new System.EventHandler(this.picOk_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(121)))), ((int)(((byte)(31)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("宋体", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(216, 217);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '*';
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 4;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem,
            this.清除当前服务器ToolStripMenuItem,
            this.清除当前用户ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 92);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click_1);
            // 
            // 清除当前服务器ToolStripMenuItem
            // 
            this.清除当前服务器ToolStripMenuItem.Name = "清除当前服务器ToolStripMenuItem";
            this.清除当前服务器ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.清除当前服务器ToolStripMenuItem.Text = "清除当前服务器";
            this.清除当前服务器ToolStripMenuItem.Click += new System.EventHandler(this.清除当前服务器ToolStripMenuItem_Click);
            // 
            // 清除当前用户ToolStripMenuItem
            // 
            this.清除当前用户ToolStripMenuItem.Name = "清除当前用户ToolStripMenuItem";
            this.清除当前用户ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.清除当前用户ToolStripMenuItem.Text = "清除当前用户";
            this.清除当前用户ToolStripMenuItem.Click += new System.EventHandler(this.清除当前用户ToolStripMenuItem_Click);
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(654, 293);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.picOk);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.chkServer);
            this.Controls.Add(this.cbxPwd);
            this.Controls.Add(this.cbxUsername);
            this.Controls.Add(this.cbxServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "登陆";
            this.Load += new System.EventHandler(this.FrmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picOk)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxServer;
        private System.Windows.Forms.ComboBox cbxUsername;
        private System.Windows.Forms.ComboBox cbxPwd;
        private System.Windows.Forms.CheckBox chkServer;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picOk;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除当前服务器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除当前用户ToolStripMenuItem;
    }
}

