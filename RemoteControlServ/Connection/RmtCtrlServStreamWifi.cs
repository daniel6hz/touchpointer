using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using RemoteControlServ.Structs;

namespace RemoteControl.Connection
{

    /// <summary>
    /// wifi连接模块
    /// </summary>
    class RmtCtrlServStreamWifi : ListenAble
    {
        private Socket Listener = null;
        private Socket Client;
        private Stream stream;
        private int endPoint;
        public string service = GuidServ.RemoteControl;

        public RmtCtrlServStreamWifi()
        {
            endPoint = 1988;//Convert.ToInt32(1988);
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, endPoint);
            Listener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream, ProtocolType.Tcp);
            Listener.Bind(localEndPoint);
            Listener.Listen(1);
        }
        /// <summary>
        /// 开始监听，等待传入连接，建立连接后验证安全信息，如果不合格则继续监听
        /// </summary>
        /// <returns></returns>
        public Stream Listen()
        {
            while (true)
            {
                Client = Listener.Accept();
                stream = new NetworkStream(Client);
                stream.WriteByte(0xff);
                try//服务验证
                {
                    byte[] verifyInfo = new byte[38];
                    stream.Read(verifyInfo, 0, 38);
                    string requestService = Encoding.ASCII.GetString(verifyInfo);
                    if (GuidServ.RemoteControl != requestService)
                    {
                        stream.Close();
                        continue;
                    }
                }
                catch (Exception e)
                {
                    continue;
                }
                return stream;
            }
            
        }

        public Stream getStream()
        {
            return stream;
        }

        public void Close()
        {
            if (Listener != null)
                Listener.Close();
            if (Client != null)
                Client.Close();
        }

    }
}
