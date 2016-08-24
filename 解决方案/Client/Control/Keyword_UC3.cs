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
    /// 关键字设置面板
    /// </summary>
    public partial class Keyword_UC3 : UserControl
    {
        private List<SRRC_ResourcebiaojirelEntity> rbList { get; set; }
        public Keyword_UC3()
        {
            InitializeComponent();
        }
        public void BindData(bool isFilter=false)
        {
            this.Controls.Clear();
            if(isFilter)
            {
                //私有关键字
               var list = DataBase.Instance.tSRRC_BiaoJiKeyword.Get_EntityCollection(
                    new ORM.OrderCollection<SRRC_BiaoJiKeywordEntity.FiledType>() { new ORM.Order<SRRC_BiaoJiKeywordEntity.FiledType>(SRRC_BiaoJiKeywordEntity.FiledType.OrderBy, ORM.OrderType.Asc) },
                    " biaojiid=[$biaojiid$]", new ORM.DataParameter("biaojiid", SROperation2.Instance.StudySelectedId));
                rbList = DataBase.Instance.tSRRC_Resourcebiaojirel.Get_EntityCollection(null, " biaoji_id=[$biaojiid$]", new ORM.DataParameter("biaojiid", SROperation2.Instance.StudySelectedId));
                if (list != null && list.Count > 0)
                {
                    var categories = list.Where(l => l.Pid == 0).OrderByDescending(l => l.OrderBy);
                    foreach (var item in categories)
                    {
                        var control = new Keyword_UC2(item, list.Where(l => l.Pid == item.Id), true);
                        control.Margin = new Padding(1);
                        control.Dock = DockStyle.Top;
                        this.Controls.Add(control);
                    }                 
                }
            }
            else
            {
                //常驻关键字
                var list = DataBase.Instance.tSRRC_BiaoJiKeyword.Get_EntityCollection(
                    new ORM.OrderCollection<SRRC_BiaoJiKeywordEntity.FiledType>() { new ORM.Order<SRRC_BiaoJiKeywordEntity.FiledType>(SRRC_BiaoJiKeywordEntity.FiledType.OrderBy, ORM.OrderType.Asc) },
                    " biaojiid=0");
                if (list != null && list.Count > 0)
                {
                    var category = list.Find(l => l.Pid == 0);
                    var control = new Keyword_UC2(category, list.Where(l => l.Pid == category.Id));
                    control.Margin = new Padding(1);
                    control.Dock = DockStyle.Top;
                    this.Controls.Add(control);
                }
                //私有关键字
                list = DataBase.Instance.tSRRC_BiaoJiKeyword.Get_EntityCollection(
                    new ORM.OrderCollection<SRRC_BiaoJiKeywordEntity.FiledType>() { new ORM.Order<SRRC_BiaoJiKeywordEntity.FiledType>(SRRC_BiaoJiKeywordEntity.FiledType.OrderBy, ORM.OrderType.Asc) },
                    " biaojiid=[$biaojiid$]", new ORM.DataParameter("biaojiid", SROperation2.Instance.StudySelectedId));
                rbList = DataBase.Instance.tSRRC_Resourcebiaojirel.Get_EntityCollection(null, " biaoji_id=[$biaojiid$]", new ORM.DataParameter("biaojiid", SROperation2.Instance.StudySelectedId));
                if (list != null && list.Count > 0)
                {
                    var categories = list.Where(l => l.Pid == 0).OrderByDescending(l => l.OrderBy);
                    foreach (var item in categories)
                    {
                        var control = new Keyword_UC2(item, list.Where(l => l.Pid == item.Id));
                        control.Margin = new Padding(1);
                        control.Dock = DockStyle.Top;
                        this.Controls.Add(control);
                    }
                }
            }            
        }
        public void SetBiaoJiKeywordStatus(List<SRRC_ResourceEntity> list)
        {
            var v = from i in list
                    join r in rbList on i.Id equals r.Resource_id
                    select r;

            var v1 = DataBase.Instance.tSRRC_ResourceBiaoJiRel_BiaoJiKeyword.Get_EntityCollection(null, string.Format("ResourceBiaoJiRelId in ({0})", string.Join(",", v.Select(i => i.Id))));
            List<long> BiaoJiKeywordIdList = new List<long>();
            if (v1 != null && v1.Count > 0)
            {
                foreach (var item in v1.GroupBy(i => i.BiaoJiKeywordId))
                {
                    if (item.Count() == list.Count)
                    {
                        BiaoJiKeywordIdList.Add(item.Key);
                    }
                }
            }

            foreach (var item in this.Controls)
            {
                if (item is Keyword_UC2)
                {
                    var v2 = item as Keyword_UC2;
                    v2.SetBiaoJiKeywordStatus(BiaoJiKeywordIdList);
                }
            }

        }
        public int AdjustHeight()
        {
            var h = 0;
            foreach (Keyword_UC2 item in this.Controls)
            {
                if(!item.Visible)
                {
                    item.Height = 0;
                    continue;
                }
                    item.Height = item.AdjustHeight();
                    h += item.Height + item.Margin.Top + item.Margin.Bottom;
            }
            return h;
        }
        public void Keyword_UC3_Refresh()
        {
          var v =  SROperation2.Instance.BiaoJiKeywordFilterList.Select(l => l.Pid);
            foreach (UserControl item in this.Controls)
            {
                item.Visible = true;
                if(v.Contains(Convert.ToInt32(item.Name)))
                {
                    item.Visible = false;
                }
            }
        }
    }
}
