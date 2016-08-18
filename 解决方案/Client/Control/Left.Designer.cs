namespace ControlLibrary.Control
{
    partial class Left
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
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Left));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.Study = new System.Windows.Forms.Label();
            this.Resources = new System.Windows.Forms.Label();
            this.Favorites = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.picTitleTool2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picTitleTool1 = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.展开下列所有目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭下列所有目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复合文件设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.子目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复合文件取消ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.默认显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跨越显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.关键字管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleTool2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleTool1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.contextMenuStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 452);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.treeView1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(294, 380);
            this.panel4.TabIndex = 6;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.FullRowSelect = true;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode3.ImageKey = "4.jpg";
            treeNode3.Name = "节点1";
            treeNode3.Text = "节点1";
            treeNode4.ImageIndex = 2;
            treeNode4.Name = "节点0";
            treeNode4.Text = "节点0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.SelectedImageIndex = 3;
            this.treeView1.Size = new System.Drawing.Size(294, 380);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            this.treeView1.Click += new System.EventHandler(this.treeView1_Click);
            this.treeView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView1_DragDrop);
            this.treeView1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView1_DragOver);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "1.jpg");
            this.imageList1.Images.SetKeyName(1, "2.jpg");
            this.imageList1.Images.SetKeyName(2, "3.jpg");
            this.imageList1.Images.SetKeyName(3, "4.jpg");
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Study);
            this.panel3.Controls.Add(this.Resources);
            this.panel3.Controls.Add(this.Favorites);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 412);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(294, 38);
            this.panel3.TabIndex = 1;
            // 
            // Study
            // 
            this.Study.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Study.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(143)))), ((int)(((byte)(178)))));
            this.Study.ForeColor = System.Drawing.Color.White;
            this.Study.Location = new System.Drawing.Point(109, 6);
            this.Study.Margin = new System.Windows.Forms.Padding(0);
            this.Study.Name = "Study";
            this.Study.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.Study.Size = new System.Drawing.Size(52, 22);
            this.Study.TabIndex = 3;
            this.Study.Text = "图库";
            this.Study.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Study.Click += new System.EventHandler(this.lblButtom1_Click);
            // 
            // Resources
            // 
            this.Resources.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Resources.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Resources.ForeColor = System.Drawing.Color.White;
            this.Resources.Location = new System.Drawing.Point(9, 6);
            this.Resources.Margin = new System.Windows.Forms.Padding(0);
            this.Resources.Name = "Resources";
            this.Resources.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.Resources.Size = new System.Drawing.Size(84, 22);
            this.Resources.TabIndex = 2;
            this.Resources.Text = "上传";
            this.Resources.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Resources.Click += new System.EventHandler(this.lblButtom1_Click);
            // 
            // Favorites
            // 
            this.Favorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Favorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Favorites.ForeColor = System.Drawing.Color.White;
            this.Favorites.Location = new System.Drawing.Point(180, 6);
            this.Favorites.Margin = new System.Windows.Forms.Padding(0);
            this.Favorites.Name = "Favorites";
            this.Favorites.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.Favorites.Size = new System.Drawing.Size(84, 22);
            this.Favorites.TabIndex = 4;
            this.Favorites.Text = "我的项目";
            this.Favorites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Favorites.Click += new System.EventHandler(this.lblButtom1_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.TitleBg;
            this.panel2.Controls.Add(this.picTitleTool2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.picTitleTool1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(294, 32);
            this.panel2.TabIndex = 0;
            // 
            // picTitleTool2
            // 
            this.picTitleTool2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picTitleTool2.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.TitleTool2;
            this.picTitleTool2.Location = new System.Drawing.Point(267, 4);
            this.picTitleTool2.Margin = new System.Windows.Forms.Padding(4);
            this.picTitleTool2.Name = "picTitleTool2";
            this.picTitleTool2.Size = new System.Drawing.Size(13, 25);
            this.picTitleTool2.TabIndex = 2;
            this.picTitleTool2.TabStop = false;
            this.picTitleTool2.Click += new System.EventHandler(this.picTitleTool2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Study";
            // 
            // picTitleTool1
            // 
            this.picTitleTool1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picTitleTool1.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.TitleTool;
            this.picTitleTool1.Location = new System.Drawing.Point(242, 4);
            this.picTitleTool1.Margin = new System.Windows.Forms.Padding(4);
            this.picTitleTool1.Name = "picTitleTool1";
            this.picTitleTool1.Size = new System.Drawing.Size(27, 25);
            this.picTitleTool1.TabIndex = 1;
            this.picTitleTool1.TabStop = false;
            this.picTitleTool1.Click += new System.EventHandler(this.picTitleTool1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.展开下列所有目录ToolStripMenuItem,
            this.关闭下列所有目录ToolStripMenuItem,
            this.关闭所有ToolStripMenuItem,
            this.复合文件设置ToolStripMenuItem,
            this.复合文件取消ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 134);
            // 
            // 展开下列所有目录ToolStripMenuItem
            // 
            this.展开下列所有目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.展开下列所有目录ToolStripMenuItem.Name = "展开下列所有目录ToolStripMenuItem";
            this.展开下列所有目录ToolStripMenuItem.ShortcutKeyDisplayString = "F";
            this.展开下列所有目录ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.展开下列所有目录ToolStripMenuItem.Text = "展开下列所有目录";
            this.展开下列所有目录ToolStripMenuItem.Click += new System.EventHandler(this.展开下列所有目录ToolStripMenuItem_Click);
            // 
            // 关闭下列所有目录ToolStripMenuItem
            // 
            this.关闭下列所有目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关闭下列所有目录ToolStripMenuItem.Name = "关闭下列所有目录ToolStripMenuItem";
            this.关闭下列所有目录ToolStripMenuItem.ShortcutKeyDisplayString = "G";
            this.关闭下列所有目录ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.关闭下列所有目录ToolStripMenuItem.Text = "关闭下列所有目录";
            this.关闭下列所有目录ToolStripMenuItem.Click += new System.EventHandler(this.关闭下列所有目录ToolStripMenuItem_Click);
            // 
            // 关闭所有ToolStripMenuItem
            // 
            this.关闭所有ToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.关闭所有ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关闭所有ToolStripMenuItem.Name = "关闭所有ToolStripMenuItem";
            this.关闭所有ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.关闭所有ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.关闭所有ToolStripMenuItem.Text = "关闭所有";
            this.关闭所有ToolStripMenuItem.Click += new System.EventHandler(this.关闭所有ToolStripMenuItem_Click);
            // 
            // 复合文件设置ToolStripMenuItem
            // 
            this.复合文件设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.当前目录ToolStripMenuItem,
            this.子目录ToolStripMenuItem});
            this.复合文件设置ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.复合文件设置ToolStripMenuItem.Name = "复合文件设置ToolStripMenuItem";
            this.复合文件设置ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.复合文件设置ToolStripMenuItem.Text = "复合文件设置";
            // 
            // 当前目录ToolStripMenuItem
            // 
            this.当前目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.当前目录ToolStripMenuItem.Name = "当前目录ToolStripMenuItem";
            this.当前目录ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.当前目录ToolStripMenuItem.Text = "当前目录";
            this.当前目录ToolStripMenuItem.Click += new System.EventHandler(this.当前目录ToolStripMenuItem_Click);
            // 
            // 子目录ToolStripMenuItem
            // 
            this.子目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.子目录ToolStripMenuItem.Name = "子目录ToolStripMenuItem";
            this.子目录ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.子目录ToolStripMenuItem.Text = "子目录";
            this.子目录ToolStripMenuItem.Click += new System.EventHandler(this.子目录ToolStripMenuItem_Click);
            // 
            // 复合文件取消ToolStripMenuItem
            // 
            this.复合文件取消ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.复合文件取消ToolStripMenuItem.Name = "复合文件取消ToolStripMenuItem";
            this.复合文件取消ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.复合文件取消ToolStripMenuItem.Text = "复合文件取消";
            this.复合文件取消ToolStripMenuItem.Click += new System.EventHandler(this.复合文件取消ToolStripMenuItem_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.默认显示ToolStripMenuItem,
            this.跨越显示ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(145, 56);
            // 
            // 默认显示ToolStripMenuItem
            // 
            this.默认显示ToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.默认显示ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.默认显示ToolStripMenuItem.Name = "默认显示ToolStripMenuItem";
            this.默认显示ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.默认显示ToolStripMenuItem.Text = "默认显示";
            this.默认显示ToolStripMenuItem.Click += new System.EventHandler(this.默认显示ToolStripMenuItem_Click);
            // 
            // 跨越显示ToolStripMenuItem
            // 
            this.跨越显示ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.跨越显示ToolStripMenuItem.Name = "跨越显示ToolStripMenuItem";
            this.跨越显示ToolStripMenuItem.Size = new System.Drawing.Size(144, 26);
            this.跨越显示ToolStripMenuItem.Text = "跨越显示";
            this.跨越显示ToolStripMenuItem.Click += new System.EventHandler(this.跨越显示ToolStripMenuItem_Click);
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关键字管理ToolStripMenuItem});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(182, 58);
            // 
            // 关键字管理ToolStripMenuItem
            // 
            this.关键字管理ToolStripMenuItem.Name = "关键字管理ToolStripMenuItem";
            this.关键字管理ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.关键字管理ToolStripMenuItem.Text = "关键字管理";
            this.关键字管理ToolStripMenuItem.Click += new System.EventHandler(this.关键字管理ToolStripMenuItem_Click);
            // 
            // Left
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Left";
            this.Size = new System.Drawing.Size(296, 452);
            this.Load += new System.EventHandler(this.Left_Load);
            this.Enter += new System.EventHandler(this.Left_Enter);
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleTool2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleTool1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.contextMenuStrip3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picTitleTool1;
        private System.Windows.Forms.PictureBox picTitleTool2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Resources;
        private System.Windows.Forms.Label Favorites;
        private System.Windows.Forms.Label Study;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 默认显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 跨越显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 展开下列所有目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭下列所有目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复合文件设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 子目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复合文件取消ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem 关键字管理ToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
    }
}
