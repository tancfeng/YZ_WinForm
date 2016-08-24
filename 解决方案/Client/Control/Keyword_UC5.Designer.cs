namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    partial class Keyword_UC5
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
            this.pl_Content = new System.Windows.Forms.Panel();
            this.pic_delete = new System.Windows.Forms.PictureBox();
            this.lb_Keyword = new System.Windows.Forms.Label();
            this.lb_Category = new System.Windows.Forms.Label();
            this.pl_Content.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_delete)).BeginInit();
            this.SuspendLayout();
            // 
            // pl_Content
            // 
            this.pl_Content.AutoSize = true;
            this.pl_Content.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pl_Content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.pl_Content.Controls.Add(this.pic_delete);
            this.pl_Content.Controls.Add(this.lb_Keyword);
            this.pl_Content.Controls.Add(this.lb_Category);
            this.pl_Content.Location = new System.Drawing.Point(1, 1);
            this.pl_Content.Margin = new System.Windows.Forms.Padding(0);
            this.pl_Content.Name = "pl_Content";
            this.pl_Content.Size = new System.Drawing.Size(200, 22);
            this.pl_Content.TabIndex = 0;
            // 
            // pic_delete
            // 
            this.pic_delete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_delete.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.delete_16x;
            this.pic_delete.Location = new System.Drawing.Point(181, 3);
            this.pic_delete.Name = "pic_delete";
            this.pic_delete.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.pic_delete.Size = new System.Drawing.Size(16, 16);
            this.pic_delete.TabIndex = 2;
            this.pic_delete.TabStop = false;
            this.pic_delete.Click += new System.EventHandler(this.pic_delete_Click);
            // 
            // lb_Keyword
            // 
            this.lb_Keyword.AutoSize = true;
            this.lb_Keyword.ForeColor = System.Drawing.Color.Red;
            this.lb_Keyword.Location = new System.Drawing.Point(65, 3);
            this.lb_Keyword.Name = "lb_Keyword";
            this.lb_Keyword.Size = new System.Drawing.Size(55, 15);
            this.lb_Keyword.TabIndex = 1;
            this.lb_Keyword.Text = "label1";
            // 
            // lb_Category
            // 
            this.lb_Category.AutoSize = true;
            this.lb_Category.ForeColor = System.Drawing.Color.Silver;
            this.lb_Category.Location = new System.Drawing.Point(3, 3);
            this.lb_Category.Margin = new System.Windows.Forms.Padding(4, 3, 3, 0);
            this.lb_Category.Name = "lb_Category";
            this.lb_Category.Size = new System.Drawing.Size(55, 15);
            this.lb_Category.TabIndex = 0;
            this.lb_Category.Text = "label1";
            // 
            // Keyword_UC5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.pl_Content);
            this.Name = "Keyword_UC5";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(202, 24);
            this.pl_Content.ResumeLayout(false);
            this.pl_Content.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_delete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pl_Content;
        private System.Windows.Forms.PictureBox pic_delete;
        private System.Windows.Forms.Label lb_Keyword;
        private System.Windows.Forms.Label lb_Category;
    }
}
