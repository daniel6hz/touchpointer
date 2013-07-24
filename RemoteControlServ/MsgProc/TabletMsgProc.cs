using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RemoteControlServ.Structs;

namespace RemoteControl.MsgProc
{
    /// <summary>
    /// 手写板消息处理模块
    /// 处理面板打开，关闭，绘画消息
    /// </summary>
    class TabletMsgProc
    {
        public static void msgProc(Tablet tablet,TabletMsgStruct msg)
        {
            switch (msg.msgCode)
            {
                case TabletMsgCode.ShowTablet:
                    tablet.Show();
                    break;
                case TabletMsgCode.Draw:
                    tablet.drawLine(msg.x1, msg.y1, msg.x2, msg.y2);
                    break;
                case TabletMsgCode.Clear:
                    tablet.clear();
                    break;
                case TabletMsgCode.HideTablet:
                    tablet.Hide();
                    break;
            }
        }
    }
}
