
namespace BGGallery.UIS.Main
{
    partial class ImageGallery
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
            this.doubleBufferedFlowLayoutPanel1 = new BGGallery.UIS.DoubleBufferedFlowLayoutPanel();
            this.SuspendLayout();
            // 
            // doubleBufferedFlowLayoutPanel1
            // 
            this.doubleBufferedFlowLayoutPanel1.AutoScroll = true;
            this.doubleBufferedFlowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.doubleBufferedFlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.doubleBufferedFlowLayoutPanel1.Name = "doubleBufferedFlowLayoutPanel1";
            this.doubleBufferedFlowLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.doubleBufferedFlowLayoutPanel1.Size = new System.Drawing.Size(1042, 727);
            this.doubleBufferedFlowLayoutPanel1.TabIndex = 0;
            this.doubleBufferedFlowLayoutPanel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.doubleBufferedFlowLayoutPanel1_DragDrop);
            this.doubleBufferedFlowLayoutPanel1.DragEnter += new System.Windows.Forms.DragEventHandler(this.doubleBufferedFlowLayoutPanel1_DragEnter);
            // 
            // ImageGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.doubleBufferedFlowLayoutPanel1);
            this.Name = "ImageGallery";
            this.Size = new System.Drawing.Size(1042, 727);
            this.ResumeLayout(false);

        }

        #endregion

        private DoubleBufferedFlowLayoutPanel doubleBufferedFlowLayoutPanel1;
    }
}
