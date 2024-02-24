namespace BGGallery.UIS.ImageView
{
    partial class KpImageViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            DisposeControl();

            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPreview = new System.Windows.Forms.Panel();
            this.lblPreview = new System.Windows.Forms.Label();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnMode = new System.Windows.Forms.Button();
            this.cbZoom = new System.Windows.Forms.ComboBox();
            this.btnFitToScreen = new System.Windows.Forms.Button();
            this.btnZoomIn = new System.Windows.Forms.Button();
            this.btnZoomOut = new System.Windows.Forms.Button();
            this.btnRotate270 = new System.Windows.Forms.Button();
            this.btnRotate90 = new System.Windows.Forms.Button();
            this.pbPanel = new System.Windows.Forms.PictureBox();
            this.pbFull = new BGGallery.UIS.ImageView.PanelDoubleBuffered();
            this.panelPreview.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPreview
            // 
            this.panelPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPreview.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPreview.Controls.Add(this.lblPreview);
            this.panelPreview.Location = new System.Drawing.Point(1379, 3);
            this.panelPreview.Name = "panelPreview";
            this.panelPreview.Size = new System.Drawing.Size(150, 27);
            this.panelPreview.TabIndex = 12;
            // 
            // lblPreview
            // 
            this.lblPreview.AutoSize = true;
            this.lblPreview.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPreview.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblPreview.Location = new System.Drawing.Point(3, 4);
            this.lblPreview.Name = "lblPreview";
            this.lblPreview.Size = new System.Drawing.Size(59, 18);
            this.lblPreview.TabIndex = 0;
            this.lblPreview.Text = "Preview";
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panelMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenu.Controls.Add(this.btnMode);
            this.panelMenu.Controls.Add(this.cbZoom);
            this.panelMenu.Controls.Add(this.btnFitToScreen);
            this.panelMenu.Controls.Add(this.btnZoomIn);
            this.panelMenu.Controls.Add(this.btnZoomOut);
            this.panelMenu.Controls.Add(this.btnRotate270);
            this.panelMenu.Controls.Add(this.btnRotate90);
            this.panelMenu.Location = new System.Drawing.Point(2, 3);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1373, 27);
            this.panelMenu.TabIndex = 11;
            // 
            // btnMode
            // 
            this.btnMode.Image = global::BGGallery.Properties.Resources.btnSelect;
            this.btnMode.Location = new System.Drawing.Point(142, 1);
            this.btnMode.Name = "btnMode";
            this.btnMode.Size = new System.Drawing.Size(25, 23);
            this.btnMode.TabIndex = 16;
            this.btnMode.UseVisualStyleBackColor = true;
            this.btnMode.Click += new System.EventHandler(this.btnMode_Click);
            // 
            // cbZoom
            // 
            this.cbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbZoom.FormattingEnabled = true;
            this.cbZoom.Location = new System.Drawing.Point(1306, 3);
            this.cbZoom.Name = "cbZoom";
            this.cbZoom.Size = new System.Drawing.Size(62, 20);
            this.cbZoom.TabIndex = 14;
            this.cbZoom.SelectedIndexChanged += new System.EventHandler(this.cbZoom_SelectedIndexChanged);
            this.cbZoom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbZoom_KeyPress);
            // 
            // btnFitToScreen
            // 
            this.btnFitToScreen.Image = global::BGGallery.Properties.Resources.btnFitToScreen;
            this.btnFitToScreen.Location = new System.Drawing.Point(58, 1);
            this.btnFitToScreen.Name = "btnFitToScreen";
            this.btnFitToScreen.Size = new System.Drawing.Size(25, 23);
            this.btnFitToScreen.TabIndex = 13;
            this.btnFitToScreen.UseVisualStyleBackColor = true;
            this.btnFitToScreen.Click += new System.EventHandler(this.btnFitToScreen_Click);
            // 
            // btnZoomIn
            // 
            this.btnZoomIn.Image = global::BGGallery.Properties.Resources.btnZoomIn;
            this.btnZoomIn.Location = new System.Drawing.Point(2, 1);
            this.btnZoomIn.Name = "btnZoomIn";
            this.btnZoomIn.Size = new System.Drawing.Size(25, 23);
            this.btnZoomIn.TabIndex = 12;
            this.btnZoomIn.UseVisualStyleBackColor = true;
            this.btnZoomIn.Click += new System.EventHandler(this.btnZoomIn_Click);
            // 
            // btnZoomOut
            // 
            this.btnZoomOut.Image = global::BGGallery.Properties.Resources.btnZoomOut;
            this.btnZoomOut.Location = new System.Drawing.Point(30, 1);
            this.btnZoomOut.Name = "btnZoomOut";
            this.btnZoomOut.Size = new System.Drawing.Size(25, 23);
            this.btnZoomOut.TabIndex = 11;
            this.btnZoomOut.UseVisualStyleBackColor = true;
            this.btnZoomOut.Click += new System.EventHandler(this.btnZoomOut_Click);
            // 
            // btnRotate270
            // 
            this.btnRotate270.Image = global::BGGallery.Properties.Resources.btnRotate270;
            this.btnRotate270.Location = new System.Drawing.Point(86, 1);
            this.btnRotate270.Name = "btnRotate270";
            this.btnRotate270.Size = new System.Drawing.Size(25, 23);
            this.btnRotate270.TabIndex = 10;
            this.btnRotate270.UseVisualStyleBackColor = true;
            this.btnRotate270.Click += new System.EventHandler(this.btnRotate270_Click);
            // 
            // btnRotate90
            // 
            this.btnRotate90.Image = global::BGGallery.Properties.Resources.btnRotate90;
            this.btnRotate90.Location = new System.Drawing.Point(114, 1);
            this.btnRotate90.Name = "btnRotate90";
            this.btnRotate90.Size = new System.Drawing.Size(25, 23);
            this.btnRotate90.TabIndex = 9;
            this.btnRotate90.UseVisualStyleBackColor = true;
            this.btnRotate90.Click += new System.EventHandler(this.btnRotate90_Click);
            // 
            // pbPanel
            // 
            this.pbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPanel.Location = new System.Drawing.Point(1380, 33);
            this.pbPanel.Name = "pbPanel";
            this.pbPanel.Size = new System.Drawing.Size(148, 108);
            this.pbPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPanel.TabIndex = 10;
            this.pbPanel.TabStop = false;
            this.pbPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseDown);
            this.pbPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseMove);
            this.pbPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbPanel_MouseUp);
            // 
            // pbFull
            // 
            this.pbFull.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.pbFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbFull.Location = new System.Drawing.Point(2, 33);
            this.pbFull.Name = "pbFull";
            this.pbFull.Size = new System.Drawing.Size(1373, 923);
            this.pbFull.TabIndex = 13;
            this.pbFull.Click += new System.EventHandler(this.pbFull_Click);
            this.pbFull.DragDrop += new System.Windows.Forms.DragEventHandler(this.pbFull_DragDrop);
            this.pbFull.DragEnter += new System.Windows.Forms.DragEventHandler(this.pbFull_DragEnter);
            this.pbFull.Paint += new System.Windows.Forms.PaintEventHandler(this.pbFull_Paint);
            this.pbFull.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseDoubleClick);
            this.pbFull.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseDown);
            this.pbFull.MouseEnter += new System.EventHandler(this.pbFull_MouseEnter);
            this.pbFull.MouseLeave += new System.EventHandler(this.pbFull_MouseLeave);
            this.pbFull.MouseHover += new System.EventHandler(this.pbFull_MouseHover);
            this.pbFull.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseMove);
            this.pbFull.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbFull_MouseUp);
            // 
            // KpImageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.pbFull);
            this.Controls.Add(this.panelPreview);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.pbPanel);
            this.MinimumSize = new System.Drawing.Size(454, 145);
            this.Name = "KpImageViewer";
            this.Size = new System.Drawing.Size(1532, 959);
            this.Load += new System.EventHandler(this.KP_ImageViewerV2_Load);
            this.Click += new System.EventHandler(this.KpImageViewer_Click);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.KP_ImageViewerV2_MouseWheel);
            this.Resize += new System.EventHandler(this.KP_ImageViewerV2_Resize);
            this.panelPreview.ResumeLayout(false);
            this.panelPreview.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPreview;
        private System.Windows.Forms.Label lblPreview;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.PictureBox pbPanel;
        private PanelDoubleBuffered pbFull;
        private System.Windows.Forms.Button btnRotate270;
        private System.Windows.Forms.Button btnRotate90;
        private System.Windows.Forms.Button btnZoomIn;
        private System.Windows.Forms.Button btnZoomOut;
        private System.Windows.Forms.Button btnFitToScreen;
        private System.Windows.Forms.ComboBox cbZoom;
        private System.Windows.Forms.Button btnMode;
    }
}
