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
        private int BiaoQianId { get; set; }
        public KeywordManager()
        {
            InitializeComponent();
            this.BiaoQianId = SROperation2.Instance.StudySelectedId;
            BindData();
        }
        /// <summary>
        /// 主要用于常驻关键字，设置biaoQianId==0,为常驻关键字
        /// </summary>
        /// <param name="biaoQianId"></param>
        public KeywordManager(int biaoQianId)
        {
            InitializeComponent();
            this.BiaoQianId = biaoQianId;
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
                }, " Pid=0 and BiaoJiId=[$Id$]", new ORM.DataParameter("Id", this.BiaoQianId)
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
                BiaoJiId = this.BiaoQianId,
                Name = str,
                Pid = 0,
                //OrderBy = this.listBox_Category.Items.Count
            };
            entity.OrderBy = DataBase.Instance.tSRRC_BiaoJiKeyword.AddWithoutOrderBy(entity);
            RefreshCategory();
        }

        private void btn_KeywordAdd_Click(object sender, EventArgs e)
        {
            if (this.listBox_Category.SelectedItem == null) return;
            string str = Interaction.InputBox("请输入新关键字", "关键字管理");
            var entity = new SRRC_BiaoJiKeywordEntity
            {
                BiaoJiId = this.BiaoQianId,
                Name = str,
                Pid = (this.listBox_Category.SelectedItem as SRRC_BiaoJiKeywordEntity).Id,
                //OrderBy = this.listBox_Keyword.Items.Count
            };
            entity.OrderBy =   DataBase.Instance.tSRRC_BiaoJiKeyword.AddWithoutOrderBy(entity);
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
            DataBase.Instance.tSRRC_BiaoJiKeyword.DeleteCascade(item.Id);
            this.listBox_Category.Items.Remove(item);
        }

        private void btn_KeywordDel_Click(object sender, EventArgs e)
        {
            if (this.listBox_Keyword.SelectedItem == null) return;
            var item = this.listBox_Keyword.SelectedItem as SRRC_BiaoJiKeywordEntity;
            DataBase.Instance.tSRRC_BiaoJiKeyword.Delete(item.Id);
            this.listBox_Keyword.Items.Remove(item);
        }

        private void btn_CategoryEdit_Click(object sender, EventArgs e)
        {
            if (this.listBox_Category.SelectedItem == null) return;
            var item = this.listBox_Category.SelectedItem as SRRC_BiaoJiKeywordEntity;
            string text = Interaction.InputBox("请输入新分类名", "关键字管理", item.Name);
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("不能为空");
                return;
            }
            item.Name = text;
            DataBase.Instance.tSRRC_BiaoJiKeyword.Update(item);
            var index = this.listBox_Category.Items.IndexOf(item);
            this.listBox_Category.Items[index] = item;
        }

        private void btn_KeywordEdit_Click(object sender, EventArgs e)
        {
            if (this.listBox_Keyword.SelectedItem == null) return;
            var item = this.listBox_Keyword.SelectedItem as SRRC_BiaoJiKeywordEntity;
            string text = Interaction.InputBox("请输入新关键字名", "关键字管理", item.Name);
            if (string.IsNullOrEmpty(text))
            {
                MessageBox.Show("不能为空");
                return;
            }
            item.Name = text;
            DataBase.Instance.tSRRC_BiaoJiKeyword.Update(item);
            var index = this.listBox_Keyword.Items.IndexOf(item);
            this.listBox_Keyword.Items[index] = item;
        }

        private void btn_CategoryUp_Click(object sender, EventArgs e)
        {
            if (this.listBox_Category.SelectedItem == null) return;
            var item = this.listBox_Category.SelectedItem as SRRC_BiaoJiKeywordEntity;
            var index = this.listBox_Category.Items.IndexOf(item);
            if(index != 0)
            {
                var v = this.listBox_Category.Items[index - 1];
                var itemOrder = item.OrderBy;
                var newV = (v as SRRC_BiaoJiKeywordEntity);
                item.OrderBy = newV.OrderBy;
                newV.OrderBy = itemOrder;
                this.listBox_Category.Items[index] = item;
                this.listBox_Category.Items.Remove(v);
                this.listBox_Category.Items.Insert(index, newV);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(item);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(newV);
            }
        }

        private void btn_CategoryDown_Click(object sender, EventArgs e)
        {
            if (this.listBox_Category.SelectedItem == null) return;
            var item = this.listBox_Category.SelectedItem as SRRC_BiaoJiKeywordEntity;
            var index = this.listBox_Category.Items.IndexOf(item);
            if (index != this.listBox_Category.Items.Count - 1)
            {
                var v = this.listBox_Category.Items[index + 1];
                var itemOrder = item.OrderBy;
                var newV = (v as SRRC_BiaoJiKeywordEntity);
                item.OrderBy = newV.OrderBy;
                newV.OrderBy = itemOrder;
                this.listBox_Category.Items[index] = item;
                this.listBox_Category.Items.Remove(v);
                this.listBox_Category.Items.Insert(index, newV);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(item);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(newV);
            }
        }

        private void btn_KeywordUp_Click(object sender, EventArgs e)
        {
            if (this.listBox_Keyword.SelectedItem == null) return;
            var item = this.listBox_Keyword.SelectedItem as SRRC_BiaoJiKeywordEntity;
            var index = this.listBox_Keyword.Items.IndexOf(item);
            if(index != 0)
            {
                var v = this.listBox_Keyword.Items[index - 1];
                var itemOrder = item.OrderBy;
                var newV = (v as SRRC_BiaoJiKeywordEntity);
                item.OrderBy = newV.OrderBy;
                newV.OrderBy = itemOrder;
                this.listBox_Keyword.Items[index] = item;
                this.listBox_Keyword.Items.Remove(v);
                this.listBox_Keyword.Items.Insert(index, newV);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(item);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(newV);
            }
        }

        private void btn_KeywordDown_Click(object sender, EventArgs e)
        {
            if (this.listBox_Keyword.SelectedItem == null) return;
            var item = this.listBox_Keyword.SelectedItem as SRRC_BiaoJiKeywordEntity;
            var index = this.listBox_Keyword.Items.IndexOf(item);
            if (index != this.listBox_Keyword.Items.Count - 1)
            {
                var v = this.listBox_Keyword.Items[index + 1];
                var itemOrder = item.OrderBy;
                var newV = (v as SRRC_BiaoJiKeywordEntity);
                item.OrderBy = newV.OrderBy;
                newV.OrderBy = itemOrder;
                this.listBox_Keyword.Items[index] = item;
                this.listBox_Keyword.Items.Remove(v);
                this.listBox_Keyword.Items.Insert(index, newV);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(item);
                DataBase.Instance.tSRRC_BiaoJiKeyword.Update(newV);
            }
        }
    }
}
