using System;
using System.Collections.Generic;
using System.ComponentModel;

using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SirdRoom.ManageSystem.Library;
using SirdRoom.ManageSystem.Library.DataRelated;
using SirdRoom.ORM;
using System.Configuration;
using SirdRoom.Common;
using SirdRoom.ManageSystem.Library.Data;
using System.IO;
using System.Linq;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public partial class FrmLogin : Form
    {
        private delegate void InvokeDelegate();
        private Object thisLock = new Object();
        private AutoResetEvent _event = new AutoResetEvent(false);

        private String pristrServer;
        private String pristrPort;
        private String pristrUsername;
        private String pristrPwd;
        private SRLogin.SRLoginResultType priSRLoginResultType = SRLogin.SRLoginResultType.NoInstall;
        public FrmLogin()
        {
            this.DialogResult = DialogResult.No;
            InitializeComponent();
            //this.AcceptButton = this.btnOk;
            //this.lblLoginLog.Visible = false;
            this.BackgroundImage = Image.FromFile(Param.CrrentPath + "\\Images\\Login.png");
            this.picOk.Image = Image.FromFile(Param.CrrentPath + "\\Images\\loginbtn.gif");
        }

        //关闭
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Application.Exit();

        }

        void Login()
        {
            lock (this.thisLock)
            {
                //GU.SetControlVisible(this.lblLoginLog, true);
                //Thread.Sleep(100);
                SRLogin.SRLoginResultType loginResultType = SRLogin.SRLoginResultType.NoInstall;
                try
                {

                    //ClientWebService client = new ClientWebService();
                    SRLogin login = new SRLogin();
                    Param.Loginname = this.pristrUsername; Param.Pwd = this.pristrPwd;
                    loginResultType = login.ValidateUserAndSetSession(this.pristrUsername, this.pristrPwd);

                    SR_WordbookEntity wordbookEnt = DataBase.Instance.tSR_Wordbook.Get_Entity(String.Format(" title like [$Title$] "), new DataParameter("Title", "\\\\" + this.pristrServer + "%"));
                    if (wordbookEnt == null)
                    {
                        loginResultType = SRLogin.SRLoginResultType.NoServer;
                    }
                    try
                    {
                        using (new IdentityScope(wordbookEnt.Description,
                          wordbookEnt.Remark,
                          wordbookEnt.Title))
                        {
                           // new DirectoryInfo(wordbookEnt.Title).GetFiles();
                        }
                    }
                    catch (Exception)
                    {
                        loginResultType = SRLogin.SRLoginResultType.ConectServerFaile;
                    }
                    Param.IP = this.pristrServer;
                    Param.ServerIP = wordbookEnt;
                    Param.ServerCacheIP = @"\\" + Param.IP + "\\Cache";
                    Thread t = new Thread(new ThreadStart(BackgroudLoadingImage));
                    t.Start();
                }
                catch (Exception)
                {
                    loginResultType = SRLogin.SRLoginResultType.NoInstall;
                }
                this.priSRLoginResultType = loginResultType;

                _event.Set();
            }
        }


        private void FrmLogin_Load(object sender, EventArgs e)
        {
            //<add key="ClientChk" value="false"/>
            //<add key="Client" value=""/>
            #region 记住服务器
            List<String> entList = new List<string>();
            entList = String.IsNullOrEmpty(SRConfig.Instance.GetAppString("ClientServer")) == true ? new List<String>() : Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(SRFun.DecodeReversible(SRConfig.Instance.GetAppString("ClientServer")));
            if (entList != null && entList.Count > 0)
            {
                foreach (var item in entList)
                {
                    this.cbxServer.Items.Add(item);
                }
                this.cbxServer.SelectedIndex = 0;
                this.chkServer.Checked = true;
            }
            #endregion
            #region 记住用户
            Dictionary<String, String> dicUserList = new Dictionary<string, string>();
            dicUserList = String.IsNullOrEmpty(SRConfig.Instance.GetAppString("ClientUser")) == true ? new Dictionary<string, string>() : Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<String, String>>(SRFun.DecodeReversible(SRConfig.Instance.GetAppString("ClientUser")));
            if (dicUserList != null && dicUserList.Count > 0)
            {
                this.cbxUsername.ValueMember = "Value";
                this.cbxUsername.DisplayMember = "Key";
                List<KeyValuePair<string, string>> list = dicUserList.ToList();
                list.Reverse();
                this.cbxUsername.DataSource = list;
                this.checkBox2.Checked = true;
                this.cbxUsername.SelectedIndex = 0;
            }
            #endregion
        }

        //登陆
        private void picOk_Click(object sender, EventArgs e)
        {
            //更新helper
            SRConfig.Instance.SetAppString("ServerIp", this.cbxServer.Text);
            DataBaseHelper.Instance = new DataBaseHelper();
            DataBase.Instance.tSR_User = new SR_User();
            DataBase.Instance.tSR_Wordbook = new SR_Wordbook();
            DataBase.Instance.tSR_Systemrecord = new SR_Systemrecord();
            DataBase.Instance.tSMDictionary = new SMDictionary();
            DataBase.Instance.tSRRC_Biaoji = new SRRC_Biaoji();
            DataBase.Instance.tSRRC_Resource = new SRRC_Resource();
            DataBase.Instance.tSRRC_Resourcebiaojirel = new SRRC_Resourcebiaojirel();
            DataBase.Instance.tSR_UserSetting = new SR_UserSetting();
            //登录按钮隐藏,避免重复点击
            this.picOk.Visible = false;

            String strServer = this.cbxServer.Text;
            string strUsername = this.cbxUsername.Text;
            string strPwd = this.textBox1.Text;

            #region 验证
            //if (string.IsNullOrEmpty(strServer) == true)
            //{
            //    new SRFMessageBox("请选择或输入服务器", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            //}
            //else if (string.IsNullOrEmpty(strPort) == true)
            //{
            //    new SRFMessageBox("请选择或输入端口", "提示", MessageBoxButtons.OK).ShowDialog(); return;
            //}
            //else
            if (string.IsNullOrEmpty(strUsername) == true)
            {
                new SRFMessageBox("请输入用户名", "提示", MessageBoxButtons.OK).ShowDialog(); this.picOk.Visible = true; return;
            }
            else if (string.IsNullOrEmpty(strPwd) == true)
            {
                new SRFMessageBox("请输入密码", "提示", MessageBoxButtons.OK).ShowDialog(); this.picOk.Visible = true; return;
            }
            #endregion

            this.pristrServer = strServer;
            this.pristrPwd = strPwd;
            this.pristrUsername = strUsername;
            //this.lblLoginLog.Visible = true;
            //Thread.Sleep(1000); 
            Thread t = new Thread(new ThreadStart(this.Login));
            t.IsBackground = true;
            t.Start();
            LoadingCheckBoxImageList();//等待时执行
            _event.WaitOne();
            //t = new Thread(new ThreadStart(FrmLogin.GetImageListByLeftSelectedId));
            //t.IsBackground = true;
            //t.Start();
            Thread.Sleep(1000);
            //this.Login();
            //this.lblLoginLog.Visible = false;
            SRLogin.SRLoginResultType loginResultType = this.priSRLoginResultType;
            //SRLogin.SRLoginResultType loginResultType = SRLogin.SRLoginResultType.LoginOk;
            switch (loginResultType)
            {
                case SRLogin.SRLoginResultType.LoginOk:
                    #region 记住服务器
                    List<String> entList = new List<string>();
                    entList = String.IsNullOrEmpty(SRConfig.Instance.GetAppString("ClientServer")) == true ? new List<String>() : Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(SRFun.DecodeReversible(SRConfig.Instance.GetAppString("ClientServer")));
                    if (this.chkServer.Checked == true)
                    {
                        if (entList.Any(m => m.Equals(this.pristrServer) == true) == true)
                        {
                            entList.Remove(this.pristrServer); //如果存在，则移除
                        }
                        entList.Insert(0, this.pristrServer); //插入首位，以便第一个显示
                        SRConfig.Instance.SetAppString("ClientServer", SRFun.EncodeReversible(Newtonsoft.Json.JsonConvert.SerializeObject(entList)));

                    }
                    else
                    {
                        if (entList.Any(m => m.Equals(this.pristrServer) == true) == true)
                        {
                            entList.Remove(this.pristrServer);
                            SRConfig.Instance.SetAppString("ClientServer", SRFun.EncodeReversible(Newtonsoft.Json.JsonConvert.SerializeObject(entList)));
                        }
                    }
                    #endregion
                    #region 记住用户
                    Dictionary<String, String> dicUserList = new Dictionary<string, string>();
                    dicUserList = String.IsNullOrEmpty(SRConfig.Instance.GetAppString("ClientUser")) == true ? new Dictionary<string, string>() : Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<String, String>>(SRFun.DecodeReversible(SRConfig.Instance.GetAppString("ClientUser")));
                    if (this.checkBox2.Checked == true)
                    {
                        if (dicUserList.ContainsKey(this.pristrUsername) == true)
                        {
                            dicUserList.Remove(this.pristrUsername);
                        }
                        dicUserList.Add(this.pristrUsername, this.pristrPwd);                                                                     
                        SRConfig.Instance.SetAppString("ClientUser", SRFun.EncodeReversible(Newtonsoft.Json.JsonConvert.SerializeObject(dicUserList)));

                    }
                    else
                    {
                        if (dicUserList.ContainsKey(this.pristrUsername) == true)
                        {
                            dicUserList.Remove(this.pristrUsername);
                            SRConfig.Instance.SetAppString("ClientUser", SRFun.EncodeReversible(Newtonsoft.Json.JsonConvert.SerializeObject(dicUserList)));
                        }
                    }
                    #endregion                    
                    #region 写日志
                    //SirdRoom.Data.SQL.SRSystemRecord.Create_SRSystemRecordInsert(
                    //    new SirdRoom.Data.SQL.SRSystemRecord(0, -1, "登陆成功", String.Format("IP:{0} 用户名:{1}进入系统!", Request.UserHostAddress, strUsername), DateTime.Now, "Ok", SRSystemRecordType.Log)
                    //    , SRSystemRecordMode.Local
                    //    );
                    DataBase.Instance.tSR_Systemrecord.Add(new SR_SystemrecordEntity()
                    {
                        Adddate = DateTime.Now,
                        Ltype = "日志",
                        Title = Param.Loginname,
                        Description = "用户登陆",
                        Remark = "登陆"
                    });
                    #endregion
                    Param.LoginState = true;
                    Param.Loginname = this.pristrUsername;
                    Param.Pwd = this.pristrPwd;
                    List<DataParameter> whereParam = (new List<DataParameter> { new DataParameter("Loginname", this.pristrUsername) });
                    Param.UserEnt = DataBase.Instance.tSR_User.Get_Entity(" Loginname=[$Loginname$] ", whereParam.ToArray());
                    Param.UserId = Param.UserEnt.Id;
                    Param.GroupId = Param.UserEnt.Groupid;
                    Param.LoginState = true;
                    var userSetting = DataBase.Instance.tSR_UserSetting.Get_Entity(Param.UserId);
                    Param.filterkeyword = userSetting == null ? "" : userSetting.DefaultKeyword;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    //if (Application.OpenForms["FrmLogin"] != null) Application.OpenForms["FrmLogin"].Close();
                    break;
                case SRLogin.SRLoginResultType.UsernameError:
                    new SRFMessageBox("用户名不存在", "提示", MessageBoxButtons.OK).ShowDialog(); this.picOk.Visible = true;
                    #region 写日志
                    //SirdRoom.Data.SQL.SRSystemRecord.Create_SRSystemRecordInsert(
                    //    new SirdRoom.Data.SQL.SRSystemRecord(0, -1, "登陆失败", String.Format("IP:{0} 用户名:{1}登陆失败!", Request.UserHostAddress, strUsername), DateTime.Now, "Error", SRSystemRecordType.Log)
                    //    , SRSystemRecordMode.Local
                    //    );
                    #endregion
                    break;
                case SRLogin.SRLoginResultType.PwdError:
                    new SRFMessageBox("密码错误，请重新输入", "提示", MessageBoxButtons.OK).ShowDialog(); this.picOk.Visible = true;
                    #region 写日志
                    //SirdRoom.Data.SQL.SRSystemRecord.Create_SRSystemRecordInsert(
                    //    new SirdRoom.Data.SQL.SRSystemRecord(0, -1, "登陆失败", String.Format("IP:{0} 用户名:{1}密码错误!", Request.UserHostAddress, strUsername), DateTime.Now, "Error", SRSystemRecordType.Log)
                    //    , SRSystemRecordMode.Local
                    //    );
                    #endregion
                    break;
                case SRLogin.SRLoginResultType.AuthorizeExpired:
                    new SRFMessageBox("授权过期！", "提示", MessageBoxButtons.OK).ShowDialog(); this.picOk.Visible = true;
                    #region 写日志
                    //SirdRoom.Data.SQL.SRSystemRecord.Create_SRSystemRecordInsert(
                    //    new SirdRoom.Data.SQL.SRSystemRecord(0, -1, "登陆失败", String.Format("授权过期，不能使用系统!"), DateTime.Now, "Error", SRSystemRecordType.Log)
                    //    , SRSystemRecordMode.Local
                    //    );
                    #endregion
                    break;
                case SRLogin.SRLoginResultType.NoInstall:
                    //Response.Redirect("~/Install/Install.aspx");
                    new SRFMessageBox("无法连接到服务器！", "提示", MessageBoxButtons.OK).ShowDialog(); this.picOk.Visible = true;
                    break;
                default:
                    new SRFMessageBox("登陆失败！", "提示", MessageBoxButtons.OK).ShowDialog(); this.picOk.Visible = true;
                    break;
            }
            //GU.SetControlVisible(this.lblLoginLog, false);

        }

        private void cbxUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.textBox1.Text = this.cbxUsername.SelectedValue.ToString();
        }

        private void 退出ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //后台加载图片
        void BackgroudLoadingImage()
        {
            //Center1默认图片
            SROperation2.Instance.Center1DefaultImageList.Count();
            //SROperation2.Instance.Center2ImageDict = new SortedDictionary<string, Image>();
            //Center2图片，默认加载20张
            List<SRRC_ResourceEntity> temp =  DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, " Id in(" + SROperation.Instance.CenterLanZhi + ") ");
            if (temp == null) return;
            foreach (var item in temp.Take(20))
            {
                //using (new IdentityScope(Param.ServerIP.Description,
                //                Param.ServerIP.Remark,
                //                Param.ServerIP.Title))
                //{
                //    Image image = Image.FromFile(item.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + item.Path);
                //    MemoryStream ms = new MemoryStream();
                //    image.Save(ms, image.RawFormat);
                //    if (ms == null) return;
                //    image = Image.FromStream(ms);
                //    GC.Collect();
                //    SROperation2.Instance.Center2ImageDict.Add(item.Id.ToString(), image);
                //}
                SROperation2.Instance.Center2ImageBlockingCollection.Add(new KeyValuePair<string, string>(item.Id.ToString(), item.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + item.Path));
            }
        }

        //加载CheckBoxImageList图标
        void LoadingCheckBoxImageList()
        {            
            SROperation2.Instance.CheckBoxImageList.ImageSize = new Size(16, 16);
            SROperation2.Instance.CheckBoxImageList.ColorDepth = ColorDepth.Depth32Bit;
            DirectoryInfo di = new DirectoryInfo(@"Images\CheckboxIcon\");
            FileInfo[] fis = di.GetFiles();
            String images = SRConfig.Instance.GetAppString("ImageExt");
            if (fis.Length > 0)
            {
                foreach (FileInfo fi in fis)
                {
                    if (images.Contains(fi.Extension.Trim('.').ToLower()))
                    {
                       // SRLogHelper.Instance.AddLog("日志", "FrmLogin", "LoadingCheckBoxImageList", fi.FullName);
                        SROperation2.Instance.CheckBoxImageList.Images.Add(fi.Name.Replace(fi.Extension, ""), Image.FromFile(fi.FullName));
                    }
                }
            }
            
        }

        private void 清除当前服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> entList = new List<string>();
            entList = String.IsNullOrEmpty(SRConfig.Instance.GetAppString("ClientServer")) == true ? new List<String>() : Newtonsoft.Json.JsonConvert.DeserializeObject<List<String>>(SRFun.DecodeReversible(SRConfig.Instance.GetAppString("ClientServer")));
            if (entList.Any(m => m.Equals(this.cbxServer.Text) == true) == true)
            {
                entList.Remove(this.cbxServer.Text);
                SRConfig.Instance.SetAppString("ClientServer", SRFun.EncodeReversible(Newtonsoft.Json.JsonConvert.SerializeObject(entList)));
            }
            if (entList != null && entList.Count > 0)
            {
                foreach (var item in entList)
                {
                    this.cbxServer.Items.Add(item);
                }
                this.cbxServer.SelectedIndex = 0;
                this.chkServer.Checked = true;
            }
            else
            {
                this.cbxServer.Text = "";
            }
        }

        private void 清除当前用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<String, String> dicUserList = new Dictionary<string, string>();
            dicUserList = String.IsNullOrEmpty(SRConfig.Instance.GetAppString("ClientUser")) == true ? new Dictionary<string, string>() : Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<String, String>>(SRFun.DecodeReversible(SRConfig.Instance.GetAppString("ClientUser")));
            if (dicUserList.ContainsKey(this.cbxUsername.Text) == true)
            {
                dicUserList.Remove(this.cbxUsername.Text);
                SRConfig.Instance.SetAppString("ClientUser", SRFun.EncodeReversible(Newtonsoft.Json.JsonConvert.SerializeObject(dicUserList)));
            }
            if (dicUserList != null && dicUserList.Count > 0)
            {
                this.cbxUsername.ValueMember = "Value";
                this.cbxUsername.DisplayMember = "Key";
                List<KeyValuePair<string, string>> list = dicUserList.ToList();
                list.Reverse();
                this.cbxUsername.DataSource = list;
                this.checkBox2.Checked = true;
                this.cbxUsername.SelectedIndex = 0;
            }
            else
            {
                this.cbxUsername.Text = "";
                this.cbxPwd.Text = "";
            }
        }
    }
}
