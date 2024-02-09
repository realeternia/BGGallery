using BGGallery.Utils;
using RJControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCSearch : UserControl
    {
        class SearchData
        {
            public string Title;
            public string Line;
            public int LineIndex;
            public DateTime CreateTime;
        }

        private ListViewItem selectLine;
        private List<SearchData> searchResults = new List<SearchData>();
        public Form1 Form1 { get; set; }
        private DateTime searchBegin;

        public UCSearch()
        {
            InitializeComponent();

            textBox1.OnLoad();
        }

        public void OnInit(string keyword)
        {
            textBox1.Text = keyword;
            textBox1.Focus();
            if (string.IsNullOrEmpty(keyword))
                listView1.Hide();
            rjComboBox1.SelectedIndex = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchAct();
        }

        private void SearchAct()
        {
            DelayedExecutor.Trigger("ucsearch", 0.3f, () =>
            {
                listView1.Visible = false; //防止中途绘制出现奇怪问题
                searchResults.Clear();
                var searchTxt = textBox1.Text;
                if (string.IsNullOrWhiteSpace(searchTxt))
                {
                    listView1.VirtualListSize = 0;
                    return;
                }

                foreach (var itemInfo in BGBook.Instance.Items)
                {
                    var fullPath = string.Format("{0}/{1}.rtf", ENV.SaveDir, itemInfo.Id);
                    if (itemInfo.IsEncrypt())
                        fullPath = fullPath.Replace(".rtf", ".rz");

                    if(File.Exists(fullPath))
                    {
                        var fi = new FileInfo(fullPath);
                        if (fi.LastWriteTime < searchBegin)
                            continue;

                        var itemIdStr = fi.Name;

                        if (itemInfo.Title.Contains(searchTxt))
                            searchResults.Add(new SearchData { Line = itemInfo.Title, Title = itemIdStr, CreateTime = fi.LastWriteTime, LineIndex = 0 });
                        if (itemInfo.Tag.Contains(searchTxt))
                            searchResults.Add(new SearchData { Line = itemInfo.Tag, Title = itemIdStr, CreateTime = fi.LastWriteTime, LineIndex = 0 });

                        string plainText = RtfModifier.ReadRtfPlainText(itemInfo.Id);

                        int lineid = 0;
                        foreach (var line in plainText.Split('\n'))
                        {
                            if (line.IndexOf(searchTxt) >= 0)
                                searchResults.Add(new SearchData { Line = line, Title = itemIdStr, CreateTime = fi.LastWriteTime, LineIndex = lineid + 1 });
                            lineid++;
                        }
                    }
                    else
                    {
                        if (itemInfo.Title.Contains(searchTxt))
                            searchResults.Add(new SearchData { Line = itemInfo.Title, Title = itemInfo.Id.ToString(), CreateTime = DateTime.MinValue, LineIndex = 0 });
                        if (itemInfo.Tag != null && itemInfo.Tag.Contains(searchTxt))
                            searchResults.Add(new SearchData { Line = itemInfo.Tag, Title = itemInfo.Id.ToString(), CreateTime = DateTime.MinValue, LineIndex = 0 });
                    }
                }

                searchResults.Sort((a, b) => (int)(b.CreateTime - a.CreateTime).TotalSeconds);
                selectLine = null;
                listView1.VirtualListSize = searchResults.Count;
                listView1.Visible = true;
            });
        }

        private void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex >= 0 && e.ItemIndex < searchResults.Count)
            {
                ListViewItem item = new ListViewItem(searchResults[e.ItemIndex].Line);
                item.SubItems.Add(searchResults[e.ItemIndex].Title);

                e.Item = item;
            }
        }

        private static void DrawLine(DrawListViewSubItemEventArgs e, string fullText, string searshText, Font font)
        {
            // 逐字绘制
            float x = e.Bounds.X + 5;
            float y = e.Bounds.Y + 40;

            List<int> matchIndx = new List<int>();

            foreach (Match match in Regex.Matches(fullText, searshText))
            {
                int index = match.Index;
                for (int i = 0; i < searshText.Length; i++)
                    matchIndx.Add(index + i);
            }

            for (int i = 0; i < fullText.Length; i++)
            {
                var c = fullText[i];
                // 随机选择一个画刷
                var brush = matchIndx.Contains(i) ? Brushes.WhiteSmoke : Brushes.DimGray;

                // 设置字符之间的间距
                float characterSpacing = -5.0f; // 调整字符之间的距离

                var sf = new StringFormat
                {
                    FormatFlags = StringFormatFlags.MeasureTrailingSpaces,
                    LineAlignment = StringAlignment.Near,
                    Alignment = StringAlignment.Near
                };
                // e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;
                e.Graphics.DrawString(c.ToString(), font, brush, x, y, sf);

                // 更新 x 位置
                x += e.Graphics.MeasureString(c.ToString(), font).Width + characterSpacing;

                if (x > e.Bounds.X + e.Bounds.Width - 10)
                    break;

            }
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            var lineInfo = searchResults[e.ItemIndex];
            var itemInfo = BGBook.Instance.GetItem(int.Parse(lineInfo.Title.Replace(".rtf", "")));
            if (itemInfo != null)
            {
                e.Graphics.DrawImage(ResLoader.Read(itemInfo.Icon), e.Bounds.X + 8, e.Bounds.Y + 10, 24, 24);
                e.Graphics.DrawString(string.Format("{2} ({0}/{1} Ln:{3})", itemInfo.GetCatalog(), itemInfo.GetColumn(), itemInfo.Title, lineInfo.LineIndex),
                    e.Item.Font, Brushes.White, e.Bounds.X + 8 + 30, e.Bounds.Y + 10, StringFormat.GenericDefault);
            }

            using (var ft = new Font("微软雅黑", 9.5f))
                DrawLine(e, e.SubItem.Text, textBox1.Text, ft);
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
            var itemInfo = BGBook.Instance.GetItem(int.Parse(lineInfo.Title.Replace(".rtf", "")));

            Form1.ShowPaperPadEx(itemInfo.CatalogId, itemInfo, lineInfo.Line.Trim());

            PanelManager.Instance.HideBlackPanel();
        }

        private void rjComboBox1_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            if (rjComboBox1.SelectedIndex == 0) //一周
                searchBegin = DateTime.Now.Subtract(TimeSpan.FromDays(7));
            else if (rjComboBox1.SelectedIndex == 1) //一周
                searchBegin = DateTime.Now.Subtract(TimeSpan.FromDays(30));
            else
                searchBegin = DateTime.Now.Subtract(TimeSpan.FromDays(365 * 30));

            if (!string.IsNullOrEmpty(textBox1.Text))
                SearchAct();
        }

    }
}
