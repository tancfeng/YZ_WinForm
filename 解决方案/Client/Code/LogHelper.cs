using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

    /// <summary>
    /// 日志助手类
    /// </summary>
public class LogHelper
{
    public static LogHelper Instance = new LogHelper();

    private static object logSync = new object();

    public LogHelper()
    {
        //if (ConfigurationManager.AppSettings["LogPath"] != null)
        //{
        //    LogPath = ConfigurationManager.AppSettings["LogPath"].ToString();
        //}
        LogPath = Application.StartupPath.TrimEnd('\\') + @"\Log"; 
    }

    /// <summary>
    /// 日志存放路径
    /// </summary>
    public string LogPath { get; set; }

    /// <summary>
    /// 添加日志
    /// </summary>
    /// <param name="logType">日志类型（枚举）</param>
    /// <param name="appactionType">程序地址，如：Service</param>
    /// <param name="model">提示模式，如：登录成功</param>
    /// <param name="operation">操作</param>
    /// <param name="content">日志内容</param>
    public void AddLog(string model, string operation, string content)
    {
        //LogType logType, AppcationType appactionType
        String logType = "WinService";
        //String appactionType = "Log";
        string thisLogPath = this.LogPath.Trim('\\');  // string.Format("{0}\\{1}", this.LogPath.Trim('\\'), appactionType.ToString().Trim('\\'));
        try
        {
            if (!Directory.Exists(thisLogPath))
            {
                DirectoryInfo di = Directory.CreateDirectory(thisLogPath);
                di = null;
            }
        }
        catch
        {
            thisLogPath = "C:\\Log\\";
        }

        try
        {
            string saveLogPath = Path.Combine(thisLogPath, logType.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
            lock (logSync)
            {
                using (StreamWriter sw = new StreamWriter(saveLogPath, true, Encoding.GetEncoding("gb2312")))
                {
                    sw.WriteLine(string.Format("[{0}][{1}][{2}][{3}]",
                        DateTime.Now.ToString(),
                        logType.ToString(),
                        model + "-" + operation,
                        content
                        ));
                }
            }
        }
        catch (Exception ex)
        {
            throw new Exception("生成日志失败！错误信息：" + ex.Message);
        }
    }
}
