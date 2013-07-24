using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RemoteControl
{
    /// <summary>
    /// 手写板窗体
    /// </summary>
    public partial class Tablet : Form
    {
        private Graphics graph;
        Pen pen;
        public Tablet()
        {
            InitializeComponent();
            graph = this.CreateGraphics();
            Color color = Color.FromArgb(255,0, 0, 0);
            pen = new Pen(color);
            Form.CheckForIllegalCrossThreadCalls = false;
        }
        public void drawLine(int x1, int y1, int x2, int y2)
        {
            graph.DrawLine(pen, x1, y1, x2, y2);
        }

        public void clear()
        {
            graph.Clear(this.BackColor);
        }
    }
}
