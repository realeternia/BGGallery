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
        private int expIndex; //0是本体

        public Color BgColor
        {
            get { return doubleBufferedPanel1.BackColor; }
            set { doubleBufferedPanel1.BackColor = value; }
        }

        public UCDocPropertyList()
        {
            InitializeComponent();
        }

        public void Init(BGItemInfo itemInfo, int expInde)
        {
            itemId = itemInfo.Id;
            expIndex = expInde;
            var oldCtrList = new List<Control>();
            foreach (Control c in doubleBufferedPanel1.Controls)
                oldCtrList.Add(c);

            SuspendLayout();
            doubleBufferedPanel1.Controls.Clear();

            CheckCtrs(oldCtrList, itemInfo, "common", "别名", string.IsNullOrEmpty(itemInfo.NickName) ? itemInfo.Id.ToString() : itemInfo.NickName, (s) => { itemInfo.NickName = s; CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "multisel", "标签", itemInfo.Tag, (s) => { itemInfo.SetTag(s); CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "star", "评分", itemInfo.Star.ToString(), (s) => { itemInfo.Star = int.Parse(s); CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "star", "新手评分", itemInfo.StarNewbie.ToString(), (s) => { itemInfo.StarNewbie = int.Parse(s); CheckChange(); });
            CheckCtrs(oldCtrList, itemInfo, "button", "其他信息", "", (s) => { CheckChange(); });
            //CheckCtrs(oldCtrList, itemInfo, "multisel", "购入信息", itemInfo.BuyInfo, (s) => { itemInfo.BuyInfo = s; CheckChange(); });

            Width = Math.Max(Width, 700 - 5);
            Height = doubleBufferedPanel1.Controls.Count * 32 + 10;
            ResumeLayout();

            doubleBufferedPanel1.Invalidate();
        }

        public void SetExpIndex(int expInde)
        {
            expIndex = expInde;
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
                else if (type == "button")
                    found = new UCDocButtonItem();

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

            // 加载经验图片（如果存在）  
            Image img = null;
            if (expIndex > 0)
            {
                img = ImageBook.Instance.Load(ENV.ImgDir + itemId + "/exp" + expIndex + ".jpg");
            }

            // 如果没有经验图片或者加载失败，则加载封面图片  
            if (img == null)
            {
                img = ImageBook.Instance.Load(ENV.ImgDir + itemId + "/cover.jpg");
            }

            // 如果图片加载成功  
            if (img != null)
            {
                int maxWidth = 200;
                // 计算缩放比例  
                float scaleWidth = (float)maxWidth / img.Width;
                float scaleHeight = (float)Height / img.Height;

                if (scaleHeight < scaleWidth)
                    scaleWidth = scaleHeight;

                // 计算缩放后的图片尺寸  
                int scaledWidth = (int)(img.Width * scaleWidth);
                int scaledHeight = (int)(img.Height * scaleWidth);

                // 计算图片绘制的起始位置，确保图片在目标区域内居中  
                int x = Math.Max(0, Width - 220); // 减去220是为了在右侧留出空间  
                int y = (Height - scaledHeight) / 2;

                // 在指定位置绘制图片  
                e.Graphics.DrawImage(img, new Rectangle(x, y, scaledWidth, scaledHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            }
        }
    }
}
