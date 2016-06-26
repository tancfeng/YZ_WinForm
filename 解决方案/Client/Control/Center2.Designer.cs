namespace ControlLibrary.Control
{
    partial class Center2
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FilmStrip = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.清除选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.复制到指定目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跳转到资源目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.panel1.Controls.Add(this.FilmStrip);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(770, 25);
            this.panel1.TabIndex = 0;
            // 
            // FilmStrip
            // 
            this.FilmStrip.AutoSize = true;
            this.FilmStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.FilmStrip.ForeColor = System.Drawing.Color.White;
            this.FilmStrip.Location = new System.Drawing.Point(92, 3);
            this.FilmStrip.Name = "FilmStrip";
            this.FilmStrip.Padding = new System.Windows.Forms.Padding(3);
            this.FilmStrip.Size = new System.Drawing.Size(71, 18);
            this.FilmStrip.TabIndex = 2;
            this.FilmStrip.Text = "Film Strip";
            this.FilmStrip.Click += new System.EventHandler(this.FilmStrip_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(748, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(13, 13);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(143)))), ((int)(((byte)(178)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Basket";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Location = new System.Drawing.Point(0, 25);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(769, 128);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DragLeave += new System.EventHandler(this.listView1_DragLeave);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择全部ToolStripMenuItem,
            this.toolStripSeparator1,
            this.清除选择ToolStripMenuItem,
            this.清除所有ToolStripMenuItem,
            this.toolStripSeparator2,
            this.复制到指定目录ToolStripMenuItem,
            this.跳转到资源目录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(201, 126);
            // 
            // 选择全部ToolStripMenuItem
            // 
            this.选择全部ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.选择全部ToolStripMenuItem.Name = "选择全部ToolStripMenuItem";
            this.选择全部ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.选择全部ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.选择全部ToolStripMenuItem.Text = "选择全部";
            this.选择全部ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(197, 6);
            // 
            // 清除选择ToolStripMenuItem
            // 
            this.清除选择ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.清除选择ToolStripMenuItem.Name = "清除选择ToolStripMenuItem";
            this.清除选择ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.清除选择ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.清除选择ToolStripMenuItem.Text = "清除选择";
            this.清除选择ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 清除所有ToolStripMenuItem
            // 
            this.清除所有ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.清除所有ToolStripMenuItem.Name = "清除所有ToolStripMenuItem";
            this.清除所有ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.清除所有ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.清除所有ToolStripMenuItem.Text = "清除所有";
            this.清除所有ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(197, 6);
            // 
            // 复制到指定目录ToolStripMenuItem
            // 
            this.复制到指定目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.复制到指定目录ToolStripMenuItem.Name = "复制到指定目录ToolStripMenuItem";
            this.复制到指定目录ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.复制到指定目录ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.复制到指定目录ToolStripMenuItem.Text = "复制到指定目录";
            this.复制到指定目录ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 跳转到资源目录ToolStripMenuItem
            // 
            this.跳转到资源目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.跳转到资源目录ToolStripMenuItem.Name = "跳转到资源目录ToolStripMenuItem";
            this.跳转到资源目录ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.跳转到资源目录ToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.跳转到资源目录ToolStripMenuItem.Text = "跳转到资源目录";
            this.跳转到资源目录ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Center2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Center2";
            this.Size = new System.Drawing.Size(768, 152);
            this.Enter += new System.EventHandler(this.Center2_Enter);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 清除选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 复制到指定目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 跳转到资源目录ToolStripMenuItem;
        private System.Windows.Forms.Label FilmStrip;
    }
}
