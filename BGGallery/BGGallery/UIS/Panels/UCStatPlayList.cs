using BGGallery.Utils;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    public partial class UCStatPlayList : UserControl
    {
        public UCStatPlayList()
        {
            InitializeComponent();
        }

        public void Init()
        {
            // 假设 itemInfo 是从外部传入或已绑定的数据
            var rs = BGBook.Instance.Records.Records;
            rs.Sort((a, b) => b.BeginTime.CompareTo(a.BeginTime));

            if (rs.Count == 0)
                return;

            // 清空旧数据
            listView1.Items.Clear();

            foreach (var record in rs)
            {
                var bgInfo = BGBook.Instance.GetItem(record.GameId);
                // 假设 itemInfo.Name 是桌游名
                var item = new ListViewItem(TimeTool.UnixTimeToDateTime(record.BeginTime).ToString("yyyy/MM/dd")); // 时间
                item.UseItemStyleForSubItems = false; //aaaaaaaa
                item.SubItems.Add(bgInfo.Title);              // 桌游名
                item.SubItems.Add(record.Details);             // 详情
                // 解析爸爸和旺仔的分数并设置行颜色
                var match = System.Text.RegularExpressions.Regex.Match(record.Details, @"爸爸\s*(\d+)\s*旺仔\s*(\d+)");
                if (match.Success)
                {
                    if (int.TryParse(match.Groups[1].Value, out int dadScore) && int.TryParse(match.Groups[2].Value, out int wangzaiScore))
                    {
                        if (wangzaiScore > dadScore)
                            item.SubItems[2].ForeColor = System.Drawing.Color.Blue;
                        else if (dadScore > wangzaiScore)
                            item.SubItems[2].ForeColor = System.Drawing.Color.Red;
                        // 分数相等时不改变颜色
                    }
                }
                match = System.Text.RegularExpressions.Regex.Match(record.Details, @"旺仔\s*(\d+)\s*爸爸\s*(\d+)");
                if (match.Success)
                {
                    if (int.TryParse(match.Groups[1].Value, out int wangzaiScore) && int.TryParse(match.Groups[2].Value, out int dadScore))
                    {
                        if (wangzaiScore > dadScore)
                            item.SubItems[2].ForeColor = System.Drawing.Color.Blue;
                        else if (dadScore > wangzaiScore)
                            item.SubItems[2].ForeColor = System.Drawing.Color.Red;
                        // 分数相等时不改变颜色
                    }
                }
                listView1.Items.Add(item);
            }
        }
    }
}
