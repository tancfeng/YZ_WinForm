namespace ControlLibrary.Control
{
    partial class Center1ShowFilterByKeywordSetting
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBox_Exsit = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tp_Favorites = new System.Windows.Forms.TabPage();
            this.tv_Favorites = new System.Windows.Forms.TreeView();
            this.tp_Study = new System.Windows.Forms.TabPage();
            this.tv_Study = new System.Windows.Forms.TreeView();
            this.btn_删除 = new System.Windows.Forms.Button();
            this.btn_添加 = new System.Windows.Forms.Button();
            this.tabControl.SuspendLayout();
            this.tp_Favorites.SuspendLayout();
            this.tp_Study.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox_Exsit
            // 
            this.listBox_Exsit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.listBox_Exsit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Exsit.ForeColor = System.Drawing.Color.White;
            this.listBox_Exsit.FormattingEnabled = true;
            this.listBox_Exsit.ItemHeight = 12;
            this.listBox_Exsit.Location = new System.Drawing.Point(12, 11);
            this.listBox_Exsit.Name = "listBox_Exsit";
            this.listBox_Exsit.Size = new System.Drawing.Size(179, 302);
            this.listBox_Exsit.TabIndex = 0;
            this.listBox_Exsit.SelectedIndexChanged += new System.EventHandler(this.listBox_Exsit_SelectedIndexChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tp_Favorites);
            this.tabControl.Controls.Add(this.tp_Study);
            this.tabControl.Location = new System.Drawing.Point(197, 11);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(256, 304);
            this.tabControl.TabIndex = 1;
            // 
            // tp_Favorites
            // 
            this.tp_Favorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.tp_Favorites.Controls.Add(this.tv_Favorites);
            this.tp_Favorites.ForeColor = System.Drawing.Color.White;
            this.tp_Favorites.Location = new System.Drawing.Point(4, 22);
            this.tp_Favorites.Name = "tp_Favorites";
            this.tp_Favorites.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Favorites.Size = new System.Drawing.Size(248, 278);
            this.tp_Favorites.TabIndex = 0;
            this.tp_Favorites.Text = "Favorites";
            // 
            // tv_Favorites
            // 
            this.tv_Favorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.tv_Favorites.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tv_Favorites.ForeColor = System.Drawing.Color.White;
            this.tv_Favorites.Location = new System.Drawing.Point(3, 3);
            this.tv_Favorites.Name = "tv_Favorites";
            this.tv_Favorites.Size = new System.Drawing.Size(245, 272);
            this.tv_Favorites.TabIndex = 0;
            // 
            // tp_Study
            // 
            this.tp_Study.Controls.Add(this.tv_Study);
            this.tp_Study.ForeColor = System.Drawing.Color.Transparent;
            this.tp_Study.Location = new System.Drawing.Point(4, 22);
            this.tp_Study.Name = "tp_Study";
            this.tp_Study.Padding = new System.Windows.Forms.Padding(3);
            this.tp_Study.Size = new System.Drawing.Size(248, 278);
            this.tp_Study.TabIndex = 1;
            this.tp_Study.Text = "Study";
            this.tp_Study.UseVisualStyleBackColor = true;
            // 
            // tv_Study
            // 
            this.tv_Study.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.tv_Study.ForeColor = System.Drawing.Color.White;
            this.tv_Study.Location = new System.Drawing.Point(0, 3);
            this.tv_Study.Name = "tv_Study";
            this.tv_Study.Size = new System.Drawing.Size(245, 272);
            this.tv_Study.TabIndex = 0;
            // 
            // btn_删除
            // 
            this.btn_删除.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_删除.ForeColor = System.Drawing.Color.White;
            this.btn_删除.Location = new System.Drawing.Point(116, 321);
            this.btn_删除.Name = "btn_删除";
            this.btn_删除.Size = new System.Drawing.Size(75, 23);
            this.btn_删除.TabIndex = 2;
            this.btn_删除.Text = "删除";
            this.btn_删除.UseVisualStyleBackColor = false;
            this.btn_删除.Click += new System.EventHandler(this.btn_删除_Click);
            // 
            // btn_添加
            // 
            this.btn_添加.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.btn_添加.ForeColor = System.Drawing.Color.White;
            this.btn_添加.Location = new System.Drawing.Point(374, 321);
            this.btn_添加.Name = "btn_添加";
            this.btn_添加.Size = new System.Drawing.Size(75, 23);
            this.btn_添加.TabIndex = 3;
            this.btn_添加.Text = "添加";
            this.btn_添加.UseVisualStyleBackColor = false;
            this.btn_添加.Click += new System.EventHandler(this.btn_添加_Click);
            // 
            // Center1ShowFilterByKeywordSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.btn_添加);
            this.Controls.Add(this.btn_删除);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.listBox_Exsit);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Center1ShowFilterByKeywordSetting";
            this.Size = new System.Drawing.Size(469, 357);
            this.Load += new System.EventHandler(this.Center1ShowFilterByKeywordSetting_Load);
            this.tabControl.ResumeLayout(false);
            this.tp_Favorites.ResumeLayout(false);
            this.tp_Study.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Exsit;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tp_Favorites;
        private System.Windows.Forms.TabPage tp_Study;
        private System.Windows.Forms.Button btn_删除;
        private System.Windows.Forms.Button btn_添加;
        private System.Windows.Forms.TreeView tv_Favorites;
        private System.Windows.Forms.TreeView tv_Study;
    }
}
