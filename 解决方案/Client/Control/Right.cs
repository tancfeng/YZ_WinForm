using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ORM;
using System.IO;
using SirdRoom;
using SirdRoom.ManageSystem.ClientApplication;
using SirdRoom.ManageSystem.Library.Data;

namespace ControlLibrary.Control
{
    public partial class Right : UserControl
    {   
        //定义委托
        public delegate void PageClickHandle(object sender, MyEventArgs e);
        //定义事件
        public event PageClickHandle OnPageClicked;
        public Right()
        {
            InitializeComponent();
            this.keyword1.OnPageClicked += keyword1_OnPageClicked;

            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());
            this.treeView1.StateImageList = SROperation2.Instance.CheckBoxImageList;
            this.treeView1.ImageList = imageList1;
        }

        void keyword1_OnPageClicked(object sender, MyEventArgs e)
        {
            if (OnPageClicked != null)
            {
                OnPageClicked(sender, e);//把按钮自身作为参数传递
            }
        }

        //String lblSelected = "Study";
        private void lblButtom1_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            SROperation.Instance.RightDtype = lbl.Name;
            this.Keyword.BackColor = this.Study.BackColor = this.Favorites.BackColor = Color.FromArgb(54, 54, 54);
            switch (lbl.Text)
            {
                case "Keyword":
                    this.treeView1.AllowDrop = false;
                    this.comboBox1.Visible = true;
                    this.Keyword.BackColor = Color.FromArgb(100, 143, 178);
                    break;
                case "Study":
                    this.treeView1.AllowDrop = false;
                    this.comboBox1.Visible = false;
                    this.Study.BackColor = Color.FromArgb(100, 143, 178);
                    break;
                case "Favorites":
                    this.treeView1.AllowDrop = false;
                    this.comboBox1.Visible = false;
                    this.Favorites.BackColor = Color.FromArgb(100, 143, 178);
                    break;
                default:
                    break;
            }
            this.SetTreeview();
            //设置选中状态
            if (this.FindForm() is FrmFrame)//弹出框
            {
                SetBiaoJiStatusByString(SROperation2.Instance.BrowserPicId.ToString());
            }
            else
            {
                if (SROperation2.Instance.PicSelected != null && SROperation2.Instance.PicSelected.Count > 0)
                {//有选择项，使用选择项
                    SetBiaoJiSatus(SROperation2.Instance.PicSelected);
                }
                else
                {//无选择项，使用查询结果
                    SetBiaoJiSatus(SROperation2.Instance.Center1EntList);
                }
            }
        }
        void SetTreeview()
        {
            switch (SROperation.Instance.RightDtype)
            {
                case "Keyword":
                    {
                        this.treeView1.Visible = false;
                        this.keyword1.Visible = true;
                        this.comboBox1.Visible = true;
                        if (this.label1.Text == "" || this.label1.Text != SROperation.Instance.RightDtype)
                        {
                            this.label1.Text = SROperation.Instance.RightDtype;
                            this.keyword1.BindData();
                        }
                    }
                    return;
                case "Study":
                    {
                        this.treeView1.Visible = true;
                        this.keyword1.Visible = false;
                        this.comboBox1.Visible = false;
                        if(this.label1.Text == "" || this.label1.Text != SROperation.Instance.RightDtype)
                        { //
                            this.label1.Text = SROperation.Instance.RightDtype;
                            this.treeView1.Nodes.Clear();
                            List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(new OrderCollection<SRRC_BiaojiEntity.FiledType>() {
                                                        new Order<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.OrderNum,OrderType.Asc)}, " User_id=0 ");
                            if (entList != null)
                            {
                                foreach (var item in entList.Where(m => m.Pid == 0))
                                {
                                    TreeNode newNode = new TreeNode() { Text = item.Name, Tag = item, Name = item.Id.ToString(), ImageKey = item.Img, SelectedImageKey = item.Img };
                                    this.treeView1.Nodes.Add(newNode);
                                    AddNodeData2(newNode, entList, item.Id);
                                }
                            }
                        }                        
                    }
                    break;
                case "Favorites":
                    {
                        this.treeView1.Visible = true;
                        this.keyword1.Visible = false;
                        this.comboBox1.Visible = false;
                        if (this.label1.Text == "" || this.label1.Text != SROperation.Instance.RightDtype)
                        {
                            this.label1.Text = SROperation.Instance.RightDtype;
                            this.treeView1.Nodes.Clear();
                            List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(new OrderCollection<SRRC_BiaojiEntity.FiledType>() {
                                                        new Order<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.OrderNum,OrderType.Asc)}, " User_id=" + Param.UserId);
                            if (entList != null)
                            {
                                foreach (var item in entList.Where(m => m.Pid == 0))
                                {
                                    TreeNode newNode = new TreeNode() { Text = item.Name, Tag = item, Name = item.Id.ToString(), ImageKey = item.Img, SelectedImageKey = item.Img };
                                    this.treeView1.Nodes.Add(newNode);
                                    AddNodeData2(newNode, entList, item.Id);
                                }
                            }
                        }
                    }
                    break;
            }
            this.treeView1.ForeColor = Color.White;
            //this.treeView1.ExpandAll();
        }
        /// <summary>
        /// 根据ID，设置treeview
        /// </summary>
        /// <param name="idS">id字符串</param>
        public void SetBiaoJiStatusByString(string idS)
        {
            if (String.IsNullOrEmpty(idS)) return;
            int count = idS.Split(',').Length;
            // List<SRRC_BiaojiEntity> checkedEntList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null, " Id in (select Biaoji_id from SRRC_Resourcebiaojirel where Resource_id in (" + idS + "))");
            string sql = String.Format(@"select ta.Id,tb.count from SRRC_Biaoji as ta inner join
                            (SELECT Biaoji_id,COUNT(*) as count
                            FROM [SRRC_Resourcebiaojirel]
                            where Resource_id in ({0})
                            group by Biaoji_id) as tb
                            on ta.id = tb.Biaoji_id", idS);
            DataTable dt = DataBaseHelper.Instance.Helper.ExecuteQuery(CommandType.Text, sql);
            // SetTreeview();
            //清除已设置标记状态
            SetTreeNodeCheckStatus(this.treeView1.Nodes, false);
            if (dt == null || dt.Rows.Count == 0) return;
            
            foreach(DataRow dr in dt.Rows)
            {
                TreeNode[] tns = this.treeView1.Nodes.Find(dr["Id"].ToString(), true);
                if (tns != null && tns.Length > 0)
                {
                    //if (Convert.ToInt32(dr["count"]) == count)//共有属性
                    //{
                    //    tns[0].Checked = true;
                    //}
                    //else
                    //{
                    //    tns[0].StateImageIndex = 2;//非共有属性
                    //}
                    tns[0].Checked = true;
                }
            }
        }
        private void SetTreeNodeCheckStatus(TreeNodeCollection tnCollection,bool status)
        {
            foreach(TreeNode tn in tnCollection)
            {
                tn.Checked = status;
                if (tn.Nodes != null)
                {
                    SetTreeNodeCheckStatus(tn.Nodes, status);
                }
            }            
        }
        public void SetBiaoJiSatus(List<SRRC_ResourceEntity> entList)
        {
            if (entList == null || entList.Count == 0)
            {
                this.SetTreeview();
                return;
            }
            string str = "";            
            foreach(SRRC_ResourceEntity ent in entList)
            {
                str += ent.Id + ",";
            }
            SetBiaoJiStatusByString(str.Trim(','));
        }
        void AddNodeData2(TreeNode pnode, List<SRRC_BiaojiEntity> allEntList, Int32 pid)
        {
            if (allEntList.Any(m => m.Pid == pid) == false)
                return;
            IEnumerable<SRRC_BiaojiEntity> entList = allEntList.Where(m => m.Pid == pid);
            foreach (var item in entList)
            {
                TreeNode newNode = new TreeNode() { Text = item.Name, Tag = item, Name = item.Id.ToString(), ImageKey = item.Img, SelectedImageKey = item.Img };
                pnode.Nodes.Add(newNode);
                this.AddNodeData2(newNode, allEntList, item.Id);
            }
        }


        private void Left_Load(object sender, EventArgs e)
        {
            
        }

        //定义委托
        public delegate void PageAfterHandle(object sender, TreeViewEventArgs e);
        //定义事件
        public event PageAfterHandle OnPageAftered;

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {            
            if (OnPageAftered != null && e.Action != TreeViewAction.Unknown)
            {
                OnPageAftered(sender, e);
            }
        }
        /// <summary>
        /// 得到已选中Id
        /// </summary>
        /// <param name="ilevel"></param>
        /// <returns></returns>
        Int32 GetLeftTreeviewSelectedId()
        {
            Int32 id = 0;
            if (this.treeView1.SelectedNode == null) return id;
            try
            {
                id = (this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity).Id;
            }
            catch (Exception)
            {
            }
            return id;
        }
        private void 新建ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int  itreeid = this.GetLeftTreeviewSelectedId();
            FrmFrame frm = new FrmFrame() { StartPosition = FormStartPosition.CenterScreen, Text = "添加", Width = 319, Height = 174 };
            Param.DPageParameter = "";
            frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.Wordbook.Add() { Name = "Add" });
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(Param.DPageParameter) == false)
                {
                    String[] arrls = Param.DPageParameter.Split(new char[] { '|' });
                    string guid = Guid.NewGuid().ToString();
                    SRRC_BiaojiEntity ent = new SRRC_BiaojiEntity() { Addtime = DateTime.Now, Img = arrls[1], Name = arrls[0], User_id = SROperation.Instance.RightDtype == "Study" ? 0 : Param.UserId, Pid = itreeid, Code = guid, isShowKeyword = true, isShowPanel = true, isShowUserPanel = true, Hide = true };
                    if (itreeid > 0)
                    {
                        ent.Topid = (this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity).Topid == 0 ? (this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity).Id : (this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity).Topid;
                    }

                    SRRC_BiaojiEntity ent1 = DataBase.Instance.tSRRC_Biaoji.Get_Entity(
                        new KeyValueCollection<SRRC_BiaojiEntity.FiledType>() { new KeyValue<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.Pid,itreeid)},
                        new OrderCollection<SRRC_BiaojiEntity.FiledType>() { new Order<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.OrderNum,OrderType.Desc)}
                        );
                    ent.OrderNum = ent1 == null ? 0 : ent1.OrderNum + 1;
                    DataBase.Instance.tSRRC_Biaoji.Add(ent);
                    ent = DataBase.Instance.tSRRC_Biaoji.Get_Entity(guid);
                    
                    if (itreeid ==0)
                        this.treeView1.Nodes.Add(new TreeNode() { Tag = ent, Text = arrls[0], Name = ent.Id.ToString(), ImageKey = arrls[1], SelectedImageKey = arrls[1] });
                    else
                        this.treeView1.SelectedNode.Nodes.Add(new TreeNode() { Tag = ent, Text = arrls[0], Name = ent.Id.ToString(), ImageKey = arrls[1], SelectedImageKey = arrls[1] });
                }
            }
        }

        private void 修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int itreeid = this.GetLeftTreeviewSelectedId();
            if (itreeid <= 0)
            {
                new SRFMessageBox("请选择要修改的节点！", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }
            FrmFrame frm = new FrmFrame() { StartPosition = FormStartPosition.CenterScreen, Text = "修改", Width = 319, Height = 174 };
           SRRC_BiaojiEntity ent = DataBase.Instance.tSRRC_Biaoji.Get_Entity(itreeid);
            Param.DPageParameter =
                String.Format("{0}|{1}", ent.Name, ent.Img);
            frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.Wordbook.Add() { Name = "Add" });
            if (frm.ShowDialog() == DialogResult.OK)
            {
                if (String.IsNullOrEmpty(Param.DPageParameter) == false)
                {
                    String[] arrls = Param.DPageParameter.Split(new char[] { '|' });
                    DataBase.Instance.tSRRC_Biaoji.Update(
                        new KeyValueCollection<SRRC_BiaojiEntity.FiledType>() {
                        new KeyValue<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.Name, arrls[0]) ,
                        new KeyValue<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.Img, arrls[1]) 
                        },
                        " Id=[$Id$] ", new DataParameter("Id", itreeid));
                    this.treeView1.SelectedNode.Text = arrls[0];
                    this.treeView1.SelectedNode.ImageKey = this.treeView1.SelectedNode.SelectedImageKey = arrls[1];
                }
            }
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int itreeid = 0;
            itreeid = this.GetLeftTreeviewSelectedId();
            if (itreeid<=0)
            {
                new SRFMessageBox("请选择要删除的子区！", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }
            if (this.treeView1.SelectedNode.Nodes != null && this.treeView1.SelectedNode.Nodes.Count > 0)
            {
                new SRFMessageBox("该节点下有子节点，不能被删除！", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            }
            if (new SRFMessageBox("确认删除此子区？", "提示", MessageBoxButtons.YesNo).ShowDialog() != System.Windows.Forms.DialogResult.Yes)
            {
                return;
            }
            DataBase.Instance.tSRRC_Biaoji.Delete(itreeid);
            this.treeView1.SelectedNode.Remove();
        }

        private void picTitleTool1_Click(object sender, EventArgs e)
        {
            if (OnPageClicked != null)
            {
                OnPageClicked(sender, new MyEventArgs() { Action = 0 });//把按钮自身作为参数传递
            }
        }

        public void BindData()
        {            
            if (Param.GroupId > 2) //员工及客户
            {
                this.Study.Visible = false;
                if(SROperation.Instance.RightDtype == "Study")
                {
                    SROperation.Instance.RightDtype = "Favorites";
                }
                if(Param.GroupId == 4) //客户
                {
                    this.Favorites.Visible = false;
                    SROperation.Instance.RightDtype = "Keyword";
                }
            }

            foreach (KeyValuePair<string,Image> item in SROperation.Instance.IconList)
            {
                this.imageList1.Images.Add(item.Key, item.Value);
            }
            //设置关键字关系下拉列表，并绑定选项改变事件。
            this.comboBox1.SelectedIndexChanged -= new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            switch (SROperation.Instance.RightDtype)
            {
                case "Keyword":
                    this.lblButtom1_Click(this.Keyword, new EventArgs());
                    break;
                case "Study":
                    this.lblButtom1_Click(this.Study, new EventArgs());
                    break;
                case "Favorites":
                    this.lblButtom1_Click(this.Favorites, new EventArgs());
                    break;
                default: break;
            }
        }
        public void RefreshKeyword()
        {
            if(SROperation.Instance.RightDtype == "Keyword")
            {
                this.keyword1.BindData();
            }
        }

        public void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;
            switch (obj.Text)
            {
                case "展开下列所有节目":
                    {
                        if (this.treeView1.SelectedNode != null)
                        {
                            this.treeView1.SelectedNode.ExpandAll();
                        }
                        else
                        {
                            this.treeView1.ExpandAll();
                        }
                    }
                    break;
                case "关闭下列所有节目":
                    {
                        if (this.treeView1.SelectedNode != null)
                        {
                            this.treeView1.SelectedNode.Collapse();
                        }
                        else
                        {
                            this.treeView1.CollapseAll();
                        }
                    }
                    break;
                case "关闭所有":
                    {
                        this.treeView1.CollapseAll();
                    }
                    break;
                case "向上排列":
                    {
                        if (this.treeView1.Visible == true && this.treeView1.SelectedNode != null)
                        {
                            if (this.treeView1.SelectedNode.PrevNode == null) return;
                            SRRC_BiaojiEntity cur = this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity;
                            SRRC_BiaojiEntity prev = this.treeView1.SelectedNode.PrevNode.Tag as SRRC_BiaojiEntity;
                            int prevOrder = prev.OrderNum;
                            prev.OrderNum = cur.OrderNum;
                            cur.OrderNum = prevOrder;
                            DataBase.Instance.tSRRC_Biaoji.Update(prev);
                            DataBase.Instance.tSRRC_Biaoji.Update(cur);
                            this.treeView1.SelectedNode.Tag = cur;
                            this.treeView1.SelectedNode.PrevNode.Tag = prev;
                            var Node = this.treeView1.SelectedNode;
                            var index = this.treeView1.SelectedNode.PrevNode.Index;
                            if (this.treeView1.SelectedNode.Parent == null)
                            {
                                this.treeView1.Nodes.Remove(this.treeView1.SelectedNode);
                                this.treeView1.Nodes.Insert(index, Node);  
                            }
                            else
                            {
                                this.treeView1.SelectedNode.Parent.Nodes.Remove(this.treeView1.SelectedNode);
                                this.treeView1.SelectedNode.Parent.Nodes.Insert(index, Node);  
                            }                          
                        }
                    }
                    break;
                case "向下排列":
                    {
                        if (this.treeView1.Visible == true && this.treeView1.SelectedNode != null)
                        {
                            if (this.treeView1.SelectedNode.NextNode == null) return;
                            SRRC_BiaojiEntity cur = this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity;
                            SRRC_BiaojiEntity next = this.treeView1.SelectedNode.NextNode.Tag as SRRC_BiaojiEntity;
                            int nextOrder = next.OrderNum;
                            next.OrderNum = cur.OrderNum;
                            cur.OrderNum = nextOrder;
                            DataBase.Instance.tSRRC_Biaoji.Update(next);
                            DataBase.Instance.tSRRC_Biaoji.Update(cur);
                            this.treeView1.SelectedNode.Tag = cur;
                            this.treeView1.SelectedNode.NextNode.Tag = next;
                            var Node = this.treeView1.SelectedNode;
                            var index = this.treeView1.SelectedNode.NextNode.Index;
                            if (this.treeView1.SelectedNode.Parent == null)
                            {
                                this.treeView1.Nodes.Remove(this.treeView1.SelectedNode);
                                this.treeView1.Nodes.Insert(index, Node);  
                            }
                            else
                            {
                                this.treeView1.SelectedNode.Parent.Nodes.Remove(this.treeView1.SelectedNode);
                                this.treeView1.SelectedNode.Parent.Nodes.Insert(index, Node);  
                            }
                        }
                    }
                    break;
                case "用户面板不显示":
                    {
                        if (this.treeView1.Visible == true && this.treeView1.SelectedNode != null)
                        {
                            SRRC_BiaojiEntity ent = this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity;
                            obj.Checked = !obj.Checked;
                            ent.isShowUserPanel = !obj.Checked;
                            DataBase.Instance.tSRRC_Biaoji.Update(ent);
                        }
                    }
                    break;
                case "面板不显示":
                    {
                        if (this.treeView1.Visible == true && this.treeView1.SelectedNode != null)
                        {
                            SRRC_BiaojiEntity ent = this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity;
                            obj.Checked = !obj.Checked;
                            ent.isShowPanel = !obj.Checked;
                            DataBase.Instance.tSRRC_Biaoji.Update(ent);
                        }
                    }
                    break;
                case "智能关键字不显示":
                    {
                        if (this.treeView1.Visible == true && this.treeView1.SelectedNode != null)
                        {
                            SRRC_BiaojiEntity ent = this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity;
                            obj.Checked = !obj.Checked;
                            ent.isShowKeyword = !obj.Checked;
                            DataBase.Instance.tSRRC_Biaoji.Update(ent);
                        }
                    }
                    break;
                default:
                    break;
            }            
        }

        private void keyword1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.F:
                    {
                        ToolStripMenuItem_Click(展开下列所有节目ToolStripMenuItem, e);
                    }
                    break;
                case Keys.G:
                    {
                        ToolStripMenuItem_Click(关闭下列所有节目ToolStripMenuItem, e);
                    }
                    break;
                default:
                    break;
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            SetTreeview();
        }

        private void contextMenuStrip1_VisibleChanged(object sender, EventArgs e)
        {
            if(contextMenuStrip1.Visible)
            {
                if (this.treeView1.Visible == false)
                {
                    this.toolStripSeparator1.Visible = false;
                    this.修改ToolStripMenuItem.Visible = false;
                    this.新建ToolStripMenuItem.Visible = false;
                    this.删除ToolStripMenuItem.Visible = false;

                    this.toolStripSeparator2.Visible = false;
                    this.向上排列ToolStripMenuItem.Visible = false;
                    this.向下排列ToolStripMenuItem.Visible = false;

                    this.toolStripSeparator3.Visible = false;
                    this.智能关键字不显示ToolStripMenuItem.Visible = false;
                    this.用户面板不显示ToolStripMenuItem.Visible = false;
                    this.面板不显示ToolStripMenuItem.Visible = false;
                }
                else if (this.treeView1.SelectedNode == null) //未选择结点
                {
                    this.toolStripSeparator2.Visible = false;
                    this.向上排列ToolStripMenuItem.Visible = false;
                    this.向下排列ToolStripMenuItem.Visible = false;

                    this.toolStripSeparator3.Visible = false;
                    this.智能关键字不显示ToolStripMenuItem.Visible = false;
                    this.用户面板不显示ToolStripMenuItem.Visible = false;
                    this.面板不显示ToolStripMenuItem.Visible = false;
                }
                else//选择了结点
                {
                    SRRC_BiaojiEntity ent = this.treeView1.SelectedNode.Tag as SRRC_BiaojiEntity;
                    this.智能关键字不显示ToolStripMenuItem.Checked = !ent.isShowKeyword;
                    this.面板不显示ToolStripMenuItem.Checked = !ent.isShowPanel;
                    this.用户面板不显示ToolStripMenuItem.Checked = !ent.isShowUserPanel;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SROperation2.Instance.KeywordLogical = this.comboBox1.SelectedItem.ToString();
            if (OnPageClicked != null)
            {
                OnPageClicked(sender, new MyEventArgs() { Action = 5 });
            }
        }

        private void Right_Click(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Right";
        }

        private void Right_Enter(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Right";
        }

        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            if(e.Node.StateImageIndex == 2)
            {
                e.Graphics.DrawLine(new Pen(SystemBrushes.WindowFrame), 19, e.Bounds.Y, 19, e.Bounds.Y+16);
            }
            else
            {
                e.DrawDefault = true;
            }
        }
    }
}