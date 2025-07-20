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
                item.SubItems.Add(bgInfo.Title);              // 桌游名
                item.SubItems.Add(record.Details);             // 详情

                listView1.Items.Add(item);
            }
        }
    }
}
