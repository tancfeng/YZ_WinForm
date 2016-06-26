using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication.D.Pages
{
    public partial class Schedule : Form
    {
        public Schedule()
        {
            InitializeComponent();
        }
        public Schedule(String str)
        {
            InitializeComponent();
            this.Text = str;
            this.lbl.Text = String.Format("{0}中......", str);
        }
    }
}
