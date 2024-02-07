using System;
using System.Windows.Forms;
using System.Linq;

namespace BGGallery.UIS
{
    public partial class InputArrayBox : UserControl
    {
        public Action<string[]> OnCustomTextChanged;

        public string[] StrArray
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                    return new string[0];

                string[] lines = textBox1.Text.Split('\n')
                                           .Select(line => line.Trim())  // Trim 剔除空白字符
                                           .Where(line => !string.IsNullOrWhiteSpace(line))  // 剔除空字符串
                                           .ToArray();

                return lines;
            }
            set
            {
                textBox1.Clear();
                foreach (var line in value)
                    textBox1.AppendText(line + "\r\n");
            }
        }

        public InputArrayBox()
        {
            InitializeComponent();
        }

        public void OnInit()
        {
            textBox1.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (OnCustomTextChanged != null)
                OnCustomTextChanged(StrArray);

            PanelManager.Instance.HideBlackPanel();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
      
        }

    }
}
