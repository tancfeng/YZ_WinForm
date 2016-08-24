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
    public partial class BiaoQianControl : UserControl
    {
        public BiaoQianControl()
        {
            InitializeComponent();
        }
        public BiaoQianControl(string labelText) : this()
        {
            this.label1.Text = labelText;
            

                
        }
    }
}
