using BGGallery.Model;
using BGGallery.UIS.Panels;
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
        private Label addLabel;

        public UCBGPropertyModify()
        {
            InitializeComponent();

            hintTextBoxBuyTime.OnLoad();
            hintTextBoxPrice.OnLoad();
            hintTextBoxBuyOther.OnLoad();

            PanelBorders.InitBorder(this);
        }

        public void OnInit(int bgId)
        {
            bGItemInfo = BGBook.Instance.GetItem(bgId);
            labelId.Text = bgId.ToString();
            labelName.Text = bGItemInfo.Title;

            hintTextBoxBuyTime.TrueText = "";
            hintTextBoxPrice.TrueText = "";
            hintTextBoxBuyOther.TrueText = "";

            if (!string.IsNullOrEmpty(bGItemInfo.BuyInfo))
            {
                var buyInfos = bGItemInfo.BuyInfo.Split(',');
                List<string> otherInfos = new List<string>();
                foreach (var buyInfo in buyInfos)
                {
                    if (buyInfo.StartsWith("2"))
                        hintTextBoxBuyTime.TrueText = buyInfo;
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
            }

            hintTextBoxBuyTime.Focus();

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

            flowLayoutPanel1.Controls.Clear();
            var myTags = new HashSet<string>();
            if(bGItemInfo.TagInfo != null)
            {
                var listTag = new List<string>(bGItemInfo.TagInfo.Split(','));
                listTag.Sort();
                foreach (var tag in listTag)
                {
                    AddAttrItem(tag, true);
                    myTags.Add(tag);
                }
            }
            var list = new List<string>(TagsInfoManager.Tags);
            list.Sort();
            foreach (var tag in list)
            {
                if (myTags.Contains(tag))
                    continue;
                AddAttrItem(tag, false);
            }
            if (addLabel == null)
            {
                var btn = new Label();
                btn.Cursor = Cursors.Hand;
                btn.AutoSize = true;
                btn.Font = new Font("微软雅黑", 11, FontStyle.Regular);
                btn.BackColor = Color.FromArgb(32, 32, 32);
                btn.Text = "+添加";
                btn.Click += (e, o) => {
                   // Point absoluteLocation = this.PointToScreen(new Point(0, 0));

                    var inputBox = new InputTextBox();
                    inputBox.OnCustomTextChanged = OnAddTag;

                    PanelManager.Instance.ShowBlackPanel(inputBox, 0, 0, 1);
                    inputBox.Focus();
                };
                addLabel = btn;
            }

            flowLayoutPanel1.Controls.Add(addLabel);
        }

        private void OnAddTag(string tag)
        {
            AddAttrItem(tag, true);
            flowLayoutPanel1.Controls.SetChildIndex(addLabel, flowLayoutPanel1.Controls.Count);

            TagsInfoManager.Add(tag);
        }

        private void AddAttrItem(string tag, bool checked1)
        {
            var tagItem = new UCBGPropertyAttrItem();
            tagItem.Cursor = Cursors.Hand;
            tagItem.Text = tag;
            tagItem.Checked = checked1;
            tagItem.Font = new Font("微软雅黑", 11, FontStyle.Regular);
            flowLayoutPanel1.Controls.Add(tagItem);
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

        private void rjButtonOk_Click(object sender, EventArgs e)
        {
            List<string> buyInfo = new List<string>();
            if (!string.IsNullOrEmpty(hintTextBoxBuyTime.TrueText)) 
                buyInfo.Add(hintTextBoxBuyTime.TrueText);
            if (!string.IsNullOrEmpty(hintTextBoxPrice.TrueText)) 
                buyInfo.Add(hintTextBoxPrice.TrueText);
            var buyInfoStr = string.Join(",", buyInfo);
            if(!string.IsNullOrEmpty(hintTextBoxBuyOther.TrueText))
                buyInfoStr = buyInfoStr + "," + hintTextBoxBuyOther.TrueText;
            bGItemInfo.BuyInfo = buyInfoStr;
            bGItemInfo.CatalogId = 0;
            bGItemInfo.ColumnId = 0;
            foreach (var cfgData in cfgDict)
            {
                if (cfgData.Value == rjComboBoxCatalog.SelectedItem.ToString())
                    bGItemInfo.CatalogId = cfgData.Key;
                else if (cfgData.Value == rjComboBoxColumn.SelectedItem.ToString())
                    bGItemInfo.ColumnId = cfgData.Key;
            }

            List<string> tags = new List<string>();
            foreach (var ctr in flowLayoutPanel1.Controls)
            {
                var checkControl = ctr as UCBGPropertyAttrItem;
                if (checkControl == null || !checkControl.Checked || string.IsNullOrEmpty(checkControl.Text))
                    continue;

                tags.Add(checkControl.Text.Trim());
            }
            bGItemInfo.TagInfo = string.Join(",", tags);

            DelayedExecutor.Trigger("memoSave", 10, () => BGBook.Instance.Save());

            PanelManager.Instance.HideBlackPanel();
        }
    }
}

