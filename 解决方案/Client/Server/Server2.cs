using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Server.Server
{


    class ClientThread2
    {
        Encoding encoding = Encoding.GetEncoding("GB2312"); //解码器（可以用于汉字）

        private Socket client;
        private string data = null;
        private byte[] receiveBytes = new byte[1024];//服务器端设置缓冲区

        private int recCount;

        //传递连接socket  

        public ClientThread2(Socket ClientSocket)
        {
            this.client = ClientSocket;

        }

        //数据处理接口
        public void ClientServer()
        {
            try
            {

                while (true)
                {
                    //recCount = client.Receive(receiveBytes, receiveBytes.Length, 0);//从客户端接收信息
                    IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                    EndPoint Remote = (EndPoint)(sender);
                    recCount = client.ReceiveFrom(receiveBytes, ref Remote);

                    if (recCount != 0)//当服务器端的缓冲区接收到的信息不为空时
                    {

                        //data = encoding.getb(receiveBytes, 0, recCount); //接收数据
                        Console.WriteLine(DateTime.Now.ToString() + ArConvert.byteToHexStr(receiveBytes.Take(recCount).ToArray()));
                        Console.WriteLine(DateTime.Now + data);
                        //接收数据成功后给客户端返回OK  

                        //client.Send(encoding.GetBytes("OK"), 2, 0);

                    }

                    else
                    {

                        break;

                    }

                }

            }

            catch (Exception ex)
            {
                Console.Write("出现异常：");

                Console.WriteLine(ex.ToString());

                Console.ReadLine();

            }

            client.Close();

        }

    }
}
