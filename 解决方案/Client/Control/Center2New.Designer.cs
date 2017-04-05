using System.Windows.Forms;

namespace ControlLibrary.Control
{
    partial class Center2New
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.faTabStrip1 = new FarsiLibrary.Win.FATabStrip();
            this.listView1 = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.选择全部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.清除选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.复制到指定目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加到ImageBasketTtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.跳转到资源目录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.faTabStrip1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // faTabStrip1
            // 
            this.faTabStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.faTabStrip1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.faTabStrip1.Location = new System.Drawing.Point(0, 0);
            this.faTabStrip1.Name = "faTabStrip1";
            this.faTabStrip1.Size = new System.Drawing.Size(357, 208);
            this.faTabStrip1.TabIndex = 0;
            this.faTabStrip1.Text = "faTabStrip1";
            this.faTabStrip1.TabStripItemAdd += new FarsiLibrary.Win.TabStripItemAddHandler(this.faTabStrip1_TabStripItemAdd);
            this.faTabStrip1.TabStripItemClosing += new FarsiLibrary.Win.TabStripItemClosingHandler(this.faTabStrip1_TabStripItemClosing);
            this.faTabStrip1.TabStripItemSelectionChanged += new FarsiLibrary.Win.TabStripItemChangedHandler(this.faTabStrip1_TabStripItemSelectionChanged);
            this.faTabStrip1.TabStripClose += new System.EventHandler(this.faTabStrip1_TabStripClose);
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.listView1.ContextMenuStrip = this.contextMenuStrip1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 31);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(580, 159);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listView1_ItemDrag);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DragLeave += new System.EventHandler(this.listView1_DragLeave);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            this.listView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择全部ToolStripMenuItem,
            this.toolStripSeparator1,
            this.清除选择ToolStripMenuItem,
            this.清除所有ToolStripMenuItem,
            this.toolStripSeparator2,
            this.复制到指定目录ToolStripMenuItem,
            this.添加到ImageBasketTtoolStripMenuItem,
            this.跳转到资源目录ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(247, 200);
            this.contextMenuStrip1.VisibleChanged += new System.EventHandler(this.contextMenuStrip1_VisibleChanged);
            // 
            // 选择全部ToolStripMenuItem
            // 
            this.选择全部ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.选择全部ToolStripMenuItem.Name = "选择全部ToolStripMenuItem";
            this.选择全部ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.选择全部ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.选择全部ToolStripMenuItem.Text = "选择全部";
            this.选择全部ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // 清除选择ToolStripMenuItem
            // 
            this.清除选择ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.清除选择ToolStripMenuItem.Name = "清除选择ToolStripMenuItem";
            this.清除选择ToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.清除选择ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.清除选择ToolStripMenuItem.Text = "清除选择";
            this.清除选择ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 清除所有ToolStripMenuItem
            // 
            this.清除所有ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.清除所有ToolStripMenuItem.Name = "清除所有ToolStripMenuItem";
            this.清除所有ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.清除所有ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.清除所有ToolStripMenuItem.Text = "清除所有";
            this.清除所有ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // 复制到指定目录ToolStripMenuItem
            // 
            this.复制到指定目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.复制到指定目录ToolStripMenuItem.Name = "复制到指定目录ToolStripMenuItem";
            this.复制到指定目录ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.复制到指定目录ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.复制到指定目录ToolStripMenuItem.Text = "复制到指定目录";
            this.复制到指定目录ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // 添加到ImageBasketTtoolStripMenuItem
            // 
            this.添加到ImageBasketTtoolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.添加到ImageBasketTtoolStripMenuItem.Name = "添加到ImageBasketTtoolStripMenuItem";
            this.添加到ImageBasketTtoolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.添加到ImageBasketTtoolStripMenuItem.Text = "添加到ImageBasket";
            this.添加到ImageBasketTtoolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            this.添加到ImageBasketTtoolStripMenuItem.EnabledChanged += new System.EventHandler(this.添加到ImageBasketTtoolStripMenuItem_EnabledChanged);
            // 
            // 跳转到资源目录ToolStripMenuItem
            // 
            this.跳转到资源目录ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.跳转到资源目录ToolStripMenuItem.Name = "跳转到资源目录ToolStripMenuItem";
            this.跳转到资源目录ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.跳转到资源目录ToolStripMenuItem.Size = new System.Drawing.Size(246, 26);
            this.跳转到资源目录ToolStripMenuItem.Text = "跳转到资源目录";
            this.跳转到资源目录ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // Center2New
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.faTabStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "Center2New";
            this.Size = new System.Drawing.Size(357, 208);
            this.Enter += new System.EventHandler(this.Center2New_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.faTabStrip1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private FarsiLibrary.Win.FATabStrip faTabStrip1;
        public System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 选择全部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 清除选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 复制到指定目录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 跳转到资源目录ToolStripMenuItem;
        private ToolStripMenuItem 添加到ImageBasketTtoolStripMenuItem;
    }
}
