using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ManageSystem.Library.Client;
using SirdRoom.ManageSystem.Library;
using SirdRoom.ManageSystem.Library.Common;
using System.Threading;
using SirdRoom.ORM;
using SirdRoom.ManageSystem.Library.Data;
using SirdRoom.ManageSystem.ClientApplication.Pages;
using SirdRoom.ManageSystem.ClientApplication.Pages.Else;
using System.Threading.Tasks;
using ControlLibrary.Control;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class FrmMain : Form
    {

        bool CtrlIsOk = false;//同鼠标轴滚动事件配合使用，进行图片模式的缩放
        Thread t;
        public FrmMain()
        {
            this.Hide();
            InitializeComponent();
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());
            menuStrip1.ForeColor = Color.White;
            menuStrip1.BackColor = Color.FromArgb(57, 57, 57);

            

            //worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
            this.left1.OnPageAftered += left1_OnPageAftered;
            this.tool1.OnPageToolClicked += tool1_OnPageToolClicked;
            this.center21.OnPageClicked += center21_OnPageClicked;
            this.right1.OnPageClicked += right1_OnPageClicked;
            this.right1.OnPageAftered += right1_OnPageAftered;
            this.center11.OnPageClicked += center11_OnPageClicked;

            //设置默认焦点面板
            SROperation2.Instance.FocusPanel = "Left";
            t = new Thread(new ThreadStart(BlockingCollectionInit));
            t.Start();
        }
        #region 控件事件

        //左边事件
        void left1_OnPageAftered(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null) return;
            SROperation2.Instance.FocusPanel = "Left";
            SROperation.Instance.LeftSelectedId = SRLibFun.StringConvertToInt32(e.Node.Name);
            SROperation2.Instance.PicSelected = null;
            switch(SROperation.Instance.LeftDtype)
            {
                case "Resources":
                    {
                        SROperation2.Instance.ResourceSelectedId = SROperation.Instance.LeftSelectedId;
                    }break;
                case "Study":
                    {
                        SROperation2.Instance.StudySelectedId = SROperation.Instance.LeftSelectedId;
                    }break;
                case "Favorites":
                    {
                        SROperation2.Instance.FavoritesSelectedId = SROperation.Instance.LeftSelectedId;
                    }break;
            }
            SROperation.Instance.OperationList_Add(SROperation.Instance.LeftSelectedId);
            CurrentUrl = new SROperation.UrlEntity() { Index = 0, UrlId = SROperation.Instance.LeftSelectedId };
            this.center11.BindData();
            this.tool1.BindData();
            this.buttom1.BindData();
            this.right1.BindData();
            this.Refresh();
            this.center11.SetData();
            this.right1.RefreshKeyword();
        }

        private SROperation.UrlEntity CurrentUrl = new SROperation.UrlEntity() { Index = 0, UrlId = 0 };
        //工具事件
        void tool1_OnPageToolClicked(object sender, ControlLibrary.Control.Tool.ToolEventArgs e)
        {
            //MessageBox.Show(e.PicIndex.ToString());
            switch (e.PicIndex)
            {
                case 0:
                    {
                        CurrentUrl = SROperation.Instance.OperationList_Get(0, CurrentUrl.Index);
                        if (CurrentUrl == null)
                        {
                            CurrentUrl = new SROperation.UrlEntity() { Index = 0, UrlId = 0 };
                        }
                        if (CurrentUrl.UrlId == 0) break;
                        SROperation.Instance.LeftSelectedId = CurrentUrl.UrlId;

                        this.center11.BindData();
                        this.tool1.BindData();
                        this.Refresh();
                        this.center11.SetData();
                    }
                    break;
                case 1:
                    {
                        CurrentUrl = SROperation.Instance.OperationList_Get(1, CurrentUrl.Index);
                        if (CurrentUrl == null)
                        {
                            CurrentUrl = new SROperation.UrlEntity() { Index = 0, UrlId = 0 };
                        }
                        if (CurrentUrl.UrlId == 0) break;
                        SROperation.Instance.LeftSelectedId = CurrentUrl.UrlId;

                        this.center11.BindData();
                        this.tool1.BindData();
                        this.Refresh();
                        this.center11.SetData();
                    }
                    break;
                case 2:
                    {
                        CurrentUrl = SROperation.Instance.OperationList_Get(2, 0);
                        if (CurrentUrl == null)
                        {
                            CurrentUrl = new SROperation.UrlEntity() { Index = 0, UrlId = 0 };
                        }
                        if (CurrentUrl.UrlId == 0) break;
                        switch (SROperation.Instance.LeftDtype)
                        {
                            case "Resources":
                                {
                                    SRRC_ResourceEntity resourceEnt = DataBase.Instance.tSRRC_Resource.Get_Entity(CurrentUrl.UrlId);
                                    if (resourceEnt != null && resourceEnt.Pid != 0)
                                    {
                                        SROperation.Instance.OperationList_Add(resourceEnt.Pid);
                                        CurrentUrl.UrlId = resourceEnt.Pid;
                                    }
                                    else
                                    {
                                        CurrentUrl.UrlId = 0;
                                    }
                                }
                                break;
                            case "Study":
                            case "Favorites":
                                {
                                    SRRC_BiaojiEntity resourceEnt = DataBase.Instance.tSRRC_Biaoji.Get_Entity(CurrentUrl.UrlId);
                                    if (resourceEnt != null && resourceEnt.Pid != 0)
                                    {
                                        SROperation.Instance.OperationList_Add(resourceEnt.Pid);
                                        CurrentUrl.UrlId = resourceEnt.Pid;
                                    }
                                    else
                                    {
                                        CurrentUrl.UrlId = 0;
                                    }
                                }
                                break;
                            default:
                                break;
                        }
                        if (CurrentUrl.UrlId == 0) break;
                        SROperation.Instance.LeftSelectedId = CurrentUrl.UrlId;

                        this.center11.BindData();
                        this.tool1.BindData();
                        this.Refresh();
                        this.center11.SetData();
                    }
                    break;
                case 3://刷新
                    this.Binddata();
                    break;
                case 4: //排序
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem();
                        ls.Text = "按标记时间排列";
                        this.ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 5:
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem();
                        ls.Text = "按使用次数排列";
                        this.ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 6:
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem();
                        ls.Text = "按修改时间排列";
                        this.ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 7:
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem();
                        ls.Text = "按文件大小排列";
                        this.ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 8:
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem();
                        ls.Text = "按文件名称排列";
                        this.ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 9:
                    this.contextMenuStrip1.Show(MousePosition.X, MousePosition.Y);
                    break;
                case 10:
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem() { Text = "列表" };
                        this.Context1ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 11:
                    {//493, 109
                        FrmFrame frm = new FrmFrame() { Width = 490, Height = 130, Text = "设置路径" };
                        frm.SetUserControl(new SetFolder());
                        frm.ShowDialog();
                    }
                    break;
                case 12:
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem();
                        ls.Text = "跳转到资源目录";
                        SROperation2.Instance.FocusPanel = "Left";
                        this.ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 13://复制到指定目录
                    {
                        ToolStripMenuItem ls = new ToolStripMenuItem();
                        ls.Text = "复制到指定目录";
                        this.ToolStripMenuItem_Click(ls, null);
                    }
                    break;
                case 14://Center1KeywordFilter
                    {                        
                        SROperation.Instance.OnlyShow = !SROperation.Instance.OnlyShow;
                        //ToolStripMenuItem ls = new ToolStripMenuItem();
                        //ls.Text = "刷新";
                        //this.ToolStripMenuItem_Click(ls, null);
                        this.center11.BindData();
                        this.tool1.BindData();
                        this.Refresh();
                        this.center11.SetData();
                        this.right1.RefreshKeyword();
                    }break;
                case 15:
                    {
                        this.center11.BindData();
                        this.tool1.BindData();
                        this.Refresh();
                        this.center11.SetData();
                    }
                    break;
                default:
                    break;
            }
        }

        //中间1事件
        void center11_OnPageClicked(object sender, MyEventArgs e)
        {
            switch (e.Action)
            {
                case 3: //更新状态栏
                    {
                        this.buttom1.BindData();
                        this.right1.SetBiaoJiSatus(SROperation2.Instance.PicSelected);
                    }
                    break;
                case 1: //打开图片预览
                    //MessageBox.Show("打开，未实现");
                    {
                        if (SROperation2.Instance.PicSelected == null || SROperation2.Instance.PicSelected.Count <= 0) return;
                        //StringBuilder sb = new StringBuilder();
                        //if (SROperation2.Instance.PicSelected.Count == 1)
                        //{
                        //    SRRC_ResourceEntity ent = SROperation2.Instance.PicSelected.FirstOrDefault();
                        //    var t1 = this.center11.listView1.Items.Find(ent.Id.ToString(), true);
                        //    if (t1 == null && t1.Length == 0) return;
                        //    var t1_0 = t1[0];
                        //    int begin = t1_0.Index - 10 < 0 ? 0 : t1_0.Index - 10;
                        //    for (int i = begin; i < begin + 10 && i < this.center11.listView1.Items.Count; i++)
                        //    {
                        //        t1_0 = this.center11.listView1.Items[i];
                        //        if (t1_0 != null)
                        //            sb.Append(t1_0.Name + ",");
                        //    }
                        //}
                        //else
                        //{
                        //    foreach (var item in SROperation2.Instance.PicSelected)
                        //    {
                        //        sb.Append(item.Id + ",");
                        //    }
                        //}
                        //SROperation2.Instance.CenterLanZhiTemp = sb.ToString().Trim(',');
                        FrmFrame frm = new FrmFrame()
                        {
                            WindowState = FormWindowState.Maximized,
                            MaximizeBox = true,
                            MinimizeBox = true,
                            Text = "艺卓资源管理系统",
                            Name = "Browser",
                            FormBorderStyle = FormBorderStyle.Sizable
                        };
                        SRRC_ResourceEntity i = SROperation2.Instance.PicSelected[0];
                        Param.DPageParameter = i.Serverip + i.Path + "|" + this.center11.listView1.Items.Find(i.Id.ToString(),true)[0].Index + "|" + i.Id;
                        //frm.SetUserControl(new Browser(this.center11.listView1.Items));
                        frm.SetUserControl(new Browser1(this.center11.entList,"Center1"));
                        frm.Owner = this;
                        SROperation2.Instance.Center2_1ImageDict = SROperation2.Instance.Center1ImageDict;
                        //frm.Show();
                        //frm.ShowDialog();                        
                        frm.Show();
                        (sender as ListViewItem).Selected = false;
                        this.Hide();
                    }
                    break;
                case 2: //加载图片
                    {
                        // this.center11.listView1_Load();
                        // this.tool1.BindData();
                    }
                    break;
                case 4: //刷新地址栏
                    {
                        SRRC_ResourceEntity ent = e.Parameter as SRRC_ResourceEntity;
                        this.left1_OnPageAftered(sender, new TreeViewEventArgs(new TreeNode() { Name = ent.Id.ToString(), Tag = ent }));

                    }
                    break;
                case 5://刷新Left,center,button
                    {
                        this.left1.BindData();
                        this.center11.BindData();
                        this.buttom1.BindData();
                        this.tool1.BindData();
                        this.Refresh();
                        this.center11.SetData();
                    }
                    break;
                case 6:
                    {
                        this.ToolStripMenuItem_Click(e.Parameter, null);
                    }
                    break;
                case 7:
                    {
                        //清空 图像 篮子 选择项
                        this.center21.ClearListViewSelectedItems();
                    }
                    break;
                default:
                    break;
            }
        }

        //中间2事件
        void center21_OnPageClicked(object sender, MyEventArgs e)
        {
            //this.splitContainer3.Panel2Collapsed = true;
            switch (e.Action)
            {
                case 0:
                    {
                        this.splitContainer3.Panel2Collapsed = true;
                        this.图像蓝子ToolStripMenuItem.Checked = false;
                        SROperation.Instance.IsShowLZ = false;
                    }
                    break;
                case 1:
                    {
                        SROperation2.Instance.CenterLanZhiTemp = this.center21.isTemp ? SROperation.Instance.CenterLanZhiTemp : SROperation.Instance.CenterLanZhi;
                        FrmFrame frm = new FrmFrame()
                        {
                            WindowState = FormWindowState.Maximized,
                            MaximizeBox = true,
                            MinimizeBox = true,
                            Text = "艺卓资源管理系统"
                        };
                        Param.DPageParameter = e.Parameter.ToString();
                        frm.SetUserControl(new Browser(this.center21.listView1.Items, "Center2"));
                        //frm.SetUserControl(new Browser(this.center21.entList,"Center2"));
                        SROperation2.Instance.Center2_1ImageDict = SROperation2.Instance.Center2ImageDict;
                        frm.Owner = this;
                        frm.Show();
                        foreach(ListViewItem lvi in this.center21.listView1.SelectedItems)
                        {
                            lvi.Selected = false;
                        }
                        this.Hide();
                    }
                    break;
                case 2:
                    {

                    }
                    break;
                case 3: //更新关键字
                    {
                        this.right1.SetBiaoJiSatus(SROperation2.Instance.Center2PicSelected);
                    }
                    break;
                case 6:
                    {
                        this.ToolStripMenuItem_Click(e.Parameter, null);
                    }
                    break;
                case 7:
                    {
                        //清空center1 selecteditems
                        this.center11.ClearListViewSelectedItems();
                    }
                    break;
                default:
                    break;
            }
        }

        //右边事件
        void right1_OnPageClicked(object sender, MyEventArgs e)
        {
            switch (e.Action)
            {
                case 0:
                    this.splitContainer2.Panel2Collapsed = true;
                    this.操作过滤面板ToolStripMenuItem.Checked = false;
                    SROperation.Instance.IsShowFilter = false;
                    break;
                case 5:
                    this.center11.BindData();
                    this.tool1.BindData();
                    this.buttom1.BindData();
                    this.Refresh();
                    this.center11.SetData();
                    break;
                default:
                    break;
            }
        }

        //右边事件
        void right1_OnPageAftered(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null) return;
            {
                Int32 ibiaojiId = (e.Node.Tag as SRRC_BiaojiEntity).Id;
                int userId = (e.Node.Tag as SRRC_BiaojiEntity).User_id;
                String strPicSelected = "";
                if (SROperation2.Instance.PicSelected != null)
                {//center1
                    foreach (var item in SROperation2.Instance.PicSelected)
                    {
                        strPicSelected += item.Id + ",";
                    }
                }
                else if(SROperation2.Instance.Center2PicSelected != null)
                {
                    //center2
                    foreach (var item in SROperation2.Instance.Center2PicSelected)
                    {
                        strPicSelected += item.Id + ",";
                    }
                }
                strPicSelected = strPicSelected.TrimEnd(',');
                if (!string.IsNullOrEmpty(strPicSelected))
                {
                    DataBase.Instance.tSRRC_Resourcebiaojirel.Delete("Biaoji_id=[$Biaoji_id$] and Resource_id in (" + strPicSelected + ") ",
                        new DataParameter("Biaoji_id", ibiaojiId)
                        );
                    if (e.Node.Checked == true)//勾选
                    {
                        List<SRRC_ResourcebiaojirelEntity> resourcebiaojirelEntList = new List<SRRC_ResourcebiaojirelEntity>();
                        foreach (var item in strPicSelected.Split(new char[] { ',' }))
                        {
                            resourcebiaojirelEntList.Add(new SRRC_ResourcebiaojirelEntity()
                            {
                                Addtime = DateTime.Now,
                                Biaoji_id = ibiaojiId,
                                Resource_id = SRLibFun.ToInt32(item),
                                User_id = userId
                            });
                        }
                        DataBase.Instance.tSRRC_Resourcebiaojirel.Add(resourcebiaojirelEntList.ToArray());
                        DataBaseHelper.Instance.Helper.ExecuteNonQuery(System.Data.CommandType.Text, " update SRRC_Resource set bjtime=Getdate() where id in(" + strPicSelected + ")  ");
                    }
                }
            }
        }
        #endregion

        //初始化
        private void FrmMain_Load(object sender, EventArgs e)
        {
            this.Hide();//隐藏Form1
            this.aaToolStripMenuItem.Available = false;
            if (Param.LoginState == false || Param.UserId <= 0)
            {//显示登陆
                
                FrmLogin login = new FrmLogin();
                if (login.ShowDialog() == DialogResult.OK)
                {

                    if ((Param.LoginState == true && Param.UserId > 0))
                    {
                        //login.Close();
                        //this.Show();
                    }
                    else
                    {
                        Application.Exit(); return;
                    }
                }
                else
                {
                    Application.Exit(); return;
                }
            }
            if (Param.LoginState == true && Param.UserId > 0)
            {
                //this.Size = this.MinimumSize = this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
                this.WindowState = FormWindowState.Maximized;
                // this.SizeChanged += FrmMain_SizeChanged;
                this.Show();
                try
                {
                    this.Init();
                    this.Binddata();
                }
                catch(Exception ex)
                {
                    SRLogHelper.Instance.AddLog("异常", "FrmMain", "FrmMain_Load", ex.Message);
                }
                finally
                {
                    //非管理员，禁用文件菜单下用户管理
                    if (Param.GroupId == 1) //1：管理员，2：主管，3：员工
                    {
                        this.aaToolStripMenuItem.Available = true;
                    }
                    //this.toolStripStatusLabel1.Text = "    登录用户：" + Param.Loginname;
                    //this.SetUserControl(new Main() { Name = "u1" });
                    ProcessHelper.AddNetUse();
                    this.Text = String.Format("艺卓资源管理系统(当前用户：{0})", Param.UserEnt.Loginname);
                }
            }
            else
            {
                Application.Exit(); return;
            }

           
        }

        void Init()
        {
            SROperation.Instance.OperationList = "";
            //菜单初始化
            this.图像蓝子ToolStripMenuItem.Checked = SROperation.Instance.IsShowLZ;
            this.splitContainer3.Panel2Collapsed = !SROperation.Instance.IsShowLZ;
            switch (SROperation.Instance.LeftDtype)
            {
                case "Resources":
                    this.资源ToolStripMenuItem.Checked = true;
                    this.公共资源与研发ToolStripMenuItem.Checked = false;
                    this.个人收藏ToolStripMenuItem.Checked = false;
                    break;
                case "Study":
                    this.资源ToolStripMenuItem.Checked = false;
                    this.公共资源与研发ToolStripMenuItem.Checked = true;
                    this.个人收藏ToolStripMenuItem.Checked = false;
                    break;
                case "Favorites":
                    this.资源ToolStripMenuItem.Checked = false;
                    this.公共资源与研发ToolStripMenuItem.Checked = false;
                    this.个人收藏ToolStripMenuItem.Checked = true;
                    break;
                default:
                    break;
            }
            this.操作过滤面板ToolStripMenuItem.Checked = SROperation.Instance.IsShowLZ;
            this.splitContainer2.Panel2Collapsed = !SROperation.Instance.IsShowLZ;
            switch (SROperation.Instance.Orderby)
            {
                case 1:
                    this.按标记时间排列ToolStripMenuItem.Checked = true;
                    this.按使用次数排列ToolStripMenuItem.Checked = false;
                    this.按修改时间排列ToolStripMenuItem.Checked = false;
                    this.按文件大小排列ToolStripMenuItem.Checked = false;
                    this.按文件名称排列ToolStripMenuItem.Checked = false;
                    break;
                case 2:
                    this.按标记时间排列ToolStripMenuItem.Checked = false;
                    this.按使用次数排列ToolStripMenuItem.Checked = true;
                    this.按修改时间排列ToolStripMenuItem.Checked = false;
                    this.按文件大小排列ToolStripMenuItem.Checked = false;
                    this.按文件名称排列ToolStripMenuItem.Checked = false;
                    this.center11.视图优先排列ToolStripMenuItem.Checked = false;
                    this.center11.使用次数ToolStripMenuItem.Checked = true;
                    break;
                case 3:
                    this.按标记时间排列ToolStripMenuItem.Checked = false;
                    this.按使用次数排列ToolStripMenuItem.Checked = false;
                    this.按修改时间排列ToolStripMenuItem.Checked = true;
                    this.按文件大小排列ToolStripMenuItem.Checked = false;
                    this.按文件名称排列ToolStripMenuItem.Checked = false;
                    break;
                case 4:
                    this.按标记时间排列ToolStripMenuItem.Checked = false;
                    this.按使用次数排列ToolStripMenuItem.Checked = false;
                    this.按修改时间排列ToolStripMenuItem.Checked = false;
                    this.按文件大小排列ToolStripMenuItem.Checked = true;
                    this.按文件名称排列ToolStripMenuItem.Checked = false;
                    break;
                case 5:
                    this.按标记时间排列ToolStripMenuItem.Checked = false;
                    this.按使用次数排列ToolStripMenuItem.Checked = false;
                    this.按修改时间排列ToolStripMenuItem.Checked = false;
                    this.按文件大小排列ToolStripMenuItem.Checked = false;
                    this.按文件名称排列ToolStripMenuItem.Checked = true;
                    break;
                case 6:
                    this.center11.视图优先排列ToolStripMenuItem.Checked = true;
                    this.center11.使用次数ToolStripMenuItem.Checked = false;
                    break;
                default:
                    break;
            }
            for (int i = 0; i < this.contextMenuStrip1.Items.Count; i++)
            {
                ToolStripMenuItem titem = this.contextMenuStrip1.Items[i] as ToolStripMenuItem;
                if (i == SROperation.Instance.DisplayMode)
                    titem.Checked = true;
                else
                    titem.Checked = false;
            }

            //   this.Size = new Size(SROperation.Instance.WindowWidth, SROperation.Instance.WindowHeight);

            this.splitContainer1.SplitterDistance = SROperation.Instance.SplitContainer1SplitterDistance;
            this.splitContainer2.SplitterDistance = SROperation.Instance.SplitContainer2SplitterDistance;
            this.splitContainer3.SplitterDistance = SROperation.Instance.SplitContainer3SplitterDistance;

            this.splitContainer2.SplitterWidth = 1;
            this.splitContainer3.SplitterWidth = 1;

            this.splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            this.splitContainer2.SplitterMoved += splitContainer2_SplitterMoved;
            this.splitContainer3.SplitterMoved += splitContainer3_SplitterMoved;

            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());

            //
            this.MouseWheel += FrmMain_MouseWheel;
        }

        private void FrmMain_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.CtrlIsOk) //按下了Ctrl键
            {
                if (e.Delta > 0)
                {
                    if (SROperation.Instance.DisplayMode > 9)
                        return;
                    this.Context1ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = (SROperation.Instance.DisplayMode + 1).ToString() }, e);
                }
                else if (e.Delta < 0)
                {
                    if (SROperation.Instance.DisplayMode < 1)
                        return;
                    this.Context1ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = (SROperation.Instance.DisplayMode - 1).ToString() }, e);
                }
            }
        }

        void Binddata()
        {

            this.left1.BindData();
            this.center11.BindData();
            this.tool1.BindData();
            this.right1.BindData();
            this.center21.BindData();
            this.Refresh();
            this.center11.SetData();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Param.LoginState == true)
            {

                if (new SRFMessageBox("您确定要退出吗?", "提示", MessageBoxButtons.YesNo).ShowDialog() == DialogResult.Yes)
                {
                    e.Cancel = false;
                    ProcessHelper.DelNetUse();
                    t.Abort();
                    Application.ExitThread();
                    System.Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = false;
                ProcessHelper.DelNetUse();
                t.Abort();
                Application.ExitThread();
                System.Environment.Exit(0);
            }
        }


        private void aaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFrame frm = new FrmFrame() { Width = 330, Height = 340, Text = "用户管理" };
            frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.User.List());
            frm.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutYiZhuoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFrame frm = new FrmFrame() { Width = 368, Height = 152, Text = "About Yi Zhuo" };
            frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.About());
            frm.ShowDialog();
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem ls = sender as ToolStripMenuItem;
            switch (ls.Text)
            {
                case "图像蓝子":
                    {
                        ls.Checked = !ls.Checked;
                        SROperation.Instance.IsShowLZ = ls.Checked;
                        this.splitContainer3.Panel2Collapsed = !SROperation.Instance.IsShowLZ;
                    }
                    break;
                case "资源":
                    this.资源ToolStripMenuItem.Checked = true;
                    this.公共资源与研发ToolStripMenuItem.Checked = false;
                    this.个人收藏ToolStripMenuItem.Checked = false;
                    SROperation.Instance.LeftDtype = "Resources";
                    this.left1.BindData();
                    break;
                case "公共资源与研发":
                    this.资源ToolStripMenuItem.Checked = false;
                    this.公共资源与研发ToolStripMenuItem.Checked = true;
                    this.个人收藏ToolStripMenuItem.Checked = false;
                    SROperation.Instance.LeftDtype = "Study";
                    this.left1.BindData();
                    break;
                case "个人收藏":
                    this.资源ToolStripMenuItem.Checked = false;
                    this.公共资源与研发ToolStripMenuItem.Checked = false;
                    this.个人收藏ToolStripMenuItem.Checked = true;
                    SROperation.Instance.LeftDtype = "Favorites";
                    this.left1.BindData();
                    break;
                case "操作过滤面板":
                    {
                        ls.Checked = !ls.Checked;
                        SROperation.Instance.IsShowFilter = ls.Checked;
                        this.splitContainer2.Panel2Collapsed = !SROperation.Instance.IsShowFilter;
                    }
                    break;
                case "按标记时间排列":
                    {
                        this.按标记时间排列ToolStripMenuItem.Checked = true;
                        this.按使用次数排列ToolStripMenuItem.Checked = false;
                        this.按修改时间排列ToolStripMenuItem.Checked = false;
                        this.按文件大小排列ToolStripMenuItem.Checked = false;
                        this.按文件名称排列ToolStripMenuItem.Checked = false;
                        SROperation.Instance.Orderby = 1;
                        this.center11.BindData();
                        this.center11.SetData();
                    }
                    break;
                case "按使用次数排列":
                    {
                        this.按标记时间排列ToolStripMenuItem.Checked = false;
                        this.按使用次数排列ToolStripMenuItem.Checked = true;
                        this.按修改时间排列ToolStripMenuItem.Checked = false;
                        this.按文件大小排列ToolStripMenuItem.Checked = false;
                        this.按文件名称排列ToolStripMenuItem.Checked = false;
                        this.center11.视图优先排列ToolStripMenuItem.Checked = false;
                        this.center11.使用次数ToolStripMenuItem.Checked = true;
                        SROperation.Instance.Orderby = 2;
                        this.center11.BindData();
                        this.center11.SetData();
                    }
                    break;
                case "使用次数":
                    {
                        FrmFrame ff = new FrmFrame();
                        ff.Width = 400;
                        ff.Height = 200;
                        ff.Text = "修改使用次数";
                        ff.SetUserControl(new Add("次数"));
                        if ((ff.ShowDialog() == DialogResult.OK) && (SROperation2.Instance.PicSelected != null) && (SROperation2.Instance.PicSelected.Count > 0))
                        {
                            SRRC_ResourceEntity ent = SROperation2.Instance.PicSelected.First();
                            ent.Usecount = Convert.ToInt32(Param.DPageParameter);
                            DataBase.Instance.tSRRC_Resource.Update(ent);
                        }
                    }
                    break;
                case "按修改时间排列":
                    {
                        this.按标记时间排列ToolStripMenuItem.Checked = false;
                        this.按使用次数排列ToolStripMenuItem.Checked = false;
                        this.按修改时间排列ToolStripMenuItem.Checked = true;
                        this.按文件大小排列ToolStripMenuItem.Checked = false;
                        this.按文件名称排列ToolStripMenuItem.Checked = false;
                        SROperation.Instance.Orderby = 3;
                        this.center11.BindData();
                        this.center11.SetData();
                    }
                    break;
                case "按文件大小排列":
                    {
                        this.按标记时间排列ToolStripMenuItem.Checked = false;
                        this.按使用次数排列ToolStripMenuItem.Checked = false;
                        this.按修改时间排列ToolStripMenuItem.Checked = false;
                        this.按文件大小排列ToolStripMenuItem.Checked = true;
                        this.按文件名称排列ToolStripMenuItem.Checked = false;
                        SROperation.Instance.Orderby = 4;
                        this.center11.BindData();
                        this.center11.SetData();
                    }
                    break;
                case "按文件名称排列":
                    {
                        this.按标记时间排列ToolStripMenuItem.Checked = false;
                        this.按使用次数排列ToolStripMenuItem.Checked = false;
                        this.按修改时间排列ToolStripMenuItem.Checked = false;
                        this.按文件大小排列ToolStripMenuItem.Checked = false;
                        this.按文件名称排列ToolStripMenuItem.Checked = true;
                        SROperation.Instance.Orderby = 5;
                        this.center11.BindData();
                        this.center11.SetData();
                    }
                    break;
                case "视图优先排列":
                    {
                        if ((SROperation2.Instance.PicSelected != null) && (SROperation2.Instance.PicSelected.Count > 0))
                        {
                            foreach (SRRC_ResourceEntity ent in SROperation2.Instance.PicSelected)
                            {
                                ent.Extend3 = ls.Checked ? DateTime.Now.ToString("yyyyMMddHHmmssffff") : "";//视图优先排列
                                DataBase.Instance.tSRRC_Resource.Update(ent);
                            }
                        }
                    }
                    break;

                case "刷新":
                    {
                        this.Binddata();
                    }
                    break;
                //=====================
                case "复制到指定目录":
                    {
                        //MessageBox.Show("未实现！");
                        //this.left1.KKCopy(null, Param.ServerIP);
                        SR_UserEntity userEnt = DataBase.Instance.tSR_User.Get_Entity(Param.UserId);
                        if (userEnt == null || String.IsNullOrEmpty(userEnt.Companyname) == true)
                        {
                            MessageBox.Show("未设置路径！");
                            return;
                        }
                        List<SRRC_ResourceEntity> SelectedEntList;
                        if (SROperation2.Instance.FocusPanel == "Center2")
                        {
                            SelectedEntList = SROperation2.Instance.Center2PicSelected;
                        }
                        else
                        {
                            SelectedEntList = SROperation2.Instance.PicSelected;
                        }

                        if (SelectedEntList == null || SelectedEntList.Count <= 0)
                        {
                            MessageBox.Show("请先选择要复制的项！");
                            return;
                        }
                        using (new IdentityScope(Param.ServerIP.Description,
                                                 Param.ServerIP.Remark,
                                                 Param.ServerIP.Title))
                        {
                            List<string> pathList = new List<string>();
                            foreach (var item in SelectedEntList)
                            {
                                string path = "";
                                if (item.Iscomposite)//复合文件
                                {
                                    var temp = DataBase.Instance.tSRRC_Resource.Get_Entity(item.Pid);
                                    if (temp == null) continue;
                                    item.Usecount++;
                                    path = temp.Serverip + temp.Path;
                                }
                                else
                                {
                                    path = item.Serverip + item.Path;
                                    item.Usecount++;
                                }
                                pathList.Add(path);
                            }

                            SROperation2.Instance.isLoading = true;
                            int totalCount = 0;
                            foreach (var path in pathList.Distinct())
                            {
                                if (Directory.Exists(path))
                                {//文件夹
                                    totalCount += Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                                }
                                else if (File.Exists(path))
                                {
                                    //文件
                                    totalCount++;
                                }
                            }
                            SROperation2.Instance.entListCount = totalCount;
                            SROperation2.Instance.entListReadyCount = 0;
                            Thread t = new Thread(new ThreadStart(SetWaitPic));
                            t.Start();
                            
                            foreach (var path in pathList.Distinct())
                            {
                                //先复制文件
                                if (Directory.Exists(path))
                                {//文件夹
                                    string destPath = userEnt.Companyname.TrimEnd('\\') + "\\" + new DirectoryInfo(path).Name;
                                    if (!Directory.Exists(destPath))
                                    {
                                        Directory.CreateDirectory(destPath);
                                    }
                                    else
                                    {
                                        Directory.Delete(destPath, true);
                                        Directory.CreateDirectory(destPath);
                                    }
                                    this.copyDirectory(path, destPath);
                                }
                                else if (File.Exists(path))
                                {
                                    //文件
                                    File.Copy(path, userEnt.Companyname.TrimEnd('\\') + "\\" + new FileInfo(path).Name, true);
                                    ++SROperation2.Instance.entListReadyCount;
                                }                                
                            }
                            SROperation2.Instance.isLoading = false;
                            MessageBox.Show("复制完成！");
                        }


                        //System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                        //psi.Arguments = "/e,/select," + userEnt.Companyname.TrimEnd('\\') + "\\" + SROperation2.Instance.PicSelected.FirstOrDefault().Name;
                        //System.Diagnostics.Process.Start(psi);

                    }
                    break;
                case "跳转到资源目录":
                    {
                        SROperation.Instance.LeftDtype = "Resources";
                        List<SRRC_ResourceEntity> SelectedEntList;
                        if (SROperation2.Instance.FocusPanel == "Center2")
                        {
                            SelectedEntList = SROperation2.Instance.Center2PicSelected;
                        }
                        else
                        {
                            SelectedEntList = SROperation2.Instance.PicSelected;
                        }
                        if (SelectedEntList != null && SelectedEntList.Count > 0)
                        {
                            SRRC_ResourceEntity ent = SelectedEntList[0];
                            if (ent != null)
                                SROperation.Instance.LeftSelectedId = ent.Pid;
                        }
                        this.left1.BindData();
                        this.center11.BindData();
                        this.tool1.BindData();
                        this.buttom1.BindData();
                        this.Refresh();
                        this.center11.SetData();
                    }
                    break;
                case "跳转到原始微缩图":
                    {
                        SRRC_ResourceEntity ent = SROperation2.Instance.PicSelected.FirstOrDefault();
                        if(ent != null)
                        {
                            string path = "";
                            path = ent.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + ent.Path;
                            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                            psi.Arguments = "/e,/select," + path;
                            System.Diagnostics.Process.Start(psi);
                        }
                    }
                    break;
                case "跳转到原始目录":
                    {
                        SRRC_ResourceEntity ent = SROperation2.Instance.PicSelected.FirstOrDefault();
                        if (ent != null)
                        {
                            string path = "";
                            path = ent.Serverip + ent.Path;
                            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
                            psi.Arguments = "/e,/select," + path;
                            System.Diagnostics.Process.Start(psi);
                        } 
                    }
                    break;
                case "新建文件夹":
                    {
                        if(Param.GroupId > 2)
                        {
                            MessageBox.Show("您不具备该权限！请联系管理员。");
                            return;
                        }
                        if (SROperation.Instance.LeftDtype != "Resources") return;
                        FrmFrame frm = new FrmFrame() { Width = 400, Height = 200, Text = "新建文件夹" };
                        frm.SetUserControl(new Add());
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            if (String.IsNullOrEmpty(Param.DPageParameter) == true) return;
                            using (new IdentityScope(Param.ServerIP.Description,
                                Param.ServerIP.Remark,
                                Param.ServerIP.Title))
                            {
                                SRRC_ResourceEntity resEnt = DataBase.Instance.tSRRC_Resource.Get_Entity(SROperation.Instance.LeftSelectedId);
                                String strFolrder = "";
                                if (resEnt != null)
                                {
                                    Directory.CreateDirectory(resEnt.Serverip + resEnt.Path.TrimEnd('\\') + "\\" + Param.DPageParameter);
                                    Directory.CreateDirectory(resEnt.Serverip.Replace(Param.IP,Param.ServerCacheIP) + resEnt.Path.TrimEnd('\\') + "\\" + Param.DPageParameter);
                                    DataBase.Instance.tSRRC_Resource.Add(new SRRC_ResourceEntity()
                                    {
                                        Name = Param.DPageParameter,
                                        Addtime = DateTime.Now,
                                        Dtype = 0,
                                        Path = resEnt.Path.TrimEnd('\\') + "\\" + Param.DPageParameter,
                                        Pid = resEnt.Id,
                                        Serverip = resEnt.Serverip,
                                        Extend2 = "1.png"
                                    });
                                    //strFolrder = resEnt.Serverip + resEnt.Path.TrimEnd('\\') + "\\" + Param.DPageParameter;
                                }
                                else //根
                                {
                                    DataBase.Instance.tSRRC_Resource.Add(new SRRC_ResourceEntity()
                                    {
                                        Name = Param.DPageParameter,
                                        Addtime = DateTime.Now,
                                        Dtype = 0,
                                        Path = "\\" + Param.DPageParameter,
                                        Pid = 0,
                                        Serverip = Param.ServerIP.Title,
                                        Extend2 = "1.png"
                                    });
                                    Directory.CreateDirectory(Param.ServerIP.Title + "\\" + Param.DPageParameter);
                                    Directory.CreateDirectory(Param.ServerIP.Title.Replace(Param.IP, Param.ServerCacheIP)+ Param.DPageParameter);
                                }
                                //if (Directory.Exists(strFolrder) == false)
                                //{
                                //    Directory.CreateDirectory(strFolrder);
                                //}
                                    
                            }
                        }
                        this.Binddata();
                    }
                    break;
                case "复制":
                    {
                        if (Param.GroupId > 2)
                        {
                            MessageBox.Show("您不具备该权限！请联系管理员。");
                            return;
                        }
                        if (SROperation.Instance.LeftDtype != "Resources") return;
                        this.center11.CopySelectedToClipboard();
                        SROperation2.Instance.OperationType = 2;
                    }
                    break;
                case "剪切":
                    {
                        if (Param.GroupId > 2)
                        {
                            MessageBox.Show("您不具备该权限！请联系管理员。");
                            return;
                        }
                        if (SROperation.Instance.LeftDtype != "Resources") return;
                        this.center11.CopySelectedToClipboard();
                        SROperation2.Instance.OperationType = 1;
                        if (this.center11.listView1.SelectedItems != null)
                        {
                            foreach (ListViewItem listItem in this.center11.listView1.SelectedItems)
                            {
                                listItem.BackColor = Color.White;
                            }
                        }
                    }
                    break;
                case "粘贴":
                    {
                        if (SROperation.Instance.LeftDtype != "Resources") return;
                        if (Param.GroupId > 2)
                        {
                            MessageBox.Show("您不具备该权限，请联系管理员！");
                            return;
                        }
                        this.center11.CopyClipboardToCenter1();
                        return;

                        if (SROperation2.Instance.PicCopyTreeId == SROperation.Instance.LeftSelectedId ||
                            SROperation2.Instance.OperationType != 1 || SROperation2.Instance.OperationType != 2 ||
                            SROperation2.Instance.PicSelected == null || SROperation2.Instance.PicSelected.Count <= 0
                            )
                        { return; }
                        if (SROperation2.Instance.OperationType == 1) //Cut
                        {
                            List<String> pathList = new List<string>();
                            foreach (var item in SROperation2.Instance.PicSelected)
                            {
                                pathList.Add(item.Path);
                            }
                            List<SRRC_ResourceEntity> resEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Serverip=[$Serverip$] ", new DataParameter("Serverip", Param.ServerIP.Title));
                            this.left1.KKCopyList(pathList, Param.ServerIP, resEntList.Any(m => m.Id == SROperation.Instance.LeftSelectedId) == false ? "" : resEntList.FirstOrDefault(m => m.Id == SROperation.Instance.LeftSelectedId).Path);
                            String strPids = "";
                            //删除
                            using (new IdentityScope(Param.ServerIP.Description,
                                    Param.ServerIP.Remark,
                                    Param.ServerIP.Title))
                            {
                                foreach (var item in SROperation2.Instance.PicSelected)
                                {
                                    try
                                    {
                                        if (item.Dtype == 1)
                                            new FileInfo(item.Serverip + item.Path).Delete();
                                        else
                                            new DirectoryInfo(item.Serverip + item.Path).Delete();

                                        strPids += item.Id + ",";
                                        GetIds(resEntList, item.Id, ref strPids);
                                    }
                                    catch (Exception)
                                    {
                                        ;
                                    }
                                }
                            }
                            if (string.IsNullOrEmpty(strPids) == false)
                            {
                                DataBase.Instance.tSRRC_Resource.Delete(" Id in(" + strPids.TrimEnd(',') + ") ");
                            }

                            this.left1.BindData();
                            this.center11.BindData();
                            this.Refresh();
                            this.center11.SetData();
                        }
                        else
                        {
                            List<String> pathList = new List<string>();
                            foreach (var item in SROperation2.Instance.PicSelected)
                            {
                                pathList.Add(item.Path);
                            }
                            this.left1.KKCopyList(pathList, Param.ServerIP, SROperation.Instance.LeftSelectedId <= 0 ? "" : DataBase.Instance.tSRRC_Resource.Get_Entity(SROperation.Instance.LeftSelectedId).Path);

                            this.left1.BindData();
                            this.center11.BindData();
                            this.Refresh();
                            this.center11.SetData();
                        }
                    }
                    break;
                case "重命名":
                    {
                        if (Param.GroupId > 2)
                        {
                            MessageBox.Show("您不具备该权限！请联系管理员。");
                            return;
                        }
                        if (SROperation.Instance.LeftDtype != "Resources") return;
                        if (SROperation2.Instance.PicSelected == null || SROperation2.Instance.PicSelected.Count <= 0)
                        { return; }

                        FrmFrame frm = new FrmFrame() { Text = "重命名", Width = 400, Height = 200 };
                        string strold = SROperation2.Instance.PicSelected[0].Path.Split(new char[] { '\\' })[SROperation2.Instance.PicSelected[0].Path.Split(new char[] { '\\' }).Length - 1];
                        Param.DPageParameter = SROperation2.Instance.PicSelected[0].Name;
                        frm.SetUserControl(new Add());
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            if (String.IsNullOrEmpty(Param.DPageParameter) == true) return;
                            using (new IdentityScope(Param.ServerIP.Description,
                                Param.ServerIP.Remark,
                                Param.ServerIP.Title))
                            {
                                SROperation2.Instance.PicSelected[0].Name = Param.DPageParameter;
                                SROperation2.Instance.PicSelected[0].Path = SROperation2.Instance.PicSelected[0].Path.Substring(0, SROperation2.Instance.PicSelected[0].Path.Length - strold.Length - 1) + Param.DPageParameter;
                                foreach (ListViewItem litem in this.center11.listView1.SelectedItems)
                                {
                                    if ((litem.Tag as SRRC_ResourceEntity).Id == SROperation2.Instance.PicSelected[0].Id)
                                    {
                                        litem.Text = SROperation2.Instance.PicSelected[0].Name;
                                        litem.Tag = SROperation2.Instance.PicSelected[0];
                                    }
                                }
                                //DataBase.Instance.tSRRC_Resource.Update(new KeyValueCollection<SRRC_ResourceEntity.FiledType>() { new KeyValue<SRRC_ResourceEntity.FiledType>(){ Key = SRRC_ResourceEntity.FiledType.Path, Value = "" } }, " Serverip=[$Serverip$] ", new DataParameter("Serverip", Param.ServerIP.Title));
                                DataBaseHelper.Instance.Helper.ExecuteNonQuery(System.Data.CommandType.Text, " update SRRC_Resource set path= replace(path,'" + SROperation2.Instance.PicSelected[0].Path.Substring(0, SROperation2.Instance.PicSelected[0].Path.Length - strold.Length - 1) + "','" + SROperation2.Instance.PicSelected[0].Path + "') where Serverip=[$Serverip$] ", new DataParameter("Serverip", Param.ServerIP.Title));

                            }
                        }
                    }
                    break;
                case "删除":
                    {
                        if (Param.GroupId > 2)
                        {
                            MessageBox.Show("您不具备该权限！请联系管理员。");
                            return;
                        }
                        if (SROperation.Instance.LeftDtype != "Resources") return;
                        if (SROperation2.Instance.PicSelected == null || SROperation2.Instance.PicSelected.Count <= 0)
                        { return; }
                        Thread t = new Thread(new ThreadStart(SetWaitPic2));
                        SROperation2.Instance.isLoading = true;
                        t.Start();
                        String strPids = "";
                        //删除
                        List<SRRC_ResourceEntity> resEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Serverip=[$Serverip$] ", new DataParameter("Serverip", Param.ServerIP.Title));
                        using (new IdentityScope(Param.ServerIP.Description,
                                Param.ServerIP.Remark,
                                Param.ServerIP.Title))
                        {
                            foreach (var item in SROperation2.Instance.PicSelected)
                            {
                                try
                                {

                                    DataBase.Instance.tSRRC_Resource.Delete(" Id =" + item.Id);
                                    DataBase.Instance.tSRRC_Resourcebiaojirel.Delete(" Resource_id =" + item.Id);

                                    if (item.Dtype == 0)
                                        new DirectoryInfo(item.Serverip + item.Path).Delete(true);
                                    else
                                        new FileInfo(item.Serverip + item.Path).Delete();
                                    strPids += item.Id + ",";
                                    GetIds(resEntList, item.Id, ref strPids);
                                }
                                catch (Exception ex)
                                {
                                    //MessageBox.Show(ex.Message);
                                    SRLogHelper.Instance.AddLog("异常", "FrmMain", "删除", ex.Message);
                                }
                            }
                        }
                        if (string.IsNullOrEmpty(strPids) == false)
                        {
                            DataBase.Instance.tSRRC_Resource.Delete(" Id in(" + strPids.TrimEnd(',') + ") ");
                            DataBase.Instance.tSRRC_Resourcebiaojirel.Delete(" Resource_id in(" + strPids.TrimEnd(',') + ") ");
                        }
                        this.Binddata();
                        SROperation2.Instance.isLoading = false;
                    }
                    break;
                case "全选":
                    {
                        //this.center11.
                        if (this.center11.listView1.Items != null)
                        {
                            foreach (ListViewItem lItem in this.center11.listView1.Items)
                            {
                                lItem.Selected = true;
                            }
                        }
                    }
                    break;
                case "反选":
                    {
                        if (this.center11.listView1.Items != null)
                        {
                            foreach (ListViewItem lItem in this.center11.listView1.Items)
                            {
                                lItem.Selected = !lItem.Selected;
                            }
                        }
                    }
                    break;
                case "取消选择":
                    {
                        if (this.center11.listView1.Items != null)
                        {
                            foreach (ListViewItem lItem in this.center11.listView1.SelectedItems)
                            {
                                lItem.Selected = false;
                            }
                        }
                    }
                    break;
                case "修改使用次数":
                    {
                        if (Param.GroupId > 2)
                        {
                            MessageBox.Show("您不具备该权限！请联系管理员。");
                            return;
                        }
                        FrmFrame ff = new FrmFrame();
                        ff.Width = 400;
                        ff.Height = 200;
                        ff.Text = "修改使用次数";
                        ff.SetUserControl(new Add("次数"));
                        if ((ff.ShowDialog() == DialogResult.OK) && (SROperation2.Instance.PicSelected != null) && (SROperation2.Instance.PicSelected.Count > 0))
                        {
                            SRRC_ResourceEntity ent = SROperation2.Instance.PicSelected.First();
                            ent.Usecount = Convert.ToInt32(Param.DPageParameter);
                            DataBase.Instance.tSRRC_Resource.Update(ent);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        public void BrowserCross(object sender, EventArgs e)
        {
            ToolStripMenuItem_Click(sender, e);
        }
        public void BrowserCross(string source,int index)
        {
            //source : Center1,Center2
            ListViewItem lvi = null;
            if(source == "Center1")
            {
             lvi =   this.center11.listView1.Items[index];

            }else if(source == "Center2")
            {
               lvi = this.center21.listView1.Items[index];
            }
            if(lvi != null)
            {
                lvi.EnsureVisible();
                lvi.Selected = true;
            }
        }
        void GetIds(List<SRRC_ResourceEntity> resEntList, Int32 pid, ref String strPids)
        {
            if (resEntList == null || resEntList.Count <= 0) return;
            List<SRRC_ResourceEntity> entList = resEntList.Where(m => m.Pid == pid).ToList();
            if (entList != null)
            {
                foreach (var item in entList)
                {
                    strPids += item.Id + ",";
                    GetIds(resEntList, item.Id, ref strPids);
                }

            }
        }

        //文件显示方式事件
        private void Context1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ToolStripMenuItem ls = sender as ToolStripMenuItem;
            Int32 inewMode = 0;
            switch (ls.Text)
            {
                case "详细":
                    {
                        inewMode = 0;
                    }
                    break;
                case "列表":
                    {
                        inewMode = 1;
                    }
                    break;
                case "小图标":
                    {
                        inewMode = 2;
                    }
                    break;
                case "大图标":
                    {
                        inewMode = 3;
                    }
                    break;
                case "小平铺(64*64)":
                    {
                        inewMode = 4;
                    }
                    break;
                case "缩略图 #2(128*128)":
                    {
                        inewMode = 6;
                    }
                    break;
                case "缩略图 #3(256*256)":
                    {
                        inewMode = 10;
                    }
                    break;
                default:
                    {
                        inewMode = Convert.ToInt32(ls.Text);
                    }break;
            }
            if (inewMode != SROperation.Instance.DisplayMode)
            {
                SROperation.Instance.DisplayMode = inewMode;
                for (int i = 0; i < this.contextMenuStrip1.Items.Count; i++)
                {
                    ToolStripMenuItem titem = this.contextMenuStrip1.Items[i] as ToolStripMenuItem;
                    if (i == SROperation.Instance.DisplayMode)
                        titem.Checked = true;
                    else
                        titem.Checked = false;
                }
                this.center11.RefreshData();
            }
        }

        public void copyDirectory(string sourceDirectory, string destDirectory)
        {
            //判断源目录和目标目录是否存在，如果不存在，则创建一个目录
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }
            if (!Directory.Exists(destDirectory))
            {
                Directory.CreateDirectory(destDirectory);
            }
            //拷贝文件
            copyFile(sourceDirectory, destDirectory);
            //拷贝子目录 
            //获取所有子目录名称
            string[] directionName = Directory.GetDirectories(sourceDirectory);
            foreach (string directionPath in directionName)
            {
                //根据每个子目录名称生成对应的目标子目录名称
                string directionPathTemp = destDirectory + "\\" + directionPath.Substring(sourceDirectory.Length + 1);
                //递归下去
                copyDirectory(directionPath, directionPathTemp);
            }
        }

        public void copyFile(string sourceDirectory, string destDirectory)
        {
            //获取所有文件名称
            string[] fileName = Directory.GetFiles(sourceDirectory);
            foreach (string filePath in fileName)
            {
                //根据每个文件名称生成对应的目标文件名称
                string filePathTemp = destDirectory + "\\" + filePath.Substring(sourceDirectory.Length + 1);
                //若不存在，直接复制文件；若存在，覆盖复制
                if (File.Exists(filePathTemp))
                {
                    File.Copy(filePath, filePathTemp, true);
                }
                else
                {
                    File.Copy(filePath, filePathTemp);
                }
                ++SROperation2.Instance.entListReadyCount;
            }
        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            //需要进行特殊处理的控件KeyPress事件处理
            //左边栏
            if (this.left1.ContainsFocus)
            {
                switch (e.KeyChar.ToString().ToUpper())
                {
                    case "F":
                        {
                            this.left1.ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = "展开下列所有节目" }, new EventArgs());
                        }
                        break;
                    case "G":
                        {
                            if (ModifierKeys == Keys.Control)
                            {
                                this.left1.ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = "关闭所有" }, new EventArgs());
                            }
                            else
                            {
                                this.left1.ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = "关闭下列所有节目" }, new EventArgs());
                            }
                        }
                        break;
                    default:
                        break;
                }
                return;
            }
            //图片展示区
            if (this.center11.ContainsFocus)
            {
                switch (e.KeyChar.ToString().ToUpper())
                {
                    case "M":
                        {
                            ToolStripMenuItem_Click(图像蓝子ToolStripMenuItem, e);
                        }
                        break;
                    case "Q":
                        {
                            ToolStripMenuItem_Click(资源ToolStripMenuItem, e);
                        }
                        break;
                    case "W":
                        {
                            ToolStripMenuItem_Click(公共资源与研发ToolStripMenuItem, e);
                        }
                        break;
                    case "E":
                        {
                            ToolStripMenuItem_Click(个人收藏ToolStripMenuItem, e);
                        }
                        break;
                    case "Y":
                        {
                            if (ModifierKeys == Keys.Shift)
                            {
                                ToolStripMenuItem_Click(操作过滤面板ToolStripMenuItem, e);
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            //右边栏
            if (this.right1.ContainsFocus)
            {
                switch (e.KeyChar.ToString().ToUpper())
                {
                    case "F":
                        {
                            this.right1.ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = "展开下列所有节目" }, new EventArgs());
                        }
                        break;
                    case "G":
                        {
                            if (ModifierKeys == Keys.Control)
                            {
                                this.right1.ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = "关闭所有" }, new EventArgs());
                            }
                            else
                            {
                                this.right1.ToolStripMenuItem_Click(new ToolStripMenuItem() { Text = "关闭下列所有节目" }, new EventArgs());
                            }
                        }
                        break;
                    default:
                        break;
                }
                return;
            }
            //
            switch (e.KeyChar.ToString().ToUpper())
            {
                case "1":
                    {
                        ToolStripMenuItem_Click(按标记时间排列ToolStripMenuItem, e);
                    }
                    break;
                case "2":
                    {
                        ToolStripMenuItem_Click(按使用次数排列ToolStripMenuItem, e);
                    }
                    break;
                case "3":
                    {
                        ToolStripMenuItem_Click(按修改时间排列ToolStripMenuItem, e);
                    }
                    break;
                case "4":
                    {
                        ToolStripMenuItem_Click(按文件大小排列ToolStripMenuItem, e);
                    }
                    break;
                case "5":
                    {
                        ToolStripMenuItem_Click(按文件名称排列ToolStripMenuItem, e);
                    }
                    break;
                default:
                    break;
            }
        }

        private void FrmMain_MouseUp(object sender, MouseEventArgs e)
        {
            ;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SROperation.Instance.SplitContainer1SplitterDistance = this.splitContainer1.SplitterDistance;
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SROperation.Instance.SplitContainer2SplitterDistance = this.splitContainer2.SplitterDistance;
        }

        private void splitContainer3_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SROperation.Instance.SplitContainer3SplitterDistance = this.splitContainer3.SplitterDistance;
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            SROperation.Instance.WindowWidth = this.Size.Width;
            SROperation.Instance.WindowHeight = this.Size.Height;
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                this.CtrlIsOk = true;
            }
        }

        private void FrmMain_KeyUp(object sender, KeyEventArgs e)
        {
            this.CtrlIsOk = false;
        }

        private void left1_Click(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Left";
        }

        private void right1_Click(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Right";
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            ProcessHelper.DelNetUse();
        }

        private void SetWaitPic()
        {
            FrmFrame ff = new FrmFrame() { Width = 284, Height = 258, Text = "正在复制，请稍后..." };
            ControlLibrary.Control.WaitPic wp = new ControlLibrary.Control.WaitPic();
            ff.SetUserControl(wp);
            ff.Show();
            while (SROperation2.Instance.isLoading)
            {
                wp.SetReadCount();
                ff.Refresh();
            }            
        }
        private void SetWaitPic2()
        {
            FrmFrame ff = new FrmFrame() { Width = 213, Height = 200, Text = "正在删除，请稍后..." };
            ControlLibrary.Control.WaitPic2 wp2 = new ControlLibrary.Control.WaitPic2();
            ff.SetUserControl(wp2);
            ff.Show();
            while (SROperation2.Instance.isLoading)
            {                
                ff.Refresh();
            }
        }
        /// <summary>
        /// 图片加载，如果直接在需要图片时启动线程，会导致拖动过快时线程过多死机。所以用BlockingCollection来处理
        /// </summary>
        public void BlockingCollectionInit()
        {
            int count = Convert.ToInt32(SRConfig.Instance.GetAppString("BlockingCollectionTakeThreadNum"));
            
            Thread[] threads = new Thread[count];
            while (true)
            {
                if ((SROperation2.Instance.Center1ImageBlockingCollection.Count != 0
                    || SROperation2.Instance.Center2ImageBlockingCollection.Count != 0))
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (threads[i] == null || threads[i].ThreadState == ThreadState.Stopped)
                        {
                            threads[i] = new Thread(new ThreadStart(BlockingCollectinoTake));
                            threads[i].Start();
                        }
                    }
                }
                Thread.Sleep(100);
            }
        }
        public void BlockingCollectinoTake()
        {
            KeyValuePair<string,string> kv;
            try
            {
                while (SROperation2.Instance.Center1ImageBlockingCollection.Count != 0
                    || SROperation2.Instance.Center2ImageBlockingCollection.Count != 0)
                {
                    if (SROperation2.Instance.Center1ImageBlockingCollection.TryTake(out kv))
                    {

                        using (new IdentityScope(Param.ServerIP.Description,
                           Param.ServerIP.Remark,
                           Param.ServerIP.Title))
                        {
                            Image image = Image.FromFile(kv.Value);
                            MemoryStream ms = new MemoryStream();
                            image.Save(ms, image.RawFormat);
                            if (ms == null) return;
                            image = Image.FromStream(ms);
                            GC.Collect();
                            SROperation2.Instance.Center1ImageDict.Add(kv.Key, image);
                            this.center11.Invoke(new Center1.SetImageListDelegate(center11.SetImageList), kv.Key, image);
                        }
                    }

                    if (SROperation2.Instance.Center2ImageBlockingCollection.TryTake(out kv))
                    {

                        using (new IdentityScope(Param.ServerIP.Description,
                           Param.ServerIP.Remark,
                           Param.ServerIP.Title))
                        {
                            Image image = Image.FromFile(kv.Value);
                            MemoryStream ms = new MemoryStream();
                            image.Save(ms, image.RawFormat);
                            if (ms == null) return;
                            image = Image.FromStream(ms);
                            GC.Collect();
                            SROperation2.Instance.Center2ImageDict.Add(kv.Key, image);
                            this.center21.Invoke(new Center2.SetImageListDelegate(center21.SetImageList), kv.Key, image);
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                SRLogHelper.Instance.AddLog("异常", "FrmMain", "BlockingCollectionInit", ex.Message);
            }
        }

        private void menuStrip1_VisibleChanged(object sender, EventArgs e)
        {
            if(this.menuStrip1.Visible)
            {
                if(Param.GroupId > 2)
                {
                    this.新建文件夹ToolStripMenuItem.Available = false;
                    this.重命名ToolStripMenuItem.Available = false;
                    this.删除ToolStripMenuItem.Available = false;
                    this.toolStripSeparator7.Available = false;
                }
            }
        }
    }
}
