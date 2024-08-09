using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    class PanelBorders
    {
        public static void InitBorder(UserControl uc)
        {
            uc.Paint += (o, e) => { 
                e.Graphics.DrawRectangle(Pens.LightGray, 0, 0, uc.Width-1, uc.Height-1);
                e.Graphics.DrawRectangle(Pens.Gray, 5, 5, uc.Width - 10, uc.Height - 10);
            };
        }

    }
}
