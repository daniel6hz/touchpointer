using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using RemoteControl.Structs;

namespace RemoteControl.MsgProc
{
    class ScrollbarMsgProc
    {
        private int startPosY;
        private RmtCtrlClient rmtCtrlClient;
        private int scrollCheckLength;//屏幕旋转需处理！
        public ScrollbarMsgProc(RmtCtrlClient rmtCtrlClient)
        {
            this.rmtCtrlClient = rmtCtrlClient;
            scrollCheckLength = rmtCtrlClient.mobileScreenSize.Height / 20;//平均处理20次左右
        }
        public void procScrollMsg(MouseMsgStruct msg)
        {
            switch (msg.MsgCode)
            {
                case MouseMsgCode.MouseDown:
                    startPosY = msg.Y;
                    break;
                case MouseMsgCode.MouseMove:
                    if (msg.Y - startPosY > scrollCheckLength)
                    {
                        msg.MsgCode = MouseMsgCode.ScrollDown;
                        rmtCtrlClient.SendByteMsg(MyCoding.EncodeDirectMouseMsg(msg));
                        startPosY += scrollCheckLength;
                    }
                    else if (startPosY - msg.Y > scrollCheckLength)
                    {
                        msg.MsgCode = MouseMsgCode.ScrollUp;
                        rmtCtrlClient.SendByteMsg(MyCoding.EncodeDirectMouseMsg(msg));
                        startPosY -= scrollCheckLength;
                    }
                    break;
                case MouseMsgCode.MouseUp:
                    break;
            }
        }
        public void procZoomMsg(MouseMsgStruct msg)
        {
            switch (msg.MsgCode)
            {
                case MouseMsgCode.MouseDown:

                    break;
                case MouseMsgCode.MouseMove:

                    break;
                case MouseMsgCode.MouseUp:
                    break;
            }
        }



        //任意比例缩放：因效率原因，此代码作废。
        //private int prevPosY;
        //private Rectangle startRect;
        //private int Xscale;
        //private int Yscale;
        //private int zoomCheckLength;
        //public ScrollbarMsgProc(RmtCtrlClient rmtCtrlClient)
        //{
        //    this.rmtCtrlClient = rmtCtrlClient;
        //    scrollCheckLength = rmtCtrlClient.mobileScreenSize.Height / 20;//平均处理20次左右
        //    if (rmtCtrlClient.mobileScreenSize.Height > rmtCtrlClient.mobileScreenSize.Width)
        //    {
        //        Xscale = 3;//3:4屏幕，竖屏
        //        Yscale = 4;
        //    }
        //    else
        //    {
        //        Xscale = 4;//4：3屏幕，横屏
        //        Yscale = 3;
        //    }
        //    zoomCheckLength = Yscale * 2;
        //}
        //public void procZoomMsg(MouseMsgStruct msg)
        //{
        //    switch (msg.MsgCode)
        //    {
        //        case MouseMsgCode.MouseDown:
        //            startPosY = msg.YParam;
        //            startRect = rmtCtrlClient.curRect;
        //            prevPosY = msg.YParam;
        //            break;
        //        case MouseMsgCode.MouseMove:
        //            if (msg.YParam - prevPosY > zoomCheckLength || prevPosY - msg.YParam > zoomCheckLength)//开始缩放
        //            {
        //                int changeSize = msg.YParam - startPosY;
        //                if (changeSize < 0)
        //                    zoomIn(-changeSize);
        //                else
        //                    zoomOut(changeSize);
        //                prevPosY = msg.YParam;
        //                rmtCtrlClient.mainForm.Invalidate();
        //                rmtCtrlClient.mainForm.Update();
        //            }
        //            break;
        //        case MouseMsgCode.MouseUp:
        //            break;
        //    }
        //}
        //private void zoomIn(int changeSize)
        //{
        //    int level = changeSize / zoomCheckLength;
        //    int tempRectHeight = startRect.Height - Yscale * 2 * level;
        //    if (tempRectHeight >= rmtCtrlClient.mobileScreenSize.Height / 4) //放大过度确认
        //    {
        //        rmtCtrlClient.curRect.X = startRect.X + Xscale * level;
        //        rmtCtrlClient.curRect.Y = startRect.Y + Yscale * level;
        //        rmtCtrlClient.curRect.Width = startRect.Width - Xscale * 2 * level;
        //        rmtCtrlClient.curRect.Height = tempRectHeight;
        //    }
        //}
        //private void zoomOut(int changeSize)
        //{
        //    int level = changeSize / zoomCheckLength;
        //    int tempRectHeight = startRect.Height + Yscale * 2 * level;
        //    if (tempRectHeight <= rmtCtrlClient.mobileScreenSize.Height) //缩小过度确认
        //    {
        //        rmtCtrlClient.curRect.X = startRect.X - Xscale * level;
        //        rmtCtrlClient.curRect.Y = startRect.Y - Yscale * level;
        //        rmtCtrlClient.curRect.Width = startRect.Width + Xscale * 2 * level;
        //        rmtCtrlClient.curRect.Height = tempRectHeight;
        //    }
        //}
    }
}
