using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

public class ProcessHelper
{
    public static void ExecCmd(List<string> cmdList)
    {
        if (cmdList == null || cmdList.Count == 0) return;
        try
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;

            p.Start();
            foreach (string commandText in cmdList)
            {
                p.StandardInput.WriteLine(commandText);
            }
            p.StandardInput.WriteLine("exit");
            p.WaitForExit();
            p.Close();
        }
        catch (Exception e)
        {
            SRLogHelper.Instance.AddLog("异常", "ProcessHelper", "ExecCmd", e.Message);
        }
    }

    /// <summary>
    /// 添加和删除本机保存的目标主机的连接，用于从服务端复制时
    /// </summary>
    public static void AddAndDelNetUse()
    {
       // AddNetUse();
      //  Thread.SpinWait(2 * 60 * 1000);//等待2分钟，期间用于复制文件。
      //  DelNetUse();
    }
    public static void AddNetUse()
    {
        //CMD命令
        List<string> cmdList = new List<string>();
        //添加----------
        cmdList.Add(string.Format(@"net use \\{0} {1} /user:{2}", Param.IP, Param.ServerIP.Remark, Param.ServerIP.Description));
        ProcessHelper.ExecCmd(cmdList);
    }
    public static void DelNetUse()
    {
        //CMD命令
        List<string> cmdList = new List<string>();
        cmdList.Add(string.Format("cmdkey /delete:{0}", Param.IP));//删除保存的凭据
        cmdList.Add(string.Format(@"net use \\{0} /delete /yes", Param.IP));
        ProcessHelper.ExecCmd(cmdList);
    }
}