using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;


public class ClientEntity
{
    //设备Code
    public String Code { get; set; }
    public String RemoteEndPoint { get; set; }
    public Socket ClientSoket { get; set; }
    public DateTime RefreshTime { get; set; }

    private String _CMD = "";
    //发下指令
    public String CMD
    {
        get { return _CMD; }
        set { _CMD = value; }
    }
    private String _MsgCode = "";
    //信息Code
    public String MsgCode
    {
        get { return _MsgCode; }
        set { _MsgCode = value; }
    }



    public ClientEntity()
    {
 
    }
    public ClientEntity(string strcode, Socket _ClientSoket)
    {
        this.Code = strcode; this.ClientSoket = _ClientSoket;
    }

    public ClientEntity(string strcode, Socket _ClientSoket, DateTime _RefreshTime)
    {
        this.Code = strcode; this.ClientSoket = _ClientSoket; this.RefreshTime = _RefreshTime;
    }
}
