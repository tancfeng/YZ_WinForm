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
    public partial class Keyword_UC2 : UserControl
    {
        public Keyword_UC2()
        {
            InitializeComponent();
        }
        public Keyword_UC2(string categoryName,IEnumerable<SRRC_BiaoJiKeywordEntity> list) : this()
        {
            this.CategoryName.Text = categoryName;
            foreach (var item in list)
            {
                var v = new Keyword_UC1(item.Name);
                v.Name = item.Id.ToString();
               // v.Tag = item;
                this.flp_keyword.Controls.Add(v);
            }
        }
        public void SetBiaoJiKeywordStatus(List<long> list)
        {
            foreach (Keyword_UC1 item in this.flp_keyword.Controls)
            {
                if (list.Exists(l => l.ToString() == item.Name))
                {
                   item.CheckStatusChange(true);
                }
                else
                {
                    item.CheckStatusChange(false);
                }
            }
        }
        public int AdjustHeight()
        {
            if (this.flp_keyword.Controls.Count == 0) return 0;
            var w = 0;
            var h = 0;
            foreach (UserControl item in this.flp_keyword.Controls)
            {
                var ww = item.Width + item.Margin.Left + item.Margin.Right;
                w += ww;
                if (w > this.flp_keyword.Width)
                {
                    w = ww;
                    h++;
                }
            }
            var controls = this.flp_keyword.Controls[0];
            var height = (h + 1) * (controls.Height + controls.Margin.Top + controls.Margin.Bottom);
            return height + this.flp_keyword.Margin.Top + this.flp_keyword.Margin.Bottom;
        }
    }
}
