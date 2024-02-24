using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS.Main
{
    public partial class UCListSelectBar : UserControl
    {
        [EditorBrowsable(EditorBrowsableState.Always)]
        public string TabNames { get; set; } // \n 分割

        public int SelectedIndex { get; set; }

        public Action<int> OnIndexChanged;

        private Rectangle[] regions;

        public UCListSelectBar()
        {
            InitializeComponent();

        }
        private void UCListSelectBar_Load(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(TabNames))
                return;
            var infos = TabNames.Split('|');
            regions = new Rectangle[infos.Length];
            for (int i = 0; i < infos.Length; i++)
                regions[i] = new Rectangle(10 + i * 95, 0, 90, Height);
        }

        private void UCListSelectBar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Gray, 0, Height - 5, Width, Height - 5);
            if (!string.IsNullOrEmpty(TabNames))
            {
                var infos = TabNames.Split('|');
                for (int i = 0; i < infos.Length; i++)
                {
                    var bounds = regions[i];

                    using (var b = new SolidBrush(i == SelectedIndex ? ForeColor : Color.Gray))
                    {
                        if (i < infos.Length)
                        {
                            var len = e.Graphics.MeasureString(infos[i], Font).Width;
                            e.Graphics.DrawString(infos[i], Font, b, bounds.Left + (bounds.Width - len) / 2, bounds.Top + 5);
                        }
                    }

                    if (i == SelectedIndex)
                    {
                        using (var pen = new Pen(Color.White, 2))
                            e.Graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 5, bounds.Right, bounds.Bottom - 5);
                    }
                }
            }

        }
        private void UCListSelectBar_MouseClick(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < regions.Length; i++)
            {
                if (regions[i].Contains(e.Location))
                {
                    SelectedIndex = i;
                    Invalidate();
                    if (OnIndexChanged != null)
                        OnIndexChanged(i);
                    break;  // 如果你只想处理一个区域，可以使用break
                }
            }
        }
    }
}
