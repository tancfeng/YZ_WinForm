using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    public partial class Keyword_UC7 : UserControl
    {
        public Keyword_UC2 ParentKeyword_UC2 { get; set; }
        public Keyword_UC7()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.ParentKeyword_UC2.Convert_UC4_To_UC1();
        }
    }
}
