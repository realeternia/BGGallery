using System;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCDocStringItem : UserControl, IDocComp
    {
        public Action<string> OnModify { get; set; }

        public UCDocStringItem()
        {
            InitializeComponent();
        }

        public void SetData(string k, string v)
        {
            label1.Text = k;
            if (!string.IsNullOrEmpty(v))
                textBox1.Text = v;
        }

        public void SetReadOnly(bool readOnly)
        {
            textBox1.ReadOnly = readOnly;
            textBox1.ForeColor = readOnly ? label1.ForeColor : Color.White;
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (OnModify != null)
                    OnModify(textBox1.Text);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (OnModify != null)
                OnModify(textBox1.Text);
        }
    }
}
