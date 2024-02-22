
using BGGallery.UIS;
using RJControls;

namespace BGGallery.UIS
{
    partial class UCEditImage
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelSizeNow = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxRatio = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.doubleBufferedPanel1 = new BGGallery.UIS.DoubleBufferedPanel();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(30, 30);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(634, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "宽x高";
            // 
            // labelSizeNow
            // 
            this.labelSizeNow.AutoSize = true;
            this.labelSizeNow.Font = new System.Drawing.Font("宋体", 10F);
            this.labelSizeNow.ForeColor = System.Drawing.Color.White;
            this.labelSizeNow.Location = new System.Drawing.Point(717, 22);
            this.labelSizeNow.Name = "labelSizeNow";
            this.labelSizeNow.Size = new System.Drawing.Size(28, 14);
            this.labelSizeNow.TabIndex = 5;
            this.labelSizeNow.Text = "1x1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(634, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "缩放比例";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(634, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "截取坐标";
            // 
            // textBoxRatio
            // 
            this.textBoxRatio.Location = new System.Drawing.Point(720, 53);
            this.textBoxRatio.Name = "textBoxRatio";
            this.textBoxRatio.Size = new System.Drawing.Size(100, 21);
            this.textBoxRatio.TabIndex = 10;
            this.textBoxRatio.Text = "1";
            this.textBoxRatio.TextChanged += new System.EventHandler(this.textBoxRatio_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(634, 129);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 11;
            this.label5.Text = "截取范围";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(717, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 14);
            this.label6.TabIndex = 12;
            this.label6.Text = "1x1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(717, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 14);
            this.label7.TabIndex = 13;
            this.label7.Text = "1x1";
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(16)))), ((int)(((byte)(16)))));
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(12, 12);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(600, 450);
            this.doubleBufferedPanel1.TabIndex = 3;
            this.doubleBufferedPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.doubleBufferedPanel1_Paint);
            this.doubleBufferedPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.doubleBufferedPanel1_MouseDown);
            this.doubleBufferedPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.doubleBufferedPanel1_MouseMove);
            this.doubleBufferedPanel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.doubleBufferedPanel1_MouseUp);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold);
            this.buttonOk.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonOk.Location = new System.Drawing.Point(637, 181);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(122, 29);
            this.buttonOk.TabIndex = 20;
            this.buttonOk.Tag = "";
            this.buttonOk.Text = "确 认";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // UCEditImage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxRatio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelSizeNow);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.doubleBufferedPanel1);
            this.Name = "UCEditImage";
            this.Size = new System.Drawing.Size(841, 476);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private DoubleBufferedPanel doubleBufferedPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSizeNow;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxRatio;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonOk;
    }
}
