using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BGGallery;
using BGGallery.Properties;
using BGGallery.Utils;

namespace Text_Editor
{

    public partial class UCToolbar : UserControl
    {
        private Timer fadeInTimer;
        private bool toShow;
        private DateTime timeToFinish;
        private int lastTagCount;

        public UCToolbar()
        {
            InitializeComponent();

            fadeInTimer = new Timer();
            fadeInTimer.Interval = 10; // 设置速度
            fadeInTimer.Tick += new EventHandler(FadeInTimer_Tick);

            InitColorMenu();
        }

        private void InitColorMenu()
        {
            foreach (var cr in ColorTool.BaseColorTable)
            {
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(cr.Key);
                //    blueMenuItem.BackColor = Color.Blue;
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ImageTool.CreateSolidColorBitmap(Color.FromArgb(cr.Value.R, cr.Value.G, cr.Value.B), 32, 32);
                blueMenuItem.Tag = cr.Value;
                //     blueMenuItem.Click += ColorMenuItem_Click;
                colorStripDropDownButton.DropDownItems.Add(blueMenuItem);
            }

            List<string> colorNames = new List<string>();
            colorNames.AddRange(ColorTool.FullColorTable.Keys);
            colorNames.Sort((a, b) =>
            {
                var aColor = ColorTool.FullColorTable[a];
                var bColor = ColorTool.FullColorTable[b];

                // 计算亮度
                double luminanceA = 0.299 * aColor.R + 0.587 * aColor.G + 0.114 * aColor.B;
                double luminanceB = 0.299 * bColor.R + 0.587 * bColor.G + 0.114 * bColor.B;

                // 按照亮度从高到低排序
                return luminanceB.CompareTo(luminanceA);
            });

            foreach (var crName in colorNames)
            {
                var color = ColorTool.FullColorTable[crName];
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(crName);
                //    blueMenuItem.BackColor = Color.Blue;
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ImageTool.CreateSolidColorBitmap(Color.FromArgb(color.R, color.G, color.B), 32, 32);
                blueMenuItem.Tag = color;
                //     blueMenuItem.Click += ColorMenuItem_Click;

                var colorS = ColorClassifier.ClassifyColor(color);
                var subItem = colorStripDropDownButton.DropDownItems[(int)colorS] as ToolStripMenuItem;
                subItem.DropDownItems.Add(blueMenuItem);
            }

            foreach (ToolStripMenuItem cr in toolStripDropDownButtonSwitch.DropDownItems)
            {
                cr.BackColor = Color.FromArgb(24, 24, 24);
                cr.ForeColor = Color.White;
                cr.Image = Resources.brush;
            }
        }

        public void OnLoadFile()
        {
            InitCataMenu();
        }

        private void InitCataMenu()
        {
            var tagItems = BGBook.Instance.FindItemInfosByTag("汇总", "加密"); //加密文件不能进汇总
            if (lastTagCount == tagItems.Count)
                return;

            lastTagCount = tagItems.Count;
            toolStripDropDownButtonCata.DropDownItems.Clear();
            foreach (var cr in tagItems)
            {
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(cr.Title);
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ResLoader.Read(cr.Icon);
                blueMenuItem.Tag = cr.Id;
                //     blueMenuItem.Click += ColorMenuItem_Click;
                toolStripDropDownButtonCata.DropDownItems.Add(blueMenuItem);
            }
        }

        public void DelayVisible(bool visible, int ms)
        {
            if (Visible == visible)
                return;

            fadeInTimer.Stop();
            toShow = visible;
            timeToFinish = DateTime.Now.AddMilliseconds(ms);
            fadeInTimer.Start();
        }

        private void FadeInTimer_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now > timeToFinish)
            {
                fadeInTimer.Stop();
                Visible = toShow;
            }
          
        }
    }

}
