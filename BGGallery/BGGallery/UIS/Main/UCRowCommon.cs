﻿using BGGallery.Model;
using BGGallery.Properties;
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

            if (File.Exists(ENV.CoverDir + ItemId + ".jpg"))
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
            e.Graphics.DrawString(title, Font, Brushes.WhiteSmoke, 35, 8);

            if (isMouseOver)
                e.Graphics.DrawImage(Resources.menu, menuRegion);

            if (selected)
                e.Graphics.DrawRectangle(Pens.LightBlue, 0, 0, Width - 1, Height - 1);
        }

        protected virtual void UCRowCommon_Paint(object sender, PaintEventArgs e)
        {
            if (ShowCover)
            {
                var cover = Image.FromFile(ENV.CoverDir + ItemId + ".jpg");
                if (cover != null)
                {
                    // 计算源矩形和目标矩形  
                    int sourceWidth = cover.Width; // 源图像的宽度  
                    int sourceHeight = cover.Height; // 源图像的高度  

                    // 定义源矩形，它表示图像中要绘制的部分  
                    Rectangle sourceRect = new Rectangle(0, (sourceHeight - imageHeight) / 2, sourceWidth, imageHeight);

                    // 定义目标矩形，它表示在绘图表面上绘制图像的位置和大小  
                    Rectangle destRect = new Rectangle(0, Height - imageHeight, Width, imageHeight);

                    // 使用 DrawImage 方法绘制图像的一部分  
                    e.Graphics.DrawImage(cover, destRect, sourceRect, GraphicsUnit.Pixel);

                  //  e.Graphics.DrawImage(cover, 0, Height - Width * 2 / 3, Width, Width * 2 / 3);
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
