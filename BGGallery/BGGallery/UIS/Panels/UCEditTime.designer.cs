namespace BGGallery.UIS.Panels
{
    partial class UCEditTime
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxYear = new System.Windows.Forms.TextBox();
            this.textBoxMonth = new System.Windows.Forms.TextBox();
            this.textBoxDate = new System.Windows.Forms.TextBox();
            this.textBoxHour = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonDay = new System.Windows.Forms.Button();
            this.buttonHour = new System.Windows.Forms.Button();
            this.buttonWeek = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "设定时间";
            // 
            // textBoxYear
            // 
            this.textBoxYear.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxYear.Location = new System.Drawing.Point(23, 52);
            this.textBoxYear.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxYear.Name = "textBoxYear";
            this.textBoxYear.Size = new System.Drawing.Size(92, 26);
            this.textBoxYear.TabIndex = 2;
            this.textBoxYear.Tag = "2099";
            this.textBoxYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxYear.TextChanged += new System.EventHandler(this.textBoxSec_TextChanged);
            this.textBoxYear.Enter += new System.EventHandler(this.textBoxYear_Enter);
            this.textBoxYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxYear_KeyPress);
            this.textBoxYear.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBoxYear_MouseUp);
            // 
            // textBoxMonth
            // 
            this.textBoxMonth.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMonth.Location = new System.Drawing.Point(131, 52);
            this.textBoxMonth.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMonth.Name = "textBoxMonth";
            this.textBoxMonth.Size = new System.Drawing.Size(45, 26);
            this.textBoxMonth.TabIndex = 3;
            this.textBoxMonth.Tag = "12";
            this.textBoxMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxMonth.TextChanged += new System.EventHandler(this.textBoxSec_TextChanged);
            this.textBoxMonth.Enter += new System.EventHandler(this.textBoxYear_Enter);
            this.textBoxMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxYear_KeyPress);
            this.textBoxMonth.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBoxYear_MouseUp);
            // 
            // textBoxDate
            // 
            this.textBoxDate.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDate.Location = new System.Drawing.Point(196, 52);
            this.textBoxDate.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(45, 26);
            this.textBoxDate.TabIndex = 4;
            this.textBoxDate.Tag = "31";
            this.textBoxDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxDate.TextChanged += new System.EventHandler(this.textBoxSec_TextChanged);
            this.textBoxDate.Enter += new System.EventHandler(this.textBoxYear_Enter);
            this.textBoxDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxYear_KeyPress);
            this.textBoxDate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBoxYear_MouseUp);
            // 
            // textBoxHour
            // 
            this.textBoxHour.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxHour.Location = new System.Drawing.Point(261, 52);
            this.textBoxHour.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxHour.Name = "textBoxHour";
            this.textBoxHour.Size = new System.Drawing.Size(45, 26);
            this.textBoxHour.TabIndex = 6;
            this.textBoxHour.Tag = "24";
            this.textBoxHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxHour.TextChanged += new System.EventHandler(this.textBoxSec_TextChanged);
            this.textBoxHour.Enter += new System.EventHandler(this.textBoxYear_Enter);
            this.textBoxHour.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxYear_KeyPress);
            this.textBoxHour.MouseUp += new System.Windows.Forms.MouseEventHandler(this.textBoxYear_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10F);
            this.label3.Location = new System.Drawing.Point(316, 59);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "时";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.Location = new System.Drawing.Point(114, 57);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 14);
            this.label4.TabIndex = 12;
            this.label4.Text = "/";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.Location = new System.Drawing.Point(178, 57);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "/";
            // 
            // buttonDay
            // 
            this.buttonDay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.buttonDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDay.Location = new System.Drawing.Point(188, 99);
            this.buttonDay.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDay.Name = "buttonDay";
            this.buttonDay.Size = new System.Drawing.Size(53, 29);
            this.buttonDay.TabIndex = 16;
            this.buttonDay.Tag = "24";
            this.buttonDay.Text = "+1天";
            this.buttonDay.UseVisualStyleBackColor = false;
            this.buttonDay.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonHour
            // 
            this.buttonHour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.buttonHour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHour.Location = new System.Drawing.Point(261, 99);
            this.buttonHour.Margin = new System.Windows.Forms.Padding(4);
            this.buttonHour.Name = "buttonHour";
            this.buttonHour.Size = new System.Drawing.Size(53, 29);
            this.buttonHour.TabIndex = 17;
            this.buttonHour.Tag = "1";
            this.buttonHour.Text = "+1时";
            this.buttonHour.UseVisualStyleBackColor = false;
            this.buttonHour.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonWeek
            // 
            this.buttonWeek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(48)))), ((int)(((byte)(72)))));
            this.buttonWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWeek.Location = new System.Drawing.Point(117, 99);
            this.buttonWeek.Margin = new System.Windows.Forms.Padding(4);
            this.buttonWeek.Name = "buttonWeek";
            this.buttonWeek.Size = new System.Drawing.Size(53, 29);
            this.buttonWeek.TabIndex = 18;
            this.buttonWeek.Tag = "168";
            this.buttonWeek.Text = "+1周";
            this.buttonWeek.UseVisualStyleBackColor = false;
            this.buttonWeek.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.BackColor = System.Drawing.Color.DodgerBlue;
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Bold);
            this.buttonOk.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonOk.Location = new System.Drawing.Point(223, 162);
            this.buttonOk.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(91, 29);
            this.buttonOk.TabIndex = 19;
            this.buttonOk.Tag = "";
            this.buttonOk.Text = "确 认";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // UCEditTime
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.buttonWeek);
            this.Controls.Add(this.buttonHour);
            this.Controls.Add(this.buttonDay);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxHour);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.textBoxMonth);
            this.Controls.Add(this.textBoxYear);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UCEditTime";
            this.Size = new System.Drawing.Size(348, 218);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UCGmRunSvTime_PreviewKeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxYear;
        private System.Windows.Forms.TextBox textBoxMonth;
        private System.Windows.Forms.TextBox textBoxDate;
        private System.Windows.Forms.TextBox textBoxHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonDay;
        private System.Windows.Forms.Button buttonHour;
        private System.Windows.Forms.Button buttonWeek;
        private System.Windows.Forms.Button buttonOk;
    }
}
