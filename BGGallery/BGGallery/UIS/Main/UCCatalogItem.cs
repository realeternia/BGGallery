using BGGallery.Properties;
using BGGallery.UIS;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery
{
    public partial class UCCatalogItem : UserControl
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private bool isSelected;
        private bool isMouseOn;

        private Rectangle menuRegion;
        public RJControls.RJDropdownMenu Menu { get; set; }

        public UCCatalogItem()
        {
            InitializeComponent();
        }

        public void AfterInit()
        {
            menuRegion = new Rectangle(Width - 40, Height / 2 - Resources.menu.Height / 2, 34, 31);
        }

        public void SetSelect(bool sel)
        {
            isSelected = sel;
            UpdateBG();
        }

        private void UCCatalogItem_Paint(object sender, PaintEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Title))
                using (var b = new SolidBrush(ForeColor))
                    e.Graphics.DrawString(Title, Font, b, 34, 5);

            e.Graphics.DrawImage(Resources.note, 5, 7, 24, 24);

            if (isMouseOn)
                e.Graphics.DrawImage(Resources.menu, menuRegion);
        }

        private void UCCatalogItem_MouseEnter(object sender, System.EventArgs e)
        {
            isMouseOn = true;
            UpdateBG();
        }

        private void UCCatalogItem_MouseLeave(object sender, System.EventArgs e)
        {
            isMouseOn = false;
            UpdateBG();
        }

        private void UCCatalogItem_MouseClick(object sender, MouseEventArgs e)
        {
            if (menuRegion.Contains(e.Location) && Menu != null)
            {
                Menu.Show(this, menuRegion.X + menuRegion.Width, menuRegion.Y);
                Menu.Tag = Id;
            }
        }

        private void UpdateBG()
        {
            if (isMouseOn)
            {
                BackColor = isSelected ? Color.FromArgb(90, 40, 40) : Color.FromArgb(64, 64, 64);
            }
            else
            {
                BackColor = isSelected ? Color.FromArgb(70, 20, 20) : Color.FromArgb(24, 24, 24);
            }

        }
    }
}
