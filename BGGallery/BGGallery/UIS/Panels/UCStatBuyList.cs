using BGGallery.Utils;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    public partial class UCStatBuyList : UserControl
    {
        public UCStatBuyList()
        {
            InitializeComponent();
        }

        public class BuyRecord
        {
            public string GameName { get; set; }
            public string YearInfo { get; set; }
            public string PriceInfo { get; set; }
            public string OtherInfo { get; set; }

            public int PlayerCount { get; set; } //游玩次数
            public bool HasNote { get; set; } //是否攻略
        }

        public void Init()
        {
            var filteredItems = BGBook.Instance.Items
                .Where(item => item.BuyInfo != null)
                .ToList();
            // filteredItems.Sort((a, b) => b.b.CompareTo(a.BeginTime));
            // 创建列表保存提取后的数据
            List<BuyRecord> buyRecords = new List<BuyRecord>();
            // 清空旧数据
            listView1.Items.Clear();

            foreach (var record in filteredItems)
            {
                var priceParts = record.BuyInfo.Split(',');
                string yearInfo = "";
                string priceInfo = "";
                string otherInfo = "";

                foreach (var part in priceParts)
                {
                    if (part.StartsWith("￥"))
                    {
                        priceInfo = part.Substring(1);
                    }
                    else if (part.Contains("-"))
                    {
                        yearInfo += part;
                    }
                    else
                    {
                        otherInfo += part;
                    }
                }

                buyRecords.Add(new BuyRecord
                {
                    GameName = record.Title,
                    YearInfo = yearInfo,
                    PriceInfo = priceInfo,
                    OtherInfo = otherInfo.Trim(),
                    PlayerCount = BGBook.Instance.Records.Records.Count(a => a.GameId == record.Id),
                    HasNote = record.Parm != null && record.Parm.Contains("wcount")
                });


            }

            // 按 yearInfo 倒序排序（假设 yearInfo 是年份字符串）
            var sortedRecords = buyRecords
                .OrderByDescending(r => r.YearInfo)
                .ToList();

            // 清空 ListView
            listView1.Items.Clear();

            // 添加排序后的数据到 ListView
            foreach (var record in sortedRecords)
            {
                var lvi = new ListViewItem(record.YearInfo);
                lvi.UseItemStyleForSubItems = false; //aaaaaaaa
                lvi.SubItems.Add(record.GameName);
                lvi.SubItems.Add("￥" + record.PriceInfo);
                lvi.SubItems.Add(record.OtherInfo);
                if (record.PlayerCount > 0)
                    lvi.SubItems.Add(record.PlayerCount.ToString());
                else
                    lvi.SubItems.Add("");
                if (record.HasNote)
                    lvi.SubItems.Add("是");
                else
                    lvi.SubItems.Add("");

                // 设置价格颜色
                lvi.SubItems[2].ForeColor = Color.Orange;

                listView1.Items.Add(lvi);
            }
        }
    }
}
