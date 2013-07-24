using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Windows.Forms;
using RemoteControl.Structs;

namespace RemoteControl.Connection
{
    /// <summary>
    /// 连接模块的接口
    /// </summary>
    public interface ConnectAble
    {
        bool Connect();
        Stream getStream();
    }

    /// <summary>
    /// 蓝牙连接模块
    /// </summary>
    class RmtCtrlStreamBT :ConnectAble
    {
        private BluetoothAddress deviceAddr = null;
        private String DeviceName = null;
        private BluetoothClient BTClient, dtstream;
        private Guid service = new Guid(GuidServ.RemoteControl);
        private Stream stream;

        public RmtCtrlStreamBT()
        {
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            SelectRmtDev();
        }

        /// <summary>
        /// 搜索并选择指定蓝牙设备
        /// </summary>
        private void SelectRmtDev()
        {
            BluetoothRadio.PrimaryRadio.Mode = RadioMode.Connectable;
            SelectBluetoothDeviceDialog selDia = null;
            selDia = new SelectBluetoothDeviceDialog();
            selDia.ShowAuthenticated = true;
            selDia.ShowRemembered = true;
            selDia.ShowUnknown = true;
            if (selDia.ShowDialog() == DialogResult.OK)
            {
                deviceAddr = selDia.SelectedDevice.DeviceAddress;
                DeviceName = selDia.SelectedDevice.DeviceName;
                //labDeviceName.Text = DeviceName;
            }
        }

        /// <summary>
        /// 连接指定设备
        /// </summary>
        /// <returns></returns>
        public bool Connect()
        {
            try
            {
                BTClient = new BluetoothClient();
                BTClient.Connect(new BluetoothEndPoint(deviceAddr, service));
                stream = BTClient.GetStream();
                return true;
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.Message.ToString());
                return false;
            }
        }
        public Stream getStream()
        {
            return stream;
        }
    }
}
