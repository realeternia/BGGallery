using System.Windows.Forms;

namespace BGGallery.UIS
{
    public class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        public DoubleBufferedFlowLayoutPanel()
        {
            DoubleBuffered = true;
        }
    }
}
