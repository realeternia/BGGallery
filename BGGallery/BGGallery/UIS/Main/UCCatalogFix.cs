using BGGallery.Properties;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery
{
    public partial class UCCatalogFix : UserControl
    {
        public string Title { get; set; }
        public Image PicImg { get; set; }

        public UCCatalogFix()
        {
            InitializeComponent();

            DoubleBuffered = true;
        }

        private void UCCatalogNew_Paint(object sender, PaintEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                using (var b = new SolidBrush(ForeColor))
                    e.Graphics.DrawString(Title, Font, b, 34, 8);
            }

            e.Graphics.DrawImage(PicImg, 5, 7, 24, 24);
        }

        private void UCCatalogNew_MouseEnter(object sender, System.EventArgs e)
        {
            BackColor = Color.FromArgb(64, 64, 64);
        }

        private void UCCatalogNew_MouseLeave(object sender, System.EventArgs e)
        {
            BackColor = Color.FromArgb(24, 24, 24);
        }
    }
}
