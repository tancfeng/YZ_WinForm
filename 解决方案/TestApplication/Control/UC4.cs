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
    public partial class UC4 : UserControl
    {
        public UC4()
        {
            InitializeComponent();
            for (int i = 0; i < 50; i++)
            {
                var c = new UC1("单体模型" + i);
                this.flowLayoutPanel1.Controls.Add(c);
            }                        
        }
        public int AdjustHeight()
        {
            if (this.flowLayoutPanel1.Controls.Count == 0) return 0;
            var w = 0;
            var h = 0;
            foreach (UserControl item in this.flowLayoutPanel1.Controls)
            {
                w += item.Width + item.Margin.Left + item.Margin.Right;
                if (w > this.flowLayoutPanel1.Width)
                {
                    w = item.Width;
                    h++;
                }
            }
            var controls = this.flowLayoutPanel1.Controls[0];
            var height = (h + 1) * (controls.Height + controls.Margin.Top + controls.Margin.Bottom);
            return height;
        }
    }
}
