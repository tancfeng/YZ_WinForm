using SirdRoom;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

/// <summary>
/// 不存配置文件的
/// </summary>
public class SROperation2
{
    public static SROperation2 Instance = new SROperation2();

    /// <summary>
    /// 选中的图片Id
    /// </summary>
    private List<SRRC_ResourceEntity> _PicSelected = null;
    public List<SRRC_ResourceEntity> PicSelected
    {
        get { return _PicSelected; }
        set { _PicSelected = value; }
    }

    /// <summary>
    /// 待复制TreeId
    /// </summary>
    public int PicCopyTreeId { get; set; }
    /// <summary>
    /// 操作类型 1剪切 2复制
    /// </summary>
    public Int32 OperationType { get; set; }


    #region Keyword

    /// <summary>
    /// Keyword
    /// </summary>
    public String KeywordFilter { get; set; }
    /// <summary>
    /// 添加
    /// </summary>
    /// <param name="id"></param>
    public int KeywordFilter_Add(Int32 id)
    {
        Int32 ijg = 0;
        String strValue = this.KeywordFilter;
        if (String.IsNullOrEmpty(strValue) == true)
        {
            this.KeywordFilter = id.ToString();
            ijg = 1;
        }
        else if (("," + strValue + ",").Contains("," + id + ",") == false)
        {
            this.KeywordFilter += "," + id;
            ijg = 1;
        }
        return ijg;
    }
    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="id"></param>
    public int KeywordFilter_Remove(Int32 id)
    {
        Int32 ijg = 0;
        String strValue = this.KeywordFilter;
        if (String.IsNullOrEmpty(strValue) == false && ("," + strValue + ",").Contains("," + id + ",") == true)
        {
            strValue = ("," + strValue + ",").Replace("," + id + ",", ",").Trim(',');
            this.KeywordFilter = strValue;
            ijg = 1;
        }
        return ijg;
    }
    #endregion

    /// <summary>
    /// Center1中总的项目数
    /// </summary>
    public int entListCount { get; set; }
    /// <summary>
    /// Center1中已加载的项目数
    /// </summary>
    public int entListReadyCount { get; set; }
    /// <summary>
    /// 左边栏，鼠标右键点击时获取的被选的SRRC_ResourceEntity
    /// </summary>
    public SRRC_ResourceEntity LeftMouseRightSelectedEnt { get; set; }
    /// <summary>
    /// 当前操作的面板，Left,Right,Center2
    /// </summary>
    public string FocusPanel { get; set; }
    /// <summary>
    /// 关键字间逻辑
    /// </summary>
    private string _KeywordLogical;
    public string KeywordLogical
    {
        get
        {
            if (_KeywordLogical == null)
            {
                return "and";
            }
            return _KeywordLogical;
        }

        set
        {
            _KeywordLogical = value;
        }
    }
    /// <summary>
    /// 图片预览界面临时篮子,Id
    /// </summary>
    public string CenterLanZhiTemp { get; set; }
    /// <summary>
    /// 图片预览界面篮子 
    /// </summary>
    public List<SRRC_ResourceEntity> BrowserLanZhi { get; set; }
    public int BrowserPicId { get; set; }

    public List<SRRC_ResourceEntity> Center1EntList { get; set; }
    private SortedDictionary<string, Image> _center1ImageDict = new SortedDictionary<string, Image>();
    public SortedDictionary<string,Image> Center1ImageDict { get
        {
            if(_center1ImageDict.Count == 0)
            {
                _center1ImageDict.Clear();
                foreach(var item in Center1DefaultImageList)
                {
                    _center1ImageDict.Add(item.Key, item.Value);
                }
            }
            return _center1ImageDict;
        }
    }
    private SortedDictionary<string, Image> _center2ImageDict = new SortedDictionary<string, Image>();
    public SortedDictionary<string, Image> Center2ImageDict
    {
        get
        {
            if (_center2ImageDict.Count == 0)
            {
                _center2ImageDict.Clear();
                foreach (var item in Center1DefaultImageList)
                {
                    _center2ImageDict.Add(item.Key, item.Value);
                }
            }
            return _center2ImageDict;
        }
    }

    public SortedDictionary<string, Image> Center2_1ImageDict { get; set; }

    public List<String> defaultImageNameList = new List<string>();
    private SortedDictionary<string, Image> _Center1DefaultImageList;
    public SortedDictionary<string,Image> Center1DefaultImageList { get
        {
            if (_Center1DefaultImageList == null)
            {
                string[] defaultIcoS = Directory.GetFiles(Param.CrrentPath + "\\Img\\");
                _Center1DefaultImageList = new SortedDictionary<string, Image>();
                FileInfo fi = null;
                String images = SRConfig.Instance.GetAppString("ImageExt");
                foreach (string item in defaultIcoS)
                {
                    fi = new FileInfo(item);
                    
                    if (images.Contains(fi.Extension.Trim('.').ToLower()))
                    {
                        string key = fi.Name.Replace(fi.Extension, "");
                        _Center1DefaultImageList.Add(key, Image.FromFile(item));
                        defaultImageNameList.Add(key);
                    }
                }
            }
            return _Center1DefaultImageList;
        }
    }
    public bool isLoading { get; set; }
    //图像篮子选中的项
    private List<SRRC_ResourceEntity> _Center2PicSelected = new List<SRRC_ResourceEntity>();
    public List<SRRC_ResourceEntity> Center2PicSelected
    {
        get { return _Center2PicSelected; }
        set { _Center2PicSelected = value; }
    }
    /// <summary>
    /// 记录Left每个面板上次选择的Id;
    /// </summary>
    public int ResourceSelectedId { get; set; }
    public int StudySelectedId { get; set; }
    public int FavoritesSelectedId { get; set; }
    /// <summary>
    /// 复制到指定目录，已复制的数量
    /// </summary>
    public int CopyCount { get; set; }
    /// <summary>
    /// TreeView CheckedBox 图标
    /// </summary>
    public ImageList CheckBoxImageList = new ImageList();
    public BlockingCollection<KeyValuePair<string,string>> Center1ImageBlockingCollection = new BlockingCollection<KeyValuePair<string, string>>(new ConcurrentStack<KeyValuePair<string, string>>());
    public BlockingCollection<KeyValuePair<string, string>> Center2ImageBlockingCollection = new BlockingCollection<KeyValuePair<string, string>>(new ConcurrentStack<KeyValuePair<string, string>>());
    public BlockingCollection<KeyValuePair<string, string>> Center2_1ImageBlockingCollection = new BlockingCollection<KeyValuePair<string, string>>(new ConcurrentStack<KeyValuePair<string, string>>());
    /// <summary>
    /// Browser中，用于终止取图线程
    /// </summary>
    public bool isContinue { get; set; }

    public bool isFilterKeywordChanged { get; set; }
}
