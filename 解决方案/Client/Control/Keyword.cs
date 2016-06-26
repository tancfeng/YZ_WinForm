using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ORM;

namespace WindowsFormsApplication1
{
    public partial class Keyword : UserControl
    {
        public Keyword()
        {
            InitializeComponent();
            this.Controls.Clear();

            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());
        }
        public void BindData()
        {
            SROperation2.Instance.KeywordFilter = String.Empty;
            List<SRRC_BiaojiEntity> entList = null;
            if (this.FindForm() is SirdRoom.ManageSystem.ClientApplication.FrmMain)
            {//主窗体
                Int32 id = SROperation.Instance.LeftSelectedId;
                String strWhere = "";
                switch (SROperation.Instance.LeftDtype)
                {
                    case "Resources":
                        {
                            if(SROperation2.Instance.Center1EntList != null && SROperation2.Instance.Center1EntList.Count >0)
                            {
                                StringBuilder sb = new StringBuilder();
                                foreach(SRRC_ResourceEntity ent in SROperation2.Instance.Center1EntList)
                                {
                                    sb.Append(ent.Id + ",");
                                }
                                entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null, "Id in (select Biaoji_id from SRRC_Resourcebiaojirel where Resource_id in (" + sb.ToString().Trim(',') + ") AND User_id in (0," + Param.UserId + "))  AND isShowKeyword=1");
                            }
                        }
                        break;
                    case "Study":
                    case "Favorites":
                        {
                            if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                            {
                                strWhere = " Id in (select Biaoji_id from SRRC_Resourcebiaojirel where Resource_id in (select Resource_id from SRRC_Resourcebiaojirel where Biaoji_id=[$Pid$])  and Resource_id  in (select Resource_id FROM SRRC_Resourcebiaojirel where User_id in (0," + Param.UserId + ")  and  Biaoji_id in (" + Param.filterkeyword + "))  AND User_id in (0," + Param.UserId + "))  AND isShowKeyword=1  ";
                            }
                            else
                            {
                                strWhere = " Id in (select Biaoji_id from SRRC_Resourcebiaojirel where Resource_id in (select Resource_id from SRRC_Resourcebiaojirel where Biaoji_id=[$Pid$])  AND User_id in (0," + Param.UserId + "))  AND isShowKeyword=1 ";
                            }
                            entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null, strWhere,
                                new DataParameter("Pid", id));
                        }
                        break;
                    default:
                        break;
                }
            }else if(this.FindForm() is SirdRoom.ManageSystem.ClientApplication.FrmFrame)
            {//弹出窗体
                entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null, " Id in (select Biaoji_id from SRRC_Resourcebiaojirel where Resource_id in (" + SROperation2.Instance.BrowserPicId + ") AND User_id in (0," + Param.UserId + "))  AND isShowKeyword=1 ");
            }
            this.Controls.Clear();
            if (entList == null || entList.Count == 0) return;
            Int32 irow_Y = 0;

            irow_Y = 13;
            List<SRRC_BiaojiEntity> temp = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null, "Topid=0");
            foreach (var item in temp)
            {
                IOrderedEnumerable<SRRC_BiaojiEntity> children = entList.Where(m => m.Topid == item.Id).OrderBy(m => m.Pid);
                if (!entList.Any(m => m.Id == item.Id) && (children == null || children.Count() == 0)) continue;//无子项，返回
                //group 
                Label lblGroup = new Label() { AutoSize = true, BackColor = System.Drawing.SystemColors.ActiveCaption, Text = "-", Size = new Size(11, 12), TextAlign = ContentAlignment.MiddleCenter };
                lblGroup.Location = new Point(7, irow_Y);
                Label lblGroup2 = new Label() { AutoSize = true, Text = item.Name, Tag = item, ForeColor = Color.White };
                lblGroup2.Location = new Point(24, irow_Y);
                lblGroup2.Click += lbl_Click;
                this.Controls.Add(lblGroup);
                this.Controls.Add(lblGroup2);
                irow_Y += 25;
                Int32 ikindex = 24;
                
                foreach (var itemsub in children)
                {
                    Label lbl = new Label() { AutoSize = true, Text = itemsub.Name, Tag = itemsub, ForeColor = Color.White };
                    if(ikindex + lbl.PreferredWidth + 10 > this.Width) //
                    {
                        irow_Y += 25;
                        ikindex = 24;
                    }
                    lbl.Location = new Point(ikindex, irow_Y);
                    lbl.Click += lbl_Click;
                    this.Controls.Add(lbl);
                    ikindex += lbl.PreferredWidth + 10;
                }
                if (entList.Count(m => m.Topid == item.Id) != 0)
                {
                    irow_Y += 25;
                }
                //线
                Panel pnl = new Panel()
                {
                    Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top
                        | System.Windows.Forms.AnchorStyles.Left
                        | System.Windows.Forms.AnchorStyles.Right),
                    BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle,
                    Size = new System.Drawing.Size(this.Width, 1)

                };
                pnl.Location = new Point(9, irow_Y);
                this.Controls.Add(pnl);
                irow_Y += 5;

            }

        }
        //定义委托
        public delegate void PageClickHandle(object sender, MyEventArgs e);
        //定义事件
        public event PageClickHandle OnPageClicked;

        void lbl_Click(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Right";
            Label lbl = sender as Label;
            SRRC_BiaojiEntity ent = lbl.Tag as SRRC_BiaojiEntity;
            if (lbl.ForeColor == Color.Red)
            {
                lbl.ForeColor = Color.White;
                SROperation2.Instance.KeywordFilter_Remove(ent.Id);
            }
            else
            {
                lbl.ForeColor = Color.Red;
                SROperation2.Instance.KeywordFilter_Add(ent.Id);
            }
            if (OnPageClicked != null)
            {
                OnPageClicked(sender, new MyEventArgs() { Action = 5 });
            }
        }

        private void 清除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is Label)
                {
                    ctl.ForeColor = Color.White;
                }
            }
            SROperation2.Instance.KeywordFilter = "";
            if (OnPageClicked != null)
            {
                OnPageClicked(sender, new MyEventArgs() { Action = 5 });
            }
        }
    }
}
