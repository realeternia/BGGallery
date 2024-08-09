using BGGallery.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCEditImage : UserControl
    {
        public Action<Image> OnImageChanged;
        private Image editImg;
        private float ratio = 1;
        private bool mouseDrawing = false;
        private Point mouseStartPoint;
        private Rectangle mouseRectangle;

        public UCEditImage()
        {
            InitializeComponent();

            Panels.PanelBorders.InitBorder(this);
        }

        public void OnInit(Image img)
        {
            editImg = img;
            ratio = 1;
            mouseStartPoint = new Point();
            mouseRectangle = new Rectangle();
            UpdateSize();
        }

        private void UpdateSize()
        {
            labelSizeNow.Text = string.Format("{0:0} x {1:0}", editImg.Width * ratio, editImg.Height * ratio);
        }

        private void doubleBufferedPanel1_Paint(object sender, PaintEventArgs e)
        {
            Size clientSize = doubleBufferedPanel1.Size;
            var imgSize = new Size((int)(editImg.Width), (int)(editImg.Height));

            // 计算缩放比例
            float scale = Math.Min((float)clientSize.Width / imgSize.Width, (float)clientSize.Height / imgSize.Height);
            if (ratio > scale)
                ratio = scale;

            // 计算绘制的矩形
            int drawWidth = (int)(imgSize.Width * ratio);
            int drawHeight = (int)(imgSize.Height * ratio);
            int drawX = (clientSize.Width - drawWidth) / 2;
            int drawY = (clientSize.Height - drawHeight) / 2;

            e.Graphics.DrawImage(editImg, drawX, drawY, drawWidth, drawHeight);

            using (Pen pen = new Pen(Color.Yellow, 2))
                e.Graphics.DrawRectangle(pen, mouseRectangle);

            // 获取矩形右下角的坐标
            int right = mouseRectangle.Right + 1;
            int bottom = mouseRectangle.Bottom + 1;

            // 绘制宽度和高度
            string sizeText = $"({Math.Max(0,mouseRectangle.Width-4)}x{Math.Max(0,mouseRectangle.Height-4)})";
            e.Graphics.DrawString(sizeText, Font, Brushes.Yellow, right, bottom);
        }

        private void textBoxRatio_TextChanged(object sender, EventArgs e)
        {
            if (float.TryParse(textBoxRatio.Text, out var s))
            {
                if (s < 0.01 || s > 10)
                    return;

                ratio = s;
                UpdateSize();
                doubleBufferedPanel1.Invalidate();
            }
        }

        private void doubleBufferedPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDrawing = true;
            mouseStartPoint = e.Location;
        }

        private void doubleBufferedPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            // 鼠标移动时更新矩形
            if (mouseDrawing)
            {
                int width = e.X - mouseStartPoint.X;
                int height = e.Y - mouseStartPoint.Y;
                mouseRectangle = new Rectangle(mouseStartPoint.X, mouseStartPoint.Y, width, height);

                doubleBufferedPanel1.Invalidate(); // 强制重绘Panel
            }
        }

        private void doubleBufferedPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            // 鼠标松开时完成绘制
            mouseDrawing = false;
            doubleBufferedPanel1.Invalidate(); // 强制重绘Panel
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (OnImageChanged == null)
                return;

            if (mouseRectangle.X == 0 && mouseRectangle.Y == 0)
            {
                if (ratio == 1)
                {
                    OnImageChanged(editImg);
                    PanelManager.Instance.HideBlackPanel();
                    return;
                }
                OnImageChanged(ImageTool.Resize(editImg, (int)(editImg.Width * ratio), (int)(editImg.Height * ratio), false));
                PanelManager.Instance.HideBlackPanel();
                return;
            }

            // 截取Panel上的矩形区域
            Bitmap screenshot = new Bitmap(mouseRectangle.Width-4, mouseRectangle.Height-4);
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(doubleBufferedPanel1.PointToScreen(new Point(mouseRectangle.X+2, mouseRectangle.Y+2)), Point.Empty, new Size(mouseRectangle.Width-4, mouseRectangle.Height-4));
            }
            OnImageChanged(screenshot);
            Clipboard.SetImage(editImg); //还原图片，方便redo
            PanelManager.Instance.HideBlackPanel();
        }
    }
}
