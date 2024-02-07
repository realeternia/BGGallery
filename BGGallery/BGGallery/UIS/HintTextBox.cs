using System;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    class HintTextBox : TextBox
    {
        private string defaultText;

        public string DefaultText
        {
            get { return defaultText; }
            set { defaultText = value; }
        }

        public string TrueText
        {
            get
            {
                if (Text == defaultText)
                    return "";
                return Text;
            }
            set { 

                if(string.IsNullOrEmpty(value))
                {
                    Text = defaultText;
                    ForeColor = SystemColors.GrayText;
                }
                else
                {
                    Text = value;
                    ForeColor = ForeColorDE;
                }
            }
        }

        public Color ForeColorDE { get; set; } = Color.White;

        public void OnLoad()
        {
            Text = defaultText;
            ForeColor = SystemColors.GrayText;
            this.Enter += new EventHandler(this.HintTextBox_Enter);
            this.Leave += new EventHandler(this.HintTextBox_Leave);
        }

        private void HintTextBox_Enter(object sender, EventArgs e)
        {
            if (Text == defaultText)
            {
                Text = "";
                ForeColor = ForeColorDE;
            }
        }

        private void HintTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Text))
            {
                Text = defaultText;
                ForeColor = SystemColors.GrayText;
            }
        }
    }
}
