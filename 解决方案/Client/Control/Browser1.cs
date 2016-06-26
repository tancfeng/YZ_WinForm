using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SirdRoom.ORM;
using SirdRoom.ManageSystem.Library.Data;
using System.Threading;
using ControlLibrary.Control;
using System.Threading.Tasks;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class Browser1 : UserControl
    {
        Int32 index = -1;
        String strPic = "";
        int PicId = 0;
        string PicSrc = "";
        double Ratio = 1;//缩放比例
        List<SRRC_ResourceEntity> recEntList = new List<SRRC_ResourceEntity>();
        ListView.ListViewItemCollection lvic;
        Size moveSize;
        Bitmap newbm;
        static Thread t;
        string source;
        public Browser1()
        {
            InitializeComponent();
            t = new Thread(new ThreadStart(BlockingCollectionInit));
           // t.Start();
        }

        private void Browser_FormClosing(object sender, FormClosingEventArgs e)
        {
            SROperation2.Instance.isContinue = false;
            if (this.TopLevelControl is FrmFrame)
            {
                ((this.TopLevelControl as FrmFrame).Owner as FrmMain).BrowserCross(source, index);
            }
            this.FindForm().Owner.Show();
            this.FindForm().Owner.Refresh();
        }

        public Browser1(ListView.ListViewItemCollection lvic):this()
        {
            this.lvic = lvic;
        }

        public Browser1(List<SRRC_ResourceEntity> recEntList,string source):this()
        {
            this.recEntList = recEntList;
            this.source = source;
        }

        void center2_11_OnPageClicked(object sender, MyEventArgs e)
        {
            switch (e.Action)
            {                
                case 11:
                    {
                        
                        index--;
                        //if (index < 0)
                        //    index = 0;
                        if (index >= 0)
                        {
                            SRRC_ResourceEntity ent = lvic[index].Tag as SRRC_ResourceEntity;
                            this.PicId = ent.Id;
                            this.inPutBuffer(ent.Serverip + ent.Path, 0);
                            this.center2_11.SetSelectedState(index);
                            this.right1.SetBiaoJiStatusByString(this.PicId.ToString());
                            
                        }
                        else
                        {
                            index = 0;
                            MessageBox.Show("已是第一张");
                        }
                        
                    }
                    break;
                case 12:
                    {
                        index++;
                        if (lvic.Count > index)
                        {
                            SRRC_ResourceEntity ent = lvic[index].Tag as SRRC_ResourceEntity;
                            this.PicId = ent.Id;
                            this.inPutBuffer(ent.Serverip + ent.Path, 0);
                            this.center2_11.SetSelectedState(index);
                            this.right1.SetBiaoJiStatusByString(this.PicId.ToString());
                        }
                        else
                        {
                            index = lvic.Count - 1;
                            MessageBox.Show("已是最后一张");
                        }
                    }
                    break;
                case 13:
                    {
                        this.inPutBuffer(strPic, -1);
                    }
                    break;
                case 14:
                    {
                        this.inPutBuffer(strPic, 0);
                    }
                    break;
                case 15:
                    {
                        this.inPutBuffer(strPic, 0);
                    }
                    break;
                case 16://显示图片
                    {
                        if (String.IsNullOrEmpty(e.Parameter.ToString()) == false)
                        {
                            //1:1显示
                            String[] arrls = e.Parameter.ToString().Split(new char[] { '|' });
                            index = SRLibFun.StringConvertToInt32(arrls[1]);
                            PicId = SRLibFun.StringConvertToInt32(arrls[2]);
                            inPutBuffer(arrls[0], 0);
                            this.right1.SetBiaoJiStatusByString(this.PicId.ToString());
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        Bitmap M_map_bufferpic;//加快GDI读取用缓存图片(原图)        

        /**/
        /// <summary>
        /// 传入内存缓存中
        /// </summary>
        /// <param name="P_str_path">图片地址 </param>
        private void inPutBuffer(string P_str_path, double trackBarvalue)
        {
            GC.Collect();
            //判断是目录还是文件
            if (String.IsNullOrEmpty(P_str_path) || Directory.Exists(P_str_path))
            {
                return;
            }
            SROperation2.Instance.BrowserPicId = this.PicId;
            if (PicSrc != P_str_path)
            {
                M_map_bufferpic = null;
                PicSrc = P_str_path;
            }

            strPic = P_str_path;
            if (M_map_bufferpic == null)
            {
                
                    using (new IdentityScope(Param.ServerIP.Description,
                                Param.ServerIP.Remark,
                                Param.ServerIP.Title))
                    {
                        M_map_bufferpic = new Bitmap(P_str_path);
                    }
                                
            }            
            Size picsize = M_map_bufferpic.Size;
            Size pictureSize = this.pictureBox1.Size;
            newbm = M_map_bufferpic;
            if (trackBarvalue == 0) //原图大小，超过窗口大小，缩放 
            {
                moveSize = new Size(0, 0);
                if (picsize.Width > pictureSize.Width || picsize.Height > pictureSize.Height)
                {
                    if (picsize.Width * pictureSize.Height >= picsize.Height * pictureSize.Width)
                    {
                        picsize.Height = pictureSize.Width * picsize.Height / picsize.Width;
                        picsize.Width = pictureSize.Width;
                    }
                    else
                    {
                        picsize.Width = pictureSize.Height * picsize.Width / picsize.Height;
                        picsize.Height = pictureSize.Height;
                    }
                    newbm = new Bitmap(picsize.Width, picsize.Height);
                    Graphics g = Graphics.FromImage(newbm);
                    g.DrawImage(M_map_bufferpic, new Rectangle(0, 0, picsize.Width, picsize.Height), new Rectangle(0, 0, M_map_bufferpic.Width, M_map_bufferpic.Height), GraphicsUnit.Pixel);
                    g.Dispose();                                        
                }
                else
                {
                    //原图显示
                }
                //M_map_bufferpic = new Bitmap(M_map_bufferpic, picsize);
            }
            else if (trackBarvalue == -1) //窗口大小,原图
            {
                moveSize = new Size(0, 0);
                //if (picsize.Width * pictureSize.Height >= picsize.Height * pictureSize.Width)
                //{
                //    picsize.Height = pictureSize.Width * picsize.Height / picsize.Width;
                //    picsize.Width = pictureSize.Width;
                //}
                //else
                //{
                //    picsize.Width = pictureSize.Height * picsize.Width / picsize.Height;
                //    picsize.Height = pictureSize.Height;
                //}
                //newbm = new Bitmap(picsize.Width, picsize.Height);//新建一个放大后大
                //Graphics g = Graphics.FromImage(newbm);
                //g.DrawImage(M_map_bufferpic, new Rectangle(0, 0, picsize.Width, picsize.Height), new Rectangle(0, 0, M_map_bufferpic.Width, M_map_bufferpic.Height), GraphicsUnit.Pixel);
                //g.Dispose();
            }
            else
            {
                picsize.Width = (int)(M_map_bufferpic.Width * trackBarvalue);
                picsize.Height = (int)(M_map_bufferpic.Height * trackBarvalue);
                if (picsize.Width > 7200)
                {
                    picsize.Width = 7200;
                }
                if (picsize.Height > 7200)
                {
                    picsize.Height = 7200;
                }
                newbm = new Bitmap(picsize.Width, picsize.Height);//新建一个放大后大
                Graphics g = Graphics.FromImage(newbm);
                g.DrawImage(M_map_bufferpic, new Rectangle(0, 0, picsize.Width, picsize.Height), new Rectangle(0, 0, M_map_bufferpic.Width, M_map_bufferpic.Height), GraphicsUnit.Pixel);
                g.Dispose();
            }       
            pictureBox1.Image = newbm;
            GC.Collect();
        }

        Point M_pot_p = new Point();//原始位置
        int M_int_mx = 0, M_int_my = 0;//下次能继续
        int M_int_maxX, M_int_maxY;//加快读取用

        private void pnlLeft_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
        }

        private void pnlLeft_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
        }

        private void pnlRight_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(57)))), ((int)(((byte)(57)))));
        }

        private void pnlRight_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            M_pot_p = e.Location;
            //<=0,不需要平移
            M_int_maxX = (newbm.Width - pictureBox1.Width) / 2 > 0 ? (newbm.Width - pictureBox1.Width) / 2 : 0;
            M_int_maxY = (newbm.Height - pictureBox1.Height) / 2 > 0 ? (newbm.Height - pictureBox1.Height) / 2 : 0;
            Cursor = Cursors.SizeAll;
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {            
            if (e.Button == MouseButtons.Left && (M_int_maxX > 0 || M_int_maxY > 0))//当按左键的时候,并且可平移时
            {
                GC.Collect();
                //位移
                M_int_mx = moveSize.Width + e.X - M_pot_p.X;
                M_int_my = moveSize.Height + e.Y - M_pot_p.Y;
                //锁定范围
                //相对于newbm中心点平移的距离
                moveSize.Width = Math.Min(M_int_maxX, Math.Abs(M_int_mx)) == M_int_maxX ? Math.Sign(M_int_mx) * M_int_maxX : M_int_mx;
                moveSize.Height = Math.Min(M_int_maxY, Math.Abs(M_int_my)) == M_int_maxY ? Math.Sign(M_int_my) * M_int_maxY : M_int_my;

                Image i = new Bitmap(M_int_maxX == 0 ? newbm.Width : pictureBox1.Width, M_int_maxY == 0 ? newbm.Height : pictureBox1.Height);
                {
                    Graphics g = Graphics.FromImage(i);
                    GraphicsUnit gu = new GraphicsUnit();

                    g.DrawImage(newbm, i.GetBounds(ref gu), new Rectangle((newbm.Width / 2 - moveSize.Width - i.Width / 2), (newbm.Height / 2 - moveSize.Height - i.Height / 2), i.Width, i.Height), gu);
                    pictureBox1.Image = i;
                    M_pot_p = e.Location;
                    g.Dispose();
                }              
                
            }
            else
            {
                Cursor = Cursors.Default;
            }            
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Cursor = Cursors.Default;
        }
        private void pnlRight_MouseClick(object sender, MouseEventArgs e)
        {
            //this.center2_11_OnPageClicked(sender, new MyEventArgs() { Action = 12 });
            下一张ToolStripMenuItem_Click(sender, e);
        }

        private void pnlLeft_MouseClick(object sender, MouseEventArgs e)
        {
            //this.center2_11_OnPageClicked(sender, new MyEventArgs() { Action = 11 });
            上一张ToolStripMenuItem_Click(sender, e);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            this.buttom1.BindData(this.PicId);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Ratio = 1;
            inPutBuffer(PicSrc.Replace(Param.ServerCacheIP, Param.IP), 0);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Ratio -= 0.2;
            this.Ratio = this.Ratio < 0.2 ? 0.2 : this.Ratio;     
            inPutBuffer(PicSrc, this.Ratio);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Ratio += 0.2;
            inPutBuffer(PicSrc, this.Ratio);
        }
        
        private void Browser_DoubleClick(object sender, EventArgs e)
        {
                        
            
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.TopLevelControl is FrmFrame)
            {
                (this.TopLevelControl as FrmFrame).Close();
            }
        }

        private void p3_Click(object sender, EventArgs e)
        {
            inPutBuffer(PicSrc.Replace(Param.IP,Param.ServerCacheIP), 0);//原始缩略图
        }

        private void 复制到指定目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SR_UserEntity userEnt = DataBase.Instance.tSR_User.Get_Entity(Param.UserId);
            if (userEnt == null || String.IsNullOrEmpty(userEnt.Companyname) == true)
            {
                MessageBox.Show("未设置路径！");
                return;
            }
            using (new IdentityScope(Param.ServerIP.Description,
                    Param.ServerIP.Remark,
                    Param.ServerIP.Title))
            {

                SRRC_ResourceEntity item = DataBase.Instance.tSRRC_Resource.Get_Entity(this.PicId);
                if (item == null) return;
                string path = "";
                if (item.Iscomposite)//复合文件
                {
                    var temp = DataBase.Instance.tSRRC_Resource.Get_Entity(item.Pid);
                    path = temp.Serverip + temp.Path;
                }
                else
                {
                    path = item.Serverip + item.Path;
                }

                SROperation2.Instance.isLoading = true;
                int totalCount = 0;
                if (Directory.Exists(path))
                {//文件夹
                    totalCount += Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).Length;
                }
                else if (File.Exists(path))
                {
                    //文件
                    totalCount++;
                }

                SROperation2.Instance.entListCount = totalCount;
                SROperation2.Instance.entListReadyCount = 0;
                Thread t = new Thread(new ThreadStart(SetWaitPic));
                t.Start();

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
        private void 跳转到资源目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(SROperation2.Instance.PicSelected == null)
            {
                SROperation2.Instance.PicSelected = new List<SRRC_ResourceEntity>();
            }
            else
            {
                SROperation2.Instance.PicSelected.Clear(); 
            }
            SROperation2.Instance.PicSelected.Add(DataBase.Instance.tSRRC_Resource.Get_Entity(this.PicId));
            if(this.TopLevelControl is FrmFrame)
            {
                ToolStripMenuItem ti = new ToolStripMenuItem();
                ti.Text = "跳转到资源目录";
                ((this.TopLevelControl as FrmFrame).Owner as FrmMain).BrowserCross(ti, new EventArgs());
            }
        }

        private void 放大ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox2_Click(sender, e);
        }

        private void 缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox3_Click(sender,e);
        }

        private void 上一张ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.center2_11_OnPageClicked(sender, new MyEventArgs() { Action = 11 });

            index--;
            //if (index < 0)
            //    index = 0;
            if (index >= 0)
            {
                SRRC_ResourceEntity ent = recEntList[index];
                this.PicId = ent.Id;
                this.inPutBuffer(ent.Serverip + ent.Path, 0);
                //this.center2_11.SetSelectedState(index);
                this.right1.SetBiaoJiStatusByString(this.PicId.ToString());

            }
            else
            {
                index = 0;
                MessageBox.Show("已是第一张");
            }
        }

        private void 下一张ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.center2_11_OnPageClicked(sender, new MyEventArgs() { Action = 12 });
            index++;
            if (recEntList.Count > index)
            {
                SRRC_ResourceEntity ent = recEntList[index];
                this.PicId = ent.Id;
                this.inPutBuffer(ent.Serverip + ent.Path, 0);
                //this.center2_11.SetSelectedState(index);
                this.right1.SetBiaoJiStatusByString(this.PicId.ToString());
            }
            else
            {
                index = recEntList.Count - 1;
                MessageBox.Show("已是最后一张");
            }
        }

        private void 适配图像到窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inPutBuffer(PicSrc.Replace(Param.ServerCacheIP, Param.IP), -1);//原始缩略图
        }

        private void 适配图像到窗口仅缩小ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inPutBuffer(PicSrc.Replace(Param.ServerCacheIP, Param.IP), 0);//原始缩略图
        }

        private void 按图像实际像素显示11ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inPutBuffer(PicSrc.Replace( Param.ServerCacheIP, Param.IP), 0);//原始缩略图
        }
        private void p13_Click(object sender, EventArgs e)
        {
            复制到指定目录ToolStripMenuItem_Click(sender, e);
        }

        private void p12_Click(object sender, EventArgs e)
        {
            跳转到资源目录ToolStripMenuItem_Click(sender, e);
        }

        private void p11_Click(object sender, EventArgs e)
        {
            this.contextMenuStrip1.Show();
        }

        private void contextMenuStrip1_VisibleChanged(object sender, EventArgs e)
        {
            if(contextMenuStrip1.Visible)
            {
                contextMenuStrip1.Left = MousePosition.X;
                contextMenuStrip1.Top = MousePosition.Y;
            }
        }

        private void Browser_Load(object sender, EventArgs e)
        {
            this.right1.BindData();
            //this.right1.OnPageClicked += right1_OnPageClicked;
            this.right1.OnPageAftered += right1_OnPageAftered;
            this.center2_11.OnPageClicked += center2_11_OnPageClicked;
 
            //双缓存
            //base.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            //base.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);

            //Path|Index
            if (String.IsNullOrEmpty(Param.DPageParameter) == false)
            {
                //1:1显示
                String[] arrls = Param.DPageParameter.Split(new char[] { '|' });
                index = SRLibFun.StringConvertToInt32(arrls[1]);
                PicId = SRLibFun.StringConvertToInt32(arrls[2]);
                inPutBuffer(arrls[0].Replace(Param.ServerCacheIP, Param.IP), 0);
                SROperation2.Instance.BrowserPicId = this.PicId;
            }
            //this.center2_11.BindData(ref this.lvic);
            this.right1.SetBiaoJiStatusByString(this.PicId.ToString());
            //右键菜单
            CustomToolStripColorTable ctsct = new CustomToolStripColorTable();
            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(ctsct);
            contextMenuStrip2.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip2.Renderer = new ToolStripProfessionalRenderer(ctsct);
            //FrmFame 事件
            //this.center2_11.listView1.KeyDown += Browser_KeyDown;
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            splitContainer1.SplitterDistance = SROperation.Instance.BrowserSplitContainer1SplitterDistance;

            this.FindForm().KeyPreview = true;
            this.FindForm().KeyUp += Browser_KeyUp;
            this.FindForm().MouseWheel += Browser_MouseWheel;

            this.FindForm().FormClosing += Browser_FormClosing;
        }

        private void Browser_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta >0)
            {
                上一张ToolStripMenuItem_Click(上一张ToolStripMenuItem, new EventArgs());
            }
            else
            {
                下一张ToolStripMenuItem_Click(下一张ToolStripMenuItem, new EventArgs());
            }
        }

        private void Browser_KeyUp(object sender, KeyEventArgs e)
        {
            switch(e.KeyData)
            {
                case Keys.D1:
                    {
                        适配图像到窗口ToolStripMenuItem_Click(适配图像到窗口ToolStripMenuItem, new EventArgs());
                        e.Handled = true;
                    }break;
                case Keys.D2:
                    {
                        适配图像到窗口仅缩小ToolStripMenuItem_Click(适配图像到窗口仅缩小ToolStripMenuItem, new EventArgs());
                        e.Handled = true;
                        break;
                    }
                case Keys.D3:
                    {
                        按图像实际像素显示11ToolStripMenuItem_Click(按图像实际像素显示11ToolStripMenuItem, new EventArgs());
                        e.Handled = true;
                    }break;
                case Keys.Q:
                    {
                        放大ToolStripMenuItem_Click(放大ToolStripMenuItem, new EventArgs());
                        e.Handled = true;
                    }break;
                case Keys.W:
                    {
                        缩小ToolStripMenuItem_Click(缩小ToolStripMenuItem, new EventArgs());
                        e.Handled = true;
                    }break;
                case Keys.Left:
                    {
                        上一张ToolStripMenuItem_Click(上一张ToolStripMenuItem, new EventArgs());
                        e.Handled = true;
                    }break;
                case Keys.Right:
                case Keys.Space:
                    {
                        下一张ToolStripMenuItem_Click(下一张ToolStripMenuItem, new EventArgs());
                        e.Handled = true;
                    }break;
                default:
                    break;
            }
        }
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            SROperation.Instance.BrowserSplitContainer1SplitterDistance = splitContainer1.SplitterDistance;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }

        private void pictureBox1_Resize(object sender, EventArgs e)
        {
           // inPutBuffer(PicSrc.Replace(Param.ServerCacheIP, Param.IP), 0);
        }



        //右边事件
        void right1_OnPageClicked(object sender, MyEventArgs e)
        {
            SROperation2.Instance.CenterLanZhiTemp = "";
            if (SROperation2.Instance.KeywordFilter.Length == 0)//无关键字
            {
                recEntList = null;
            }
            else //有关键字
            {
                //and
                if (SROperation2.Instance.KeywordLogical == "and")
                {
                    int count = SROperation2.Instance.KeywordFilter.Split(',').Length;
                    recEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL("select * from SRRC_Resource where id in (SELECT Resource_id  FROM SRRC_Resourcebiaojirel  WHERE Biaoji_id IN (" + SROperation2.Instance.KeywordFilter + ")  GROUP BY Resource_id  HAVING COUNT(*)=" + count + ")");
                }
                //or
                if (SROperation2.Instance.KeywordLogical == "or")
                {
                    recEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL("select * from SRRC_Resource where id in (SELECT Resource_id  FROM SRRC_Resourcebiaojirel  WHERE Biaoji_id IN (" + SROperation2.Instance.KeywordFilter + ")  GROUP BY Resource_id)");
                }
            }
            if (recEntList != null && recEntList.Count > 0)
            {
                foreach (SRRC_ResourceEntity item in recEntList)
                {
                    SROperation2.Instance.CenterLanZhiTemp += item.Id + ",";
                }
            }
            SROperation2.Instance.CenterLanZhiTemp = SROperation2.Instance.CenterLanZhiTemp.Trim(',');
            if (SROperation2.Instance.CenterLanZhiTemp == "") SROperation2.Instance.CenterLanZhiTemp = "0";
            this.center2_11.BindData();
        }

        //右边事件
        void right1_OnPageAftered(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null || e.Node.Tag == null) return;
            {

                Int32 ibiaojiId = (e.Node.Tag as SRRC_BiaojiEntity).Id;
                String strPicSelected = this.PicId.ToString();
                
                strPicSelected = strPicSelected.TrimEnd(',');
                if (string.IsNullOrEmpty(strPicSelected) == false)
                {
                    DataBase.Instance.tSRRC_Resourcebiaojirel.Delete(" User_id=[$User_id$] and Biaoji_id=[$Biaoji_id$] and Resource_id in (" + strPicSelected + ") ",
                        new DataParameter("User_id", SROperation.Instance.RightDtype.Equals("Study") == true ? 0 : Param.UserId),
                        new DataParameter("Biaoji_id", ibiaojiId)
                        );
                    if (e.Node.Checked == true)
                    {
                        List<SRRC_ResourcebiaojirelEntity> resourcebiaojirelEntList = new List<SRRC_ResourcebiaojirelEntity>();
                        foreach (var item in strPicSelected.Split(new char[] { ',' }))
                        {
                            resourcebiaojirelEntList.Add(new SRRC_ResourcebiaojirelEntity()
                            {
                                Addtime = DateTime.Now,
                                Biaoji_id = ibiaojiId,
                                Resource_id = SRLibFun.ToInt32(item),
                                User_id = SROperation.Instance.RightDtype.Equals("Study") == true ? 0 : Param.UserId
                            });
                        }
                        DataBase.Instance.tSRRC_Resourcebiaojirel.Add(resourcebiaojirelEntList.ToArray());
                        DataBaseHelper.Instance.Helper.ExecuteNonQuery(System.Data.CommandType.Text, " update SRRC_Resource set bjtime=Getdate() where id in(" + strPicSelected + ")  ");
                    }
                }
            }
        }

        /// <summary>
        /// 图片加载，如果直接在需要图片时启动线程，会导致拖动过快时线程过多死机。所以用BlockingCollection来处理
        /// </summary>
        public void BlockingCollectionInit()
        {
            int count = Convert.ToInt32(SRConfig.Instance.GetAppString("BlockingCollectionTakeThreadNum"));
            Thread[] threads = new Thread[count];
            SROperation2.Instance.isContinue = true;
            while (SROperation2.Instance.isContinue)
            {

                if ((SROperation2.Instance.Center2_1ImageBlockingCollection.Count != 0))
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
                while (SROperation2.Instance.Center2_1ImageBlockingCollection.Count != 0)
                {
                    if (SROperation2.Instance.Center2_1ImageBlockingCollection.TryTake(out kv))
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
                                this.center2_11.Invoke(new Center2_1.SetImageListDelegate(center2_11.SetImageList), kv.Key, image);
                            }
                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                SRLogHelper.Instance.AddLog("异常", "Browser", "BlockingCollectionInit", ex.Message);
            }
        }
    }

}
