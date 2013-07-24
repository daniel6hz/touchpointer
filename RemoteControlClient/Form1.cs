using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Sockets;
using InTheHand.Net.Bluetooth;
using InTheHand.Windows.Forms;
using System.IO;
using System.Threading;
using RemoteControl.Structs;
using PictureButton;

namespace RemoteControl
{
    public enum Direction { Up, Down, Left, Right };
    public partial class Form1 : Form
    {
        
        private RmtCtrlClient rmtCtrlClient;
        private Rectangle mainFormRect;//旋转需改变！

        public Form1()
        {
            InitializeComponent();
            rmtCtrlClient = new RmtCtrlClient(this, new Size(this.Width, this.Height));
            tabPanel.SelectedIndex = 3;
            rmtCtrlClient.ImageReveived += new ImgRecvdEventHandler(rmtCtrlClient_ImageReveived);
            mainFormRect = new Rectangle(0, 0, this.Width, this.Height);
            //pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

        }
        delegate void UpdataCtrl();
        //画背景
        //响应背景更新事件
        void rmtCtrlClient_ImageReveived(Image image, string str)
        {
            UpdataCtrl pic = delegate()
            {
                this.Invalidate();
            };
            this.Invoke(pic);
        }
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(rmtCtrlClient.imgMsgProc.getImage(), mainFormRect, rmtCtrlClient.curRect, GraphicsUnit.Pixel);
            }
            catch { base.OnPaintBackground(e); }
        }


        //功能按钮
        private void BtnSellect_Click(object sender, EventArgs e)
        {
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            if (rbtnBt.Checked)
            {
                rmtCtrlClient.Connect(true, textBox1.Text, textBox2.Text);
            }
            else
            {
                rmtCtrlClient.Connect(false, textBox1.Text, textBox2.Text);
            }
            btnInput.Focus();
        }

        //鼠标事件
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            rmtCtrlClient.ProcMouseMsg(MouseMsgCode.MouseMove, e.X, e.Y);

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            rmtCtrlClient.ProcMouseMsg(MouseMsgCode.MouseDown, e.X, e.Y);


        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            rmtCtrlClient.ProcMouseMsg(MouseMsgCode.MouseUp, e.X, e.Y);
            //this.Invalidate();
            //this.Update();
        }

        //软键盘事件
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            rmtCtrlClient.ProcKeyMsg(KeyMsgCode.KeyDown, (short)e.KeyCode);

        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            rmtCtrlClient.ProcKeyMsg(KeyMsgCode.KeyUp, (short)e.KeyCode);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            rmtCtrlClient.ProcKeyMsg(KeyMsgCode.Char, (short)e.KeyChar);
        }

        //自定义按钮事件
        private void ButtonDown_GotFocus(object sender, EventArgs e)
        {
            PicBtn btn = (PicBtn)sender;
            if (!btn.Capture)//不是btndown
            {
                btnInput.Focus();
                return;
            }
            short keyCode = Convert.ToInt16((string)(btn.Tag));
            rmtCtrlClient.ProcKeyMsg(KeyMsgCode.KeyDown, keyCode);
        }

        private void ButtonUp_Click(object sender, EventArgs e)
        {
            short keyCode = Convert.ToInt16(((string)((PicBtn)sender).Tag));

            rmtCtrlClient.ProcKeyMsg(KeyMsgCode.KeyUp, keyCode);
            btnInput.Focus();
        }

        private short[] holdBtnKey = new short[4] { 17, 16, 18, 91 };
        private bool[] checkBtnHold = new bool[4] { false, false, false, false };
        private void ButtonHold_Click(object sender, EventArgs e)
        {
            PicBtn btn = (PicBtn)sender;
            short keyCode = Convert.ToInt16(((string)btn.Tag));
            int index = Array.IndexOf<short>(holdBtnKey, keyCode);
            if (!checkBtnHold[index])
            {
                rmtCtrlClient.ProcKeyMsg(KeyMsgCode.KeyDown, keyCode);
                btn.BackColor = btnInput.ForeColor;
                btn.ForeColor = btnInput.BackColor;
                checkBtnHold[index] = true;
            }
            else
            {
                rmtCtrlClient.ProcKeyMsg(KeyMsgCode.KeyUp, keyCode);
                btn.BackColor = btnInput.BackColor;
                btn.ForeColor = btnInput.ForeColor;
                checkBtnHold[index] = false;
            }
            btnInput.Focus();
        }

        //输入法面板
        private void btnSIP_Click(object sender, EventArgs e)
        {
            if (inputPanel1.Enabled)
                inputPanel1.Enabled = false;
            else
                inputPanel1.Enabled = true;

            btnInput.Focus();
        }

        //滑动面板消息
        private void ctrlBarSlide_MouseDown(object sender, MouseEventArgs e)
        {
            UIControl.PanelSlide(ctrlBar, (Control)sender, e, Direction.Left, 30);
        }

        private void tabPanel_MouseDown(object sender, MouseEventArgs e)
        {
            UIControl.PanelSlide(tabPanel, (Control)sender, e, Direction.Down, 30);
        }

        private void scrollbarSlide_MouseDown(object sender, MouseEventArgs e)
        {
            UIControl.PanelSlide(scrollbar, (Control)sender, e, Direction.Down, 30);
        }

        //文本框更新事件
        private void tbOption_LostFocus(object sender, EventArgs e)
        {
            try
            {
                //UIControl.rate = Convert.ToInt32(tbPanelMoveSpeed.Text);
                //UIControl.checkLength = Convert.ToInt32(tbCheckSize.Text);
                //UIControl.leaveSize = Convert.ToInt32(tbLeaveSize.Text);
            }
            catch { }
        }



        //滑动面板控制算法
        class UIControl
        {
            //DockStyle tempDock;
            static Control movedCtrl;
            static Point ctrlStartPt, mouseStartPt;
            static Direction locateddirection;
            static public int rate = 30;
            static public int checkLength = 30;
            static public int leaveSize = 30;
            static public void PanelSlide(Control ctrl, Control slideBlock, MouseEventArgs e, Direction locatedDirection, int Size)
            {
                locateddirection = locatedDirection;
                //leaveSize = Size;
                movedCtrl = ctrl;
                //tempDock = ctrl.Dock;
                ctrl.Dock = DockStyle.None;
                ctrlStartPt = ctrl.Location;
                mouseStartPt = slideBlock.PointToScreen(new Point(e.X, e.Y));
                slideBlock.MouseMove += new MouseEventHandler(slideBlock_MouseMove);
                slideBlock.MouseUp += new MouseEventHandler(slideBlock_MouseUp);
            }

            static void slideBlock_MouseMove(object sender, MouseEventArgs e)
            {
                Point curPt = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                //label3.Text = "current" + curPt.X + " " + curPt.Y;
                if (locateddirection == Direction.Up || locateddirection == Direction.Down)
                {
                    curPt.X = ctrlStartPt.X;
                    curPt.Y = ctrlStartPt.Y + curPt.Y - mouseStartPt.Y;
                }
                else
                {
                    curPt.X = ctrlStartPt.X + curPt.X - mouseStartPt.X;
                    curPt.Y = ctrlStartPt.Y;
                }
                movedCtrl.Location = curPt;
                movedCtrl.Parent.Refresh();
            }

            static void slideBlock_MouseUp(object sender, MouseEventArgs e)
            {
                ((Control)sender).MouseMove -= slideBlock_MouseMove;
                ((Control)sender).MouseUp -= slideBlock_MouseUp;
                //movedCtrl.Dock = tempDock;
                Point curMousePt = ((Control)sender).PointToScreen(new Point(e.X, e.Y));
                int length = 0;
                int mouseMoveLengthX = curMousePt.X - mouseStartPt.X;
                int mouseMoveLengthY = curMousePt.Y - mouseStartPt.Y;
                bool isVertical = true;
                Point goalPt = new Point();
                switch (locateddirection)
                {
                    case Direction.Up:
                        if ((mouseMoveLengthY > 0 && mouseMoveLengthY < checkLength)//下拉未成功
                            || (mouseMoveLengthY < 0 && -mouseMoveLengthY > checkLength))//上拉成功
                            goalPt.Y = 0 - movedCtrl.Height + leaveSize;//上收隐藏
                        else
                            goalPt.Y = 0;//下拉显示
                        length = goalPt.Y - movedCtrl.Location.Y;
                        isVertical = true;
                        break;

                    case Direction.Down:
                        if ((mouseMoveLengthY < 0 && -mouseMoveLengthY < checkLength)//上拉未成功
                            || (mouseMoveLengthY > 0 && mouseMoveLengthY > checkLength))//下拉成功
                            goalPt.Y = movedCtrl.Parent.Height - leaveSize;//下收隐藏
                        else
                            goalPt.Y = movedCtrl.Parent.Height - movedCtrl.Height;//上拉显示
                        length = goalPt.Y - movedCtrl.Location.Y;
                        isVertical = true;
                        break;

                    case Direction.Left:
                        if ((mouseMoveLengthX > 0 && mouseMoveLengthX < checkLength)//右拉未成功
                            || (mouseMoveLengthX < 0 && -mouseMoveLengthX > checkLength))//左拉成功
                            goalPt.X = 0 - movedCtrl.Width + leaveSize;//左收隐藏
                        else
                            goalPt.X = 0;//右拉显示
                        length = goalPt.X - movedCtrl.Location.X;
                        isVertical = false;
                        break;

                    case Direction.Right:
                        if ((mouseMoveLengthX < 0 && -mouseMoveLengthX < checkLength)//上拉未成功
                            || (mouseMoveLengthX > 0 && mouseMoveLengthX > checkLength))//下拉成功
                            goalPt.X = movedCtrl.Parent.Width - leaveSize;//下收隐藏
                        else
                            goalPt.X = movedCtrl.Parent.Width - movedCtrl.Width;//上拉显示
                        length = goalPt.X - movedCtrl.Location.X;
                        isVertical = false;
                        break;

                }

                controlAutoMove(movedCtrl, isVertical, length);
            }

            static void controlAutoMove(Control ctrl, bool isVertical, int length)
            {


                Point curPt = ctrl.Location;

                if (isVertical && length < 0)//往上走
                {
                    length = 0 - length;
                    while (length > 0)
                    {
                        curPt.Y -= rate;
                        length -= rate;
                        ctrl.Location = curPt;
                        ctrl.Parent.Refresh();
                    }
                    curPt.Y -= length;
                    ctrl.Location = curPt;
                    ctrl.Parent.Refresh();
                    return;
                }
                if (isVertical && length > 0)//往下走
                {

                    while (length > 0)
                    {
                        curPt.Y += rate;
                        length -= rate;
                        ctrl.Location = curPt;
                        ctrl.Parent.Refresh();
                    }
                    curPt.Y += length;
                    ctrl.Location = curPt;
                    ctrl.Parent.Refresh();
                    return;
                }
                if (!isVertical && length < 0)//往左走
                {
                    length = 0 - length;
                    while (length > 0)
                    {
                        curPt.X -= rate;
                        length -= rate;
                        ctrl.Location = curPt;
                        ctrl.Parent.Refresh();
                    }
                    curPt.X -= length;
                    ctrl.Location = curPt;
                    ctrl.Parent.Refresh();
                    return;
                }
                if (!isVertical && length > 0)//往右走
                {

                    while (length > 0)
                    {
                        curPt.X += rate;
                        length -= rate;
                        ctrl.Location = curPt;
                        ctrl.Parent.Refresh();
                    }
                    curPt.X += length;
                    ctrl.Location = curPt;
                    ctrl.Parent.Refresh();
                    return;
                }
            }
        }

        private void showDesktop_Click(object sender, EventArgs e)
        {
            if (checkBoxViewMode.Checked)
            {
                rmtCtrlClient.showDesktop(true);
                btnDragMode.Visible = true;
            }
            else
            {
                rmtCtrlClient.showDesktop(false);
                btnDragMode.Visible = false;
            }

        }
        //进入，退出拖拽模式
        public void btnDragMode_Click(object sender, EventArgs e)
        {
            if (rmtCtrlClient.dragMode())
                lableDrag.Visible = true;
            else lableDrag.Visible = false;
            btnInput.Focus();
        }

        private void scrollbar_MouseDown(object sender, MouseEventArgs e)
        {
            rmtCtrlClient.ProcScrollbarMsg(MouseMsgCode.MouseDown, e.X, e.Y);
        }

        private void scrollbar_MouseMove(object sender, MouseEventArgs e)
        {
            rmtCtrlClient.ProcScrollbarMsg(MouseMsgCode.MouseMove, e.X, e.Y);
        }

        private void scrollbar_MouseUp(object sender, MouseEventArgs e)
        {
            rmtCtrlClient.ProcScrollbarMsg(MouseMsgCode.MouseUp, e.X, e.Y);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDebug_Click(object sender, EventArgs e)
        {
            rmtCtrlClient.debug = true;
        }

        private void btnShowTablet_Click(object sender, EventArgs e)
        {
            rmtCtrlClient.showTablet();
        }

        private void btnRunMedia_Click(object sender, EventArgs e)
        {
            int ID= Convert.ToInt32((string)((PicBtn)sender).Tag);
            rmtCtrlClient.ProcCmdMsg(CmdMsgCode.RunMediaPlayer, ID, 0);
        }

        private void textBox1_GotFocus(object sender, EventArgs e)
        {
            inputPanel1.Enabled = true;
        }

    }
}