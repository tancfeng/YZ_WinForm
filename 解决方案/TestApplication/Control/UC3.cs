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
    public partial class UC3 : UserControl
    {
        public UC3()
        {
            InitializeComponent();
            for (int i = 0; i < 3; i++)
            {
                var m = new UC2();
                m.Dock = DockStyle.Top;
                this.Controls.Add(m);
            }
        }
        public int AdjustHeight()
        {
            var h = 0;
            foreach (UC2 item in this.Controls)
            {
                item.Height = item.AdjustHeight();
                h += item.Height;
            }
            return h;
        }


    }
}
