namespace SirdRoom.ManageSystem.ClientApplication.D.Pages
{
    partial class Schedule
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
            this.lbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(25, 45);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(107, 12);
            this.lbl.TabIndex = 1;
            this.lbl.Text = "发送信息中.......";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(25, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(424, 23);
            this.panel1.TabIndex = 2;
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 127);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(487, 165);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(487, 165);
            this.Name = "Schedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "发送信息";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Panel panel1;
    }
}