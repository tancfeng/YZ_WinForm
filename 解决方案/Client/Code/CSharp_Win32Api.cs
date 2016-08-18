using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace WindowsAPI

{

    class CSharp_Win32Api

    {
        public const int SB_HORZ = 0;
        public const int SB_VERT = 1;
        public const int SB_CTL = 2;
        public const int SB_BOTH = 3;

        #region User32.dll 函数

        /// <summary>

        /// 该函数检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图。hWnd：设备上下文环境被检索的窗口的句柄

        /// </summary>

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(int hwnd, int wBar, int bShow);

        #endregion
    }
}
