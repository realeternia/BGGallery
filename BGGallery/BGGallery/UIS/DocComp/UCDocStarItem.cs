using BGGallery.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCDocStarItem : UserControl, IDocComp
    {
        public Action<string> OnModify { get; set; }

        public UCDocStarItem()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        public void SetData(Model.BGItemInfo i, string k, string tagStr1)
        {
            label1.Text = k;
            textBox1.Text = tagStr1;
        }

        public void SetReadOnly(bool readOnly)
        {
            textBox1.ReadOnly = readOnly;
        }

        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            Invalidate();
            OnModify(textBox1.Text);
            textBox1.Visible = false;
        }

        private void UCDocStarItem_Paint(object sender, PaintEventArgs e)
        {
            if (textBox1.Visible)
                return;

            var startX = 110;
            var startY = 5;

            var val = 0;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                val = int.Parse(textBox1.Text);
            }

            bool needHalf = false;

            if ((val % 10) >= 5)
                needHalf = true;

            var fullCount = val / 10;
            var emptyCount = 10 - val / 10;
            if (needHalf)
                emptyCount--;

            List<string> starList = new List<string>();
            for (int i = 0; i < fullCount; i++)
                starList.Add("full");
            if(needHalf)
                starList.Add("half");
            for (int i = 0; i < emptyCount; i++)
                starList.Add("empty");

            var isNewBie = label1.Text.Contains("新手");
            foreach (string type in starList)
            {
                if (type == "full")
                    e.Graphics.DrawImage(!isNewBie ? Resources.stary: Resources.starn, startX, startY, 20, 20);
                else if (type == "half")
                    e.Graphics.DrawImage(!isNewBie ? Resources.stary1 : Resources.starn1, startX, startY, 20, 20);
                else
                    e.Graphics.DrawImage(Resources.starnull, startX, startY, 20, 20);

                startX += 20 + 3;
            }
        }

        private void UCDocStarItem_Click(object sender, System.EventArgs e)
        {
            if (textBox1.ReadOnly)
                return;

            textBox1.Visible = true;
            textBox1.Focus();
            Invalidate();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Invalidate();
                OnModify(textBox1.Text);
                textBox1.Visible = false;
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
            else if (number < 1 || number > 100)
            {
                textBox1.Text = "100";
                e.Handled = true; // 阻止输入，因为数字超出范围
            }
        }
    }
}
