namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    partial class Keyword_UC6
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
            this.flp_filter = new System.Windows.Forms.FlowLayoutPanel();
            this.flb_resident = new System.Windows.Forms.FlowLayoutPanel();
            this.keyword_UC31 = new SirdRoom.ManageSystem.ClientApplication.Control.Keyword_UC3();
            this.SuspendLayout();
            // 
            // flp_filter
            // 
            this.flp_filter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.flp_filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.flp_filter.Location = new System.Drawing.Point(0, 0);
            this.flp_filter.Name = "flp_filter";
            this.flp_filter.Size = new System.Drawing.Size(588, 44);
            this.flp_filter.TabIndex = 0;
            // 
            // flb_resident
            // 
            this.flb_resident.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.flb_resident.Dock = System.Windows.Forms.DockStyle.Top;
            this.flb_resident.Location = new System.Drawing.Point(0, 150);
            this.flb_resident.Name = "flb_resident";
            this.flb_resident.Size = new System.Drawing.Size(588, 40);
            this.flb_resident.TabIndex = 2;
            // 
            // keyword_UC31
            // 
            this.keyword_UC31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.keyword_UC31.Dock = System.Windows.Forms.DockStyle.Top;
            this.keyword_UC31.Location = new System.Drawing.Point(0, 44);
            this.keyword_UC31.Name = "keyword_UC31";
            this.keyword_UC31.Size = new System.Drawing.Size(588, 106);
            this.keyword_UC31.TabIndex = 1;
            // 
            // Keyword_UC6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.Controls.Add(this.flb_resident);
            this.Controls.Add(this.keyword_UC31);
            this.Controls.Add(this.flp_filter);
            this.Name = "Keyword_UC6";
            this.Size = new System.Drawing.Size(588, 193);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flp_filter;
        private Keyword_UC3 keyword_UC31;
        private System.Windows.Forms.FlowLayoutPanel flb_resident;
    }
}
