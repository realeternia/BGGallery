using BGGallery;
using BGGallery.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    public partial class UCEditTime : UserControl
    {
        public Action<uint> AfterSelect;

        public UCEditTime()
        {
            InitializeComponent();
            DoubleBuffered = true;

            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                    control.KeyUp += TextBox_KeyDown;
            }
            Panels.PanelBorders.InitBorder(this);
        }


        public void OnInit()
        {
            SetTime(DateTime.Now);
            this.Focus();
        }


        private void SetTime(DateTime dt)
        {
            textBoxYear.Text = dt.Year.ToString();
            textBoxMonth.Text = dt.Month.ToString();
            textBoxDate.Text = dt.Day.ToString();

            textBoxHour.Text = dt.Hour.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMonth.Text) || string.IsNullOrEmpty(textBoxHour.Text))
                return;

            var nowDate = new DateTime(int.Parse(textBoxYear.Text), int.Parse(textBoxMonth.Text),
                int.Parse(textBoxDate.Text)
                , int.Parse(textBoxHour.Text), 0, 0);

            var addon = int.Parse((sender as Button).Tag.ToString());

            SetTime(nowDate.AddHours(addon));
        }

        private void textBoxYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            //判断按键是不是要输入的类型。
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8 && (int)e.KeyChar != 46)
                e.Handled = true;
        }

        private void textBoxSec_TextChanged(object sender, EventArgs e)
        {
            var txtbox = sender as TextBox;
            if (txtbox.Text == "")
                txtbox.Text = 0.ToString();
            int number = int.Parse(txtbox.Text);
            if (number < 0)
            {
                number = 0;
            }

            if (number > int.Parse(txtbox.Tag.ToString()))
            {
                number = int.Parse(txtbox.Tag.ToString());
            }

            txtbox.Text = number.ToString();
        }

        private bool flag = false;
        private void textBoxYear_Enter(object sender, EventArgs e)
        {
            flag = true;
        }

        private void textBoxYear_MouseUp(object sender, MouseEventArgs e)
        {
            if (flag)
            {
                flag = false;
                (sender as TextBox).SelectAll();
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            var nowDate = new DateTime(int.Parse(textBoxYear.Text), int.Parse(textBoxMonth.Text),
             int.Parse(textBoxDate.Text)
             , int.Parse(textBoxHour.Text), 0, 0);

            if (AfterSelect != null)
                AfterSelect(TimeTool.DateTimeToUnixTime(nowDate));

            PanelManager.Instance.HideBlackPanel();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (AfterSelect != null)
                        AfterSelect(0);
                    PanelManager.Instance.HideBlackPanel();
                    break;
            }
        }

        private void UCGmRunSvTime_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (AfterSelect != null)
                        AfterSelect(0);
                    PanelManager.Instance.HideBlackPanel();
                    break;
            }
        }
    }
}
