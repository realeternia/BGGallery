using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCDocSelectItem : UserControl, IDocComp
    {
        public Action<string> OnModify { get; set; }

        public UCDocSelectItem()
        {
            InitializeComponent();
            DoubleBuffered = true;
        }

        private Dictionary<int, string> cfgDict = new Dictionary<int, string>();
        private string lastVal;
        public void SetData(Model.BGItemInfo i, string k, string tagStr1)
        {
            label1.Text = k;
            cfgDict.Clear();
            rjComboBox1.Items.Clear();
            if (k == "CatalogId")
            {
                foreach(var cat in BGBook.Instance.CatalogInfos)
                {
                    rjComboBox1.Items.Add(cat.Name);
                    cfgDict[cat.Id] = cat.Name;
                }
            }
            else if (k == "ColumnId")
            {
                foreach (var cat in BGBook.Instance.CatalogInfos)
                {
                    if (cat.Id != i.CatalogId)
                        continue;
                    foreach (var col in cat.Columns)
                    {
                        rjComboBox1.Items.Add(col.Title);
                        cfgDict[col.Id] = col.Title;
                    }
                }
            }

            lastVal = tagStr1;
            var checkId = int.Parse(tagStr1);
            var checkStr = "";
            if (cfgDict.ContainsKey(checkId))
                checkStr = cfgDict[checkId];
            foreach (var it in rjComboBox1.Items)
                if (it.ToString() == checkStr)
                    rjComboBox1.SelectedItem = it;
        }

        public void SetReadOnly(bool readOnly)
        {
            // rjComboBox1.r = readOnly;
        }

        private void textBox1_Leave(object sender, System.EventArgs e)
        {
            Invalidate();

            if (rjComboBox1.SelectedItem == null)
            {
                rjComboBox1.Visible = false;
                return;
            }
            foreach (var itm in cfgDict)
            {
                if (itm.Value == rjComboBox1.SelectedItem.ToString())
                {
                    if (lastVal != itm.Key.ToString())
                    {
                        OnModify(itm.Key.ToString());
                        lastVal = itm.Key.ToString();
                    }
                    break;
                }
            }
            rjComboBox1.Visible = false;
        }

        private void UCDocStarItem_Paint(object sender, PaintEventArgs e)
        {
            if (rjComboBox1.Visible)
                return;

            var startX = 110;
            var startY = 5;

            var checkitem = "未选择";
            if (rjComboBox1.SelectedItem != null)
                checkitem = rjComboBox1.SelectedItem.ToString();
            e.Graphics.DrawString(checkitem, Font, checkitem == "未选择" ? Brushes.Gray : Brushes.White, startX + 3, startY + 5);
        }

        private void UCDocStarItem_Click(object sender, System.EventArgs e)
        {
            //if (textBox1.ReadOnly)
            //    return;

            rjComboBox1.Visible = true;
            rjComboBox1.Focus();
            Invalidate();
        }

    }
}
