using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    class UCBGPropertyAttrItem : Label
    {
        private bool checked1;
        //private Image icon;
        private Color foreColor;
        private Color bgColor = Color.White;
        public bool Checked { get { return checked1; } set { checked1 = value; Invalidate(); } }

        public override string Text { get { return base.Text; } set { base.Text = value; CheckWords(value); Invalidate(); } }

        public UCBGPropertyAttrItem()
        {
            AutoSize = true;
            Click += UCBGPropertyAttrItem_Click;
        }

        private void CheckWords(string wrd)
        {
            // 定义颜色映射  
            Dictionary<string, Tuple<Color, Color>> colorMap = new Dictionary<string, Tuple<Color, Color>>
            {
                { "牌套", new Tuple<Color, Color>(Color.DimGray, Color.LightGray) },  
            };

            // 默认颜色  
            foreColor = Color.LawnGreen;
            bgColor = Color.White; // 假设默认背景色是白色  

            // 检查是否有匹配的颜色设置  
            if (colorMap.TryGetValue(wrd, out var colors))
            {
                foreColor = colors.Item1;
                bgColor = colors.Item2;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (checked1)
            {
                if (bgColor != Color.White)
                    using (var b = new SolidBrush(bgColor))
                        e.Graphics.FillRectangle(b, 0, 0, Width, Height);
                using (var b = new SolidBrush(foreColor))
                    e.Graphics.DrawString(Text, Font, b, 0, 0);
            }
            else
            {
                e.Graphics.DrawString(Text, Font, Brushes.DimGray, 0, 0);
            }
        }

        private void UCBGPropertyAttrItem_Click(object sender, EventArgs e)
        {
            checked1 = !checked1;
            Invalidate();
        }

    }
}
