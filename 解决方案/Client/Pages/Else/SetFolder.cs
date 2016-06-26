using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ORM;

namespace SirdRoom.ManageSystem.ClientApplication.Pages.Else
{
    public partial class SetFolder : UserControl
    {
        public SetFolder()
        {
            InitializeComponent();
        }

        void BindData()
        {
            this.textBox1.Text = Param.UserEnt.Companyname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Text = this.folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataBase.Instance.tSR_User.Update(new KeyValueCollection<SR_UserEntity.FiledType>() {
             new KeyValue<SR_UserEntity.FiledType>( SR_UserEntity.FiledType.Companyname,this.textBox1.Text)
            },
                " Id=[$Id$] ",
                new DataParameter("Id", Param.UserId));
            Param.UserEnt.Companyname = this.textBox1.Text;
            this.ParentForm.Close();
        }

    }
}
