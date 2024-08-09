using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    public partial class UCBigBox : UserControl
    {
        public UCBigBox()
        {
            InitializeComponent();
            richTextBox1.ShortcutsEnabled = true;    // allow shortcuts
            richTextBox1.DetectUrls = true;    // allow detect url

            Panels.PanelBorders.InitBorder(this);
        }

        public void OnInit(string s)
        {
            richTextBox1.Rtf = s;
            richTextBox1.Select(0, 0);
            richTextBox1.SelectionIndent = 0;
        }
    }
}
