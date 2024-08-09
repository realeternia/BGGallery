
using BGGallery.UIS;
using RJControls;

namespace BGGallery.UIS
{
    partial class UCBGPropertyModify
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
            this.labelId = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.hintTextBoxBuyOther = new BGGallery.UIS.HintTextBox();
            this.rjButtonOk = new RJControls.RJButton();
            this.rjComboBoxColumn = new RJControls.RJComboBox();
            this.rjComboBoxCatalog = new RJControls.RJComboBox();
            this.hintTextBoxPrice = new BGGallery.UIS.HintTextBox();
            this.hintTextBoxBuyTime = new BGGallery.UIS.HintTextBox();
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
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "购入时间";
            // 
            // labelId
            // 
            this.labelId.AutoSize = true;
            this.labelId.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelId.ForeColor = System.Drawing.Color.White;
            this.labelId.Location = new System.Drawing.Point(12, 15);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(23, 20);
            this.labelId.TabIndex = 2;
            this.labelId.Text = "id";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(88, 15);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 20);
            this.labelName.TabIndex = 3;
            this.labelName.Text = "name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(280, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "购入价格";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Catalog";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(280, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 9;
            this.label4.Text = "Column";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 165);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(613, 273);
            this.flowLayoutPanel1.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(12, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "购买信息";
            // 
            // hintTextBoxBuyOther
            // 
            this.hintTextBoxBuyOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.hintTextBoxBuyOther.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hintTextBoxBuyOther.DefaultText = "输入搜索";
            this.hintTextBoxBuyOther.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.hintTextBoxBuyOther.ForeColor = System.Drawing.Color.White;
            this.hintTextBoxBuyOther.ForeColorDE = System.Drawing.Color.White;
            this.hintTextBoxBuyOther.Location = new System.Drawing.Point(92, 89);
            this.hintTextBoxBuyOther.Name = "hintTextBoxBuyOther";
            this.hintTextBoxBuyOther.Size = new System.Drawing.Size(349, 22);
            this.hintTextBoxBuyOther.TabIndex = 15;
            this.hintTextBoxBuyOther.Text = "点击输入";
            this.hintTextBoxBuyOther.TrueText = "点击输入";
            // 
            // rjButtonOk
            // 
            this.rjButtonOk.BackColor = System.Drawing.Color.RoyalBlue;
            this.rjButtonOk.BackgroundColor = System.Drawing.Color.RoyalBlue;
            this.rjButtonOk.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButtonOk.BorderRadius = 0;
            this.rjButtonOk.BorderSize = 0;
            this.rjButtonOk.FlatAppearance.BorderSize = 0;
            this.rjButtonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButtonOk.ForeColor = System.Drawing.Color.White;
            this.rjButtonOk.Location = new System.Drawing.Point(276, 451);
            this.rjButtonOk.Name = "rjButtonOk";
            this.rjButtonOk.Size = new System.Drawing.Size(92, 27);
            this.rjButtonOk.TabIndex = 11;
            this.rjButtonOk.Text = "保 存";
            this.rjButtonOk.TextColor = System.Drawing.Color.White;
            this.rjButtonOk.UseVisualStyleBackColor = false;
            this.rjButtonOk.Click += new System.EventHandler(this.rjButtonOk_Click);
            // 
            // rjComboBoxColumn
            // 
            this.rjComboBoxColumn.BackColor = System.Drawing.Color.Black;
            this.rjComboBoxColumn.BorderColor = System.Drawing.Color.RoyalBlue;
            this.rjComboBoxColumn.BorderSize = 1;
            this.rjComboBoxColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rjComboBoxColumn.Font = new System.Drawing.Font("宋体", 10F);
            this.rjComboBoxColumn.ForeColor = System.Drawing.Color.LightGray;
            this.rjComboBoxColumn.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.rjComboBoxColumn.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.rjComboBoxColumn.ListTextColor = System.Drawing.Color.DimGray;
            this.rjComboBoxColumn.Location = new System.Drawing.Point(360, 122);
            this.rjComboBoxColumn.MinimumSize = new System.Drawing.Size(150, 30);
            this.rjComboBoxColumn.Name = "rjComboBoxColumn";
            this.rjComboBoxColumn.Padding = new System.Windows.Forms.Padding(1);
            this.rjComboBoxColumn.Size = new System.Drawing.Size(150, 30);
            this.rjComboBoxColumn.TabIndex = 10;
            this.rjComboBoxColumn.Texts = "";
            // 
            // rjComboBoxCatalog
            // 
            this.rjComboBoxCatalog.BackColor = System.Drawing.Color.Black;
            this.rjComboBoxCatalog.BorderColor = System.Drawing.Color.RoyalBlue;
            this.rjComboBoxCatalog.BorderSize = 1;
            this.rjComboBoxCatalog.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rjComboBoxCatalog.Font = new System.Drawing.Font("宋体", 10F);
            this.rjComboBoxCatalog.ForeColor = System.Drawing.Color.LightGray;
            this.rjComboBoxCatalog.IconColor = System.Drawing.Color.MediumSlateBlue;
            this.rjComboBoxCatalog.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(228)))), ((int)(((byte)(245)))));
            this.rjComboBoxCatalog.ListTextColor = System.Drawing.Color.DimGray;
            this.rjComboBoxCatalog.Location = new System.Drawing.Point(92, 122);
            this.rjComboBoxCatalog.MinimumSize = new System.Drawing.Size(150, 30);
            this.rjComboBoxCatalog.Name = "rjComboBoxCatalog";
            this.rjComboBoxCatalog.Padding = new System.Windows.Forms.Padding(1);
            this.rjComboBoxCatalog.Size = new System.Drawing.Size(150, 30);
            this.rjComboBoxCatalog.TabIndex = 8;
            this.rjComboBoxCatalog.Texts = "";
            this.rjComboBoxCatalog.OnSelectedIndexChanged += new System.EventHandler(this.rjComboBoxCatalog_OnSelectedIndexChanged);
            // 
            // hintTextBoxPrice
            // 
            this.hintTextBoxPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.hintTextBoxPrice.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hintTextBoxPrice.DefaultText = "输入搜索";
            this.hintTextBoxPrice.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.hintTextBoxPrice.ForeColor = System.Drawing.Color.LightSalmon;
            this.hintTextBoxPrice.ForeColorDE = System.Drawing.Color.LightSalmon;
            this.hintTextBoxPrice.Location = new System.Drawing.Point(360, 58);
            this.hintTextBoxPrice.Name = "hintTextBoxPrice";
            this.hintTextBoxPrice.Size = new System.Drawing.Size(81, 22);
            this.hintTextBoxPrice.TabIndex = 4;
            this.hintTextBoxPrice.Text = "点击输入";
            this.hintTextBoxPrice.TrueText = "点击输入";
            // 
            // textBoxBuyTime
            // 
            this.hintTextBoxBuyTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.hintTextBoxBuyTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.hintTextBoxBuyTime.DefaultText = "输入搜索";
            this.hintTextBoxBuyTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.hintTextBoxBuyTime.ForeColor = System.Drawing.Color.PaleGreen;
            this.hintTextBoxBuyTime.ForeColorDE = System.Drawing.Color.PaleGreen;
            this.hintTextBoxBuyTime.Location = new System.Drawing.Point(92, 57);
            this.hintTextBoxBuyTime.Name = "textBoxBuyTime";
            this.hintTextBoxBuyTime.Size = new System.Drawing.Size(81, 22);
            this.hintTextBoxBuyTime.TabIndex = 0;
            this.hintTextBoxBuyTime.Text = "点击输入";
            this.hintTextBoxBuyTime.TrueText = "点击输入";
            this.hintTextBoxBuyTime.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // UCBGPropertyModify
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.hintTextBoxBuyOther);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.rjButtonOk);
            this.Controls.Add(this.rjComboBoxColumn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rjComboBoxCatalog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hintTextBoxPrice);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hintTextBoxBuyTime);
            this.Name = "UCBGPropertyModify";
            this.Size = new System.Drawing.Size(644, 493);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HintTextBox hintTextBoxBuyTime;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label label2;
        private HintTextBox hintTextBoxPrice;
        private System.Windows.Forms.Label label3;
        private RJComboBox rjComboBoxCatalog;
        private RJComboBox rjComboBoxColumn;
        private System.Windows.Forms.Label label4;
        private RJButton rjButtonOk;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private HintTextBox hintTextBoxBuyOther;
    }
}
