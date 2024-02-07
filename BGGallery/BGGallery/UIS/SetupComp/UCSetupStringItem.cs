using System;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCSetupStringItem : UserControl
    {
        public Action<string> OnModify { get; set; } //todo 未实现

        public UCSetupStringItem()
        {
            InitializeComponent();
        }

        public void SetData(string name, string des, string value)
        {
            label1.Text = name;
            label2.Text = des;
            label3.Text = value;
            label3.Location = new System.Drawing.Point(label1.Location.X + label1.Width + 30, label3.Location.Y);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowInputBox(label3.Text, (s) =>
            {
                label3.Text = s;
                if (OnModify != null)
                    OnModify(s);
            });
        }
    }
}
