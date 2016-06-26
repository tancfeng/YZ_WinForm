using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ORM;
using SirdRoom;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using SirdRoom.ManageSystem.ClientApplication;

namespace ControlLibrary.Control
{
    
public partial class Center2 : UserControl
    {
        //定义委托
        public delegate void PageClickHandle(object sender, MyEventArgs e);
        //定义事件
        public event PageClickHandle OnPageClicked;

        public bool isTemp = false;
        public List<SRRC_ResourceEntity> entList;//
        List<string> waitLoadImageId = new List<string>();

        MouseButtons _mouseDown;
        public Center2()
        {
            InitializeComponent();
            this.listView1.View = View.LargeIcon;
            string[] fileStripSize = SRConfig.Instance.GetAppString("FilmStripSize").Split(',');
            this.listView1.LargeImageList = new ImageList();
            // this.listView1.LargeImageList.ImageSize = new Size(Convert.ToInt32(fileStripSize[0]), Convert.ToInt32(fileStripSize[1]));
            this.listView1.LargeImageList.ImageSize = new Size(96, 96);
            this.listView1.ForeColor = Color.White;

            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());
            
        }
        private void SetWaitPic()
        {
            FrmFrame ff = new FrmFrame() { Width = 284, Height = 258, Text = "正在加载，请稍后..." };
            WaitPic wp = new WaitPic();
            ff.SetUserControl(wp);
            ff.Show();
            while (SROperation2.Instance.isLoading)
            {
                wp.SetReadCount();
                ff.Refresh();
            }
        }
        void SetData(List<SRRC_ResourceEntity> entList)
        {
            this.listView1.Clear();
            this.listView1.Refresh();
            if (entList == null) return;
            SROperation2.Instance.isLoading = true;
            SROperation2.Instance.entListCount = entList.Count;
            SROperation2.Instance.entListReadyCount = 0;
            if (entList.Count > 200)
            {
                Thread t = new Thread(new ThreadStart(SetWaitPic));
                t.Start();
            }

            if (entList == null)
            {
                SROperation2.Instance.isLoading = false;
                return;
            }
            
            foreach (var item in entList)
            {
                AddPic(item);
                ++SROperation2.Instance.entListReadyCount;
            }
            SROperation2.Instance.isLoading = false;
        }

        internal void AddPic(SRRC_ResourceEntity item)
        {
            ListViewItem litem = new ListViewItem();
            if (item.Dtype == 0)//文件夹
            {
                litem.ImageKey = "folder";
            }
            else if (item.Dtype == 1)//图片
            {
                litem.ImageKey = "image";
            }
            else
            {
                litem.ImageKey = item.Extend1.ToLower();
            }
            litem.Name = item.Id.ToString();
            litem.Text = item.Name;
            litem.Tag = item;
            this.listView1.Items.Add(litem);

        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (OnPageClicked != null)
            {
                OnPageClicked(sender, new MyEventArgs() { Action = 0 });//把按钮自身作为参数传递
            }
        }

        internal void BindData()
        {
            string strData = "";
            if (isTemp)
            {
                strData = SROperation.Instance.CenterLanZhiTemp;
            }
            else
            {
                 strData = SROperation.Instance.CenterLanZhi;
            }            
            entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Id in(" + strData + ") ");
            this.SetData(entList);
        }
        
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems != null && OnPageClicked != null)
            {
                Int32 index = 0;
                foreach (ListViewItem litem in this.listView1.Items)
                {
                    if ((litem.Tag as SRRC_ResourceEntity).Id == (this.listView1.SelectedItems[0].Tag as SRRC_ResourceEntity).Id)
                    {
                        break;
                    }
                    index++;
                }
                OnPageClicked(sender, new MyEventArgs() { Action = 1, Parameter = (this.listView1.SelectedItems[0].Tag as SRRC_ResourceEntity).Serverip + (this.listView1.SelectedItems[0].Tag as SRRC_ResourceEntity).Path + "|" + index + "|" + (this.listView1.SelectedItems[0].Tag as SRRC_ResourceEntity).Id });//把按钮自身作为参数传递
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            this._mouseDown = e.Button;
            if (e.Button == System.Windows.Forms.MouseButtons.Right && OnPageClicked != null)
            {
                ListViewItem itemUnder = this.listView1.GetItemAt(e.X, e.X);
                if (itemUnder != null)
                    OnPageClicked(sender, new MyEventArgs() { Action = 2, Parameter = itemUnder.Tag });//把按钮自身作为参数传递
            }
        }

        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            this.listView1.DoDragDrop(this.listView1.SelectedItems, DragDropEffects.Move);
        }

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void listView1_DragLeave(object sender, EventArgs e)
        {
            if (this.listView1.SelectedItems == null || this.listView1.SelectedItems.Count == 0) return;
            Point pt = this.listView1.PointToClient(MousePosition);
            bool isMouseIn = this.listView1.Bounds.Contains(pt); 
            if (!isMouseIn)
            {
                List<string> list = new List<string>();
                foreach (ListViewItem lvi in this.listView1.SelectedItems)
                {
                    SRRC_ResourceEntity ent = lvi.Tag as SRRC_ResourceEntity;
                    string path="";
                    if (ent.Iscomposite) //复合文件
                    {
                        var item = DataBase.Instance.tSRRC_Resource.Get_Entity(ent.Pid);
                        if (item == null) continue;
                        item.Usecount++;
                        DataBase.Instance.tSRRC_Resource.Update(item);
                        if (this._mouseDown == System.Windows.Forms.MouseButtons.Left)
                        {
                            path = item.Serverip + item.Path;
                        }
                        else if (this._mouseDown == System.Windows.Forms.MouseButtons.Right)
                        {
                            List<SRRC_ResourceEntity> maxEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, "pid=[$pid$] and lower(Extend1)=[$extend1$]", new DataParameter("pid", item.Pid), new DataParameter("extend1", "max"));
                            if (maxEntList == null || maxEntList.Count == 0)
                            {
                                MessageBox.Show(string.Format("{0}复合文件无MAX文件，请修改！", item.Name.Substring(0, item.Name.LastIndexOf('.'))));
                                return;
                            }
                            else if (maxEntList.Count > 1)
                            {
                                MessageBox.Show(string.Format("{0}复合文件有{1}个MAX文件，请修改！", item.Name.Substring(0, item.Name.LastIndexOf('.')), maxEntList.Count));
                                return;
                            }
                            else
                            {
                                var maxEnt = maxEntList.First();
                                path = maxEnt.Serverip + maxEnt.Path;
                            }
                        }
                    }
                    else
                    {
                        path = ent.Serverip + ent.Path;
                    }
                    ent.Usecount++;
                    DataBase.Instance.tSRRC_Resource.Update(ent);
                    if (path != "" && !list.Contains(path))
                    {
                        list.Add(path);
                    }
                }

                if (list.Count > 0)
                {
                    //Thread t = new Thread(new ThreadStart(ProcessHelper.AddAndDelNetUse));
                    //t.Start();
                    IDataObject poj = new DataObject(DataFormats.FileDrop, list.ToArray());
                    poj.SetData(poj);
                    this.listView1.DoDragDrop(poj, DragDropEffects.Copy);

                }
            }
        }

        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            if (SROperation2.Instance.PicSelected != null)
            {
                foreach (SRRC_ResourceEntity item in SROperation2.Instance.PicSelected)
                {
                    if (item.Dtype == 0) continue;
                    Int32 ires = 0;
                    if (isTemp)
                    {
                         ires = SROperation.Instance.CenterLanZhiTemp_Add(item.Id);
                    }
                    else
                    {
                         ires = SROperation.Instance.CenterLanZhi_Add(item.Id);
                    }
                    if (ires > 0)
                    {
                        this.AddPic(item);
                    }
                }
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;
            if (obj != null && OnPageClicked != null)
            {
                switch (obj.Text)
                {
                    case "选择全部":
                        {
                            if (this.listView1.Items != null)
                            {
                                foreach (ListViewItem litem in this.listView1.Items)
                                {
                                    litem.Selected = true;
                                }
                            }
                        }
                        break;
                    case "清除选择":
                        {
                            if (this.listView1.SelectedItems != null && this.listView1.SelectedItems.Count > 0)
                            {
                                foreach (ListViewItem litem in this.listView1.SelectedItems)
                                {
                                    SRRC_ResourceEntity ent = litem.Tag as SRRC_ResourceEntity;
                                    if (isTemp)
                                    {
                                        Int32 ires = SROperation.Instance.CenterLanZhiTemp_Remove(ent.Id);
                                    }
                                    else
                                    {
                                        Int32 ires = SROperation.Instance.CenterLanZhi_Remove(ent.Id);
                                    }
                                    SROperation2.Instance.Center2ImageDict.Remove(ent.Id.ToString());
                                    litem.Remove();
                                }
                            }
                        }
                        break;
                    case "清除所有":
                        {
                            this.listView1.Items.Clear();
                            if (isTemp)
                            {
                                SROperation.Instance.CenterLanZhiTemp = "";
                            }
                            else
                            {
                                SROperation.Instance.CenterLanZhi = "";
                            }

                        }
                        break;
                    case "复制到指定目录":                        
                    case "跳转到资源目录":
                        {
                            SROperation2.Instance.Center2PicSelected.Clear();
                            if (this.listView1.SelectedItems != null)
                            {
                                foreach (ListViewItem litem in this.listView1.SelectedItems)
                                {
                                    SROperation2.Instance.Center2PicSelected.Add(litem.Tag as SRRC_ResourceEntity);
                                }
                                OnPageClicked(sender, new MyEventArgs() { Action = 6, Parameter = sender });//把按钮自身作为参数传递
                            }
                        }
                        break;
                }
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.label1.BackColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(143)))), ((int)(((byte)(178)))));
            this.FilmStrip.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.isTemp = false;
            this.BindData();
        }

        private void FilmStrip_Click(object sender, EventArgs e)
        {
            this.FilmStrip.BackColor = Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(143)))), ((int)(((byte)(178)))));
            this.label1.BackColor = Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(37)))));
            this.isTemp = true;
            this.BindData();
        }

        private void Center2_Enter(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Center2";
        }
        #region 图片绘制
        public delegate void SetImageListDelegate(string key, Image image);
        void DownLoadImage(object obj)
        {
            string[] pass = obj as string[];
            string key = pass[0];
            string path = pass[1];
            using (new IdentityScope(Param.ServerIP.Description,
                                Param.ServerIP.Remark,
                                Param.ServerIP.Title))
            {
                Image image = Image.FromFile(path);
                //MemoryStream ms = SirdRoom.ManageSystem.Library.Common.Image.ImageOperation.CreateThumb(path, 256, 256);
                MemoryStream ms = new MemoryStream();
                image.Save(ms, image.RawFormat);
                if (ms == null) return;
                image = Image.FromStream(ms);
                //image.Save(@"C:\Users\tanche\Desktop\New folder (3)\" + key + ".jpg");
                GC.Collect();
                listView1.Invoke(new SetImageListDelegate(SetImageList), key, image);
            }
        }
        public void SetImageList(string key, Image image)
        {
            //if (listView1.Items.ContainsKey(key) && !SROperation2.Instance.Center2ImageDict.ContainsKey(key))
            //{
            //    // this.imageList1.Images.Add(key, image);  //imageList中的图片会失真。故不使用Listview默认的图像列表。
            //    SROperation2.Instance.Center2ImageDict.Add(key, image);
                ListViewItem lvi = listView1.Items.Find(key, true)[0];
               // lvi.ImageKey = key;
                waitLoadImageId.Remove(key);
                listView1.RedrawItems(lvi.Index, lvi.Index, true);
                //SRLogHelper.Instance.AddLog("日志", "SetImageList," + lvi.Name);
            //}
        }
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            string imageKey = e.Item.ImageKey;
            SRRC_ResourceEntity ent = e.Item.Tag as SRRC_ResourceEntity;
            if (imageKey == "image" && !waitLoadImageId.Contains(ent.Id.ToString()) && !SROperation2.Instance.Center2ImageDict.ContainsKey(ent.Id.ToString()))
            {
                //图片，未加载
                waitLoadImageId.Add(ent.Id.ToString());
                //Thread t = new Thread(new ParameterizedThreadStart(DownLoadImage));
                //t.Start(new string[] { ent.Id.ToString(), ent.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + ent.Path });
                SROperation2.Instance.Center2ImageBlockingCollection.Add(new KeyValuePair<string, string>(ent.Id.ToString(), ent.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + ent.Path));
                e.DrawDefault = true;
            }
            else
            {
                Image image1;
                if (SROperation2.Instance.Center2ImageDict.ContainsKey(ent.Id.ToString()))
                {
                    image1 = SROperation2.Instance.Center2ImageDict[ent.Id.ToString()];
                }
                else
                {
                    image1 = SROperation2.Instance.Center2ImageDict[e.Item.ImageKey];
                }
                Size size = e.Item.ImageList.ImageSize;
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                if ((e.State & ListViewItemStates.Selected) != 0 && e.Item.Selected)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), e.Bounds);

                    Rectangle re = new Rectangle(e.Bounds.X + (e.Bounds.Width - size.Width) / 2, e.Bounds.Y + 2, size.Width, size.Height);
                    e.Graphics.DrawImage(image1, re);
                    //绘制次数
                    re = new Rectangle(re.X, re.Y + (re.Height - listView1.Font.Height + 2), re.Width, listView1.Font.Height + 2);
                    e.Graphics.DrawString((e.Item.Tag as SRRC_ResourceEntity).Usecount.ToString(), listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                    if (ent.Iscomposite)
                    {
                        e.Graphics.DrawString("*", listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    }
                }
                else
                {
                    Rectangle re = new Rectangle(e.Bounds.X + (e.Bounds.Width - size.Width) / 2, e.Bounds.Y + 2, size.Width, size.Height);
                    e.Graphics.DrawImage(image1, re);
                    //绘制次数
                    re = new Rectangle(re.X, re.Y + (re.Height - listView1.Font.Height + 2), re.Width, listView1.Font.Height + 2);
                    e.Graphics.DrawString((e.Item.Tag as SRRC_ResourceEntity).Usecount.ToString(), listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                    if (ent.Iscomposite)
                    {
                        e.Graphics.DrawString("*", listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                    }
                }
            }
        }
        #endregion



    }
}
