using System;
using System.Windows.Forms;
using System.Linq;
using BGGallery.Model.Types;
using System.Drawing;
using System.Collections.Generic;

namespace BGGallery.UIS
{
    public partial class InputTextColorBox : UserControl
    {
        public Action<TextColorCfg[]> OnCustomTextChanged;

        public TextColorCfg[] ColorArray
        {
            get
            {
                return Export();
            }
            set
            {
                RefreshControls(value);
            }
        }

        public InputTextColorBox()
        {
            InitializeComponent();
        }

        public void OnInit()
        {
          //  textBox1.Focus();
        }

        private void RefreshControls(TextColorCfg[] value)
        {
            tableLayoutPanel1.Controls.Clear();
            tableLayoutPanel1.RowCount = value.Length;

            int index = 0;
            foreach (var colorCfg in value)
            {
                AddLine(index, colorCfg.Text, colorCfg.Color.ToColor());
                index++;
            }
            tableLayoutPanel1.Height = tableLayoutPanel1.RowCount * 30;
        }

        private void AddLine(int index, string text, Color color)
        {
            var textB = new HintTextBox();
            textB.DefaultText = "点击输入";
            textB.Dock = DockStyle.Fill;
            textB.BackColor = Color.FromArgb(40, 40, 40);
            textB.ForeColor = Color.White;
            textB.BorderStyle = BorderStyle.None;
            textB.Font = new Font("微软雅黑", 11);
            textB.OnLoad();
            textB.TrueText = text;
            tableLayoutPanel1.Controls.Add(textB, 0, index);

            Button colorBtn = new Button();
            colorBtn.BackColor = color;
            colorBtn.FlatStyle = FlatStyle.Flat;
            colorBtn.Dock = DockStyle.Fill;
            colorBtn.Click += (sender, e) =>
            {
                PanelManager.Instance.ShowColorBox(colorBtn.BackColor, (s) =>
                {
                    colorBtn.BackColor = s;
                });
            };
            tableLayoutPanel1.Controls.Add(colorBtn, 1, index);

            Button removeBtn = new Button();
            removeBtn.FlatStyle = FlatStyle.Flat;
            removeBtn.Dock = DockStyle.Fill;
            removeBtn.Text = "移除";
            removeBtn.Click += (sender, e) =>
            {
                textB.Tag = "remove";
                var dts = Export();
                RefreshControls(dts);
            };
            tableLayoutPanel1.Controls.Add(removeBtn, 2, index);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (OnCustomTextChanged != null)
                OnCustomTextChanged(ColorArray);

            PanelManager.Instance.HideBlackPanel();
        }

        private void rjButtonAddLine_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowCount = tableLayoutPanel1.RowCount + 1;
            AddLine(tableLayoutPanel1.RowCount - 1, "", Color.LawnGreen);
            tableLayoutPanel1.Height = tableLayoutPanel1.RowCount * 30;
        }

        private TextColorCfg[] Export()
        {
            var configs = new List<TextColorCfg>();

            // 假设每行都有三个控件：HintTextBox, ColorButton, RemoveButton  
            // 并且这些控件是按照这个顺序添加的  
            for (int rowIndex = 0; rowIndex < tableLayoutPanel1.RowCount; rowIndex++)
            {
                Control textBoxControl = tableLayoutPanel1.GetControlFromPosition(0, rowIndex);
                Control colorBtnControl = tableLayoutPanel1.GetControlFromPosition(1, rowIndex);

                // 移除按钮不是必需的，因为它不包含我们需要的数据  

                if (textBoxControl is HintTextBox textBox && colorBtnControl is Button colorBtn)
                {
                    if (textBox.Tag != null && (string)textBox.Tag == "remove")
                        continue;

                    // 假设HintTextBox类有一个Text属性  
                    string text = textBox.TrueText;

                    // 将Button的背景色转换为Color对象  
                    Color color = colorBtn.BackColor;

                    // 创建一个TextColorCfg对象并添加到列表中  
                    configs.Add(new TextColorCfg
                    {
                        Text = text,
                        Color = new ColorCfg { Value = color.ToArgb() } // 假设ColorCfg有一个Value属性来存储颜色的ARGB值  
                    });
                }
            }

            return configs.ToArray();
        }
    }
}
