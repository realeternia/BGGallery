
namespace Text_Editor
{
    partial class UCToolbar
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonSwitch = new System.Windows.Forms.ToolStripDropDownButton();
            this.textToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.head3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.clearFormattingStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButtonCata = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.boldStripButton = new System.Windows.Forms.ToolStripButton();
            this.italicStripButton = new System.Windows.Forms.ToolStripButton();
            this.underlineStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonSwitch,
            this.colorStripDropDownButton,
            this.toolStripSeparator9,
            this.clearFormattingStripButton,
            this.toolStripDropDownButtonCata,
            this.toolStripSeparator2,
            this.boldStripButton,
            this.italicStripButton,
            this.underlineStripButton,
            this.toolStripButtonDel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(438, 31);
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonSwitch
            // 
            this.toolStripDropDownButtonSwitch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonSwitch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.textToolStripMenuItem,
            this.blistToolStripMenuItem,
            this.head1ToolStripMenuItem,
            this.head2ToolStripMenuItem,
            this.head3ToolStripMenuItem,
            this.qutoToolStripMenuItem});
            this.toolStripDropDownButtonSwitch.ForeColor = System.Drawing.Color.Black;
            this.toolStripDropDownButtonSwitch.Image = global::BGGallery.Properties.Resources._switch;
            this.toolStripDropDownButtonSwitch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSwitch.Name = "toolStripDropDownButtonSwitch";
            this.toolStripDropDownButtonSwitch.Size = new System.Drawing.Size(38, 28);
            this.toolStripDropDownButtonSwitch.Text = "切换";
            // 
            // textToolStripMenuItem
            // 
            this.textToolStripMenuItem.BackColor = System.Drawing.Color.White;
            this.textToolStripMenuItem.Name = "textToolStripMenuItem";
            this.textToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.textToolStripMenuItem.Text = "文本";
            // 
            // blistToolStripMenuItem
            // 
            this.blistToolStripMenuItem.Name = "blistToolStripMenuItem";
            this.blistToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.blistToolStripMenuItem.Text = "条目";
            // 
            // head1ToolStripMenuItem
            // 
            this.head1ToolStripMenuItem.Name = "head1ToolStripMenuItem";
            this.head1ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.head1ToolStripMenuItem.Text = "一级标题";
            // 
            // head2ToolStripMenuItem
            // 
            this.head2ToolStripMenuItem.Name = "head2ToolStripMenuItem";
            this.head2ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.head2ToolStripMenuItem.Text = "二级标题";
            // 
            // head3ToolStripMenuItem
            // 
            this.head3ToolStripMenuItem.Name = "head3ToolStripMenuItem";
            this.head3ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.head3ToolStripMenuItem.Text = "三级标题";
            // 
            // qutoToolStripMenuItem
            // 
            this.qutoToolStripMenuItem.Name = "qutoToolStripMenuItem";
            this.qutoToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.qutoToolStripMenuItem.Text = "引用";
            // 
            // colorStripDropDownButton
            // 
            this.colorStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.colorStripDropDownButton.Image = global::BGGallery.Properties.Resources.colorf;
            this.colorStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.colorStripDropDownButton.Name = "colorStripDropDownButton";
            this.colorStripDropDownButton.Size = new System.Drawing.Size(38, 28);
            this.colorStripDropDownButton.Text = "字色";
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(6, 31);
            // 
            // clearFormattingStripButton
            // 
            this.clearFormattingStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.clearFormattingStripButton.Image = global::BGGallery.Properties.Resources.clearformat;
            this.clearFormattingStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearFormattingStripButton.Name = "clearFormattingStripButton";
            this.clearFormattingStripButton.Size = new System.Drawing.Size(29, 28);
            this.clearFormattingStripButton.Text = "清除格式";
            // 
            // toolStripDropDownButtonCata
            // 
            this.toolStripDropDownButtonCata.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonCata.Image = global::BGGallery.Properties.Resources.bubble;
            this.toolStripDropDownButtonCata.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonCata.Name = "toolStripDropDownButtonCata";
            this.toolStripDropDownButtonCata.Size = new System.Drawing.Size(38, 28);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // boldStripButton
            // 
            this.boldStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.boldStripButton.Image = global::BGGallery.Properties.Resources.bold;
            this.boldStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.boldStripButton.Name = "boldStripButton";
            this.boldStripButton.Size = new System.Drawing.Size(29, 28);
            this.boldStripButton.Text = "Bold";
            this.boldStripButton.ToolTipText = "加粗";
            // 
            // italicStripButton
            // 
            this.italicStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.italicStripButton.Image = global::BGGallery.Properties.Resources.iter;
            this.italicStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.italicStripButton.Name = "italicStripButton";
            this.italicStripButton.Size = new System.Drawing.Size(29, 28);
            this.italicStripButton.Text = "斜体";
            // 
            // underlineStripButton
            // 
            this.underlineStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.underlineStripButton.Image = global::BGGallery.Properties.Resources.uline;
            this.underlineStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.underlineStripButton.Name = "underlineStripButton";
            this.underlineStripButton.Size = new System.Drawing.Size(29, 28);
            this.underlineStripButton.Text = "下划线";
            // 
            // toolStripButtonDel
            // 
            this.toolStripButtonDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDel.Image = global::BGGallery.Properties.Resources.del21;
            this.toolStripButtonDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDel.Name = "toolStripButtonDel";
            this.toolStripButtonDel.Size = new System.Drawing.Size(29, 28);
            this.toolStripButtonDel.Text = "删除线";
            // 
            // UCToolbar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.toolStrip1);
            this.Name = "UCToolbar";
            this.Size = new System.Drawing.Size(438, 34);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        public System.Windows.Forms.ToolStripDropDownButton colorStripDropDownButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        public System.Windows.Forms.ToolStripButton clearFormattingStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.ToolStripButton boldStripButton;
        public System.Windows.Forms.ToolStripButton italicStripButton;
        public System.Windows.Forms.ToolStripButton underlineStripButton;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSwitch;
        public System.Windows.Forms.ToolStripMenuItem textToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem blistToolStripMenuItem;
        public System.Windows.Forms.ToolStripButton toolStripButtonDel;
        public System.Windows.Forms.ToolStripMenuItem head1ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem head2ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem head3ToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem qutoToolStripMenuItem;
        public System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonCata;
    }
}
