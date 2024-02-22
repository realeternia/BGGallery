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

        public UCEditImage()
        {
            InitializeComponent();
        }

        public void OnInit(Image img)
        {
            editImg = img;

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

            if(!hideSelection)
            {
                using (Pen pen = new Pen(Color.Yellow, 2))
                    e.Graphics.DrawRectangle(pen, rectangle);

                // 获取矩形右下角的坐标
                int right = rectangle.Right + 1;
                int bottom = rectangle.Bottom + 1;

                // 绘制宽度和高度
                string sizeText = $"({rectangle.Width}x{rectangle.Height})";
                e.Graphics.DrawString(sizeText, Font, Brushes.Yellow, right, bottom);
            }
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

        private bool drawing = false;
        private Point startPoint;
        private Rectangle rectangle;
        private bool hideSelection;
        private void doubleBufferedPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            drawing = true;
            startPoint = e.Location;
        }

        private void doubleBufferedPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            // 鼠标移动时更新矩形
            if (drawing)
            {
                int width = e.X - startPoint.X;
                int height = e.Y - startPoint.Y;
                rectangle = new Rectangle(startPoint.X, startPoint.Y, width, height);

                doubleBufferedPanel1.Invalidate(); // 强制重绘Panel
            }
        }

        private void doubleBufferedPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            // 鼠标松开时完成绘制
            drawing = false;
            doubleBufferedPanel1.Invalidate(); // 强制重绘Panel
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (OnImageChanged == null)
                return;

            if (rectangle.X == 0 && rectangle.Y == 0)
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
            hideSelection = true;
            doubleBufferedPanel1.Invalidate();
            // 截取Panel上的矩形区域
            Bitmap screenshot = new Bitmap(rectangle.Width, rectangle.Height);
            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(doubleBufferedPanel1.PointToScreen(rectangle.Location), Point.Empty, rectangle.Size);
            }
            hideSelection = false;
            OnImageChanged(screenshot);
            PanelManager.Instance.HideBlackPanel();
        }
    }
}
