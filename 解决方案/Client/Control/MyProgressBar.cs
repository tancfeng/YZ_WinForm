using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication.Control
{
    public partial class MyProgressBar : UserControl
    {
        public MyProgressBar(BackgroundWorker worker)
        {
            InitializeComponent();
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.ParentForm.Close();           
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;

            this.label2.Text = e.ProgressPercentage + "%";
            //switch(e.ProgressPercentage)
            //{
            //    case 0:
            //        this.label1.Text = "正在准备复制文件...";
            //        break;
            //    case 20:
            //        this.label1.Text = "正在复制文件...";
            //        break;
            //    case 50:
            //        this.label1.Text = "正在入库及生成缩略图...";
            //        break;
            //    case 100:
            //        this.label1.Text = "文件上传完成！";
            //        break;
            //    default:
            //        break;
            //}
        }


        //工作完成后执行的事件   
        public void OnProcessCompleted(object sender, EventArgs e)
        {
            this.ParentForm.Close();
        }

    }
}
