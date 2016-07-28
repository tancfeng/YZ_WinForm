namespace ControlLibrary.Control
{
    partial class Tool
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.p0 = new System.Windows.Forms.ToolStripButton();
            this.p1 = new System.Windows.Forms.ToolStripButton();
            this.p2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.p3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Sort = new System.Windows.Forms.ToolStripDropDownButton();
            this.p4 = new System.Windows.Forms.ToolStripMenuItem();
            this.p5 = new System.Windows.Forms.ToolStripMenuItem();
            this.p6 = new System.Windows.Forms.ToolStripMenuItem();
            this.p7 = new System.Windows.Forms.ToolStripMenuItem();
            this.p8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.递增ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.递减ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.p9 = new System.Windows.Forms.ToolStripButton();
            this.p10 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.p11 = new System.Windows.Forms.ToolStripButton();
            this.p12 = new System.Windows.Forms.ToolStripButton();
            this.p13 = new System.Windows.Forms.ToolStripButton();
            this.p14 = new System.Windows.Forms.ToolStripButton();
            this.btnQuery = new System.Windows.Forms.ToolStripButton();
            this.txtQuery = new System.Windows.Forms.ToolStripTextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1087, 1);
            this.panel1.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Location = new System.Drawing.Point(49, 41);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1031, 28);
            this.panel2.TabIndex = 23;
            // 
            // toolTip1
            // 
            this.toolTip1.BackColor = System.Drawing.Color.Black;
            this.toolTip1.ForeColor = System.Drawing.Color.White;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.p0,
            this.p1,
            this.p2,
            this.toolStripSeparator1,
            this.p3,
            this.toolStripSeparator2,
            this.Sort,
            this.p9,
            this.p10,
            this.toolStripSeparator3,
            this.p11,
            this.p12,
            this.p13,
            this.p14,
            this.btnQuery,
            this.txtQuery});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1087, 27);
            this.toolStrip1.TabIndex = 27;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // p0
            // 
            this.p0.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p0.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._0_0;
            this.p0.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p0.Name = "p0";
            this.p0.Size = new System.Drawing.Size(24, 24);
            this.p0.Text = "后退";
            this.p0.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p1
            // 
            this.p1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p1.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._1_0;
            this.p1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p1.Name = "p1";
            this.p1.Size = new System.Drawing.Size(24, 24);
            this.p1.Text = "前进";
            this.p1.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p2
            // 
            this.p2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p2.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._2_0;
            this.p2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p2.Name = "p2";
            this.p2.Size = new System.Drawing.Size(24, 24);
            this.p2.Text = "上移";
            this.p2.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // p3
            // 
            this.p3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p3.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._3_0;
            this.p3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p3.Name = "p3";
            this.p3.Size = new System.Drawing.Size(24, 24);
            this.p3.Text = "刷新";
            this.p3.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // Sort
            // 
            this.Sort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Sort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Sort.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.p4,
            this.p5,
            this.p6,
            this.p7,
            this.p8,
            this.toolStripMenuItem1,
            this.递增ToolStripMenuItem,
            this.递减ToolStripMenuItem});
            this.Sort.ForeColor = System.Drawing.Color.White;
            this.Sort.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.sort19;
            this.Sort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sort.Name = "Sort";
            this.Sort.Size = new System.Drawing.Size(83, 24);
            this.Sort.Text = "排序方式";
            // 
            // p4
            // 
            this.p4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.p4.ForeColor = System.Drawing.Color.White;
            this.p4.Name = "p4";
            this.p4.Size = new System.Drawing.Size(189, 26);
            this.p4.Text = "按更新时间排列";
            this.p4.Visible = false;
            this.p4.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p5
            // 
            this.p5.ForeColor = System.Drawing.Color.White;
            this.p5.Name = "p5";
            this.p5.Size = new System.Drawing.Size(189, 26);
            this.p5.Text = "按使用次数排列";
            this.p5.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p6
            // 
            this.p6.ForeColor = System.Drawing.Color.White;
            this.p6.Name = "p6";
            this.p6.Size = new System.Drawing.Size(189, 26);
            this.p6.Text = "按修改时间排列";
            this.p6.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p7
            // 
            this.p7.ForeColor = System.Drawing.Color.White;
            this.p7.Name = "p7";
            this.p7.Size = new System.Drawing.Size(189, 26);
            this.p7.Text = "按文件大小排列";
            this.p7.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p8
            // 
            this.p8.ForeColor = System.Drawing.Color.White;
            this.p8.Name = "p8";
            this.p8.Size = new System.Drawing.Size(189, 26);
            this.p8.Text = "按文件名称排列";
            this.p8.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(186, 6);
            // 
            // 递增ToolStripMenuItem
            // 
            this.递增ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.递增ToolStripMenuItem.Name = "递增ToolStripMenuItem";
            this.递增ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.递增ToolStripMenuItem.Text = "递增";
            this.递增ToolStripMenuItem.Click += new System.EventHandler(this.递增ToolStripMenuItem_Click);
            // 
            // 递减ToolStripMenuItem
            // 
            this.递减ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.递减ToolStripMenuItem.Name = "递减ToolStripMenuItem";
            this.递减ToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.递减ToolStripMenuItem.Text = "递减";
            this.递减ToolStripMenuItem.Click += new System.EventHandler(this.递减ToolStripMenuItem_Click);
            // 
            // p9
            // 
            this.p9.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p9.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._9_0;
            this.p9.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p9.Name = "p9";
            this.p9.Size = new System.Drawing.Size(24, 24);
            this.p9.Text = "查看";
            this.p9.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p10
            // 
            this.p10.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p10.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._10_0;
            this.p10.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p10.Name = "p10";
            this.p10.Size = new System.Drawing.Size(24, 24);
            this.p10.Text = "显示";
            this.p10.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // p11
            // 
            this.p11.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p11.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._11_0;
            this.p11.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p11.Name = "p11";
            this.p11.Size = new System.Drawing.Size(24, 24);
            this.p11.Text = "设置路径";
            this.p11.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p12
            // 
            this.p12.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p12.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._12_0;
            this.p12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p12.Name = "p12";
            this.p12.Size = new System.Drawing.Size(24, 24);
            this.p12.Text = "跳转到资源目录";
            this.p12.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p13
            // 
            this.p13.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p13.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._13_0;
            this.p13.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p13.Name = "p13";
            this.p13.Size = new System.Drawing.Size(24, 24);
            this.p13.Text = "复制到指定目录";
            this.p13.Click += new System.EventHandler(this.PicTool_Click);
            // 
            // p14
            // 
            this.p14.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.p14.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._14_0;
            this.p14.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.p14.Name = "p14";
            this.p14.Size = new System.Drawing.Size(24, 24);
            this.p14.Text = "关键字过滤";
            this.p14.Click += new System.EventHandler(this.PicTool_Click);
            this.p14.MouseUp += new System.Windows.Forms.MouseEventHandler(this.p14_MouseUp);
            // 
            // btnQuery
            // 
            this.btnQuery.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnQuery.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnQuery.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.query;
            this.btnQuery.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(24, 24);
            this.btnQuery.Text = "toolStripButton11";
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // txtQuery
            // 
            this.txtQuery.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(200, 27);
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.T2_1;
            this.pictureBox5.Location = new System.Drawing.Point(5, 39);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(37, 31);
            this.pictureBox5.TabIndex = 4;
            this.pictureBox5.TabStop = false;
            // 
            // Tool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox5);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Tool";
            this.Size = new System.Drawing.Size(1087, 73);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton p0;
        private System.Windows.Forms.ToolStripButton p1;
        private System.Windows.Forms.ToolStripButton p2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton p3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripDropDownButton Sort;
        private System.Windows.Forms.ToolStripMenuItem p4;
        private System.Windows.Forms.ToolStripMenuItem p5;
        private System.Windows.Forms.ToolStripMenuItem p6;
        private System.Windows.Forms.ToolStripMenuItem p7;
        private System.Windows.Forms.ToolStripMenuItem p8;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 递增ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 递减ToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton p9;
        private System.Windows.Forms.ToolStripButton p10;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton p11;
        private System.Windows.Forms.ToolStripButton p12;
        private System.Windows.Forms.ToolStripButton p13;
        private System.Windows.Forms.ToolStripButton p14;
        private System.Windows.Forms.ToolStripButton btnQuery;
        private System.Windows.Forms.ToolStripTextBox txtQuery;
    }
}
