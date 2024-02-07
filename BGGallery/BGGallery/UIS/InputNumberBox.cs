using System;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class InputNumberBox : UserControl
    {
        public Action<int> OnCustomTextChanged;

        public int Value
        {
            get
            {
                if (int.TryParse(textBox1.Text, out var r))
                    return r;
                return 0;
            }
            set { textBox1.Text = value.ToString(); }
        }

        public int ValMin { get; set; }
        public int ValMax { get; set; }

        public InputNumberBox()
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
                OnCustomTextChanged(int.Parse(textBox1.Text));

            PanelManager.Instance.HideBlackPanel();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!int.TryParse(textBox1.Text, out var _))
                    textBox1.Text = "0";

                if (OnCustomTextChanged != null)
                    OnCustomTextChanged(int.Parse(textBox1.Text));
                e.Handled = true;

                PanelManager.Instance.HideBlackPanel();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 允许数字、删除键和退格键的输入
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // 阻止输入
            }

            // 获取当前文本框中的文本
            string currentText = this.textBox1.Text;

            // 在处理输入之前，尝试将输入字符添加到当前文本框中的文本
            string newText = currentText.Substring(0, this.textBox1.SelectionStart) + e.KeyChar + currentText.Substring(this.textBox1.SelectionStart + this.textBox1.SelectionLength);

            // 尝试将新文本解析为数字
            if (!int.TryParse(newText, out int number))
            {
                e.Handled = true; // 阻止输入，因为新文本不是有效的数字
            }
            else if (number < ValMin || number > ValMax)
            {
                textBox1.Text = ValMax.ToString();
                e.Handled = true; // 阻止输入，因为数字超出范围
            }
        }
    }
}
