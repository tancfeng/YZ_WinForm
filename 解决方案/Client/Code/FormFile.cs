using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SirdRoom.ManageSystem.ClientApplication.Code
{
    public class FormFile
    {
        public static FormFile Instance = new FormFile();
        public Boolean SaveFilename(String strData)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "Excel文件(*.csv)|*.csv";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.WriteFileContent(saveFileDialog1.FileName, strData);
                return true;
            }
            return false;
        }
        //写
        void WriteFileContent(String strFileName, String strData)
        {
            try
            {
                if (File.Exists(strFileName) == true) File.Delete(strFileName);
                FileStream fs = new FileStream(strFileName, FileMode.CreateNew);
                StreamWriter streamWriter = new StreamWriter(fs,Encoding.GetEncoding("gb2312"));
                streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                streamWriter.WriteLine(strData);
                streamWriter.Flush();
            }
            catch
            {
                throw new Exception("写文件失败");
            }
        }
    }
}
