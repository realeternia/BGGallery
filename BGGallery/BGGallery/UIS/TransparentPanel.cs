using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public class TransparentPanel : Panel
    {
        class CachedParms
        {
            public Bitmap BG { get; set; }
            public float Brightness { get; set; }
            public Control Control { get; set; }
        }

        private Bitmap BG;
        private float Brightness = 0.5f; // 控制亮度，1 为不变，大于 1 变亮，小于 1 变暗

        private Stack<CachedParms> caches = new Stack<CachedParms>();

        public TransparentPanel()
        {
            DoubleBuffered = true;

            this.Click += new System.EventHandler(this.TransparentPanel_Click);
        }

        public void SetUp(Control c, int rx, int ry, Bitmap bg, float bright)
        {
            if(Controls.Count > 0) //叠了
            {
                caches.Push(new CachedParms { BG = BG, Brightness = Brightness, Control = Controls[0] });
                Controls.Clear();
            }

            BG = bg;
            Brightness = bright;

            if (rx + ry == 0)
            {//自动居中
                rx = (Width - c.Width) / 2;
                ry = (Height - c.Height) / 2;
            }

            // 设置 labelControl 的位置
            c.Location = new Point(rx, ry);
            Controls.Add(c);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (BG == null)
                return;

            float[][] matrixItems ={
                    new float[] { Brightness, 0, 0, 0, 0},
                    new float[] {0, Brightness, 0, 0, 0},
                    new float[] {0, 0, Brightness, 0, 0},
                    new float[] {0, 0, 0, 1, 0}, // 不影响 Alpha 通道（透明度）
                    new float[] {0, 0, 0, 0, 1}
                };
            ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            e.Graphics.DrawImage(BG, new Rectangle(0, 0, Width, Height), 0, 0, Width, Height, GraphicsUnit.Pixel, imageAttr);
        }

        private void TransparentPanel_Click(object sender, System.EventArgs e)
        {
            HideAll();
        }

        public void HideAll()
        {
            Controls.Clear();

            if(caches.Count > 0)
            {
                var parm = caches.Pop();
                BG = parm.BG;
                Brightness = parm.Brightness;
                Controls.Add(parm.Control);
            }
            else
            {
                SendToBack();
            }
        }

    }
}
