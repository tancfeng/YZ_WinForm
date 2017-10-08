namespace ControlLibrary.Control
{
    partial class Right
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.panel1 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.设为同款关键字ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.展开下列所有节目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭下列所有节目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.新建ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.向上排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.向下排列ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.用户面板不显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.面板不显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.智能关键字不显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Keyword = new System.Windows.Forms.Label();
            this.Study = new System.Windows.Forms.Label();
            this.Favorites = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picTitleTool1 = new System.Windows.Forms.PictureBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.keyword1 = new WindowsFormsApplication1.Keyword();
            this.panel1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleTool1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.keyword1);
            this.panel1.Controls.Add(this.treeView1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 661);
            this.panel1.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.CheckBoxes = true;
            this.treeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ForeColor = System.Drawing.Color.White;
            this.treeView1.HideSelection = false;
            this.treeView1.Location = new System.Drawing.Point(0, 32);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode1.ImageKey = "4.jpg";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.ImageIndex = 2;
            treeNode2.Name = "节点0";
            treeNode2.Text = "节点0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeView1.Size = new System.Drawing.Size(339, 589);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            this.treeView1.DrawNode += new System.Windows.Forms.DrawTreeNodeEventHandler(this.treeView1_DrawNode);
            this.treeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeSelect);
            this.treeView1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.设为同款关键字ToolStripMenuItem,
            this.展开下列所有节目ToolStripMenuItem,
            this.关闭下列所有节目ToolStripMenuItem,
            this.关闭所有ToolStripMenuItem,
            this.toolStripSeparator1,
            this.新建ToolStripMenuItem,
            this.修改ToolStripMenuItem,
            this.删除ToolStripMenuItem,
            this.toolStripSeparator2,
            this.向上排列ToolStripMenuItem,
            this.向下排列ToolStripMenuItem,
            this.toolStripSeparator3,
            this.用户面板不显示ToolStripMenuItem,
            this.面板不显示ToolStripMenuItem,
            this.智能关键字不显示ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(225, 362);
            this.contextMenuStrip1.VisibleChanged += new System.EventHandler(this.contextMenuStrip1_VisibleChanged);
            // 
            // 设为同款关键字ToolStripMenuItem
            // 
            this.设为同款关键字ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.设为同款关键字ToolStripMenuItem.Name = "设为同款关键字ToolStripMenuItem";
            this.设为同款关键字ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.设为同款关键字ToolStripMenuItem.Text = "设为同款关键字";
            this.设为同款关键字ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 展开下列所有节目ToolStripMenuItem
            // 
            this.展开下列所有节目ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.展开下列所有节目ToolStripMenuItem.Name = "展开下列所有节目ToolStripMenuItem";
            this.展开下列所有节目ToolStripMenuItem.ShortcutKeyDisplayString = "F";
            this.展开下列所有节目ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.展开下列所有节目ToolStripMenuItem.Text = "展开下列所有节目";
            this.展开下列所有节目ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 关闭下列所有节目ToolStripMenuItem
            // 
            this.关闭下列所有节目ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关闭下列所有节目ToolStripMenuItem.Name = "关闭下列所有节目ToolStripMenuItem";
            this.关闭下列所有节目ToolStripMenuItem.ShortcutKeyDisplayString = "G";
            this.关闭下列所有节目ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.关闭下列所有节目ToolStripMenuItem.Text = "关闭下列所有节目";
            this.关闭下列所有节目ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 关闭所有ToolStripMenuItem
            // 
            this.关闭所有ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.关闭所有ToolStripMenuItem.Name = "关闭所有ToolStripMenuItem";
            this.关闭所有ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.关闭所有ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.关闭所有ToolStripMenuItem.Text = "关闭所有";
            this.关闭所有ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // 新建ToolStripMenuItem
            // 
            this.新建ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.新建ToolStripMenuItem.Name = "新建ToolStripMenuItem";
            this.新建ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.新建ToolStripMenuItem.Text = "新建";
            this.新建ToolStripMenuItem.Click += new System.EventHandler(this.新建ToolStripMenuItem_Click);
            // 
            // 修改ToolStripMenuItem
            // 
            this.修改ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.修改ToolStripMenuItem.Name = "修改ToolStripMenuItem";
            this.修改ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.修改ToolStripMenuItem.Text = "修改";
            this.修改ToolStripMenuItem.Click += new System.EventHandler(this.修改ToolStripMenuItem_Click);
            // 
            // 删除ToolStripMenuItem
            // 
            this.删除ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.删除ToolStripMenuItem.Name = "删除ToolStripMenuItem";
            this.删除ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.删除ToolStripMenuItem.Text = "删除";
            this.删除ToolStripMenuItem.Click += new System.EventHandler(this.删除ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(221, 6);
            // 
            // 向上排列ToolStripMenuItem
            // 
            this.向上排列ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.向上排列ToolStripMenuItem.Name = "向上排列ToolStripMenuItem";
            this.向上排列ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.向上排列ToolStripMenuItem.Text = "向上排列";
            this.向上排列ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 向下排列ToolStripMenuItem
            // 
            this.向下排列ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.向下排列ToolStripMenuItem.Name = "向下排列ToolStripMenuItem";
            this.向下排列ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.向下排列ToolStripMenuItem.Text = "向下排列";
            this.向下排列ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(221, 6);
            // 
            // 用户面板不显示ToolStripMenuItem
            // 
            this.用户面板不显示ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.用户面板不显示ToolStripMenuItem.Name = "用户面板不显示ToolStripMenuItem";
            this.用户面板不显示ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.用户面板不显示ToolStripMenuItem.Text = "用户面板不显示";
            this.用户面板不显示ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 面板不显示ToolStripMenuItem
            // 
            this.面板不显示ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.面板不显示ToolStripMenuItem.Name = "面板不显示ToolStripMenuItem";
            this.面板不显示ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.面板不显示ToolStripMenuItem.Text = "面板不显示";
            this.面板不显示ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 智能关键字不显示ToolStripMenuItem
            // 
            this.智能关键字不显示ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.智能关键字不显示ToolStripMenuItem.Name = "智能关键字不显示ToolStripMenuItem";
            this.智能关键字不显示ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.智能关键字不显示ToolStripMenuItem.Text = "智能关键字不显示";
            this.智能关键字不显示ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.Keyword);
            this.panel3.Controls.Add(this.Study);
            this.panel3.Controls.Add(this.Favorites);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 621);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(339, 38);
            this.panel3.TabIndex = 1;
            // 
            // Keyword
            // 
            this.Keyword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Keyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Keyword.ForeColor = System.Drawing.Color.White;
            this.Keyword.Location = new System.Drawing.Point(12, 6);
            this.Keyword.Margin = new System.Windows.Forms.Padding(0);
            this.Keyword.Name = "Keyword";
            this.Keyword.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.Keyword.Size = new System.Drawing.Size(84, 22);
            this.Keyword.TabIndex = 2;
            this.Keyword.Text = "关键字";
            this.Keyword.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Keyword.Click += new System.EventHandler(this.lblButtom1_Click);
            // 
            // Study
            // 
            this.Study.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Study.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(143)))), ((int)(((byte)(178)))));
            this.Study.ForeColor = System.Drawing.Color.White;
            this.Study.Location = new System.Drawing.Point(123, 6);
            this.Study.Margin = new System.Windows.Forms.Padding(0);
            this.Study.Name = "Study";
            this.Study.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.Study.Size = new System.Drawing.Size(52, 22);
            this.Study.TabIndex = 3;
            this.Study.Text = "后台";
            this.Study.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Study.Click += new System.EventHandler(this.lblButtom1_Click);
            // 
            // Favorites
            // 
            this.Favorites.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Favorites.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.Favorites.ForeColor = System.Drawing.Color.White;
            this.Favorites.Location = new System.Drawing.Point(188, 6);
            this.Favorites.Margin = new System.Windows.Forms.Padding(0);
            this.Favorites.Name = "Favorites";
            this.Favorites.Padding = new System.Windows.Forms.Padding(4, 2, 0, 0);
            this.Favorites.Size = new System.Drawing.Size(84, 22);
            this.Favorites.TabIndex = 4;
            this.Favorites.Text = "我的添加";
            this.Favorites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Favorites.Click += new System.EventHandler(this.lblButtom1_Click);
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.TitleBg;
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.picTitleTool1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 32);
            this.panel2.TabIndex = 0;
            this.panel2.Click += new System.EventHandler(this.panel2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.comboBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "and",
            "or"});
            this.comboBox1.Location = new System.Drawing.Point(223, 4);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(79, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 15);
            this.label1.TabIndex = 0;
            // 
            // picTitleTool1
            // 
            this.picTitleTool1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picTitleTool1.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.close;
            this.picTitleTool1.Location = new System.Drawing.Point(311, 8);
            this.picTitleTool1.Margin = new System.Windows.Forms.Padding(4);
            this.picTitleTool1.Name = "picTitleTool1";
            this.picTitleTool1.Size = new System.Drawing.Size(19, 20);
            this.picTitleTool1.TabIndex = 1;
            this.picTitleTool1.TabStop = false;
            this.picTitleTool1.Click += new System.EventHandler(this.picTitleTool1_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // keyword1
            // 
            this.keyword1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.keyword1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keyword1.Location = new System.Drawing.Point(0, 32);
            this.keyword1.Margin = new System.Windows.Forms.Padding(5);
            this.keyword1.Name = "keyword1";
            this.keyword1.Size = new System.Drawing.Size(339, 589);
            this.keyword1.TabIndex = 6;
            this.keyword1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyword1_KeyDown);
            // 
            // Right
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Right";
            this.Size = new System.Drawing.Size(341, 661);
            this.Load += new System.EventHandler(this.Left_Load);
            this.Click += new System.EventHandler(this.Right_Click);
            this.Enter += new System.EventHandler(this.Right_Enter);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTitleTool1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picTitleTool1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label Keyword;
        private System.Windows.Forms.Label Favorites;
        private System.Windows.Forms.Label Study;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 新建ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除ToolStripMenuItem;
        private WindowsFormsApplication1.Keyword keyword1;
        private System.Windows.Forms.ToolStripMenuItem 展开下列所有节目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭下列所有节目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关闭所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 向上排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 向下排列ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 用户面板不显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 面板不显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 智能关键字不显示ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem 设为同款关键字ToolStripMenuItem;
    }
}
