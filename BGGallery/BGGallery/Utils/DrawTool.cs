using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BGGallery.Utils
{
    static class DrawTool
    {
        public static void FillRoundRectangle(this Graphics g, Brush brush, Rectangle r, float radius)
        {
            FillRoundRectangle(g, brush, r.X, r.Y, r.Width, r.Height, radius);
        }
        public static void FillRoundRectangle(this Graphics g, Brush brush, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath roundedRectangle = RoundedRectangle(rectangle, radius);
            g.FillPath(brush, roundedRectangle);
        }
        public static void DrawRoundRectangle(this Graphics g, Pen pen, Rectangle r, float radius)
        {
            DrawRoundRectangle(g, pen, r.X, r.Y, r.Width, r.Height, radius);
        }
        public static void DrawRoundRectangle(this Graphics g, Pen pen, float x, float y, float width, float height, float radius)
        {
            RectangleF rectangle = new RectangleF(x, y, width, height);
            GraphicsPath roundedRectangle = RoundedRectangle(rectangle, radius);
            g.DrawPath(pen, roundedRectangle);
        }

        public static GraphicsPath RoundedRectangle(RectangleF rectangle, float radius)
        {
            GraphicsPath path = new GraphicsPath();

            // 去掉圆角的锯齿
            path.FillMode = FillMode.Winding;

            float x = rectangle.X;
            float y = rectangle.Y;
            float width = rectangle.Width;
            float height = rectangle.Height;

            // 上
            path.AddLine(x + radius, y, x + width - radius, y);

            // 右上角
            path.AddArc(x + width - radius * 2, y, radius * 2, radius * 2, 270, 90);

            // 右
            path.AddLine(x + width, y + radius, x + width, y + height - radius);

            // 右下角
            path.AddArc(x + width - radius * 2, y + height - radius * 2, radius * 2, radius * 2, 0, 90);

            // 下
            path.AddLine(x + width - radius, y + height, x + radius, y + height);

            // 左下角
            path.AddArc(x, y + height - radius * 2, radius * 2, radius * 2, 90, 90);

            // 左
            path.AddLine(x, y + height - radius, x, y + radius);

            // 左上角
            path.AddArc(x, y, radius * 2, radius * 2, 180, 90);

            // 闭合路径
            path.CloseFigure();

            return path;
        }

        public static Brush GetTagBrush(string word, Brush defaultB = null)
        {
            switch(word)
            {
                case "存档": return Brushes.DarkRed;
                case "未分类": return Brushes.DimGray;
                case "未到货": return Brushes.Red;
                case "汇总": return Brushes.MediumPurple;
                case "加密": return Brushes.OrangeRed;

                case "美式": return Brushes.Brown;
                case "德式": return Brushes.DimGray;
                case "聚会": return Brushes.CadetBlue;
                case "卡牌": return Brushes.DarkOrange;
            }

            if (word.Contains("￥"))
                return Brushes.Green;

            if (word.StartsWith("2") && word.Length == 4 && int.TryParse(word, out _)) //year
                return Brushes.DeepPink;

            if (defaultB != null)
                return defaultB;

            return Brushes.DeepSkyBlue;
        }
    }
}
