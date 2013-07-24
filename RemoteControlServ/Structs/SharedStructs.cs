using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace RemoteControlServ.Structs
{
    /// <summary>
    /// BT服务Guid，Wifi验证信息
    /// </summary>
    class GuidServ
    {
        public const string RemoteControl = "{7A51FDC2-FDDF-4c9b-AFFC-98BCD91BF93B}";
    }



    /// <summary>
    /// 消息结构体头部
    /// </summary>
    struct MsgHeader
    {
        public MsgCode code;
        public int size;
    }
    enum MsgCode : byte { Mouse, KeyBoard, ImageMsg, Option, DirectMouseMsg, Command, Tablet };



    /// <summary>
    /// 鼠标消息结构体
    /// </summary>
    struct MouseMsgStruct
    {
        public MouseMsgCode MsgCode;
        public short X;
        public short Y;
    }
    enum MouseMsgCode : byte { MouseMove, MouseDown, MouseUp, ScrollUp, ScrollDown, MBtnClick, Click, Drag, RClick };



    /// <summary>
    /// 键盘消息结构体
    /// </summary>
    struct KeyMsgStruct
    {
        public KeyMsgCode msgCode;
        public short keyCode;
    }
    public enum KeyMsgCode : byte { KeyDown, KeyUp, Char };


    /// <summary>
    /// 命令消息结构体
    /// </summary>
    public enum CmdMsgCode : byte { RunMediaPlayer };
    public struct CmdMsgStruct
    {
        public CmdMsgCode msgCode;
        public int param1;
        public int param2;
        public CmdMsgStruct(CmdMsgCode msgCode, int param1, int param2)
        {
            this.msgCode = msgCode;
            this.param1 = param1;
            this.param2 = param2;
        }
    }


    /// <summary>
    /// 手写板消息
    /// </summary>
    public enum TabletMsgCode : byte { ShowTablet, HideTablet, Draw, Clear };
    public struct TabletMsgStruct
    {
        public TabletMsgCode msgCode;
        public int x1;
        public int x2;
        public int y1;
        public int y2;
        public TabletMsgStruct(TabletMsgCode msgCode, int x1, int y1, int x2, int y2)
        {
            this.msgCode = msgCode;
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
    }


    /// <summary>
    /// 编码解码模块，对数据编码后传输，再解码
    /// </summary>
    class MyCoding
    {
        public const int headSize = 5;       //消息头长度（字节）
        public const int mouseMsgSize = 5;   //鼠标消息长度（字节）
        public const int keyMsgSize = 3;     //键盘消息长度（字节）
        public const int cmdMsgSize = 9;     //命令消息长度（字节）
        public const int tabletMsgSize = 17; //手写板消息长度（字节）
        /// <summary>
        /// 对鼠标消息编码
        /// </summary>
        /// <param name="Msg">鼠标消息结构体</param>
        /// <returns>编码后的字节数组</returns>
        public static byte[] EncodeMouseMsg(MouseMsgStruct Msg)
        {
            byte[] buff = new byte[headSize + mouseMsgSize];
            buff[0] = (byte)MsgCode.Mouse;
            BitConverter.GetBytes(mouseMsgSize).CopyTo(buff, 1);
            buff[5] = (byte)Msg.MsgCode;
            BitConverter.GetBytes(Msg.X).CopyTo(buff, 6);
            BitConverter.GetBytes(Msg.Y).CopyTo(buff, 8);
            return buff;
        }

        public static byte[] EncodeKeyMsg(KeyMsgStruct Msg)
        {
            byte[] buff = new byte[headSize + keyMsgSize];
            buff[0] = (byte)MsgCode.KeyBoard;
            BitConverter.GetBytes(keyMsgSize).CopyTo(buff, 1);
            buff[5] = (byte)Msg.msgCode;
            BitConverter.GetBytes(Msg.keyCode).CopyTo(buff, 6);
            return buff;
        }
        public static MsgHeader DecodeHeader(byte[] bytemsg)
        {
            MsgHeader header = new MsgHeader();
            header.code = (MsgCode)bytemsg[0];
            header.size = BitConverter.ToInt32(bytemsg, 1);
            return header;
        }
        /// <summary>
        /// 对鼠标消息解码
        /// </summary>
        /// <param name="bytemsg">要解码的字节数组</param>
        /// <returns>鼠标消息结构体</returns>
        public static MouseMsgStruct DecodeMouseMsg(byte[] bytemsg)
        {
            MouseMsgStruct Msg = new MouseMsgStruct();
            Msg.MsgCode = (MouseMsgCode)bytemsg[0];
            Msg.X = BitConverter.ToInt16(bytemsg, 1);
            Msg.Y = BitConverter.ToInt16(bytemsg, 3);
            return Msg;
        }
        public static KeyMsgStruct DecodeKeyMsg(byte[] bytemsg)
        {
            KeyMsgStruct Msg = new KeyMsgStruct();
            Msg.msgCode = (KeyMsgCode)bytemsg[0];
            Msg.keyCode = BitConverter.ToInt16(bytemsg, 1);
            return Msg;
        }
        public static byte[] EncodeDirectMouseMsg(MouseMsgStruct Msg)
        {
            byte[] buff = new byte[headSize + mouseMsgSize];
            buff[0] = (byte)MsgCode.DirectMouseMsg;
            BitConverter.GetBytes(mouseMsgSize).CopyTo(buff, 1);
            buff[5] = (byte)Msg.MsgCode;
            BitConverter.GetBytes(Msg.X).CopyTo(buff, 6);
            BitConverter.GetBytes(Msg.Y).CopyTo(buff, 8);
            return buff;
        }
        public static MouseMsgStruct DecodeDirectMouseMsg(byte[] bytemsg)
        {
            MouseMsgStruct Msg = new MouseMsgStruct();
            Msg.MsgCode = (MouseMsgCode)bytemsg[0];
            Msg.X = BitConverter.ToInt16(bytemsg, 1);
            Msg.Y = BitConverter.ToInt16(bytemsg, 3);
            return Msg;
        }

        public static byte[] EncodeCmdMsg(CmdMsgStruct Msg)
        {
            byte[] buff = new byte[headSize + cmdMsgSize];
            buff[0] = (byte)MsgCode.Command;
            BitConverter.GetBytes(cmdMsgSize).CopyTo(buff, 1);
            buff[5] = (byte)Msg.msgCode;
            BitConverter.GetBytes(Msg.param1).CopyTo(buff, 6);
            BitConverter.GetBytes(Msg.param2).CopyTo(buff, 10);
            return buff;
        }
        public static CmdMsgStruct DecodeCmdMsg(byte[] bytemsg)
        {
            CmdMsgStruct Msg = new CmdMsgStruct();
            Msg.msgCode = (CmdMsgCode)bytemsg[0];
            Msg.param1 = BitConverter.ToInt32(bytemsg, 1);
            Msg.param2 = BitConverter.ToInt32(bytemsg, 5);
            return Msg;
        }
        public static byte[] EncodeTabletMsg(TabletMsgStruct Msg)
        {
            byte[] buff = new byte[headSize + tabletMsgSize];
            buff[0] = (byte)MsgCode.Tablet;
            BitConverter.GetBytes(tabletMsgSize).CopyTo(buff, 1);
            buff[5] = (byte)Msg.msgCode;
            BitConverter.GetBytes(Msg.x1).CopyTo(buff, 6);
            BitConverter.GetBytes(Msg.y1).CopyTo(buff, 10);
            BitConverter.GetBytes(Msg.x2).CopyTo(buff, 14);
            BitConverter.GetBytes(Msg.y2).CopyTo(buff, 18);
            return buff;
        }
        public static TabletMsgStruct DecodeTabletMsg(byte[] bytemsg)
        {
            TabletMsgStruct Msg = new TabletMsgStruct();
            Msg.msgCode = (TabletMsgCode)bytemsg[0];
            Msg.x1 = BitConverter.ToInt32(bytemsg, 1);
            Msg.y1 = BitConverter.ToInt32(bytemsg, 5);
            Msg.x2 = BitConverter.ToInt32(bytemsg, 9);
            Msg.y2 = BitConverter.ToInt32(bytemsg, 13);
            return Msg;
        }

    }

    /// <summary>
    /// 图像消息
    /// </summary>
    class ImageMsg
    {
        const int msgSize = 12;
        public short x;
        public short y;
        public short width;
        public short height;
        public int imgSize;
        public ImageMsg() { }
        public ImageMsg(int x, int y, int width, int height, int size)
        {
            this.x = (short)x;
            this.y = (short)y;
            this.width = (short)width;
            this.height = (short)height;
            this.imgSize = size;
        }
        /// <summary>
        /// 图像消息构造函数
        /// </summary>
        /// <param name="rect">请求的图像位置</param>
        /// <param name="size">返回的图像数据的大小</param>
        public ImageMsg(Rectangle rect, int size)
        {
            this.x = (short)rect.X;
            this.y = (short)rect.Y;
            this.width = (short)rect.Width;
            this.height = (short)rect.Height;
            this.imgSize = size;
        }
        /// <summary>
        /// 将消息编码为字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] toBuffer()
        {
            byte[] buff = new byte[5 + msgSize];
            buff[0] = (byte)MsgCode.ImageMsg;//头部
            BitConverter.GetBytes(msgSize).CopyTo(buff, 1);//头部
            BitConverter.GetBytes(x).CopyTo(buff, 5);
            BitConverter.GetBytes(y).CopyTo(buff, 7);
            BitConverter.GetBytes(width).CopyTo(buff, 9);
            BitConverter.GetBytes(height).CopyTo(buff, 11);
            BitConverter.GetBytes(imgSize).CopyTo(buff, 13);
            return buff;
        }
        /// <summary>
        /// 将字节数组解码成消息
        /// </summary>
        /// <param name="buffer"></param>
        public void fromBuffer(byte[] buffer)
        {
            x = BitConverter.ToInt16(buffer, 0);
            y = BitConverter.ToInt16(buffer, 2);
            width = BitConverter.ToInt16(buffer, 4);
            height = BitConverter.ToInt16(buffer, 6);
            imgSize = BitConverter.ToInt32(buffer, 8);
        }
    }
}
