namespace ControlLibrary.Control
{
    partial class Center1
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制到指定目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跳转到资源目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.全选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.反选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.视图优先排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.使用次数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改使用次数toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.刷新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跳转到原始目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跳转到原始微缩图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new ControlLibrary.Control.ListViewDoubleBuffered();
            this.listViewLoadData = new System.ComponentModel.BackgroundWorker();
            this.设为同款可显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(128, 128);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制到指定目录ToolStripMenuItem,
            this.跳转到资源目录ToolStripMenuItem,
            this.toolStripSeparator1,
            this.全选ToolStripMenuItem,
            this.反选ToolStripMenuItem,
            this.取消选择ToolStripMenuItem,
            this.复制toolStripMenuItem,
            this.粘贴toolStripMenuItem,
            this.toolStripSeparator2,
            this.视图优先排列ToolStripMenuItem,
            this.使用次数ToolStripMenuItem,
            this.修改使用次数toolStripMenuItem1,
            this.toolStripSeparator3,
            this.刷新ToolStripMenuItem,
            this.跳转到原始目录ToolStripMenuItem,
            this.跳转到原始微缩图ToolStripMenuItem,
            this.设为同款可显示ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(247, 414);
            this.contextMenuStrip1.VisibleChanged += new System.EventHandler(this.contextMenuStrip1_VisibleChanged);
            // 
            // 复制到指定目录ToolStripMenuItem
            // 
            this.复制到指定目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.复制到指定目录ToolStripMenuItem.Name = "复制到指定目录ToolStripMenuItem";
            this.复制到指定目录ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.复制到指定目录ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.复制到指定目录ToolStripMenuItem.Tag = "0";
            this.复制到指定目录ToolStripMenuItem.Text = "复制到指定目录";
            this.复制到指定目录ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 跳转到资源目录ToolStripMenuItem
            // 
            this.跳转到资源目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.跳转到资源目录ToolStripMenuItem.Name = "跳转到资源目录ToolStripMenuItem";
            this.跳转到资源目录ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.跳转到资源目录ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.跳转到资源目录ToolStripMenuItem.Tag = "1";
            this.跳转到资源目录ToolStripMenuItem.Text = "跳转到资源目录";
            this.跳转到资源目录ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // 全选ToolStripMenuItem
            // 
            this.全选ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.全选ToolStripMenuItem.Name = "全选ToolStripMenuItem";
            this.全选ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.全选ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.全选ToolStripMenuItem.Tag = "2";
            this.全选ToolStripMenuItem.Text = "全选";
            this.全选ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 反选ToolStripMenuItem
            // 
            this.反选ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.反选ToolStripMenuItem.Name = "反选ToolStripMenuItem";
            this.反选ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.反选ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.反选ToolStripMenuItem.Tag = "3";
            this.反选ToolStripMenuItem.Text = "反选";
            this.反选ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 取消选择ToolStripMenuItem
            // 
            this.取消选择ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.取消选择ToolStripMenuItem.Name = "取消选择ToolStripMenuItem";
            this.取消选择ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.取消选择ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.取消选择ToolStripMenuItem.Tag = "4";
            this.取消选择ToolStripMenuItem.Text = "取消选择";
            this.取消选择ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 复制toolStripMenuItem
            // 
            this.复制toolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.复制toolStripMenuItem.Name = "复制toolStripMenuItem";
            this.复制toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.复制toolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.复制toolStripMenuItem.Text = "复制";
            this.复制toolStripMenuItem.Click += new System.EventHandler(this.复制toolStripMenuItem_Click);
            // 
            // 粘贴toolStripMenuItem
            // 
            this.粘贴toolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.粘贴toolStripMenuItem.Name = "粘贴toolStripMenuItem";
            this.粘贴toolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.粘贴toolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.粘贴toolStripMenuItem.Text = "粘贴";
            this.粘贴toolStripMenuItem.Click += new System.EventHandler(this.粘贴toolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // 视图优先排列ToolStripMenuItem
            // 
            this.视图优先排列ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.视图优先排列ToolStripMenuItem.Name = "视图优先排列ToolStripMenuItem";
            this.视图优先排列ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.视图优先排列ToolStripMenuItem.Tag = "5";
            this.视图优先排列ToolStripMenuItem.Text = "视图优先排列";
            this.视图优先排列ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 使用次数ToolStripMenuItem
            // 
            this.使用次数ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.使用次数ToolStripMenuItem.Name = "使用次数ToolStripMenuItem";
            this.使用次数ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.使用次数ToolStripMenuItem.Tag = "6";
            this.使用次数ToolStripMenuItem.Text = "使用次数";
            this.使用次数ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 修改使用次数toolStripMenuItem1
            // 
            this.修改使用次数toolStripMenuItem1.ForeColor = System.Drawing.Color.White;
            this.修改使用次数toolStripMenuItem1.Name = "修改使用次数toolStripMenuItem1";
            this.修改使用次数toolStripMenuItem1.Size = new System.Drawing.Size(246, 26);
            this.修改使用次数toolStripMenuItem1.Text = "修改使用次数";
            this.修改使用次数toolStripMenuItem1.Visible = false;
            this.修改使用次数toolStripMenuItem1.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
            // 
            // 刷新ToolStripMenuItem
            // 
            this.刷新ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.刷新ToolStripMenuItem.Name = "刷新ToolStripMenuItem";
            this.刷新ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.刷新ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.刷新ToolStripMenuItem.Tag = "7";
            this.刷新ToolStripMenuItem.Text = "刷新";
            this.刷新ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 跳转到原始目录ToolStripMenuItem
            // 
            this.跳转到原始目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.跳转到原始目录ToolStripMenuItem.Name = "跳转到原始目录ToolStripMenuItem";
            this.跳转到原始目录ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.跳转到原始目录ToolStripMenuItem.Text = "跳转到原始目录";
            this.跳转到原始目录ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // 跳转到原始微缩图ToolStripMenuItem
            // 
            this.跳转到原始微缩图ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.跳转到原始微缩图ToolStripMenuItem.Name = "跳转到原始微缩图ToolStripMenuItem";
            this.跳转到原始微缩图ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.跳转到原始微缩图ToolStripMenuItem.Text = "跳转到原始微缩图";
            this.跳转到原始微缩图ToolStripMenuItem.Click += new System.EventHandler(this.contextMenuStrip_Click);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Margin = new System.Windows.Forms.Padding(4);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(1133, 652);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DragLeave += new System.EventHandler(this.listView1_DragLeave);
            this.listView1.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.listView1_QueryContinueDrag);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // listViewLoadData
            // 
            this.listViewLoadData.WorkerReportsProgress = true;
            this.listViewLoadData.WorkerSupportsCancellation = true;
            this.listViewLoadData.DoWork += new System.ComponentModel.DoWorkEventHandler(this.listViewLoadData_DoWork);
            this.listViewLoadData.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.listViewLoadData_ProgressChanged);
            this.listViewLoadData.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.listViewLoadData_RunWorkerCompleted);
            // 
            // 设为同款可显示ToolStripMenuItem
            // 
            this.设为同款可显示ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.设为同款可显示ToolStripMenuItem.Name = "设为同款可显示ToolStripMenuItem";
            this.设为同款可显示ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.设为同款可显示ToolStripMenuItem.Text = "设为同款可显示";
            this.设为同款可显示ToolStripMenuItem.Click += new System.EventHandler(this.设为同款可显示ToolStripMenuItem_Click);
            // 
            // Center1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.listView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Center1";
            this.Size = new System.Drawing.Size(1133, 652);
            this.Enter += new System.EventHandler(this.Center1_Enter);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复制到指定目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 跳转到资源目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 全选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 反选ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 取消选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripMenuItem 视图优先排列ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem 使用次数ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 刷新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴toolStripMenuItem;
        public ListViewDoubleBuffered listView1;
        private System.Windows.Forms.ToolStripMenuItem 修改使用次数toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 跳转到原始目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 跳转到原始微缩图ToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker listViewLoadData;
        private System.Windows.Forms.ToolStripMenuItem 设为同款可显示ToolStripMenuItem;
    }
}
