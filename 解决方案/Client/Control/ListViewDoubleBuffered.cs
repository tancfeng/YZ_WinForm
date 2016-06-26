using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.Control
{
    public class ListViewDoubleBuffered:ListView
    {
        protected override bool DoubleBuffered
        {
            get
            {
                return true;
            }

            set
            {
                base.DoubleBuffered = value;
            }
        }
    }
}
