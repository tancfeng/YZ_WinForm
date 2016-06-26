using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ManageSystem.ClientApplication.Code;
using System.Drawing.Drawing2D;

namespace SirdRoom.ManageSystem.ClientApplication.Pages.Wordbook
{
    public partial class Add : UserControl
    {
        public Add()
        {
            InitializeComponent();
        }
        void Binddata()
        {
            if (String.IsNullOrEmpty(Param.DPageParameter) == false)
            {
                String[] arrls = Param.DPageParameter.Split(new char[] { '|' });
                this.textBox1.Text = arrls[0];
                Int32 iindex = 0;
                Int32 iselectedindex = 0;
                foreach (MyItem item in this.comboBox1.Items)
                {
                    if (item.Value.Equals(arrls[1]) == true)
                    {
                        iselectedindex = iindex;
                        break;
                    }
                    iindex++;
                }
                this.comboBox1.SelectedIndex = iselectedindex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrEmpty(this.textBox1.Text) == true)
            {
                new SRFMessageBox("名称不能为空！", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }
            Param.DPageParameter = this.textBox1.Text+ "|" + (this.comboBox1.SelectedItem as MyItem).Value;

            this.ParentForm.DialogResult = DialogResult.OK;
            this.ParentForm.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.ParentForm.DialogResult = DialogResult.Cancel;
            this.ParentForm.Close();
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //鼠标选中在这个项上
            if ((e.State & DrawItemState.Selected) != 0)
            {
                //渐变画刷
                LinearGradientBrush brush = new LinearGradientBrush(e.Bounds, Color.FromArgb(255, 251, 237),
                                                 Color.FromArgb(255, 236, 181), LinearGradientMode.Vertical);
                //填充区域
                Rectangle borderRect = new Rectangle(3, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height - 2);
                e.Graphics.FillRectangle(brush, borderRect);
                //画边框
                Pen pen = new Pen(Color.FromArgb(229, 195, 101));
                e.Graphics.DrawRectangle(pen, borderRect);
            }
            else
            {
                SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
                e.Graphics.FillRectangle(brush, e.Bounds);
            }

            //获得项图片,绘制图片
            MyItem item = (MyItem)comboBox1.Items[e.Index];
            Image img = item.Img;

            //图片绘制的区域
            Rectangle imgRect = new Rectangle(6, e.Bounds.Y + 3, 16, 16);
            e.Graphics.DrawImage(img, imgRect);

            //文本内容显示区域
            Rectangle textRect =
                    new Rectangle(imgRect.Right + 2, imgRect.Y, e.Bounds.Width - imgRect.Width, e.Bounds.Height - 2);

            //获得项文本内容,绘制文本
            String itemText = comboBox1.Items[e.Index].ToString();

            //文本格式垂直居中
            StringFormat strFormat = new StringFormat();
            strFormat.LineAlignment = StringAlignment.Center;
            e.Graphics.DrawString(itemText, new Font("微软雅黑", 12), Brushes.Black, textRect, strFormat);
        }

        private void Add_Load(object sender, EventArgs e)
        {
            //添加项
            foreach(KeyValuePair<string,Image> item in SROperation.Instance.IconList)
            {
                comboBox1.Items.Add(new MyItem("", item.Value, item.Key));
            }
            //默认选中项索引
            comboBox1.SelectedIndex = 0;

            //自绘组合框需要设置的一些属性
            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.ItemHeight = 20;
            //comboBox1.Width = 200;

            this.Binddata();
        }

    }
}
