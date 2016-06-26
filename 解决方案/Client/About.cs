using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();

//公司名：长沙新贝今信息技术有限公司//邮箱：benkin@163.com//公司网站地址：www.benkin.com.cn//qq号码：674781046//联系电话：0731-85535945  18975158288

            this.label1.Text = "";
            this.label1.Text += "艺卓资源管理器 Version 1.0\r\n\r\n";
            this.label1.Text += "Copy (C)2015\r\n\r\n";
            //this.label1.Text += "公司网站地址：www.benkin.com.cn\r\n\r\n";
            //this.label1.Text += "qq号码：674781046\r\n\r\n";
            //this.label1.Text += "联系电话：0731-85535945  18975158288\r\n\r\n";

            //this.label1.Text = SRConfig.Instance.GetAppString("About");

            //this.label1.Text = this.label1.Text.Replace("\\r\\n", "\r\n");

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //System.Diagnostics.Process.Start("http://www.sirdroom.com");
        }
    }
}
