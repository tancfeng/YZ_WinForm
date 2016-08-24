using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestApplication.Control
{
    public partial class UC1 : UserControl
    {
        public UC1()
        {
            InitializeComponent();
        }
        public UC1(string text):this()
        {
            this.label1.Text = text;
        }
    }
}
