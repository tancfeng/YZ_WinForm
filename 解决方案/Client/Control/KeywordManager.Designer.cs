namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    partial class KeywordManager
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox_Category = new System.Windows.Forms.ListBox();
            this.listBox_Keyword = new System.Windows.Forms.ListBox();
            this.btn_CategoryAdd = new System.Windows.Forms.Button();
            this.btn_CategoryDel = new System.Windows.Forms.Button();
            this.btn_KeywordAdd = new System.Windows.Forms.Button();
            this.btn_KeywordDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "分类";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(316, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "关键字";
            // 
            // listBox_Category
            // 
            this.listBox_Category.FormattingEnabled = true;
            this.listBox_Category.ItemHeight = 15;
            this.listBox_Category.Location = new System.Drawing.Point(33, 48);
            this.listBox_Category.Name = "listBox_Category";
            this.listBox_Category.Size = new System.Drawing.Size(269, 319);
            this.listBox_Category.TabIndex = 2;
            // 
            // listBox_Keyword
            // 
            this.listBox_Keyword.FormattingEnabled = true;
            this.listBox_Keyword.ItemHeight = 15;
            this.listBox_Keyword.Location = new System.Drawing.Point(319, 48);
            this.listBox_Keyword.Name = "listBox_Keyword";
            this.listBox_Keyword.Size = new System.Drawing.Size(245, 319);
            this.listBox_Keyword.TabIndex = 3;
            // 
            // btn_CategoryAdd
            // 
            this.btn_CategoryAdd.Location = new System.Drawing.Point(33, 373);
            this.btn_CategoryAdd.Name = "btn_CategoryAdd";
            this.btn_CategoryAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_CategoryAdd.TabIndex = 4;
            this.btn_CategoryAdd.Text = "新增";
            this.btn_CategoryAdd.UseVisualStyleBackColor = true;
            // 
            // btn_CategoryDel
            // 
            this.btn_CategoryDel.Location = new System.Drawing.Point(115, 372);
            this.btn_CategoryDel.Name = "btn_CategoryDel";
            this.btn_CategoryDel.Size = new System.Drawing.Size(75, 23);
            this.btn_CategoryDel.TabIndex = 5;
            this.btn_CategoryDel.Text = "删除";
            this.btn_CategoryDel.UseVisualStyleBackColor = true;
            // 
            // btn_KeywordAdd
            // 
            this.btn_KeywordAdd.Location = new System.Drawing.Point(319, 372);
            this.btn_KeywordAdd.Name = "btn_KeywordAdd";
            this.btn_KeywordAdd.Size = new System.Drawing.Size(75, 23);
            this.btn_KeywordAdd.TabIndex = 6;
            this.btn_KeywordAdd.Text = "新增";
            this.btn_KeywordAdd.UseVisualStyleBackColor = true;
            // 
            // btn_KeywordDel
            // 
            this.btn_KeywordDel.Location = new System.Drawing.Point(401, 371);
            this.btn_KeywordDel.Name = "btn_KeywordDel";
            this.btn_KeywordDel.Size = new System.Drawing.Size(75, 23);
            this.btn_KeywordDel.TabIndex = 7;
            this.btn_KeywordDel.Text = "删除";
            this.btn_KeywordDel.UseVisualStyleBackColor = true;
            // 
            // KeywordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.btn_KeywordDel);
            this.Controls.Add(this.btn_KeywordAdd);
            this.Controls.Add(this.btn_CategoryDel);
            this.Controls.Add(this.btn_CategoryAdd);
            this.Controls.Add(this.listBox_Keyword);
            this.Controls.Add(this.listBox_Category);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KeywordManager";
            this.Size = new System.Drawing.Size(605, 449);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox_Category;
        private System.Windows.Forms.ListBox listBox_Keyword;
        private System.Windows.Forms.Button btn_CategoryAdd;
        private System.Windows.Forms.Button btn_CategoryDel;
        private System.Windows.Forms.Button btn_KeywordAdd;
        private System.Windows.Forms.Button btn_KeywordDel;
    }
}
