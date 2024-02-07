using System;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCSetupNumberItem : UserControl
    {
        public Action<int> OnModify { get; set; } //todo 未实现

        public int MinVal { get; set; }
        public int MaxVal { get; set; }

        public UCSetupNumberItem()
        {
            InitializeComponent();
        }

        public void SetData(string name, string des, int value)
        {
            label1.Text = name;
            label2.Text = string.Format("{0} 值范围[{1}, {2}]", des, MinVal, MaxVal);
            label3.Text = value.ToString();
            label3.Location = new System.Drawing.Point(label1.Location.X + label1.Width + 30, label3.Location.Y);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            var val = 0;
            if (int.TryParse(label3.Text, out var val1))
                val = val1;
            PanelManager.Instance.ShowNumberBox(val, MinVal, MaxVal, (s) =>
            {
                label3.Text = s.ToString();
                if (OnModify != null)
                    OnModify(s);
            });
        }

    }
}
