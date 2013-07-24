namespace RemoteControl
{
    partial class Tablet
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
            this.button1 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(200, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 20);
            this.button1.TabIndex = 0;
            this.button1.Text = "Close";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(220)))), ((int)(((byte)(233)))));
            this.btnClear.Location = new System.Drawing.Point(0, 300);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(38, 20);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Tablet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.button1);
            this.Location = new System.Drawing.Point(0, 0);
            this.MinimizeBox = false;
            this.Name = "Tablet";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Tablet_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Tablet_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClear;
    }
}