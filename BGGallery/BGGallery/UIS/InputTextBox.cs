using System;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class InputTextBox : UserControl
    {
        public Action<string> OnCustomTextChanged;

        public override string Text
        {
            get
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text))
                    return "未命名";
                return textBox1.Text;
            }
            set { textBox1.Text = value; }
        }

        public InputTextBox()
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
                OnCustomTextChanged(textBox1.Text);

            PanelManager.Instance.HideBlackPanel();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (OnCustomTextChanged != null)
                    OnCustomTextChanged(textBox1.Text);
                e.Handled = true;

                PanelManager.Instance.HideBlackPanel();
            }
        }

    }
}
