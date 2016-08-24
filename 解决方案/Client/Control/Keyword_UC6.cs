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
    public partial class Keyword_UC6 : UserControl
    {
        public Keyword_UC6()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            //常驻关键字
            var list = DataBase.Instance.tSRRC_BiaoJiKeyword.Get_EntityCollection(
                new ORM.OrderCollection<SRRC_BiaoJiKeywordEntity.FiledType>() { new ORM.Order<SRRC_BiaoJiKeywordEntity.FiledType>(SRRC_BiaoJiKeywordEntity.FiledType.OrderBy, ORM.OrderType.Asc) },
                " biaojiid=0");
            this.flb_resident.Controls.Clear();
            if (list != null && list.Count > 0)
            {
                var category = list.Find(l => l.Pid == 0);
                foreach (var item in list.Where(l=>l.Pid == category.Id))
                {
                    var control = new Keyword_UC1(item.Name, true);
                    control.Tag = item;                    
                    this.flb_resident.Controls.Add(control);
                }                
            }
            //私有关键字
            this.keyword_UC31.BindData(true);
            //筛选结果
            //null
            this.flp_filter.Controls.Clear();
        }
        public void SetBiaoJiKeywordStatus(List<SRRC_ResourceEntity> list)
        {

        }
        public int AdjustHeight_flb_resident()
        {
            if (this.flb_resident.Controls.Count == 0)
            {
                this.flb_resident.Height = 0;
                this.flb_resident.Margin = new Padding(1);
                return 0;
            }
            else
            {
                var w = 0;
                var h = 0;
                foreach (UserControl item in this.flb_resident.Controls)
                {
                    var ww = item.Width + item.Margin.Left + item.Margin.Right;
                    w += ww;
                    if (w > this.flb_resident.Width)
                    {
                        w = ww;
                        h++;
                    }
                }
                var controls = this.flb_resident.Controls[0];
                this.flb_resident.Height = (h + 1) * (controls.Height + controls.Margin.Top + controls.Margin.Bottom);
                return this.flb_resident.Height + this.flb_resident.Margin.Top + this.flb_resident.Margin.Bottom;
            }
        }
        public int AdjustHeight_flb_filter()
        {
            if (this.flp_filter.Controls.Count == 0)
            {
                this.flp_filter.Height = 0;
                this.flp_filter.Margin = new Padding(0);
                return 0;
            }else
            {
                var w = 0;
                var h = 0;
                foreach (UserControl item in this.flp_filter.Controls)
                {
                    var ww = item.Width + item.Margin.Left + item.Margin.Right;
                    w += ww;
                    if (w > this.flp_filter.Width)
                    {
                        w = ww;
                        h++;
                    }
                }
                var controls = this.flp_filter.Controls[0];
                this.flp_filter.Height = (h + 1) * (controls.Height + controls.Margin.Top + controls.Margin.Bottom);
                return this.flp_filter.Height + this.flp_filter.Margin.Top + this.flp_filter.Margin.Bottom;
            }
            
        }
        public int AdjustHeight_Keyword_UC31()
        {
            this.keyword_UC31.Height = this.keyword_UC31.AdjustHeight();
            return this.keyword_UC31.Height + this.keyword_UC31.Margin.Top + this.keyword_UC31.Margin.Bottom;
        }
        public int AdjustHeight()
        {
            //return 100;
            return this.AdjustHeight_flb_filter() + this.AdjustHeight_flb_resident() + this.AdjustHeight_Keyword_UC31();
        }
        /// <summary>
        /// 刷新控件
        /// </summary>
        public void UC_6_Refresh()
        {
            //设置筛选结果
            this.flp_filter.Controls.Clear();
            var group = SROperation2.Instance.BiaoJiKeywordFilterList.GroupBy(i => i.CategoryName);
            foreach (var item in group)
            {
                if (String.IsNullOrEmpty(item.Key)) continue;
                var v = new Keyword_UC5(item.Key, item.ToList());
                this.flp_filter.Controls.Add(v);
            }

            //刷新私有关键字
            this.keyword_UC31.Keyword_UC3_Refresh();
        }
    }
}
