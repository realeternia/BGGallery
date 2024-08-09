namespace Text_Editor
{
    public partial class DasayEditor
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DasayEditor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.undoStripButton = new System.Windows.Forms.ToolStripButton();
            this.redoStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.imgStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonScreen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonEmo = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTextColor = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButtonTemplate = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripTextBoxKeyText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButtonFindNext = new System.Windows.Forms.ToolStripButton();
            this.ucToolbar1 = new Text_Editor.UCToolbar();
            this.richTextBox1 = new Text_Editor.RichTextBoxEx();
            this.rjDropdownMenuRightClick = new RJControls.RJDropdownMenu(this.components);
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rjDropdownMenuBar = new RJControls.RJDropdownMenu(this.components);
            this.textToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bulletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemKeywords = new System.Windows.Forms.ToolStripMenuItem();
            this.showlineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rjDropdownMenuLine = new RJControls.RJDropdownMenu(this.components);
            this.toolStripMenuItemKeys = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTime = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemEmotion = new System.Windows.Forms.ToolStripMenuItem();
            this.rjButtonLeftS = new RJControls.RJButton();
            this.toolStrip1.SuspendLayout();
            this.rjDropdownMenuRightClick.SuspendLayout();
            this.rjDropdownMenuBar.SuspendLayout();
            this.rjDropdownMenuLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoStripButton,
            this.redoStripButton,
            this.toolStripSeparator1,
            this.imgStripButton,
            this.toolStripButtonScreen,
            this.toolStripButtonEmo,
            this.toolStripButtonTextColor,
            this.toolStripSeparator2,
            this.toolStripDropDownButtonTemplate,
            this.toolStripTextBoxKeyText,
            this.toolStripButtonFindNext});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 31);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // undoStripButton
            // 
            this.undoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.undoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("undoStripButton.Image")));
            this.undoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.undoStripButton.Name = "undoStripButton";
            this.undoStripButton.Size = new System.Drawing.Size(28, 28);
            this.undoStripButton.Text = "撤销";
            this.undoStripButton.Click += new System.EventHandler(this.undoStripButton_Click);
            // 
            // redoStripButton
            // 
            this.redoStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.redoStripButton.Image = ((System.Drawing.Image)(resources.GetObject("redoStripButton.Image")));
            this.redoStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.redoStripButton.Name = "redoStripButton";
            this.redoStripButton.Size = new System.Drawing.Size(28, 28);
            this.redoStripButton.Text = "重做";
            this.redoStripButton.Click += new System.EventHandler(this.redoStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // imgStripButton
            // 
            this.imgStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.imgStripButton.Image = global::BGGallery.Properties.Resources.pictureadd;
            this.imgStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.imgStripButton.Name = "imgStripButton";
            this.imgStripButton.Size = new System.Drawing.Size(28, 28);
            this.imgStripButton.Text = "插入图片";
            this.imgStripButton.Click += new System.EventHandler(this.imgStripButton_Click);
            // 
            // toolStripButtonScreen
            // 
            this.toolStripButtonScreen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonScreen.Image = global::BGGallery.Properties.Resources.picturepaste;
            this.toolStripButtonScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonScreen.Name = "toolStripButtonScreen";
            this.toolStripButtonScreen.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonScreen.Text = "黏贴图片";
            this.toolStripButtonScreen.Click += new System.EventHandler(this.toolStripButtonScreen_Click);
            // 
            // toolStripButtonEmo
            // 
            this.toolStripButtonEmo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEmo.Image = global::BGGallery.Properties.Resources.smile;
            this.toolStripButtonEmo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEmo.Name = "toolStripButtonEmo";
            this.toolStripButtonEmo.Size = new System.Drawing.Size(28, 28);
            this.toolStripButtonEmo.Text = "添加表情";
            this.toolStripButtonEmo.Click += new System.EventHandler(this.toolStripButtonEmo_Click);
            // 
            // toolStripButtonTextColor
            // 
            this.toolStripButtonTextColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTextColor.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonTextColor.Image = global::BGGallery.Properties.Resources.smile;
            this.toolStripButtonTextColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTextColor.Name = "toolStripButtonTextColor";
            this.toolStripButtonTextColor.Size = new System.Drawing.Size(72, 28);
            this.toolStripButtonTextColor.Text = "关键词染色";
            this.toolStripButtonTextColor.Click += new System.EventHandler(this.toolStripButtonTextColor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // toolStripDropDownButtonTemplate
            // 
            this.toolStripDropDownButtonTemplate.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripDropDownButtonTemplate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonTemplate.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButtonTemplate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonTemplate.Image")));
            this.toolStripDropDownButtonTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonTemplate.Name = "toolStripDropDownButtonTemplate";
            this.toolStripDropDownButtonTemplate.Size = new System.Drawing.Size(45, 28);
            this.toolStripDropDownButtonTemplate.Text = "模板";
            // 
            // toolStripTextBoxKeyText
            // 
            this.toolStripTextBoxKeyText.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.toolStripTextBoxKeyText.ForeColor = System.Drawing.Color.Black;
            this.toolStripTextBoxKeyText.Name = "toolStripTextBoxKeyText";
            this.toolStripTextBoxKeyText.Size = new System.Drawing.Size(120, 31);
            this.toolStripTextBoxKeyText.Visible = false;
            // 
            // toolStripButtonFindNext
            // 
            this.toolStripButtonFindNext.ForeColor = System.Drawing.Color.Black;
            this.toolStripButtonFindNext.Image = global::BGGallery.Properties.Resources.search;
            this.toolStripButtonFindNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonFindNext.Name = "toolStripButtonFindNext";
            this.toolStripButtonFindNext.Size = new System.Drawing.Size(72, 28);
            this.toolStripButtonFindNext.Text = "下一个";
            this.toolStripButtonFindNext.Visible = false;
            this.toolStripButtonFindNext.Click += new System.EventHandler(this.toolStripButtonFindNext_Click);
            // 
            // ucToolbar1
            // 
            this.ucToolbar1.BackColor = System.Drawing.Color.White;
            this.ucToolbar1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ucToolbar1.Location = new System.Drawing.Point(520, 278);
            this.ucToolbar1.Margin = new System.Windows.Forms.Padding(2);
            this.ucToolbar1.Name = "ucToolbar1";
            this.ucToolbar1.Size = new System.Drawing.Size(322, 28);
            this.ucToolbar1.TabIndex = 20;
            this.ucToolbar1.Visible = false;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ContextMenuStrip = this.rjDropdownMenuRightClick;
            this.richTextBox1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.richTextBox1.Location = new System.Drawing.Point(39, 47);
            this.richTextBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(990, 624);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.WordWrap = false;
            this.richTextBox1.SelectionChanged += new System.EventHandler(this.richTextBox1_SelectionChanged);
            this.richTextBox1.VScroll += new System.EventHandler(this.richTextBox1_VScroll);
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            this.richTextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyDown);
            this.richTextBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBox1_KeyPress);
            this.richTextBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox1_KeyUp);
            this.richTextBox1.MouseEnter += new System.EventHandler(this.richTextBox1_MouseEnter);
            this.richTextBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.richTextBox1_MouseMove);
            // 
            // rjDropdownMenuRightClick
            // 
            this.rjDropdownMenuRightClick.BackColor = System.Drawing.Color.Black;
            this.rjDropdownMenuRightClick.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rjDropdownMenuRightClick.ForeColor = System.Drawing.Color.White;
            this.rjDropdownMenuRightClick.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenuRightClick.IsMainMenu = false;
            this.rjDropdownMenuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.searchToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.rjDropdownMenuRightClick.MenuItemHeight = 25;
            this.rjDropdownMenuRightClick.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRightClick.Name = "rjDropdownMenu1";
            this.rjDropdownMenuRightClick.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRightClick.Size = new System.Drawing.Size(158, 124);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.cutToolStripMenuItem.Text = "剪切";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.copyToolStripMenuItem.Text = "复制";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.pasteToolStripMenuItem.Text = "黏贴";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.searchToolStripMenuItem.Text = "查找";
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(157, 24);
            this.removeToolStripMenuItem.Text = "删除";
            // 
            // rjDropdownMenuBar
            // 
            this.rjDropdownMenuBar.BackColor = System.Drawing.Color.Black;
            this.rjDropdownMenuBar.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rjDropdownMenuBar.ForeColor = System.Drawing.Color.White;
            this.rjDropdownMenuBar.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenuBar.IsMainMenu = false;
            this.rjDropdownMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem1,
            this.bulletToolStripMenuItem,
            this.head1ToolStripMenuItem,
            this.head2ToolStripMenuItem,
            this.head3ToolStripMenuItem,
            this.qutoToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItemKeywords,
            this.showlineToolStripMenuItem});
            this.rjDropdownMenuBar.MenuItemHeight = 25;
            this.rjDropdownMenuBar.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuBar.Name = "rjDropdownMenu1";
            this.rjDropdownMenuBar.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuBar.Size = new System.Drawing.Size(200, 250);
            // 
            // textToolStripMenuItem1
            // 
            this.textToolStripMenuItem1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textToolStripMenuItem1.Image = global::BGGallery.Properties.Resources.brush;
            this.textToolStripMenuItem1.Name = "textToolStripMenuItem1";
            this.textToolStripMenuItem1.Size = new System.Drawing.Size(199, 30);
            this.textToolStripMenuItem1.Text = "转为文本";
            // 
            // bulletToolStripMenuItem
            // 
            this.bulletToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.bulletToolStripMenuItem.Image = global::BGGallery.Properties.Resources.brush;
            this.bulletToolStripMenuItem.Name = "bulletToolStripMenuItem";
            this.bulletToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.bulletToolStripMenuItem.Text = "转为●条目";
            // 
            // head1ToolStripMenuItem
            // 
            this.head1ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.head1ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 14F);
            this.head1ToolStripMenuItem.Image = global::BGGallery.Properties.Resources.brush;
            this.head1ToolStripMenuItem.Name = "head1ToolStripMenuItem";
            this.head1ToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.head1ToolStripMenuItem.Text = "转为一级标题";
            // 
            // head2ToolStripMenuItem
            // 
            this.head2ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.head2ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.head2ToolStripMenuItem.Image = global::BGGallery.Properties.Resources.brush;
            this.head2ToolStripMenuItem.Name = "head2ToolStripMenuItem";
            this.head2ToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.head2ToolStripMenuItem.Text = "转为二级标题";
            // 
            // head3ToolStripMenuItem
            // 
            this.head3ToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.head3ToolStripMenuItem.Image = global::BGGallery.Properties.Resources.brush;
            this.head3ToolStripMenuItem.Name = "head3ToolStripMenuItem";
            this.head3ToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.head3ToolStripMenuItem.Text = "转为三级标题";
            // 
            // qutoToolStripMenuItem
            // 
            this.qutoToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.qutoToolStripMenuItem.Image = global::BGGallery.Properties.Resources.brush;
            this.qutoToolStripMenuItem.Name = "qutoToolStripMenuItem";
            this.qutoToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.qutoToolStripMenuItem.Text = "转为|引用";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(196, 6);
            // 
            // toolStripMenuItemKeywords
            // 
            this.toolStripMenuItemKeywords.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemKeywords.Image = global::BGGallery.Properties.Resources.trace;
            this.toolStripMenuItemKeywords.Name = "toolStripMenuItemKeywords";
            this.toolStripMenuItemKeywords.Size = new System.Drawing.Size(199, 30);
            this.toolStripMenuItemKeywords.Text = "查找关键词";
            // 
            // showlineToolStripMenuItem
            // 
            this.showlineToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.showlineToolStripMenuItem.Image = global::BGGallery.Properties.Resources.trace;
            this.showlineToolStripMenuItem.Name = "showlineToolStripMenuItem";
            this.showlineToolStripMenuItem.Size = new System.Drawing.Size(199, 30);
            this.showlineToolStripMenuItem.Text = "查看文本";
            // 
            // rjDropdownMenuLine
            // 
            this.rjDropdownMenuLine.BackColor = System.Drawing.Color.Black;
            this.rjDropdownMenuLine.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rjDropdownMenuLine.ForeColor = System.Drawing.Color.White;
            this.rjDropdownMenuLine.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenuLine.IsMainMenu = false;
            this.rjDropdownMenuLine.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemKeys,
            this.toolStripMenuItemPage,
            this.toolStripMenuItemTime,
            this.toolStripMenuItemEmotion});
            this.rjDropdownMenuLine.MenuItemHeight = 25;
            this.rjDropdownMenuLine.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuLine.Name = "rjDropdownMenu1";
            this.rjDropdownMenuLine.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuLine.Size = new System.Drawing.Size(139, 108);
            // 
            // toolStripMenuItemKeys
            // 
            this.toolStripMenuItemKeys.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemKeys.Image = global::BGGallery.Properties.Resources.bubble;
            this.toolStripMenuItemKeys.Name = "toolStripMenuItemKeys";
            this.toolStripMenuItemKeys.Size = new System.Drawing.Size(138, 26);
            this.toolStripMenuItemKeys.Text = "关键词";
            // 
            // toolStripMenuItemPage
            // 
            this.toolStripMenuItemPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemPage.Image = global::BGGallery.Properties.Resources.paper;
            this.toolStripMenuItemPage.Name = "toolStripMenuItemPage";
            this.toolStripMenuItemPage.Size = new System.Drawing.Size(138, 26);
            this.toolStripMenuItemPage.Text = "页面引用";
            // 
            // toolStripMenuItemTime
            // 
            this.toolStripMenuItemTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemTime.Image = global::BGGallery.Properties.Resources.time;
            this.toolStripMenuItemTime.Name = "toolStripMenuItemTime";
            this.toolStripMenuItemTime.Size = new System.Drawing.Size(138, 26);
            this.toolStripMenuItemTime.Text = "时间";
            // 
            // toolStripMenuItemEmotion
            // 
            this.toolStripMenuItemEmotion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemEmotion.Image = global::BGGallery.Properties.Resources.emo;
            this.toolStripMenuItemEmotion.Name = "toolStripMenuItemEmotion";
            this.toolStripMenuItemEmotion.Size = new System.Drawing.Size(138, 26);
            this.toolStripMenuItemEmotion.Text = "表情";
            // 
            // rjButtonLeftS
            // 
            this.rjButtonLeftS.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButtonLeftS.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.rjButtonLeftS.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButtonLeftS.BorderRadius = 0;
            this.rjButtonLeftS.BorderSize = 0;
            this.rjButtonLeftS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rjButtonLeftS.FlatAppearance.BorderSize = 0;
            this.rjButtonLeftS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonLeftS.ForeColor = System.Drawing.Color.White;
            this.rjButtonLeftS.Image = global::BGGallery.Properties.Resources.selector;
            this.rjButtonLeftS.Location = new System.Drawing.Point(83, 325);
            this.rjButtonLeftS.Margin = new System.Windows.Forms.Padding(0);
            this.rjButtonLeftS.Name = "rjButtonLeftS";
            this.rjButtonLeftS.Size = new System.Drawing.Size(21, 34);
            this.rjButtonLeftS.TabIndex = 22;
            this.rjButtonLeftS.TextColor = System.Drawing.Color.White;
            this.rjButtonLeftS.UseVisualStyleBackColor = false;
            this.rjButtonLeftS.Visible = false;
            this.rjButtonLeftS.Click += new System.EventHandler(this.rjButtonLeftS_Click);
            // 
            // DasayEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.rjButtonLeftS);
            this.Controls.Add(this.ucToolbar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.richTextBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "DasayEditor";
            this.Size = new System.Drawing.Size(1029, 670);
            this.Load += new System.EventHandler(this.frmEditor_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.rjDropdownMenuRightClick.ResumeLayout(false);
            this.rjDropdownMenuBar.ResumeLayout(false);
            this.rjDropdownMenuLine.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RichTextBoxEx richTextBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton undoStripButton;
        private System.Windows.Forms.ToolStripButton redoStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton imgStripButton;
        private UCToolbar ucToolbar1;
        private System.Windows.Forms.ToolStripButton toolStripButtonScreen;
        private System.Windows.Forms.ToolStripButton toolStripButtonEmo;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonTemplate;
        private RJControls.RJButton rjButtonLeftS;
        private RJControls.RJDropdownMenu rjDropdownMenuBar;
        private System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bulletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem head1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem head2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem head3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private RJControls.RJDropdownMenu rjDropdownMenuRightClick;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showlineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem qutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxKeyText;
        private System.Windows.Forms.ToolStripButton toolStripButtonFindNext;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemKeywords;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private RJControls.RJDropdownMenu rjDropdownMenuLine;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemEmotion;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemKeys;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTime;
        private System.Windows.Forms.ToolStripButton toolStripButtonTextColor;
    }
}