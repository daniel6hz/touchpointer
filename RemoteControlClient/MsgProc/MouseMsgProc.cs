using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using RemoteControl.Structs;

namespace RemoteControl.MsgProc
{
    class MouseMsgProc
    {
        private Stream stream;

        private RmtCtrlClient rmtCtrlClient;
        private Timer checkTimer = new Timer();
        private int checkRange = 15;
        public MouseMsgProc(RmtCtrlClient rmtCtrlClient, Stream stream)
        {
            this.stream = stream;
            //this.curRect = curRect;
            this.rmtCtrlClient = rmtCtrlClient;
            checkTimer.Interval = 400;
            checkTimer.Tick += new EventHandler(checkTimer_Tick);
        }


        public void ProcessMsg(Mode curMode, MouseMsgStruct msg)
        {
            switch (curMode)
            {
                case Mode.NonPicMode:
                    SendByteMsg(MyCoding.EncodeMouseMsg(msg));
                    break;
                case Mode.PicMode:
                    Point realPoint = rmtCtrlClient.imgMsgProc.CurPosToRealPos(rmtCtrlClient.curRect.X + msg.X, rmtCtrlClient.curRect.Y + msg.Y);
                    msg.X = (short)realPoint.X;
                    msg.Y = (short)realPoint.Y;
                    procPicMouseMsg(msg);
                    break;
                case Mode.PicDragMode:
                    procPicDragMsg(msg);
                    break;
            }
        }
        private void SendByteMsg(byte[] byteMsg)
        {
            try
            {
                stream.Write(byteMsg, 0, byteMsg.Length);
            }
            catch
            {
            }
        }

        private Point mouseDownPos = new Point();
        private Point rectStartPos = new Point();
        private int outSize = 30;
        private void procPicDragMsg(MouseMsgStruct msg)
        {
            switch (msg.MsgCode)
            {
                case MouseMsgCode.MouseMove:
                    bool updata = false;
                    int x = rectStartPos.X - (msg.X - mouseDownPos.X);
                    int y = rectStartPos.Y - (msg.Y - mouseDownPos.Y);
                    if (0 - outSize <= x && x <= rmtCtrlClient.PCScreenSize.Width - rmtCtrlClient.mobileScreenSize.Width)
                    {
                        rmtCtrlClient.curRect.X = x;
                        updata = true;
                    }
                    if (0 <= y && y <= rmtCtrlClient.PCScreenSize.Height - rmtCtrlClient.mobileScreenSize.Height + outSize)
                    {
                        rmtCtrlClient.curRect.Y = y;
                        updata = true;
                    }
                    if (updata)
                    {
                        rmtCtrlClient.mainForm.Invalidate();
                        rmtCtrlClient.mainForm.Update();
                    }
                    break;
                case MouseMsgCode.MouseDown:
                    rectStartPos.X = rmtCtrlClient.curRect.X;
                    rectStartPos.Y = rmtCtrlClient.curRect.Y;
                    mouseDownPos.X = msg.X;
                    mouseDownPos.Y = msg.Y;
                    break;
                case MouseMsgCode.MouseUp:
                    if (Math.Abs(msg.X - mouseDownPos.X) < 5 && Math.Abs(msg.Y - mouseDownPos.Y) < checkRange)
                    {
                        rmtCtrlClient.dragMode();
                    }
                    break;
            }
        }


        List<MouseMsgStruct> clickRecord = new List<MouseMsgStruct>();
        List<MouseMsgStruct> moveRecord = new List<MouseMsgStruct>();
        private void procPicMouseMsg(MouseMsgStruct msg)
        {
            if (checkTimer.Enabled == true)
            {
                if (msg.MsgCode != MouseMsgCode.MouseMove)
                { clickRecord.Add(msg); }
                else { moveRecord.Add(msg); }
                return;
            }

            switch (msg.MsgCode)
            {
                case MouseMsgCode.MouseDown:
                    moveRecord.Clear();
                    clickRecord.Clear();
                    checkTimer.Enabled = true;
                    clickRecord.Add(msg);
                    break;
                case MouseMsgCode.MouseMove:
                    SendByteMsg(MyCoding.EncodeDirectMouseMsg(msg));
                    break;
                case MouseMsgCode.MouseUp:
                    SendByteMsg(MyCoding.EncodeDirectMouseMsg(msg));
                    break;
                default:
                    break;
            }
        }
        void checkTimer_Tick(object sender, EventArgs e)
        {
            checkTimer.Enabled = false;
            switch (clickRecord.Count)
            {
                case 1:
                    if (moveRecord.Count == 0)
                    {
                        MouseMsgStruct rmsg = clickRecord[0];
                        rmsg.MsgCode = MouseMsgCode.RClick;
                        SendByteMsg(MyCoding.EncodeDirectMouseMsg(rmsg));
                        return;
                    }
                    else if (Math.Abs(moveRecord.Last().X - clickRecord[0].X) < checkRange && Math.Abs(moveRecord.Last().Y - clickRecord[0].Y) < checkRange)
                    {
                        MouseMsgStruct rmsg = clickRecord[0];
                        rmsg.MsgCode = MouseMsgCode.RClick;
                        SendByteMsg(MyCoding.EncodeDirectMouseMsg(rmsg));
                        return;
                    }
                    break;
                case 3:
                    MouseMsgStruct dragMsg = clickRecord[0];
                    rectStartPos.X = rmtCtrlClient.curRect.X;
                    rectStartPos.Y = rmtCtrlClient.curRect.Y;
                    mouseDownPos.X = dragMsg.X;
                    mouseDownPos.Y = dragMsg.Y;
                    rmtCtrlClient.dragMode();
                    return;
                default:
                    break;
            }
            MouseMsgStruct msg;
            foreach (MouseMsgStruct mouseMsg in clickRecord)
            {
                msg = mouseMsg;
                msg.X = clickRecord[0].X;
                msg.Y = clickRecord[0].Y;
                SendByteMsg(MyCoding.EncodeDirectMouseMsg(msg));
            }
        }
    }
}
