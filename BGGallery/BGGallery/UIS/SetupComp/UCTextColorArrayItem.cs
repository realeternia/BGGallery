using BGGallery.Model.Types;
using System;
using System.Linq;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCTextColorArrayItem : UserControl
    {
        public Action<TextColorCfg[]> OnModify { get; set; }
        private TextColorCfg[] old;

        public UCTextColorArrayItem()
        {
            InitializeComponent();
        }

        public void SetData(string name, string des, TextColorCfg[] value)
        {
            old = value;
            label1.Text = name;
            label2.Text = des;
            label3.Text = value == null ? "" : string.Join(",", value.Select(cfg => cfg.ToString()));
            label3.Location = new System.Drawing.Point(label1.Location.X + label1.Width + 30, label3.Location.Y);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowTextColorBox(old, (array) =>
            {
                label3.Text = array == null ? "" : string.Join(",", array.Select(cfg => cfg.ToString()));
                old = array;
                if (OnModify != null)
                    OnModify(array);
            });
        }
    }
}
