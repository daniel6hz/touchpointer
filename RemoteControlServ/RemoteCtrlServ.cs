using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;
using RemoteControl.Connection;
using RemoteControl.MsgProc;
using RemoteControlServ.Structs;

namespace RemoteControl
{

    /// <summary>
    /// 远程控制主模块,获取消息并对收到的消息进行分类和处理
    /// </summary>
    class RemoteControlServ
    {
        /// <summary>
        /// 连接模块，客户端服务器通讯的关键部分
        /// </summary>
        public ListenAble client;
        private Stream stream;//通讯的连接流
        private System.Threading.Thread ListenThread;//消息获取，分类，处理主要线程
        private bool running = false;//标记服务是否正在运行
        private mainForm mainForm;//主窗口对象
        private ImageMsg imgRequestMsg = new ImageMsg();//图像消息

        public RemoteControlServ(mainForm mainForm)
        {
            this.mainForm = mainForm;
        }

        /// <summary>
        /// 启动服务端远程控制服务，可以选择连接方式
        /// </summary>
        /// <param name="useBt">
        /// ture：使用蓝牙模块连接
        /// false：使用wifi模块连接</param>
        public void Start(bool useBt)
        {
            if (running)
            { return; }
            running = true;
            if (useBt)
            { client = new RmtCtrlServStreamBT(); }//选择使用蓝牙模块建立连接
            else
            { client = new RmtCtrlServStreamWifi(); }//使用wifi模块建立连接
            ListenThread = new System.Threading.Thread(new System.Threading.ThreadStart(ListenLoop));
            ListenThread.Start();
        }

        public void Stop()
        {
            if (client != null)
                client.Close();
        }

        /// <summary>
        /// 监听线程，程序主要线程，负责：消息获取，分类，调用相应模块进行处理
        /// </summary>
        private void ListenLoop()
        {
            byte[] msgbuff, headBuff = new byte[MyCoding.headSize];
            int received = 0;
            MouseMsgProc mouseMsgProc = new MouseMsgProc();//鼠标消息处理模块
            KeyMsgProc keyMsgProc = new KeyMsgProc();//键盘消息处理模块
            DirectMouseMsgProc directMouseMsgPrc = new DirectMouseMsgProc();//图像映射模式下鼠标消息处理模块
            // ImageMsg imgRequestMsg = new ImageMsg();
            while (true)//反复接受传入连接
            {
                try
                {
                    stream = client.Listen();// return;
                }
                catch (Exception e)
                {
                    //MessageBox.Show(e.Message.ToString());
                    break;
                }
                while (true)//反复读取消息
                {
                    try
                    {
                        stream.Read(headBuff, 0, MyCoding.headSize);
                    }
                    catch
                    {
                        break;
                    }
                    MsgHeader msgHeader = MyCoding.DecodeHeader(headBuff);
                    msgbuff = new byte[msgHeader.size];
                    received = stream.Read(msgbuff, 0, msgHeader.size);
                    if (received > 0)
                    {
                        switch (msgHeader.code)
                        {
                            case MsgCode.Mouse:
                                MouseMsgStruct mouseMsg = MyCoding.DecodeMouseMsg(msgbuff);
                                mouseMsgProc.ProcessMsg(mouseMsg);
                                break;
                            case MsgCode.KeyBoard:
                                KeyMsgStruct keyMsg = MyCoding.DecodeKeyMsg(msgbuff);
                                keyMsgProc.ProcessMsg(keyMsg);
                                break;
                            case MsgCode.ImageMsg:
                                imgRequestMsg.fromBuffer(msgbuff);
                                Thread sendImageThread = new Thread(new ThreadStart(imageThread));
                                sendImageThread.Start();
                                break;
                            case MsgCode.DirectMouseMsg:
                                MouseMsgStruct directMouseMsg = MyCoding.DecodeMouseMsg(msgbuff);
                                directMouseMsgPrc.ProcessMsg(directMouseMsg);
                                break;
                            case MsgCode.Tablet:
                                TabletMsgStruct tabletMsg = MyCoding.DecodeTabletMsg(msgbuff);
                                TabletMsgProc.msgProc(mainForm.tablet, tabletMsg);
                                break;
                            case MsgCode.Command:
                                CmdMsgStruct cmdMsg = MyCoding.DecodeCmdMsg(msgbuff);
                                CmdMsgProc.msgProc(cmdMsg);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        //connection lost
                        //MessageBox.Show("断开！");
                        break;
                    }
                }

                try
                {
                    stream.Close();
                }
                catch
                {
                }
            }

        }

        /// <summary>
        /// 图像消息处理线程
        /// 接受请求消息，将消息中所要求的屏幕块的图像以jpg数据发送过去
        /// </summary>
        private void imageThread()
        {
            Rectangle screenRect = SystemInformation.VirtualScreen;
            if (imgRequestMsg.width == 0)
            {
                imgRequestMsg.width = (short)(screenRect.Width);
                imgRequestMsg.height = (short)(screenRect.Height);
            }

            //图像处理过程，此处算法待改进
            Bitmap requestBitmap = new Bitmap(imgRequestMsg.width, imgRequestMsg.height);
            Graphics g = Graphics.FromImage(requestBitmap);
            g.CopyFromScreen(imgRequestMsg.x, imgRequestMsg.y, 0, 0, new Size(imgRequestMsg.width, imgRequestMsg.height));


            MemoryStream memStream = new MemoryStream();
            requestBitmap.Save(memStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            int length = (int)memStream.Length;

            imgRequestMsg.imgSize = length;
            byte[] imgResponseMsgBuff = imgRequestMsg.toBuffer();
            try
            {
                stream.Write(imgResponseMsgBuff, 0, imgResponseMsgBuff.Length);
                stream.Write(memStream.GetBuffer(), 0, length);
            }
            catch
            {
                return;
            }

            

            //分段发送，暂时不用
            //int segment = 1000024;
            ////int time = 10;
            //int cur = 0;
            //while (cur + segment < length)
            //{
            //    stream.Write(memStream.GetBuffer(), cur, segment);
            //    stream.Flush();
            //    cur += segment;
            //    //Thread.Sleep(time);
            //}

            //stream.Write(memStream.GetBuffer(), cur, length - cur);
        }
    }


}
