using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ControlLibrary.Control
{
    //Action 0表示Click 1表示双击
    public partial class MyPic : UserControl
    {
        //定义委托
        public delegate void PageClickHandle(object sender, MyEventArgs e);
        //定义事件
        public event PageClickHandle OnPageClick;

        public MyPic()
        {
            InitializeComponent();
        }
        public void SetData(SRRC_ResourceEntity ent)
        {
            this.label1.Text = ent.Extend1;
            this.label2.Text = ent.Name;
            this.pictureBox1.Image = Image.FromFile(ent.Serverip + ent.Path);
        }

        /// <summary>
        /// 选中与否
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SRRC_ResourceEntity ent = this.Tag as SRRC_ResourceEntity;
            if (this.BackColor == Color.FromArgb(57, 57, 57))//未选中
            {
                this.BackColor = Color.FromArgb(77, 77, 77);
                SROperation2.Instance.PicSelected_Add(ent.Id);
            }
            else
            {
                this.BackColor = Color.FromArgb(57, 57, 57);
                SROperation2.Instance.PicSelected_Remove(ent.Id);
            }
            if (OnPageClick != null)
            {
                OnPageClick(sender, new MyEventArgs() { Action = 0, Parameter = this.Tag });
            }

        }
        //双击
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (OnPageClick != null)
            {
                OnPageClick(sender, new MyEventArgs() { Action = 1, Parameter = this.Tag });
            }
        }
    }
}
