using System;
using System.Collections.Generic;
using System.Drawing;

namespace BGGallery.Utils
{
    class ImageTool
    {
        private static Dictionary<string, Bitmap> imgMap = new Dictionary<string, Bitmap>();

        public static Bitmap CreateSolidColorBitmap(Color color, int width, int height)
        {
            var colorName = string.Format("{0}_{1}x{2}", color.ToArgb(), width, height);
            if (imgMap.ContainsKey(colorName))
                return imgMap[colorName];

            // 创建一个位图
            Bitmap bitmap = new Bitmap(width, height);

            // 使用 Graphics 对象填充整个位图
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                // 使用指定颜色填充
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(color.R, color.G, color.B)))
                {
                    g.FillRectangle(brush, 0, 0, width, height);
                }
            }
            imgMap[colorName] = bitmap;
            return bitmap;
        }

        public static Bitmap Transparent2Color(Bitmap bmp1, Color bgColor, int width, int height)
        {
            Bitmap bmp2 = new Bitmap(width, height);
            Rectangle rect = new Rectangle(Point.Empty, bmp2.Size);
            using (Graphics G = Graphics.FromImage(bmp2))
            {
                G.Clear(bgColor);
                G.DrawImage(bmp1, rect, new Rectangle(0, 0, bmp1.Width, bmp1.Height), GraphicsUnit.Pixel);
            }
            return bmp2;
        }
    }
}
