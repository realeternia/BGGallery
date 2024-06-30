
namespace BGGallery.UIS
{
    partial class UCDocTopBar
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
            this.buttonFormer = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.buttonExpAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFormer
            // 
            this.buttonFormer.BackgroundImage = global::BGGallery.Properties.Resources.arrowup;
            this.buttonFormer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonFormer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonFormer.ForeColor = System.Drawing.Color.Gray;
            this.buttonFormer.Location = new System.Drawing.Point(7, 2);
            this.buttonFormer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonFormer.Name = "buttonFormer";
            this.buttonFormer.Size = new System.Drawing.Size(22, 19);
            this.buttonFormer.TabIndex = 0;
            this.buttonFormer.UseVisualStyleBackColor = true;
            // 
            // buttonNext
            // 
            this.buttonNext.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonNext.BackgroundImage = global::BGGallery.Properties.Resources.arrowdown;
            this.buttonNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNext.ForeColor = System.Drawing.Color.Gray;
            this.buttonNext.Location = new System.Drawing.Point(36, 2);
            this.buttonNext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(22, 19);
            this.buttonNext.TabIndex = 1;
            this.buttonNext.UseVisualStyleBackColor = true;
            // 
            // buttonExpAdd
            // 
            this.buttonExpAdd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonExpAdd.BackgroundImage = global::BGGallery.Properties.Resources.add;
            this.buttonExpAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonExpAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonExpAdd.ForeColor = System.Drawing.Color.Gray;
            this.buttonExpAdd.Location = new System.Drawing.Point(68, 2);
            this.buttonExpAdd.Margin = new System.Windows.Forms.Padding(2);
            this.buttonExpAdd.Name = "buttonExpAdd";
            this.buttonExpAdd.Size = new System.Drawing.Size(22, 19);
            this.buttonExpAdd.TabIndex = 2;
            this.buttonExpAdd.UseVisualStyleBackColor = true;
            // 
            // UCDocTopBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(28)))));
            this.Controls.Add(this.buttonExpAdd);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonFormer);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "UCDocTopBar";
            this.Size = new System.Drawing.Size(225, 22);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button buttonFormer;
        public System.Windows.Forms.Button buttonNext;
        public System.Windows.Forms.Button buttonExpAdd;
    }
}
