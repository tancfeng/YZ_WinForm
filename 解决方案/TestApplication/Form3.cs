using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Resize(object sender, EventArgs e)
        {
            this.uC31.Height = this.uC31.AdjustHeight();
        }
        private void Form3_Shown(object sender, EventArgs e)
        {
            this.uC31.Height = this.uC31.AdjustHeight();
        }
    }
}
