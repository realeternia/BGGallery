using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    public partial class UCNInput : UserControl
    {
        private int textHintIndex;
        private bool isAutoComplete;
        private static string[] wordList = new string[0];
        private List<string> results = new List<string>(); //当前显示的结果列表

        public Action<string> AfterSelect;

        public UCNInput()
        {
            InitializeComponent();
        }

        public void OnInit(string[] wordL)
        {
            wordList = wordL;
            textBoxText.Clear();
            textBoxText.Focus();

            UpdateHints();
            Panels.PanelBorders.InitBorder(this);
        }

        private string GetHint(int index)
        {
            if (results.Count == 0)
            {
                return "";
            }
            return results[index % results.Count];
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                e.Handled = true;
                textHintIndex--;
                UpdateHintText();
            }
            else if (e.KeyCode == Keys.Down)
            {
                e.Handled = true;
                textHintIndex++;
                UpdateHintText();
            }
        }

        private void UpdateHintText()
        {
            var hintResult = GetHint(10000000 + textHintIndex);
            if (hintResult != "")
            {
                isAutoComplete = true;
                textBoxText.Text = hintResult;
                textBoxText.SelectionStart = textBoxText.Text.Length;
                listBox1.SelectedIndex = results.IndexOf(hintResult);
                isAutoComplete = false;
            }
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonOk.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (AfterSelect != null)
                    AfterSelect("");
                PanelManager.Instance.HideBlackPanel();
            }
        }

        private void textBoxText_TextChanged(object sender, EventArgs e)
        {
            if (textBoxText.Text.Contains("\n"))
            {
                textBoxText.Text = "";
                return;
            }

            UpdateHints();
        }

        private void UpdateHints()
        {
            var nowText = textBoxText.Text;
            if (isAutoComplete)
                return;

            textHintIndex = 0;

            results = new List<string>();
            nowText = nowText.Trim();
            foreach (var matchTxt in wordList)
            {
                if (results.Count >= 10)
                    break;
                if (string.IsNullOrEmpty(nowText))
                {
                    results.Add(matchTxt);
                    continue;
                }

                if (ConvertPinyinName(matchTxt).StartsWith(nowText) || matchTxt.StartsWith(nowText))
                {
                    results.Add(matchTxt);
                    continue;
                }
            }

            listBox1.Items.Clear();
            listBox1.Items.AddRange(results.ToArray());
        }

        private string ConvertPinyinName(string nm)
        {
            var ss = NPinyin.Pinyin.GetPinyin(nm).Split(' ');
            StringBuilder sb = new StringBuilder();
            foreach (var s in ss)
            {
                if (s.Length == 0)
                    continue;
                sb.Append(s[0]);
            }
            return sb.ToString();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxText.Text))
                return;

            if (AfterSelect != null)
                AfterSelect(textBoxText.Text);
          
            PanelManager.Instance.HideBlackPanel();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textHintIndex = listBox1.SelectedIndex;
            UpdateHintText();
        }
    }
}
