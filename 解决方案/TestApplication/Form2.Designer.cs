namespace TestApplication
{
    partial class Form2
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
            this.uC31 = new TestApplication.Control.UC3();
            this.SuspendLayout();
            // 
            // uC31
            // 
            this.uC31.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC31.Location = new System.Drawing.Point(0, 0);
            this.uC31.Name = "uC31";
            this.uC31.Size = new System.Drawing.Size(889, 542);
            this.uC31.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 542);
            this.Controls.Add(this.uC31);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.VisibleChanged += new System.EventHandler(this.Form2_VisibleChanged);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form2_Paint);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.UC3 uC31;
    }
}