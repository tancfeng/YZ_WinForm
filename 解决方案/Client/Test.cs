using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ManageSystem.Library.Client;
using System.Data.OleDb;
using System.Data;
using System.IO;
using SirdRoom.Common;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();

            this.right1.BindData();

            //List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, "  (Dtype=1 or Dtype=2) ");

            //List<SRRC_ResourceEntity> entList2 = new List<SRRC_ResourceEntity>();
            //if (entList != null)
            //    for (int i = 0; i < 5; i++)
            //    {
            //        entList2.AddRange(entList);
            //    }

            //this.center21.SetData(entList2); 

            this.treeView2.ExpandAll();

            //this.pictureBox1.Image = Image.FromFile(Param.CrrentPath + "\\Images\\001 (2).png");

            //List<ListItem> itemList = new List<ListItem>();
            //itemList.Add(new ListItem() { Text= "1", Value= "1" });
            //itemList.Add(new ListItem() { Text = "2", Value = "2" });
            //itemList.Add(new ListItem() { Text = "3", Value = "3" });
            //itemList.Add(new ListItem() { Text = "浪费顺枯顶ffffffffffffff替夺顶替遥顶替", Value = "4" });
            //itemList.Add(new ListItem() { Text = "5", Value = "5" });

            //this.radioButtonList1.DataSource = itemList;
            //this.radioButtonList1.DataBind();

            //this.radioButtonList1.SelectedValue = "5";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.pictureBox1.Image = System.Drawing.Image.FromFile(@"C:\Users\SQ\Documents\D1_Right_2.jpg");

            //new SRFMessageBox(this.radioButtonList1.SelectedValue.ToString());
        }

        private void treeView2_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            e.Effect = DragDropEffects.Copy;
            Point pt = treeView2.PointToClient(new Point(e.X, e.Y));
            TreeNode itemUnder = treeView2.GetNodeAt(pt.X, pt.Y);
            this.treeView2.SelectedNode = itemUnder;
        }

        private void treeView2_DragDrop(object sender, DragEventArgs e)
        {
            // Can only drop files, so check
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            switch (e.Effect)
            {
                case DragDropEffects.Copy:
                    MessageBox.Show("Copy");
                    break;
                case DragDropEffects.Move:
                    break;
                case DragDropEffects.Link:		// TODO: Need to handle links
                    break;
            }
        }




    }
}
