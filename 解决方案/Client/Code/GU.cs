using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;


    internal  class GU
    {

        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetListBoxSafe(ListBox control, String text);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetListBox(ListBox control, String text)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetListBoxSafe scts = new SetListBoxSafe(SetListBox);
                    control.Invoke(scts, new Object[] { control, text });
                }
                else
                {
                    control.Items.Insert(0, text);
                }
            }
        }

        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetTreeNodeSafe(TreeView control, TreeNodeCollection val, String strc);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetTreeNode(TreeView control, TreeNodeCollection val, String strc)
        {
            if (control != null)
            {
                string[] arrls = strc.Split(new char[] { '|' });
                if (control.InvokeRequired)
                {
                    SetTreeNodeSafe scts = new SetTreeNodeSafe(SetTreeNode);
                    control.Invoke(scts, new Object[] { control, val,strc });
                }
                else
                {
                    if (String.IsNullOrEmpty(strc) == true)
                    {
                        for (int i = 0; i < val.Count; i++)
                        {                         
                        control.Nodes.Add(val[i]);   
                        }
                    }
                    else
                    {
                        TreeNode pnode = null;
                        Int32 ik = 0;
                        foreach (var item in arrls)
                        {
                            if (ik == 0)
                            {
                                pnode = control.Nodes[SRLibFun.StringConvertToInt32(item)];
                            }
                            else
                            {
                                pnode = pnode.Nodes[SRLibFun.StringConvertToInt32(item)];
                            }
                            ik++;
                        }
                        for (int i = 0; i < val.Count; i++)
                        {
                            pnode.Nodes.Add(val[i]);
                        }
                    }
                    control.ExpandAll();
                }
            }
        }

        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetControlTextSafe(Control control, String text);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetControlText(Control control, String text)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetControlTextSafe scts = new SetControlTextSafe(SetControlText);
                    control.Invoke(scts, new Object[] { control, text });
                }
                else
                {
                    control.Text = text;
                }
            }
        }

        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetControlVisibleSafe2(Control control, bool val);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetControlVisible(Control control,  bool val)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetControlVisibleSafe2 scts = new SetControlVisibleSafe2(SetControlVisible);
                    control.Invoke(scts, new Object[] { control, val });
                }
                else
                {
                    control.Visible = val;
                }
            }
        }


        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetControlEnableSafe(Control control, bool val);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetControlEnable(Control control, bool val)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetControlEnableSafe scts = new SetControlEnableSafe(SetControlEnable);
                    control.Invoke(scts, new Object[] { control, val });
                }
                else
                {
                    control.Enabled = val;
                }
            }
        }


        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetControlPictureSafe(PictureBox control, Image val);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetControlPicture(PictureBox control, Image val)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetControlPictureSafe scts = new SetControlPictureSafe(SetControlPicture);
                    control.Invoke(scts, new Object[] { control, val });
                }
                else
                {
                    control.Image = val;
                }
            }
        }



        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetControlPicture2Safe(PictureBox control, Image val,int fx);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetControlPicture2(PictureBox control, Image val,int fx)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetControlPicture2Safe scts = new SetControlPicture2Safe(SetControlPicture2);
                    control.Invoke(scts, new Object[] { control, val, fx });
                }
                else
                {
                    control.Image = val;
                    switch (fx)
                    {
                        case 4:
                            break;
                        case 8:
                            control.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case 12:
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case 16:
                            control.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                            //绿反向
//                            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
//顺时针旋转90度 RotateFlipType.Rotate90FlipNone 
//逆时针旋转90度 RotateFlipType.Rotate270FlipNone 
//水平翻转 RotateFlipType.Rotate180FlipY 
//垂直翻转 RotateFlipType.Rotate180FlipX
                        case 104:
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            break;
                        case 108:
                            control.Image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipX);                            
                            break;
                        case 112:
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            break;
                        case 116:
                            control.Image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipX);                
                            break;
                        //绿 45度
                        case 203:
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            control.Image = GetRotateImage(control.Image, -45);
                            break;
                        case 207:
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            control.Image = GetRotateImage(control.Image, 45);
                            break;
                        case 211:
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            control.Image = GetRotateImage(control.Image, -45);
                            break;
                        case 215:
                            control.Image.RotateFlip(RotateFlipType.Rotate180FlipY);
                            control.Image = GetRotateImage(control.Image, 45);
                            break;
                        //绿 45度反向
                        case 303:
                            control.Image = GetRotateImage(control.Image, -45);
                            break;
                        case 307:
                            control.Image = GetRotateImage(control.Image, 45);
                            break;
                        case 311:
                            control.Image = GetRotateImage(control.Image, -45);
                            break;
                        case 315:
                            control.Image = GetRotateImage(control.Image, 45);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public static Image GetRotateImage(Image img, float angle)
        {
            angle = angle % 360;//弧度转换 
            double radian = angle * Math.PI / 180.0;
            double cos = Math.Cos(radian);
            double sin = Math.Sin(radian);
            //原图的宽和高 
            int w = img.Width;
            int h = img.Height;
            int W = (int)(Math.Max(Math.Abs(w * cos - h * sin), Math.Abs(w * cos + h * sin)));
            int H = (int)(Math.Max(Math.Abs(w * sin - h * cos), Math.Abs(w * sin + h * cos)));
            //目标位图 
            Image dsImage = new Bitmap(W, H, img.PixelFormat);
            using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dsImage))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Bilinear;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //计算偏移量 
                Point Offset = new Point((W - w) / 2, (H - h) / 2);
                //构造图像显示区域：让图像的中心与窗口的中心点一致 
                Rectangle rect = new Rectangle(Offset.X, Offset.Y, w, h);
                Point center = new Point(rect.X + rect.Width / 2, rect.Y + rect.Height / 2);
                g.TranslateTransform(center.X, center.Y);
                g.RotateTransform(360 - angle);
                //恢复图像在水平和垂直方向的平移 
                g.TranslateTransform(-center.X, -center.Y);
                g.DrawImage(img, rect);
                //重至绘图的所有变换 
                g.ResetTransform();
                g.Save();
            }
            return dsImage;
        }

        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetWebBrowserSafe(WebBrowser control, String text);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetWebBrowser(WebBrowser control, String text)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetWebBrowserSafe scts = new SetWebBrowserSafe(SetWebBrowser);
                    control.Invoke(scts, new Object[] { control, text });
                }
                else
                {
                    control.DocumentText = text;
                }
            }
        }

        ///// <summary>
        ///// This delegate enables asynchronous calls for setting control Text.
        ///// </summary>
        //public delegate void SetTimerSafe(Timer control);

        ///// <summary>
        ///// Sets the text for the specified control in multithreading circumstances.
        ///// </summary>
        ///// <param name="control"></param>
        ///// <param name="text"></param>
        //public static void SetTimer(Timer control)
        //{
        //    if (control != null)
        //    {
        //        if (control.InvokeRequired)
        //        {
        //            SetTimerSafe scts = new SetTimerSafe(SetTimer);
        //            control.Invoke(scts, new Object[] { control });
        //        }
        //        else
        //        {
        //            control.DocumentText = text;
        //        }
        //    }
        //}




        /// <summary>
        /// This delegate enables asynchronous calls for setting control Text.
        /// </summary>
        public delegate void SetDataGridViewCellSafe(DataGridView control, Int32 irowindex,String strState);

        /// <summary>
        /// Sets the text for the specified control in multithreading circumstances.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="text"></param>
        public static void SetDataGridViewCell(DataGridView control, Int32 irowindex, String strState)
        {
            if (control != null)
            {
                if (control.InvokeRequired)
                {
                    SetDataGridViewCellSafe scts = new SetDataGridViewCellSafe(SetDataGridViewCell);
                    control.Invoke(scts, new Object[] { control, irowindex, strState });
                }
                else
                {
                    control.Rows[irowindex].Cells["State"].Value = strState;
                }
            }
        }

    }
