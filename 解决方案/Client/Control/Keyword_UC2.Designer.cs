namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    partial class Keyword_UC2
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
            this.CategoryName = new System.Windows.Forms.Label();
            this.flp_keyword = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // CategoryName
            // 
            this.CategoryName.Dock = System.Windows.Forms.DockStyle.Left;
            this.CategoryName.ForeColor = System.Drawing.Color.Silver;
            this.CategoryName.Location = new System.Drawing.Point(0, 0);
            this.CategoryName.Margin = new System.Windows.Forms.Padding(0);
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Padding = new System.Windows.Forms.Padding(5);
            this.CategoryName.Size = new System.Drawing.Size(120, 149);
            this.CategoryName.TabIndex = 0;
            this.CategoryName.Text = "label1";
            // 
            // flp_keyword
            // 
            this.flp_keyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.flp_keyword.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flp_keyword.Location = new System.Drawing.Point(120, 0);
            this.flp_keyword.Name = "flp_keyword";
            this.flp_keyword.Size = new System.Drawing.Size(455, 149);
            this.flp_keyword.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 149);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 1);
            this.panel1.TabIndex = 2;
            // 
            // Keyword_UC2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.flp_keyword);
            this.Controls.Add(this.CategoryName);
            this.Controls.Add(this.panel1);
            this.Name = "Keyword_UC2";
            this.Size = new System.Drawing.Size(575, 150);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label CategoryName;
        private System.Windows.Forms.FlowLayoutPanel flp_keyword;
        private System.Windows.Forms.Panel panel1;
    }
}
