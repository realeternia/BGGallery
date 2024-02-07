using System;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCSetupStrArrayItem : UserControl
    {
        public Action<string[]> OnModify { get; set; } //todo 未实现

        private string[] vals;

        public UCSetupStrArrayItem()
        {
            InitializeComponent();
        }

        private string GetResult()
        {
            string result = string.Join(", ", vals);

            // 截断字符串到前50个字符
            int maxLength = 50;
            if (result.Length > maxLength)
            {
                result = result.Substring(0, maxLength) + "...";
            }
            return result;
        }

        public void SetData(string name, string des, string[] value)
        {
            label1.Text = name;
            label2.Text = des;
            vals = value;
            label3.Text = GetResult();
            label3.Location = new System.Drawing.Point(label1.Location.X + label1.Width + 30, label3.Location.Y);
        }

        private void rjButton1_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowStrArrayBox(vals, (s) =>
            {
                vals = s;
                label3.Text = GetResult();
                if (OnModify != null)
                    OnModify(s);
            });
        }
    }
}
