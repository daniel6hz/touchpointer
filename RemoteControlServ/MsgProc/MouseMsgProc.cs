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
    /// 鼠标消息处理模块，对来自手机的消息进行处理，并生成最终的鼠标控制信号
    /// </summary>
    class MouseMsgProc
    {
        private Queue<POINT> recentPoints;
        private List<MouseBtnMsg> recentMouseMsg;
        private Queue<Timer> ClickDelayTimers;
        private Timer RightClickTimer;
        private double SpeedupRate;
        private int ClickTime, ClickRange, SingleClickDelayTime;
        private bool MoveStatus = false, DragMode = false;
        

        public MouseMsgProc()
        {
            recentPoints = new Queue<POINT>();//记录最近的鼠标消息
            recentMouseMsg = new List<MouseBtnMsg>();//记录最近的完成的鼠标动作
            ClickDelayTimers = new Queue<Timer>();//记录最近的单击延时计时器
            SpeedupRate = 0.125;//鼠标加速参数，0-0.2适宜
            ClickTime = 200;//单击判断时间，小于时间间隔才被认为完成一个单击操作
            ClickRange = 15;//移动判断，初次按下时，当移动小于这个距离时，忽略所有移动消息，以此来提高点击成功率
            SingleClickDelayTime = 150;//单击延时发送，用于配合拖拽功能
            RightClickTimer = new Timer(400);//右击计时器
            RightClickTimer.Elapsed += new ElapsedEventHandler(SendRightClick);
        }

        /// <summary>
        /// 处理鼠标消息
        /// </summary>
        /// <param name="Msg"></param>
        public void ProcessMsg(MouseMsgStruct Msg)
        {
           switch (Msg.MsgCode)
           {
               case MouseMsgCode.MouseMove:
                   if (MoveStatus)
                       MouseMove(Msg.X, Msg.Y);
                   else 
                       CheckMove(Msg.X, Msg.Y);
                    break;
               case MouseMsgCode.MouseDown:
                    MouseDown(Msg.X, Msg.Y);
                    break;
               case MouseMsgCode.MouseUp:
                    MouseUp(Msg.X, Msg.Y);
                    break;
               default:
                    break;
           }
        }
        /// <summary>
        /// 鼠标按下消息是：单击、双击、右击、移动、拖动的第一个消息，需要进行精确的判断和区分
        /// 将消息加入消息历史队列，用于后续精确判断
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MouseDown(int x, int y)
        {
            recentPoints.Clear();
            POINT p = new POINT();
            p.x = x;
            p.y = y;
            recentPoints.Enqueue(p);//鼠标移动起始点
            recentMouseMsg.Add(new MouseBtnMsg(MouseMsgCode.MouseDown,0,0,System.Environment.TickCount));
            CheckDrag();
            RightClickTimer.Start();
        }

        /// <summary>
        /// 鼠标抬起消息是：单击、双击、拖动的完成消息，需要进行精确的判断和区分
        /// 配合之前已经完成的鼠标动作，判断当前抬起消息是处理的单击、双击、拖动中哪一个
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MouseUp(int x, int y)
        {
            POINT p = new POINT();
            WinAPI.GetCursorPos(ref p);
            recentMouseMsg.Add(new MouseBtnMsg(MouseMsgCode.MouseUp, p.x, p.y, System.Environment.TickCount));
            if (!CheckClick())
                CheckDoubleClick();
            MoveStatus=false;
            RightClickTimer.Stop();
        }
        
        /// <summary>
        /// 处理鼠标移动消息，结合加速函数，更新当前鼠标的位置
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void MouseMove(int x,int y)
        {
            POINT LP,cur=new POINT();
            LP = recentPoints.Last();
            POINT p = new POINT();
            p.x = x;
            p.y = y;
            recentPoints.Enqueue(p);
            WinAPI.GetCursorPos(ref cur);
            x=x-LP.x;
            y=y-LP.y;
            //str1 += x + " ";
            //str2 += y + " ";
            SpeedUp(ref x, ref y);
            WinAPI.SetCursorPos(cur.x + x, cur.y + y);
        }

        /// <summary>
        /// 鼠标加速函数，根据鼠标消息间距大小调节鼠标的移动速度
        /// 间距大小意味着手指在触摸屏上的移动速度，速度越快，间距越大
        /// 此项可以做到根据手指移动速度自动调节鼠标移动速度
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SpeedUp(ref int x, ref int y)
        {
            int max = Math.Abs(x);
            double rate = 0;
            if ( Math.Abs(y) > max) 
                max = Math.Abs(y);
            if (max < 4)
                rate = 1;
            else
                rate = 1 + (max - 4) * SpeedupRate;
            #region
            //switch (max / 5)
            //{
            //    case 0:
            //        rate = 1;
            //        break;
            //    case 1:
            //        rate = 1.5;
            //        break;
            //    case 2:
            //        rate = 2;
            //        break;             
            //    case 3:
            //        rate = 2.5;
            //        break;
            //    case 4:
            //    case 5:

            //    case 6:
            //    case 7:
 
            //    default:
            //        rate = 3;
            //        break;
            //}
            #endregion
            x = (int)(x * rate);
            y = (int)(y * rate);
            return;
        }

        /// <summary>
        /// 在首次鼠标键按下时，小幅度的移动消息将被忽略，以消除由于手指抖动带来的影响
        /// </summary>
        /// <param name="curMobileX"></param>
        /// <param name="curMobileY"></param>
        private void CheckMove(int curMobileX, int curMobileY)
        {
            if (Math.Abs(recentPoints.Last().x - curMobileX) > ClickRange || Math.Abs(recentPoints.Last().y - curMobileY) > ClickRange)
            {
                POINT p=new POINT();
                p.x=curMobileX;p.y=curMobileY;
                recentPoints.Enqueue(p);
                MoveStatus=true;
                recentMouseMsg.Add(new MouseBtnMsg(MouseMsgCode.MouseMove,0,0,0));
                RightClickTimer.Stop();
            }
        }

        /// <summary>
        /// 判断是否完成一个单击动作，主要判别项包括：
        /// 时间间隔，是否完成一个按下操作，是否处于拖拽模式
        /// </summary>
        /// <returns></returns>
        private bool CheckClick()
        {
            int n;
            n = recentMouseMsg.Count;
            if (n > 2)
                if (recentMouseMsg[n - 2].code == MouseMsgCode.MouseDown)
                    if (recentMouseMsg[n - 1].time - recentMouseMsg[n - 2].time < ClickTime)
                    //if (recentMouseMsg[n - 1].x == recentMouseMsg[n - 2].x
                    //&&recentMouseMsg[n - 1].y == recentMouseMsg[n - 2].y)
                    {
                        if (DragMode)
                        {
                            WinAPI.mouse_event(4, 0, 0, 0, 0);
                            DragMode = false;
                            return true;
                        }
                        recentMouseMsg.Add(new MouseBtnMsg(MouseMsgCode.Click, 0, 0, Environment.TickCount));
                        Timer t = new Timer(SingleClickDelayTime);
                        t.Elapsed += new ElapsedEventHandler(SendSingleClick);
                        t.Start();
                        ClickDelayTimers.Enqueue(t);
                        return true;
                    }
            return false;
        }

        /// <summary>
        /// 发送单击操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SendSingleClick(object sender, ElapsedEventArgs e)
        {
            WinAPI.mouse_event(2, 0, 0, 0, 0);
            WinAPI.mouse_event(4, 0, 0, 0, 0);
            try
            {
                ClickDelayTimers.Dequeue().Stop();
            }
            catch { }
        }

        /// <summary>
        /// 判断是否完成一个拖拽开启动作，主要判别项包括：
        /// 最近是否完成一个单击动作，时间间隔。
        /// </summary>
        /// <returns></returns>
        private bool CheckDrag()
        {
            int n;
            n = recentMouseMsg.Count;
            if (n > 2)
                if (recentMouseMsg[n - 2].code == MouseMsgCode.Click)
                    if (recentMouseMsg[n - 1].time - recentMouseMsg[n - 2].time < SingleClickDelayTime)
                    {
                        DragMode = true;
                        ClickDelayTimers.Dequeue().Stop();
                        WinAPI.mouse_event(2, 0, 0, 0, 0);
                        recentMouseMsg.Add(new MouseBtnMsg(MouseMsgCode.Drag, 0, 0, Environment.TickCount));
                    }
            return false;
        }

        /// <summary>
        /// 判断是否完成一个双击动作，主要判别项包括：
        /// 最近是否完成一个拖拽动作，时间间隔
        /// </summary>
        /// <returns></returns>
        private bool CheckDoubleClick()
        {
            int n;
            n = recentMouseMsg.Count;
            if (n > 2)
                if (recentMouseMsg[n - 2].code == MouseMsgCode.Drag)
                {
                    if (recentMouseMsg[n - 1].time - recentMouseMsg[n - 2].time < SingleClickDelayTime)
                    {
                        WinAPI.mouse_event(4, 0, 0, 0, 0);
                        WinAPI.mouse_event(2, 0, 0, 0, 0);
                    }
                    DragMode =false;
                    WinAPI.mouse_event(4, 0, 0, 0, 0);
                    recentMouseMsg.Clear();
                }
            return false;
        }
        private void SendRightClick(object sender, ElapsedEventArgs e)
        {
            WinAPI.mouse_event(0x008, 0, 0, 0, 0);
            WinAPI.mouse_event(0x0010, 0, 0, 0, 0);
            RightClickTimer.Stop();
        }
    }
}
