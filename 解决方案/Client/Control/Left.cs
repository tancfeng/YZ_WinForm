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
using System.Drawing.Imaging;
using SirdRoom.ManageSystem.ClientApplication.Control;

namespace ControlLibrary.Control
{
    public partial class Left : UserControl
    {
        BackgroundWorker worker;
        List<SRRC_ResourceEntity> priAddEntList = new List<SRRC_ResourceEntity>();
        List<String> _fileList = new List<string>(); //复制的文件列表
        List<SRRC_ResourceEntity> entList;
        String _strQz = "";//复制的文件列表准备存放的父目录，即拖动文件到Left区域时，TreeNode的选中项，
        String strtree = "0";
        TreeNode pnode = null;
        int fileCount = 0;//需要上传的文件总量
        int index = 0;//已处理的文件数量
        public Left()
        {
            InitializeComponent();
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);

            //设置contextMenuStrip style
            ToolStripProfessionalRenderer pr = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());
            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Renderer = pr;

            contextMenuStrip2.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip2.Renderer = pr;

            contextMenuStrip3.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip3.Renderer = pr;
            contextMenuStrip3.ForeColor = Color.White;
        }
        //TreeNode pnode = null;
        /// <summary> 
        /// 异步 开始事件 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="e"></param> 
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            worker.ReportProgress(0);
            KKCopyList(_fileList, Param.ServerIP, _strQz);
        }
        private void lblButtom1_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl.Text.Equals(SROperation.Instance.LeftDtype) == true)
            {
                return;
            }
            SROperation.Instance.OperationList = "";
            SROperation.Instance.LeftDtype = lbl.Name;

            this.BindData();
        }
         void SetTreeview()
        {
            switch (SROperation.Instance.LeftDtype)
            {
                case "Resources":
                    {
                        this.treeView1.ContextMenuStrip = null;
                        //List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " ServerIp=[$ServerIp$] and Dtype=0 "
                        //    , new DataParameter("ServerIp", Param.ServerIP.Title)
                        //    );
                        //List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL("SELECT * FROM SRRC_Resource WHERE Serverip like '%" + Param.IP + "%' AND Dtype in (0,1)");
                        entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL(@"SELECT ta.[Id],[Addtime],[User_id],[Pid],[Name],ta.[Dtype],[Serverip],[Path],[Extend1],'('+tb.sProperty2+')' as [Extend2],[Extend3],[Bjtime],[Usecount],[Filesize],ta.[Code],[Iscomposite]
                            FROM [SRRC_Resource] as ta
                            left join SMDictionary as tb
                            on ta.Id = tb.iExtend2 WHERE ta.Serverip like '%" + Param.IP + "%' AND ta.Dtype =0");
                        this.treeView1.Nodes.Clear();
                        this.treeView1.Nodes.Add(new TreeNode() { Text = "服务器" + Param.IP, Name = "0", Tag = null, ImageIndex = 2, SelectedImageIndex = 2 });
                        if (entList != null)
                            AddNodeData(this.treeView1.Nodes[0], entList, 0);
                        //设置右键菜单
                        contextMenuStrip1AddItem();
                    }
                    break;
                case "Study":
                    {
                        this.treeView1.ContextMenuStrip = null;
                        string where = " User_id=0 ";
                        if(Param.GroupId >2)//非管理员及主管
                        {
                            where += "AND IsShowUserPanel=1 ";
                        }
                        else
                        {
                            where += "AND IsShowPanel=1 ";
                        }
                        //List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null,where);
                        List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(new OrderCollection<SRRC_BiaojiEntity.FiledType>() {
                                                        new Order<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.OrderNum,OrderType.Asc)}, where);
                        this.treeView1.Nodes.Clear();
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
                    break;
                case "Favorites":
                    {
                        this.treeView1.ContextMenuStrip = null;
                        string where = " User_id=" + Param.UserId + " ";
                        if (Param.GroupId > 2)//非管理员及主管
                        {
                            where += "AND IsShowUserPanel=1 ";
                        }
                        else
                        {
                            where += "AND IsShowPanel=1 ";
                        }
                        //List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(null,where  );
                        List<SRRC_BiaojiEntity> entList = DataBase.Instance.tSRRC_Biaoji.Get_EntityCollection(new OrderCollection<SRRC_BiaojiEntity.FiledType>() {
                                                        new Order<SRRC_BiaojiEntity.FiledType>(SRRC_BiaojiEntity.FiledType.OrderNum,OrderType.Asc)}, where);
                        this.treeView1.Nodes.Clear();
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
                    break;
            }
            this.treeView1.ForeColor = Color.White;
            this.treeView1.CollapseAll();

            TreeNode[] tns = this.treeView1.Nodes.Find(SROperation.Instance.LeftSelectedId.ToString(), true);
            if(tns != null && tns.Length >0)
            {
                tns[0].EnsureVisible();
                tns[0].BackColor = Color.Blue;             
            }
        }
        void AddNodeData(TreeNode pnode, List<SRRC_ResourceEntity> allEntList, Int32 pid)
        {
            if (allEntList == null) return;
            if (allEntList.Any(m => m.Pid == pid) == false)
                return;
            
            IEnumerable<SRRC_ResourceEntity> entList = allEntList.Where(m => m.Pid == pid);
            
            if (SROperation.Instance.LeftShowType == "Cross")
            {
                if (entList.Any(m => m.Dtype == 1) == true) // 图片
                {
                    return;
                }
            }
            foreach (var item in entList.Where(m => m.Dtype == 0))
            {
                TreeNode newNode = new TreeNode() { Text = item.Name + item.Extend1, Tag = item, Name = item.Id.ToString(), ImageIndex = 3, SelectedImageIndex = 3 };
                newNode.ContextMenuStrip = contextMenuStrip1;
                pnode.Nodes.Add(newNode);
                //this.AddNodeData(newNode, allEntList, item.Id);
            }
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

        private void treeView1_DragOver(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.None;
                return;
            }
            e.Effect = DragDropEffects.Copy;
            Point pt = treeView1.PointToClient(new Point(e.X, e.Y));
            TreeNode itemUnder = treeView1.GetNodeAt(pt.X, pt.Y);
            this.treeView1.SelectedNode = itemUnder;
        }

        private void treeView1_DragDrop(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            switch (e.Effect)
            {
                case DragDropEffects.Copy:
                    //MessageBox.Show("Copy");
                    string strQZ = ""; //路径
                    if (this.treeView1.SelectedNode != null)
                    {
                        SROperation.Instance.LeftSelectedId = SRLibFun.StringConvertToInt32(this.treeView1.SelectedNode.Name);
                        if(SROperation.Instance.LeftSelectedId >0)
                        {                            
                            strQZ = (this.treeView1.SelectedNode.Tag as SRRC_ResourceEntity).Path;
                        }
                        else //不可以选择服务器IP
                        {
                            break;
                        }                            
                    }
                    else
                    {
                        break;
                    }
                    _fileList = files.ToList();
                    _strQz = strQZ;
                    worker.RunWorkerAsync();
                    if (this.treeView1.SelectedNode != null)
                    {
                        //pnode = this.treeView1.SelectedNode;
                        //this.treeView1.SelectedNode.Level
                        strtree = "";
                        TreeNode node = this.treeView1.SelectedNode;
                        for (int i = this.treeView1.SelectedNode.Level; i >= 0; i--)
                        {
                            strtree = node.Index + "|" + strtree;
                            if (node.Parent == null) break;
                            node = node.Parent;
                        }
                        strtree = strtree.TrimEnd('|');
                        //this.AddNodeData(this.treeView1.SelectedNode, this.priAddEntList, ipid);
                    }
                    else
                    {
                        //pnode = this.treeView1.Nodes[0];
                        strtree = "0";
                        //this.AddNodeData(this.treeView1.Nodes[0], this.priAddEntList, 0);
                    }
                    //显示进度窗体 
                    FrmFrame frm = new FrmFrame()
                    {
                        Text = "正在上传...",
                        Width = 400,
                        Height = 100,
                    };
                    frm.FormClosed += Frm_FormClosed;
                    MyProgressBar bar = new MyProgressBar(this.worker);
                    frm.SetUserControl(bar);
                    frm.StartPosition = FormStartPosition.CenterScreen;
                    frm.ShowDialog(this);
                    //KKCopyList(files.ToList(), Param.ServerIP, strQZ);
                    break;
                case DragDropEffects.Move:
                    break;
                case DragDropEffects.Link:		// TODO: Need to handle links
                    break;
            }
        }
        /// <summary>
        /// 进度条关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.worker.CancelAsync();
            this.worker.Dispose();
        }

        public void KKCopyList(List<String> sourceList, SR_WordbookEntity ServerIp, String strQZ)
        {
            pnode = new TreeNode();
            if (sourceList == null) return;
            //获取文件个数
            foreach (var item in sourceList)
            {
                if(item.Split(new char[] { '/' })[item.Split(new char[] { '/' }).Length - 1].Contains(".") == true)
                {//文件
                    fileCount++;
                }else
                {
                    //目录,查找目录下的文件
                 fileCount +=  Directory.GetFiles(item, "*.*", SearchOption.AllDirectories).Length;
                }               
            }
            foreach (var item in sourceList)
            {
                //复制及生成缩略图
                this.KKCopy(item, ServerIp, strQZ);
            }
        }
        public void KKCopy(String strSource, SR_WordbookEntity ServerIp, String strQZ)
        {
            //根据选择项的IP切换ServerIP
            Int32 ipid = SROperation.Instance.LeftSelectedId;
            SRRC_ResourceEntity resEnt = DataBase.Instance.tSRRC_Resource.Get_Entity(ipid);
            if(resEnt != null && ServerIp.Title != resEnt.Serverip)
            {
                ServerIp = DataBase.Instance.tSR_Wordbook.Get_Entity("Title=[$serverip$]", new DataParameter("serverip", resEnt.Serverip));
            }

            bool isDir = true;//目录
            if (strSource.Split(new char[] { '/' })[strSource.Split(new char[] { '/' }).Length - 1].Contains(".") == true)
            {
                isDir = false;//非目录
            }
            this.priAddEntList = new List<SRRC_ResourceEntity>();
            String strServerIp = ServerIp.Title;
            
            strServerIp += strQZ;
            Int32 iStart = strSource.Length - strSource.Split(new char[] { '\\' })[strSource.Split(new char[] { '\\' }).Length - 1].Length - 1;

            Int32 iserverStart = strServerIp.Length;
            String StrGratePath = strServerIp + strSource.Substring(iStart);

            using (new IdentityScope(ServerIp.Description,
                ServerIp.Remark,
                ServerIp.Title))
            {
                if (isDir)
                {
                    if (!Directory.Exists(StrGratePath))
                    {
                        Directory.CreateDirectory(StrGratePath);
                    }
                    else //删除
                    {
                        List<SRRC_ResourceEntity> resEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Serverip=[$Serverip$] ", new DataParameter("Serverip", Param.ServerIP.Title));
                        new DirectoryInfo(StrGratePath).Delete(true);
                        string strPids = "";
                        var item = DataBase.Instance.tSRRC_Resource.Get_Entity(" Serverip=[$Serverip$] and Path=[$Path$] ", new DataParameter("Serverip", Param.ServerIP.Title), new DataParameter("Path", StrGratePath.Replace(Param.ServerIP.Title, "")));
                        if(item != null)
                        {
                            strPids += item.Id + ",";
                            GetIds(resEntList, item.Id, ref strPids);
                            if (string.IsNullOrEmpty(strPids) == false)
                            {
                                DataBase.Instance.tSRRC_Resource.Delete(" Id in(" + strPids.TrimEnd(',') + ") ");
                            }
                        }                        
                    }
                    //MessageBox.Show(this, "此目录下已经存在同名文件，请删除后再上传。");
                    //return;
                }
                else //文件
                {
                    //new FileInfo(item.Serverip + item.Path).Delete();
                    if (!File.Exists(StrGratePath))
                    {
                        //new FileInfo(StrGratePath).Delete();
                    }
                    else //删除
                    {
                        new FileInfo(StrGratePath).Delete();
                        DataBase.Instance.tSRRC_Resource.Delete(" Serverip=[$Serverip$] and Path=[$Path$] ", new DataParameter("Serverip", Param.ServerIP.Title), new DataParameter("Path", StrGratePath.Replace(Param.ServerIP.Title, "")));
                    }
                }
                worker.ReportProgress(20);
                //先复制文件
                this.index = 0;
                this.copyDirectory(strSource, StrGratePath);
                worker.ReportProgress(50);
                //入库，是图片生成缩略图
                this.index = 0;
                this.CopyFileDB(ipid, StrGratePath, iserverStart, ServerIp.Title, strQZ);
                worker.ReportProgress(100);
            }
            //List<SRRC_ResourceEntity> allEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " ServerIp=[$ServerIp$] and Dtype=0 "
            //                , new DataParameter("ServerIp", Param.ServerIP.Title)
            //                );
            this.AddNodeData(pnode, this.priAddEntList, ipid);
            GU.SetTreeNode(this.treeView1, pnode.Nodes, strtree);
            //this.treeView1.ExpandAll();
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
                    GetIds(resEntList, item.Id, ref  strPids);
                }

            }
        }
        
        //List<KKEntiy> dataList = new List<KKEntiy>();
        void CopyFileDB(Int32 pId, String strPath, Int32 iStart, String ServerIP, string strQZ)
        {
            string strkk = strPath.Split(new char[] { '\\' })[strPath.Split(new char[] { '\\' }).Length - 1];
            //String strPath = strQZ + strCurrentPath;
            List<String> arrFile = Directory.GetFiles(strPath).Where(m => SRConfig.Instance.GetAppString("ImageExt").Contains((m.Split(new char[] { '.' })[m.Split(new char[] { '.' }).Length - 1]).ToLower()) == true).ToList();
            String[] arrFoder = Directory.GetDirectories(strPath);
            if (arrFoder != null && arrFoder.Where(m => m.ToLower().Contains("img") == true).Count() > 0) //2
            {
                if (arrFile.Count > 0) //B类文件
                {
                    //FileInfo[] arrfile =new DirectoryInfo("").GetFiles();
                    //File.ReadAllBytes(arrFile[0]).Length +
                    Int64 ilength = File.ReadAllBytes(arrFile[0]).Length;
                    String strKKPath = arrFile[0].Substring(0,arrFile[0].Length- arrFile[0].Split(new char[] { '\\' })[arrFile[0].Split(new char[] { '\\' }).Length - 1].Length-1);
                    foreach (var item in new DirectoryInfo(strKKPath).GetFiles())
                    {
                        ilength += item.Length;
                    }
                   SRRC_ResourceEntity addEnt =  new SRRC_ResourceEntity()
                    {
                        Addtime = DateTime.Now,
                        Name = strkk,
                        Path = strQZ + arrFile[0].Substring(iStart),
                        Filesize = ilength,
                        Dtype = 2,
                        Pid = pId,
                        Serverip = ServerIP,
                        Extend1 =arrFile[0].Substring(arrFile[0].Length- arrFile[0].Split(new char[]{'.'})[arrFile[0].Split(new char[]{'.'}).Length-1].Length)
                    };
                   if (SRConfig.Instance.GetAppString("ImageExt").Contains(addEnt.Extend1.ToLower()) == true)
                   {
                       try
                       {
                           System.Drawing.Image image = System.Drawing.Image.FromFile(addEnt.Serverip + addEnt.Path);
                           addEnt.Extend2 = String.Format("{0}*{1}", image.Size.Width, image.Size.Height);
                           //比例缩放 
                           Size newpicsize = new System.Drawing.Size();
                           newpicsize.Height = 100;
                           newpicsize.Width = image.Width / (image.Height / newpicsize.Height);                           
                           if (File.Exists(addEnt.Serverip + addEnt.Path))
                               File.Delete(addEnt.Serverip + addEnt.Path);
                            image.Save(addEnt.Serverip.Replace("\\" + Param.IP, Param.ServerCacheIP) + addEnt.Path, ImageFormat.Jpeg);
                       }
                       catch (Exception ex)
                       {
                           DataBase.Instance.tSR_Systemrecord.Add(new SR_SystemrecordEntity() { Adddate = DateTime.Now, Description = ex.Message, Ltype = "异常", Title = "Left" });
                       }
                   }
                    Int32 iaddid = DataBase.Instance.tSRRC_Resource.Add(addEnt);
                    addEnt.Id = iaddid;
                    //this.priAddEntList.Add(addEnt);
                }
                //dataList.Add(new KKEntiy(2, pId, arrFile[0], strkk));
            }
            else
            {
                //增加节点
                //dataList.Add(new KKEntiy(0, pId, strPath, strkk));
                SRRC_ResourceEntity addEnt = new SRRC_ResourceEntity()
                 {
                     Addtime = DateTime.Now,
                     Name = strkk,
                     Path = strQZ + strPath.Substring(iStart),
                     Filesize = 0,
                     Dtype = 0,
                     Pid = pId,
                     Serverip = ServerIP
                 };
                Int32 iaddid = DataBase.Instance.tSRRC_Resource.Add(addEnt);
                addEnt.Id = iaddid;
                this.priAddEntList.Add(addEnt);
                //如果有文件增加文件
                if (arrFile != null && arrFile.Count() > 0)
                {
                    foreach (var item in arrFile)
                    {

                        index++;
                        worker.ReportProgress(50 + index / fileCount * 50);
                        //dataList.Add(new KKEntiy(1, strkk, item, item.Split(new char[] { '\\' })[item.Split(new char[] { '\\' }).Length - 1]));
                        String strFilename = item.Split(new char[] { '\\' })[item.Split(new char[] { '\\' }).Length - 1];

                        SRRC_ResourceEntity lsEnt = new SRRC_ResourceEntity()
                         {
                             Addtime = DateTime.Now,
                             Name = strFilename.Substring(0, strFilename.Length - strFilename.Split(new char[] { '.' })[strFilename.Split(new char[] { '.' }).Length - 1].Length - 1),
                             Path = strQZ + item.Substring(iStart),
                             Filesize = File.ReadAllBytes(item).Length,
                             Dtype = 1,
                             Pid = iaddid,
                             Serverip = ServerIP,
                             Extend1 = strFilename.Substring(strFilename.Length - strFilename.Split(new char[] { '.' })[strFilename.Split(new char[] { '.' }).Length - 1].Length)
                         };
                        if (SRConfig.Instance.GetAppString("ImageExt").Contains(lsEnt.Extend1.ToLower()) == true)
                        {
                            try
                            {
                                System.Drawing.Image image = System.Drawing.Image.FromFile(lsEnt.Serverip + lsEnt.Path);
                                lsEnt.Extend2 = String.Format("{0}*{1}", image.Size.Width, image.Size.Height);
                                //比例缩放 
                                Size newpicsize = new System.Drawing.Size();
                                newpicsize.Height = 100;
                                newpicsize.Width = image.Width / (image.Height / newpicsize.Height);
                                String strnewFilePath = (lsEnt.Serverip + lsEnt.Path).Replace(@"\\" + Param.IP, Param.ServerCacheIP);
                                string[] arrNewFolder = strnewFilePath.Split(new char[] { '\\' });
                                string strNewFolder = strnewFilePath.Substring(0, strnewFilePath.Length - arrNewFolder[arrNewFolder.Length - 1].Length);
                                if (System.IO.Directory.Exists(strNewFolder) == false)
                                {
                                    Directory.CreateDirectory(strNewFolder);
                                }
                                if (File.Exists(strnewFilePath))
                                    File.Delete(strnewFilePath);


                                Bitmap newbm = new Bitmap(newpicsize.Width, newpicsize.Height);//新建一个放大后大
                                Graphics g = Graphics.FromImage(newbm);
                                g.DrawImage(image, new Rectangle(0, 0, newpicsize.Width, newpicsize.Height), new Rectangle(0, 0, image.Width, image.Height), GraphicsUnit.Pixel);
                                g.Dispose();
                                newbm.Save(strnewFilePath, ImageFormat.Jpeg);
                            }
                            catch (Exception ex)
                            {
                                DataBase.Instance.tSR_Systemrecord.Add(new SR_SystemrecordEntity() { Adddate = DateTime.Now, Description = ex.Message, Ltype="异常", Title="Left" });
                            }
                        }
                        Int32 iaddid2 = DataBase.Instance.tSRRC_Resource.Add(lsEnt);
                    }
                }
                if (arrFoder != null && arrFoder.Count() > 0)
                {
                    foreach (var item in arrFoder)
                    {
                        CopyFileDB(iaddid, item, iStart, ServerIP, strQZ);
                    }
                }
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
                index++;
                worker.ReportProgress(20 + index / fileCount * 30);
            }
        }
        
        private void Left_Load(object sender, EventArgs e)
        {
           // this.contextMenuStrip1.Items.Clear();

        }
        private void contextMenuStrip1AddItem()
        {
            if (contextMenuStrip1.Items.Count > 5)
            {
                for(int i=5;i<contextMenuStrip1.Items.Count;)
                {
                    contextMenuStrip1.Items.RemoveAt(5);
                }
            }//已生成右键菜单
            #region 设置复合文件菜单
            if (Param.GroupId < 3) //主管以上
            {
                复合文件设置ToolStripMenuItem.Visible = true;
            }
            else
            {
                复合文件设置ToolStripMenuItem.Visible = false;
            }
            #endregion
            //添加分割符号
            contextMenuStrip1.Items.Add(new ToolStripSeparator());

            #region 个人标记
            List<SMDictionaryEntity> entList = DataBase.Instance.tSMDictionary.Get_EntityCollection(null,
                "Dtype=[$dtype$] and sProperty1=[$spro1$]",
                new DataParameter("dtype", "PersonalMark"), new DataParameter("spro1", Param.UserId));
            contextMenuStripAddItemAssistant(entList, "个人标记");
            #endregion
            #region 公共标注
            if(Param.GroupId < 3)
            {                
                entList = DataBase.Instance.tSMDictionary.Get_EntityCollection(null,
                            "Dtype=[$dtype$]",
                                new DataParameter("dtype", "PublicMark"));
                contextMenuStripAddItemAssistant(entList, "公共标注");
            }
            #endregion
        }
        private void contextMenuStripAddItemAssistant(List<SMDictionaryEntity> list,string type)
        {
            //2级菜单
            List<ToolStripItem> tsiList = new List<ToolStripItem>();
            ToolStripMenuItem menuItem;
            if(list != null)
            {
                foreach (var item in list)
                {
                    menuItem = new ToolStripMenuItem(item.sProperty2, null, MenuItem_Click, type + "_" + item.Id.ToString());
                    menuItem.ForeColor = Color.White;
                    tsiList.Add(menuItem);
                }
            }
            tsiList.Add(new ToolStripSeparator());
            menuItem = new ToolStripMenuItem("新增", null, MenuItem_Click, type + "_Add");
            menuItem.ForeColor = Color.White;
            tsiList.Add(menuItem);
            menuItem = new ToolStripMenuItem("删除", null, MenuItem_Click, type + "_Del");
            menuItem.ForeColor = Color.White;
            tsiList.Add(menuItem);
            menuItem = new ToolStripMenuItem("清除", null, MenuItem_Click, type + "_Clear");
            menuItem.ForeColor = Color.White;
            tsiList.Add(menuItem);
            //1级菜单
            menuItem = new ToolStripMenuItem(type, null, tsiList.ToArray());
            menuItem.ForeColor = Color.White;
            contextMenuStrip1.Items.Add(menuItem);
        }
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (SROperation2.Instance.LeftMouseRightSelectedEnt != null)
            {
                SRRC_ResourceEntity ent = SROperation2.Instance.LeftMouseRightSelectedEnt;
                string type = item.Name.Substring(0, item.Name.IndexOf('_'));
                if (item.Name.Contains("_Add"))
                {
                    FrmFrame ff = new FrmFrame() { Width = 400, Height = 200, Text = "新增标记" };
                    ff.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.Else.Add());
                    if (ff.ShowDialog() == DialogResult.OK)
                    {
                        SMDictionaryEntity ent1 = new SMDictionaryEntity();
                        if (type == "个人标记")
                        {
                            ent1.Dtype = "PersonalMark";
                            ent1.sProperty1 = Param.UserId.ToString();
                        }
                        else if (type == "公共标注")
                        {
                            ent1.Dtype = "PublicMark";
                        }
                        ent1.sProperty2 = Param.DPageParameter;
                        DataBase.Instance.tSMDictionary.Add(ent1);
                        contextMenuStrip1AddItem();
                    }
                }
                else if (item.Name.Contains("_Del"))
                {
                    FrmFrame ff = new FrmFrame() { Width = 400, Height = 200, Text = "删除标记" };
                    ff.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.Else.Add());
                    if (ff.ShowDialog() == DialogResult.OK)
                    {
                        SMDictionaryEntity ent1 = DataBase.Instance.tSMDictionary.Get_Entity("Dtype=[$type$] and sProperty2=[$spro2$]",
                                new DataParameter("type", type == "个人标记" ? "PersonalMark" : "PublicMark"), new DataParameter("spro2", Param.DPageParameter));
                        if (ent1 != null) DataBase.Instance.tSMDictionary.Delete(ent1.Id);
                        contextMenuStrip1AddItem();
                    }
                }
                else if (item.Name.Contains("_Clear"))
                {

                    if (type == "个人标记")
                    {
                        ent.Extend2 = "";
                        SMDictionaryEntity ent1 = DataBase.Instance.tSMDictionary.Get_Entity("iExtend1=[$userid$] and iExtend2=[$resid$]",
                            new DataParameter("userid", Param.UserId), new DataParameter("resid", ent.Id));
                        if (ent1 != null) DataBase.Instance.tSMDictionary.Delete(ent1.Id);
                    }
                    else if (type == "公共标注")
                    {
                        ent.Extend1 = "";
                        DataBase.Instance.tSRRC_Resource.Update(ent);
                    }
                }
                else
                {
                    if (type == "个人标记")
                    {

                        if (String.IsNullOrEmpty(ent.Extend2))
                        {
                            ent.Extend2 = string.Format("({0})", item.Text);
                            //入库
                            SMDictionaryEntity ent1 = new SMDictionaryEntity()
                            {
                                Dtype = "User标记",
                                iExtend1 = Param.UserId,
                                iExtend2 = ent.Id,
                                sProperty1 = ent.Extend2
                            };
                            DataBase.Instance.tSMDictionary.Add(ent1);
                        }
                        else
                        {
                            ent.Extend2 = string.Format("({0})", item.Text);
                            SMDictionaryEntity ent1 = DataBase.Instance.tSMDictionary.Get_Entity("Dtype='User标记' and iExtend1=" + Param.UserId + " and iExtend2=" + ent.Id);
                            if (ent1 != null)
                            {
                                ent1.sProperty1 = ent.Extend2;
                                DataBase.Instance.tSMDictionary.Update(ent1);
                            }
                        }
                    }
                    else if (type == "公共标注")
                    {
                        ent.Extend1 = string.Format("[{0}]", item.Text);
                        DataBase.Instance.tSRRC_Resource.Update(ent);
                    }
                }
                this.treeView1.Nodes.Find(ent.Id.ToString(), true)[0].Text = ent.Name + ent.Extend2 + ent.Extend1;
            }
        }

        //定义委托
        public delegate void PageAfterHandle(object sender, TreeViewEventArgs e);
        //定义事件
        public event PageAfterHandle OnPageAftered;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {            
            if (OnPageAftered != null)
            {
                TreeNode[] tns = this.treeView1.Nodes.Find(SROperation.Instance.LeftSelectedId.ToString(), true);
                if(tns != null &&tns.Length > 0)
                {
                    //leftSelectedId只有一个值
                    tns[0].BackColor = Color.FromArgb(37, 37, 37);
                }
                OnPageAftered(sender, e);
            }
        }

        public void BindData()
        {
            #region 权限
            if(Param.GroupId == 4) //客户
            {
                Favorites.Visible = false;
                SROperation.Instance.LeftDtype = SROperation.Instance.LeftDtype == "Favorites" ? "Study" : SROperation.Instance.LeftDtype;
            }
            #endregion


            //添加项
            foreach (KeyValuePair<string, Image> item in SROperation.Instance.IconList)
            {
                this.imageList1.Images.Add(item.Key, item.Value);
            }

            this.Resources.BackColor = this.Study.BackColor = this.Favorites.BackColor = Color.FromArgb(54, 54, 54);

            switch (SROperation.Instance.LeftDtype)
            {
                case "Resources":
                    if(Param.GroupId < 3)//管理员和主管可以上传资源，管理员和主管GroupId分别为1、2；
                    {
                        this.treeView1.AllowDrop = true;
                    }
                    else
                    {
                        this.treeView1.AllowDrop = false;
                    }
                    this.treeView1.AllowDrop = false;//2015-7-16，left面板禁用拖放操作
                    this.Resources.BackColor = Color.FromArgb(100, 143, 178);
                    break;
                case "Study":
                    this.treeView1.AllowDrop = false;
                    this.Study.BackColor = Color.FromArgb(100, 143, 178);
                    break;
                case "Favorites":
                    this.treeView1.AllowDrop = false;
                    this.Favorites.BackColor = Color.FromArgb(100, 143, 178);
                    break;
                default:
                    break;
            }
            this.label1.Text = SROperation.Instance.LeftDtype;
            //显示方式：默认显示，跨越显示
            if(SROperation.Instance.LeftShowType == "Default")
            {
                // this.默认显示ToolStripMenuItem.Checked = true;
                this.默认显示ToolStripMenuItem_Click(this.默认显示ToolStripMenuItem, new EventArgs());
            }
            else if(SROperation.Instance.LeftShowType == "Cross")
            {
                //this.跨越显示ToolStripMenuItem.Checked = true;
                this.跨越显示ToolStripMenuItem_Click(this.跨越显示ToolStripMenuItem, new EventArgs());
            }
            this.SetTreeview();

            //
            int selectedId = 0;
            switch (SROperation.Instance.LeftDtype)
            {
                case "Resources":
                    {
                        selectedId = SROperation2.Instance.ResourceSelectedId;
                    }
                    break;
                case "Study":
                    {
                        selectedId = SROperation2.Instance.StudySelectedId;
                    }
                    break;
                case "Favorites":
                    {
                        selectedId = SROperation2.Instance.FavoritesSelectedId;
                    }
                    break;
            }
            if (selectedId > 0)
            {
              TreeNode[] tns =  this.treeView1.Nodes.Find(selectedId.ToString(), true);
                if(tns != null && tns.Length > 0)
                {
                    TreeNode tn = tns[0];
                    tn.EnsureVisible();
                    tn.BackColor = SystemColors.HotTrack;
                }
            }
        }

        private void 设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFrame frm = new FrmFrame() { Width = 380, Height = 420 };
            frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.Else.SetHide());
            if (frm.ShowDialog() == DialogResult.OK)
            {
                this.SetTreeview();
            }            
        }

        private void picTitleTool1_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip2.Show(MousePosition);
        }

        private void picTitleTool2_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip2.Show(MousePosition);
        }

        private void 默认显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tlmi = sender as ToolStripMenuItem;
            tlmi.Checked = !tlmi.Checked;
            if (tlmi.Checked)//已选中
            {
                tlmi.Enabled = false;
                this.跨越显示ToolStripMenuItem.Enabled = true;
            }
            this.跨越显示ToolStripMenuItem.Checked = false;
            SROperation.Instance.LeftShowType = "Default";
            this.SetTreeview();
        }

        private void 跨越显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tlmi = sender as ToolStripMenuItem;
            tlmi.Checked = !tlmi.Checked;
            if(tlmi.Checked)//已选中
            {
                tlmi.Enabled = false;
                默认显示ToolStripMenuItem.Enabled = true;
            }
            默认显示ToolStripMenuItem.Checked = false;
            SROperation.Instance.LeftShowType = "Cross";
            this.SetTreeview();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if(e.Node.Nodes.Count == 0)
            {
                AddNodeData(e.Node, entList, Convert.ToInt32(e.Node.Name));
                //e.Node.Expand();
            }
            //鼠标右键点击
            if (e.Button == MouseButtons.Right && e.Node.Tag != null)
            {
                SROperation2.Instance.LeftMouseRightSelectedEnt = e.Node.Tag as SRRC_ResourceEntity;
                if (SROperation.Instance.LeftDtype == "Study" || Param.GroupId < 3)
                {
                    e.Node.ContextMenuStrip = contextMenuStrip3;
                }
            }
        }

        private void 展开下列所有目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SROperation2.Instance.LeftMouseRightSelectedEnt != null)
            {
                this.treeView1.Nodes.Find(SROperation2.Instance.LeftMouseRightSelectedEnt.Id.ToString(), true)[0].ExpandAll();
            }
        }

        private void 关闭下列所有目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SROperation2.Instance.LeftMouseRightSelectedEnt != null)
            {
                this.treeView1.Nodes.Find(SROperation2.Instance.LeftMouseRightSelectedEnt.Id.ToString(), true)[0].Collapse();
            }
        }

        private void 关闭所有ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.treeView1.CollapseAll();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Left";
        }

        #region 复合文件设置及取消
        private void SetComposite(SRRC_ResourceEntity ent)
        {
            ent.Name = "*" + ent.Name.TrimStart('*');
            DataBase.Instance.tSRRC_Resource.Update(ent);
            treeView1.Nodes.Find(ent.Id.ToString(), true)[0].Text = ent.Name;
            List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Pid=[$pid$] and Dtype=1 ", new DataParameter("Pid", ent.Id));
            if (entList == null || entList.Count == 0) return;
            foreach (SRRC_ResourceEntity item in entList)
            {
                item.Iscomposite = true;
                DataBase.Instance.tSRRC_Resource.Update(item);
            }
        }
        private void CancelComposite(SRRC_ResourceEntity ent)
        {
            ent.Name = ent.Name.TrimStart('*');
            DataBase.Instance.tSRRC_Resource.Update(ent);
            treeView1.Nodes.Find(ent.Id.ToString(), true)[0].Text = ent.Name;
            List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Pid=[$pid$] and Dtype=1 ", new DataParameter("Pid", ent.Id));
            if (entList == null || entList.Count == 0) return;
            foreach (SRRC_ResourceEntity item in entList)
            {
                item.Iscomposite = false;
                DataBase.Instance.tSRRC_Resource.Update(item);
            }
        }
        private void 当前目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SRRC_ResourceEntity ent = SROperation2.Instance.LeftMouseRightSelectedEnt;
            if (ent == null) return;
            SetComposite(ent);
            if (SROperation.Instance.LeftSelectedId == SROperation2.Instance.LeftMouseRightSelectedEnt.Id)
            {
                string treenodename = SROperation2.Instance.LeftMouseRightSelectedEnt.Id.ToString();
                OnPageAftered(null, new TreeViewEventArgs(treeView1.Nodes.Find(treenodename, true)[0]));
            }

        }

        private void 子目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SROperation2.Instance.LeftMouseRightSelectedEnt == null) return;
            List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, "Pid=[$pid$]", new DataParameter("pid", SROperation2.Instance.LeftMouseRightSelectedEnt.Id));
            if (entList == null || entList.Count == 0) return;
            foreach(SRRC_ResourceEntity ent in entList)
            {
                SetComposite(ent);
            }
            if (SROperation.Instance.LeftSelectedId == SROperation2.Instance.LeftMouseRightSelectedEnt.Id)
            {
                string treenodename = SROperation2.Instance.LeftMouseRightSelectedEnt.Id.ToString();
                OnPageAftered(null, new TreeViewEventArgs(treeView1.Nodes.Find(treenodename, true)[0]));
            }
        }

        private void 复合文件取消ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SRRC_ResourceEntity ent = SROperation2.Instance.LeftMouseRightSelectedEnt;
            if(ent.Name.StartsWith("*"))
            {
                CancelComposite(ent);
            }
            else
            {
                List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, "Pid=[$pid$]", new DataParameter("pid", SROperation2.Instance.LeftMouseRightSelectedEnt));
                if (entList == null || entList.Count == 0) return;
                foreach (SRRC_ResourceEntity item in entList)
                {
                    CancelComposite(item);
                }
            }
            if(SROperation.Instance.LeftSelectedId == SROperation2.Instance.LeftMouseRightSelectedEnt.Id)
            {
                string treenodename = SROperation2.Instance.LeftMouseRightSelectedEnt.Id.ToString();
                OnPageAftered(null, new TreeViewEventArgs(treeView1.Nodes.Find(treenodename, true)[0]));
            }            
        }
        #endregion

        private void Left_Enter(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Left";
        }

        private void contextMenuStrip1_VisibleChanged(object sender, EventArgs e)
        {

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
                default:
                    break;
            }
        }

        private void contextMenuStrip3_Opening(object sender, CancelEventArgs e)
        {
            FrmFrame frm = new FrmFrame()
            {
                WindowState = FormWindowState.Normal,
                Width = 480,               
                Height = 400,
                BackColor = Color.FromArgb(37, 37, 37),
                Text = "艺卓资源管理系统",
                Name = "关键字设置",
                FormBorderStyle = FormBorderStyle.Sizable
            };
            var control = new KeywordManager();
            frm.SetUserControl(control);

            //  
            frm.ShowDialog();
        }
    }
}