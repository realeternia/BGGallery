using System;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCDocButtonItem : UserControl, IDocComp
    {
        public Action<string> OnModify { get; set; }
        private int bgId;

        public UCDocButtonItem()
        {
            InitializeComponent();
        }

        public void SetData(Model.BGItemInfo i, string k, string v)
        {
            bgId = i.Id;
            label1.Text = k;
            //if (!string.IsNullOrEmpty(v))
            //    button1.Text = v;
        }

        public void SetReadOnly(bool readOnly)
        {
            button1.Enabled = !readOnly;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowBGPropertyModify(bgId);

            //if (OnModify != null)
            //    OnModify("");
        }
    }
}
