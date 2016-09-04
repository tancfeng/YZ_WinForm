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
    /// <summary>
    /// 关键字 设置和筛选分组面板
    /// </summary>
    public partial class Keyword_UC2 : UserControl
    {        
        public Keyword_UC2()
        {
            InitializeComponent();
        }
        public IEnumerable<SRRC_BiaoJiKeywordEntity> list { get; set; }
        public SRRC_BiaoJiKeywordEntity Category { get; set; }
        public Keyword_UC2(SRRC_BiaoJiKeywordEntity category,IEnumerable<SRRC_BiaoJiKeywordEntity> list,bool isFilter = false) : this()
        {
            this.list = list;
            this.Category = category;
            if(isFilter)
            {
                //keyword 筛选
                this.CategoryName.Text = category.Name;
                this.Name = category.Id.ToString();
                foreach (var item in list)
                {
                    item.CategoryName = category.Name;
                    var v = new Keyword_UC4(item);
                    v.Name = item.Id.ToString();
                    // v.Tag = item;
                    this.flp_keyword.Controls.Add(v);
                }
                //多选
                var add = new Keyword_UC7();               
                add.ParentKeyword_UC2 = this;
                this.flp_keyword.Controls.Add(add);
            }
            else
            {
                //keyword 设置
                this.CategoryName.Text = category.Name;
                foreach (var item in list)
                {
                    var v = new Keyword_UC1(item.Name);
                    v.Name = item.Id.ToString();
                    // v.Tag = item;
                    this.flp_keyword.Controls.Add(v);
                }
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

        public void Convert_UC4_To_UC1()
        {
            this.flp_keyword.Controls.Clear();
            foreach (var item in list)
            {
                item.CategoryName = Category.Name;
                var v = new Keyword_UC1(item);
                v.Name = item.Id.ToString();
                // v.Tag = item;
                this.flp_keyword.Controls.Add(v);
            }
            var v1 = new Keyword_UC4("确定",true);
            v1.Tag = this;
            this.flp_keyword.Controls.Add(v1);
            var v2 = new Keyword_UC4("取消", false);
            v2.Tag = this;
            this.flp_keyword.Controls.Add(v2);

            (this.ParentForm as FrmMain).reCalcKeywordPanelHeight();
        }
        public void Convert_UC1_To_UC4()
        {
            this.flp_keyword.Controls.Clear();
            foreach (var item in list)
            {
                item.CategoryName = Category.Name;
                var v = new Keyword_UC4(item);
                v.Name = item.Id.ToString();
                // v.Tag = item;
                this.flp_keyword.Controls.Add(v);
            }
            //多选
            var add = new Keyword_UC7();
            add.ParentKeyword_UC2 = this;
            this.flp_keyword.Controls.Add(add);
            (this.ParentForm as FrmMain).reCalcKeywordPanelHeight();
        }
        public void Filter()
        {
            foreach (UserControl item in this.flp_keyword.Controls)
            {
                if(item is Keyword_UC1)
                {
                    var v = item as Keyword_UC1;
                    if(v.Checked)
                    {
                        if (v.Tag is SRRC_BiaoJiKeywordEntity)
                        {
                            SROperation2.Instance.BiaoJiKeywordFilterList.Add(v.Tag as SRRC_BiaoJiKeywordEntity);
                        }
                    }
                }
            }
            (this.ParentForm as FrmMain).Keyword_UC6Refresh();
        }
    }
}
