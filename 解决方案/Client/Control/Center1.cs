using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SirdRoom.ORM;
using System.Threading;
using SirdRoom;
using System.IO;
using System.Runtime.InteropServices;
using SirdRoom.ManageSystem.ClientApplication;
using SirdRoom.ManageSystem.ClientApplication.Control;
using System.Collections.Specialized;
using System.Drawing.Imaging;

namespace ControlLibrary.Control
{
    public partial class Center1 : UserControl
    {

        //定义委托
        public delegate void PageClickHandle(object sender, MyEventArgs e);
        //定义事件
        public event PageClickHandle OnPageClicked;
        //资源列表
        public List<SRRC_ResourceEntity> entList = null;
        List<SRRC_ResourceEntity> staticEntList = null;//保存左边栏焦点原始查询结果，以便右边栏使用
        //图片列表
        List<Image> imageCollection = new List<Image>();
       // private Image image1;
        BackgroundWorker BgWorker;
        //Clipboard存放的用于粘贴的文件列表
        String[] CopyFiles;
        int countSum; //需要复制的总的文件个数
        int ThumbWidth;
        int ThumbHeight;

        bool isTarget = true; //ListView1是否是拖放的目标
        String strWhere = "";//查询条件

        bool[] ImageLoadingTip; //用于标示图像是否已提交下载。
        private bool isMouseWheelDoing;

        StringBuilder uploadFailFile;

        MouseButtons _mouseDown;

        System.Windows.Forms.Timer selectedIndexChangedTimer = new System.Windows.Forms.Timer();

        //
        int _listViewLoadDataOnceCount = 1000;
        public Center1()
        {
            InitializeComponent();

            this.listView1.LargeImageList = this.listView1.SmallImageList = imageList1;
            this.listView1.ForeColor = Color.White;

            contextMenuStrip1.RenderMode = ToolStripRenderMode.Professional;
            contextMenuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());

            this.listView1.MouseWheel += ListView1_MouseWheel;

            selectedIndexChangedTimer.Tick += listView1_SelectedIndexChangedHelper;
            selectedIndexChangedTimer.Interval = 100;
        }



        private void ListView1_MouseWheel(object sender, MouseEventArgs e)
        {
            ;
        }

        public void SetData()
        {
            try
            {
                //this.listView1.Visible = false;
                //this.listView1.Refresh();
                if (SROperation.Instance.DisplayMode < 0 || SROperation.Instance.DisplayMode > 10)
                    return;
                switch (SROperation.Instance.DisplayMode)
                {
                    case 0:
                        this.listView1.View = View.Details;
                        break;
                    case 1:
                        this.listView1.View = View.List;
                        this.imageList1.ImageSize = new Size(16, 16);
                        break;
                    case 2:
                        this.imageList1.ImageSize = new Size(16, 16);
                        this.listView1.View = View.SmallIcon;
                        break;
                    case 3:
                        this.imageList1.ImageSize = new Size(32, 32);
                        this.listView1.View = View.SmallIcon;
                        break;
                    default:
                        this.imageList1.ImageSize = new Size(32 * (SROperation.Instance.DisplayMode - 2), 32 * (SROperation.Instance.DisplayMode - 2));
                        this.listView1.View = View.LargeIcon;
                        break;
                }
                if (this.imageList1.Images.Count == 0)
                {
                    foreach (var item in SROperation2.Instance.Center1DefaultImageList)
                    {
                        this.imageList1.Images.Add(item.Key, item.Value);
                    }
                }
                GC.Collect();
                if (!isMouseWheelDoing)
                {
                    SROperation2.Instance.isLoading = true;
                    listViewLoadData.CancelAsync();                 
                    SROperation2.Instance.Center1ImageDict.Clear();
                    listView1.Items.Clear();
                    if (entList == null)
                    {
                        SROperation2.Instance.isLoading = false;
                        (this.ParentForm as FrmMain).SetLoadStatus();
                        return;
                    }
                    //if (entList.Count > 200)
                    //{
                    //    Thread t = new Thread(new ThreadStart(SetWaitPic));
                    //    t.Start();
                    //}
                    //SROperation2.Instance.entListReadyCount = 0;
                    //foreach (var item in entList)
                    //{
                    //    ++SROperation2.Instance.entListReadyCount;
                    //    ListViewItem litem = new ListViewItem();
                    //    if (item.Dtype == 0)//文件夹
                    //    {
                    //        litem.ImageKey = "folder";
                    //    }
                    //    else if (item.Dtype == 1)//图片
                    //    {
                    //        litem.ImageKey = "image";
                    //    }
                    //    else
                    //    {
                    //        litem.ImageKey = item.Extend1.ToLower();
                    //    }
                    //    if (!SROperation2.Instance.defaultImageNameList.Contains(litem.ImageKey))
                    //    {
                    //        litem.ImageKey = "default";
                    //    }
                    //    litem.Name = item.Id.ToString();
                    //    litem.Text = item.Name;
                    //    litem.Tag = item;
                    //    this.listView1.Items.Add(litem);
                    //}
                    listViewLoadData.RunWorkerAsync();
                }
                else
                {
                    
                }
                
            }
            catch(Exception ex)
            {
                SRLogHelper.Instance.AddLog("异常", "Center1", "SetData", ex.Message);
            }
            finally
            {
                SROperation2.Instance.isLoading = false;
                //this.listView1.Refresh();
                //this.listView1.Visible = true;
                            
            }            
        }


        public void BindData_Bak()
        {
#if debug
            SRLogHelper.Instance.AddLog("日志", DateTime.Now.ToString("mm:ss.ffff"));
#endif
#region 设置排序
            OrderCollection<SRRC_ResourceEntity.FiledType> orderBy = new OrderCollection<SRRC_ResourceEntity.FiledType>();
            //orderBy.Add(new Order<SRRC_ResourceEntity.FiledType>(SRRC_ResourceEntity.FiledType.Extend3, OrderType.Desc));//视图优先排序
            switch (SROperation.Instance.Orderby)
            {
                case 1:
                    {
                        orderBy.Add(new Order<SRRC_ResourceEntity.FiledType>() { ColumnName = SRRC_ResourceEntity.FiledType.Bjtime, OrderType = (OrderType)SROperation.Instance.OrderType });
                    }
                    break;
                case 2:
                    {
                        orderBy.Add(new Order<SRRC_ResourceEntity.FiledType>() { ColumnName = SRRC_ResourceEntity.FiledType.Usecount, OrderType = (OrderType)SROperation.Instance.OrderType });
                    }
                    break;
                case 3:
                    {
                        orderBy.Add(new Order<SRRC_ResourceEntity.FiledType>() { ColumnName = SRRC_ResourceEntity.FiledType.Addtime, OrderType = (OrderType)SROperation.Instance.OrderType });
                    }
                    break;
                case 4:
                    {
                        orderBy.Add(new Order<SRRC_ResourceEntity.FiledType>() { ColumnName = SRRC_ResourceEntity.FiledType.Filesize, OrderType = (OrderType)SROperation.Instance.OrderType });
                    }
                    break;
                case 5:
                    {
                        orderBy.Add(new Order<SRRC_ResourceEntity.FiledType>() { ColumnName = SRRC_ResourceEntity.FiledType.Name, OrderType = (OrderType)SROperation.Instance.OrderType });
                    }
                    break;
                case 6:
                    {
                        orderBy.Add(new Order<SRRC_ResourceEntity.FiledType>() { ColumnName = SRRC_ResourceEntity.FiledType.Id, OrderType = OrderType.Desc });
                    }
                    break;
                default:
                    break;
            }
#endregion
#region 左侧菜单操作、中间区域（center1,center2）
            if (SROperation2.Instance.FocusPanel != "Right")
            {
                Int32 id = SROperation.Instance.LeftSelectedId;
                switch (SROperation.Instance.LeftDtype)
                {
                    case "Resources":
                        {
                            if (!String.IsNullOrEmpty(SROperation.Instance.Keyword))
                            {
                                string sql;
                                if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                {
                                    sql = "with ta as (select * from SRRC_Resource where id=" + id + @"
                                                union all select SRRC_Resource.* from ta,SRRC_Resource where ta.Id=SRRC_Resource.Pid)
                                                select * from ta,SRRC_Resourcebiaojirel as tb on ta.Id=tb.Resource_id where (tb.Biaoji_id in (" + Param.filterkeyword + ") or ta.Dtype=0) and (Name + '.' + Extend1) like  '%" + SROperation.Instance.Keyword + "%' ";
                                }
                                else
                                {
                                    sql = "with ta as (select * from SRRC_Resource where id=" + id + @"
                                                union all select SRRC_Resource.* from ta,SRRC_Resource where ta.Id=SRRC_Resource.Pid)
                                                select * from ta where (Name + '.' + Extend1) like  '%" + SROperation.Instance.Keyword + "%' ";

                                }                                    
                                    staticEntList = SROperation2.Instance.Center1EntList = entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionForViewPriorityBySQL(sql, orderBy);
                            }
                            else
                            {
                                if (SROperation.Instance.LeftShowType == "Cross")
                                {
                                    if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                    {
                                        strWhere = " Pid in (select Id from SRRC_Resource where Pid=[$Pid$]) and Dtype<>0 and Id in ( select Resource_id from SRRC_Resourcebiaojirel where  Biaoji_id in (" + Param.filterkeyword + "))";
                                    }
                                    else
                                    {
                                        strWhere = " Pid in (select Id from SRRC_Resource where Pid=[$Pid$]) and Dtype<>0";
                                    }
                                    staticEntList = SROperation2.Instance.Center1EntList = entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionForViewPriority(orderBy, strWhere, new DataParameter("Pid", id));
                                    if (entList == null || entList.Count == 0) //没有文件
                                    {
                                        if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                        {
                                            strWhere = " Pid=[$Pid$] and (Id in (select Resource_id from SRRC_Resourcebiaojirel where  Biaoji_id in (" + Param.filterkeyword + ")) or Dtype=0)";
                                        }
                                        else
                                        {
                                            strWhere = " Pid=[$Pid$]";
                                        }
                                        staticEntList = SROperation2.Instance.Center1EntList = entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionForViewPriority(orderBy, strWhere, new DataParameter("Pid", id));
                                    }
                                }
                                else
                                {
                                    if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                    {
                                        strWhere = " Pid=[$Pid$] and Id in ( select Resource_id from SRRC_Resourcebiaojirel where  Biaoji_id in (" + Param.filterkeyword + "))";
                                    }
                                    else
                                    {
                                        strWhere = " Pid=[$Pid$]";
                                    }
                                    staticEntList = SROperation2.Instance.Center1EntList = entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionForViewPriority(orderBy, strWhere, new DataParameter("Pid", id));
                                }
                            }
                        }
                        break;
                    case "Study":
                        {
                            if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=0 and Biaoji_id=[$Pid$] ) and Id in (select Resource_id FROM SRRC_Resourcebiaojirel where User_id=0  and  Biaoji_id in (" + Param.filterkeyword + ")) ";
                            }
                            else
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=0 and Biaoji_id=[$Pid$] )";
                            }
                            if (String.IsNullOrEmpty(SROperation.Instance.Keyword) == false)
                            {
                                strWhere += " and (Name + '.' + Extend1) like  '%" + SROperation.Instance.Keyword + "%' ";
                            }
                            staticEntList = SROperation2.Instance.Center1EntList = entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionForViewPriority(orderBy, strWhere, new DataParameter("Pid", id));

                        }
                        break;
                    case "Favorites":
                        {
                            if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=" + Param.UserId + " and Biaoji_id=[$Pid$]) and Id in (select Resource_id FROM SRRC_Resourcebiaojirel where User_id=0  and Biaoji_id in (" + Param.filterkeyword + ")) ";
                            }
                            else
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=" + Param.UserId + " and Biaoji_id=[$Pid$])";
                            }
                            if (String.IsNullOrEmpty(SROperation.Instance.Keyword) == false)
                            {
                                strWhere += " and (Name + '.' + Extend1) like  '%" + SROperation.Instance.Keyword + "%' ";
                            }
                            staticEntList = SROperation2.Instance.Center1EntList = entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionForViewPriority(orderBy, strWhere, new DataParameter("Pid", id));
                        }
                        break;
                    default:
                        break;
                }

                // List<SRRC_ResourceEntity> entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(orderBy, strWhere, new DataParameter("Pid", id));
            }
#endregion

#region Keyword面板操作
            if (SROperation2.Instance.FocusPanel == "Right")
            {
                if (SROperation2.Instance.KeywordFilter == null || SROperation2.Instance.KeywordFilter.Length == 0)//无关键字
                {
                    SROperation2.Instance.Center1EntList = entList = staticEntList;
                }
                else //有关键字
                {
                    //and
                    if (SROperation2.Instance.KeywordLogical == "and")
                    {
                        int count = SROperation2.Instance.KeywordFilter.Split(',').Length;
                        entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL("select * from SRRC_Resource where id in (SELECT Resource_id  FROM SRRC_Resourcebiaojirel  WHERE Biaoji_id IN (" + SROperation2.Instance.KeywordFilter + ")  GROUP BY Resource_id  HAVING COUNT(*)=" + count + ")");
                    }
                    //or
                    if (SROperation2.Instance.KeywordLogical == "or")
                    {
                        entList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL("select * from SRRC_Resource where id in (SELECT Resource_id  FROM SRRC_Resourcebiaojirel  WHERE Biaoji_id IN (" + SROperation2.Instance.KeywordFilter + ")  GROUP BY Resource_id)");
                    }
                    if(entList == null)
                    {
                        SROperation2.Instance.Center1EntList = entList;
                    }
                    else
                    {
                        var temp = staticEntList.Intersect(entList, new SRRC_ResourceEntity_EntityComparer());
                        if (temp == null)
                        {
                            SROperation2.Instance.Center1EntList = entList = null;
                        }
                        else
                        {
                            SROperation2.Instance.Center1EntList = entList = temp.ToList();
                        }
                    }                                      
                }
            }
            #endregion

            SROperation2.Instance.entListCount = entList == null ? 0 : entList.Count;
            ImageLoadingTip = new bool[SROperation2.Instance.entListCount];

            //this.SetData();
#if debug
            SRLogHelper.Instance.AddLog("日志", DateTime.Now.ToString("mm:ss.ffff"));
#endif
        }
        public void BindData()
        {
            List<SRRC_ResourceEntity> tempList = null;
            SROperation2.Instance.SetBiaoJiStatusSql = string.Empty;
            #region 左侧菜单操作、中间区域（center1,center2）
            if (SROperation2.Instance.FocusPanel != "Right")
            {
                Int32 id = SROperation.Instance.LeftSelectedId;                
                switch (SROperation.Instance.LeftDtype)
                {
                    case "Resources":
                        {
                            if (!String.IsNullOrEmpty(SROperation.Instance.Keyword))
                            {
                                string sql;
                                if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                {
                                    sql = string.Format(@"
                                                WITH ta
                                                 AS (
                                                 SELECT *
                                                 FROM SRRC_Resource
                                                 WHERE id = {0}
                                                 UNION ALL
                                                 SELECT SRRC_Resource.*
                                                 FROM ta
                                                      INNER JOIN SRRC_Resource ON ta.Id = SRRC_Resource.Pid)
                                                 SELECT *
                                                 FROM ta
                                                      INNER JOIN SRRC_Resourcebiaojirel AS tb ON ta.Id = tb.Resource_id
                                                 WHERE(tb.Biaoji_id IN({1})
                                                 OR ta.Dtype = 0)
                                                      AND (Name+'.'+Extend1) LIKE '%{2}%';",
                                                      id, Param.filterkeyword, SROperation.Instance.Keyword);
                                    SROperation2.Instance.SetBiaoJiStatusSql = string.Format(@"
                                                WITH ta
                                                     AS (
                                                     SELECT *
                                                     FROM SRRC_Resource
                                                     WHERE id = {0}
                                                     UNION ALL
                                                     SELECT SRRC_Resource.*
                                                     FROM ta
                                                          INNER JOIN SRRC_Resource ON ta.Id = SRRC_Resource.Pid)
                                                     SELECT ta.Id,
                                                            tb.count
                                                     FROM SRRC_Biaoji AS ta
                                                          INNER JOIN
                                                     (
                                                         SELECT Biaoji_id,
                                                                COUNT(*) AS count
                                                         FROM [SRRC_Resourcebiaojirel]
                                                         WHERE Resource_id IN
                                                         (
                                                             SELECT ta.Id
                                                             FROM ta
                                                                  INNER JOIN SRRC_Resourcebiaojirel AS tb ON ta.Id = tb.Resource_id
                                                             WHERE(tb.Biaoji_id IN({1})
                                                             OR ta.Dtype = 0)
                                                                  AND (Name+'.'+Extend1) LIKE '%{2}%'
                                                         )
                                                         GROUP BY Biaoji_id
                                                     ) AS tb ON ta.id = tb.Biaoji_id;",
                                                    id, Param.filterkeyword, SROperation.Instance.Keyword);
                                }
                                else
                                {
                                    sql = string.Format(@"
                                                    WITH ta
                                                         AS (
                                                         SELECT *
                                                         FROM SRRC_Resource
                                                         WHERE id = {0}
                                                         UNION ALL
                                                         SELECT SRRC_Resource.*
                                                         FROM ta
                                                              INNER JOIN SRRC_Resource ON ta.Id = SRRC_Resource.Pid)
                                                         SELECT *
                                                         FROM ta
                                                         WHERE(Name+'.'+Extend1) LIKE '%{1}%';",
                                                         id, SROperation.Instance.Keyword);
                                    SROperation2.Instance.SetBiaoJiStatusSql = string.Format(@"
                                                                                WITH ta
                                                                                     AS (
                                                                                     SELECT *
                                                                                     FROM SRRC_Resource
                                                                                     WHERE id = {0}
                                                                                     UNION ALL
                                                                                     SELECT SRRC_Resource.*
                                                                                     FROM ta
                                                                                          INNER JOIN SRRC_Resource ON ta.Id = SRRC_Resource.Pid)
                                                                                     SELECT ta.Id,
                                                                                            tb.count
                                                                                     FROM SRRC_Biaoji AS ta
                                                                                          INNER JOIN
                                                                                     (
                                                                                         SELECT Biaoji_id,
                                                                                                COUNT(*) AS count
                                                                                         FROM [SRRC_Resourcebiaojirel]
                                                                                         WHERE Resource_id IN
                                                                                         (
                                                                                             SELECT ta.Id
                                                                                             FROM ta
                                                                                             WHERE(Name+'.'+Extend1) LIKE '%{1}%'
                                                                                         )
                                                                                         GROUP BY Biaoji_id
                                                                                     ) AS tb ON ta.id = tb.Biaoji_id;",
                                                                                    id, SROperation.Instance.Keyword);
                                }
                                tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL(sql, null);
                            }
                            else
                            {
                                if (SROperation.Instance.LeftShowType == "Cross")
                                {
                                    if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                    {
                                        strWhere = " Pid in (select Id from SRRC_Resource where Pid=[$Pid$]) and Dtype<>0 and Id in ( select Resource_id from SRRC_Resourcebiaojirel where  Biaoji_id in (" + Param.filterkeyword + "))";
                                    }
                                    else
                                    {
                                        strWhere = " Pid in (select Id from SRRC_Resource where Pid=[$Pid$]) and Dtype<>0";
                                    }
                                    tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, strWhere, new DataParameter("Pid", id));
                                    if (tempList == null || tempList.Count == 0) //没有文件
                                    {
                                        if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                        {
                                            strWhere = " Pid=[$Pid$] and (Id in (select Resource_id from SRRC_Resourcebiaojirel where  Biaoji_id in (" + Param.filterkeyword + ")) or Dtype=0)";
                                        }
                                        else
                                        {
                                            strWhere = " Pid=[$Pid$]";
                                        }
                                        tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, strWhere, new DataParameter("Pid", id));
                                    }
                                }
                                else
                                {
                                    if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                                    {
                                        strWhere = " Pid=[$Pid$] and Id in ( select Resource_id from SRRC_Resourcebiaojirel where  Biaoji_id in (" + Param.filterkeyword + "))";
                                    }
                                    else
                                    {
                                        strWhere = " Pid=[$Pid$]";
                                    }
                                    tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, strWhere, new DataParameter("Pid", id));
                                }
                                var idSql = "SELECT Id FROM SRRC_Resource WHERE " + strWhere.Replace("[$Pid$]", id.ToString());
                                SROperation2.Instance.SetBiaoJiStatusSql = string.Format(@"
                                                                                    SELECT ta.Id,
                                                                                           tb.count
                                                                                    FROM SRRC_Biaoji AS ta
                                                                                         INNER JOIN
                                                                                    (
                                                                                        SELECT Biaoji_id,
                                                                                               COUNT(*) AS count
                                                                                        FROM [SRRC_Resourcebiaojirel]
                                                                                        WHERE Resource_id IN({0})
                                                                                        GROUP BY Biaoji_id
                                                                                    ) AS tb ON ta.id = tb.Biaoji_id;", idSql);
                            }
                        }
                        break;
                    case "Study":
                        {
                            if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=0 and Biaoji_id=[$Pid$] ) and Id in (select Resource_id FROM SRRC_Resourcebiaojirel where User_id=0  and  Biaoji_id in (" + Param.filterkeyword + ")) ";
                            }
                            else
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=0 and Biaoji_id=[$Pid$] )";
                            }
                            if (String.IsNullOrEmpty(SROperation.Instance.Keyword) == false)
                            {
                                strWhere += " and (Name + '.' + Extend1) like  '%" + SROperation.Instance.Keyword + "%' ";
                            }

                            #region 标记关键字过滤
                            if (SROperation2.Instance.BiaoJiKeywordFilterList.Count > 0)
                            {
                                var group = SROperation2.Instance.BiaoJiKeywordFilterList.GroupBy(l => l.Pid);
                                List<string> intersectSqls = new List<string>();
                                foreach (var item in group)
                                {
                                    intersectSqls.Add(string.Format(@" select ResourceBiaoJiRelId from [dbo].[SRRC_ResourceBiaoJiRel_BiaoJiKeyword]  where BiaoJiKeywordId in ({0}) ",string.Join(",", item.Select(l => l.Id))));
                                }
                                strWhere += String.Format(" and Id in( select Resource_id from dbo.SRRC_Resourcebiaojirel where id in ({0}))", string.Join("intersect", intersectSqls));
                            }
                            #endregion
                            tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, strWhere, new DataParameter("Pid", id));
                            var idSql = "SELECT Id FROM SRRC_Resource WHERE " + strWhere.Replace("[$Pid$]", id.ToString());
                            SROperation2.Instance.SetBiaoJiStatusSql = string.Format(@"
                                                                                    SELECT ta.Id,
                                                                                           tb.count
                                                                                    FROM SRRC_Biaoji AS ta
                                                                                         INNER JOIN
                                                                                    (
                                                                                        SELECT Biaoji_id,
                                                                                               COUNT(*) AS count
                                                                                        FROM [SRRC_Resourcebiaojirel]
                                                                                        WHERE Resource_id IN({0})
                                                                                        GROUP BY Biaoji_id
                                                                                    ) AS tb ON ta.id = tb.Biaoji_id;", idSql);
                        }
                        break;
                    case "Favorites":
                        {
                            if (SROperation.Instance.OnlyShow && Param.filterkeyword != "")
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=" + Param.UserId + " and Biaoji_id=[$Pid$]) and Id in (select Resource_id FROM SRRC_Resourcebiaojirel where User_id=0  and Biaoji_id in (" + Param.filterkeyword + ")) ";
                            }
                            else
                            {
                                strWhere = " Id in ( SELECT Resource_id FROM SRRC_Resourcebiaojirel where User_id=" + Param.UserId + " and Biaoji_id=[$Pid$])";
                            }
                            if (String.IsNullOrEmpty(SROperation.Instance.Keyword) == false)
                            {
                                strWhere += " and (Name + '.' + Extend1) like  '%" + SROperation.Instance.Keyword + "%' ";
                            }
                            tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, strWhere, new DataParameter("Pid", id));
                            var idSql = "SELECT Id FROM SRRC_Resource WHERE " + strWhere.Replace("[$Pid$]", id.ToString());
                            SROperation2.Instance.SetBiaoJiStatusSql = string.Format(@"
                                                                                    SELECT ta.Id,
                                                                                           tb.count
                                                                                    FROM SRRC_Biaoji AS ta
                                                                                         INNER JOIN
                                                                                    (
                                                                                        SELECT Biaoji_id,
                                                                                               COUNT(*) AS count
                                                                                        FROM [SRRC_Resourcebiaojirel]
                                                                                        WHERE Resource_id IN({0})
                                                                                        GROUP BY Biaoji_id
                                                                                    ) AS tb ON ta.id = tb.Biaoji_id;", idSql);
                        }
                        break;
                    default:
                        break;
                }
                staticEntList = tempList;
            }
            #endregion

            #region Keyword面板操作
            if (SROperation2.Instance.FocusPanel == "Right")
            {
                if (SROperation2.Instance.KeywordFilter == null || SROperation2.Instance.KeywordFilter.Length == 0)//无关键字
                {
                    tempList = staticEntList;
                }
                else //有关键字
                {
                    //and
                    if (SROperation2.Instance.KeywordLogical == "and")
                    {
                        int count = SROperation2.Instance.KeywordFilter.Split(',').Length;
                        tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL("select * from SRRC_Resource where id in (SELECT Resource_id  FROM SRRC_Resourcebiaojirel  WHERE Biaoji_id IN (" + SROperation2.Instance.KeywordFilter + ")  GROUP BY Resource_id  HAVING COUNT(*)=" + count + ")");
                    }
                    //or
                    if (SROperation2.Instance.KeywordLogical == "or")
                    {
                        tempList = DataBase.Instance.tSRRC_Resource.Get_EntityCollectionBySQL("select * from SRRC_Resource where id in (SELECT Resource_id  FROM SRRC_Resourcebiaojirel  WHERE Biaoji_id IN (" + SROperation2.Instance.KeywordFilter + ")  GROUP BY Resource_id)");
                    }
                    if (tempList != null)
                    {                    
                        var temp = staticEntList.Intersect(tempList, new SRRC_ResourceEntity_EntityComparer());
                        if (temp == null)
                        {
                           tempList = null;
                        }
                        else
                        {
                            tempList = temp.ToList();
                        }
                    }
                }
            }
            #endregion


            #region 排序
            if (tempList != null)
            {
                switch (SROperation.Instance.Orderby)
                {
                    case 1:
                        {
                            var viewPriority = tempList.Where(t => !String.IsNullOrEmpty(t.Extend3));
                            var others = tempList.Where(t => String.IsNullOrEmpty(t.Extend3));
                            var temp = new List<SRRC_ResourceEntity>();
                            if (SROperation.Instance.OrderType == 0)//ASC
                            {
                                temp.AddRange(viewPriority.OrderBy(t => t.Bjtime));
                                temp.AddRange(others.OrderBy(t => t.Bjtime));
                            }
                            else if (SROperation.Instance.OrderType == 1)//DESC
                            {
                                temp.AddRange(viewPriority.OrderByDescending(t => t.Bjtime));
                                temp.AddRange(others.OrderByDescending(t => t.Bjtime));
                            }
                            tempList = temp;
                        }
                        break;
                    case 2:
                        {
                            var viewPriority = tempList.Where(t => !String.IsNullOrEmpty(t.Extend3));
                            var others = tempList.Where(t => String.IsNullOrEmpty(t.Extend3));
                            var temp = new List<SRRC_ResourceEntity>();
                            if (SROperation.Instance.OrderType == 0)//ASC
                            {
                                temp.AddRange(viewPriority.OrderBy(t => t.Usecount));
                                temp.AddRange(others.OrderBy(t => t.Usecount));
                            }
                            else if (SROperation.Instance.OrderType == 1)//DESC
                            {
                                temp.AddRange(viewPriority.OrderByDescending(t => t.Usecount));
                                temp.AddRange(others.OrderByDescending(t => t.Usecount));
                            }
                            tempList = temp;
                        }
                        break;
                    case 3:
                        {
                            var viewPriority = tempList.Where(t => !String.IsNullOrEmpty(t.Extend3));
                            var others = tempList.Where(t => String.IsNullOrEmpty(t.Extend3));
                            var temp = new List<SRRC_ResourceEntity>();
                            if (SROperation.Instance.OrderType == 0)//ASC
                            {
                                temp.AddRange(viewPriority.OrderBy(t => t.Addtime));
                                temp.AddRange(others.OrderBy(t => t.Addtime));
                            }
                            else if (SROperation.Instance.OrderType == 1)//DESC
                            {
                                temp.AddRange(viewPriority.OrderByDescending(t => t.Addtime));
                                temp.AddRange(others.OrderByDescending(t => t.Addtime));
                            }
                            tempList = temp;
                        }
                        break;
                    case 4:
                        {
                            var viewPriority = tempList.Where(t => !String.IsNullOrEmpty(t.Extend3));
                            var others = tempList.Where(t => String.IsNullOrEmpty(t.Extend3));
                            var temp = new List<SRRC_ResourceEntity>();
                            if (SROperation.Instance.OrderType == 0)//ASC
                            {
                                temp.AddRange(viewPriority.OrderBy(t => t.Filesize));
                                temp.AddRange(others.OrderBy(t => t.Filesize));
                            }
                            else if (SROperation.Instance.OrderType == 1)//DESC
                            {
                                temp.AddRange(viewPriority.OrderByDescending(t => t.Filesize));
                                temp.AddRange(others.OrderByDescending(t => t.Filesize));
                            }
                            tempList = temp;
                        }
                        break;
                    case 5:
                        {
                            var viewPriority = tempList.Where(t => !String.IsNullOrEmpty(t.Extend3));
                            var others = tempList.Where(t => String.IsNullOrEmpty(t.Extend3));
                            var temp = new List<SRRC_ResourceEntity>();
                            if (SROperation.Instance.OrderType == 0)//ASC
                            {
                                temp.AddRange(viewPriority.OrderBy(t => t.Name));
                                temp.AddRange(others.OrderBy(t => t.Name));
                            }
                            else if (SROperation.Instance.OrderType == 1)//DESC
                            {
                                temp.AddRange(viewPriority.OrderByDescending(t => t.Name));
                                temp.AddRange(others.OrderByDescending(t => t.Name));
                            }
                            tempList = temp;
                        }
                        break;
                    case 6:
                        {
                            tempList = tempList.OrderBy(t => t.Id).ToList();
                        }
                        break;
                    default:
                        break;
                }
            }
            
            #endregion
            SROperation2.Instance.Center1EntList = entList = tempList;
            SROperation2.Instance.entListCount = entList == null ? 0 : entList.Count;
            ImageLoadingTip = new bool[SROperation2.Instance.entListCount];
        }
        /// <summary>
        /// 更改视图时，刷新数据
        /// </summary>
        public void RefreshData()
        {
            isMouseWheelDoing = true;
            SetData();
            isMouseWheelDoing = false;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //每次selectedItems 选项 发生变化时 都会 触发 ，特别是多选时，会触发多次
            if(!selectedIndexChangedTimer.Enabled)
            {
                selectedIndexChangedTimer.Start();
            }
            else
            {
                selectedIndexChangedTimer.Stop();
                selectedIndexChangedTimer.Start();
            }
        }
        private void listView1_SelectedIndexChangedHelper(object sender, EventArgs e)
        {
            selectedIndexChangedTimer.Stop();
            if (this.listView1.Focused)
            {
                OnPageClicked(sender, new MyEventArgs { Action = 7 });
            }
            SROperation2.Instance.PicSelected = new List<SRRC_ResourceEntity>();
            if (OnPageClicked != null)
            {
                if (this.listView1.SelectedItems != null && this.listView1.SelectedItems.Count > 0)
                {
                    foreach (ListViewItem item in this.listView1.SelectedItems)
                    {
                        SROperation2.Instance.PicSelected.Add(item.Tag as SRRC_ResourceEntity);
                    }
                }
                if (SROperation2.Instance.PicSelected != null && SROperation2.Instance.PicSelected.Count > 0)
                    OnPageClicked(sender, new MyEventArgs() { Action = 3 });//把按钮自身作为参数传递
            }
        }
        private void listView1_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right || SROperation.Instance.IsShowLZ == false)
            {
                List<string> list = new List<string>();
                foreach (ListViewItem lvi in this.listView1.SelectedItems)
                {
                    SRRC_ResourceEntity ent = lvi.Tag as SRRC_ResourceEntity;
                    string path = "";
                    if (ent.Iscomposite) //复合文件
                    {
                        var item = DataBase.Instance.tSRRC_Resource.Get_Entity(ent.Pid);
                        if (item == null) continue;
                        item.Usecount++;
                        DataBase.Instance.tSRRC_Resource.Update(item);

                        List<SRRC_ResourceEntity> maxEntList = DataBase.Instance.tSRRC_Resource.Get_EntityCollection(null, "pid in (select Id from SRRC_Resource where pid=[$pid$] and Dtype=0) and lower(Extend1)=[$extend1$]", new DataParameter("pid", item.Id), new DataParameter("extend1", "max"));
                        if (maxEntList == null || maxEntList.Count == 0)
                        {
                            MessageBox.Show(string.Format("{0}复合文件无MAX文件，请修改！", item.Name.Substring(0, item.Name.LastIndexOf('.'))));
                            return;
                        }
                        else if (maxEntList.Count > 1)
                        {
                            MessageBox.Show(string.Format("{0}复合文件有{1}个MAX文件，请修改！", item.Name.Substring(0, item.Name.LastIndexOf('.')), maxEntList.Count));
                            return;
                        }
                        else
                        {                            
                            var maxEnt = maxEntList.First();
                            path = maxEnt.Serverip + maxEnt.Path;
                        }
                    }
                    else
                    {
                        path = ent.Serverip + ent.Path;
                    }
                    ent.Usecount++;
                    DataBase.Instance.tSRRC_Resource.Update(ent);
                    if (path != "" && !list.Contains(path))
                    {
                        list.Add(path);
                    }
                }

                if (list.Count > 0)
                {
                    (this.TopLevelControl as FrmMain).WindowState = FormWindowState.Minimized;
                    //Thread t = new Thread(new ThreadStart(ProcessHelper.AddAndDelNetUse));
                    //t.Start();
                    IDataObject poj = new DataObject(DataFormats.FileDrop, list.ToArray());
                    poj.SetData(poj);
                    this.listView1.DoDragDrop(poj, DragDropEffects.Copy);
                   
                }

            }
            else
            {
                this.listView1.DoDragDrop(this.listView1.SelectedItems, DragDropEffects.Move);  
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (OnPageClicked != null)
            {
                ListView lv = sender as ListView;
                if (lv.FocusedItem == null) return;
                SRRC_ResourceEntity ent = lv.FocusedItem.Tag as SRRC_ResourceEntity;
                if (ent.Dtype == 0) //文件夹
                {
                    SROperation.Instance.LeftSelectedId = (lv.FocusedItem.Tag as SRRC_ResourceEntity).Id;
                    OnPageClicked(sender, new MyEventArgs() { Action = 4, Parameter = ent });
                    // this.BindData();

                }
                else if (ent.Dtype == 1) //图片
                {                    
                    OnPageClicked(lv.FocusedItem, new MyEventArgs() { Action = 1 });//把按钮自身作为参数传递
                }
                else
                {
                    //其他类型的文件
                    MessageBox.Show("所选项不是图片类型，不能进行图片预览！");
                }
            }
        }

        private void contextMenuStrip_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem obj = sender as ToolStripMenuItem;
            if (obj != null && OnPageClicked != null)
            {
                if (obj.Text == "视图优先排列" || obj.Text == "使用次数")
                {
                    obj.Checked = !obj.Checked;
                }
                OnPageClicked(sender, new MyEventArgs() { Action = 6, Parameter = sender });//把按钮自身作为参数传递
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            ListView lv = sender as ListView;
            SRRC_ResourceEntity ent = lv.FocusedItem.Tag as SRRC_ResourceEntity;
            if (lv.FocusedItem.ImageKey == "folder")
            {//文件夹

            }
            else
            {
                //图片文件
            }
        }


        /// <summary>
        /// 将选择的项目复制到剪贴板
        /// </summary>
        public void CopySelectedToClipboard()
        {
            if (SROperation2.Instance.PicSelected == null) return;
            System.Collections.Specialized.StringCollection sc = new System.Collections.Specialized.StringCollection();
            foreach (SRRC_ResourceEntity ent in SROperation2.Instance.PicSelected)
            {
                string path;
                if(ent.Iscomposite) //复合文件
                {
                    var item = DataBase.Instance.tSRRC_Resource.Get_Entity(ent.Pid);
                    if (item == null) continue;
                    item.Usecount++;
                    DataBase.Instance.tSRRC_Resource.Update(item);
                    path = item.Serverip + item.Path;
                }
                else
                {
                    path = ent.Serverip + ent.Path;
                }
                ent.Usecount++;
                DataBase.Instance.tSRRC_Resource.Update(ent);
                if(!sc.Contains(path))
                {
                    sc.Add(path);
                }                
            }

            if (sc.Count > 0)
            {
                //Thread t = new Thread(new ThreadStart(ProcessHelper.AddAndDelNetUse));
                //t.Start();
                Clipboard.SetFileDropList(sc);

            }             

        }

        private void 复制toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Param.GroupId > 2)
            {
                MessageBox.Show("您不具备该权限！请联系管理员。");
                return;
            }
            CopySelectedToClipboard();
        }

        private void 粘贴toolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Param.GroupId > 2)
            {
                MessageBox.Show("您不具备该权限，请联系管理员！");
                return;
            }
            CopyClipboardToCenter1();
        }
        public void CopyClipboardToCenter1()
        {
            if (Clipboard.ContainsFileDropList())
            {
                List<string> CopyList = new List<string>();
                foreach (var item in Clipboard.GetFileDropList())
                {
                    CopyList.Add(item);
                }
                CopyFiles = CopyList.ToArray();
                BgWorkerInit();
            }
            else
            {
                MessageBox.Show("无数据");
            }
        }
        private void listView1_DragLeave(object sender, EventArgs e)
        {
            //鼠标是否在控件区域内
            Point pt = this.listView1.PointToClient(MousePosition);
            bool isMouseIn = this.listView1.Bounds.Contains(pt);

            if(this.isTarget && isMouseIn)//是拖放的目标
            {                
                if (CopyFiles != null && CopyFiles.Length > 0)
                {
                    if (CopyFiles.Any(o => o.StartsWith("\\\\"))) return;
                    if (Param.GroupId > 2)
                    {
                        MessageBox.Show("您不具备该权限！请联系管理员。");
                        return;
                    }
                    BgWorkerInit();
                }
            }else if(!this.isTarget && !isMouseIn)
            {
                List<string> list = new List<string>();
                foreach (ListViewItem lvi in this.listView1.SelectedItems)
                {
                    SRRC_ResourceEntity ent = lvi.Tag as SRRC_ResourceEntity;
                    string path = "";
                    if (ent.Iscomposite) //复合文件
                    {
                        var item = DataBase.Instance.tSRRC_Resource.Get_Entity(ent.Pid);
                        if (item == null) continue;
                        item.Usecount++;
                        DataBase.Instance.tSRRC_Resource.Update(item);                        
                        path = item.Serverip + item.Path;
                    }
                    else
                    {
                        path = ent.Serverip + ent.Path;
                    }
                    ent.Usecount++;
                    DataBase.Instance.tSRRC_Resource.Update(ent);
                    if (path != "" && !list.Contains(path))
                    {
                        list.Add(path);
                    }
                }

                if (list.Count > 0)
                {
                    //Thread t = new Thread(new ThreadStart(ProcessHelper.AddAndDelNetUse));
                    //t.Start();
                    IDataObject poj = new DataObject(DataFormats.FileDrop, list.ToArray());
                    poj.SetData(poj);
                    this.listView1.DoDragDrop(poj, DragDropEffects.Copy);
                }
            }
        }
        private void listView1_DragDrop(object sender, DragEventArgs e)
        {
            
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            else
            {
                CopyFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (CopyFiles.Any(o => o.StartsWith("\\\\"))) return;
                if (Param.GroupId > 2)
                {
                    MessageBox.Show("您不具备该权限，请联系管理员！");
                    return;
                }
                BgWorkerInit();
            }
        }

#region 复制文件后台操作
        private void BgWorkerInit()
        {
            
            ThumbWidth = Convert.ToInt32(SRConfig.Instance.GetAppString("ThumbWidth"));
            ThumbHeight = Convert.ToInt32(SRConfig.Instance.GetAppString("ThumbHeight"));

            BgWorker = new BackgroundWorker();
            BgWorker.WorkerReportsProgress = true;
            BgWorker.WorkerSupportsCancellation = true;
            BgWorker.DoWork += new DoWorkEventHandler(worker_DoWork);
            BgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;
            BgWorker.WorkerSupportsCancellation = true;
            //显示进度窗体 
            FrmFrame frm = new FrmFrame()
            {
                Text = "正在复制...",
                Width = 400,
                Height = 120,
            };
            frm.FormClosed += Frm_FormClosed;
            MyProgressBar bar = new MyProgressBar(this.BgWorker);
            frm.SetUserControl(bar);
            frm.StartPosition = FormStartPosition.CenterScreen;

            BgWorker.RunWorkerAsync();            
            frm.ShowDialog(this);
            
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!string.IsNullOrEmpty(uploadFailFile.ToString()))
            {
                MessageBox.Show(uploadFailFile.ToString(), "上传失败的文件");
            }
            OnPageClicked(sender, new MyEventArgs() { Action = 5 });
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            SRRC_ResourceEntity baseEnt = DataBase.Instance.tSRRC_Resource.Get_Entity(SROperation.Instance.LeftSelectedId);
            if (baseEnt == null) return;
            countSum = 0;
            uploadFailFile = new StringBuilder();
            foreach (string file in CopyFiles)
            {
                if (File.Exists(file)) //判断是否是文件
                {
                    countSum++;
                }
                else
                {
                    //文件夹
                    countSum += Directory.GetFiles(file, "*.*", SearchOption.AllDirectories).Length;
                }
            }
            
            int count = 0;
            Copy(baseEnt, CopyFiles, ref count);
        }

       

        private void Copy(SRRC_ResourceEntity parentEnt, string[] files, ref int count)
        {
       
            foreach (string file in files)
            {
                if (File.Exists(file)) //判断是否是文件
                {
                    try
                    {
                        CopyFile(parentEnt, file, ref count);
                    }
                    catch
                    {
                        uploadFailFile.AppendFormat(file + @"\r\n");
                        SRLogHelper.Instance.AddLog("异常", "上传文件", "文件", file);
                    }
                }
                else
                {
                    try
                    {
                        //文件夹
                        DirectoryInfo di = new DirectoryInfo(file);
                        string path = parentEnt.Path + "\\" + di.Name;
                        SRRC_ResourceEntity ent = DataBase.Instance.tSRRC_Resource.Get_Entity("ServerIP=[$ip$] and Path=[$path$]"
                      , new DataParameter("ip", parentEnt.Serverip)
                      , new DataParameter("path", path));
                        if (ent == null)
                        {
                            Directory.CreateDirectory(parentEnt.Serverip + path);
                            Directory.CreateDirectory(parentEnt.Serverip.Replace(Param.IP, Param.IP + "\\Cache") + path);
                            string code = Guid.NewGuid().ToString();
                            ent = new SRRC_ResourceEntity()
                            {
                                Addtime = DateTime.Now,
                                Pid = parentEnt.Id,
                                Name = di.Name,
                                Dtype = 0,
                                Serverip = parentEnt.Serverip,
                                Path = path,
                                Code = code
                            };
                            DataBase.Instance.tSRRC_Resource.Add(ent);
                            ent = DataBase.Instance.tSRRC_Resource.Get_Entity(code);
                        }
                        Copy(ent, Directory.GetFiles(file).Concat(Directory.GetDirectories(file)).ToArray(), ref count);

                    }
                    catch (Exception ex)
                    {
                        SRLogHelper.Instance.AddLog("异常", "上传文件", "文件夹", ex.Message);
                    }
                }
            }
        }
        /// <summary>
        /// 复制单个文件
        /// </summary>
        /// <param name="parentEnt">目录</param>
        /// <param name="file">要复制的文件名</param>
        /// <param name="count">当前已复制的个数</param>
        private void CopyFile(SRRC_ResourceEntity parentEnt,string file,ref int count)
        {
            
            SRRC_ResourceEntity ent;
            FileInfo fi = new FileInfo(file);
            string name = fi.Name;
            if (name == "Thumbs.db") return;
            string path = parentEnt.Path + "\\" + name;
            int type = 2;//文件类型，2，非图片            
            int width = 0;
            int height = 0;
            //复制
            File.Copy(file, parentEnt.Serverip + path, true);
            
            //图片生成缩略图，删除本地缓存
            if(SRConfig.Instance.GetAppString("ImageExt").Contains(fi.Extension.Trim('.').ToLower()))
            {
                type = 1;
                using (new IdentityScope(Param.ServerIP.Description,Param.ServerIP.Remark,Param.ServerIP.Title))
                {
                    SirdRoom.ManageSystem.Library.Common.Image.ImageOperation.CreateThumb(
                          parentEnt.Serverip + path
                          , parentEnt.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + path
                          , ThumbWidth, ThumbHeight);
                }
                    
                Image im = Bitmap.FromFile(file);
                width = im.Width;
                height = im.Height;
            }
            
            ent = DataBase.Instance.tSRRC_Resource.Get_Entity("ServerIP=[$ip$] and Path=[$path$]"
                , new DataParameter("ip", parentEnt.Serverip)
                , new DataParameter("path", path));
            if(ent == null)
            {
                //新增
                ent = new SRRC_ResourceEntity()
                {
                    Addtime = DateTime.Now,
                    Pid = parentEnt.Id,
                    Name = fi.Name,
                    Dtype=type,
                    Serverip = parentEnt.Serverip,
                    Path=path,
                    Extend1 = fi.Extension.Trim('.'),
                    Extend2 = type == 1? width + "*" + height:"",
                    Filesize = fi.Length
                };
                DataBase.Instance.tSRRC_Resource.Add(ent);
            }
            else
            {
                //替换
                ent.Addtime = DateTime.Now;
                ent.Extend2 = type == 1 ? width + "*" + height : "";
                ent.Filesize = fi.Length;
                DataBase.Instance.tSRRC_Resource.Update(ent);
            }
            BgWorker.ReportProgress(++count * 100 / countSum);
        }
        private void Frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.BgWorker.CancelAsync();
            this.BgWorker.Dispose();
        }
#endregion

        private void listView1_DragEnter(object sender, DragEventArgs e)
        {
            this.isTarget = true;
            if (!e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                return;
            }
            else
            {
                CopyFiles = (string[])e.Data.GetData(DataFormats.FileDrop);    
            }
        }

        private void listView1_MouseDown(object sender, MouseEventArgs e)
        {
            this._mouseDown = e.Button;
            if(listView1.HitTest(e.Location).Item == null)
            {
                OnPageClicked(sender, new MyEventArgs() { Action = 2 });
            }            
        }

        #region 图片绘制
        public delegate void SetImageListDelegate(string key, Image image);
        void DownLoadImage(object obj)
        {
            string[] pass = obj as string[];
            string key = pass[0];
            string path = pass[1];
            using (new IdentityScope(Param.ServerIP.Description,
                                Param.ServerIP.Remark,
                                Param.ServerIP.Title))
            {                
                Image image = Image.FromFile(path);
                //MemoryStream ms = SirdRoom.ManageSystem.Library.Common.Image.ImageOperation.CreateThumb(path, 256, 256);
                MemoryStream ms = new MemoryStream();
                image.Save(ms,image.RawFormat);
                if (ms == null) return;
                image = Image.FromStream(ms);
                //image.Save(@"C:\Users\tanche\Desktop\New folder (3)\" + key + ".jpg");
                GC.Collect();
                listView1.Invoke(new SetImageListDelegate(SetImageList), key, image);
            }
        }
       public void SetImageList(string key,Image image)
        {
            //if(listView1.Items.ContainsKey(key) && !SROperation2.Instance.Center1ImageDict.ContainsKey(key))
            //{               
                //SROperation2.Instance.Center1ImageDict.Add(key, image);
                ListViewItem lvi = listView1.Items.Find(key, true)[0];
                listView1.RedrawItems(lvi.Index, lvi.Index, true);               
            //}      
        }
        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            //
            if(ImageLoadingTip.Length != (sender as ListView).Items.Count)
            {
                return;
            }
            string imageKey = e.Item.ImageKey;
            #region 非大图标默认显示
            if (listView1.View != View.LargeIcon)
            {
                int id;
                if (int.TryParse(e.Item.ImageKey, out id))
                {
                    listView1.Items.Find(e.Item.Name, true)[0].ImageKey = "image";
                }
                e.DrawDefault = true;
                return;
            }
            #endregion

            SRRC_ResourceEntity ent = e.Item.Tag as SRRC_ResourceEntity;
            //SRLogHelper.Instance.AddLog("日志", "DrawItem," + e.Item.Name + "," + DateTime.Now.ToString("ss.ffff"));

            //大图标，图片，未加载，图像字典中不包含。使用未加载是因为图像已提交加载，但未加载完成时，预防再次提交而使用。
            if (listView1.View == View.LargeIcon && e.Item.ImageKey == "image" && !ImageLoadingTip[e.ItemIndex] 
                && !SROperation2.Instance.Center1ImageDict.ContainsKey(ent.Id.ToString())) //图片类型，未加载图片
            {
                ImageLoadingTip[e.ItemIndex] = true;
                // Thread t = new Thread(new ParameterizedThreadStart(DownLoadImage));
                // t.Start(new string[] { ent.Id.ToString(), ent.Serverip.Replace(Param.IP,Param.ServerCacheIP.Trim('\\')) + ent.Path });
                SROperation2.Instance.Center1ImageBlockingCollection.Add(new KeyValuePair<string, string>(ent.Id.ToString(), ent.Serverip.Replace(Param.IP, Param.ServerCacheIP.Trim('\\')) + ent.Path));
                e.DrawDefault = true;
            }
            else 
            {
                try
                {
                    Image image1;
                    if(SROperation2.Instance.Center1ImageDict.ContainsKey(ent.Id.ToString()))
                    {
                        image1 = SROperation2.Instance.Center1ImageDict[ent.Id.ToString()];
                    }
                    else
                    {
                        image1 = SROperation2.Instance.Center1ImageDict[e.Item.ImageKey];
                    }
                    Size size = e.Item.ImageList.ImageSize;
                    e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                    e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    if ((e.State & ListViewItemStates.Selected) != 0 && e.Item.Selected)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.Gray), e.Bounds);
                        
                            Rectangle re = new Rectangle(e.Bounds.X + (e.Bounds.Width - size.Width) / 2, e.Bounds.Y + 2, size.Width, size.Height);
                            e.Graphics.DrawImage(image1, re);

                            //绘制次数
                            re = new Rectangle(re.X, re.Y + (re.Height - listView1.Font.Height + 2), re.Width, listView1.Font.Height + 2);
                            //e.Graphics.FillRectangle(new SolidBrush(Color.Silver), re);
                            e.Graphics.DrawString((e.Item.Tag as SRRC_ResourceEntity).Usecount.ToString(), listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                        if(ent.Iscomposite)
                        {
                            e.Graphics.DrawString("*", listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                        }
                    }
                    else
                    {
                            Rectangle re = new Rectangle(e.Bounds.X + (e.Bounds.Width - size.Width) / 2, e.Bounds.Y + 2, size.Width, size.Height);
                            e.Graphics.DrawImage(image1, re);
                            //绘制次数
                            re = new Rectangle(re.X, re.Y + (re.Height - listView1.Font.Height + 2), re.Width, listView1.Font.Height + 2);
                            //e.Graphics.FillRectangle(new SolidBrush(Color.Silver), re);
                            e.Graphics.DrawString((e.Item.Tag as SRRC_ResourceEntity).Usecount.ToString(), listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                        if (ent.Iscomposite)
                        {
                            e.Graphics.DrawString("*", listView1.Font, new SolidBrush(Color.Red), re, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                        }
                    }
                    e.DrawText(TextFormatFlags.Bottom | TextFormatFlags.HorizontalCenter);                   
                }
                catch (Exception ex)
                {
                    SRLogHelper.Instance.AddLog("异常","Center1","DrawItem", ex.Message);
                }
            }
                       
        }
        #endregion
        private void contextMenuStrip1_VisibleChanged(object sender, EventArgs e)
        {
            if(contextMenuStrip1.Visible)
            {
                if ((SROperation2.Instance.PicSelected != null) && (SROperation2.Instance.PicSelected.Count > 0))
                {
                   foreach(SRRC_ResourceEntity ent in SROperation2.Instance.PicSelected)
                    {
                        if (String.IsNullOrEmpty(ent.Extend3)) //视图优先排列标记
                        {
                            this.视图优先排列ToolStripMenuItem.Checked = false;
                            return;
                        }
                          
                    }
                    this.视图优先排列ToolStripMenuItem.Checked = true;
                }

                if(Param.GroupId > 2)
                {
                    this.复制toolStripMenuItem.Available = false;
                    this.粘贴toolStripMenuItem.Available = false;
                    this.toolStripSeparator2.Available = false;
                    this.视图优先排列ToolStripMenuItem.Available = false;
                    this.使用次数ToolStripMenuItem.Available = false;
                    this.跳转到原始微缩图ToolStripMenuItem.Available = false;
                    this.跳转到原始目录ToolStripMenuItem.Available = false;

                    this.复制toolStripMenuItem.Visible = false;
                    this.粘贴toolStripMenuItem.Visible = false;
                    this.toolStripSeparator2.Visible = false;
                    this.视图优先排列ToolStripMenuItem.Visible = false;
                    this.使用次数ToolStripMenuItem.Visible = false;
                    this.跳转到原始微缩图ToolStripMenuItem.Visible = false;
                    this.跳转到原始目录ToolStripMenuItem.Visible = false;

                    this.复制toolStripMenuItem.Enabled = false;
                    this.粘贴toolStripMenuItem.Enabled = false;
                    this.toolStripSeparator2.Enabled = false;
                    this.视图优先排列ToolStripMenuItem.Enabled = false;
                    this.使用次数ToolStripMenuItem.Enabled = false;
                    this.跳转到原始微缩图ToolStripMenuItem.Enabled = false;
                    this.跳转到原始目录ToolStripMenuItem.Enabled = false;

                }
            }
        }

        private void listView1_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            this.isTarget = false;
        }

        private void listView1_DragOver(object sender, DragEventArgs e)
        {
        }
        private void SetWaitPic()
        {
            FrmFrame ff = new FrmFrame() { Width = 284, Height = 258, Text = "正在加载，请稍后..." };
            WaitPic wp = new WaitPic();
            ff.SetUserControl(wp);
            ff.Show();
            while (SROperation2.Instance.isLoading)
            {
                wp.SetReadCount();
                ff.Refresh();
            }
        }

        private void Center1_Enter(object sender, EventArgs e)
        {
            SROperation2.Instance.FocusPanel = "Center1";
        }
        /// <summary>
        /// 清除ListView SelectedItems
        /// </summary>
        public void ClearListViewSelectedItems()
        {
            this.listView1.SelectedItems.Clear();
        }

        private void listViewLoadData_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bw = sender as BackgroundWorker;
            List<ListViewItem>[] arr = new List<ListViewItem>[entList.Count / _listViewLoadDataOnceCount + 1];
            int i = 0;
            arr[i] = new List<ListViewItem>();
            foreach (SRRC_ResourceEntity item in entList)
            {
                if (!bw.CancellationPending)
                {
                    ListViewItem litem = new ListViewItem();
                    if (item.Dtype == 0)//文件夹
                    {
                        litem.ImageKey = "folder";
                    }
                    else if (item.Dtype == 1)//图片
                    {
                        litem.ImageKey = "image";
                    }
                    else
                    {
                        litem.ImageKey = item.Extend1.ToLower();
                    }
                    if (!SROperation2.Instance.defaultImageNameList.Contains(litem.ImageKey))
                    {
                        litem.ImageKey = "default";
                    }
                    litem.Name = item.Id.ToString();
                    litem.Text = item.Name;
                    litem.Tag = item;
                    arr[i].Add(litem);
                    if(arr[i].Count == _listViewLoadDataOnceCount)
                    {
                        bw.ReportProgress(i, arr[i]);
                        i++;
                        arr[i] = new List<ListViewItem>();
                    }
                }
            }
            if(arr[i].Count > 0)
            {
                bw.ReportProgress(i, arr[i]);
            }
        }

        private void listViewLoadData_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var list = e.UserState as List<ListViewItem>;
            this.listView1.Items.AddRange(list.ToArray<ListViewItem>());
        }

        private void listViewLoadData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            #region 从资源目录跳转时，需要重新定义SROperation2.Instance.PicSelected文件，默认将其设置为第一项的，所以如果SROperation2.Instance.PicSelected相同则聚焦
            if (this.listView1 != null && this.listView1.Items.Count > 0)
            {
                List<SRRC_ResourceEntity> SelectedEntList;
                if (SROperation2.Instance.FocusPanel == "Center2")
                {
                    SelectedEntList = SROperation2.Instance.Center2PicSelected;
                }
                else
                {
                    SelectedEntList = SROperation2.Instance.PicSelected;
                }
                if (SelectedEntList != null && SelectedEntList.Count > 0)
                {
                    ListViewItem[] lvis = listView1.Items.Find(SelectedEntList[0].Id.ToString(), true);
                    if (lvis != null && lvis.Length > 0)
                    {
                        lvis[0].EnsureVisible();
                        lvis[0].Selected = true;
                        SROperation2.Instance.PicSelected.Clear();
                        SROperation2.Instance.PicSelected.Add(lvis[0].Tag as SRRC_ResourceEntity);
                    }
                }
            }
            #endregion
            (this.ParentForm as FrmMain).SetLoadStatus();
        }
    }
}
