using BGGallery.Model;
using BGGallery.Properties;
using BGGallery.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static BGGallery.UCTipColumn;

namespace BGGallery
{
    public partial class UCRowCommon : UserControl, IRowItem
    {
        public int ItemId { get; set; }
        public event MouseEventHandler NLMouseClick;
        public event MouseEventHandler NLMouseDown;
        public event MouseEventHandler NLMouseUp;

        public RJControls.RJDropdownMenu Menu { get; set; }
        public UCTipColumn ColumnCtr { get; set; }

        public virtual RowItemType Type { get { return RowItemType.Common; } }

        private Rectangle menuRegion;

        private bool selected;
        protected Image icon;
        private string title;
        protected bool isMouseOver;

        public BGItemInfo itemInfo { get; set; }
        private bool ShowCover;
        private int imageHeight = 100;

        public UCRowCommon()
        {
            InitializeComponent();

            menuRegion = new Rectangle(Width - 40, Height / 2 - Resources.menu.Height / 2, 34, 31);
        }

        public virtual void AfterInit()
        {
            UpdateView();
        }

        protected virtual void UpdateView()
        {
            Height = 47;

            if (File.Exists(ENV.CoverDir + ItemId + "/cover.jpg"))
            {
                ShowCover = true;
                Height += imageHeight;
            }
        }

        public virtual void OnRemove()
        {

        }

        public void SetTitle(string str)
        {
            title = str;
        }

        public void SetIcon(string icon1)
        {
            icon = ResLoader.Read(icon1);
        }

        private void UCRowCommon_MouseClick(object sender, MouseEventArgs e)
        {
            if (menuRegion.Contains(e.Location) && Menu != null)
            {
                Menu.Show(this, menuRegion.X + menuRegion.Width, menuRegion.Y);
                Menu.Tag = ItemId;
                Menu.Bind = ColumnCtr;
                return;
            }

            if (NLMouseClick != null)
                NLMouseClick(this, e);

            UpdateView();
        }

        private void UCRowCommon_MouseDown(object sender, MouseEventArgs e)
        {
            if (NLMouseDown != null)
                NLMouseDown(this, e);
        }

        private void UCRowCommon_MouseUp(object sender, MouseEventArgs e)
        {
            if (NLMouseUp != null)
                NLMouseUp(this, e);
        }
        private void UCRowCommon_MouseEnter(object sender, EventArgs e)
        {
            isMouseOver = true;
            // 重新绘制控件
            this.Invalidate();
        }

        private void UCRowCommon_MouseLeave(object sender, EventArgs e)
        {
            isMouseOver = false;
            // 重新绘制控件
            this.Invalidate();
        }

        public void SetSelect(bool sel)
        {
            selected = sel;
            Invalidate();
        }

        protected void DrawBase(PaintEventArgs e)
        {
            if (icon != null)
                e.Graphics.DrawImage(icon, 1, 5, 32, 32);

            var size = itemInfo.GetFileLength();
            e.Graphics.DrawString(title, Font, Brushes.WhiteSmoke, 35, 8);
            if (size > 0)
                e.Graphics.DrawString(string.Format("{0:0.0}k", (float)size / 1024), Font, Brushes.Yellow, e.Graphics.MeasureString(title, Font).Width + 35 + 30, 8);

            if (isMouseOver)
                e.Graphics.DrawImage(Resources.menu, menuRegion);

            if (selected)
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, Width - 1, Height - 1);
        }

        private void DrawStars(Graphics g, int val, bool isNewBie, int startX, int startY)
        {
            var fullCount = val / 10;

            bool needHalf = false;

            if ((val % 10) >= 5)
                needHalf = true;

            List<string> starList = new List<string>();
            for (int i = 0; i < fullCount; i++)
                starList.Add("full");
            if (needHalf)
                starList.Add("half");

            foreach (string type in starList)
            {
                if (type == "full")
                    g.DrawImage(!isNewBie ? Resources.stary : Resources.starn, startX, startY, 15, 15);
                else if (type == "half")
                    g.DrawImage(!isNewBie ? Resources.stary1 : Resources.starn1, startX, startY, 15, 15);

                startX += 15;
            }
        }

        protected virtual void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            if (ShowCover)
            {
                try
                {
                    var cover = ImageBook.Instance.Load(ENV.CoverDir + ItemId + "/cover.jpg");
                    if (cover != null)
                    {
                        // 计算源矩形和目标矩形  
                        int sourceWidth = cover.Width; // 源图像的宽度  
                        int sourceHeight = cover.Height; // 源图像的高度  

                        Rectangle destRect = new Rectangle(0, Height - imageHeight, Width, imageHeight);
                        var sourceHeight2 = destRect.Height * sourceWidth / destRect.Width;
                        // 定义源矩形，它表示图像中要绘制的部分  
                        Rectangle sourceRect = new Rectangle(0, (sourceHeight - sourceHeight2) / 2, sourceWidth, sourceHeight2);

                        // 使用 DrawImage 方法绘制图像的一部分  
                        e.Graphics.DrawImage(cover, destRect, sourceRect, GraphicsUnit.Pixel);

                        if (itemInfo.Star > 0)
                            DrawStars(e.Graphics, itemInfo.Star, false, 3, Height - imageHeight + 3);
                        if (itemInfo.StarNewbie > 0)
                            DrawStars(e.Graphics, itemInfo.StarNewbie, true, 3, Height - imageHeight + 3+20);
                    }

                }
                catch(Exception ex)
                {
                    HLog.Error(ex);
                }
             
            }
            DrawBase(e);
        }

        private int DrawItem(Graphics g, Image img, int val, int posX)
        {
            if (val <= 0)
                return 0;
            g.DrawImage(img, posX, 35 + 2, 20, 20);
            g.DrawString(val.ToString(), Font, Brushes.Yellow, posX + 23, 35);
            return 1;
        }

    }
}
