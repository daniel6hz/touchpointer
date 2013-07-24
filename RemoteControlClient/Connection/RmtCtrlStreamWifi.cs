using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Windows.Forms;
using RemoteControl.Structs;

namespace RemoteControl.Connection
{
    /// <summary>
    /// wifi连接模块
    /// </summary>
    class RmtCtrlStreamWifi :ConnectAble
    {

        private String DeviceName = null;
        private IPEndPoint rmtEndPoint;
        private Socket Client;
        private string service = GuidServ.RemoteControl;
        private Stream stream;

        public RmtCtrlStreamWifi(string ipAddress, string endPoint)
        {
            IPAddress ip;
            int endpt;
            try
            {
                ip = IPAddress.Parse(ipAddress);
                endpt = Convert.ToInt32(endPoint);
                rmtEndPoint = new IPEndPoint(ip, endpt);
            }
            catch
            {
                MessageBox.Show("IP地址填写有误！");
            }

        }

        /// <summary>
        /// 连接指定地址
        /// </summary>
        /// <returns>是否连接成功</returns>
        public bool Connect()
        {
            Client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Client.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);
            try
            {
                Client.Connect(rmtEndPoint);
                stream = new NetworkStream(Client);
                byte[] verifyInfo = Encoding.ASCII.GetBytes(service);
                stream.Write(verifyInfo,0,verifyInfo.Length);//提供验证信息
                //过滤无效字符
                while (true)
                {
                    int startByte = stream.ReadByte();
                    if (startByte == 0xff)
                        break;
                }
                return true;
            }
            catch
            {
                MessageBox.Show("无法连接主机，请确认IP及端口！");
                return false;
            }
        }
        /// <summary>
        /// 得到连接流
        /// </summary>
        /// <returns></returns>
        public Stream getStream()
        {
            return stream;
        }
    }
}
