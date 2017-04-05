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
    /// 关键字筛选
    /// </summary>
    public partial class Keyword_UC4 : UserControl
    {
        private bool IsOk { get; set; }
        public Keyword_UC4()
        {
            InitializeComponent();
        }
        public Keyword_UC4(SRRC_BiaoJiKeywordEntity entity) : this()
        {
            this.UC_Text.Text = entity.Name;
            this.Tag = entity;
        }
        public Keyword_UC4(string text, bool isOk = false) : this()
        {
            this.UC_Text.Text = text;
            this.UC_Text.ForeColor = Color.Red;
            this.IsOk = isOk;
        }
        private void UC_Text_Click(object sender, EventArgs e)
        {
            if (this.Tag is Keyword_UC2)//确定或取消
            {
                if (this.IsOk)
                {
                    (this.Tag as Keyword_UC2).Filter();
                }
                    (this.Tag as Keyword_UC2).Convert_UC1_To_UC4();
            }
            if (this.Tag is SRRC_BiaoJiKeywordEntity)
            {
                SROperation2.Instance.BiaoJiKeywordFilterList.Add(this.Tag as SRRC_BiaoJiKeywordEntity);
                (this.ParentForm as FrmMain).Keyword_UC6Refresh();
            }
        }
    }
}
