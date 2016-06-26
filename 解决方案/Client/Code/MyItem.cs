using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SirdRoom.ManageSystem.ClientApplication.Code
{
    public class MyItem
    {
        //项文本内容
        private String Text;

        //项图片
        public Image Img;

        public String Value;
        
        //构造函数
        public MyItem(String text, Image img,string value)
        {
            Text = text;
            Img = img;
            Value = value;
        }

        //重写ToString函数，返回项文本
        public override string ToString()
        {
            return Text;
        }
    }

}
