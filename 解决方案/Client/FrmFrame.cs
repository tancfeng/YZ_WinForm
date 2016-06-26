using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class FrmFrame : Form
    {

        public FrmFrame()
        {
            InitializeComponent();            
        }
        #region
        //设置显示控件
        public void SetUserControl(UserControl userControl)
        {
            this.panelMain.Controls.Clear();
            userControl.TabIndex = 1;
            userControl.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(userControl);
            System.Windows.Forms.Control[] ctrls = this.Controls.Find("btnOk", true);
            if (ctrls != null && ctrls.Length > 0)
            {
                this.AcceptButton = ctrls[0] as Button;
            }
            System.Windows.Forms.Control[] ctrls2 = this.Controls.Find("btnCancel", true);
            if (ctrls2 != null && ctrls2.Length > 0)
            {
                this.CancelButton = ctrls2[0] as Button;
            }            
        }



        /// <summary>
        /// 打开加载
        /// </summary>
        public void OpenLoding()
        {
            this.label1.Visible = false;
            this.panelLoading.Visible = true;
            this.panelMain.Visible = false;
            this.Refresh();
        }
        /// <summary>
        /// 打开加载
        /// </summary>
        public void OpenLoding(String strTS)
        {
            this.label1.Text = strTS;
            this.panelLoading.Visible = true;
            this.panelMain.Visible = false;
            this.label1.Location = new Point((this.panelLoading.Width - this.label1.Width) / 2, (this.panelLoading.Height - this.label1.Height) / 2);
            this.Refresh();
        }
        /// <summary>
        /// 关闭加载
        /// </summary>
        public void CloseLoding()
        {
            this.panelLoading.Visible =false ;
            this.panelMain.Visible = true;
        }

        #endregion
    }
}
