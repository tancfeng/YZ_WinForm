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
            this.btn_CategoryEdit = new System.Windows.Forms.Button();
            this.btn_KeywordEdit = new System.Windows.Forms.Button();
            this.btn_CategoryUp = new System.Windows.Forms.Button();
            this.btn_CategoryDown = new System.Windows.Forms.Button();
            this.btn_KeywordUp = new System.Windows.Forms.Button();
            this.btn_KeywordDown = new System.Windows.Forms.Button();
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
            this.listBox_Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.listBox_Category.ForeColor = System.Drawing.Color.White;
            this.listBox_Category.FormattingEnabled = true;
            this.listBox_Category.ItemHeight = 15;
            this.listBox_Category.Location = new System.Drawing.Point(33, 48);
            this.listBox_Category.Name = "listBox_Category";
            this.listBox_Category.Size = new System.Drawing.Size(269, 319);
            this.listBox_Category.TabIndex = 2;
            this.listBox_Category.SelectedIndexChanged += new System.EventHandler(this.listBox_Category_SelectedIndexChanged);
            // 
            // listBox_Keyword
            // 
            this.listBox_Keyword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.listBox_Keyword.ForeColor = System.Drawing.Color.White;
            this.listBox_Keyword.FormattingEnabled = true;
            this.listBox_Keyword.ItemHeight = 15;
            this.listBox_Keyword.Location = new System.Drawing.Point(319, 48);
            this.listBox_Keyword.Name = "listBox_Keyword";
            this.listBox_Keyword.Size = new System.Drawing.Size(245, 319);
            this.listBox_Keyword.TabIndex = 3;
            // 
            // btn_CategoryAdd
            // 
            this.btn_CategoryAdd.ForeColor = System.Drawing.Color.White;
            this.btn_CategoryAdd.Location = new System.Drawing.Point(33, 373);
            this.btn_CategoryAdd.Name = "btn_CategoryAdd";
            this.btn_CategoryAdd.Size = new System.Drawing.Size(80, 29);
            this.btn_CategoryAdd.TabIndex = 4;
            this.btn_CategoryAdd.Text = "新增";
            this.btn_CategoryAdd.UseVisualStyleBackColor = false;
            this.btn_CategoryAdd.Click += new System.EventHandler(this.btn_CategoryAdd_Click);
            // 
            // btn_CategoryDel
            // 
            this.btn_CategoryDel.ForeColor = System.Drawing.Color.White;
            this.btn_CategoryDel.Location = new System.Drawing.Point(121, 373);
            this.btn_CategoryDel.Name = "btn_CategoryDel";
            this.btn_CategoryDel.Size = new System.Drawing.Size(80, 29);
            this.btn_CategoryDel.TabIndex = 5;
            this.btn_CategoryDel.Text = "删除";
            this.btn_CategoryDel.UseVisualStyleBackColor = false;
            this.btn_CategoryDel.Click += new System.EventHandler(this.btn_CategoryDel_Click);
            // 
            // btn_KeywordAdd
            // 
            this.btn_KeywordAdd.ForeColor = System.Drawing.Color.White;
            this.btn_KeywordAdd.Location = new System.Drawing.Point(319, 372);
            this.btn_KeywordAdd.Name = "btn_KeywordAdd";
            this.btn_KeywordAdd.Size = new System.Drawing.Size(80, 29);
            this.btn_KeywordAdd.TabIndex = 6;
            this.btn_KeywordAdd.Text = "新增";
            this.btn_KeywordAdd.UseVisualStyleBackColor = false;
            this.btn_KeywordAdd.Click += new System.EventHandler(this.btn_KeywordAdd_Click);
            // 
            // btn_KeywordDel
            // 
            this.btn_KeywordDel.ForeColor = System.Drawing.Color.White;
            this.btn_KeywordDel.Location = new System.Drawing.Point(406, 372);
            this.btn_KeywordDel.Name = "btn_KeywordDel";
            this.btn_KeywordDel.Size = new System.Drawing.Size(80, 29);
            this.btn_KeywordDel.TabIndex = 7;
            this.btn_KeywordDel.Text = "删除";
            this.btn_KeywordDel.UseVisualStyleBackColor = false;
            this.btn_KeywordDel.Click += new System.EventHandler(this.btn_KeywordDel_Click);
            // 
            // btn_CategoryEdit
            // 
            this.btn_CategoryEdit.ForeColor = System.Drawing.Color.White;
            this.btn_CategoryEdit.Location = new System.Drawing.Point(207, 373);
            this.btn_CategoryEdit.Name = "btn_CategoryEdit";
            this.btn_CategoryEdit.Size = new System.Drawing.Size(80, 29);
            this.btn_CategoryEdit.TabIndex = 8;
            this.btn_CategoryEdit.Text = "编辑";
            this.btn_CategoryEdit.UseVisualStyleBackColor = false;
            this.btn_CategoryEdit.Click += new System.EventHandler(this.btn_CategoryEdit_Click);
            // 
            // btn_KeywordEdit
            // 
            this.btn_KeywordEdit.ForeColor = System.Drawing.Color.White;
            this.btn_KeywordEdit.Location = new System.Drawing.Point(490, 372);
            this.btn_KeywordEdit.Name = "btn_KeywordEdit";
            this.btn_KeywordEdit.Size = new System.Drawing.Size(80, 29);
            this.btn_KeywordEdit.TabIndex = 9;
            this.btn_KeywordEdit.Text = "编辑";
            this.btn_KeywordEdit.UseVisualStyleBackColor = false;
            this.btn_KeywordEdit.Click += new System.EventHandler(this.btn_KeywordEdit_Click);
            // 
            // btn_CategoryUp
            // 
            this.btn_CategoryUp.ForeColor = System.Drawing.Color.White;
            this.btn_CategoryUp.Location = new System.Drawing.Point(81, 403);
            this.btn_CategoryUp.Name = "btn_CategoryUp";
            this.btn_CategoryUp.Size = new System.Drawing.Size(80, 29);
            this.btn_CategoryUp.TabIndex = 10;
            this.btn_CategoryUp.Text = "上移";
            this.btn_CategoryUp.UseVisualStyleBackColor = false;
            this.btn_CategoryUp.Click += new System.EventHandler(this.btn_CategoryUp_Click);
            // 
            // btn_CategoryDown
            // 
            this.btn_CategoryDown.ForeColor = System.Drawing.Color.White;
            this.btn_CategoryDown.Location = new System.Drawing.Point(167, 403);
            this.btn_CategoryDown.Name = "btn_CategoryDown";
            this.btn_CategoryDown.Size = new System.Drawing.Size(80, 29);
            this.btn_CategoryDown.TabIndex = 11;
            this.btn_CategoryDown.Text = "下移";
            this.btn_CategoryDown.UseVisualStyleBackColor = false;
            this.btn_CategoryDown.Click += new System.EventHandler(this.btn_CategoryDown_Click);
            // 
            // btn_KeywordUp
            // 
            this.btn_KeywordUp.ForeColor = System.Drawing.Color.White;
            this.btn_KeywordUp.Location = new System.Drawing.Point(356, 405);
            this.btn_KeywordUp.Name = "btn_KeywordUp";
            this.btn_KeywordUp.Size = new System.Drawing.Size(80, 29);
            this.btn_KeywordUp.TabIndex = 12;
            this.btn_KeywordUp.Text = "上移";
            this.btn_KeywordUp.UseVisualStyleBackColor = false;
            this.btn_KeywordUp.Click += new System.EventHandler(this.btn_KeywordUp_Click);
            // 
            // btn_KeywordDown
            // 
            this.btn_KeywordDown.ForeColor = System.Drawing.Color.White;
            this.btn_KeywordDown.Location = new System.Drawing.Point(452, 404);
            this.btn_KeywordDown.Name = "btn_KeywordDown";
            this.btn_KeywordDown.Size = new System.Drawing.Size(80, 29);
            this.btn_KeywordDown.TabIndex = 13;
            this.btn_KeywordDown.Text = "下移";
            this.btn_KeywordDown.UseVisualStyleBackColor = false;
            this.btn_KeywordDown.Click += new System.EventHandler(this.btn_KeywordDown_Click);
            // 
            // KeywordManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.btn_KeywordDown);
            this.Controls.Add(this.btn_KeywordUp);
            this.Controls.Add(this.btn_CategoryDown);
            this.Controls.Add(this.btn_CategoryUp);
            this.Controls.Add(this.btn_KeywordEdit);
            this.Controls.Add(this.btn_CategoryEdit);
            this.Controls.Add(this.btn_KeywordDel);
            this.Controls.Add(this.btn_KeywordAdd);
            this.Controls.Add(this.btn_CategoryDel);
            this.Controls.Add(this.btn_CategoryAdd);
            this.Controls.Add(this.listBox_Keyword);
            this.Controls.Add(this.listBox_Category);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "KeywordManager";
            this.Size = new System.Drawing.Size(605, 432);
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
        private System.Windows.Forms.Button btn_CategoryEdit;
        private System.Windows.Forms.Button btn_KeywordEdit;
        private System.Windows.Forms.Button btn_CategoryUp;
        private System.Windows.Forms.Button btn_CategoryDown;
        private System.Windows.Forms.Button btn_KeywordUp;
        private System.Windows.Forms.Button btn_KeywordDown;
    }
}
