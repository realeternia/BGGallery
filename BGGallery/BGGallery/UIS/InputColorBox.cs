using System;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class InputColorBox : UserControl
    {
        public Action<Color> OnCustomTextChanged;
        private int rowCount = 12;
        private int colCount = 18;
        private int cellWidth = 0;
        private int cellHeight = 0;
        private int selIdx;
        private Color old;

        public InputColorBox()
        {
            InitializeComponent();

            cellWidth = doubleBufferedPanel1.Width / colCount;
            cellHeight = doubleBufferedPanel1.Height / rowCount;
        }

        public void OnInit(Color c)
        {
            old = c;
        }

        private void doubleBufferedPanel1_Paint(object sender, PaintEventArgs e)
        {
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 6; z++)
                    {
                        // 生成相邻颜色
                        Color baseColor = Color.FromArgb(z * 33, x * 33, y * 33);

                        var myId = (x + (z % 3) * 6) + (y + z / 3 * 6) * colCount;
                        // 绘制颜色方块

                        var rect = new Rectangle((x + (z % 3) * 6) * cellWidth, (y + z / 3 * 6) * cellHeight, cellWidth-1, cellHeight-1);
                        e.Graphics.FillRectangle(new SolidBrush(baseColor), rect);
                        if (baseColor == old)
                            e.Graphics.DrawRectangle(Pens.Gold, rect);
                        if (myId == selIdx)
                            e.Graphics.DrawRectangle(Pens.White, rect);
                    }
                }
            }
        }


        private void doubleBufferedPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            var newIdx = (e.X / cellWidth) + (e.Y / cellHeight) * colCount;
            if(newIdx != selIdx)
            {
                selIdx = newIdx;
                doubleBufferedPanel1.Invalidate();
            }
        }

        private void doubleBufferedPanel1_MouseLeave(object sender, EventArgs e)
        {
            var newIdx = -1;
            if (newIdx != selIdx)
            {
                selIdx = newIdx;
                doubleBufferedPanel1.Invalidate();
            }
        }

        private void doubleBufferedPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (selIdx < 0)
                return;

            Color baseColor = Color.Black;
            for (int x = 0; x < 6; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    for (int z = 0; z < 6; z++)
                    {
                        var myId = (x + (z % 3) * 6) + (y + z / 3 * 6) * colCount;
                        if (myId == selIdx)
                        {
                            // 生成相邻颜色
                            baseColor = Color.FromArgb(z * 33, x * 33, y * 33);
                            break;
                        }
                    }
                }
            }

            if (OnCustomTextChanged != null)
                OnCustomTextChanged(baseColor);

            PanelManager.Instance.HideBlackPanel();
        }
    }
}
