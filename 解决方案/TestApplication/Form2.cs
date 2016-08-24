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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.uC31.Height = this.uC31.AdjustHeight();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            //this.uC31.Height = this.uC31.AdjustHeight();
        }

        private void Form2_Resize(object sender, EventArgs e)
        {
            this.uC31.Height = this.uC31.AdjustHeight();
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            ;
        }
    }
}
