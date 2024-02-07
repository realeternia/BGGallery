
using BGGallery.UIS;
using RJControls;

namespace BGGallery.UIS
{
    partial class UCSearch
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listView1 = new BGGallery.UIS.DoubleBufferedListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new BGGallery.UIS.HintTextBox();
            this.rjComboBox1 = new RJControls.RJComboBox();
            this.rjButton6 = new RJControls.RJButton();
            this.rjButton1 = new RJControls.RJButton();
            this.rjButton2 = new RJControls.RJButton();
            this.rjButton3 = new RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(70, 70);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BGGallery.Properties.Resources.search;
            this.pictureBox1.Location = new System.Drawing.Point(10, 47);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.Font = new System.Drawing.Font("微软雅黑", 10.5F);
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(10, 88);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.Size = new System.Drawing.Size(830, 903);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.VirtualMode = true;
            this.listView1.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.listView1_DrawItem);
            this.listView1.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listView1_DrawSubItem);
            this.listView1.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listView1_RetrieveVirtualItem);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseMove);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 800;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.DefaultText = "输入搜索";
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.GrayText;
            this.textBox1.ForeColorDE = System.Drawing.Color.White;
            this.textBox1.Location = new System.Drawing.Point(53, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(631, 33);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "输入搜索";
            this.textBox1.TrueText = "";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // rjComboBox1
            // 
            this.rjComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.rjComboBox1.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.rjComboBox1.BorderSize = 1;
            this.rjComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rjComboBox1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.rjComboBox1.ForeColor = System.Drawing.Color.White;
            this.rjComboBox1.IconColor = System.Drawing.Color.Yellow;
            this.rjComboBox1.Items.AddRange(new object[] {
            "最近一周",
            "最近一个月",
            "所有时间"});
            this.rjComboBox1.ListBackColor = System.Drawing.Color.DimGray;
            this.rjComboBox1.ListTextColor = System.Drawing.Color.White;
            this.rjComboBox1.Location = new System.Drawing.Point(690, 44);
            this.rjComboBox1.MinimumSize = new System.Drawing.Size(150, 30);
            this.rjComboBox1.Name = "rjComboBox1";
            this.rjComboBox1.Padding = new System.Windows.Forms.Padding(1);
            this.rjComboBox1.Size = new System.Drawing.Size(150, 38);
            this.rjComboBox1.TabIndex = 3;
            this.rjComboBox1.Texts = "";
            this.rjComboBox1.OnSelectedIndexChanged += new System.EventHandler(this.rjComboBox1_OnSelectedIndexChanged);
            // 
            // rjButton6
            // 
            this.rjButton6.BackColor = System.Drawing.Color.Silver;
            this.rjButton6.BackgroundColor = System.Drawing.Color.Silver;
            this.rjButton6.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton6.BorderRadius = 20;
            this.rjButton6.BorderSize = 0;
            this.rjButton6.FlatAppearance.BorderSize = 0;
            this.rjButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.rjButton6.ForeColor = System.Drawing.Color.Black;
            this.rjButton6.Image = global::BGGallery.Properties.Resources.add;
            this.rjButton6.Location = new System.Drawing.Point(53, 2);
            this.rjButton6.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rjButton6.Name = "rjButton6";
            this.rjButton6.Size = new System.Drawing.Size(112, 39);
            this.rjButton6.TabIndex = 54;
            this.rjButton6.Text = "todo";
            this.rjButton6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rjButton6.TextColor = System.Drawing.Color.Black;
            this.rjButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rjButton6.UseVisualStyleBackColor = false;
            this.rjButton6.Click += new System.EventHandler(this.rjButton6_Click);
            // 
            // rjButton1
            // 
            this.rjButton1.BackColor = System.Drawing.Color.PaleGreen;
            this.rjButton1.BackgroundColor = System.Drawing.Color.PaleGreen;
            this.rjButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton1.BorderRadius = 20;
            this.rjButton1.BorderSize = 0;
            this.rjButton1.FlatAppearance.BorderSize = 0;
            this.rjButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.rjButton1.ForeColor = System.Drawing.Color.Black;
            this.rjButton1.Image = global::BGGallery.Properties.Resources.done1;
            this.rjButton1.Location = new System.Drawing.Point(173, 2);
            this.rjButton1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rjButton1.Name = "rjButton1";
            this.rjButton1.Size = new System.Drawing.Size(112, 39);
            this.rjButton1.TabIndex = 55;
            this.rjButton1.Text = "done";
            this.rjButton1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rjButton1.TextColor = System.Drawing.Color.Black;
            this.rjButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rjButton1.UseVisualStyleBackColor = false;
            this.rjButton1.Click += new System.EventHandler(this.rjButton6_Click);
            // 
            // rjButton2
            // 
            this.rjButton2.BackColor = System.Drawing.Color.LemonChiffon;
            this.rjButton2.BackgroundColor = System.Drawing.Color.LemonChiffon;
            this.rjButton2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton2.BorderRadius = 20;
            this.rjButton2.BorderSize = 0;
            this.rjButton2.FlatAppearance.BorderSize = 0;
            this.rjButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.rjButton2.ForeColor = System.Drawing.Color.Black;
            this.rjButton2.Image = global::BGGallery.Properties.Resources.share;
            this.rjButton2.Location = new System.Drawing.Point(293, 2);
            this.rjButton2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rjButton2.Name = "rjButton2";
            this.rjButton2.Size = new System.Drawing.Size(121, 39);
            this.rjButton2.TabIndex = 56;
            this.rjButton2.Text = "share";
            this.rjButton2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rjButton2.TextColor = System.Drawing.Color.Black;
            this.rjButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rjButton2.UseVisualStyleBackColor = false;
            this.rjButton2.Click += new System.EventHandler(this.rjButton6_Click);
            // 
            // rjButton3
            // 
            this.rjButton3.BackColor = System.Drawing.Color.DarkSalmon;
            this.rjButton3.BackgroundColor = System.Drawing.Color.DarkSalmon;
            this.rjButton3.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.rjButton3.BorderRadius = 20;
            this.rjButton3.BorderSize = 0;
            this.rjButton3.FlatAppearance.BorderSize = 0;
            this.rjButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.rjButton3.ForeColor = System.Drawing.Color.Black;
            this.rjButton3.Image = global::BGGallery.Properties.Resources.follow;
            this.rjButton3.Location = new System.Drawing.Point(422, 2);
            this.rjButton3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rjButton3.Name = "rjButton3";
            this.rjButton3.Size = new System.Drawing.Size(121, 39);
            this.rjButton3.TabIndex = 57;
            this.rjButton3.Text = "follow";
            this.rjButton3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rjButton3.TextColor = System.Drawing.Color.Black;
            this.rjButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.rjButton3.UseVisualStyleBackColor = false;
            this.rjButton3.Click += new System.EventHandler(this.rjButton6_Click);
            // 
            // UCSearch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.Controls.Add(this.rjButton3);
            this.Controls.Add(this.rjButton2);
            this.Controls.Add(this.rjButton1);
            this.Controls.Add(this.rjButton6);
            this.Controls.Add(this.rjComboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.textBox1);
            this.Name = "UCSearch";
            this.Size = new System.Drawing.Size(850, 1000);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HintTextBox textBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ImageList imageList1;
        private DoubleBufferedListView listView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private RJComboBox rjComboBox1;
        private RJButton rjButton6;
        private RJButton rjButton1;
        private RJButton rjButton2;
        private RJButton rjButton3;
    }
}
