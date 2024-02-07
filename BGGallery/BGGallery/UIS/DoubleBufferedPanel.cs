using System.Windows.Forms;

namespace BGGallery.UIS
{
    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true; 
        }
    }
}
