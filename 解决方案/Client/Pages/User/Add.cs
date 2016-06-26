using SirdRoom.ManageSystem.Library.Data;
using SirdRoom.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication.Pages.User
{
    public partial class Add : UserControl
    {
        Int32 id = 0;
        public Add()
        {
            InitializeComponent();
            id = SRLibFun.StringConvertToInt32(Param.DPageParameter);

            List<SR_WordbookEntity> allPurviewEntList = DataBase.Instance.tSR_Wordbook.Get_EntityCollection(null, " Dtype=[$Dtype$] ", new DataParameter("Dtype", "用户权限"));
            //List<SR_WordbookEntity> myEntList = DataBase.Instance.tSR_Wordbook.Get_EntityCollection(null, " Ordernumber=[$Ordernumber$] and Dtype=[$Dtype$] ", new DataParameter("Ordernumber", id), new DataParameter("Dtype", "my用户权限"));
            if (allPurviewEntList == null) allPurviewEntList = new List<SR_WordbookEntity>();
            //if (myEntList == null) myEntList = new List<SR_WordbookEntity>();
            //List<SR_WordbookEntity> treeviewEntList = new List<SR_WordbookEntity>();

            this.BindData();
        }

        void BindData()
        {
            if (id > 0)
            {
                SR_UserEntity userEnt = DataBase.Instance.tSR_User.Get_Entity(id);
                this.textBox1.Text = userEnt.Loginname;
                this.textBox2.Text = userEnt.Pwd;
                switch (userEnt.Groupid)
                {
                    case 1: this.radioButton1.Checked = true;
                        break;
                    case 2: this.radioButton2.Checked = true;
                        break;
                    case 3: this.radioButton3.Checked = true;
                        break;
                    case 4: this.radioButton4.Checked = true;
                        break;
                    default:
                        break;
                }

            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetNodeCheckStatus(e.Node, e.Node.Checked);
                SetNodeStyle(e.Node);
            }
        }

        private void SetNodeCheckStatus(TreeNode tn, bool Checked)
        {

            if (tn == null) return;
            foreach (TreeNode tnChild in tn.Nodes)
            {

                tnChild.Checked = Checked;

                SetNodeCheckStatus(tnChild, Checked);

            }
            TreeNode tnParent = tn;
        }


        private void SetNodeStyle(TreeNode Node)
        {
            int nNodeCount = 0;
            if (Node.Nodes.Count != 0)
            {
                foreach (TreeNode tnTemp in Node.Nodes)
                {

                    if (tnTemp.Checked == true)

                        nNodeCount++;
                }

                if (nNodeCount == Node.Nodes.Count)
                {
                    Node.Checked = true;
                    //Node.ExpandAll();
                    Node.ForeColor = Color.Black;
                }
                else if (nNodeCount == 0)
                {
                    Node.Checked = false;
                    //Node.Collapse();
                    Node.ForeColor = Color.Black;
                }
                else
                {
                    Node.Checked = true;
                    Node.ForeColor = Color.Gray;
                }
            }
            //当前节点选择完后，判断父节点的状态，调用此方法递归。  
            if (Node.Parent != null)
                SetNodeStyle(Node.Parent);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.textBox1.Text) == true)
            {
                new SRFMessageBox("用户名不能为空！", "提示", MessageBoxButtons.OK).ShowDialog();
                return;
            }
            if (this.textBox2.Text.Length == 0)
            {
                new SRFMessageBox("密码不能为空！", "提示", MessageBoxButtons.OK).ShowDialog();
                return;
            }
            id = SRLibFun.StringConvertToInt32(Param.DPageParameter);
            if (DataBase.Instance.tSR_User.Get_Entity(" Loginname=[$Loginname$] and Id !=[$Id$] ", new DataParameter("Loginname", this.textBox1.Text), new DataParameter("Id", id)) != null)
            {
                new SRFMessageBox("用户名已经被使用，请输入其它用户名！", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }
            if (id > 0)
            {
                SR_UserEntity userEnt = DataBase.Instance.tSR_User.Get_Entity(id);
                userEnt.Loginname = this.textBox1.Text;
                userEnt.Pwd = this.textBox2.Text;
                if (this.radioButton1.Checked == true)
                    userEnt.Groupid = 1;
                else if (this.radioButton2.Checked == true)
                    userEnt.Groupid = 2;
                else if (this.radioButton3.Checked == true)
                    userEnt.Groupid = 3;
                else if (this.radioButton4.Checked == true)
                    userEnt.Groupid = 4;
                DataBase.Instance.tSR_User.Update(userEnt);
            }
            else
            {
                //object objval = DataBase.Instance.tSR_User.Math(FunType.Count, SR_UserEntity.FiledType.Id,null,null);
                //if (objval != DBNull.Value && SRLibFun.StringConvertToInt32(objval.ToString()) >=30)
                //{
                //    new SRFMessageBox("用户名数量已达到上限！", "提示", MessageBoxButtons.OK).ShowDialog();
                //    return;
                //}
                SR_UserEntity userEnt = new SR_UserEntity();
                userEnt.Loginname = this.textBox1.Text;
                userEnt.Pwd = this.textBox2.Text;
                if (this.radioButton1.Checked == true)
                    userEnt.Groupid = 1;
                else if (this.radioButton2.Checked == true)
                    userEnt.Groupid = 2;
                else if (this.radioButton3.Checked == true)
                    userEnt.Groupid = 3;
                else if (this.radioButton4.Checked == true)
                    userEnt.Groupid = 4;
               id = DataBase.Instance.tSR_User.Add(userEnt);
            }
            

            DataBase.Instance.tSR_Systemrecord.Add(new SR_SystemrecordEntity()
            {
                Adddate = DateTime.Now,
                Ltype = "日志",
                Title = Param.Loginname,
                Description = this.textBox1.Text
                + "用户",
                Remark = "设置"
            });
            new SRFMessageBox("保存成功！", "提示", MessageBoxButtons.OK).ShowDialog();
            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || ((Keys)(e.KeyChar) == Keys.Back))
            {
                e.Handled = false;
            }
            else
            {
                //this.textBox2.Text.TrimEnd(e.KeyChar);
                e.Handled = true;
                //new SRFMessageBox("只能输入数字或英文", "提示", MessageBoxButtons.OK).ShowDialog();
            }
        }
    }
}