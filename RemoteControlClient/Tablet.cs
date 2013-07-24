using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RemoteControl.Structs;
namespace RemoteControl
{
    /// <summary>
    /// 手写板模块
    /// </summary>
    partial class Tablet : Form
    {
        private Graphics graph;
        private Pen pen;
        private Point startPoint;
        private Point endPoint;
        private RmtCtrlClient client;
        public Tablet(RmtCtrlClient client)
        {
            this.client = client;
            InitializeComponent();
            graph = this.CreateGraphics();
            Color color = Color.FromArgb(0, 0, 0);
            pen = new Pen(color);
        }


        private void Tablet_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = new Point(e.X, e.Y);
        }

        private void Tablet_MouseMove(object sender, MouseEventArgs e)
        {
            endPoint = new Point(e.X, e.Y);
            graph.DrawLine(pen, startPoint.X,startPoint.Y, endPoint.X,endPoint.Y);
            TabletMsgStruct msg=new TabletMsgStruct( TabletMsgCode.Draw,startPoint.X,startPoint.Y, endPoint.X,endPoint.Y);
            client.SendByteMsg(MyCoding.EncodeTabletMsg(msg));
            startPoint = endPoint;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TabletMsgStruct msg = new TabletMsgStruct(TabletMsgCode.HideTablet, 0, 0, 0, 0);
            client.SendByteMsg(MyCoding.EncodeTabletMsg(msg));
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            graph.Clear(this.BackColor);
            TabletMsgStruct msg = new TabletMsgStruct(TabletMsgCode.Clear, 0, 0, 0, 0);
            client.SendByteMsg(MyCoding.EncodeTabletMsg(msg));
        }

    }
}