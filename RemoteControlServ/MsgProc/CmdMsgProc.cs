using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using RemoteControlServ.Structs;

namespace RemoteControl.MsgProc
{
    /// <summary>
    /// 命令消息处理模块
    /// 处理：启动程序
    /// </summary>
    class CmdMsgProc
    {
        static private string[] mediaPlayers = new string[1]
        {
            @"C:\Program Files\Windows Media Player\wmplayer.exe",
           // @"C:\Program Files\TTPlayer\TTPlayer.exe"
        };
        static public void msgProc(CmdMsgStruct msg)
        {
            switch (msg.msgCode)
            {
                case CmdMsgCode.RunMediaPlayer:
                    Process mediaProcess = new Process();
                    mediaProcess.StartInfo.FileName = mediaPlayers[msg.param1];
                    mediaProcess.Start();
                    break;
                default:
                    break;
            }
        }
    }
}
