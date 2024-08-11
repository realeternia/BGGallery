using BGGallery.Model;
using BGGallery.Model.Types;
using BGGallery.UIS.Panels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCStatPanel : UserControl
    {
        private List<Control> cachedControls = new List<Control>();
        private List<string> catalogs = new List<string>();
        private UCSettingItem nowSettingCtr;

        public UCStatPanel()
        {
            InitializeComponent();

         //   Panels.PanelBorders.InitBorder(this);
        }

        public void Init()
        {
            catalogs = new List<string>() { "概况", "购买信息" };

            int index = 0;
            UCSettingItem firstItem = null;
            foreach (var cat in catalogs)
            {
                var settingItem = new UCSettingItem();
                settingItem.Title = cat;
                settingItem.Width = Width - panel1.Width;
                settingItem.Location = new Point(1, index * 40 + 50);
                settingItem.Click += CatalogItem_Click;
                Controls.Add(settingItem);
                index++;

                if (firstItem == null)
                    firstItem = settingItem;
            }

            SelectTarget(firstItem);
        }

        private void CatalogItem_Click(object sender, System.EventArgs e)
        {
            var mItem = sender as UCSettingItem;
            if (nowSettingCtr == mItem)
                return;

            SelectTarget(mItem);
        }

        private void SelectTarget(UCSettingItem mItem)
        {
            if (nowSettingCtr != null)
                nowSettingCtr.SetSelect(false);
            nowSettingCtr = mItem;
            mItem.SetSelect(true);

            RefreshItems(mItem.Title);
        }

        private void RefreshItems(string cat)
        {
            panel1.SuspendLayout();
            panel1.Controls.Clear();

            UserControl uc = null;
            if(cat == "概况")
            {
                uc = new UCStatTotal();
                (uc as UCStatTotal).Init();
                uc.Width = panel1.Width;
                uc.Height = panel1.Height - 90;
                panel1.Controls.Add(uc);
                uc.Location = new Point(0, 90);
            }
            else if (cat == "购买信息")
            {
                List<string> xData = new List<string>();
                List<float> yData = new List<float>();
                for (int i = 2019; i <= 2024; i++)
                {
                    xData.Add(i.ToString());
                    yData.Add(UCStatTotal.SumMoney(i.ToString()));
                }
                uc = new UCMemChart();
                uc.BackColor = Color.FromArgb(16,24,16);
                (uc as UCMemChart).InitBars("年购买支付（元）", xData.ToArray(), yData.ToArray());
                uc.Width = panel1.Width - 160;
                uc.Height = 220;
                panel1.Controls.Add(uc);
                uc.Location = new Point(60, 90);

                xData.Clear();
                yData.Clear();
                for (int year = 2019; year <= 2024; year++)
                {
                    for (int month = 1; month <= 12; month++)
                    {
                        string monthStr = month.ToString("D2"); // 确保月份是两位数（如 "01" 而不是 "1"）
                        monthStr = $"{year}-{monthStr}";
                        xData.Add(month == 1 ? year.ToString() : month.ToString());
                        yData.Add(UCStatTotal.SumMoney(monthStr));
                    }
                }
                uc = new UCMemChart();
                uc.BackColor = Color.FromArgb(16, 24, 16);
                (uc as UCMemChart).InitBars("月购买支付（元）", xData.ToArray(), yData.ToArray());
                uc.Width = panel1.Width - 160;
                uc.Height = 220;
                panel1.Controls.Add(uc);
                uc.Location = new Point(60, 90 + 220 + 20);
            }

            panel1.ResumeLayout();

            panel1.Invalidate(new Rectangle(0, 0, 870, 100));
        }

        private void doubleBufferedPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (nowSettingCtr != null)
                using (var ft = new Font("微软雅黑", 12))
                    e.Graphics.DrawString(nowSettingCtr.Title, ft, Brushes.White, 55, 35);
            e.Graphics.DrawLine(Pens.Gray, 55, 75, 870, 75);
        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            panel1.Invalidate(new Rectangle(0, 0, 870, 100));
        }
    }
}
