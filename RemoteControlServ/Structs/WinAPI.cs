using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace RemoteControlServ.Structs
{
    /// <summary>
    /// PC端调用的Windows API 函数
    /// </summary>
    class WinAPI
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(int bVk, byte bScan, int dwFlags, int dwExtraInfo);

        [DllImport("user32.dll")]
        public static extern int GetFocus();

        [DllImport("user32.dll")]
        public static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(int hWnd, int lpdwProcessId);

        [DllImport("Kernel32.dll")]
        public static extern int GetCurrentThreadId();

        [DllImport("user32.dll")]
        public static extern bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);

        [DllImport("user32.dll")]
        public static extern int GetCursorPos(ref POINT p);

        [DllImport("user32.dll")]
        public static extern int SetCursorPos(int x, int y);

        [DllImport("user32.dll")]
        public static extern int mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

    }
}
