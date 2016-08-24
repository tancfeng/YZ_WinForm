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
    public partial class Keyword_UC5 : UserControl
    {
        private List<SRRC_BiaoJiKeywordEntity> entList { get; set; }
        private string CategoryName { get; set; }
        public Keyword_UC5()
        {
            InitializeComponent();
        }
        public Keyword_UC5(string categoryName,List<SRRC_BiaoJiKeywordEntity> list):this()
        {
            this.CategoryName = categoryName;
            entList = list;
            this.lb_Category.Text = categoryName+":";
            var w = this.lb_Category.Width+this.lb_Category.Margin.Right+this.lb_Category.Margin.Left;
            w += this.lb_Keyword.Margin.Left;
            this.lb_Keyword.Location = new Point(w, this.lb_Keyword.Location.Y);
            var v = list.OrderBy(l => l.OrderBy).Select(l => l.Name);
            this.lb_Keyword.Text = string.Join("、", v);
            w += this.lb_Keyword.Width+this.lb_Keyword.Margin.Right;
            w += this.pic_delete.Margin.Left;
            this.pic_delete.Location = new Point(w, this.pic_delete.Location.Y);
        }

        private void pic_delete_Click(object sender, EventArgs e)
        {
            SROperation2.Instance.BiaoJiKeywordFilterList.RemoveAll(l=>l.CategoryName == this.CategoryName);
            (this.ParentForm as FrmMain).Keyword_UC6Refresh();
        }
    }
}
