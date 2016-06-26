using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.Control
{
    public partial class WaitPic : UserControl
    {
        public WaitPic()
        {
            InitializeComponent();
        }

        private void WaitPic_Load(object sender, EventArgs e)
        {
            label1.Text = SROperation2.Instance.entListCount.ToString();
        }
        public void SetReadCount()
        {
            label2.Text = SROperation2.Instance.entListReadyCount.ToString();
        }
    }
}
