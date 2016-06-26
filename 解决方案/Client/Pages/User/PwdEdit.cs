using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ManageSystem.Library.Data;

namespace SirdRoom.ManageSystem.ClientApplication.Pages.User
{
    public partial class PwdEdit : UserControl
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
                }
            }
            return false;
        }

        public PwdEdit()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataBase.Instance.tSR_Systemrecord.Add(new SR_SystemrecordEntity()
            {
                Adddate = DateTime.Now,
                Ltype = "日志",
                Title = Param.Loginname,
                Description = DataBase.Instance.tSR_User.Get_Entity(Param.UserId) == null ? "" : DataBase.Instance.tSR_User.Get_Entity(Param.UserId).Loginname
                + "密码设置",
                Remark = "设置"
            });
            if (this.textBox1.Text.Length != 6 || this.textBox2.Text.Length != 6 || this.textBox3.Text.Length != 6)
            {
                new SRFMessageBox("密码必须为6个ASCII字符！", "提示", MessageBoxButtons.OK).ShowDialog();
                return;
            }

            SR_UserEntity userEnt = DataBase.Instance.tSR_User.Get_Entity(Param.UserId);
            if (this.textBox1.Text.Equals(userEnt.Pwd) == false)
            {
                new SRFMessageBox("旧密码输入错误!", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }
            if (this.textBox2.Text.Equals(this.textBox3.Text) == false)
            {
                new SRFMessageBox("新密码不一致!", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }

            userEnt.Pwd = this.textBox2.Text;
            if (DataBase.Instance.tSR_User.Update(userEnt) > 0)
            {
                if (new SRFMessageBox("密码修改成功，请牢记新密码!", "提示", MessageBoxButtons.OK).ShowDialog() == DialogResult.OK)
                    this.ParentForm.Close();
            }
            else
            {
                new SRFMessageBox("修改失败!", "提示", MessageBoxButtons.OK).ShowDialog();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
