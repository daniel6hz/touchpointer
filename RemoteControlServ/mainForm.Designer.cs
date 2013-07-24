namespace RemoteControl
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.BtnRemoteControl = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.rbtnBt = new System.Windows.Forms.RadioButton();
            this.rbtWifi = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // BtnRemoteControl
            // 
            this.BtnRemoteControl.Location = new System.Drawing.Point(12, 24);
            this.BtnRemoteControl.Name = "BtnRemoteControl";
            this.BtnRemoteControl.Size = new System.Drawing.Size(86, 23);
            this.BtnRemoteControl.TabIndex = 5;
            this.BtnRemoteControl.Text = "开启远程控制";
            this.BtnRemoteControl.UseVisualStyleBackColor = true;
            this.BtnRemoteControl.Click += new System.EventHandler(this.BtnRemoteControl_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // rbtnBt
            // 
            this.rbtnBt.AutoSize = true;
            this.rbtnBt.Checked = true;
            this.rbtnBt.Location = new System.Drawing.Point(148, 24);
            this.rbtnBt.Name = "rbtnBt";
            this.rbtnBt.Size = new System.Drawing.Size(77, 16);
            this.rbtnBt.TabIndex = 13;
            this.rbtnBt.TabStop = true;
            this.rbtnBt.Text = "Bluetooth";
            this.rbtnBt.UseVisualStyleBackColor = true;
            // 
            // rbtWifi
            // 
            this.rbtWifi.AutoSize = true;
            this.rbtWifi.Location = new System.Drawing.Point(148, 47);
            this.rbtWifi.Name = "rbtWifi";
            this.rbtWifi.Size = new System.Drawing.Size(47, 16);
            this.rbtWifi.TabIndex = 14;
            this.rbtWifi.Text = "WIFI";
            this.rbtWifi.UseVisualStyleBackColor = true;
            // 
            // mainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(249, 101);
            this.Controls.Add(this.rbtWifi);
            this.Controls.Add(this.rbtnBt);
            this.Controls.Add(this.BtnRemoteControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "mainForm";
            this.ShowInTaskbar = false;
            this.Text = "RemoteControl Beta1";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnRemoteControl;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.RadioButton rbtnBt;
        private System.Windows.Forms.RadioButton rbtWifi;
    }
}

