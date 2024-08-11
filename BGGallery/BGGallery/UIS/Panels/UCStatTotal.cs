using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    public partial class UCStatTotal : UserControl
    {
        public UCStatTotal()
        {
            InitializeComponent();
        }

        public void Init()
        {
            AddLine("桌游总计", "总计", BGBook.Instance.Items.Count.ToString());
            AddLine("", "未到货", BGBook.Instance.Items.FindAll(a => a.BuyInfo != null && a.BuyInfo.Contains("未到货")).Count.ToString());
            AddLine("", "已卖出", "-" + BGBook.Instance.Items.FindAll(a => a.BuyInfo != null && a.BuyInfo.Contains("已卖出")).Count.ToString());
            AddLine("", "已攻略", BGBook.Instance.Items.FindAll(a => a.Parm != null && a.Parm.Contains("wcount")).Count.ToString());
            AddLine("桌游分类", "", "");
            AddLine("", "德式", BGBook.Instance.Items.FindAll(a => a.Tag != null && a.Tag.Contains("德式")).Count.ToString());
            AddLine("", "美式", BGBook.Instance.Items.FindAll(a => a.Tag != null && a.Tag.Contains("美式")).Count.ToString());
            AddLine("购入", "", "");
            var nowYear = DateTime.Now.Year;
            AddLine("", "今年数量", BGBook.Instance.Items.FindAll(a => a.BuyInfo != null && a.BuyInfo.Contains(nowYear.ToString())).Count.ToString());
            AddLine("", "去年数量", BGBook.Instance.Items.FindAll(a => a.BuyInfo != null && a.BuyInfo.Contains((nowYear - 1).ToString())).Count.ToString());
            AddLine("", "今年花费", "￥" + SumMoney(nowYear).ToString());
            AddLine("", "去年花费", "￥" + SumMoney(nowYear - 1).ToString());
            AddLine("评分", "", "");
            AddLine("", "90+", BGBook.Instance.Items.FindAll(a => a.Star >= 90).Count.ToString());
            AddLine("", "80+", BGBook.Instance.Items.FindAll(a => a.Star >= 80 && a.Star < 90).Count.ToString());
            AddLine("", "70+", BGBook.Instance.Items.FindAll(a => a.Star >= 70 && a.Star < 80).Count.ToString());
            AddLine("", "60+", BGBook.Instance.Items.FindAll(a => a.Star >= 60 && a.Star < 70).Count.ToString());
            AddLine("", "未打分", BGBook.Instance.Items.FindAll(a => a.Star == 0).Count.ToString());
        }

        private static decimal SumMoney(int nowYear)
        {
            decimal totalMoney = BGBook.Instance.Items
                .Where(item => item.BuyInfo != null && item.BuyInfo.Contains(nowYear.ToString())) // 确保BuyInfo不为null  
                .Select(item =>
                {
                    // 假设BuyInfo是一个以逗号分隔的字符串，我们尝试找到以￥开头的价格  
                    var priceParts = item.BuyInfo.Split(',');
                    decimal price = 0m;
                    foreach (var part in priceParts)
                    {
                        if (part.StartsWith("￥") && decimal.TryParse(part.Substring(1), out decimal tempPrice))
                        {
                            // 检查这个价格是否属于当前年份（这里需要额外的逻辑来确认，但基于你的原始问题，我们假设所有找到的价格都符合条件）  
                            // 由于题目没有提供具体的年份与价格的关联方式，这里我们假设所有找到的价格都有效  
                            price += tempPrice; // 累加价格  
                        }
                    }
                    // 注意：这里我们假设每个Item只计算一次价格总和，即使它可能包含多个价格  
                    // 如果你的逻辑需要不同，你可能需要调整这个部分  
                    return price;
                }).Sum(); // 累加所有Item的价格总和
            return totalMoney;
        }

        private void AddLine(string t, string subt, string val)
        {
            ListViewItem lvi = new ListViewItem(t);
            lvi.UseItemStyleForSubItems = false; //aaaaaaaa
            lvi.SubItems.Add(subt);
            lvi.SubItems.Add(val);
            if (val.StartsWith("-"))
                lvi.SubItems[lvi.SubItems.Count - 1].ForeColor = Color.IndianRed;
            else if (val.StartsWith("￥"))
                lvi.SubItems[lvi.SubItems.Count - 1].ForeColor = Color.Orange;
            else
                lvi.SubItems[lvi.SubItems.Count - 1].ForeColor = Color.LawnGreen;
            listView1.Items.Add(lvi);
        }
    }
}
