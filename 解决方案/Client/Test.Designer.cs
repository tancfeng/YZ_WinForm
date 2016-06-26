namespace SirdRoom.ManageSystem.ClientApplication
{
    partial class Test
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("一级1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("一级2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("一级1", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("二级");
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.center21 = new ControlLibrary.Control.Center2();
            this.right1 = new ControlLibrary.Control.Right();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(144, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // treeView2
            // 
            this.treeView2.AllowDrop = true;
            this.treeView2.Location = new System.Drawing.Point(294, 93);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "一级1";
            treeNode1.Text = "一级1";
            treeNode2.Name = "一级2";
            treeNode2.Text = "一级2";
            treeNode3.Name = "一级1";
            treeNode3.Text = "一级1";
            treeNode4.Name = "二级";
            treeNode4.Text = "二级";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode4});
            this.treeView2.Size = new System.Drawing.Size(121, 97);
            this.treeView2.TabIndex = 2;
            this.treeView2.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeView2_DragDrop);
            this.treeView2.DragOver += new System.Windows.Forms.DragEventHandler(this.treeView2_DragOver);
            // 
            // center21
            // 
            this.center21.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.center21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.center21.Location = new System.Drawing.Point(61, 196);
            this.center21.Name = "center21";
            this.center21.Size = new System.Drawing.Size(768, 152);
            this.center21.TabIndex = 3;
            // 
            // right1
            // 
            this.right1.BackColor = System.Drawing.Color.Transparent;
            this.right1.Location = new System.Drawing.Point(269, 12);
            this.right1.Name = "right1";
            this.right1.Size = new System.Drawing.Size(256, 529);
            this.right1.TabIndex = 4;
            // 
            // Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 556);
            this.Controls.Add(this.right1);
            this.Controls.Add(this.center21);
            this.Controls.Add(this.treeView2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TreeView treeView2;
        private ControlLibrary.Control.Center2 center21;
        private ControlLibrary.Control.Right right1;

    }
}