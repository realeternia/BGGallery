using System;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCSetupColorItem : UserControl
    {
        public Action<Color> OnModify { get; set; } 

        public UCSetupColorItem()
        {
            InitializeComponent();
        }

        public void SetData(string name, string des, Color value)
        {
            label1.Text = name;
            label2.Text = des;
            panel1.BackColor = value;
            panel1.Location = new System.Drawing.Point(label1.Location.X + label1.Width + 30, panel1.Location.Y);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowColorBox(panel1.BackColor, (s) =>
            {
                panel1.BackColor = s;
                if (OnModify != null)
                    OnModify(s);
            });
        }
    }
}
