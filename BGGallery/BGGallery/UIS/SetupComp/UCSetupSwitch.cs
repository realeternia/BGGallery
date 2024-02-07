using System;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCSetupSwitch : UserControl
    {
        public Action<bool> OnModify { get; set; } 

        public UCSetupSwitch()
        {
            InitializeComponent();
        }

        public void SetData(string k, string v, bool isOn)
        {
            label1.Text = k;
            label2.Text = v;
            this.rjToggleButton1.Checked = isOn;
        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (OnModify != null)
                OnModify(rjToggleButton1.Checked);
        }
    }
}
