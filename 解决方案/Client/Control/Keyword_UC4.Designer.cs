namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    partial class Keyword_UC4
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
            this.UC_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UC_Text
            // 
            this.UC_Text.AutoSize = true;
            this.UC_Text.ForeColor = System.Drawing.Color.Silver;
            this.UC_Text.Location = new System.Drawing.Point(3, 3);
            this.UC_Text.Name = "UC_Text";
            this.UC_Text.Size = new System.Drawing.Size(55, 15);
            this.UC_Text.TabIndex = 0;
            this.UC_Text.Text = "label1";
            this.UC_Text.Click += new System.EventHandler(this.UC_Text_Click);
            // 
            // Keyword_UC4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.UC_Text);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "Keyword_UC4";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(64, 21);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label UC_Text;
    }
}
