using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    public partial class KeywordManager : UserControl
    {
        private int CategoryId { get; set; }
        public KeywordManager()
        {
            InitializeComponent();
            BindData();
        }

        private void BindData()
        {
            RefreshCategory();
            RefreshKeyword();
        }
        private void RefreshCategory()
        {
            //category
            this.listBox_Category.Items.Clear();
            var list = DataBase.Instance.tSRRC_BiaoJiKeyword.Get_EntityCollection(
                new ORM.OrderCollection<SRRC_BiaoJiKeywordEntity.FiledType>()
                {
                    new ORM.Order<SRRC_BiaoJiKeywordEntity.FiledType>(SRRC_BiaoJiKeywordEntity.FiledType.OrderBy,ORM.OrderType.Asc)
                }, " Pid=0 and BiaoJiId=[$Id$]", new ORM.DataParameter("Id", SROperation2.Instance.StudySelectedId)
                );
            if (list == null) return;
            foreach (var item in list)
            {
                this.listBox_Category.Items.Add(item);
            }
        }
        private void RefreshKeyword()
        {
            this.listBox_Keyword.Items.Clear();
            if(this.listBox_Category.SelectedItem != null)
            {
                var list = DataBase.Instance.tSRRC_BiaoJiKeyword.Get_EntityCollection(
                new ORM.OrderCollection<SRRC_BiaoJiKeywordEntity.FiledType>()
                {
                    new ORM.Order<SRRC_BiaoJiKeywordEntity.FiledType>(SRRC_BiaoJiKeywordEntity.FiledType.OrderBy,ORM.OrderType.Asc)
                }, " Pid=[$Pid$]"
                , new ORM.DataParameter("Pid", (this.listBox_Category.SelectedItem as SRRC_BiaoJiKeywordEntity).Id)
                );
                if (list == null) return;
                foreach (var item in list)
                {
                    this.listBox_Keyword.Items.Add(item);
                }
            }         
        }
        private void btn_CategoryAdd_Click(object sender, EventArgs e)
        {
            string str = Interaction.InputBox("请输入新关键字类名", "关键字管理");

            var entity = new SRRC_BiaoJiKeywordEntity
            {
                BiaoJiId = SROperation2.Instance.StudySelectedId,
                Name = str,
                Pid = 0,
                OrderBy = this.listBox_Category.Items.Count
            };
            DataBase.Instance.tSRRC_BiaoJiKeyword.Add(entity);
            RefreshCategory();
        }

        private void btn_KeywordAdd_Click(object sender, EventArgs e)
        {
            if (this.listBox_Category.SelectedItem == null) return;
            string str = Interaction.InputBox("请输入新关键字", "关键字管理");
            var entity = new SRRC_BiaoJiKeywordEntity
            {
                BiaoJiId = SROperation2.Instance.StudySelectedId,
                Name = str,
                Pid = (this.listBox_Category.SelectedItem as SRRC_BiaoJiKeywordEntity).Id,
                OrderBy = this.listBox_Keyword.Items.Count
            };
            DataBase.Instance.tSRRC_BiaoJiKeyword.Add(entity);
            RefreshKeyword();
        }

        private void listBox_Category_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshKeyword();
        }

        private void btn_CategoryDel_Click(object sender, EventArgs e)
        {
            if (this.listBox_Category.SelectedItem == null) return;
            var item = this.listBox_Category.SelectedItem as SRRC_BiaoJiKeywordEntity;
            DataBase.Instance.tSRRC_BiaoJiKeyword.Delete(item.Id);
            this.listBox_Category.Items.Remove(item);
        }

        private void btn_KeywordDel_Click(object sender, EventArgs e)
        {
            if (this.listBox_Keyword.SelectedItem == null) return;
            var item = this.listBox_Keyword.SelectedItem as SRRC_BiaoJiKeywordEntity;
            DataBase.Instance.tSRRC_BiaoJiKeyword.Delete(item.Id);
            this.listBox_Keyword.Items.Remove(item);
        }
    }
}
