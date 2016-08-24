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
    public partial class BiaoQianPanelControl : UserControl
    {
        public BiaoQianPanelControl()
        {
            InitializeComponent();
            Initialization();
        }
        public void Initialization()
        {
            for (int i = 0; i < 4; i++)
            {
                var control = new BiaoQianControl();
                control.Dock = DockStyle.Top;
                this.Controls.Add(control);
            }            
        }
    }
}
