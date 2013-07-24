using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace RemoteControl.Structs
{
    public delegate void ImgRecvdEventHandler(Image image, string str);
    public enum Mode { NonPicMode, PicMode, PicDragMode };
}
