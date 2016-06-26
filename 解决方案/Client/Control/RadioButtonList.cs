using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sirdroom.Exam.Library.Controls
{
    public partial class RadioButtonList : UserControl
    {
        public RadioButtonList()
        {
            InitializeComponent();
            this.I18N();
        }
        void I18N()
        {
            
        }

        public Int32 Get()
        {
            Int32 iJG = 0;
            if (this.radioButton1.Checked == true)
            {
                iJG = 0;
            }
            else if (this.radioButton2.Checked == true)
            {
                iJG = 1;
            }
            else if (this.radioButton4.Checked == true)
            {
                iJG = 2;
            }
            return iJG;
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            this.radioButton1.Checked = false;
            this.radioButton2.Checked = false;
            this.radioButton4.Checked = false;
            RadioButton rad = sender as RadioButton;
            rad.Checked = true;
        }
    }
}
