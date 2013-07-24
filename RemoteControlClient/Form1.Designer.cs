namespace RemoteControl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ctrlBar = new System.Windows.Forms.Panel();
            this.picBtn5 = new PictureButton.PicBtn();
            this.btnShowTablet = new PictureButton.PicBtn();
            this.btnWin = new PictureButton.PicBtn();
            this.btnShift = new PictureButton.PicBtn();
            this.btnCtrl = new PictureButton.PicBtn();
            this.btnSIP = new PictureButton.PicBtn();
            this.btnDragMode = new PictureButton.PicBtn();
            this.tabPanel = new System.Windows.Forms.TabControl();
            this.tabDirection = new System.Windows.Forms.TabPage();
            this.picBtn4 = new PictureButton.PicBtn();
            this.btnDown = new PictureButton.PicBtn();
            this.button11 = new PictureButton.PicBtn();
            this.button10 = new PictureButton.PicBtn();
            this.button12 = new PictureButton.PicBtn();
            this.btnEnter = new PictureButton.PicBtn();
            this.btnRight = new PictureButton.PicBtn();
            this.btnUp = new PictureButton.PicBtn();
            this.btnLeft = new PictureButton.PicBtn();
            this.tabKey = new System.Windows.Forms.TabPage();
            this.picBtn3 = new PictureButton.PicBtn();
            this.button9 = new PictureButton.PicBtn();
            this.button17 = new PictureButton.PicBtn();
            this.button8 = new PictureButton.PicBtn();
            this.button16 = new PictureButton.PicBtn();
            this.button7 = new PictureButton.PicBtn();
            this.button15 = new PictureButton.PicBtn();
            this.button4 = new PictureButton.PicBtn();
            this.button14 = new PictureButton.PicBtn();
            this.button13 = new PictureButton.PicBtn();
            this.button1 = new PictureButton.PicBtn();
            this.tabMedia = new System.Windows.Forms.TabPage();
            this.picBtn2 = new PictureButton.PicBtn();
            this.btnRunMedia = new PictureButton.PicBtn();
            this.btPlay = new PictureButton.PicBtn();
            this.btNext = new PictureButton.PicBtn();
            this.button5 = new PictureButton.PicBtn();
            this.tbVolDn = new PictureButton.PicBtn();
            this.tbVolUp = new PictureButton.PicBtn();
            this.button6 = new PictureButton.PicBtn();
            this.btPre = new PictureButton.PicBtn();
            this.tabOption = new System.Windows.Forms.TabPage();
            this.picBtn1 = new PictureButton.PicBtn();
            this.btnExit = new PictureButton.PicBtn();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtnWifi = new System.Windows.Forms.RadioButton();
            this.rbtnBt = new System.Windows.Forms.RadioButton();
            this.checkBoxViewMode = new System.Windows.Forms.CheckBox();
            this.button2 = new PictureButton.PicBtn();
            this.btnInput = new System.Windows.Forms.Button();
            this.inputPanel1 = new Microsoft.WindowsCE.Forms.InputPanel(this.components);
            this.scrollbar = new System.Windows.Forms.Panel();
            this.scoreBarSlideBtn = new PictureButton.PicBtn();
            this.lableDrag = new System.Windows.Forms.Label();
            this.ctrlBar.SuspendLayout();
            this.tabPanel.SuspendLayout();
            this.tabDirection.SuspendLayout();
            this.tabKey.SuspendLayout();
            this.tabMedia.SuspendLayout();
            this.tabOption.SuspendLayout();
            this.scrollbar.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlBar
            // 
            this.ctrlBar.BackColor = System.Drawing.Color.Transparent;
            this.ctrlBar.Controls.Add(this.picBtn5);
            this.ctrlBar.Controls.Add(this.btnShowTablet);
            this.ctrlBar.Controls.Add(this.btnWin);
            this.ctrlBar.Controls.Add(this.btnShift);
            this.ctrlBar.Controls.Add(this.btnCtrl);
            this.ctrlBar.Controls.Add(this.btnSIP);
            this.ctrlBar.Location = new System.Drawing.Point(0, 0);
            this.ctrlBar.Name = "ctrlBar";
            this.ctrlBar.Size = new System.Drawing.Size(240, 40);
            this.ctrlBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrlBarSlide_MouseDown);
            // 
            // picBtn5
            // 
            this.picBtn5.BtnText = "";
            this.picBtn5.color = System.Drawing.Color.Black;
            this.picBtn5.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("picBtn5.imageBtnDown")));
            this.picBtn5.imageOriginal = ((System.Drawing.Image)(resources.GetObject("picBtn5.imageOriginal")));
            this.picBtn5.Location = new System.Drawing.Point(201, 0);
            this.picBtn5.Name = "picBtn5";
            this.picBtn5.Size = new System.Drawing.Size(39, 40);
            this.picBtn5.TabIndex = 28;
            this.picBtn5.TextLocation = new System.Drawing.Point(19, 11);
            this.picBtn5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ctrlBarSlide_MouseDown);
            // 
            // btnShowTablet
            // 
            this.btnShowTablet.BackColor = System.Drawing.Color.Transparent;
            this.btnShowTablet.BtnText = "tabt";
            this.btnShowTablet.color = System.Drawing.Color.Black;
            this.btnShowTablet.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnShowTablet.imageBtnDown")));
            this.btnShowTablet.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnShowTablet.imageOriginal")));
            this.btnShowTablet.Location = new System.Drawing.Point(120, 0);
            this.btnShowTablet.Name = "btnShowTablet";
            this.btnShowTablet.Size = new System.Drawing.Size(40, 40);
            this.btnShowTablet.TabIndex = 27;
            this.btnShowTablet.TextLocation = new System.Drawing.Point(8, 11);
            this.btnShowTablet.Click += new System.EventHandler(this.btnShowTablet_Click);
            // 
            // btnWin
            // 
            this.btnWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnWin.BackColor = System.Drawing.Color.Transparent;
            this.btnWin.BtnText = "Win";
            this.btnWin.color = System.Drawing.Color.Black;
            this.btnWin.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnWin.imageBtnDown")));
            this.btnWin.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnWin.imageOriginal")));
            this.btnWin.Location = new System.Drawing.Point(80, 0);
            this.btnWin.Name = "btnWin";
            this.btnWin.Size = new System.Drawing.Size(40, 40);
            this.btnWin.TabIndex = 0;
            this.btnWin.Tag = "91";
            this.btnWin.TextLocation = new System.Drawing.Point(8, 11);
            this.btnWin.Click += new System.EventHandler(this.ButtonHold_Click);
            // 
            // btnShift
            // 
            this.btnShift.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnShift.BackColor = System.Drawing.Color.Transparent;
            this.btnShift.BtnText = "Shift";
            this.btnShift.color = System.Drawing.Color.Black;
            this.btnShift.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnShift.imageBtnDown")));
            this.btnShift.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnShift.imageOriginal")));
            this.btnShift.Location = new System.Drawing.Point(40, 0);
            this.btnShift.Name = "btnShift";
            this.btnShift.Size = new System.Drawing.Size(40, 40);
            this.btnShift.TabIndex = 0;
            this.btnShift.Tag = "16";
            this.btnShift.TextLocation = new System.Drawing.Point(5, 11);
            this.btnShift.Click += new System.EventHandler(this.ButtonHold_Click);
            // 
            // btnCtrl
            // 
            this.btnCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnCtrl.BackColor = System.Drawing.Color.Transparent;
            this.btnCtrl.BtnText = "Ctrl";
            this.btnCtrl.color = System.Drawing.Color.Black;
            this.btnCtrl.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnCtrl.imageBtnDown")));
            this.btnCtrl.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnCtrl.imageOriginal")));
            this.btnCtrl.Location = new System.Drawing.Point(0, 0);
            this.btnCtrl.Name = "btnCtrl";
            this.btnCtrl.Size = new System.Drawing.Size(40, 40);
            this.btnCtrl.TabIndex = 0;
            this.btnCtrl.Tag = "17";
            this.btnCtrl.TextLocation = new System.Drawing.Point(9, 11);
            this.btnCtrl.Click += new System.EventHandler(this.ButtonHold_Click);
            // 
            // btnSIP
            // 
            this.btnSIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnSIP.BackColor = System.Drawing.Color.Transparent;
            this.btnSIP.BtnText = "SIP";
            this.btnSIP.color = System.Drawing.Color.Black;
            this.btnSIP.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnSIP.imageBtnDown")));
            this.btnSIP.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnSIP.imageOriginal")));
            this.btnSIP.Location = new System.Drawing.Point(160, 0);
            this.btnSIP.Name = "btnSIP";
            this.btnSIP.Size = new System.Drawing.Size(40, 40);
            this.btnSIP.TabIndex = 0;
            this.btnSIP.Tag = "";
            this.btnSIP.TextLocation = new System.Drawing.Point(8, 11);
            this.btnSIP.Click += new System.EventHandler(this.btnSIP_Click);
            // 
            // btnDragMode
            // 
            this.btnDragMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btnDragMode.BackColor = System.Drawing.Color.Transparent;
            this.btnDragMode.BtnText = "Drag";
            this.btnDragMode.color = System.Drawing.Color.Black;
            this.btnDragMode.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnDragMode.imageBtnDown")));
            this.btnDragMode.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnDragMode.imageOriginal")));
            this.btnDragMode.Location = new System.Drawing.Point(80, 0);
            this.btnDragMode.Name = "btnDragMode";
            this.btnDragMode.Size = new System.Drawing.Size(82, 21);
            this.btnDragMode.TabIndex = 0;
            this.btnDragMode.Tag = "";
            this.btnDragMode.TextLocation = new System.Drawing.Point(25, 1);
            this.btnDragMode.Visible = false;
            this.btnDragMode.Click += new System.EventHandler(this.btnDragMode_Click);
            // 
            // tabPanel
            // 
            this.tabPanel.Controls.Add(this.tabDirection);
            this.tabPanel.Controls.Add(this.tabKey);
            this.tabPanel.Controls.Add(this.tabMedia);
            this.tabPanel.Controls.Add(this.tabOption);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabPanel.Location = new System.Drawing.Point(0, 122);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.SelectedIndex = 0;
            this.tabPanel.Size = new System.Drawing.Size(240, 198);
            this.tabPanel.TabIndex = 1;
            // 
            // tabDirection
            // 
            this.tabDirection.BackColor = System.Drawing.Color.White;
            this.tabDirection.Controls.Add(this.picBtn4);
            this.tabDirection.Controls.Add(this.btnDown);
            this.tabDirection.Controls.Add(this.button11);
            this.tabDirection.Controls.Add(this.button10);
            this.tabDirection.Controls.Add(this.button12);
            this.tabDirection.Controls.Add(this.btnEnter);
            this.tabDirection.Controls.Add(this.btnRight);
            this.tabDirection.Controls.Add(this.btnUp);
            this.tabDirection.Controls.Add(this.btnLeft);
            this.tabDirection.Location = new System.Drawing.Point(0, 0);
            this.tabDirection.Name = "tabDirection";
            this.tabDirection.Size = new System.Drawing.Size(240, 175);
            this.tabDirection.Text = "Direction";
            // 
            // picBtn4
            // 
            this.picBtn4.BackColor = System.Drawing.Color.Transparent;
            this.picBtn4.BtnText = "";
            this.picBtn4.color = System.Drawing.Color.Black;
            this.picBtn4.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("picBtn4.imageBtnDown")));
            this.picBtn4.imageOriginal = ((System.Drawing.Image)(resources.GetObject("picBtn4.imageOriginal")));
            this.picBtn4.Location = new System.Drawing.Point(0, 0);
            this.picBtn4.Name = "picBtn4";
            this.picBtn4.Size = new System.Drawing.Size(243, 25);
            this.picBtn4.TabIndex = 26;
            this.picBtn4.TextLocation = new System.Drawing.Point(97, 3);
            this.picBtn4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPanel_MouseDown);
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDown.BtnText = "↓";
            this.btnDown.color = System.Drawing.Color.Black;
            this.btnDown.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnDown.imageBtnDown")));
            this.btnDown.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnDown.imageOriginal")));
            this.btnDown.Location = new System.Drawing.Point(83, 102);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(65, 65);
            this.btnDown.TabIndex = 0;
            this.btnDown.Tag = "40";
            this.btnDown.TextLocation = new System.Drawing.Point(28, 23);
            this.btnDown.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btnDown.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.Transparent;
            this.button11.BtnText = "PageU";
            this.button11.color = System.Drawing.Color.Black;
            this.button11.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button11.imageBtnDown")));
            this.button11.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button11.imageOriginal")));
            this.button11.Location = new System.Drawing.Point(12, 31);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(65, 33);
            this.button11.TabIndex = 0;
            this.button11.Tag = "33";
            this.button11.TextLocation = new System.Drawing.Point(17, 7);
            this.button11.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button11.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Transparent;
            this.button10.BtnText = "PageD";
            this.button10.color = System.Drawing.Color.Black;
            this.button10.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button10.imageBtnDown")));
            this.button10.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button10.imageOriginal")));
            this.button10.Location = new System.Drawing.Point(12, 63);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(65, 33);
            this.button10.TabIndex = 0;
            this.button10.Tag = "34";
            this.button10.TextLocation = new System.Drawing.Point(17, 7);
            this.button10.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button10.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.Transparent;
            this.button12.BtnText = "Back";
            this.button12.color = System.Drawing.Color.Black;
            this.button12.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button12.imageBtnDown")));
            this.button12.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button12.imageOriginal")));
            this.button12.Location = new System.Drawing.Point(154, 31);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(65, 33);
            this.button12.TabIndex = 0;
            this.button12.Tag = "8";
            this.button12.TextLocation = new System.Drawing.Point(20, 7);
            this.button12.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button12.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // btnEnter
            // 
            this.btnEnter.BackColor = System.Drawing.Color.Transparent;
            this.btnEnter.BtnText = "Enter";
            this.btnEnter.color = System.Drawing.Color.Black;
            this.btnEnter.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnEnter.imageBtnDown")));
            this.btnEnter.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnEnter.imageOriginal")));
            this.btnEnter.Location = new System.Drawing.Point(154, 63);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(65, 33);
            this.btnEnter.TabIndex = 0;
            this.btnEnter.Tag = "13";
            this.btnEnter.TextLocation = new System.Drawing.Point(17, 7);
            this.btnEnter.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btnEnter.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // btnRight
            // 
            this.btnRight.BackColor = System.Drawing.Color.Transparent;
            this.btnRight.BtnText = "→";
            this.btnRight.color = System.Drawing.Color.Black;
            this.btnRight.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnRight.imageBtnDown")));
            this.btnRight.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnRight.imageOriginal")));
            this.btnRight.Location = new System.Drawing.Point(154, 102);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(65, 65);
            this.btnRight.TabIndex = 0;
            this.btnRight.Tag = "39";
            this.btnRight.TextLocation = new System.Drawing.Point(28, 23);
            this.btnRight.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btnRight.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Transparent;
            this.btnUp.BtnText = "↑";
            this.btnUp.color = System.Drawing.Color.Black;
            this.btnUp.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnUp.imageBtnDown")));
            this.btnUp.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnUp.imageOriginal")));
            this.btnUp.Location = new System.Drawing.Point(83, 31);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(65, 65);
            this.btnUp.TabIndex = 0;
            this.btnUp.Tag = "38";
            this.btnUp.TextLocation = new System.Drawing.Point(28, 23);
            this.btnUp.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btnUp.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // btnLeft
            // 
            this.btnLeft.BackColor = System.Drawing.Color.Transparent;
            this.btnLeft.BtnText = "←";
            this.btnLeft.color = System.Drawing.Color.Black;
            this.btnLeft.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnLeft.imageBtnDown")));
            this.btnLeft.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnLeft.imageOriginal")));
            this.btnLeft.Location = new System.Drawing.Point(12, 102);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(65, 65);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.Tag = "37";
            this.btnLeft.TextLocation = new System.Drawing.Point(28, 23);
            this.btnLeft.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btnLeft.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // tabKey
            // 
            this.tabKey.BackColor = System.Drawing.Color.White;
            this.tabKey.Controls.Add(this.picBtn3);
            this.tabKey.Controls.Add(this.button9);
            this.tabKey.Controls.Add(this.button17);
            this.tabKey.Controls.Add(this.button8);
            this.tabKey.Controls.Add(this.button16);
            this.tabKey.Controls.Add(this.button7);
            this.tabKey.Controls.Add(this.button15);
            this.tabKey.Controls.Add(this.button4);
            this.tabKey.Controls.Add(this.button14);
            this.tabKey.Controls.Add(this.button13);
            this.tabKey.Controls.Add(this.button1);
            this.tabKey.Location = new System.Drawing.Point(0, 0);
            this.tabKey.Name = "tabKey";
            this.tabKey.Size = new System.Drawing.Size(232, 172);
            this.tabKey.Text = "Key";
            // 
            // picBtn3
            // 
            this.picBtn3.BackColor = System.Drawing.Color.Transparent;
            this.picBtn3.BtnText = "";
            this.picBtn3.color = System.Drawing.Color.Black;
            this.picBtn3.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("picBtn3.imageBtnDown")));
            this.picBtn3.imageOriginal = ((System.Drawing.Image)(resources.GetObject("picBtn3.imageOriginal")));
            this.picBtn3.Location = new System.Drawing.Point(0, 0);
            this.picBtn3.Name = "picBtn3";
            this.picBtn3.Size = new System.Drawing.Size(243, 25);
            this.picBtn3.TabIndex = 27;
            this.picBtn3.TextLocation = new System.Drawing.Point(97, 3);
            this.picBtn3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPanel_MouseDown);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Transparent;
            this.button9.BtnText = "ESC";
            this.button9.color = System.Drawing.Color.Black;
            this.button9.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button9.imageBtnDown")));
            this.button9.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button9.imageOriginal")));
            this.button9.Location = new System.Drawing.Point(7, 76);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(41, 42);
            this.button9.TabIndex = 2;
            this.button9.Tag = "27";
            this.button9.TextLocation = new System.Drawing.Point(8, 12);
            this.button9.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button9.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button17
            // 
            this.button17.BackColor = System.Drawing.Color.Transparent;
            this.button17.BtnText = "End";
            this.button17.color = System.Drawing.Color.Black;
            this.button17.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button17.imageBtnDown")));
            this.button17.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button17.imageOriginal")));
            this.button17.Location = new System.Drawing.Point(101, 77);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(42, 42);
            this.button17.TabIndex = 2;
            this.button17.Tag = "23";
            this.button17.TextLocation = new System.Drawing.Point(12, 12);
            this.button17.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button17.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.Transparent;
            this.button8.BtnText = "Home";
            this.button8.color = System.Drawing.Color.Black;
            this.button8.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button8.imageBtnDown")));
            this.button8.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button8.imageOriginal")));
            this.button8.Location = new System.Drawing.Point(53, 77);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(42, 42);
            this.button8.TabIndex = 2;
            this.button8.Tag = "24";
            this.button8.TextLocation = new System.Drawing.Point(5, 12);
            this.button8.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button8.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button16
            // 
            this.button16.BackColor = System.Drawing.Color.Transparent;
            this.button16.BtnText = "F4";
            this.button16.color = System.Drawing.Color.Black;
            this.button16.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button16.imageBtnDown")));
            this.button16.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button16.imageOriginal")));
            this.button16.Location = new System.Drawing.Point(149, 125);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(42, 42);
            this.button16.TabIndex = 2;
            this.button16.Tag = "115";
            this.button16.TextLocation = new System.Drawing.Point(13, 12);
            this.button16.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button16.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Transparent;
            this.button7.BtnText = "Del";
            this.button7.color = System.Drawing.Color.Black;
            this.button7.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button7.imageBtnDown")));
            this.button7.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button7.imageOriginal")));
            this.button7.Location = new System.Drawing.Point(53, 28);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(42, 42);
            this.button7.TabIndex = 2;
            this.button7.Tag = "46";
            this.button7.TextLocation = new System.Drawing.Point(12, 12);
            this.button7.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button7.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button15
            // 
            this.button15.BackColor = System.Drawing.Color.Transparent;
            this.button15.BtnText = "F3";
            this.button15.color = System.Drawing.Color.Black;
            this.button15.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button15.imageBtnDown")));
            this.button15.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button15.imageOriginal")));
            this.button15.Location = new System.Drawing.Point(101, 125);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(42, 42);
            this.button15.TabIndex = 2;
            this.button15.Tag = "114";
            this.button15.TextLocation = new System.Drawing.Point(13, 12);
            this.button15.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button15.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BtnText = "Snap";
            this.button4.color = System.Drawing.Color.Black;
            this.button4.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button4.imageBtnDown")));
            this.button4.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button4.imageOriginal")));
            this.button4.Location = new System.Drawing.Point(101, 28);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(42, 42);
            this.button4.TabIndex = 2;
            this.button4.Tag = "44";
            this.button4.TextLocation = new System.Drawing.Point(5, 12);
            this.button4.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button4.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button14
            // 
            this.button14.BackColor = System.Drawing.Color.Transparent;
            this.button14.BtnText = "F2";
            this.button14.color = System.Drawing.Color.Black;
            this.button14.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button14.imageBtnDown")));
            this.button14.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button14.imageOriginal")));
            this.button14.Location = new System.Drawing.Point(54, 125);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(41, 42);
            this.button14.TabIndex = 2;
            this.button14.Tag = "113";
            this.button14.TextLocation = new System.Drawing.Point(12, 12);
            this.button14.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button14.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Transparent;
            this.button13.BtnText = "F1";
            this.button13.color = System.Drawing.Color.Black;
            this.button13.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button13.imageBtnDown")));
            this.button13.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button13.imageOriginal")));
            this.button13.Location = new System.Drawing.Point(7, 125);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(41, 42);
            this.button13.TabIndex = 2;
            this.button13.Tag = "112";
            this.button13.TextLocation = new System.Drawing.Point(12, 12);
            this.button13.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button13.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BtnText = "Tab";
            this.button1.color = System.Drawing.Color.Black;
            this.button1.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button1.imageBtnDown")));
            this.button1.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button1.imageOriginal")));
            this.button1.Location = new System.Drawing.Point(7, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 42);
            this.button1.TabIndex = 2;
            this.button1.Tag = "9";
            this.button1.TextLocation = new System.Drawing.Point(11, 12);
            this.button1.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button1.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // tabMedia
            // 
            this.tabMedia.BackColor = System.Drawing.Color.White;
            this.tabMedia.Controls.Add(this.picBtn2);
            this.tabMedia.Controls.Add(this.btnRunMedia);
            this.tabMedia.Controls.Add(this.btPlay);
            this.tabMedia.Controls.Add(this.btNext);
            this.tabMedia.Controls.Add(this.button5);
            this.tabMedia.Controls.Add(this.tbVolDn);
            this.tabMedia.Controls.Add(this.tbVolUp);
            this.tabMedia.Controls.Add(this.button6);
            this.tabMedia.Controls.Add(this.btPre);
            this.tabMedia.Location = new System.Drawing.Point(0, 0);
            this.tabMedia.Name = "tabMedia";
            this.tabMedia.Size = new System.Drawing.Size(232, 172);
            this.tabMedia.Text = "Media";
            // 
            // picBtn2
            // 
            this.picBtn2.BackColor = System.Drawing.Color.Transparent;
            this.picBtn2.BtnText = "";
            this.picBtn2.color = System.Drawing.Color.Black;
            this.picBtn2.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("picBtn2.imageBtnDown")));
            this.picBtn2.imageOriginal = ((System.Drawing.Image)(resources.GetObject("picBtn2.imageOriginal")));
            this.picBtn2.Location = new System.Drawing.Point(0, 0);
            this.picBtn2.Name = "picBtn2";
            this.picBtn2.Size = new System.Drawing.Size(243, 25);
            this.picBtn2.TabIndex = 25;
            this.picBtn2.TextLocation = new System.Drawing.Point(97, 3);
            this.picBtn2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPanel_MouseDown);
            // 
            // btnRunMedia
            // 
            this.btnRunMedia.BackColor = System.Drawing.Color.Transparent;
            this.btnRunMedia.BtnText = "Run Player";
            this.btnRunMedia.color = System.Drawing.Color.Black;
            this.btnRunMedia.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnRunMedia.imageBtnDown")));
            this.btnRunMedia.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnRunMedia.imageOriginal")));
            this.btnRunMedia.Location = new System.Drawing.Point(61, 150);
            this.btnRunMedia.Name = "btnRunMedia";
            this.btnRunMedia.Size = new System.Drawing.Size(106, 20);
            this.btnRunMedia.TabIndex = 4;
            this.btnRunMedia.Tag = "0";
            this.btnRunMedia.TextLocation = new System.Drawing.Point(23, 1);
            this.btnRunMedia.Click += new System.EventHandler(this.btnRunMedia_Click);
            // 
            // btPlay
            // 
            this.btPlay.BackColor = System.Drawing.Color.Transparent;
            this.btPlay.BtnText = "";
            this.btPlay.color = System.Drawing.Color.Black;
            this.btPlay.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btPlay.imageBtnDown")));
            this.btPlay.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btPlay.imageOriginal")));
            this.btPlay.Location = new System.Drawing.Point(117, 94);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(50, 50);
            this.btPlay.TabIndex = 3;
            this.btPlay.Tag = "179";
            this.btPlay.TextLocation = new System.Drawing.Point(5, 16);
            this.btPlay.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btPlay.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // btNext
            // 
            this.btNext.BackColor = System.Drawing.Color.Transparent;
            this.btNext.BtnText = "";
            this.btNext.color = System.Drawing.Color.Black;
            this.btNext.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btNext.imageBtnDown")));
            this.btNext.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btNext.imageOriginal")));
            this.btNext.Location = new System.Drawing.Point(171, 94);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(50, 50);
            this.btNext.TabIndex = 2;
            this.btNext.Tag = "176";
            this.btNext.TextLocation = new System.Drawing.Point(5, 16);
            this.btNext.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btNext.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BtnText = "";
            this.button5.color = System.Drawing.Color.Black;
            this.button5.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button5.imageBtnDown")));
            this.button5.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button5.imageOriginal")));
            this.button5.Location = new System.Drawing.Point(33, 38);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(46, 50);
            this.button5.TabIndex = 1;
            this.button5.Tag = "174";
            this.button5.TextLocation = new System.Drawing.Point(3, 16);
            this.button5.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button5.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // tbVolDn
            // 
            this.tbVolDn.BackColor = System.Drawing.Color.Transparent;
            this.tbVolDn.BtnText = "";
            this.tbVolDn.color = System.Drawing.Color.Black;
            this.tbVolDn.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("tbVolDn.imageBtnDown")));
            this.tbVolDn.imageOriginal = ((System.Drawing.Image)(resources.GetObject("tbVolDn.imageOriginal")));
            this.tbVolDn.Location = new System.Drawing.Point(89, 38);
            this.tbVolDn.Name = "tbVolDn";
            this.tbVolDn.Size = new System.Drawing.Size(50, 50);
            this.tbVolDn.TabIndex = 1;
            this.tbVolDn.Tag = "173";
            this.tbVolDn.TextLocation = new System.Drawing.Point(5, 16);
            this.tbVolDn.Click += new System.EventHandler(this.ButtonUp_Click);
            this.tbVolDn.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // tbVolUp
            // 
            this.tbVolUp.BackColor = System.Drawing.Color.Transparent;
            this.tbVolUp.BtnText = "";
            this.tbVolUp.color = System.Drawing.Color.Black;
            this.tbVolUp.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("tbVolUp.imageBtnDown")));
            this.tbVolUp.imageOriginal = ((System.Drawing.Image)(resources.GetObject("tbVolUp.imageOriginal")));
            this.tbVolUp.Location = new System.Drawing.Point(146, 38);
            this.tbVolUp.Name = "tbVolUp";
            this.tbVolUp.Size = new System.Drawing.Size(50, 50);
            this.tbVolUp.TabIndex = 1;
            this.tbVolUp.Tag = "175";
            this.tbVolUp.TextLocation = new System.Drawing.Point(5, 16);
            this.tbVolUp.Click += new System.EventHandler(this.ButtonUp_Click);
            this.tbVolUp.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Transparent;
            this.button6.BtnText = "";
            this.button6.color = System.Drawing.Color.Black;
            this.button6.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button6.imageBtnDown")));
            this.button6.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button6.imageOriginal")));
            this.button6.Location = new System.Drawing.Point(61, 94);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(50, 50);
            this.button6.TabIndex = 1;
            this.button6.Tag = "178";
            this.button6.TextLocation = new System.Drawing.Point(5, 16);
            this.button6.Click += new System.EventHandler(this.ButtonUp_Click);
            this.button6.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // btPre
            // 
            this.btPre.BackColor = System.Drawing.Color.Transparent;
            this.btPre.BtnText = "";
            this.btPre.color = System.Drawing.Color.Black;
            this.btPre.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btPre.imageBtnDown")));
            this.btPre.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btPre.imageOriginal")));
            this.btPre.Location = new System.Drawing.Point(7, 94);
            this.btPre.Name = "btPre";
            this.btPre.Size = new System.Drawing.Size(50, 50);
            this.btPre.TabIndex = 1;
            this.btPre.Tag = "177";
            this.btPre.TextLocation = new System.Drawing.Point(5, 16);
            this.btPre.Click += new System.EventHandler(this.ButtonUp_Click);
            this.btPre.GotFocus += new System.EventHandler(this.ButtonDown_GotFocus);
            // 
            // tabOption
            // 
            this.tabOption.BackColor = System.Drawing.Color.White;
            this.tabOption.Controls.Add(this.picBtn1);
            this.tabOption.Controls.Add(this.btnExit);
            this.tabOption.Controls.Add(this.textBox2);
            this.tabOption.Controls.Add(this.textBox1);
            this.tabOption.Controls.Add(this.label2);
            this.tabOption.Controls.Add(this.label1);
            this.tabOption.Controls.Add(this.rbtnWifi);
            this.tabOption.Controls.Add(this.rbtnBt);
            this.tabOption.Controls.Add(this.checkBoxViewMode);
            this.tabOption.Controls.Add(this.button2);
            this.tabOption.Location = new System.Drawing.Point(0, 0);
            this.tabOption.Name = "tabOption";
            this.tabOption.Size = new System.Drawing.Size(240, 175);
            this.tabOption.Text = "Option";
            // 
            // picBtn1
            // 
            this.picBtn1.BackColor = System.Drawing.Color.Transparent;
            this.picBtn1.BtnText = "";
            this.picBtn1.color = System.Drawing.Color.Black;
            this.picBtn1.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("picBtn1.imageBtnDown")));
            this.picBtn1.imageOriginal = ((System.Drawing.Image)(resources.GetObject("picBtn1.imageOriginal")));
            this.picBtn1.Location = new System.Drawing.Point(0, 0);
            this.picBtn1.Name = "picBtn1";
            this.picBtn1.Size = new System.Drawing.Size(243, 25);
            this.picBtn1.TabIndex = 26;
            this.picBtn1.TextLocation = new System.Drawing.Point(97, 3);
            this.picBtn1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tabPanel_MouseDown);
            // 
            // btnExit
            // 
            this.btnExit.BtnText = "Exit";
            this.btnExit.color = System.Drawing.Color.Black;
            this.btnExit.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("btnExit.imageBtnDown")));
            this.btnExit.imageOriginal = ((System.Drawing.Image)(resources.GetObject("btnExit.imageOriginal")));
            this.btnExit.Location = new System.Drawing.Point(194, 155);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(44, 20);
            this.btnExit.TabIndex = 16;
            this.btnExit.TextLocation = new System.Drawing.Point(8, 1);
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(164, 25);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(48, 21);
            this.textBox2.TabIndex = 21;
            this.textBox2.Text = "1988";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 21;
            this.textBox1.Text = "169.254.189.65";
            this.textBox1.GotFocus += new System.EventHandler(this.textBox1_GotFocus);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(140, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 20);
            this.label2.Text = "EP:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 20);
            this.label1.Text = "IP:";
            // 
            // rbtnWifi
            // 
            this.rbtnWifi.Location = new System.Drawing.Point(18, 49);
            this.rbtnWifi.Name = "rbtnWifi";
            this.rbtnWifi.Size = new System.Drawing.Size(51, 20);
            this.rbtnWifi.TabIndex = 18;
            this.rbtnWifi.TabStop = false;
            this.rbtnWifi.Text = "WIFI";
            // 
            // rbtnBt
            // 
            this.rbtnBt.Checked = true;
            this.rbtnBt.Location = new System.Drawing.Point(18, 69);
            this.rbtnBt.Name = "rbtnBt";
            this.rbtnBt.Size = new System.Drawing.Size(82, 20);
            this.rbtnBt.TabIndex = 17;
            this.rbtnBt.Text = "Bluetooth";
            // 
            // checkBoxViewMode
            // 
            this.checkBoxViewMode.Location = new System.Drawing.Point(3, 152);
            this.checkBoxViewMode.Name = "checkBoxViewMode";
            this.checkBoxViewMode.Size = new System.Drawing.Size(100, 20);
            this.checkBoxViewMode.TabIndex = 12;
            this.checkBoxViewMode.Text = "ViewMode";
            this.checkBoxViewMode.Click += new System.EventHandler(this.showDesktop_Click);
            // 
            // button2
            // 
            this.button2.BtnText = "connect";
            this.button2.color = System.Drawing.Color.Black;
            this.button2.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("button2.imageBtnDown")));
            this.button2.imageOriginal = ((System.Drawing.Image)(resources.GetObject("button2.imageOriginal")));
            this.button2.Location = new System.Drawing.Point(18, 95);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(62, 20);
            this.button2.TabIndex = 0;
            this.button2.TextLocation = new System.Drawing.Point(5, 1);
            this.button2.Click += new System.EventHandler(this.BtnConnect_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(0, 0);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(0, 0);
            this.btnInput.TabIndex = 3;
            this.btnInput.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.btnInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.btnInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            // 
            // scrollbar
            // 
            this.scrollbar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollbar.BackColor = System.Drawing.Color.Gainsboro;
            this.scrollbar.Controls.Add(this.scoreBarSlideBtn);
            this.scrollbar.Location = new System.Drawing.Point(207, 0);
            this.scrollbar.Name = "scrollbar";
            this.scrollbar.Size = new System.Drawing.Size(33, 320);
            this.scrollbar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.scrollbar_MouseMove);
            this.scrollbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollbar_MouseDown);
            this.scrollbar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scrollbar_MouseUp);
            // 
            // scoreBarSlideBtn
            // 
            this.scoreBarSlideBtn.BtnText = "";
            this.scoreBarSlideBtn.color = System.Drawing.Color.Black;
            this.scoreBarSlideBtn.imageBtnDown = ((System.Drawing.Image)(resources.GetObject("scoreBarSlideBtn.imageBtnDown")));
            this.scoreBarSlideBtn.imageOriginal = ((System.Drawing.Image)(resources.GetObject("scoreBarSlideBtn.imageOriginal")));
            this.scoreBarSlideBtn.Location = new System.Drawing.Point(0, 0);
            this.scoreBarSlideBtn.Name = "scoreBarSlideBtn";
            this.scoreBarSlideBtn.Size = new System.Drawing.Size(33, 33);
            this.scoreBarSlideBtn.TabIndex = 1;
            this.scoreBarSlideBtn.TextLocation = new System.Drawing.Point(16, 7);
            this.scoreBarSlideBtn.MouseDown += new System.Windows.Forms.MouseEventHandler(this.scrollbarSlide_MouseDown);
            // 
            // lableDrag
            // 
            this.lableDrag.BackColor = System.Drawing.Color.Transparent;
            this.lableDrag.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lableDrag.ForeColor = System.Drawing.Color.DimGray;
            this.lableDrag.Location = new System.Drawing.Point(68, 40);
            this.lableDrag.Name = "lableDrag";
            this.lableDrag.Size = new System.Drawing.Size(89, 20);
            this.lableDrag.Text = "DragMode!";
            this.lableDrag.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(177)))), ((int)(((byte)(228)))));
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.scrollbar);
            this.Controls.Add(this.ctrlBar);
            this.Controls.Add(this.lableDrag);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnDragMode);
            this.Controls.Add(this.tabPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(0, 0);
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.ctrlBar.ResumeLayout(false);
            this.tabPanel.ResumeLayout(false);
            this.tabDirection.ResumeLayout(false);
            this.tabKey.ResumeLayout(false);
            this.tabMedia.ResumeLayout(false);
            this.tabOption.ResumeLayout(false);
            this.scrollbar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ctrlBar;
        private PictureButton.PicBtn btnCtrl;
        public PictureButton.PicBtn btnDragMode;
        private PictureButton.PicBtn btnShift;
        private PictureButton.PicBtn btnSIP;
        private PictureButton.PicBtn btnWin;
        private System.Windows.Forms.TabControl tabPanel;
        private System.Windows.Forms.TabPage tabDirection;
        private System.Windows.Forms.TabPage tabOption;
        private PictureButton.PicBtn btnDown;
        private PictureButton.PicBtn btnEnter;
        private PictureButton.PicBtn btnRight;
        private PictureButton.PicBtn btnUp;
        private PictureButton.PicBtn btnLeft;
        private PictureButton.PicBtn button2;
        private System.Windows.Forms.Button btnInput;
        private Microsoft.WindowsCE.Forms.InputPanel inputPanel1;
        private System.Windows.Forms.Panel scrollbar;
        private System.Windows.Forms.TabPage tabMedia;
        private PictureButton.PicBtn btPlay;
        private PictureButton.PicBtn btNext;
        private PictureButton.PicBtn btPre;
        private System.Windows.Forms.TabPage tabKey;
        private PictureButton.PicBtn tbVolDn;
        private PictureButton.PicBtn tbVolUp;
        private PictureButton.PicBtn button1;
        private PictureButton.PicBtn button4;
        private PictureButton.PicBtn button5;
        private PictureButton.PicBtn button6;
        private PictureButton.PicBtn button9;
        private PictureButton.PicBtn button8;
        private PictureButton.PicBtn button7;
        private PictureButton.PicBtn button11;
        private PictureButton.PicBtn button10;
        private PictureButton.PicBtn button12;
        private PictureButton.PicBtn button16;
        private PictureButton.PicBtn button15;
        private PictureButton.PicBtn button14;
        private PictureButton.PicBtn button13;
        private PictureButton.PicBtn button17;
        private System.Windows.Forms.CheckBox checkBoxViewMode;
        public System.Windows.Forms.Label lableDrag;
        private PictureButton.PicBtn btnExit;
        private System.Windows.Forms.RadioButton rbtnBt;
        private System.Windows.Forms.RadioButton rbtnWifi;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private PictureButton.PicBtn btnShowTablet;
        private PictureButton.PicBtn btnRunMedia;
        private PictureButton.PicBtn picBtn4;
        private PictureButton.PicBtn picBtn3;
        private PictureButton.PicBtn picBtn2;
        private PictureButton.PicBtn picBtn1;
        private PictureButton.PicBtn scoreBarSlideBtn;
        private PictureButton.PicBtn picBtn5;
    }
}

