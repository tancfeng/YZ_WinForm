using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class SRFMessageBox : Form
    {
        MessageBoxButtons probtns= MessageBoxButtons.YesNo;
        public SRFMessageBox(String strText, string strTitle, MessageBoxButtons btns)
        {
            InitializeComponent();
            probtns = btns;
            this.Text = strTitle;
            this.label1.Text = strText;

            this.Icon = null;
            this.label1.Location = new Point((this.Width - label1.Width) / 2, (this.Height - label1.Height - 30 - 40) / 2);

            if (MessageBoxButtons.YesNo == probtns)
            {
                this.button1.Visible = true;
                this.button3.Visible = true;
                this.button1.Location = new Point((this.Width / 2 - 3 - 75), this.Height - 40 - 30);
                this.button3.Location = new Point((this.Width / 2 + 3), this.Height - 40 - 30);
            }
            else if (MessageBoxButtons.OK == probtns)
            {
                this.button1.Text = "确定";
                this.button1.Location = new Point((this.Width - button1.Width) / 2, this.Height - 40 - 30);
                this.button1.Visible = true;
                this.button3.Visible = false;
            }
            else
            {
                this.button1.Visible = false;
                this.button3.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBoxButtons.YesNo == probtns)
            {
                this.DialogResult = DialogResult.Yes;
            }
            else if (MessageBoxButtons.OK == probtns)
            {
                this.DialogResult = DialogResult.OK;
            }
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
