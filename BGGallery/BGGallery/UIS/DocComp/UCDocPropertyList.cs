using BGGallery.Model;
using BGGallery.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCDocPropertyList : UserControl
    {
        private int itemId;

        public Color BgColor
        {
            get { return doubleBufferedPanel1.BackColor; }
            set { doubleBufferedPanel1.BackColor = value; }
        }

        public UCDocPropertyList()
        {
            InitializeComponent();
        }

        public void Init(BGItemInfo itemInfo)
        {
            itemId = itemInfo.Id;
            var oldCtrList = new List<Control>();
            foreach (Control c in doubleBufferedPanel1.Controls)
                oldCtrList.Add(c);

            SuspendLayout();
            doubleBufferedPanel1.Controls.Clear();

            CheckCtrs(oldCtrList, itemInfo, "common", "别名", string.IsNullOrEmpty(itemInfo.NickName) ? itemInfo.Id.ToString() : itemInfo.NickName, (s) => { itemInfo.NickName = s; CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "multisel", "标签", itemInfo.Tag, (s) => { itemInfo.Tag = s; CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "star", "评分", itemInfo.Star.ToString(), (s) => { itemInfo.Star = int.Parse(s); CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "star", "新手评分", itemInfo.StarNewbie.ToString(), (s) => { itemInfo.StarNewbie = int.Parse(s); CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "multisel", "购入信息", itemInfo.BuyInfo, (s) => { itemInfo.BuyInfo = s; CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "select", "CatalogId", itemInfo.CatalogId.ToString(), (s) => { itemInfo.CatalogId = int.Parse(s); itemInfo.ColumnId = 0; CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "select", "ColumnId", itemInfo.ColumnId.ToString(), (s) => { itemInfo.ColumnId = int.Parse(s); CheckChange(); });

            Width = Math.Max(Width, 700 - 5);
            Height = doubleBufferedPanel1.Controls.Count * 32 + 10;
            ResumeLayout();

            doubleBufferedPanel1.Invalidate();
        }

        private void CheckCtrs(List<Control> cc, BGItemInfo itemInfo, string type, string k, string v, Action<string> onModify)
        {
            var found = FindCtr(cc, k);
            if(found == null)
            {
                if (type == "common")
                    found = new UCDocStringItem();
                else if (type == "multisel")
                    found = new UCDocMultiselItem();
                else if (type == "star")
                    found = new UCDocStarItem();
                else if (type == "select")
                    found = new UCDocSelectItem();

                var foundCtr = found as Control;
                foundCtr.Name = k;
                foundCtr.Height = 32;
            }
            found.OnModify = onModify;
            found.SetData(itemInfo, k, v);
            found.SetReadOnly(onModify == null);

            doubleBufferedPanel1.Controls.Add(found as Control);
            var foundCtr2 = found as Control;
            foundCtr2.Location = new Point(0, (doubleBufferedPanel1.Controls.Count -1)* 32);
            foundCtr2.Width = Math.Max(foundCtr2.Width, 450);
          //  foundCtr2.Dock = DockStyle.Top;
        }

        DateTime lastCheckTime;
        private void CheckChange()
        {
            if ((DateTime.Now - lastCheckTime).TotalSeconds > 60)
            {
                BGBook.Instance.Save();
                lastCheckTime = DateTime.Now;
            }
        }

        private IDocComp FindCtr(List<Control> cc, string k)
        {
            foreach(Control c in cc)
            {
                if (c.Name == k)
                    return c as IDocComp;
            }
            return null;
        }

        private void doubleBufferedPanel1_Paint(object sender, PaintEventArgs e)
        {
            if (itemId == 0)
                return;

            var width = 200;

            var cover = ImageBook.Instance.Load(ENV.CoverDir + itemId + "/cover.jpg");
            var height = width * cover.Height / cover.Width;
            e.Graphics.DrawImage(cover, Width - 220, (Height - height) / 2, 200, height);
        }
    }
}
