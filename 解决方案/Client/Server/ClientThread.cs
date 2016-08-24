using SirdRoom.ManageSystem.Library.Data;
using SirdRoom.ORM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Web;

namespace SirdRoom.ManageSystem.ClientApplication
{
    public class ClientThread
    {
        Encoding encoding = Encoding.GetEncoding("GB2312"); //
        //解码器（可以用于汉字）
        private Socket socketWatch;
        //private string data = null;
        private byte[] receiveBytes = new byte[1024];//
        // 定义端口
        private int listenPort = 7000;
        //服务器端设置缓冲区
        //private int recCount;
        //HtmlExecute htmlExe = null;
        //传递连接socket  
        List<ClientEntity> priClientList = new List<ClientEntity>();
        Dictionary<string, Thread> dictThread = new Dictionary<string, Thread>();  
        public ClientThread()
        {
            listenPort = SRLibFun.StringConvertToInt32(SRConfig.Instance.GetAppString("Port"));
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socketWatch.Bind(new IPEndPoint(GetIP(), listenPort));
            socketWatch.Listen(10);
        }

        IPAddress GetIP()
        {
            IPAddress[] arrls = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress item in arrls)
            {
                if (item.AddressFamily == AddressFamily.InterNetwork)
                    return item;
            }
            return arrls[0];
        }

        //数据处理接口
        public void ClientServer()
        {
            try
            {
                while (true)
                {
                    Socket sokConnection = socketWatch.Accept();
                    Console.WriteLine(DateTime.Now + "_连接成功_" + sokConnection.RemoteEndPoint);
                    LogHelper.Instance.AddLog("日志", "记录", "连接成功_" + sokConnection.RemoteEndPoint);
                    Byte[] sendBytes = ArConvert.strToToHexByte("21808500");
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "Send: Msg:{0}", "21808500");
                    LogHelper.Instance.AddLog("日志", "记录", "Send: Msg:{0}"+ "21808500");
                    sokConnection.Send(sendBytes, 0);

                    Thread thr = new Thread(RecMsg);
                    thr.IsBackground = true;
                    thr.Start(sokConnection);
                    dictThread.Add(sokConnection.RemoteEndPoint.ToString(), thr);  //  将新建的线程 添加 到线程的集合中去。  
                }
            }
            catch (Exception ex)
            {
                Console.Write("出现异常："+ex.ToString());
                LogHelper.Instance.AddLog("日志", "异常", "出现异常：" + ex.ToString());
                //Console.ReadLine();
            }
        }

        #region
        Int32 ik = 0;
        void RecMsg(object sokConnectionparn)
        {
            Socket sokClient = sokConnectionparn as Socket;
            while (true)
            {
                int length = -1;
                try
                {
                    length = sokClient.Receive(receiveBytes); // 接收数据，并返回数据的长度；  
                    ik = 0;
                }
                catch (Exception se)
                {
                    //sokClient.Connect(sokClient.RemoteEndPoint);
                    ik++;
                    Console.WriteLine("异常：" + se.Message);
                    LogHelper.Instance.AddLog("日志", "异常", se.Message);
                    if (ik >= 3) //三次容错
                    {
                        // 从 通信套接字 集合中删除被中断连接的通信套接字；  
                        if (this.priClientList.Exists(m => m.RemoteEndPoint.Equals(sokClient.RemoteEndPoint.ToString())) == true)
                            this.priClientList.RemoveAll(m => m.RemoteEndPoint.Equals(sokClient.RemoteEndPoint.ToString()));
                        // 从通信线程集合中删除被中断连接的通信线程对象；  
                        dictThread.Remove(sokClient.RemoteEndPoint.ToString());
                        break;
                    }
                }
                if (length > 0)
                {
                    #region 处理接收到的数据
                    string receiveString = ArConvert.byteToHexStr(receiveBytes.Take(length).ToArray());
                    Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "Received: {0}", receiveString);
                    LogHelper.Instance.AddLog("日志", "记录", "Received:"+ receiveString);
                    //处理连包 心跳
                    string strXT = "";
                    if (length >= 6 && receiveString.Substring(0, 8).Equals("2183FF00") == true)
                    {
                        strXT = receiveString.Substring(0, 12);
                        this.ExecuteData(sokClient, receiveString.Substring(0, 12));
                    }
                    //数据
                    this.ExecuteData(sokClient, String.IsNullOrEmpty(strXT) == false ? receiveString.Replace(strXT, "") : receiveString);
                    #endregion
                }
            }
        }

        //void ExecuteData(object objval)
       void ExecuteData(Socket _ClientSocket, string receiveString)
        {
            try
            {
                if (receiveString.Length >= 8)
                {
                    //心跳
                    if (receiveString.Substring(0, 8).Equals("2183FF00") == true || receiveString.Substring(0, 8).Equals("21848500") == true || receiveString.Substring(0, 8).Equals("21838500") == true)
                    {
                        //LogHelper.Instance.AddLog("日志", "服务端(ExecuteData)", string.Format("心跳：" + _ClientSocket.RemoteEndPoint.ToString() + receiveString));
                        String strCode = "";
                        if (receiveString.Substring(0, 8).Equals("2183FF00") == true)
                            strCode = ArConvert.Convert16ToInt(receiveString.Substring(8, 4)).ToString();
                        else
                            strCode = ArConvert.Convert16ToInt(receiveString.Substring(14, 4)).ToString();
                        if (this.priClientList.Any(m => m.Code.Equals(strCode) == true) == false) //新增
                        {
                            this.priClientList.Add(new ClientEntity(strCode, _ClientSocket, DateTime.Now) { RemoteEndPoint = _ClientSocket.RemoteEndPoint.ToString() });
                            //LogHelper.Instance.AddLog("日志", "Sql1", "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$]___________ " + DateTime.Now + strCode);

                            DataBaseHelper.Instance.Helper.ExecuteNonQuery(System.Data.CommandType.Text, "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$] "
                               , new DataParameter("Updatetiem", DateTime.Now), new DataParameter("Code", strCode)
                                );
                        }
                        else //修改
                        {
                            ClientEntity clientEnt = this.priClientList.FirstOrDefault(m => m.Code.Equals(strCode) == true);
                            //if (clientEnt.RemoteEndPoint.Equals(_ClientSocket.RemoteEndPoint.ToString()) == false)
                            {
                                clientEnt.RefreshTime = DateTime.Now;

                                //LogHelper.Instance.AddLog("日志", "Sql2", "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$]___________ " + DateTime.Now + strCode);

                                DataBaseHelper.Instance.Helper.ExecuteNonQuery(System.Data.CommandType.Text, "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$] "
                               , new DataParameter("Updatetiem", DateTime.Now), new DataParameter("Code", strCode)
                                );
                            }
                        }
                    }
                    if (receiveString.Substring(0, 8).Equals("2183FF00") == false)
                    {
                        if (this.priClientList.Any(m => m.RemoteEndPoint.Equals(_ClientSocket.RemoteEndPoint.ToString()) == true) == true) //有效设备
                        {
                            ClientEntity clientEnt = this.priClientList.FirstOrDefault(m => m.RemoteEndPoint.Equals(_ClientSocket.RemoteEndPoint.ToString()) == true);
                            clientEnt.RefreshTime = DateTime.Now;

                            String strsql = "delete from SRTE_DeviceCMD where addtime<DateAdd(day,-5,getdate());update SRTE_Device set Updatetiem=getdate() where Code=(select top 1 SRTE_DeviceCode from SRTE_DeviceCMD where Code=[$Code$]); update SRTE_DeviceCMD set State=1,ReturnCMD='" + receiveString + "' where Code=[$Code$]; ";
                            if (receiveString.Substring(0, 8).Equals("2183A900") == true) //信号机报警
                            {
                                //receiveString
                                String strDe = "";
                                Int32 ipid = -1;
                                string strejz = ArConvert.Convert16To2(receiveString.Substring(10, 2), 8);
                                Int32 ixw1 = ArConvert.Convert16ToInt(receiveString.Substring(12, 2));
                                Int32 ixw2 = ArConvert.Convert16ToInt(receiveString.Substring(14, 2));
                                if (strejz.Substring(0, 1) == "1" && ixw1 > 0)
                                    strDe += "相位" + ixw1 + "红绿灯同亮;";
                                if (strejz.Substring(1, 1) == "1" && ixw1 > 0)
                                    strDe += "相位" + ixw1 + "红灯故障;";
                                if (strejz.Substring(2, 1) == "1" && ixw1 > 0 && ixw2 > 0)
                                    strDe += "相位" + ixw1 + "、" + ixw2 + "绿冲突;";
                                if (strejz.Substring(3, 1) == "1")
                                    strDe += "通信故障;";
                                if (strejz.Substring(4, 1) == "1")
                                    strDe += "其它故障;";
                                if (strejz.Substring(5, 1) == "1")
                                    strDe += "液晶屏故障;";
                                if (strejz.Substring(6, 1) == "1")
                                    strDe += "存储器故障;";
                                if (strejz.Substring(6, 1) == "1")
                                    strDe += "时钟故障;";
                                if (strejz.Equals("00000000") == true)
                                    strDe += "故障解除;";
                                strDe = strDe.TrimEnd(';');
                                strsql += " insert into SR_Systemrecord(Pid,Title,Description,Adddate,Ltype) values(" + ipid + ",'" + clientEnt.Code + "','" + strDe + "',GETDATE(),'事件');";
                            }
                            else if (receiveString.Substring(0, 8).Equals("2183A100") == true) //检测器数据表
                            {
                                //insert into SRTE_Flow values('',GETDATE(),1,1);
                                for (int i = 1; i < 49; i++)
                                {
                                    strsql += String.Format( " insert into SRTE_Flow values('{2}',GETDATE(),{0},{1}); ",
                                            i,
                                            ArConvert.Convert16ToInt(receiveString.Substring(10 + (i - 1) * 14 + 2, 2)),
                                            clientEnt.Code
                                        );
                                }
                            }
                            DataBaseHelper.Instance.Helper.ExecuteNonQuery(CommandType.Text, strsql, new DataParameter("Code", clientEnt.MsgCode));
                            clientEnt.MsgCode = "";
                            clientEnt.CMD = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(String.Format("{0}_方法：{1}_数据包：{2}_异常内容：{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "ExecuteData", receiveString, ex.Message));
                LogHelper.Instance.AddLog("日志", "异常", String.Format("{0}_方法：{1}_数据包：{2}_异常内容：{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "ExecuteData", receiveString, ex.Message));
                //LogHelper.Instance.AddLog("异常", "服务端(ExecuteData)", ex.Message);
            }
        }

       //void ExecuteData(object objval)
       public void ExecuteDataTest( string receiveString)
       {
           try
           {
               if (receiveString.Length >= 8)
               {
                   //心跳
                   if (receiveString.Substring(0, 8).Equals("2183FF00") == true || receiveString.Substring(0, 8).Equals("21848500") == true || receiveString.Substring(0, 8).Equals("21838500") == true)
                   {
                       //LogHelper.Instance.AddLog("日志", "服务端(ExecuteData)", string.Format("心跳：" + _ClientSocket.RemoteEndPoint.ToString() + receiveString));
                       String strCode = "";
                       if (receiveString.Substring(0, 8).Equals("2183FF00") == true)
                           strCode = ArConvert.Convert16ToInt(receiveString.Substring(8, 4)).ToString();
                       else
                           strCode = ArConvert.Convert16ToInt(receiveString.Substring(14, 4)).ToString();
                       if (this.priClientList.Any(m => m.Code.Equals(strCode) == true) == false) //新增
                       {
                           //this.priClientList.Add(new ClientEntity(strCode, _ClientSocket, DateTime.Now) { RemoteEndPoint = _ClientSocket.RemoteEndPoint.ToString() });
                           //LogHelper.Instance.AddLog("日志", "Sql1", "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$]___________ " + DateTime.Now + strCode);

                           DataBaseHelper.Instance.Helper.ExecuteNonQuery(System.Data.CommandType.Text, "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$] "
                              , new DataParameter("Updatetiem", DateTime.Now), new DataParameter("Code", strCode)
                               );
                       }
                       else //修改
                       {
                           ClientEntity clientEnt = this.priClientList.FirstOrDefault(m => m.Code.Equals(strCode) == true);
                           //if (clientEnt.RemoteEndPoint.Equals(_ClientSocket.RemoteEndPoint.ToString()) == false)
                           {
                               clientEnt.RefreshTime = DateTime.Now;

                               //LogHelper.Instance.AddLog("日志", "Sql2", "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$]___________ " + DateTime.Now + strCode);

                               DataBaseHelper.Instance.Helper.ExecuteNonQuery(System.Data.CommandType.Text, "  update SRTE_Device set Updatetiem=[$Updatetiem$] where Code=[$Code$] "
                              , new DataParameter("Updatetiem", DateTime.Now), new DataParameter("Code", strCode)
                               );
                           }
                       }
                   }
                   if (receiveString.Substring(0, 8).Equals("2183FF00") == false)
                   {
                       //if (this.priClientList.Any(m => m.RemoteEndPoint.Equals(_ClientSocket.RemoteEndPoint.ToString()) == true) == true) //有效设备
                       {
                           ClientEntity clientEnt = new ClientEntity(); //this.priClientList.FirstOrDefault(m => m.RemoteEndPoint.Equals(_ClientSocket.RemoteEndPoint.ToString()) == true);
                           clientEnt.RefreshTime = DateTime.Now;

                           String strsql = "delete from SRTE_DeviceCMD where addtime<DateAdd(day,-5,getdate());update SRTE_Device set Updatetiem=getdate() where Code=(select top 1 SRTE_DeviceCode from SRTE_DeviceCMD where Code=[$Code$]); update SRTE_DeviceCMD set State=1,ReturnCMD='" + receiveString + "' where Code=[$Code$]; ";
                           if (receiveString.Substring(0, 8).Equals("2183A900") == true) //信号机报警
                           {
                               //receiveString
                               String strDe = "";
                               //Int32 ipid = -1;
                               string strejz = ArConvert.Convert16To2(receiveString.Substring(10, 2), 8);
                               Int32 ixw1 = ArConvert.Convert16ToInt(receiveString.Substring(12, 2));
                               Int32 ixw2 = ArConvert.Convert16ToInt(receiveString.Substring(14, 2));
                               if (strejz.Substring(0, 1) == "1" && ixw1 > 0)
                                   strDe += "相位" + ixw1 + "红绿灯同亮;";
                               if (strejz.Substring(1, 1) == "1" && ixw1 > 0)
                                   strDe += "相位" + ixw1 + "红灯故障;";
                               if (strejz.Substring(2, 1) == "1" && ixw1 > 0 && ixw2 > 0)
                                   strDe += "相位" + ixw1 + "、" + ixw2 + "绿冲突;";
                               if (strejz.Substring(3, 1) == "1")
                                   strDe += "通信故障;";
                               if (strejz.Substring(4, 1) == "1")
                                   strDe += "其它故障;";
                               if (strejz.Substring(5, 1) == "1")
                                   strDe += "液晶屏故障;";
                               if (strejz.Substring(6, 1) == "1")
                                   strDe += "存储器故障;";
                               if (strejz.Substring(6, 1) == "1")
                                   strDe += "时钟故障;";
                               if (strejz.Equals("00000000") == true)
                                   strDe += "故障解除;";
                               strDe = strDe.TrimEnd(';');
                               strsql += " insert into SR_Systemrecord(Pid,Title,Description,Adddate,Ltype) values(1,[$Code$],'" + strDe + "',GETDATE(),'事件');";
                           }
                           else if (receiveString.Substring(0, 8).Equals("2183A100") == true) //检测器数据表
                           {
                               //insert into SRTE_Flow values('',GETDATE(),1,1);
                               for (int i = 1; i < 49; i++)
                               {
                                   strsql += String.Format(" insert into SRTE_Flow values([$Code$],GETDATE(),{0},{1}); ",
                                           i,
                                           ArConvert.Convert16ToInt(receiveString.Substring(10 + (i - 1) * 14 + 2, 2))
                                       );
                               }
                           }
                           DataBaseHelper.Instance.Helper.ExecuteNonQuery(CommandType.Text, strsql, new DataParameter("Code", clientEnt.MsgCode));
                           clientEnt.MsgCode = "";
                           clientEnt.CMD = "";
                       }
                   }
               }
           }
           catch (Exception ex)
           {
               Console.WriteLine(String.Format("{0}_方法：{1}_数据包：{2}_异常内容：{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "ExecuteData", receiveString, ex.Message));
               LogHelper.Instance.AddLog("日志", "异常", String.Format("{0}_方法：{1}_数据包：{2}_异常内容：{3}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "ExecuteData", receiveString, ex.Message));
               //LogHelper.Instance.AddLog("异常", "服务端(ExecuteData)", ex.Message);
           }
       }

        #endregion

        /// <summary>
        /// 发送函数
        /// </summary>
        /// <param name="strCode"></param>
        /// <param name="strMsg"></param>
        /// <returns></returns>
        public Boolean SendMsg(String strCode, String strMsg,string strMsgCode)
        {
            try
            {
                if(String.IsNullOrEmpty(strCode) == true || string.IsNullOrEmpty(strMsg) == true)
                    return false;
                if (this.priClientList.Any(m => m.Code.Equals(strCode) == true && m.RefreshTime.AddMinutes(10) >= DateTime.Now) == false)
                    return false;
                ClientEntity clientEnt = this.priClientList.FirstOrDefault(m => m.Code.Equals(strCode) == true);
                clientEnt.MsgCode = strMsgCode;
                if (strMsg.Length >= 8)
                {
                    clientEnt.CMD = strMsg.Substring(0, 8);
                }
                Byte[] sendBytes = ArConvert.strToToHexByte(strMsg);
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "Send: Code:{0},Msg:{1}", strCode, strMsg);
                LogHelper.Instance.AddLog("日志", "记录", String.Format("Send: Code:{0},Msg:{1}", strCode, strMsg));
                //LogHelper.Instance.AddLog("日志", "服务端(SendMsg)", string.Format("Send: Code:{0},Msg:{1}", strCode, strMsg));
                Boolean bjg = clientEnt.ClientSoket.Send(sendBytes, 0) > 0 ? true : false;
                //clientEnt.ClientSoket.Close();
                //clientEnt.ClientSoket.co
                return bjg;
            }
            catch (Exception ex)
            {
                Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "异常" + "服务端(SendMsg)" + ex.Message);
                LogHelper.Instance.AddLog("日志", "异常", "服务端(SendMsg)" + ex.Message);
                //LogHelper.Instance.AddLog("错误", "服务端(SendMsg)", ex.Message);
            }
            return false;
        }

        /// <summary>
        /// 设备是否在线
        /// </summary>
        /// <param name="strCode"></param>
        /// <returns></returns>
        public Boolean IsOnline(String strCode)
        {
            if (this.priClientList.Any(m => m.Code.Equals(strCode) == true && m.RefreshTime.AddMinutes(10) >= DateTime.Now) == false) return false;
            return true;
        }
    }
}