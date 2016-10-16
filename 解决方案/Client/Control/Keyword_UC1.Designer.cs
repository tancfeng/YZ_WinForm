namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    partial class Keyword_UC1
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
            this.IsUnchecked = new System.Windows.Forms.PictureBox();
            this.IsChecked = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IsUnchecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsChecked)).BeginInit();
            this.SuspendLayout();
            // 
            // UC_Text
            // 
            this.UC_Text.AutoSize = true;
            this.UC_Text.Cursor = System.Windows.Forms.Cursors.Default;
            this.UC_Text.ForeColor = System.Drawing.Color.Silver;
            this.UC_Text.Location = new System.Drawing.Point(22, 3);
            this.UC_Text.Name = "UC_Text";
            this.UC_Text.Size = new System.Drawing.Size(55, 15);
            this.UC_Text.TabIndex = 2;
            this.UC_Text.Text = "label1";
            // 
            // IsUnchecked
            // 
            this.IsUnchecked.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._unchecked;
            this.IsUnchecked.Location = new System.Drawing.Point(3, 3);
            this.IsUnchecked.Name = "IsUnchecked";
            this.IsUnchecked.Size = new System.Drawing.Size(16, 16);
            this.IsUnchecked.TabIndex = 1;
            this.IsUnchecked.TabStop = false;
            this.IsUnchecked.Click += new System.EventHandler(this.IsUnchecked_Click);
            // 
            // IsChecked
            // 
            this.IsChecked.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.isChecked;
            this.IsChecked.Location = new System.Drawing.Point(3, 3);
            this.IsChecked.Name = "IsChecked";
            this.IsChecked.Size = new System.Drawing.Size(16, 16);
            this.IsChecked.TabIndex = 0;
            this.IsChecked.TabStop = false;
            this.IsChecked.Visible = false;
            this.IsChecked.Click += new System.EventHandler(this.IsChecked_Click);
            // 
            // Keyword_UC1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.Controls.Add(this.UC_Text);
            this.Controls.Add(this.IsUnchecked);
            this.Controls.Add(this.IsChecked);
            this.Name = "Keyword_UC1";
            this.Size = new System.Drawing.Size(80, 22);
            ((System.ComponentModel.ISupportInitialize)(this.IsUnchecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IsChecked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IsChecked;
        private System.Windows.Forms.PictureBox IsUnchecked;
        private System.Windows.Forms.Label UC_Text;
    }
}
