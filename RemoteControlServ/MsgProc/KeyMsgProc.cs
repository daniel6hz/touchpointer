using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RemoteControlServ.Structs;

namespace RemoteControl.MsgProc
{
    /// <summary>
    /// 键盘消息处理模块，包括字符消息处理
    /// </summary>
    class KeyMsgProc
    {
        private System.Timers.Timer ctnHitTimer;//按键连击计时器
        private bool ctnStart = false;
        private int startTime = 500;//开启连击时间长度
        private int ctnTime = 40;//按键连击间隔
        private short tmpKeyCode;
        public KeyMsgProc()
        {
            ctnHitTimer = new System.Timers.Timer(startTime);
            ctnHitTimer.Elapsed += new System.Timers.ElapsedEventHandler(ctnHitTimer_Elapsed);
        }

        public void ProcessMsg(KeyMsgStruct Msg)
        {

            //POINT curPoint; 
            switch (Msg.msgCode)
            {
                case KeyMsgCode.KeyDown:
                    procKeyDown(Msg.keyCode);
                    break;
                case KeyMsgCode.KeyUp:
                    WinAPI.keybd_event(Msg.keyCode, 0, 2, 0);
                    ctnHitTimer.Stop();
                    break;
                case KeyMsgCode.Char://处理字符消息
                    SendChar(Msg.keyCode);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 发送字符消息
        /// 将字符发送到焦点窗口中，反复调用则可以发送字符串到指定窗口
        /// </summary>
        /// <param name="keyCode">字符码</param>
        private void SendChar(short keyCode)
        {
            int handle = WinAPI.GetForegroundWindow();
            int ThreadID = WinAPI.GetWindowThreadProcessId(handle, 0);
            WinAPI.AttachThreadInput(WinAPI.GetCurrentThreadId(), ThreadID, true);
            int focusHandle = WinAPI.GetFocus();
            byte[] uniByte = BitConverter.GetBytes(keyCode);
            byte[] ansiByte = Encoding.Convert(Encoding.Unicode, Encoding.Default, uniByte);
            foreach (byte i in ansiByte)
            {
                WinAPI.SendMessage(focusHandle, 0x0102, i, 0);
            }
            WinAPI.AttachThreadInput(WinAPI.GetCurrentThreadId(), ThreadID, false);
        }



        /// <summary>
        /// 处理keydown消息
        /// 调用API发送消息，并开启按键连击
        /// </summary>
        /// <param name="keyCode">按键码</param>
        private void procKeyDown(short keyCode)
        {
            WinAPI.keybd_event(keyCode, 0, 0, 0);
            ctnStart = true;
            ctnHitTimer.Interval = startTime;
            ctnHitTimer.Start();
            tmpKeyCode = keyCode;
        }
        /// <summary>
        /// 按键连击处理
        /// 如果不在连击模式，则是首次发送，说明连击已经开启，进入连击模式
        /// 如果在连击模式，则再次发送按键消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ctnHitTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (ctnStart)
            {
                ctnHitTimer.Interval = ctnTime;
                ctnStart = false;
            }
            else
            {
                WinAPI.keybd_event(tmpKeyCode, 0, 0, 0);
            }
        }
    }
}
