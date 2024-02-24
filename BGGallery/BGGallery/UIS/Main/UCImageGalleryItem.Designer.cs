
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
            this.SuspendLayout();
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
            this.ResumeLayout(false);

        }

        #endregion
    }
}
