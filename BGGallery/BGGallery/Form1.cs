using BGGallery.Model;
using BGGallery.Model.Types;
using BGGallery.UIS;
using BGGallery.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using YamlDotNet.Serialization;
using static BGGallery.UCTipColumn;

namespace BGGallery
{
    public partial class Form1 : Form
    {
        private UCCatalogItem nowCatalogCtr = null;
        private BGCatalogInfo nowCatalog = null;

        private List<UCTipColumn> columnCtrs = new List<UCTipColumn>();

        private IRowItem nowRowItemCtr = null; //当前选择row
        private BGItemInfo nowRowItem = null;
        
        private bool textChangeLock;
        private InputTextBox colAddInputBox;

        public RJControls.RJDropdownMenu CustomMenuStripCol { get { return rjDropdownMenuCol; } }

        public Form1()
        {
            InitializeComponent();

            dasayEditor1.ParentC = this;
            imageGallery1.ParentC = this;

            ucTipAdd1.button1.Click += columnNew_Click;
            ucListSelectBar1.OnIndexChanged = OnSelectBarIndexChanged;
            ucListSelectBar2.OnIndexChanged = OnSelectBar2IndexChanged;
            dasayEditor1.richTextBox1.LinkClicked += new LinkClickedEventHandler(this.richTextBox1_LinkClicked);
            ucDocTopBar1.buttonFormer.Click += ButtonFormer_Click;
            ucDocTopBar1.buttonNext.Click += ButtonNext_Click;
            ucDocTopBar1.buttonExpAdd.Click += ButtonExpAdd_Click;

            // 先隐藏面板
            HidePaperPad();

            panelBlack.BackColor = Color.FromArgb(128, Color.Black);

            PanelManager.Instance.Init(this);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            FontMgr.Init();

            textBoxCatalogTitle.OnLoad();
            textBoxRowItemTitle.OnLoad();

            colAddInputBox = new InputTextBox();
            colAddInputBox.OnCustomTextChanged = Hintbox_OnCustomTextChanged;

            if (File.Exists(ENV.BaseDir+ "/memo.yaml"))
            {
                var yaml = File.ReadAllText(ENV.BaseDir + "/memo.yaml", Encoding.UTF8);

                var deserializer = new DeserializerBuilder().Build();
                BGBook.Instance = deserializer.Deserialize<BGBook>(yaml);
                if (BGBook.Instance.Cfg == null)
                    BGBook.Instance.Cfg = new BGBookCfg();
                var itm = RefreshCatalogs();
                if (itm != null)
                    SelectCatalogItem(itm);
            }
            TagsInfoManager.Init();

            rjDropdownMenuCatlog.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuCatlog.MenuItemTextColor = Color.White;
            rjDropdownMenuCatlog.MenuItemHeight = 25;
            rjDropdownMenuCol.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuCol.MenuItemTextColor = Color.White;
            rjDropdownMenuCol.MenuItemHeight = 25;

            rjDropdownMenuRow.PrimaryColor = Color.SeaGreen;
            rjDropdownMenuRow.MenuItemTextColor = Color.White;
            rjDropdownMenuRow.MenuItemHeight = 25;

            InitMenu();

            HLog.Info("main form load finish");
           // DeleteRemovedFiles();
        }

        //添加一个新的分类
        private void ucCatalogNew_Click(object sender, System.EventArgs e)
        {
            var newCat = BGBook.Instance.AddCatalog();
            RefreshCatalogs();

            var ctrs = flowLayoutPanel1.Controls.Find(newCat.Id.ToString(), false);
            if (ctrs.Length > 0)
                SelectCatalogItem(ctrs[0] as UCCatalogItem);

            textBoxCatalogTitle.Focus(); //光标停留到输入栏
        }

        private void ucCatalogSetup_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowSetup();
        }


        //添加一个新的栏目
        private void columnNew_Click(object sender, System.EventArgs e)
        {
            if (nowCatalog == null)
                return;

            Point absoluteLocation = ucTipAdd1.PointToScreen(new Point(0, 0));

            PanelManager.Instance.ShowBlackPanel(colAddInputBox, absoluteLocation.X - Location.X, absoluteLocation.Y - Location.Y, 1);
            colAddInputBox.Focus();
        }

        private void Hintbox_OnCustomTextChanged(string s)
        {
            var newId = nowCatalog.AddColumn(s);
            RefreshColumns(nowCatalog.Id);

            panel1.Controls.Find("col" + newId.ToString(), false);
        }

        private UCCatalogItem RefreshCatalogs()
        {
            flowLayoutPanel1.Controls.Clear();

            UCCatalogItem firstMenu = null;
            foreach(var catalog in BGBook.Instance.CatalogInfos)
            {
                var newItem = new UCCatalogItem();
                newItem.Id = catalog.Id;
                newItem.Name = catalog.Id.ToString();
                newItem.Title = catalog.Name;
                newItem.Click += CatalogItem_Click;
                newItem.Width = flowLayoutPanel1.Width - 5;
                newItem.Menu = rjDropdownMenuCatlog;
                flowLayoutPanel1.Controls.Add(newItem);

                newItem.AfterInit();

                if(firstMenu == null)
                    firstMenu = newItem;
            }
            nowCatalogCtr = null;
            return firstMenu;
        }

        private void CatalogItem_Click(object sender, System.EventArgs e)
        {
            var mItem = sender as UCCatalogItem;
            if (nowCatalogCtr == mItem)
                return;

            SelectCatalogItem(mItem);
        }

        private void SelectCatalogItem(UCCatalogItem mItem)
        {
            textChangeLock = true;
            textBoxCatalogTitle.TrueText = mItem.Title;
            textChangeLock = false;

            if (nowCatalogCtr != null)
                nowCatalogCtr.SetSelect(false);
            nowCatalogCtr = mItem;
            mItem.SetSelect(true);

            RefreshColumns(mItem.Id); //todo 这个现在每次都刷

            if (viewStack1.SelectedIndex == 1)
            {
                listMouseOnLine = null;
                var listCachedItems = BGBook.Instance.GetItemsByCatalog(catalogId);
                listView1.Items.Clear();
                foreach(var item in listCachedItems)
                {
                    var listItem = new ListViewItem(item.Title);
                    listItem.SubItems.Add(item.Star.ToString());
                    listItem.SubItems.Add(item.StarNewbie.ToString());
                    listItem.SubItems.Add(item.GetModifyTime().ToString("yyyy-MM-dd"));
                    listItem.Tag = item.Id;
                    listView1.Items.Add(listItem);
                }
            }
        }

        private int catalogId;
        private void RefreshColumns(int cid)
        {
            var ucIndex = 1;
            panel1.Visible = false;
            textBoxCatalogTitle.Visible = false;
            foreach(var ctr in panel1.Controls)
            {
                var columnCtr = ctr as UCTipColumn;
                if (columnCtr != null)
                    columnCtr.ReleaseAllLabels();
            }
            panel1.Controls.Clear();
            columnCtrs.Clear();

            if(cid > 0)
            {
                catalogId = cid;
                nowCatalog = BGBook.Instance.GetCatalog(cid);
                var maxHeight = 0;
                foreach (var column in nowCatalog.Columns)
                {
                    var newItem = AddUCColumn(column.Id, ucIndex, column.Title, Color.FromArgb(column.BgColor));
                    columnCtrs.Add(newItem);
                    ucIndex++;

                    maxHeight = Math.Max(maxHeight, newItem.ItemHeight);
                }
                panel1.Controls.Add(ucTipAdd1);
                ucTipAdd1.Location = new System.Drawing.Point((ucIndex - 1) * 270, 0);
                panel1.Width = (ucIndex - 1) * 270 + ucTipAdd1.Width;
                panel1.Height = maxHeight;
                panel1.Visible = true;
                textBoxCatalogTitle.Visible = true;
            }
 
        }

        private UCTipColumn AddUCColumn(int itid, int ucIndex, string title, Color c)
        {
            var columnUC = new UCTipColumn();

            columnUC.Height = panel1.Height - 1;
            columnUC.Name = "col" + itid;
            panel1.Controls.Add(columnUC);
            columnUC.Location = new Point((ucIndex - 1) * 270, 0);
            columnUC.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            columnUC.Width = 270;
            columnUC.ParentC = this;

            columnUC.RowMenu = rjDropdownMenuRow;
            columnUC.Init(nowCatalog.Id, itid, title, c);
            columnUC.OnClickItem += OnRowItemClick;

            panel1.Width = (ucIndex - 2) * 270;

            return columnUC;
        }

        private void OnRowItemClick(object sender, EventItemClickArgs args)
        {
            if (args == null)
            {
                HidePaperPad();
                return;
            }

            ShowPaperPad(BGBook.Instance.GetItem(args.ItemId));
            if (args.FocusTitle)
                textBoxRowItemTitle.Focus();
        }

        //外部调用展示面板
        public void ShowPaperPadEx(BGItemInfo item, ShowPaperParm parm)
        {
            foreach (UCCatalogItem ctr in flowLayoutPanel1.Controls)
            {
                if (ctr != null && ctr.Id == item.CatalogId)
                    SelectCatalogItem(ctr);
            }

            ShowPaperPad(item, parm);
        }

        private void ShowPaperPad(BGItemInfo itemInfo, ShowPaperParm parm = null)
        {
            if(itemInfo == null)
            {
                HidePaperPad();
                return;
            }

            if (nowRowItem == itemInfo)
                return;

            //更新选中
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetSelect(false);
            foreach (var column in columnCtrs)
            {
                var result = column.FindItemControl(itemInfo.Id);
                if (result != null)
                {
                    nowRowItemCtr = result;
                    nowRowItemCtr.SetSelect(true);
                    break;
                }
            }

            nowRowItem = itemInfo;
          //  listView1.Invalidate(); //todo 有优化空间

            doubleBufferedFlowLayoutPanel1.SuspendLayout();
            //更新显示文件内容
            textChangeLock = true;
            textBoxRowItemTitle.TrueText = nowRowItem.Title;

            UpdatePaperIcon(nowRowItem.Icon);
            textChangeLock = false;
            uckvList1.Init(itemInfo, 0);
           // dasayEditor1.Location = new Point(uckvList1.Location.X, uckvList1.Location.Y + uckvList1.Height);
            viewStack2.Height = splitContainer2.Panel2.Height - uckvList1.Location.Y - uckvList1.Height-45;

            string description = (float)itemInfo.GetFileLength() / 1024 > 0 ? string.Format("描述 {0:0.0}k", (float)itemInfo.GetFileLength() / 1024) : "描述";
            string images = itemInfo.GetImageCount() > 0 ? string.Format("图片 {0} 张", itemInfo.GetImageCount()) : "图片";
            int recordCount = BGBook.Instance.Records.Records.FindAll(a => a.GameId == nowRowItem.Id).Count;
            string records = recordCount > 0 ? string.Format("记录 {0} 条", recordCount) : "记录";

            ucListSelectBar2.TabNames = string.Format("{0}|{1}|{2}", description, images, records);

            if (itemInfo.Expansions != null)
                ucListSelectBar2.TempTabs = string.Join("|", itemInfo.Expansions);
            else
                ucListSelectBar2.TempTabs = "";
         //   if (ucListSelectBar2.SelectedIndex != 0)
                ucListSelectBar2.SelectedIndex = 0;
            ucListSelectBar2.Invalidate();

            var savePos = tabPage1.AutoScrollPosition; //保存滚轮纵向位置
            if (splitContainer2.SplitterDistance > splitContainer2.Width - 10)
                splitContainer2.SplitterDistance = Math.Min(lastDistance, Math.Max(0, splitContainer2.Width - 800));
            tabPage1.AutoScrollPosition = new Point(-tabPage1.AutoScrollPosition.X, -savePos.Y); //还原滚轮纵向位置

            doubleBufferedFlowLayoutPanel1.ResumeLayout();

            viewStack2.Height = splitContainer2.Panel2.Height - uckvList1.Location.Y - uckvList1.Height - 45;

            if (parm != null && !string.IsNullOrEmpty(parm.SearchTxt))
                dasayEditor1.SearchTxt(parm.SearchTxt);

            if (parm == null || !parm.NoSaveHistory)
                PageHistoryManager.Instance.Record(itemInfo.Id);
        }

        private int lastDistance;
        private void HidePaperPad()
        {
            if (splitContainer2.SplitterDistance > splitContainer2.Width - 10)
                return;
            //更新选中
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetSelect(false);
            nowRowItemCtr = null;
            nowRowItem = null;

            var savePos = tabPage1.AutoScrollPosition; //保存滚轮纵向位置
            lastDistance = splitContainer2.SplitterDistance;
            splitContainer2.SplitterDistance = splitContainer2.Width;
            tabPage1.AutoScrollPosition = new Point(-savePos.X, -savePos.Y); //还原滚轮纵向位置
        }

        private void UpdatePaperIcon(string icon)
        {
            pictureBoxPaperIcon.Image = ResLoader.Read(icon);
        }

        private void splitContainer2_Panel1_Click(object sender, System.EventArgs e)
        {
            HidePaperPad();
        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BGBook.Instance.Save();

            HLog.Info("main form quit");
        }

        private void textBoxRowItemTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowRowItem != null)
                    nowRowItem.Title = textBoxRowItemTitle.TrueText;
                if (nowRowItemCtr != null)
                    nowRowItemCtr.SetTitle(textBoxRowItemTitle.TrueText);
            }
        }

        public void SetRowTitleInfo(string title, string iconPath)
        {
            textBoxRowItemTitle.TrueText = title;
            UpdateIcon(iconPath);
        }

        private void textBoxCatalogTitle_TextChanged(object sender, System.EventArgs e)
        {
            if (!textChangeLock)
            {
                if (nowCatalog != null)
                    nowCatalog.Name = textBoxCatalogTitle.TrueText;
                if (nowCatalogCtr != null)
                    nowCatalogCtr.Title = textBoxCatalogTitle.TrueText;
            }
        }

        private void UpdateIcon(string iconPath)
        {
            if (nowRowItem != null)
                nowRowItem.Icon = iconPath;
            if (nowRowItemCtr != null)
                nowRowItemCtr.SetIcon(iconPath);
            UpdatePaperIcon(iconPath);
        }

        private void pictureBoxPaperIcon_Click(object sender, System.EventArgs e)
        {
            Point absoluteLocation = pictureBoxPaperIcon.PointToScreen(new Point(0, 0));
            PanelManager.Instance.ShowIconForm(absoluteLocation.X - Location.X - 500 / 2,
                absoluteLocation.Y - Location.Y + 5,
                (iconPath) =>
                {
                    UpdateIcon(iconPath);
                }
            );
        }

        private void ucCatalogSearch_Click(object sender, System.EventArgs e)
        {
            PanelManager.Instance.ShowSearchForm();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuCatlog.Tag.ToString());
            BGBook.Instance.DeleteCatalog(itemId);
            RefreshCatalogs();

            RefreshColumns(0);
            ShowPaperPad(null);
        }


        #region column的菜单支持
        private void InitMenu()
        {
            foreach (var cr in ColorTool.DarkColorTable)
            {
                ToolStripMenuItem blueMenuItem = new ToolStripMenuItem(cr.Key);
                blueMenuItem.BackColor = Color.FromArgb(24, 24, 24);
                blueMenuItem.ForeColor = Color.White;
                blueMenuItem.Image = ImageTool.CreateSolidColorBitmap(Color.FromArgb(cr.Value.R+40, cr.Value.G+40, cr.Value.B+40), 32, 32);
                blueMenuItem.Click += ColorMenuItem_Click;
                colorToolStripMenuItem1.DropDownItems.Add(blueMenuItem);
            }
        }

        private void DeleteRemovedFiles()
        {
            foreach (var file in Directory.GetFiles(ENV.SaveDir))
            {
                var fi = new FileInfo(file);
                var itemId = fi.Name;
                if (BGBook.Instance.GetCatalog(int.Parse(itemId.Replace(".rtf", ""))) == null)
                    File.Delete(file);
            }
        }

        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            var columnId = int.Parse(rjDropdownMenuCol.Tag.ToString());
            nowCatalog.GetColumn(columnId).BgColor = ColorTool.DarkColorTable[(sender as ToolStripMenuItem).Text].ToArgb();

            //todo 可以精细处理，就刷一列
            RefreshColumns(catalogId);
        }

        private void toolStripMenuItemDelCol_Click(object sender, EventArgs e)
        {
            var columnId = int.Parse(rjDropdownMenuCol.Tag.ToString());
            if (nowCatalog == null || BGBook.Instance.GetItemsByColumn(columnId).Count > 0)
                return;

            BGBook.Instance.GetCatalog(nowCatalog.Id).RemoveColumn(columnId);

            RefreshColumns(nowCatalog.Id);
        }

        #endregion

        #region row菜单支持

        private void deleteToolStripMenuItemRow_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());
            var columnCtr = rjDropdownMenuRow.Bind as UCTipColumn;

            var itemInfo = BGBook.Instance.RemoveItem(itemId);

            var fullPath = itemInfo.GetPath(0);
            if (File.Exists(fullPath))
                File.Delete(fullPath);

            if(itemInfo.Expansions != null)
            for (int i = 1; i <= itemInfo.Expansions.Count; i ++)
            {
                var expFullPath = itemInfo.GetPath(i);
                if (File.Exists(expFullPath))
                    File.Delete(expFullPath);
            }

            Directory.Delete(string.Format("{0}/{1}", ENV.ImgDir, itemId), true);

            columnCtr.RefreshLabels();
        }

        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());
            var columnCtr = rjDropdownMenuRow.Bind as UCTipColumn;

            var itemInfo = BGBook.Instance.GetItem(itemId);
            itemInfo.AddTag("存档");

            columnCtr.RefreshLabels();
        }

        private void toolStripMenuItemCata_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());

            var itemInfo = BGBook.Instance.GetItem(itemId);
            itemInfo.AddTag("汇总");
        }

        private void toolStripMenuItemCryto_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());

            var itemInfo = BGBook.Instance.GetItem(itemId);
            itemInfo.AddTag("加密");
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());
            BGBook.Instance.SetItemUp(itemId);
            var columnCtr = rjDropdownMenuRow.Bind as UCTipColumn;

            columnCtr.RefreshLabels();
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemId = int.Parse(rjDropdownMenuRow.Tag.ToString());
            BGBook.Instance.SetItemDown(itemId);
            var columnCtr = rjDropdownMenuRow.Bind as UCTipColumn;

            columnCtr.RefreshLabels();
        }
        #endregion

        private void doubleBufferedFlowLayoutPanel1_SizeChanged(object sender, EventArgs e)
        {
            viewStack2.Width = doubleBufferedFlowLayoutPanel1.Width;
            viewStack2.Height = doubleBufferedFlowLayoutPanel1.Height - uckvList1.Location.Y - uckvList1.Height-45;
            uckvList1.Width = doubleBufferedFlowLayoutPanel1.Width;
            ucDocTopBar1.Width = doubleBufferedFlowLayoutPanel1.Width;
            textBoxRowItemTitle.Width = doubleBufferedFlowLayoutPanel1.Width-100;
        }

        private void pictureBoxPaperIcon_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxPaperIcon.BackColor = Color.FromArgb(96, 96, 96);
        }

        private void pictureBoxPaperIcon_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxPaperIcon.BackColor = Color.FromArgb(32, 32, 32);
        }

        #region 全部信息列表

        private void listView1_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            // 自定义绘制列标题的背景
            using (SolidBrush brush1 = new SolidBrush(Color.FromArgb(16, 16, 16)))
            {
                e.Graphics.FillRectangle(brush1, e.Bounds);
            }

            // 设置绘制文本的字体和颜色
            using (var font = new Font("微软雅黑", 12, FontStyle.Bold))
                e.Graphics.DrawString(e.Header.Text, font, Brushes.WhiteSmoke, e.Bounds.X, e.Bounds.Y + 3);
        }

        private void listView1_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            // 自定义绘制列标题的背景
            using (SolidBrush brush1 = new SolidBrush(e.Item == listMouseOnLine ? Color.DarkBlue : Color.FromArgb(32, 32, 32)))
            {
                e.Graphics.FillRectangle(brush1, e.Bounds);
            }

            int xoff = 0;
            if (e.ColumnIndex == 0)
            {
                List<string> tags = new List<string>();
                var itemInfo = BGBook.Instance.GetItem((int)e.Item.Tag);
                if (itemInfo != null)
                {
                    tags.AddRange(itemInfo.Tag.Split(','));
                    e.Graphics.DrawImage(ResLoader.Read(itemInfo.Icon), e.Bounds.X + 3, e.Bounds.Y + 3, 24, 24);
                    xoff += 24;
                }

                var textColor = Brushes.White;
                if (itemInfo.ColumnId == 0 || itemInfo.CatalogId == 0)
                {
                    tags.Add("未分类");
                    textColor = Brushes.DimGray;
                }
                if (itemInfo.BuyInfo != null)
                {
                    if (itemInfo.BuyInfo.Contains("未到货"))
                    {
                        textColor = Brushes.DimGray;
                        tags.Add("未到货");
                    }
                    else if (itemInfo.BuyInfo.Contains("已卖出"))
                    {
                        textColor = Brushes.DimGray;
                        tags.Add("已卖出");
                    }
                }

                e.Graphics.DrawString(e.SubItem.Text, listView1.Font, textColor, e.Bounds.X + 4 + xoff, e.Bounds.Y + 5);
                // 获取文本的大小
                SizeF textSize1 = e.Graphics.MeasureString(e.SubItem.Text, listView1.Font);
                xoff += (int)textSize1.Width;

                foreach (string word in tags)
                {
                    // 获取文本框的大小
                    SizeF textSize = e.Graphics.MeasureString(word, Font);

                    Rectangle borderRect = new Rectangle(xoff+3, e.Bounds.Y+5, (int)textSize.Width + 6, 15 + 6);
                    var brush = DrawTool.GetTagBrush(word);
                    e.Graphics.FillRoundRectangle(brush, borderRect, 3);

                    e.Graphics.DrawString(word, listView1.Font, Brushes.White, xoff + 3, e.Bounds.Y + 5);

                    // 调整下一个词的位置
                    xoff += (int)textSize.Width + 6 + 6;
                }
            }
            else if (e.ColumnIndex == 2 || e.ColumnIndex == 1)
            {
                var brush = Brushes.White;
                var mark = int.Parse(e.SubItem.Text);
                if (mark == 0)
                    brush = Brushes.DimGray;
                else if (mark >= 90)
                    brush = Brushes.Red;
                else if (mark >= 80)
                    brush = Brushes.Orange;
                else if (mark >= 70)
                    brush = Brushes.Yellow;
                else if (mark >= 60)
                    brush = Brushes.LawnGreen;
                e.Graphics.DrawString(e.SubItem.Text, listView1.Font, brush, e.Bounds.X + 4 + xoff, e.Bounds.Y + 5);
            }
            else
            {
                e.Graphics.DrawString(e.SubItem.Text, listView1.Font, Brushes.White, e.Bounds.X + 4 + xoff, e.Bounds.Y + 5);
            }
        }

        private ListViewItem listMouseOnLine;

        private void viewStack1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (viewStack1.SelectedIndex == 1)
            {
                var listCachedItems = BGBook.Instance.GetItemsByCatalog(catalogId);
                listView1.Items.Clear();
                foreach (var item in listCachedItems)
                {
                    var listItem = new ListViewItem(item.Title);
                    listItem.SubItems.Add(item.Star.ToString());
                    listItem.SubItems.Add(item.StarNewbie.ToString());
                    listItem.SubItems.Add(item.GetModifyTime().ToString("yyyy-MM-dd"));
                    listItem.Tag = item.Id;
                    listView1.Items.Add(listItem);
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listMouseOnLine == null)
            {
                ShowPaperPad(null);
            }
            else
            {
                var lineInfo = (int)listView1.Items[listMouseOnLine.Index].Tag;
                ShowPaperPad(BGBook.Instance.GetItem(lineInfo));
            }
        }

        private void listView1_MouseMove(object sender, MouseEventArgs e)
        {
            Point localPoint = listView1.PointToClient(Cursor.Position);

            // 使用 HitTest 方法判断鼠标下方的项目
            ListViewHitTestInfo hitTest = listView1.HitTest(localPoint);
            if (hitTest.Item != null)
            {
                if (listMouseOnLine != null)
                    listView1.Invalidate(listMouseOnLine.Bounds);
                listMouseOnLine = hitTest.Item;
                listView1.Invalidate(listMouseOnLine.Bounds);
                // 在这里你可以处理鼠标悬停在项目上的逻辑
                // 例如获取项目的信息，更新UI等
            }
            else
            {
                if (listMouseOnLine != null)
                    listView1.Invalidate(listMouseOnLine.Bounds);
                listMouseOnLine = null;
            }
        }


        private void listView1_SizeChanged(object sender, EventArgs e)
        {
            listView1.Columns[0].Width = listView1.Width - 240;
        }

        private void OnSelectBarIndexChanged(int idx)
        {
            viewStack1.SelectedIndex = idx;
        }

        private void OnSelectBar2IndexChanged(int idx)
        {

            if (idx == 0)
            {
                viewStack2.SelectedIndex = idx;
                dasayEditor1.LoadFile(nowRowItem);
                uckvList1.SetExpIndex(0);
            }
            else if (idx == 1)
            {
                viewStack2.SelectedIndex = idx;
                imageGallery1.Init(nowRowItem);
            }
            else if (idx == 2)
            {
                //todo
                viewStack2.SelectedIndex = idx;
                recordBox1.Init(nowRowItem);
            }
            else
            {
                viewStack2.SelectedIndex = 0;
                dasayEditor1.LoadFile(nowRowItem, idx - 2);
                uckvList1.SetExpIndex(idx - 2);
            }

        }
        #endregion

        private void splitContainer2_Panel1_Resize(object sender, EventArgs e)
        {
            viewStack1.Height = splitContainer2.Panel1.Height - 135;
            viewStack1.Width = splitContainer2.Panel1.Width;
            ucListSelectBar1.Width = viewStack1.Width;
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText.StartsWith("file://page/"))
            {
                var id = int.Parse(e.LinkText.Substring(7 + 5));
                ShowPaperPad(BGBook.Instance.GetItem(id));
                return;
            }
            else if (e.LinkText.StartsWith("file://img/"))
            {
                var filePath = e.LinkText.Substring(7 + 4);
                if (File.Exists(ENV.ImgDir + filePath))
                    PanelManager.Instance.ShowImageViewer(ENV.ImgDir + filePath);
                return;
            }

            System.Diagnostics.Process.Start(e.LinkText);
        }
        private void ButtonFormer_Click(object sender, EventArgs e)
        {
            var pageId = PageHistoryManager.Instance.FindFormer();
            if (pageId > 0)
                ShowPaperPad(BGBook.Instance.GetItem(pageId), new ShowPaperParm { NoSaveHistory = true });
        }
        private void ButtonNext_Click(object sender, EventArgs e)
        {
            var pageId = PageHistoryManager.Instance.FindNext();
            if (pageId > 0)
                ShowPaperPad(BGBook.Instance.GetItem(pageId), new ShowPaperParm { NoSaveHistory = true });
        }

        private void ButtonExpAdd_Click(object sender, EventArgs e)
        {
            if (nowRowItem == null)
                return;

            Point absoluteLocation = ucDocTopBar1.PointToScreen(new Point(0, 0));

            var inputBox = new InputTextBox();
            inputBox.OnCustomTextChanged = OnAddExpansion;

            PanelManager.Instance.ShowBlackPanel(inputBox, absoluteLocation.X - Location.X, absoluteLocation.Y - Location.Y, 1);
            inputBox.Focus();
        }

        private void OnAddExpansion(string obj)
        {
            if (nowRowItem == null)
                return;

            if (string.IsNullOrWhiteSpace(obj))
                return;

            if (nowRowItem.Expansions == null)
                nowRowItem.Expansions = new List<string>();
            nowRowItem.Expansions.Add(obj);

            ucListSelectBar2.TempTabs = string.Join("|", nowRowItem.Expansions);
            ucListSelectBar2.Invalidate();
        }

        private void ucCatalogFixStat_Click(object sender, EventArgs e)
        {
            PanelManager.Instance.ShowStat();
        }
    }
}
