using BGGallery.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery
{
    public partial class UCSettingItem : UserControl
    {
        private bool isSelected;
        private bool isMouseOn;

        public string Title { get; set; }
        public Image PicImg { get; set; }

        public UCSettingItem()
        {
            InitializeComponent();

            BackColor = Color.FromArgb(48, 48, 48);
            DoubleBuffered = true;
        }

        private void UCSettingItem_Paint(object sender, PaintEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                using (var b = new SolidBrush(ForeColor))
                    e.Graphics.DrawString(Title, Font, b, 34, 5);
            }

            if (PicImg != null)
                e.Graphics.DrawImage(PicImg, 5, 7, 24, 24);
        }

        private void UCSettingItem_MouseEnter(object sender, System.EventArgs e)
        {
            isMouseOn = true;
            UpdateBG();
        }

        private void UCSettingItem_MouseLeave(object sender, System.EventArgs e)
        {
            isMouseOn = false;
            UpdateBG();
        }

        internal void SetSelect(bool sel)
        {
            isSelected = sel;
            UpdateBG();
        }

        private void UpdateBG()
        {
            if (isMouseOn)
            {
                BackColor = isSelected ? Color.FromArgb(80, 56, 56) : Color.FromArgb(56, 56, 56);
            }
            else
            {
                BackColor = isSelected ? Color.FromArgb(70, 48, 48) : Color.FromArgb(48, 48, 48);
            }

        }
    }
}
