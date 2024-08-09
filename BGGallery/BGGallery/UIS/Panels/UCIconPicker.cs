using BGGallery.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BGGallery.UIS.Panels
{
    public partial class UCIconPicker : UserControl
    {
        class IconRect
        {
            public string Path;
            public Rectangle Rect;
            public Point Row;
            public int Id;
        }
        class IconGroupTitle
        {
            public string Name;
            public Point Location;
        }

        private int ColCount = 12; // 列数
        private int iconSize = 32; // 图标大小
        private int iconPadding = 5; // 图标之间的间距
        private int wordHeight = 32;

        private List<IconRect> toDrawIcons;
        private List<IconGroupTitle> titles;

        public Action<string> AfterSelect;

        private List<Tuple<string, string>> catalogs = new List<Tuple<string, string>>();

        public UCIconPicker()
        {
            InitializeComponent();
            
            toDrawIcons = new List<IconRect>();
            titles = new List<IconGroupTitle>();

            catalogs.Add(new Tuple<string, string>("Work", "任务"));
            catalogs.Add(new Tuple<string, string>("Beos", "Beos"));
            catalogs.Add(new Tuple<string, string>("Icon", "幻兽"));

            int idx = 0;
            if (BGBook.Instance.Cfg.RecentIcons.Count == 0)
            {
                var rowCount = 0;
                foreach (var catalog in catalogs)
                {
                    titles.Add(new IconGroupTitle { Name = catalog.Item2, Location = new Point(0, rowCount * (iconSize + iconPadding) + idx * wordHeight) });
                    rowCount += InitIconRegion(ResLoader.GetFileList(catalog.Item1), rowCount, rowCount * (iconSize + iconPadding) + wordHeight * (idx + 1));
                    idx++;
                }

                doubleBufferedPanel1.Height = rowCount * (iconSize + iconPadding) + wordHeight * 2;
            }
            else
            {
                titles.Add(new IconGroupTitle { Name = "最近", Location = new Point(0, 0) });
                var rowCount = InitIconRegion(BGBook.Instance.Cfg.RecentIcons, 0, wordHeight);

                idx++;
                foreach (var catalog in catalogs)
                {
                    titles.Add(new IconGroupTitle { Name = catalog.Item2, Location = new Point(0, rowCount * (iconSize + iconPadding) + idx * wordHeight) });
                    rowCount += InitIconRegion(ResLoader.GetFileList(catalog.Item1), rowCount, rowCount * (iconSize + iconPadding) + wordHeight * (idx + 1));
                    idx++;
                }

                doubleBufferedPanel1.Height = rowCount * (iconSize + iconPadding) + wordHeight * 4;
            }
            Panels.PanelBorders.InitBorder(this);
        }

        public void OnInit()
        {
            selIdex = 0;
            doubleBufferedPanel1.Focus();
        }

        private int InitIconRegion(List<string> imgList, int rowOff, int yOff)
        {
            int idx = 0;
            for (int row = 0; row < 99; row++)
            {
                for (int col = 0; col < ColCount; col++)
                {
                    int x = col * (iconSize + iconPadding) + iconPadding;
                    int y = row * (iconSize + iconPadding) + iconPadding;

                    Rectangle iconRect = new Rectangle(x, y + yOff, iconSize, iconSize);
                    if (idx < imgList.Count)
                        toDrawIcons.Add(new IconRect { Id= toDrawIcons.Count, Path = imgList[idx].Trim(), Row = new Point(col, row + rowOff), Rect = iconRect });
                    else
                        return row + 1;

                    idx++;
                }
            }
            return 0;
        }

        private void UCIconPicker_Paint(object sender, PaintEventArgs e)
        {
            int pickId = 0;
            foreach (var icon in toDrawIcons)
            {
                if (pickId == selIdex)
                    e.Graphics.FillRectangle(Brushes.Gray, icon.Rect);

                e.Graphics.DrawImage(ResLoader.Read(icon.Path.Replace('\\','/')), icon.Rect);
                pickId++;
            }
            foreach (var title in titles)
            {
                e.Graphics.DrawString(title.Name, doubleBufferedPanel1.Font, Brushes.DarkGray, title.Location.X, title.Location.Y + 3);
            }
        }

        private int selIdex = -1;
        private Point lastMousePosition;
        private void UCIconPicker_MouseMove(object sender, MouseEventArgs e)
        {    // 计算鼠标位移
            int deltaX = Math.Abs(e.X - lastMousePosition.X);
            int deltaY = Math.Abs(e.Y - lastMousePosition.Y);

            // 如果位移超过阈值，触发相应的逻辑
            if (deltaX < 5 && deltaY < 5)
            {
                // 在这里添加需要执行的逻辑
             //   Console.WriteLine($"Mouse moved: DeltaX={deltaX}, DeltaY={deltaY}");
                return;
            }
            lastMousePosition = e.Location;

            int nowId = -1;
            int pickId = 0;
            foreach (var icon in toDrawIcons)
            {
                if(icon.Rect.Contains(e.X, e.Y))
                {
                    nowId = pickId;
                    break;
                }
                pickId++;
            }

            HLog.Debug("UCIconPicker_MouseMove old={0} now={1}", selIdex, nowId);
            if (selIdex != nowId)
            {
                if (selIdex != -1)
                    doubleBufferedPanel1.Invalidate(toDrawIcons[selIdex].Rect);
                selIdex = nowId;
                if (selIdex != -1)
                    doubleBufferedPanel1.Invalidate(toDrawIcons[selIdex].Rect);
              //  doubleBufferedPanel1.Focus();
            }
            
        }

        private void UCIconPicker_MouseClick(object sender, MouseEventArgs e)
        {
            CheckResult();
        }

        private void CheckResult()
        {
            if (selIdex < 0)
                return;

            var nowPath = toDrawIcons[selIdex].Path;
            BGBook.Instance.Cfg.RecentIcons.Remove(nowPath);
            BGBook.Instance.Cfg.RecentIcons.Insert(0, nowPath);
            if (BGBook.Instance.Cfg.RecentIcons.Count > 10)
                BGBook.Instance.Cfg.RecentIcons.RemoveAt(BGBook.Instance.Cfg.RecentIcons.Count - 1);

            if(AfterSelect != null)
                AfterSelect(nowPath);

            PanelManager.Instance.HideBlackPanel();
        }

        private void MoveSelection(int xoff, int yoff)
        {
            if (selIdex == -1)
                selIdex = 0;

            var nowSel = toDrawIcons[selIdex];
            int nowId = selIdex;

            if (xoff > 0)
            {
                if (toDrawIcons.Count > selIdex + 1 && toDrawIcons[selIdex + 1].Row.Y == toDrawIcons[selIdex].Row.Y)
                    nowId = selIdex + 1;
            }
            else if (xoff < 0)
            {
                if (0 <= selIdex - 1 && toDrawIcons[selIdex - 1].Row.Y == toDrawIcons[selIdex].Row.Y)
                    nowId = selIdex - 1;
            }
            else if(yoff < 0)
            {
                var results = toDrawIcons.FindAll(a => a.Row.X == nowSel.Row.X && a.Row.Y < nowSel.Row.Y);
                if(results.Count > 0)
                {
                    results.Sort((a, b) => b.Row.Y - a.Row.Y);
                    nowId = results[0].Id;
                }
            }
            else if (yoff > 0)
            {
                var results = toDrawIcons.FindAll(a => a.Row.X == nowSel.Row.X && a.Row.Y > nowSel.Row.Y);
                if (results.Count > 0)
                {
                    results.Sort((a, b) => a.Row.Y - b.Row.Y);
                    nowId = results[0].Id;
                }
            }

            HLog.Debug("MoveSelection old={0} now={1}", selIdex, nowId);
            if (selIdex != -1)
                doubleBufferedPanel1.Invalidate(toDrawIcons[selIdex].Rect);
            selIdex = nowId;
            if (selIdex != -1)
                doubleBufferedPanel1.Invalidate(toDrawIcons[selIdex].Rect);
        }

        private void doubleBufferedPanel1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    MoveSelection(0, -1);
                    break;
                case Keys.Down:
                    MoveSelection(0, 1);
                    break;
                case Keys.Left:
                    MoveSelection(-1, 0);
                    break;
                case Keys.Right:
                    MoveSelection(1, 0);
                    break;
                case Keys.Enter:
                    CheckResult();
                    break;
                case Keys.Escape:
                    if (AfterSelect != null)
                        AfterSelect("");
                    PanelManager.Instance.HideBlackPanel();
                    break;
            }
        }
    }
}
