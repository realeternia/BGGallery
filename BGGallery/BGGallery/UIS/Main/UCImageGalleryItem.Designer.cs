
namespace BGGallery.UIS.Main
{
    partial class UCImageGalleryItem
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
            this.components = new System.ComponentModel.Container();
            this.rjDropdownMenuRow = new RJControls.RJDropdownMenu(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRename = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.rjDropdownMenuRow.SuspendLayout();
            this.SuspendLayout();
            // 
            // rjDropdownMenuRow
            // 
            this.rjDropdownMenuRow.BackColor = System.Drawing.Color.Black;
            this.rjDropdownMenuRow.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.rjDropdownMenuRow.ForeColor = System.Drawing.Color.White;
            this.rjDropdownMenuRow.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.rjDropdownMenuRow.IsMainMenu = false;
            this.rjDropdownMenuRow.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.toolStripMenuItemRename,
            this.toolStripMenuItemRemove});
            this.rjDropdownMenuRow.MenuItemHeight = 25;
            this.rjDropdownMenuRow.MenuItemTextColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRow.Name = "rjDropdownMenu1";
            this.rjDropdownMenuRow.PrimaryColor = System.Drawing.Color.Empty;
            this.rjDropdownMenuRow.Size = new System.Drawing.Size(135, 76);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(134, 24);
            this.copyToolStripMenuItem.Text = "拷贝路径";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripMenuItemRename
            // 
            this.toolStripMenuItemRename.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemRename.Name = "toolStripMenuItemRename";
            this.toolStripMenuItemRename.Size = new System.Drawing.Size(134, 24);
            this.toolStripMenuItemRename.Text = "重命名";
            this.toolStripMenuItemRename.Click += new System.EventHandler(this.toolStripMenuItemRename_Click);
            // 
            // toolStripMenuItemRemove
            // 
            this.toolStripMenuItemRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.toolStripMenuItemRemove.ForeColor = System.Drawing.Color.IndianRed;
            this.toolStripMenuItemRemove.Name = "toolStripMenuItemRemove";
            this.toolStripMenuItemRemove.Size = new System.Drawing.Size(134, 24);
            this.toolStripMenuItemRemove.Text = "删除";
            this.toolStripMenuItemRemove.Click += new System.EventHandler(this.toolStripMenuItemRemove_Click);
            // 
            // UCImageGalleryItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UCImageGalleryItem";
            this.Size = new System.Drawing.Size(277, 223);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.UCImageGalleryItem_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UCImageGalleryItem_MouseClick);
            this.MouseEnter += new System.EventHandler(this.UCImageGalleryItem_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.UCImageGalleryItem_MouseLeave);
            this.rjDropdownMenuRow.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private RJControls.RJDropdownMenu rjDropdownMenuRow;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRename;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemRemove;
    }
}
