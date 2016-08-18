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
    public partial class Keyword_UC1 : UserControl
    {
        public Keyword_UC1()
        {
            InitializeComponent();
        }
        public Keyword_UC1(string text, bool isChecked) : this()
        {
            this.UC_Text.Text = text;
            this.CheckStatusChange(isChecked);
        }
        public Keyword_UC1(string text) : this(text, false)
        {

        }
        public void CheckStatusChange(bool isChecked)
        {
            if (isChecked)
            {
                this.IsChecked.Visible = true;
                this.IsUnchecked.Visible = false;
            }
            else
            {
                this.IsUnchecked.Visible = true;
                this.IsChecked.Visible = false;
            }
        }

        private void IsChecked_Click(object sender, EventArgs e)
        {
            if (SROperation2.Instance.PicSelected.Count > 0)
            {
                var id = Convert.ToInt32(this.Name);
                //SROperation2.Instance.PicSelected
                var delSql = string.Format(@" delete from dbo.SRRC_ResourceBiaoJiRel_BiaoJiKeyword  
  where BiaoJiKeywordId = {0} and ResourceBiaoJiRelId in 
  (select Id from dbo.SRRC_Resourcebiaojirel
  where Resource_id in ({2}) and Biaoji_id = {1});", id, SROperation2.Instance.StudySelectedId, string.Join(",", SROperation2.Instance.PicSelected.Select(i => i.Id)));
                var helper = SirdRoom.ManageSystem.Library.Data.DataBaseHelper.Instance.Helper;
                if (helper.ExecuteNonQuery(CommandType.Text, delSql) > 0)
                {
                    this.CheckStatusChange(false);
                }
            }

        }

        private void IsUnchecked_Click(object sender, EventArgs e)
        {
            if (SROperation2.Instance.PicSelected.Count > 0)
            {
                var id = Convert.ToInt32(this.Name);
                //SROperation2.Instance.PicSelected
                var delSql = string.Format(@" delete from dbo.SRRC_ResourceBiaoJiRel_BiaoJiKeyword  
  where BiaoJiKeywordId = {0} and ResourceBiaoJiRelId in 
  (select Id from dbo.SRRC_Resourcebiaojirel
  where Resource_id in ({2}) and Biaoji_id = {1});", id, SROperation2.Instance.StudySelectedId, string.Join(",", SROperation2.Instance.PicSelected.Select(i => i.Id)));
                var insertSql = string.Format(@"insert into dbo.SRRC_ResourceBiaoJiRel_BiaoJiKeyword
                select {0},Id from dbo.SRRC_Resourcebiaojirel
                where Resource_id in ({2}) and Biaoji_id = {1}; ", id, SROperation2.Instance.StudySelectedId, string.Join(",", SROperation2.Instance.PicSelected.Select(i => i.Id)));
                var helper = SirdRoom.ManageSystem.Library.Data.DataBaseHelper.Instance.Helper;
                if (helper.ExecuteNonQuery(CommandType.Text, delSql + insertSql) > 0)
                {
                    this.CheckStatusChange(true);
                }

            }

        }
    }
}
