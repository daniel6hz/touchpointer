using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.IO;
using System.Xml.Serialization;
using RemoteControl.Structs;
using RemoteControl.Connection;
using RemoteControl.MsgProc;

namespace RemoteControl
{
    /// <summary>
    /// 远程控制手机端的主模块
    /// 提供了消息处理接口，调用相应的功能模块来处理各类消息。
    /// </summary>
    class RmtCtrlClient
    {
        /// <summary>
        /// 图像消息事件
        /// 每当收到图像时，就会触发该事件，用于更新背景图片
        /// </summary>
        public event ImgRecvdEventHandler ImageReveived;
        public Form1 mainForm;
        public ImgMsgProc imgMsgProc;
        public Rectangle curRect;//当前手机屏幕位置（相对于电脑屏幕）
        public Size mobileScreenSize;
        public Size PCScreenSize;
        public bool debug = false;

        private ConnectAble client;
        private Stream stream;
        private KeyMsgStruct keyMsg = new KeyMsgStruct();
        private Thread receiveImgThd;
        private Mode curMode = Mode.NonPicMode;
        private MouseMsgProc mouseMsgProc;
        private ScrollbarMsgProc scrollbarMsgProc;
        private Tablet tablet;
        private bool showDesktopMode = false;

        public RmtCtrlClient(Form1 mainForm, Size moblieScrSize)
        {
            this.mainForm = mainForm;
            this.mobileScreenSize = moblieScrSize;
            curRect = new Rectangle(0, 0, mobileScreenSize.Width, mobileScreenSize.Height);
            scrollbarMsgProc = new ScrollbarMsgProc(this);
            imgMsgProc = new ImgMsgProc(this);
            tablet = new Tablet(this);
        }

        /// <summary>
        /// 连接远程主机
        /// 根据要求，选择连接方式，可以是通过蓝牙，或者wifi
        /// </summary>
        /// <param name="useBt">是否使用蓝牙方式，否则使用wifi</param>
        /// <param name="ip">wifi的IP地址</param>
        /// <param name="ep">wifi的端口</param>
        public void Connect(bool useBt, string ip, string ep)
        {
            if (useBt)
            {
                client = new RmtCtrlStreamBT();
                client.Connect();
                stream = client.getStream();
            }
            else
            {
                client = new RmtCtrlStreamWifi(ip, ep);
                client.Connect();
                stream = client.getStream();
            }
            mouseMsgProc = new MouseMsgProc(this, stream);

        }

        /// <summary>
        /// 开启桌面显示
        /// </summary>
        /// <param name="enable">是否开启：
        /// 是：开启显示桌面图像功能
        /// 否：关闭图像功能</param>
        public void showDesktop(bool enable)
        {

            if (enable)
            {
                showDesktopMode = true;
                curMode = Mode.PicMode;
                receiveImgThd = new Thread(new ThreadStart(receiveImageLoop));
                receiveImgThd.Priority = ThreadPriority.Lowest;
                receiveImgThd.Start();
            }
            else
            {
                curMode = Mode.NonPicMode;
                showDesktopMode = false;
            }
        }

        /// <summary>
        /// 拖拽模式
        /// 在图像模式下，可以进入拖拽模式，从而拖动图像移到指定位置
        /// </summary>
        /// <returns></returns>
        public bool dragMode()
        {
            if (curMode == Mode.PicMode)
            {
                curMode = Mode.PicDragMode;
                mainForm.lableDrag.Visible = true;
                return true;
            }
            else if (curMode == Mode.PicDragMode)
            {
                curMode = Mode.PicMode;
                mainForm.lableDrag.Visible = false;
            }
            return false;
        }

        /// <summary>
        /// 开启手写板
        /// </summary>
        public void showTablet()
        {
            tablet.Show();
            TabletMsgStruct tabletMsg = new TabletMsgStruct(TabletMsgCode.ShowTablet, 0, 0, 0, 0);
            SendByteMsg(MyCoding.EncodeTabletMsg(tabletMsg));
        }

        /// <summary>
        /// 鼠标消息处理
        /// </summary>
        /// <param name="code">鼠标消息类型</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ProcMouseMsg(MouseMsgCode code, int x, int y)
        {
            MouseMsgStruct msg = new MouseMsgStruct();
            msg.MsgCode = code;
            msg.X = (short)x;
            msg.Y = (short)y;
            try
            {
                mouseMsgProc.ProcessMsg(curMode, msg);
            }
            catch { }
        }

        /// <summary>
        /// scrollbar消息处理
        /// </summary>
        /// <param name="code"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void ProcScrollbarMsg(MouseMsgCode code, int x, int y)
        {
            MouseMsgStruct msg = new MouseMsgStruct();
            msg.MsgCode = code;
            msg.X = (short)x;
            msg.Y = (short)y;
            if (curMode == Mode.PicDragMode)
            {
                scrollbarMsgProc.procZoomMsg(msg);
            }
            else
            {
                scrollbarMsgProc.procScrollMsg(msg);
            }
        }

        /// <summary>
        /// 键盘消息处理
        /// </summary>
        public void ProcKeyMsg(KeyMsgCode msgCode, short keyCode)
        {
            keyMsg.msgCode = msgCode;
            keyMsg.keyCode = keyCode;
            switch (keyMsg.msgCode)
            {
                case KeyMsgCode.KeyDown:
                    KeyChar = false;
                    break;
                case KeyMsgCode.KeyUp:
                    if (keyMsg.keyCode == (short)Keys.Clear)
                        KeyChar = true;
                    break;
                case KeyMsgCode.Char:
                    if (!KeyChar)
                        return;
                    break;
            }
            SendByteMsg(MyCoding.EncodeKeyMsg(keyMsg));
        }
        private bool KeyChar = false;//过滤本地按键产生的字符消息


        /// <summary>
        /// 命令消息处理
        /// </summary>
        /// <param name="msgCode"></param>
        /// <param name="param1"></param>
        /// <param name="param2"></param>
        public void ProcCmdMsg(CmdMsgCode msgCode,int param1,int param2)
        {
            CmdMsgStruct msg = new CmdMsgStruct(msgCode, param1, param2);
            SendByteMsg(MyCoding.EncodeCmdMsg(msg));
        }

        /// <summary>
        /// 发送消息到流
        /// </summary>
        /// <param name="byteMsg"></param>
        public void SendByteMsg(byte[] byteMsg)
        {
            try
            {
                stream.Write(byteMsg, 0, byteMsg.Length);
            }
            catch
            {
                //MessageBox.Show("write stream err");
            }
        }

        //图片接受线程函数
        private void receiveImageLoop()
        {


            //while (true)
            //{

            //    stream.Read(lengthBuff, 0, 4);

            //    //Graphics converter = Graphics.FromImage(bitmap);

            //   // while (true) ;
            //    //Bitmap bitmap = new Bitmap(1000, 1000);
            //    //Thread.Sleep(3000);
            //    str+=Environment.TickCount - tmp + " 转化完成     " ;
            //    //tmp = Environment.TickCount;
            //    ImageReveived(bitmap,str);
            //    //MessageBox.Show(Environment.TickCount - tmp + " 更新完成");
            //}
            
            ImageMsg imgMsg = new ImageMsg();
            MsgHeader msgHeader;
            byte[] msgbuff, headBuff = new byte[MyCoding.headSize];
            int received = 0;
            ImageMsg imgFirstRequestMsg = new ImageMsg(0, 0, 0, 0, 0);//首次请求
            SendByteMsg(imgFirstRequestMsg.toBuffer());

            while (showDesktopMode)//反复
            {

                //读取图片
                stream.Read(headBuff, 0, MyCoding.headSize);
                msgHeader = MyCoding.DecodeHeader(headBuff);
                if (debug)
                    MessageBox.Show(msgHeader.size.ToString());
                msgbuff = new byte[msgHeader.size];
                
                received = stream.Read(msgbuff, 0, msgHeader.size);
                if (!showDesktopMode)
                { break; }
                if (received > 0)
                {
                    switch (msgHeader.code)
                    {
                        case MsgCode.ImageMsg://图片处理
                            imgMsg.fromBuffer(msgbuff);
                            imgMsgProc.msgProc(imgMsg, stream);
                            ImageReveived(imgMsgProc.getImage(), "");
                            break;
                    }
                }
                else
                {
                    //connection lost
                    MessageBox.Show("断开！");
                    break;
                }
            }
            imgMsgProc.stop();
            MessageBox.Show("退出背景模式！");

        }

        

    }


}
