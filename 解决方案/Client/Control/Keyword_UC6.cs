using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ManageSystem.Library.Data;

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
            this.flb_resident.Controls.Clear();
            if(SROperation2.Instance.StudySelectedId > 0)
            {
                var sql = @"  select tb.*
                          from (
                          select distinct BiaoJiKeywordId from [dbo].[SRRC_ResourceBiaoJiRel_BiaoJiKeyword]
                          where [ResourceBiaoJiRelId] in 
                          (select Id FROM [dbo].[SRRC_Resourcebiaojirel] WHERE Biaoji_id=[$biaoJiId$])) as ta
                          inner join [dbo].[SRRC_BiaoJiKeyword] as tb on ta.BiaoJiKeywordId=tb.Id and tb.BiaoJiId=0";
                var v = DataBaseHelper.Instance.Helper.ExecuteQuery(CommandType.Text, sql, new ORM.DataParameter("biaoJiId", SROperation2.Instance.StudySelectedId));
                if (v.Rows.Count > 0)
                {
                    var list = new List<SRRC_BiaoJiKeywordEntity>();
                    foreach (DataRow dr in v.Rows)
                    {
                        list.Add(DataBase.Instance.tSRRC_BiaoJiKeyword.Populate_Entity_FromDr(dr));
                    }
                    foreach (var item in list)
                    {
                        var control = new Keyword_UC1(item.Name, true);
                        control.Tag = item;
                        this.flb_resident.Controls.Add(control);
                    }
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
                var controls = this.flb_resident.Controls[0];
                foreach (UserControl item in this.flb_resident.Controls)
                {
                    if (!item.Visible) continue;
                    controls = item;
                    var ww = item.Width + item.Margin.Left + item.Margin.Right;
                    w += ww;
                    if (w > this.flb_resident.Width)
                    {
                        w = ww;
                        h++;
                    }
                }
                if(w == 0)//不可见 
                {
                    this.flb_resident.Height = 0;
                    this.flb_resident.Margin = new Padding(1);
                    return 0;
                }
                
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
            //
            var list = new List<SRRC_ResourceBiaoJiRel_BiaoJiKeywordEntity>();
            if (SROperation2.Instance.Center1EntList.Count > 0)
            {
                var sql = string.Format(@"SELECT [Id],[BiaoJiKeywordId],[ResourceBiaoJiRelId]
                            FROM [dbo].[SRRC_ResourceBiaoJiRel_BiaoJiKeyword]
                            where ResourceBiaoJiRelId in (select Id from [dbo].[SRRC_Resourcebiaojirel]  where Biaoji_id={0} and Resource_id in ({1}))",
                            SROperation2.Instance.StudySelectedId, string.Join(",", SROperation2.Instance.Center1EntList.Select(l => l.Id)));
                var v = DataBaseHelper.Instance.Helper.ExecuteQuery(CommandType.Text, sql);
               
                if (v.Rows.Count > 0)
                {
                    foreach (DataRow dr in v.Rows)
                    {
                        list.Add(DataBase.Instance.tSRRC_ResourceBiaoJiRel_BiaoJiKeyword.Populate_Entity_FromDr(dr));
                    }
                }
            }
            //刷新私有关键字
            this.keyword_UC31.Keyword_UC3_Refresh(list);
            //刷新常驻关键字

            foreach (UserControl item in this.flb_resident.Controls)
            {
                item.Visible = false;
            }            
            if(list.Count > 0)
            {
                foreach(UserControl item in this.flb_resident.Controls)
                {
                    var v = item.Tag as SRRC_BiaoJiKeywordEntity;
                    if(list.Exists(l=>l.BiaoJiKeywordId == v.Id))
                    {
                        item.Visible = true;
                    }
                }
            }
        }
    }
}
