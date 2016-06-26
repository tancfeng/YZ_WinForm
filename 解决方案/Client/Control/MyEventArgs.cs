using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class MyEventArgs
{
    /// <summary>
    /// 0单击 1双击 2右击 3ListView选中改变事件 5KeywordChange 6右键快捷菜单
    /// </summary>
    public Int32 Action { get; set; }
    public Object Parameter { get; set; }
}
