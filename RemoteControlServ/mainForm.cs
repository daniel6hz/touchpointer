using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Windows.Forms;

using System.IO;
namespace RemoteControl
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
            rmtCtrlServ = new RemoteControlServ(this);
        }

        private RemoteControlServ rmtCtrlServ;

        public Tablet tablet = new Tablet();

        private void BtnRemoteControl_Click(object sender, EventArgs e)
        {
            if (rbtnBt.Checked)
            { rmtCtrlServ.Start(true); }
            else
            { rmtCtrlServ.Start(false); }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                this.notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            //this.notifyIcon1.Visible = false;
        }

          private void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            rmtCtrlServ.Stop();
        }
    }
}
