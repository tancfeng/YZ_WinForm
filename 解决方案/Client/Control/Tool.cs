using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ManageSystem.ClientApplication;

namespace ControlLibrary.Control
{
    public partial class Tool : UserControl
    {
        //定义委托
        public delegate void PageToolClickHandle(object sender, ToolEventArgs e);
        //定义事件
        public event PageToolClickHandle OnPageToolClicked;
        public class ToolEventArgs
        {
            public int PicIndex { get; set; }
        }
        public Tool()
        {
            InitializeComponent();
            toolStrip1.ForeColor = Color.White;
            toolStrip1.BackColor = Color.FromArgb(37, 37, 37);
            toolStrip1.RenderMode = ToolStripRenderMode.Professional;
            toolStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());
        }
        void SetAddress(String strAddress, SRRC_ResourceEntity resEnt)
        {
            this.panel2.Controls.Clear();
            if(SROperation2.Instance.FocusPanel == "Left")
            {
                String[] arrls = strAddress.TrimStart('\\').TrimStart('\\').Split(new char[] { '\\' });
                Int32 index = 0;
                foreach (var item in arrls)
                {
                    if (String.IsNullOrEmpty(item) == false)
                    {
                        PictureBox pic = new PictureBox();
                        pic.Image = SirdRoom.ManageSystem.ClientApplication.Properties.Resources.Tool_Address;
                        pic.Size = new Size(12, 15);
                        pic.Location = new Point(index, 3);
                        this.panel2.Controls.Add(pic);

                        Label lbl = new Label();
                        lbl.Text = item;
                        lbl.AutoSize = false;
                        lbl.Size = new Size(lbl.Text.Length * 16, 15);
                        lbl.Location = new Point(index + 15 + 3, 3);
                        lbl.ForeColor = Color.White;
                        this.panel2.Controls.Add(lbl);

                        index = lbl.Location.X + lbl.Width + 3;
                    }
                }
            }
            
            //显示加载信息
            Label lbl1 = new Label();
            lbl1.Text = "共" + SROperation2.Instance.entListCount + "项";
            lbl1.AutoSize = false;
            lbl1.Size = new Size(lbl1.Text.Length * 16, 15);
            lbl1.Location = new Point(panel2.Width - lbl1.Width, 3);
            lbl1.ForeColor = Color.White;
            this.panel2.Controls.Add(lbl1);


        }

        private void PicTool_Click(object sender, EventArgs e)
        {
            //if((e as MouseEventArgs).Button == System.Windows.Forms.MouseButtons.Right)
            //{
            //    return;
            //}
            ToolStripItem pb = sender as ToolStripItem;
            if (pb.Name == "p14")//center1KeywordFilter
            {
                //查询是否设置filterKeyword
                var userSettingEnt = DataBase.Instance.tSR_UserSetting.Get_Entity(Param.UserId);
                if (userSettingEnt == null || string.IsNullOrEmpty(userSettingEnt.DefaultKeyword))
                {
                    return;
                }
                if (SROperation.Instance.OnlyShow)
                {
                    p14.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._14_0;
                }
                else
                {
                    p14.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._14_2;
                    pb.MouseLeave -= new EventHandler(toolsIcon_MouseLeave);
                }
            }
            else
            {
                string id = pb.Name.Replace("p", "");
                if ("4,5,6,7,8".Contains(id))
                {
                    p4.Checked = false;
                    p5.Checked = false;
                    p6.Checked = false;
                    p7.Checked = false;
                    p8.Checked = false;
                    switch (id)
                    {
                        case "4": p4.Checked = true; break;
                        case "5": p5.Checked = true; break;
                        case "6": p6.Checked = true; break;
                        case "7": p7.Checked = true; break;
                        case "8": p8.Checked = true; break;
                    }
                } else {
                    (sender as ToolStripButton).Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_" + id + "_1") as Image;
                    pb.MouseLeave += new EventHandler(toolsIcon_MouseLeave);
                }

            }            
            if (OnPageToolClicked != null)
            {
                if(SROperation2.Instance.PicSelected != null && SROperation2.Instance.PicSelected.Count > 0)
                {
                    SROperation.Instance.LeftSelectedId = SROperation2.Instance.PicSelected.FirstOrDefault().Pid;
                }                
                OnPageToolClicked(sender, new ToolEventArgs() { PicIndex = SRLibFun.StringConvertToInt32(pb.Name.Substring(1)) });//把按钮自身作为参数传递
            }
        }

        internal void BindData()
        {
            //排序按钮
            //重置排序
            {
                p4.Checked = false;
                p5.Checked = false;
                p6.Checked = false;
                p7.Checked = false;
                p8.Checked = false;
            }
            switch(SROperation.Instance.Orderby)
            {
                case 5:
                    {
                        // p8.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_8_1") as Image;
                        p8.Checked = true;
                    }
                    break;
                case 2:
                    {
                        // p5.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_5_1") as Image;
                        p5.Checked = true;
                    }
                    break;
                case 3:
                    {
                        //  p6.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_6_1") as Image;
                        p6.Checked = true;
                    }
                    break;
                case 4:
                    {
                        //  p7.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_7_1") as Image;
                        p7.Checked = true;
                    }
                    break;
                case 1:
                default:
                    {
                        // p4.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_4_1") as Image;
                        p4.Checked = true;
                    }
                    break;

            }
            //ordertype
            {
                this.递增ToolStripMenuItem.Checked = false;
                this.递减ToolStripMenuItem.Checked = false;
            }
            if (SROperation.Instance.OrderType == 0)
            {
                this.递增ToolStripMenuItem.Checked = true;
            }else if(SROperation.Instance.OrderType == 1)
            {
                this.递减ToolStripMenuItem.Checked = true;
            }
            //只显示
            if(SROperation.Instance.OnlyShow)
            {
                p14.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources._14_2;
            }

            //查询关键字         
            this.txtQuery.Text = SROperation.Instance.Keyword;
            String strPath = "";
            SRRC_ResourceEntity resEnt = DataBase.Instance.tSRRC_Resource.Get_Entity(SROperation.Instance.LeftSelectedId);
            switch (SROperation.Instance.LeftDtype)
            {
                case "Resources":
                    {

                        if (resEnt != null)
                        {
                            strPath = resEnt.Path;                           
                            string sharedName = resEnt.Serverip.Substring(resEnt.Serverip.LastIndexOf('\\'));
                            strPath = sharedName + "\\" + strPath;
                        }
                    }
                    break;
                case "Study":
                    {
                        List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null, " User_id=0 ");
                        if (entList != null)
                        {
                            this.AddData(entList, SROperation.Instance.LeftSelectedId, ref strPath);
                        }
                    }
                    break;
                case "Favorites":
                    {
                        List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null, " User_id="+ Param.UserId +" ");
                        if (entList != null)
                        {
                            this.AddData(entList, SROperation.Instance.LeftSelectedId, ref strPath);
                        }
                    }
                    break;
                default:
                    break;
            }

            this.SetAddress(strPath, resEnt);
        }

        void AddData(List<SRRC_BiaojiEntity> entList, int p, ref string strPath)
        {
            SRRC_BiaojiEntity ent = entList.FirstOrDefault(m => m.Id == p);
            if (ent == null)
                return;
            strPath = "\\" + ent.Name + strPath;
            this.AddData(entList, ent.Pid, ref strPath);
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            SROperation.Instance.Keyword = this.txtQuery.Text;
            if (OnPageToolClicked != null)
            {
                OnPageToolClicked(sender, new ToolEventArgs() { PicIndex = 15   });//把按钮自身作为参数传递
            }
        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {
            if(this.txtQuery.Text == "")
            {
                btnQuery_Click(sender, e);
            }
        }

        private void toolsIcon_MouseEnter(object sender, EventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            string id = pb.Name.Replace("p", "");
            if((SROperation.Instance.Orderby+3).ToString() == id)
            {
                pb.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_" + id + "_1") as Image;
            }
            else
            {
                pb.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_" + id + "_1") as Image;
                pb.MouseLeave += new EventHandler(toolsIcon_MouseLeave);
            }
           
        }
        private void toolsIcon_MouseLeave(object sender, EventArgs e)
        {
            ToolStripItem pb = sender as ToolStripItem;
            string id = pb.Name.Replace("p", "");
            pb.Image = global::SirdRoom.ManageSystem.ClientApplication.Properties.Resources.ResourceManager.GetObject("_" + id + "_0") as Image;
        }

        private void p14_MouseUp(object sender, MouseEventArgs e)
        {
            //mouseright popup
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                FrmFrame frm = new FrmFrame()
                {
                    WindowState = FormWindowState.Normal,
                    Width=480,
                    Height=390,
                    BackColor = Color.FromArgb(37,37,37),
                    Text = "艺卓资源管理系统",
                    Name = "过滤关键字设置",
                    FormBorderStyle = FormBorderStyle.Sizable
                };                
                var control = new Center1ShowFilterByKeywordSetting();
                frm.SetUserControl(control);
                
                //  
                frm.ShowDialog();
                if(SROperation2.Instance.isFilterKeywordChanged)
                {
                    OnPageToolClicked(sender, new ToolEventArgs() { PicIndex = 14 });
                }

            }
        }

        private void 递增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var item = sender as ToolStripMenuItem;
                if (item.Checked) return;
                this.递减ToolStripMenuItem.Checked = false;
                item.Checked = true;
                SROperation.Instance.OrderType = 0;
                OnPageToolClicked(sender, new ToolEventArgs() { PicIndex = SROperation.Instance.Orderby + 3 });
            }
        }

        private void 递减ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem)
            {
                var item = sender as ToolStripMenuItem;
                if (item.Checked) return;
                this.递增ToolStripMenuItem.Checked = false;
                item.Checked = true;
                SROperation.Instance.OrderType = 1;
                OnPageToolClicked(sender, new ToolEventArgs() { PicIndex = SROperation.Instance.Orderby + 3 });
            }
        }
    }

}
