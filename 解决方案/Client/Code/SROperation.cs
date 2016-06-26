using Newtonsoft.Json;
using SirdRoom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

public class SROperation
{
    public static SROperation Instance = new SROperation();


    #region Left
    /// <summary>
    /// 左边树选中Id
    /// </summary>
    public int LeftSelectedId
    {
        get
        {
            return SRLibFun.StringConvertToInt32(SRConfig.Instance.GetAppString("LeftSelectedId"));
        }
        set
        {
            SRConfig.Instance.SetAppString("LeftSelectedId", value.ToString());

        }
    }
    /// <summary>
    /// 左边选中类型
    /// </summary>
    public String LeftDtype
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("LeftDtype");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "Study";
                SRConfig.Instance.SetAppString("LeftDtype", "Study");
            }
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("LeftDtype", value);
        }
    }
    /// <summary>
    /// 左边显示类型，默认显示:Default，跨越显示:Cross
    /// </summary>
    public string LeftShowType
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("LeftShowType");
            if (String.IsNullOrEmpty(strValue))
            {
                strValue = "Default";
                SRConfig.Instance.SetAppString("LeftShowType", strValue);
            }
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("LeftShowType", value);
        }
    }
    #endregion

    #region Center
    public int Center1ImageShowNum
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("Center1ImageShowNum");
            if (String.IsNullOrEmpty(strValue))
            {
                strValue = "20";
                SRConfig.Instance.SetAppString("Center1ImageShowNum", strValue);
            }
            return Convert.ToInt32(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("Center1ImageShowNum", value.ToString());
        }
    }

    /// <summary>
    /// Center2栏子
    /// </summary>
    public String CenterLanZhi
    {
        get
        {
            string strValue = "0";
            if (Param.UserId == 0) return strValue;
            SR_UserEntity ent = DataBase.Instance.tSR_User.Get_Entity(Param.UserId);
            if(ent == null)
            {
                return strValue;
            }
            if(ent==null || String.IsNullOrEmpty(ent.Remark))
            {
                ent.Remark = strValue;
                DataBase.Instance.tSR_User.Update(ent);
            }            
            return ent.Remark;
        }
        set
        {
            SR_UserEntity ent = DataBase.Instance.tSR_User.Get_Entity(Param.UserId);
            ent.Remark = value;
            DataBase.Instance.tSR_User.Update(ent);            
        }
    }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="id"></param>
    public int CenterLanZhi_Add(Int32 id)
    {
        Int32 ijg = 0;
        String strValue = this.CenterLanZhi;
        if (String.IsNullOrEmpty(strValue) == false && ("," + strValue + ",").Contains("," + id + ",") == false)
        {
            strValue += "," + id;
            SR_UserEntity ent = DataBase.Instance.tSR_User.Get_Entity(Param.UserId);
            ent.Remark = strValue;
            DataBase.Instance.tSR_User.Update(ent);
            ijg = 1;
        }
        return ijg;
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    public int CenterLanZhi_Remove(Int32 id)
    {
        Int32 ijg = 0;
        String strValue = this.CenterLanZhi;
        if (String.IsNullOrEmpty(strValue) == false && ("," + strValue + ",").Contains("," + id + ",") == true)
        {
            strValue = ("," + strValue + ",").Replace("," + id + ",", ",").Trim(',');
            SR_UserEntity ent = DataBase.Instance.tSR_User.Get_Entity(Param.UserId);
            ent.Remark = strValue;
            DataBase.Instance.tSR_User.Update(ent); ijg = 1;
        }
        return ijg;
    }
    /// <summary>
    /// Center2栏子(临时)
    /// </summary>
    public String CenterLanZhiTemp
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("CenterLanZhiTemp");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "0";
                SRConfig.Instance.SetAppString("CenterLanZhiTemp", "0");
            }
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("CenterLanZhiTemp", value);
        }
    }
    /// <summary>
    /// 添加（临时篮子）
    /// </summary>
    /// <param name="id"></param>
    public int CenterLanZhiTemp_Add(Int32 id)
    {
        Int32 ijg = 0;
        String strValue = this.CenterLanZhiTemp;
        if (String.IsNullOrEmpty(strValue) == false && ("," + strValue + ",").Contains("," + id + ",") == false)
        {
            strValue += "," + id;
            SRConfig.Instance.SetAppString("CenterLanZhiTemp", strValue);
            ijg = 1;
        }
        return ijg;
    }
    /// <summary>
    /// 删除(临时篮子)
    /// </summary>
    /// <param name="id"></param>
    public int CenterLanZhiTemp_Remove(Int32 id)
    {
        Int32 ijg = 0;
        String strValue = this.CenterLanZhiTemp;
        if (String.IsNullOrEmpty(strValue) == false && ("," + strValue + ",").Contains("," + id + ",") == true)
        {
            strValue = ("," + strValue + ",").Replace("," + id + ",", ",");
            SRConfig.Instance.SetAppString("CenterLanZhiTemp", strValue.TrimStart(',').TrimEnd(','));
            ijg = 1;
        }
        return ijg;
    }

    /// <summary>
    /// 
    /// </summary>
    public String Keyword
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("Keyword");
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("Keyword", value);
        }
    }
    #endregion

    #region Right
    /// <summary>
    /// 右边选中类型
    /// </summary>
    public String RightDtype
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("RightDtype");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "Study";
                SRConfig.Instance.SetAppString("RightDtype", "Study");
            }
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("RightDtype", value);
        }
    }

    /// <summary>
    /// 是否显示用户面板
    /// </summary>
    public Boolean IsShowUserPanel
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("IsShowUserPanel");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "true";
                SRConfig.Instance.SetAppString("IsShowUserPanel", "true");
            }
            return SRLibFun.StringConvertTobool(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("IsShowUserPanel", value.ToString());
        }
    }
    /// <summary>
    /// 是否显示面板
    /// </summary>
    public Boolean IsShowPanel
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("IsShowPanel");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "true";
                SRConfig.Instance.SetAppString("IsShowPanel", "true");
            }
            return SRLibFun.StringConvertTobool(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("IsShowPanel", value.ToString());
        }
    }
    /// <summary>
    /// 是否显示Keyword
    /// </summary>
    public Boolean IsShowKeyword
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("IsShowKeyword");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "true";
                SRConfig.Instance.SetAppString("IsShowKeyword", "true");
            }
            return SRLibFun.StringConvertTobool(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("IsShowKeyword", value.ToString());
        }
    }

    public Dictionary<string,Image> IconList
    {
        get
        {
           string[] icons = Directory.GetFiles(Application.StartupPath + "\\Icon\\");
            Dictionary<string, Image> dic = new Dictionary<string, Image>();
            String images = SRConfig.Instance.GetAppString("ImageExt");
            if (icons != null && icons.Length > 0)
            {
                FileInfo fi = null;
                foreach (string icon in icons)
                {

                    fi = new FileInfo(icon);
                    if (images.Contains(fi.Extension.Trim('.').ToLower()))
                    {
                        //SRLogHelper.Instance.AddLog("日志", fi.FullName);
                        dic.Add(fi.Name, Image.FromFile(fi.FullName));
                    }
                }
            }
            return dic;
        }
    }
    #endregion

    #region 菜单
    /// <summary>
    /// 图像栏子
    /// </summary>
    public Boolean IsShowLZ
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("IsShowLZ");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "true";
                SRConfig.Instance.SetAppString("IsShowLZ", "true");
            }
            return SRLibFun.StringConvertTobool(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("IsShowLZ", value.ToString());
        }
    }
    /// <summary>
    /// 是否显示操作过滤面板
    /// </summary>
    public Boolean IsShowFilter
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("IsShowFilter");
            if (string.IsNullOrEmpty(strValue) == true)
            {
                strValue = "true";
                SRConfig.Instance.SetAppString("IsShowFilter", "true");
            }
            return SRLibFun.StringConvertTobool(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("IsShowFilter", value.ToString());
        }
    }
    /// <summary>
    /// 排序方式
    /// </summary>
    public Int32 Orderby
    {
        get
        {
            Int32 strValue = SRLibFun.StringConvertToInt32(SRConfig.Instance.GetAppString("Orderby"));
            if (strValue <= 0)
            {
                strValue = 2;
                SRConfig.Instance.SetAppString("Orderby", strValue.ToString());
            }
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("Orderby", value.ToString());
        }
    }
    public int OrderType
    {
        get
        {
            int strValue = -1;
            if (!string.IsNullOrEmpty(SRConfig.Instance.GetAppString("OrderType")))
            {
                strValue = SRLibFun.StringConvertToInt32(SRConfig.Instance.GetAppString("OrderType"));

            }
            if (strValue != 0 && strValue !=1)
            {
                strValue = 1;
                SRConfig.Instance.SetAppString("OrderType", strValue.ToString());
            }
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("OrderType", value.ToString());
        }
    }
    public bool OnlyShow
    {
        get
        {
           return SRLibFun.StringConvertTobool(SRConfig.Instance.GetAppString("OnlyShow"));            
        }
        set
        {
            SRConfig.Instance.SetAppString("OnlyShow", value.ToString());
        }
    }
    /// <summary>
    /// 显示方式
    /// </summary>
    public int DisplayMode
    {
        get
        {
            Int32 strValue = SRLibFun.StringConvertToInt32(SRConfig.Instance.GetAppString("DisplayMode"));
            if (strValue <= 0)
            {
                strValue = 1;
                SRConfig.Instance.SetAppString("DisplayMode", "1");
            }
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("DisplayMode", value.ToString());
        }
    }
    #endregion

    #region 页面布局
    public int WindowWidth
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("WindowWidth");
            if(String.IsNullOrEmpty(strValue))
            {
                strValue = "1000";
                SRConfig.Instance.SetAppString("WindowWidth", strValue);
            }
            return Convert.ToInt32(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("WindowWidth", value.ToString());
        }
    }
    public int WindowHeight
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("WindowHeight");
            if (String.IsNullOrEmpty(strValue))
            {
                strValue = "700";
                SRConfig.Instance.SetAppString("WindowHeight", strValue);
            }
            return Convert.ToInt32(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("WindowHeight", value.ToString());
        }
    }
    public int SplitContainer1SplitterDistance
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("SC1SD");
            if(String.IsNullOrEmpty(strValue))
            {
                strValue = "300";
                SRConfig.Instance.SetAppString("SC1SD", strValue);
            }
            return Convert.ToInt32(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("SC1SD", value.ToString());
        }
    }
    public int SplitContainer2SplitterDistance
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("SC2SD");
            if (String.IsNullOrEmpty(strValue))
            {
                strValue = "600";
                SRConfig.Instance.SetAppString("SC2SD", strValue);
            }
            return Convert.ToInt32(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("SC2SD", value.ToString());
        }
    }
    public int SplitContainer3SplitterDistance
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("SC3SD");
            if (String.IsNullOrEmpty(strValue))
            {
                strValue = "400";
                SRConfig.Instance.SetAppString("SC3SD", strValue);
            }
            return Convert.ToInt32(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("SC3SD", value.ToString());
        }
    }
    public int BrowserSplitContainer1SplitterDistance
    {
        get
        {
            string strValue = SRConfig.Instance.GetAppString("BSC1SD");
            if (String.IsNullOrEmpty(strValue))
            {
                strValue = "400";
                SRConfig.Instance.SetAppString("BSC1SD", strValue);
            }
            return Convert.ToInt32(strValue);
        }
        set
        {
            SRConfig.Instance.SetAppString("BSC1SD", value.ToString());
        }
    }
    #endregion

    public class UrlEntity
    {
        public int Index { get; set; }
        public int UrlId { get; set; }
    }
    /// <summary>
    /// 操作记录列表
    /// </summary>
    public String OperationList
    {
        get
        {
            String strValue = SRConfig.Instance.GetAppString("OperationList");
            //if (string.IsNullOrEmpty(strValue) == true)
            //{
            //    strValue = "0";
            //    SRConfig.Instance.SetAppString("OperationList", "0");
            //}
            return strValue;
        }
        set
        {
            SRConfig.Instance.SetAppString("OperationList", value);
        }
    }
    public void OperationList_Add(Int32 urlId)
    {
        string strValue = SRConfig.Instance.GetAppString("OperationList");
        List<int> entList = String.IsNullOrEmpty(strValue) == true ? null : JsonConvert.DeserializeObject<List<int>>(strValue);
        if (entList == null) entList = new List<Int32>();
        entList.Insert(0, urlId);
        SRConfig.Instance.SetAppString("OperationList", JsonConvert.SerializeObject(entList.Take(10)));
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="itype">0表示退，1表示进，2表示最新一条数据</param>
    /// <returns>无数据返回null</returns>
    public UrlEntity OperationList_Get(Int32 itype, Int32 iindex)
    {
        UrlEntity strRe = null;
        string strValue = SRConfig.Instance.GetAppString("OperationList");
        List<int> entList = String.IsNullOrEmpty(strValue) == true ? null : JsonConvert.DeserializeObject<List<int>>(strValue);
        if (entList == null) entList = new List<Int32>();
        try
        {
            switch (itype)
            {
                case 0:
                    strRe = new UrlEntity() { Index = iindex + 1, UrlId = entList[iindex + 1] };
                    break;
                case 1:
                    strRe = new UrlEntity() { Index = iindex - 1, UrlId = entList[iindex - 1] };
                    break;
                case 2:
                    strRe = new UrlEntity() { Index = 0, UrlId = entList[0] };
                    break;
                default:
                    break;
            }
        }
        catch (Exception)
        {
            switch (itype)
            {
                case 0:
                    strRe = new UrlEntity() { Index = entList.Count - 1 };
                    break;
                case 1:
                    strRe = new UrlEntity() { Index = 0 };
                    break;
                case 2:
                    strRe = new UrlEntity() { Index = 0 };
                    break;
                default:
                    break;
            }
        }
        return strRe;
    }

}

