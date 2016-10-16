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
    /// 关键字设置（模拟checkbox）
    /// </summary>
    public partial class Keyword_UC1 : UserControl
    {
        private bool isResident { get; set; }//常驻关键字用
        private bool isFilter { get; set; }//私有关键字多选用
        public bool Checked { get; set; }
        public Keyword_UC1()
        {
            InitializeComponent();
            if(Param.GroupId == 1)
            {
                this.UC_Text.Cursor = Cursors.Hand;
                this.UC_Text.Click += UC_Text_Click;
            }
        }
        public Keyword_UC1(string text, bool isResident = false) : this()
        {
            this.UC_Text.Text = text;
            this.CheckStatusChange(false);
            this.isResident = isResident;
        }
        public Keyword_UC1(SRRC_BiaoJiKeywordEntity ent) : this()
        {
            this.UC_Text.Text = ent.Name;
            this.Tag = ent;
            this.CheckStatusChange(false);
            this.isFilter = true;
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
            if(isFilter)
            {
                this.Checked = false;
                this.CheckStatusChange(false);
            }
            else if (isResident)
            {
                if(this.Tag is SRRC_BiaoJiKeywordEntity)
                {
                    SROperation2.Instance.BiaoJiKeywordFilterList.RemoveAll(s => s.Name == this.UC_Text.Text);
                    this.CheckStatusChange(false);
                    //(this.ParentForm as FrmMain).Keyword_UC6Refresh(false);
                    (this.ParentForm as FrmMain).Keyword_UC6Refresh();
                }                
            }
            else
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

        }

        private void IsUnchecked_Click(object sender, EventArgs e)
        {
            if (isFilter)
            {
                this.Checked = true;
                this.CheckStatusChange(true);
            }
            else if (isResident)
            {
                SROperation2.Instance.BiaoJiKeywordFilterList.Add(this.Tag as SRRC_BiaoJiKeywordEntity);
                this.CheckStatusChange(true);
                //(this.ParentForm as FrmMain).Keyword_UC6Refresh(false);
                (this.ParentForm as FrmMain).Keyword_UC6Refresh();
            }
            else
            {
                if (SROperation2.Instance.PicSelected != null && SROperation2.Instance.PicSelected.Count > 0)
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

        private void UC_Text_Click(object sender, EventArgs e)
        {
            if(this.UC_Text.ForeColor == Color.Silver)
            {
                this.UC_Text.ForeColor = Color.Red;
                SROperation2.Instance.BiaoJiKeywordFilterList.Add(this.Tag as SRRC_BiaoJiKeywordEntity);
            }
            else
            {
                this.UC_Text.ForeColor = Color.Silver;
                SROperation2.Instance.BiaoJiKeywordFilterList.Remove(this.Tag as SRRC_BiaoJiKeywordEntity);
            }
            (this.ParentForm as FrmMain).Keyword_UC6Refresh(false);
        }
    }
}
