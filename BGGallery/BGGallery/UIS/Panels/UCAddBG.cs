using BGGallery.Utils;
using RJControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCAddBG : UserControl
    {
        public Action<GameInfo> OnCustomTextChanged;
        class SearchData
        {
            public string Title;
            public string GameId;
            public GameInfo Info;
        }

        private ListViewItem selectLine;
        private List<SearchData> searchResults = new List<SearchData>();

        public UCAddBG()
        {
            InitializeComponent();

            textBox1.OnLoad();

            Panels.PanelBorders.InitBorder(this);
        }

        public void OnInit(string keyword)
        {
            textBox1.Text = keyword;
            textBox1.Focus();
            if (string.IsNullOrEmpty(keyword))
                listView1.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchAct();
        }

        private void SearchAct()
        {
            DelayedExecutor.Trigger("bgsearch", 0.3f, async () =>
            {
                listView1.Visible = false; //防止中途绘制出现奇怪问题
                searchResults.Clear();
                var searchTxt = textBox1.Text;
                if (string.IsNullOrWhiteSpace(searchTxt))
                {
                    listView1.VirtualListSize = 0;
                    return;
                }

                var results = await BGInfoSyncer.ExtractGameInfoAsync(searchTxt);

                foreach (var itemInfo in results)
                {
                    searchResults.Add(new SearchData { GameId = itemInfo.Id, Title = itemInfo.Title.ToString(), Info = itemInfo });
                }

                selectLine = null;
                listView1.VirtualListSize = searchResults.Count;
                listView1.Visible = true;
            });
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= 0 && e.ItemIndex < searchResults.Count)
            {
                ListViewItem item = new ListViewItem(searchResults[e.ItemIndex].Title);
                e.Item = item;
            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var lineInfo = searchResults[e.ItemIndex];
            using (var ft = new Font("微软雅黑", 9.5f))
                e.Graphics.DrawString(lineInfo.GameId + "."+ lineInfo.Title, ft, Brushes.White, e.Bounds.X + 8 + 30, e.Bounds.Y + 10);
        }

        private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            var destRT = new Rectangle(e.Bounds.X + 5, e.Bounds.Y + 5, e.Bounds.Width, e.Bounds.Height - 10);
            if (selectLine != null && e.ItemIndex == selectLine.Index)
            {
                using (var b = new SolidBrush(Color.FromArgb(60, 60, 60)))
                    e.Graphics.FillRectangle(b, destRT);
            }
        }


        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {    // 获取鼠标在 ListView 控件内的坐标
            Point localPoint = listView1.PointToClient(Cursor.Position);

            // 使用 HitTest 方法判断鼠标下方的项目
            ListViewHitTestInfo hitTest = listView1.HitTest(localPoint);
            if (hitTest.Item != null)
            {if (selectLine != null)
                    listView1.Invalidate(selectLine.Bounds);
                selectLine = hitTest.Item;
                listView1.Invalidate(selectLine.Bounds);
                // 在这里你可以处理鼠标悬停在项目上的逻辑
                // 例如获取项目的信息，更新UI等
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var lineInfo = searchResults[selectLine.Index];
            if (OnCustomTextChanged != null)
                OnCustomTextChanged(lineInfo.Info);

            PanelManager.Instance.HideBlackPanel();
        }

    }
}
