using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using SirdRoom;
using System.Data.SqlClient;

namespace SirdRoom.ManageSystem.Library.Pub.Common
{
    public class SRSMSFun
    {
        //public void SetUserControl(UserControl userControl)
        //{
        //    this.MainPanelFrame.Controls.Clear();
        //    //userControl.Location = new System.Drawing.Point(13, 42);
        //    userControl.Name = "userControl11";
        //    // userControl.Size = new System.Drawing.Size(720, 450);
        //    userControl.TabIndex = 1;
        //    userControl.Dock = DockStyle.Fill;
        //    this.MainPanelFrame.Controls.Add(userControl);

        //    this.Controls.Clear();
        //    this.Controls.Add(this.MainPanelFrame);
        //    this.Controls.Add(this.menuStrip1);

        //}

        /// <summary>
        /// 将datatable转为CVS文件
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static void FromDataGridViewToCVSFile(DataGridView dgv, String strSelecFolder)
        {
            String strJG = "";
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                strJG += col.HeaderText + ",";
            }
            if (strJG.EndsWith(",") == true)
            {
                strJG = strJG.Substring(0, strJG.Length - 1);
            }
            strJG += "\r\n";
            //内容
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewColumn col in dgv.Columns)
                {
                    if (col.Visible == true)
                    {
                        strJG += ((row.Cells[col.DataPropertyName].Value == DBNull.Value || row.Cells[col.DataPropertyName].Value == null) ? "" : row.Cells[col.DataPropertyName].Value.ToString()) + ",";
                    }
                }
                if (strJG.EndsWith(",") == true)
                {
                    strJG = strJG.Substring(0, strJG.Length - 1);
                }
                strJG += "\r\n";
            }
            if (strJG.EndsWith("\r\n") == true)
            {
                strJG = strJG.Substring(0, strJG.Length - 2);
            }

            //if (strSelecFolder.EndsWith("\\") == true)
            //{//E:\ee
            //    strSelecFolder = strSelecFolder.Substring(0, strSelecFolder.Length - 1);
            //}
            //String strFilepath = String.Format("{0}\\{1}.cvs", strSelecFolder, SirdRoom.Common.SRExcel.GetRadomFilename());

            SirdRoom.Common.SRExcel.GenerateCVSFileFromString(strSelecFolder, strJG);
        }

        /// <summary>
        /// 将datatable转为CVS文件
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static void FromDataTableToCVSFile(DataTable dgv, String strSelecFolder)
        {
            String strJG = "";
            foreach (DataColumn col in dgv.Columns)
            {
                strJG += col.ColumnName + ",";
            }
            if (strJG.EndsWith(",") == true)
            {
                strJG = strJG.Substring(0, strJG.Length - 1);
            }
            strJG += "\r\n";
            //内容
            foreach (DataRow row in dgv.Rows)
            {
                foreach (DataColumn col in dgv.Columns)
                {
                    strJG += ((row[col.ColumnName] == DBNull.Value || row[col.ColumnName] == null) ? "" : row[col.ColumnName].ToString()) + ",";
                }
                if (strJG.EndsWith(",") == true)
                {
                    strJG = strJG.Substring(0, strJG.Length - 1);
                }
                strJG += "\r\n";
            }
            if (strJG.EndsWith("\r\n") == true)
            {
                strJG = strJG.Substring(0, strJG.Length - 2);
            }

            //if (strSelecFolder.EndsWith("\\") == true)
            //{//E:\ee
            //    strSelecFolder = strSelecFolder.Substring(0, strSelecFolder.Length - 1);
            //}
            //String strFilepath = String.Format("{0}\\{1}.cvs", strSelecFolder, SirdRoom.Common.SRExcel.GetRadomFilename());

            SirdRoom.Common.SRExcel.GenerateCVSFileFromString(strSelecFolder, strJG);
        }

        //public static void FromCSVFileToDatatable(String strFilePath)
        //{
        //    //SELECT   * INTO   theImportTable FROM OPENROWSET( 'MSDASQL ', 'Driver={Microsoft   Text   Driver   (*.txt;   *.csv)};DEFAULTDIR=D:\;Extensions=CSV; ', 'SELECT   *   FROM   CSVFile.csv ') 
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (System.Data.SqlClient.SqlException E)
        //            {
        //                connection.Close();
        //                throw new Exception(E.Message);
        //            }
        //        }
        //    }
        //}
        

        //字符到图片
        public static Image StringToImage(String str)
        {

            if (String.IsNullOrEmpty(str)) return null;
            Image img = ArrayToImage(String2Bytes(str));
            return img;

        }
        //字符到Path
        public static String StringToPath(Byte[] bytes,String strKZM)
        {
            if (bytes == null) return "";
            //return ArrayToImage(String2Bytes(str));
            String strPath = System.IO.Directory.GetCurrentDirectory();
            if(strPath.EndsWith("\\") == true)
            {
                strPath += "tmp\\" ;
            }
            else
            {
                strPath += "\\" + "tmp\\" ;
            }
            if (Directory.Exists(strPath) == false)
            {
                Directory.CreateDirectory(strPath);
            }

            strPath += SirdRoom.Common.SRExcel.GetRadomFilename();
            strPath += strKZM;

            Image img = ArrayToImage(bytes);
            if (img != null)
            {
                img.Save(strPath);
            }

            return strPath;
        }
        //Path到字符
        public static String ImagePathToString(String strpath)
        {
            if (String.IsNullOrEmpty(strpath)) return string.Empty;
            return Bytes2String(PhotoToArray(strpath));
        }

        public static Image ArrayToImage(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            return Image.FromStream(ms, true); //从刚才存储到内存的数据流中创建Image对象。

        }

        /// <summary> 
        /// 将照片转换为二进制数组 
        /// </summary> 
        /// <param name="path"></param> 
        /// <returns></returns> 
        public static byte[] PhotoToArray(string path)
        {
            FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            byte[] bufferPhoto = new byte[stream.Length];
            stream.Read(bufferPhoto, 0, Convert.ToInt32(stream.Length));
            stream.Flush();
            stream.Close();

            return bufferPhoto;
        }

        


        /** 
         * 
         * @param b byte[] 
         * @return String 
         */
        public static String Bytes2String(byte[] bytearray)
        {
            String StrJG = String.Empty;
            foreach (byte b in bytearray)
            {
                StrJG += (b > 15 ? Convert.ToString(b, 16) : '0' + Convert.ToString(b, 16));
                StrJG += "|";
            }
            if (StrJG.EndsWith("|") == true)
            {
                StrJG.Substring(0, StrJG.Length - 1);
            }
            return StrJG;
        }

        /** 
          * 将指定字符串src，以每两个字符分割转换为16进制形式 
          * 如："2B44EFD9" --> byte[]{0x2B, 0x44, 0xEF, 0xD9} 
          * @param src String 
          * @return byte[] 
          */
        public static byte[] String2Bytes(String src)
        {
            String[] arrB = src.Split(new char[] { '|' });
            byte[] bJG = new byte[arrB.Length];
            for (int i = 0; i < arrB.Length; i++)
            {
                bJG[i] = Convert.ToByte(arrB[i]);
            }
            return bJG;
        }

    }
}
