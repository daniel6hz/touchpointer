using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace PictureButton
{
    public partial class PicBtn : UserControl
    {
        public Image imageOriginal
        {
            get;
            set;
        }
        public Image imageBtnDown
        {
            get;
            set;
        }

        public string BtnText
        {
            set;
            get;
        }

        public Color color
        {
            set;
            get;
        }
        public Point TextLocation
        {
            get;
            set;
        }

        //private Image imgOrg;
        //private Image imgBtnDwn;
        private bool isBtnDown;

        public PicBtn()
        {
            //imageOriginal = Resource.fangde;
            //imageBtnDown = Resource.fangde_down;
            BtnText = "Button";
            this.InitializeComponent();
            color = Color.Black;
            
            TextLocation = new Point(this.Width / 2 - 4*BtnText.Length, this.Height / 2 - 9);
            //resizePic();
            isBtnDown = false;
        }

        protected override void OnResize(EventArgs e)
        {
            //resizePic();
            TextLocation = new Point(this.Width / 2 - 4 * BtnText.Length, this.Height / 2 - 9);
            base.OnResize(e);
        }

        private void resizePic()
        {
        //    imgOrg = new Bitmap(this.Size.Width, this.Size.Height);
        //    Graphics g = Graphics.FromImage(imgOrg);
        //    g.DrawImage(imageOriginal, new Rectangle(0, 0, imgOrg.Width, imgOrg.Height), new Rectangle(0, 0, imageOriginal.Width, imageOriginal.Height), GraphicsUnit.Pixel);

        //    imgBtnDwn = new Bitmap(this.Size.Width, this.Size.Height);
        //    g = Graphics.FromImage(imgBtnDwn);
        //    g.DrawImage(imageBtnDown, new Rectangle(0, 0, imgBtnDwn.Width, imgBtnDwn.Height), new Rectangle(0, 0, imageBtnDown.Width, imageBtnDown.Height), GraphicsUnit.Pixel);
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            if (imageBtnDown == null || imageOriginal == null)
                base.OnPaint(pe);
            else if(isBtnDown)
                pe.Graphics.DrawImage(imageBtnDown, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, 0, imageBtnDown.Width, imageBtnDown.Height), GraphicsUnit.Pixel);
            else
                pe.Graphics.DrawImage(imageOriginal, new Rectangle(0, 0, this.Width, this.Height), new Rectangle(0, 0, imageOriginal.Width, imageOriginal.Height), GraphicsUnit.Pixel);

            pe.Graphics.DrawString(this.BtnText, this.Font, new SolidBrush(this.color), TextLocation.X,TextLocation.Y);


            //if (isBtnDown)
            //    pe.Graphics.DrawImage(imgBtnDwn, 0, 0);
            //else
            //    pe.Graphics.DrawImage(imgOrg, 0, 0);
            //SolidBrush brush=new SolidBrush(this.color);
            //pe.Graphics.DrawString(this.BtnText, this.Font, brush, TextLocation.X,TextLocation.Y);
          

        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //e.Graphics.DrawImage(showedImage, 0, 0);
            base.OnPaintBackground(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            this.Focus();
            isBtnDown = true;
            this.Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnClick(EventArgs e)
        {
            this.Focus();
            isBtnDown = false;
            this.Invalidate();
            base.OnClick(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            isBtnDown = false;
            this.Invalidate();
            base.OnMouseUp(e);
        }


    }
}