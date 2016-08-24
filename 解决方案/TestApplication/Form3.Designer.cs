namespace TestApplication
{
    partial class Form3
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
            this.uC31.Dock = System.Windows.Forms.DockStyle.Top;
            this.uC31.Location = new System.Drawing.Point(0, 0);
            this.uC31.Name = "uC31";
            this.uC31.Size = new System.Drawing.Size(685, 840);
            this.uC31.TabIndex = 0;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 344);
            this.Controls.Add(this.uC31);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Shown += new System.EventHandler(this.Form3_Shown);
            this.Resize += new System.EventHandler(this.Form3_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.UC3 uC31;
    }
}