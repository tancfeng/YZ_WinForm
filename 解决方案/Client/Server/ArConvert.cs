using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ArConvert
{


    /// <summary> 
    /// 从汉字转换到16进制 
    /// </summary> 
    /// <param name="s"></param> 
    /// <param name="charset">编码,如"utf-8","gb2312"</param> 
    /// <param name="fenge">是否每字符用逗号分隔</param> 
    /// <returns></returns> 
    public static string ConvertZHTo16(string s, string charset, bool fenge)
    {
        if ((s.Length % 2) != 0)
        {
            s += " ";//空格 
            //throw new ArgumentException("s is not valid chinese string!"); 
        }
        System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
        byte[] bytes = chs.GetBytes(s);
        string str = "";
        for (int i = 0; i < bytes.Length; i++)
        {
            str += string.Format("{0:X}", bytes[i]);
            if (fenge && (i != bytes.Length - 1))
            {
                str += string.Format("{0}", ",");
            }
        }
        return str.ToLower();
    }

    ///<summary> 
    /// 从16进制转换成汉字 
    /// </summary> 
    /// <param name="hex"></param> 
    /// <param name="charset">编码,如"utf-8","gb2312"</param> 
    /// <returns></returns> 
    public static string Convert16ToZH(string hex, string charset)
    {
        if (hex == null)
            throw new ArgumentNullException("hex");
        hex = hex.Replace(",", "");
        hex = hex.Replace("\n", "");
        hex = hex.Replace("\\", "");
        hex = hex.Replace(" ", "");
        if (hex.Length % 2 != 0)
        {
            hex += "20";//空格 
        }
        // 需要将 hex 转换成 byte 数组。 
        byte[] bytes = new byte[hex.Length / 2];
        for (int i = 0; i < bytes.Length; i++)
        {
            try
            {
                // 每两个字符是一个 byte。 
                bytes[i] = byte.Parse(hex.Substring(i * 2, 2),
                System.Globalization.NumberStyles.HexNumber);
            }
            catch
            {
                // Rethrow an exception with custom message. 
                throw new ArgumentException("hex is not a valid hex number!", "hex");
            }
        }
        System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
        return chs.GetString(bytes);
    }

    /// <summary>
    /// 将16进制转为double
    /// </summary>
    /// <param name="strval"></param>
    /// <returns></returns>
    public static double Convert16ToDouble(string strval)
    {
        ulong num1 = ulong.Parse(strval, System.Globalization.NumberStyles.AllowHexSpecifier);
        byte[] floatVals1 = BitConverter.GetBytes(num1);
        string run_tdddw = BitConverter.ToSingle(floatVals1, 0).ToString();
        return Convert.ToDouble(run_tdddw);
    }
    /// <summary>
    /// 将double转为16进制
    /// </summary>
    /// <param name="strval"></param>
    /// <returns></returns>
    public static String ConvertDoubleTo16(double ival, Int32 ilength)
    {
        string strjg = ival.ToString("X");
        Int32 ib0length = ilength - strjg.Length;
        for (int i = 0; i < ib0length; i++)
        {
            strjg = "0" + strjg;
        }
        return strjg.ToUpper();
    }


    /// <summary>
    /// int 到十六进制
    /// </summary>
    /// <param name="ival"></param>
    /// <param name="ilength"></param>
    /// <returns></returns>
    public static String ConvertIntTo16(Int32 ival, Int32 ilength)
    {
        string strjg = Convert.ToString(ival, 16);
        Int32 ib0length = ilength - strjg.Length;
        for (int i = 0; i < ib0length; i++)
        {
            strjg = "0" + strjg;
        }
        return strjg.ToUpper();
    }


    /// <summary>
    /// 将十六进制到int
    /// </summary>
    /// <param name="ival"></param>
    /// <param name="ilength"></param>
    /// <returns></returns>
    public static Int32 Convert16ToInt(String strval)
    {
        return Int32.Parse(strval, System.Globalization.NumberStyles.HexNumber);
    }


    /// <summary> 
    /// 字符串转16进制字节数组 
    /// </summary> 
    /// <param name="hexString"></param> 
    /// <returns></returns> 
    public static byte[] strToToHexByte(string hexString)
    {
        hexString = hexString.Replace(" ", "");
        if ((hexString.Length % 2) != 0)
            hexString += " ";
        byte[] returnBytes = new byte[hexString.Length / 2];
        for (int i = 0; i < returnBytes.Length; i++)
            returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
        return returnBytes;
    }

    /// <summary> 
    /// 字节数组转16进制字符串 
    /// </summary> 
    /// <param name="bytes"></param> 
    /// <returns></returns> 
    public static string byteToHexStr(byte[] bytes)
    {
        string returnStr = "";
        if (bytes != null)
        {
            for (int i = 0; i < bytes.Length; i++)
            {
                returnStr += bytes[i].ToString("X2");
            }
        }
        return returnStr;
    }

    /// <summary> 
    /// 字节数组转16进制字符串 
    /// </summary> 
    /// <param name="bytes"></param> 
    /// <returns></returns> 
    public static string byteToHexStr(byte[] bytes, Int32 icount)
    {
        string returnStr = "";
        if (bytes != null)
        {
            for (int i = 0; i < icount; i++)
            {
                returnStr += bytes[i].ToString("X2");
            }
        }
        return returnStr;
    }

    /// <summary>
    /// 十六进制到二进制
    /// </summary>
    /// <param name="strval"></param>
    /// <param name="ilength"></param>
    /// <returns></returns>
    public static String Convert16To2(string strval, Int32 ilength)
    {
        string strjg = Convert.ToString(Convert16ToInt(strval), 2);
        Int32 ib0length = ilength - strjg.Length;
        for (int i = 0; i < ib0length; i++)
        {
            strjg = "0" + strjg;
        }
        return strjg;
    }
    /// <summary>
    /// 二进制到十六进制
    /// </summary>
    /// <param name="strval"></param>
    /// <param name="ilength"></param>
    /// <returns></returns>
    public static String Convert2To16(string strval, Int32 ilength)
    {
        string strjg = Convert.ToString(Convert.ToInt32(strval, 2), 16);
        Int32 ib0length = ilength - strjg.Length;
        for (int i = 0; i < ib0length; i++)
        {
            strjg = "0" + strjg;
        }
        return strjg;
    }

    /// <summary>
    /// 十六进制转int64
    /// </summary>
    /// <param name="strval"></param>
    /// <returns></returns>
    public static Int64 Convert16ToInt64(string strval)
    {
        return Int64.Parse(strval, System.Globalization.NumberStyles.HexNumber);
    }


    /// <summary>
    /// int64 转 十六进制
    /// </summary>
    /// <param name="ival"></param>
    /// <param name="ilength"></param>
    /// <returns></returns>
    public static String ConvertInt64To16(Int64 ival, Int32 ilength)
    {
        string strjg = Convert.ToString(ival, 16);
        Int32 ib0length = ilength - strjg.Length;
        for (int i = 0; i < ib0length; i++)
        {
            strjg = "0" + strjg;
        }
        return strjg.ToUpper();
    }
}
