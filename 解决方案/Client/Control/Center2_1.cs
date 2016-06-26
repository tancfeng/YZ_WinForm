
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
using SirdRoom.ManageSystem.ClientApplication;
using System.IO;
using System.Threading;

namespace ControlLibrary.Control
{
    public partial class Center2_1 : UserControl
    {
        //定义委托
        public delegate void PageClickHandle(object sender, MyEventArgs e);
        //定义事件
        public event PageClickHandle OnPageClicked;
        List<string> waitLoadImageId = new List<string>();
        public Center2_1()
        {
            InitializeComponent();

            this.listView1.View = View.LargeIcon;
            string[] fileStripSize = SRConfig.Instance.GetAppString("FilmStripSize").Split(',');
            this.listView1.LargeImageList = new ImageList();
            //this.listView1.LargeImageList.ImageSize = new Size(Convert.ToInt32(fileStripSize[0]), Convert.ToInt32(fileStripSize[1]));
            this.listView1.LargeImageList.ImageSize = new Size(96, 96);
            this.listView1.ForeColor = Color.White;
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
                ++SROperation2.Instance.entListReadyCount;
                AddPic(item);
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
        
        private void btn_Click(object sender, EventArgs e)
        {
            Int32 itag = 0;
            Label lbl = sender as Label;
            if (lbl != null)
            {
                itag = SRLibFun.StringConvertToInt32(lbl.Tag.ToString());
            }
            else
            {
                PictureBox pic = sender as PictureBox;
                itag = SRLibFun.StringConvertToInt32(pic.Tag.ToString());
            }
            if (OnPageClicked != null)
            {
                OnPageClicked(sender, new MyEventArgs() { Action = itag });//把按钮自身作为参数传递
            }
        }
        List<SRRC_ResourceEntity> entList;
        internal void BindData()
        {
            String strData = (this.TopLevelControl is FrmFrame) ? SROperation2.Instance.CenterLanZhiTemp : SROperation.Instance.CenterLanZhiTemp;
            entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Id in(" + strData + ") ");
            this.SetData(entList);

            if (entList == null || entList.Count == 0)
            {
                this.label2.Visible = false;
                this.label3.Visible = false;
            }
        }
        internal void BindData(ref ListView.ListViewItemCollection lvic)
        {
            listView1.Items.Clear();
            foreach(ListViewItem item in lvic)
            {
                if ((item.Tag as SRRC_ResourceEntity).Dtype != 1)//不为图片
                {
                    lvic.Remove(item);
                    continue; 
                }
                ListViewItem lvi = item.Clone() as ListViewItem;
                lvi.Name = item.Name;
                listView1.Items.Add(lvi);
            }
           ListViewItem i =  listView1.Items.Find(SROperation2.Instance.BrowserPicId.ToString(), true)[0];
            SetSelectedState(i.Index);
            
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (OnPageClicked != null)
            {
                SRRC_ResourceEntity ent = this.listView1.SelectedItems[0].Tag as SRRC_ResourceEntity;
                int index = this.listView1.Items.IndexOf(this.listView1.SelectedItems[0]);
                OnPageClicked(sender, new MyEventArgs() { Action = 1 });//把按钮自身作为参数传递
                OnPageClicked(sender, new MyEventArgs() { Action = 16, Parameter = ent.Serverip + ent.Path + "|" + index + "|" + ent.Id });//把按钮自身作为参数传递
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
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
            if (this.listView1.SelectedItems != null)
            {
                foreach (ListViewItem litem in this.listView1.SelectedItems)
                {
                    SRRC_ResourceEntity ent = litem.Tag as SRRC_ResourceEntity;
                    Int32 ires = SROperation.Instance.CenterLanZhiTemp_Remove(ent.Id);
                    litem.Remove();
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
                    Int32 ires = SROperation.Instance.CenterLanZhiTemp_Add(item.Id);
                    if (ires > 0)
                    {
                        this.AddPic(item);
                    }
                }
            }
        }
        /// <summary>
        /// 设置指定索引的选中状态
        /// </summary>
        /// <param name="index"></param>
        internal void SetSelectedState(int index)
        {
            this.listView1.SelectedItems.Clear();           
            this.listView1.Items[index].Selected = true;
            this.listView1.Items[index].EnsureVisible();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            if (OnPageClicked != null)
            {
                SRRC_ResourceEntity ent = this.listView1.SelectedItems[0].Tag as SRRC_ResourceEntity;
                int index = this.listView1.Items.IndexOf(this.listView1.SelectedItems[0]);
                OnPageClicked(sender, new MyEventArgs() { Action = 1 });//把按钮自身作为参数传递
                OnPageClicked(sender, new MyEventArgs() { Action = 16, Parameter = ent.Serverip + ent.Path + "|" + index + "|" + ent.Id });//把按钮自身作为参数传递
            }
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
      public  void SetImageList(string key, Image image)
        {
            //if (listView1.Items.ContainsKey(key) && !SROperation2.Instance.Center2_1ImageDict.ContainsKey(key))
            //{
                // this.imageList1.Images.Add(key, image);  //imageList中的图片会失真。故不使用Listview默认的图像列表。
                //SROperation2.Instance.Center2_1ImageDict.Add(key, image);
                ListViewItem lvi = listView1.Items.Find(key, true)[0];
                //lvi.ImageKey = key;
                waitLoadImageId.Remove(key);
                listView1.RedrawItems(lvi.Index, lvi.Index, true);
                //SRLogHelper.Instance.AddLog("日志", "SetImageList," + lvi.Name);
            //}
        }
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            string imageKey = e.Item.ImageKey;
            SRRC_ResourceEntity ent = e.Item.Tag as SRRC_ResourceEntity;
            if (imageKey == "image" && !waitLoadImageId.Contains(ent.Id.ToString()) && !SROperation2.Instance.Center2_1ImageDict.ContainsKey(ent.Id.ToString()))
            {
                //图片，未加载
                waitLoadImageId.Add(ent.Id.ToString());
                //Thread t = new Thread(new ParameterizedThreadStart(DownLoadImage));
                //t.Start(new string[] { ent.Id.ToString(), ent.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + ent.Path });
                SROperation2.Instance.Center2_1ImageBlockingCollection.Add(new KeyValuePair<string, string>(ent.Id.ToString(), ent.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + ent.Path));
                e.DrawDefault = true;
            }
            else
            {
                Image image1;
                if (SROperation2.Instance.Center2_1ImageDict.ContainsKey(ent.Id.ToString()))
                {
                    image1 = SROperation2.Instance.Center2_1ImageDict[ent.Id.ToString()];
                }
                else
                {
                    image1 = SROperation2.Instance.Center2_1ImageDict[e.Item.ImageKey];
                }
                Size size = e.Item.ImageList.ImageSize;
                e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                if ( e.Item.Selected)
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
