using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RemoteControlServ.Structs
{
    /// <summary>
    /// 鼠标位置结构体
    /// </summary>
    public struct POINT
    {
        public int x, y;
    }

    /// <summary>
    /// 鼠标消息结构体,主要用于PC端算法一块
    /// </summary>
    struct MouseBtnMsg
    {
        public MouseMsgCode code;
        public int x;
        public int y;
        public int time;
        public MouseBtnMsg(MouseMsgCode code, int x, int y, int time)
        {
            this.code = code;
            this.x = x;
            this.y = y;
            this.time = time;
        }
    }
}
