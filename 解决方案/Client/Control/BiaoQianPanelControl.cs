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
    public partial class BiaoQianPanelControl : UserControl
    {
        private List<SRRC_ResourcebiaojirelEntity> rbList { get; set; }
        public BiaoQianPanelControl()
        {
            InitializeComponent();
        }
        public void BindData()
        {
            this.Controls.Clear();
            var list = DataBase.Instance.tSRRC_BiaoJiKeyword.Get_EntityCollection(
                new ORM.OrderCollection<SRRC_BiaoJiKeywordEntity.FiledType>() { new ORM.Order<SRRC_BiaoJiKeywordEntity.FiledType>(SRRC_BiaoJiKeywordEntity.FiledType.OrderBy, ORM.OrderType.Asc) },
                " biaojiid=[$biaojiid$]", new ORM.DataParameter("biaojiid", SROperation2.Instance.StudySelectedId));
            rbList = DataBase.Instance.tSRRC_Resourcebiaojirel.Get_EntityCollection(null, " biaoji_id=[$biaojiid$]", new ORM.DataParameter("biaojiid", SROperation2.Instance.StudySelectedId));
            if(list != null && list.Count > 0)
            {
                var categories = list.Where(l => l.Pid == 0);
                foreach (var item in categories)
                {
                    var control = new BiaoQianControl(item.Name, list.Where(l => l.Pid == item.Id));
                    control.Margin = new Padding(1);
                    control.Dock = DockStyle.Top;
                    this.Controls.Add(control);
                }
            }
        }
        public void SetBiaoJiKeywordStatus(List<SRRC_ResourceEntity> list)
        {
            var v = from i in list
                    join r in rbList on i.Id equals r.Resource_id
                    select r;
            List<long> BiaoJiKeywordIdList = new List<long>();

            if (v.Count() > 0)
            {
                var v1 = DataBase.Instance.tSRRC_ResourceBiaoJiRel_BiaoJiKeyword.Get_EntityCollection(null, string.Format("ResourceBiaoJiRelId in ({0})", string.Join(",", v.Select(i => i.Id))));
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
            }
            

            foreach (var item in this.Controls)
            {
                if (item is BiaoQianControl)
                {
                    var v2 = item as BiaoQianControl;
                    v2.SetBiaoJiKeywordStatus(BiaoJiKeywordIdList);
                }
            }

        }
    }
}
