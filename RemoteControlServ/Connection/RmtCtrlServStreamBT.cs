using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Windows.Forms;
using RemoteControlServ.Structs;

namespace RemoteControl.Connection
{
    /// <summary>
    /// 连接模块的接口
    /// </summary>
    public interface ListenAble
    {
        Stream Listen();
        Stream getStream();
        void Close();
    }

    /// <summary>
    /// 蓝牙连接模块
    /// </summary>
    class RmtCtrlServStreamBT : ListenAble
    {
        private BluetoothListener btListener = null;
        private BluetoothClient btClient;
        private System.IO.Stream stream;
        private Guid service = new Guid(GuidServ.RemoteControl);

        public RmtCtrlServStreamBT()
        {
            btListener = new BluetoothListener(service);

        }
        /// <summary>
        /// 接口，开始监听，获取stream
        /// </summary>
        /// <returns>建立的连接流</returns>
        public Stream Listen()
        {
            btListener.Start();
            btClient = btListener.AcceptBluetoothClient();
            stream = btClient.GetStream();
            return stream;
        }
        /// <summary>
        /// 得到stream
        /// </summary>
        /// <returns></returns>
        public Stream getStream()
        {
            return stream;
        }

        public void Close()
        {
            if (btListener != null)
                btListener.Stop();
            if (btClient != null)
                btClient.Close();
        }


        //public int Read(byte[] buffer, int offset, int count)//接口
        //{
        //    return stream.Read(buffer, offset, count);
        //}
        //public void Close()//接口
        //{
        //    btClient.Close();
        //}
    }

    
}