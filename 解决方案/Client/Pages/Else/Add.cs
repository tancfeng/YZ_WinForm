using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication.Pages.Else
{
    public partial class Add : UserControl
    {
        public Add()
        {
            InitializeComponent();
            this.textBox1.Text = Param.DPageParameter;
        }
        public Add(string text)
        {
            InitializeComponent();
            this.textBox1.Text = Param.DPageParameter;
            this.label1.Text = text + ":";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Param.DPageParameter = this.textBox1.Text;
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }
    }
}
