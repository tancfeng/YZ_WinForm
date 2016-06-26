using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class Init : UserControl
    {
        public Init()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SRConfig.Instance.SetAppString("ServerIp", this.textBox1.Text);

            try
            {
                DataBase.Instance.tSRTE_User.Get_Entity(1);
                MessageBox.Show("设置成功！");
                new FrmMain().Show();
                this.Visible = false;
            }
            catch (Exception)
            {
                MessageBox.Show("不能与服务端通讯！");
            }
        }
    }
}
