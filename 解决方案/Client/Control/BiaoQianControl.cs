using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace SirdRoom.ManageSystem.ClientApplication.Control
{

    public partial class BiaoQianControl : UserControl
    {
        private IEnumerable<SRRC_BiaoJiKeywordEntity> list { get; set; }
        public BiaoQianControl()
        {
            InitializeComponent();
        }
        public BiaoQianControl(string category,IEnumerable<SRRC_BiaoJiKeywordEntity> list):this()
        {
            this.label1.Text = category;
            foreach (var item in list)
            {
                var lvi = new ListViewItem();
                lvi.Name = item.Id.ToString();
                lvi.Text = item.Name;
                lvi.Tag = item;
                this.listView1.Items.Add(lvi);                
            }
        }
        public void SetBiaoJiKeywordStatus(List<long> list)
        {
            foreach (ListViewItem item in this.listView1.Items)
            {
                if(list.Exists(l=>l.ToString() == item.Name))
                {
                    item.Checked = true;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void listView1_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var v = sender as ListView;
            if(v.Focused && SROperation2.Instance.PicSelected.Count > 0)
            {
                var id = Convert.ToInt32(e.Item.Name);
                //SROperation2.Instance.PicSelected
                var delSql = string.Format(@" delete from dbo.SRRC_ResourceBiaoJiRel_BiaoJiKeyword  
  where BiaoJiKeywordId = {0} and ResourceBiaoJiRelId in 
  (select Id from dbo.SRRC_Resourcebiaojirel
  where Resource_id in ({2}) and Biaoji_id = {1});", id, SROperation2.Instance.StudySelectedId, string.Join(",", SROperation2.Instance.PicSelected.Select(i => i.Id)));
                var insertSql = string.Format(@"insert into dbo.SRRC_ResourceBiaoJiRel_BiaoJiKeyword
                select {0},Id from dbo.SRRC_Resourcebiaojirel
                where Resource_id in ({2}) and Biaoji_id = {1}; ", id, SROperation2.Instance.StudySelectedId, string.Join(",", SROperation2.Instance.PicSelected.Select(i => i.Id)));
                var helper = SirdRoom.ManageSystem.Library.Data.DataBaseHelper.Instance.Helper;
                if (e.Item.Checked)
                {
                    //add
                    helper.ExecuteNonQuery(CommandType.Text, delSql + insertSql);
                }
                else
                {
                    //remove
                    helper.ExecuteNonQuery(CommandType.Text, delSql);
                }
            }
        }
    }
}
