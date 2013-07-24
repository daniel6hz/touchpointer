using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Timers;
using RemoteControlServ.Structs;

namespace RemoteControl.MsgProc
{
    /// <summary>
    /// 图像映射模式下，鼠标消息处理模块
    /// </summary>
    class DirectMouseMsgProc
    {
        
        public void ProcessMsg(MouseMsgStruct Msg)
        {
            switch (Msg.MsgCode)
            {
                case MouseMsgCode.MouseMove:
                    //WinAPI.mouse_event(1, (short)Msg.XParam, (short)Msg.YParam, 0, 0);
                    WinAPI.SetCursorPos(Msg.X, Msg.Y);
                    break;
                case MouseMsgCode.MouseDown:
                    WinAPI.SetCursorPos(Msg.X, Msg.Y);
                    WinAPI.mouse_event(2, (short)Msg.X, (short)Msg.Y, 0, 0);
                    break;
                case MouseMsgCode.MouseUp:
                    WinAPI.mouse_event(4, (short)Msg.X, (short)Msg.Y, 0, 0);
                    break;
                case MouseMsgCode.MBtnClick:
                    WinAPI.mouse_event(32, 0, 0, 0, 0);
                    WinAPI.mouse_event(64, 0, 0, 0, 0);
                    break;
                case MouseMsgCode.ScrollDown:
                    WinAPI.mouse_event(2048, 0, 0, -120, 0);
                    break;
                case MouseMsgCode.ScrollUp:
                    WinAPI.mouse_event(2048, 0, 0, 120, 0);
                    break;
                case MouseMsgCode.RClick:
                    WinAPI.SetCursorPos(Msg.X, Msg.Y);
                    WinAPI.mouse_event(0x8, Msg.X, Msg.Y, 0, 0);
                    WinAPI.mouse_event(0x10, Msg.X, Msg.Y, 0, 0);
                    break;
            }
        }

        //private void MouseMove(int x, int y)
        //{
        //    WinAPI.mouse_event(1, x, y, 0, 0);
        //}

        //private void MouseDown(int x, int y)
        //{
        //    WinAPI.mouse_event(2, x, y, 0, 0);
        //}

        //private void MouseUp(int x, int y)
        //{
        //    WinAPI.mouse_event(4, x, y, 0, 0);
        //}

        
    }
}
