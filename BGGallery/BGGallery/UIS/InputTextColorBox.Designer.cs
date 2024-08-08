
namespace BGGallery.UIS
{
    partial class InputTextColorBox
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.doubleBufferedPanel1 = new BGGallery.UIS.DoubleBufferedPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.rjButtonAddLine = new RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.doubleBufferedPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::BGGallery.Properties.Resources.done;
            this.pictureBox1.Location = new System.Drawing.Point(513, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 35);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doubleBufferedPanel1.AutoScroll = true;
            this.doubleBufferedPanel1.Controls.Add(this.tableLayoutPanel1);
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(12, 18);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(495, 441);
            this.doubleBufferedPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(309, 30);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // rjButtonAddLine
            // 
            this.rjButtonAddLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rjButtonAddLine.BackColor = System.Drawing.Color.DodgerBlue;
            this.rjButtonAddLine.BackgroundColor = System.Drawing.Color.DodgerBlue;
            this.rjButtonAddLine.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButtonAddLine.BorderRadius = 3;
            this.rjButtonAddLine.BorderSize = 0;
            this.rjButtonAddLine.FlatAppearance.BorderSize = 0;
            this.rjButtonAddLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonAddLine.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rjButtonAddLine.ForeColor = System.Drawing.Color.White;
            this.rjButtonAddLine.Location = new System.Drawing.Point(513, 21);
            this.rjButtonAddLine.Name = "rjButtonAddLine";
            this.rjButtonAddLine.Size = new System.Drawing.Size(100, 35);
            this.rjButtonAddLine.TabIndex = 3;
            this.rjButtonAddLine.Text = "添加行";
            this.rjButtonAddLine.TextColor = System.Drawing.Color.White;
            this.rjButtonAddLine.UseVisualStyleBackColor = false;
            this.rjButtonAddLine.Click += new System.EventHandler(this.rjButtonAddLine_Click);
            // 
            // InputTextColorBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.rjButtonAddLine);
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "InputTextColorBox";
            this.Size = new System.Drawing.Size(620, 472);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.doubleBufferedPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private DoubleBufferedPanel doubleBufferedPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private RJControls.RJButton rjButtonAddLine;
    }
}
