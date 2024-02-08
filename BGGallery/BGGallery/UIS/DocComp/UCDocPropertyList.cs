using BGGallery.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BGGallery.UIS
{
    public partial class UCDocPropertyList : UserControl
    {
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
            var oldCtrList = new List<Control>();
            foreach (Control c in doubleBufferedPanel1.Controls)
                oldCtrList.Add(c);
            doubleBufferedPanel1.Controls.Clear();

            // 需要逆序
            CheckCtrs(oldCtrList, "common", "CatalogId", itemInfo.CatalogId.ToString(), (s) => itemInfo.CatalogId = int.Parse(s));
            CheckCtrs(oldCtrList, "common", "ColumnId", itemInfo.ColumnId.ToString(), (s) => itemInfo.ColumnId = int.Parse(s));
            CheckCtrs(oldCtrList, "multisel", "购入信息", itemInfo.BuyInfo, (s) => itemInfo.BuyInfo = s);
            CheckCtrs(oldCtrList, "star", "新手评分", itemInfo.StarNewbie.ToString(), (s) => itemInfo.StarNewbie = int.Parse(s));
            CheckCtrs(oldCtrList, "star", "评分", itemInfo.Star.ToString(), (s) => itemInfo.Star = int.Parse(s));
            CheckCtrs(oldCtrList, "multisel", "标签", itemInfo.Tag, (s) => itemInfo.Tag = s);
            CheckCtrs(oldCtrList, "common", "别名", string.IsNullOrEmpty(itemInfo.NickName) ? itemInfo.Id.ToString() : itemInfo.NickName, (s) => itemInfo.NickName = s);

            Width = 700 - 5;
            Height = doubleBufferedPanel1.Controls.Count * 32 + 10;
        }

        private void CheckCtrs(List<Control> cc, string type, string k, string v, Action<string> onModify)
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

                var foundCtr = found as Control;
                foundCtr.Name = k;
                foundCtr.Height = 32;
            }
            found.OnModify = onModify;
            found.SetData(k, v);
            found.SetReadOnly(onModify == null);

            doubleBufferedPanel1.Controls.Add(found as Control);
            var foundCtr2 = found as Control;
            foundCtr2.Location = new Point(0, doubleBufferedPanel1.Controls.Count * 32);
            foundCtr2.Width = 700 - 5;
            foundCtr2.Dock = DockStyle.Top;
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

    }
}
