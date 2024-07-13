using BGGallery.Model;
using BGGallery.Utils;
using RJControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCBGPropertyModify : UserControl
    {
        private BGItemInfo bGItemInfo;
        private Dictionary<int, string> cfgDict = new Dictionary<int, string>();

        public UCBGPropertyModify()
        {
            InitializeComponent();

            textBoxBuyTime.OnLoad();
            hintTextBoxPrice.OnLoad();
            hintTextBoxBuyOther.OnLoad();
        }

        public void OnInit(int bgId)
        {
            bGItemInfo = BGBook.Instance.GetItem(bgId);
            labelId.Text = bgId.ToString();
            labelName.Text = bGItemInfo.Title;

            textBoxBuyTime.TrueText = "";
            hintTextBoxPrice.TrueText = "";
            hintTextBoxBuyOther.TrueText = "";

            var buyInfos = bGItemInfo.BuyInfo.Split(',');
            List<string> otherInfos = new List<string>();
            foreach(var buyInfo in buyInfos)
            {
                if (buyInfo.StartsWith("2"))
                    textBoxBuyTime.TrueText = buyInfo;
                else if (buyInfo.StartsWith("￥"))
                    hintTextBoxPrice.TrueText = buyInfo;
                else
                {
                    if (!string.IsNullOrEmpty(buyInfo))
                        otherInfos.Add(buyInfo);
                }
            }
            if (otherInfos.Count > 0)
                hintTextBoxBuyOther.TrueText = string.Join(",", otherInfos);

            textBoxBuyTime.Focus();

            rjComboBoxCatalog.Items.Clear();
            rjComboBoxCatalog.Items.Add("未选择");
            cfgDict[0] = "未选择";
            foreach (var cat in BGBook.Instance.CatalogInfos)
            {
                rjComboBoxCatalog.Items.Add(cat.Name);
                cfgDict[cat.Id] = cat.Name;
            }

            rjComboBoxColumn.Items.Clear();
            rjComboBoxColumn.Items.Add("未选择");
            foreach (var cat in BGBook.Instance.CatalogInfos)
            {
                foreach (var col in cat.Columns)
                {
                    cfgDict[col.Id] = col.Title;
                }
                //if (cat.Id != bGItemInfo.CatalogId)
                //    continue;
                //foreach (var col in cat.Columns)
                //{
                //    rjComboBoxColumn.Items.Add(col.Title);
                //}
            }

            if (bGItemInfo.CatalogId == 0)
            {
                rjComboBoxCatalog.SelectedIndex = 0;
            }
            else
            {
                foreach (var it in rjComboBoxCatalog.Items)
                    if (it.ToString() == cfgDict[bGItemInfo.CatalogId])
                        rjComboBoxCatalog.SelectedItem = it;
            }
            if (bGItemInfo.ColumnId == 0)
            {
                rjComboBoxColumn.SelectedIndex = 0;
            }
            else
            {
                foreach (var it in rjComboBoxColumn.Items)
                    if (it.ToString() == cfgDict[bGItemInfo.ColumnId])
                        rjComboBoxColumn.SelectedItem = it;
            }
        }

        private void rjComboBoxCatalog_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            rjComboBoxColumn.Items.Clear();
            rjComboBoxColumn.Items.Add("未选择");
            var nowCatId = 0;
            foreach (var cfgData in cfgDict)
            {
                if (cfgData.Value == rjComboBoxCatalog.SelectedItem.ToString())
                    nowCatId = cfgData.Key;
            }
            foreach (var cat in BGBook.Instance.CatalogInfos)
            {
                if (cat.Id != nowCatId)
                    continue;
                foreach (var col in cat.Columns)
                {
                    rjComboBoxColumn.Items.Add(col.Title);
                    cfgDict[col.Id] = col.Title;
                }
            }
            rjComboBoxColumn.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }


    }
}

