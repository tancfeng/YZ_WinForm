using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using SirdRoom.ManageSystem.Library;
using SirdRoom.ManageSystem.Library.Data;

namespace SirdRoom.ManageSystem.ClientApplication
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //Param.Loginname = "admin";
            //Param.UserId = 1;
            //FrmFrame frm = new FrmFrame();
            //frm.SetUserControl(new SirdRoom.ManageSystem.ClientApplication.Pages.Wordbook.Add());
            Application.Run(new FrmMain());    
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // MessageBox.Show(e.Exception.Message);
            SRLogHelper.Instance.AddLog("异常", e.Exception.Message+"|"+e.Exception.Source+"|"+e.Exception.StackTrace);
        }
    }
}
