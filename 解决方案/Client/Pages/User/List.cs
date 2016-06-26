using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication.Pages.User
{
    public partial class List : UserControl
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;
            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        this.ParentForm.Close();//esc关闭窗体
                        break;
                    case Keys.Enter:

                        return true;
                        break;
                }
            }
            return false;
        }   

        public List()
        {
            InitializeComponent();

            this.BindData();

        }

        private void BindData()
        {
            //this.dataGridView1.DataSource = DataBase.Instance.tSR_User.Get_EntityCollection();

            //if (this.SelectedRowIndex < this.dataGridView1.Rows.Count)
            //    ;
            //else this.SelectedRowIndex = 0;
            //this.dataGridView1.CurrentCell = this.dataGridView1.Rows[this.SelectedRowIndex].Cells[1]; 
            this.panel3.Controls.Clear();
            List<SR_WordbookEntity> groupentList = DataBase.Instance.tSR_Wordbook.Get_EntityCollection(null, " Dtype='用户组' ");
            if(groupentList == null) groupentList = new List<SR_WordbookEntity>();
            List<SR_UserEntity> entList = DataBase.Instance.tSR_User.Get_EntityCollection();
            if (entList != null)
            {
                Int32 i = 0;
                foreach (var item in entList)
                {
                    Panel p = new Panel();
                    p.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                    p.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
                    p.Location = new System.Drawing.Point(0, 29 * (i + 1));
                    p.Name = "pane_"+item.Id;
                    p.Size = new System.Drawing.Size(328, 1);
                    p.TabIndex = 12;

                    Label lbl1 = new Label();
                    lbl1.AutoSize = true;
                    lbl1.ForeColor = System.Drawing.Color.Black;
                    lbl1.Location = new System.Drawing.Point(12, 11 + (i * 30));
                    lbl1.Name = "label_"+item.Id+"_1";
                    lbl1.Size = new System.Drawing.Size(41, 12);
                    lbl1.TabIndex = 8;
                    lbl1.Text = item.Loginname;

                    Label lbl2 = new Label();
                    lbl2.AutoSize = true;
                    lbl2.ForeColor = System.Drawing.Color.Black;
                    lbl2.Location = new System.Drawing.Point(108, 11 + (i * 30));
                    lbl2.Name = "label_" + item.Id + "_2";
                    lbl2.Size = new System.Drawing.Size(29, 12);
                    lbl2.TabIndex = 9;
                    lbl2.Text = groupentList.Any(m => m.Id == item.Groupid) == false ? "" : groupentList.FirstOrDefault(m => m.Id == item.Groupid).Title;
                    
                    Label lbl4 = new Label();
                    lbl4.AutoSize = true;
                    lbl4.ForeColor = System.Drawing.Color.Black;
                    lbl4.Location = new System.Drawing.Point(267, 11 + (i * 30));
                    lbl4.Name = "label_" + item.Id + "_3";
                    lbl4.Size = new System.Drawing.Size(29, 12);
                    lbl4.TabIndex = 11;
                    lbl4.Text = "删除";
                    lbl4.Tag = item.Id;
                    lbl4.Click += new System.EventHandler(this.lbl_Del_Click);

                    Label lbl3 = new Label();
                    lbl3.AutoSize = true;
                    lbl3.ForeColor = System.Drawing.Color.Black;
                    lbl3.Location = new System.Drawing.Point(232, 11 + (i * 30));
                    lbl3.Name = "label_" + item.Id + "_4";
                    lbl3.Size = new System.Drawing.Size(29, 12);
                    lbl3.TabIndex = 10;
                    lbl3.Text = "修改";
                    lbl3.Tag = item.Id;
                    lbl3.Click += new System.EventHandler(this.lbl_Edit_Click); 

                    this.panel3.Controls.Add(p);
                    this.panel3.Controls.Add(lbl1);
                    this.panel3.Controls.Add(lbl2);
                    this.panel3.Controls.Add(lbl4);
                    this.panel3.Controls.Add(lbl3);

                    i++;
                }
            }
        }

        //protected Int32 SelectedRowIndex = 0;

        //private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        try
        //        {
        //            if (dataGridView1.Columns[e.ColumnIndex].GetType() == typeof(DataGridViewButtonColumn))
        //            {
        //                if (dataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("编辑") == true)  //转发
        //                {
        //                    //this.dataGridView1.SelectedRows.Index;
        //                    this.SelectedRowIndex = e.RowIndex;
        //                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1]; 
        //                    Int32 id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
        //                    FrmFrame frm = new FrmFrame() {StartPosition = FormStartPosition.CenterScreen, Text = "编辑用户", Width = 829, Height= 622  };
        //                    Param.DPageParameter = id.ToString();
        //                    frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.User.Add() { Name = "Add" });
        //                    frm.ShowDialog();
        //                    this.BindData();
        //                }
        //                else if (dataGridView1.Columns[e.ColumnIndex].HeaderText.Equals("删除") == true)  //报告
        //                {
        //                    this.SelectedRowIndex = e.RowIndex;
        //                    this.dataGridView1.CurrentCell = this.dataGridView1.Rows[e.RowIndex].Cells[1]; 
        //                    Int32 id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value);
        //                    if (id == 1)
        //                    {
        //                        new SRFMessageBox("管理员不能被删除！", "提示", MessageBoxButtons.OK).ShowDialog(); return;
        //                    }
        //                    if (new SRFMessageBox("您确认要删除此用户吗？", "提示", MessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
        //                    {
        //                        DataBase.Instance.tSR_Systemrecord.Add(new SR_SystemrecordEntity()
        //                        {
        //                            Adddate = DateTime.Now,
        //                            Ltype = "日志",
        //                            Title = Param.Loginname,
        //                            Description = (DataBase.Instance.tSR_User.Get_Entity(id) == null ? "" : DataBase.Instance.tSR_User.Get_Entity(id).Loginname)
        //                            ,
        //                            Remark = "删除"
        //                        });
        //                        DataBase.Instance.tSR_User.Delete(id);
        //                        this.BindData();
        //                    }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            //ErrorMessage(ex.Message);
        //            return;
        //        }
        //    }
        //}

        /// <summary>
        /// Add User
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            FrmFrame frm = new FrmFrame() { StartPosition = FormStartPosition.CenterScreen, Text = "添加用户", Width = 338, Height = 235 };
            Param.DPageParameter = "";
            frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.User.Add() { Name = "Add" });
            if (frm.ShowDialog() == DialogResult.OK)
                this.BindData();
        }
        //修改
        private void lbl_Edit_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32((sender as Label).Tag);
            FrmFrame frm = new FrmFrame() { StartPosition = FormStartPosition.CenterScreen, Text = "编辑用户", Width = 338, Height = 235 };
            Param.DPageParameter = id.ToString();
            frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.User.Add() { Name = "Add" });
            if(frm.ShowDialog() == DialogResult.OK)
                this.BindData();
        }
        //删除
        private void lbl_Del_Click(object sender, EventArgs e)
        {
            Int32 id = Convert.ToInt32((sender as Label).Tag);
            if (id == 1)
            {
                new SRFMessageBox("管理员不能被删除！", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }
            if (new SRFMessageBox("您确认要删除此用户吗？", "提示", MessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
            {
                DataBase.Instance.tSR_Systemrecord.Add(new SR_SystemrecordEntity()
                {
                    Adddate = DateTime.Now,
                    Ltype = "日志",
                    Title = Param.Loginname,
                    Description = (DataBase.Instance.tSR_User.Get_Entity(id) == null ? "" : DataBase.Instance.tSR_User.Get_Entity(id).Loginname)
                    ,
                    Remark = "删除"
                });
                DataBase.Instance.tSR_User.Delete(id);
                this.BindData();
            }
        }


    }
}
