using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using RemoteControl.Structs;

namespace RemoteControl.MsgProc
{
    public enum ImgMode { Normal, ZoomOut, ZoomIn, Stop };
    class ImgMsgProc
    {
        private Image screenImg;
        private Image imgZoomOut;
        private ImgMode imgMode = ImgMode.Normal;
        private Graphics GraphScreen, GraphZoomOut;
        private bool firstTime = true;
        private RmtCtrlClient client;

        public ImgMsgProc(RmtCtrlClient client)
        {
            this.client = client;
            //screenImg = new Bitmap(screenSize.Width, screenSize.Height);
            //mobileImg = new Bitmap(mobileSize.Width, mobileSize.Height);
            //GScreen = Graphics.FromImage(screenImg);
            //GMobile = Graphics.FromImage(mobileImg);
        }

        public void msgProc(ImageMsg msg, Stream stream)
        {
            MemoryStream memStream;// = new MemoryStream();
            byte[] buff = new byte[msg.imgSize];
            int readCount = 0;
            //MessageBox.Show("开始！");
            //int tmp = Environment.TickCount;

            while (readCount < msg.imgSize)
            {
                int curReadCnt = stream.Read(buff, readCount, msg.imgSize - readCount);
                readCount += curReadCnt;
            }
            //string str = "";
            //str += Environment.TickCount - tmp + " 接收完成：" + length + "    ";
            //tmp = Environment.TickCount;
            memStream = new MemoryStream(buff);
            //str += Environment.TickCount - tmp + " 内存流完成      ";
            //tmp = Environment.TickCount;
            Image receiveBitmap = new Bitmap(memStream);

            if (!firstTime)
            {
                procImg(receiveBitmap, msg.x, msg.y);
            }
            else
            {
                screenImg = new Bitmap(msg.width, msg.height);
                GraphScreen = Graphics.FromImage(screenImg);
                GraphScreen.DrawImage(receiveBitmap, msg.x, msg.y);
                //imgZoomOut = new Bitmap(msg.width * 2, msg.height * 2);
                //GraphZoomOut = Graphics.FromImage(imgZoomOut);
                this.client.PCScreenSize = new Size(screenImg.Width, screenImg.Height);
                firstTime = false;
            }

            //发送图片请求
            //Thread.Sleep(10);  //延时
            ImageMsg imgRequestMsg = new ImageMsg(getRealRect(client.curRect), 0);
            client.SendByteMsg(imgRequestMsg.toBuffer());
        }

        public Point zoomLarger(int X, int Y)
        {
            switch (imgMode)
            {
                case ImgMode.Normal:
                    imgMode = ImgMode.ZoomOut;
                    return new Point(X * 2, Y * 2);
                case ImgMode.ZoomOut:

                default:
                    return new Point();
            }
        }
        public Point zoomSmaller(int X, int Y)
        {
            switch (imgMode)
            {
                case ImgMode.ZoomOut:
                    imgMode = ImgMode.Normal;
                    return new Point(X / 2, Y / 2);
                case ImgMode.Normal:
                default:
                    return new Point();
            }
        }
        public Image getImage()
        {
            switch (imgMode)
            {
                case ImgMode.Normal:
                    return screenImg;
                case ImgMode.ZoomOut:
                    return imgZoomOut;
                default:
                    return null;
            }
        }
        public Point CurPosToRealPos(int X, int Y)
        {
            Point realPos;
            switch (imgMode)
            {
                case ImgMode.Normal:
                    realPos = new Point(X, Y);
                    return realPos;
                case ImgMode.ZoomOut:
                    realPos = new Point(X / 2, Y / 2);
                    return realPos;
                default:
                    return new Point();
            }
        }
        //public Point RealPosToCurPos(int X, int Y)
        //{
        //    Point realPos;
        //    switch (imgMode)
        //    {
        //        case ImgMode.Normal:
        //            realPos = new Point(X, Y);
        //            return realPos;
        //        case ImgMode.ZoomOut:
        //            realPos = new Point(X * 2, Y * 2);
        //            return realPos;
        //        default:
        //            return new Point();
        //    }
        //}
        public void stop()
        {
            imgMode = ImgMode.Stop;
        }

        private Rectangle getRealRect(Rectangle curRect)
        {
            switch (imgMode)
            {
                case ImgMode.Normal:

                    return new Rectangle(curRect.X, curRect.Y, curRect.Width, curRect.Height);
                case ImgMode.ZoomOut:
                    return new Rectangle(curRect.X / 2, curRect.Y / 2, curRect.Width / 2, curRect.Height / 2);
                default:
                    return new Rectangle();
            }
        }

        private void procImg(Image recvBitmap, int X, int Y)
        {
            switch (imgMode)
            {
                case ImgMode.ZoomOut:
                    imgMode = ImgMode.Normal;
                    GraphScreen.DrawImage(recvBitmap, X, Y);
                    Rectangle destRect=new Rectangle(X*2,Y*2,recvBitmap.Width,recvBitmap.Height);
                    Rectangle srcRect=new Rectangle(0,0,recvBitmap.Width,recvBitmap.Height);
                    GraphZoomOut.DrawImage(recvBitmap, destRect, srcRect, GraphicsUnit.Pixel);
                    return;
                case ImgMode.Normal:
                    GraphScreen.DrawImage(recvBitmap, X, Y);
                    break;
                default:
                    return;
            }
        }
    }
}
