using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ORM;
using SirdRoom.ManageSystem.ClientApplication;

namespace ControlLibrary.Control
{
    public partial class Center1ShowFilterByKeywordSetting : UserControl
    {        
        public Center1ShowFilterByKeywordSetting()
        {
            InitializeComponent();
            SROperation2.Instance.isFilterKeywordChanged = false;
        }

        private void Center1ShowFilterByKeywordSetting_Load(object sender, EventArgs e)
        {
            //初始化过滤关键字列表
            SR_UserSettingEntity userSettingEnt = DataBase.Instance.tSR_UserSetting.Get_Entity(Param.UserId);            
            if(userSettingEnt != null)
            {
                string DefaultKeyword = userSettingEnt.DefaultKeyword;
                if(!string.IsNullOrEmpty(DefaultKeyword))
                {
                    List<SRRC_BiaojiEntity> keywordEntList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollectionBySQL(
                        String.Format(@"select * from SRRC_Biaoji where id in ({0}) and isShowKeyword=1", DefaultKeyword));
                    if(keywordEntList != null)
                    {
                        foreach (var item in keywordEntList)
                        {
                            listBox_Exsit.Items.Add(new ListItem { key = item.Id, Value = item.Name });
                        }
                    }
                }
            }

            //初始化TabControl
            {
                //Favorites
                this.tv_Favorites.ImageList = new ImageList();
                this.tv_Favorites.ImageList.Images.Add("isKeyword",SirdRoom.ManageSystem.ClientApplication.Properties.Resources.keywordFilter);
                this.tv_Favorites.ImageList.Images.Add("default", SirdRoom.ManageSystem.ClientApplication.Properties.Resources._default);
                this.tv_Favorites.Nodes.Clear();
                List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(new OrderCollection<SRRC_BiaojiEntity.FiledType>() {
                                                        new Order<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.OrderNum,OrderType.Asc)}, " User_id=[$userid$] and isShowKeyword=1",new DataParameter("userid", Param.UserId));
                if (entList != null)
                {
                    foreach (var item in entList.Where(m => m.Pid == 0))
                    {
                        TreeNode newNode = new TreeNode()
                        {
                            Text = item.Name,
                            Tag = item,
                            Name = item.Id.ToString(),
                            ImageKey = item.isShowKeyword ? "isKeyword" : "default",
                            SelectedImageKey = item.isShowKeyword ? "isKeyword" : "default"
                        };
                        this.tv_Favorites.Nodes.Add(newNode);
                        AddNodeData2(newNode, entList, item.Id);
                    }
                }
                //Study
                //if(Param.GroupId <=2)
                //{
                    this.tv_Study.ImageList = new ImageList();                    
                    this.tv_Study.ImageList.Images.Add("isKeyword",SirdRoom.ManageSystem.ClientApplication.Properties.Resources.keywordFilter);
                    this.tv_Study.ImageList.Images.Add("default", SirdRoom.ManageSystem.ClientApplication.Properties.Resources._default);
                    this.tv_Study.Nodes.Clear();
                    entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(new OrderCollection<SRRC_BiaojiEntity.FiledType>() {
                                                        new Order<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.OrderNum,OrderType.Asc)}, " User_id=0 and isShowKeyword=1");
                    if (entList != null)
                    {
                        foreach (var item in entList.Where(m => m.Pid == 0))
                        {
                            TreeNode newNode = new TreeNode()
                            {
                                Text = item.Name,
                                Tag = item,
                                Name = item.Id.ToString(),
                                ImageKey = item.isShowKeyword ? "isKeyword" : "default",
                                SelectedImageKey = item.isShowKeyword ? "isKeyword" : "default"
                            };
                            this.tv_Study.Nodes.Add(newNode);
                            AddNodeData2(newNode, entList, item.Id);
                        }
                    }
                //}
                //else
                //{
                //    this.tabControl.TabPages.Remove(this.tp_Study);
                //}
            }
        }

        void AddNodeData2(TreeNode pnode, List<SRRC_BiaojiEntity> allEntList, Int32 pid)
        {
            if (allEntList.Any(m => m.Pid == pid) == false)
                return;
            IEnumerable<SRRC_BiaojiEntity> entList = allEntList.Where(m => m.Pid == pid);
            foreach (var item in entList)
            {
                TreeNode newNode = new TreeNode()
                {
                    Text = item.Name,
                    Tag = item,
                    Name = item.Id.ToString(),
                    ImageKey = item.isShowKeyword ? "isKeyword" : "default",
                    SelectedImageKey = item.isShowKeyword ? "isKeyword" : "default"
                };
                pnode.Nodes.Add(newNode);
                this.AddNodeData2(newNode, allEntList, item.Id);
            }
        }

        private void btn_添加_Click(object sender, EventArgs e)
        {
            TreeNode node = null;
            switch(this.tabControl.SelectedIndex)
            {
                case 0://favorites
                    node = this.tv_Favorites.SelectedNode;
                    break;
                case 1://study
                    node = this.tv_Study.SelectedNode;
                    break;
                default:
                    break;
            }
            if(node != null)
            {
                SRRC_BiaojiEntity ent = node.Tag as SRRC_BiaojiEntity;
                ListItem item = new ListItem{key=ent.Id,Value=ent.Name};
                if(!this.listBox_Exsit.Items.Contains(item))
                {
                    if(!ent.isShowKeyword)
                    {
                        ent.isShowKeyword = true;
                        DataBase.Instance.tSRRC_Biaoji.Update(ent);
                        node.ImageKey = "isKeyword";
                    }
                    this.listBox_Exsit.Items.Add(item);

                    SR_UserSettingEntity userSettingEnt = DataBase.Instance.tSR_UserSetting.Get_Entity(Param.UserId);
                    if(userSettingEnt == null)
                    {
                        userSettingEnt = new SR_UserSettingEntity { UserId = Param.UserId };                        
                        userSettingEnt.DefaultKeyword = "" + ent.Id;
                        DataBase.Instance.tSR_UserSetting.Add(userSettingEnt);
                    }
                    else
                    {
                        userSettingEnt.DefaultKeyword = (userSettingEnt.DefaultKeyword + "," + ent.Id).TrimStart(',');
                        DataBase.Instance.tSR_UserSetting.Update(userSettingEnt);
                    }
                    SROperation2.Instance.isFilterKeywordChanged = true;
                    Param.filterkeyword = userSettingEnt.DefaultKeyword;
                }
            }

        }

        private void btn_删除_Click(object sender, EventArgs e)
        {
            if(this.listBox_Exsit.SelectedItem != null)
            {
                ListItem item = this.listBox_Exsit.SelectedItem as ListItem;
                this.listBox_Exsit.Items.Remove(this.listBox_Exsit.SelectedItem);
                SR_UserSettingEntity userSettingEnt = DataBase.Instance.tSR_UserSetting.Get_Entity(Param.UserId);
                userSettingEnt.DefaultKeyword = string.Format(",{0},", userSettingEnt.DefaultKeyword).Replace("," + item.key + ",", ",").Trim(',');
                DataBase.Instance.tSR_UserSetting.Update(userSettingEnt);
                SROperation2.Instance.isFilterKeywordChanged = true;
                Param.filterkeyword = userSettingEnt.DefaultKeyword;
            }
        }

        private void listBox_Exsit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem item = (sender as ListBox).SelectedItem as ListItem;
            if(item != null)
            {
                SRRC_BiaojiEntity ent = DataBase.Instance.tSRRC_Biaoji.Get_Entity(item.key);
                if(ent != null)
                {
                    if(ent.User_id == 0) //study
                    {
                        this.tabControl.SelectedTab = this.tp_Study;
                        TreeNode[] nodes = this.tv_Study.Nodes.Find(ent.Id.ToString(), true);
                        if(nodes != null && nodes.Length > 0)
                        {
                            var node = nodes[0];
                            //this.tv_Study.SelectedNode = node;
                            node.EnsureVisible();
                            node.BackColor = Color.BlueViolet;
                        }
                    }
                    else//favorites
                    {
                        this.tabControl.SelectedTab = this.tp_Favorites;
                        TreeNode[] nodes = this.tv_Favorites.Nodes.Find(ent.Id.ToString(), true);
                        if (nodes != null && nodes.Length > 0)
                        {
                            var node = nodes[0];
                            //this.tv_Favorites.SelectedNode = node;
                            node.EnsureVisible();
                            node.BackColor = Color.BlueViolet;
                        }
                    }
                }
            }
        }
    }

    public class ListItem
    {
        public int key { get; set; }
        public string Value { get; set; }
        public override string ToString()
        {
            return Value;
        }
    }
}
