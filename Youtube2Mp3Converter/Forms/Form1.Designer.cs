namespace Simple_Youtube2Mp3
{
    partial class Form1
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblMinimize = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblExit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.pnlContents = new System.Windows.Forms.Panel();
            this.dragHeader = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dragLogo = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.dragTitle = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.dragVersion = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.pnlSide = new Bunifu.Framework.UI.BunifuGradientPanel();
            this.btnHistory = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnSettings = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnDownloads = new Bunifu.Framework.UI.BunifuFlatButton();
            this.tmrFadeIn = new System.Windows.Forms.Timer(this.components);
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.IndianRed;
            this.pnlHeader.Controls.Add(this.lblVersion);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblMinimize);
            this.pnlHeader.Controls.Add(this.lblExit);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(166, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(704, 97);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblVersion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Location = new System.Drawing.Point(282, 63);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(100, 16);
            this.lblVersion.TabIndex = 14;
            this.lblVersion.Text = "Version x.x.x.x";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 15F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(229, 35);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(215, 23);
            this.lblTitle.TabIndex = 81;
            this.lblTitle.Text = "Simple Youtube2Mp3";
            // 
            // lblMinimize
            // 
            this.lblMinimize.AutoSize = true;
            this.lblMinimize.BackColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblMinimize.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblMinimize.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinimize.ForeColor = System.Drawing.Color.Transparent;
            this.lblMinimize.Location = new System.Drawing.Point(661, 0);
            this.lblMinimize.Name = "lblMinimize";
            this.lblMinimize.Size = new System.Drawing.Size(21, 22);
            this.lblMinimize.TabIndex = 5;
            this.lblMinimize.Text = "- ";
            this.lblMinimize.Click += new System.EventHandler(this.lblMinimize_Click);
            this.lblMinimize.MouseEnter += new System.EventHandler(this.lblMinimize_MouseEnter);
            this.lblMinimize.MouseLeave += new System.EventHandler(this.lblMinimize_MouseLeave);
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Transparent;
            this.lblExit.Location = new System.Drawing.Point(682, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(22, 22);
            this.lblExit.TabIndex = 4;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            this.lblExit.MouseEnter += new System.EventHandler(this.lblExit_MouseEnter);
            this.lblExit.MouseLeave += new System.EventHandler(this.lblExit_MouseLeave);
            // 
            // pnlContents
            // 
            this.pnlContents.BackColor = System.Drawing.Color.White;
            this.pnlContents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContents.Location = new System.Drawing.Point(166, 97);
            this.pnlContents.Name = "pnlContents";
            this.pnlContents.Size = new System.Drawing.Size(704, 463);
            this.pnlContents.TabIndex = 2;
            // 
            // dragHeader
            // 
            this.dragHeader.Fixed = true;
            this.dragHeader.Horizontal = true;
            this.dragHeader.TargetControl = this.pnlHeader;
            this.dragHeader.Vertical = true;
            // 
            // dragLogo
            // 
            this.dragLogo.Fixed = true;
            this.dragLogo.Horizontal = true;
            this.dragLogo.TargetControl = this.pbLogo;
            this.dragLogo.Vertical = true;
            // 
            // pbLogo
            // 
            this.pbLogo.BackColor = System.Drawing.Color.IndianRed;
            this.pbLogo.BackgroundImage = global::Simple_Youtube2Mp3.Properties.Resources.youtube2mp3Logo;
            this.pbLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbLogo.Location = new System.Drawing.Point(0, 0);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(166, 97);
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // dragTitle
            // 
            this.dragTitle.Fixed = true;
            this.dragTitle.Horizontal = true;
            this.dragTitle.TargetControl = this.lblTitle;
            this.dragTitle.Vertical = true;
            // 
            // dragVersion
            // 
            this.dragVersion.Fixed = true;
            this.dragVersion.Horizontal = true;
            this.dragVersion.TargetControl = this.lblVersion;
            this.dragVersion.Vertical = true;
            // 
            // pnlSide
            // 
            this.pnlSide.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlSide.BackgroundImage")));
            this.pnlSide.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlSide.Controls.Add(this.btnHistory);
            this.pnlSide.Controls.Add(this.btnSettings);
            this.pnlSide.Controls.Add(this.btnDownloads);
            this.pnlSide.Controls.Add(this.pbLogo);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.GradientBottomLeft = System.Drawing.Color.Firebrick;
            this.pnlSide.GradientBottomRight = System.Drawing.Color.IndianRed;
            this.pnlSide.GradientTopLeft = System.Drawing.Color.IndianRed;
            this.pnlSide.GradientTopRight = System.Drawing.Color.IndianRed;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Quality = 10;
            this.pnlSide.Size = new System.Drawing.Size(166, 560);
            this.pnlSide.TabIndex = 0;
            // 
            // btnHistory
            // 
            this.btnHistory.Activecolor = System.Drawing.Color.Firebrick;
            this.btnHistory.BackColor = System.Drawing.Color.IndianRed;
            this.btnHistory.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHistory.BorderRadius = 0;
            this.btnHistory.ButtonText = "     History";
            this.btnHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHistory.DisabledColor = System.Drawing.Color.White;
            this.btnHistory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistory.Iconcolor = System.Drawing.Color.Transparent;
            this.btnHistory.Iconimage = global::Simple_Youtube2Mp3.Properties.Resources.if_URL_History_64_32125;
            this.btnHistory.Iconimage_right = null;
            this.btnHistory.Iconimage_right_Selected = null;
            this.btnHistory.Iconimage_Selected = null;
            this.btnHistory.IconMarginLeft = 0;
            this.btnHistory.IconMarginRight = 0;
            this.btnHistory.IconRightVisible = true;
            this.btnHistory.IconRightZoom = 0D;
            this.btnHistory.IconVisible = true;
            this.btnHistory.IconZoom = 50D;
            this.btnHistory.IsTab = true;
            this.btnHistory.Location = new System.Drawing.Point(0, 193);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnHistory.OnHovercolor = System.Drawing.Color.Firebrick;
            this.btnHistory.OnHoverTextColor = System.Drawing.Color.White;
            this.btnHistory.selected = false;
            this.btnHistory.Size = new System.Drawing.Size(166, 48);
            this.btnHistory.TabIndex = 13;
            this.btnHistory.Text = "     History";
            this.btnHistory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistory.Textcolor = System.Drawing.Color.White;
            this.btnHistory.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Activecolor = System.Drawing.Color.Firebrick;
            this.btnSettings.BackColor = System.Drawing.Color.IndianRed;
            this.btnSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSettings.BorderRadius = 0;
            this.btnSettings.ButtonText = "     Settings";
            this.btnSettings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSettings.DisabledColor = System.Drawing.Color.White;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSettings.Iconimage = global::Simple_Youtube2Mp3.Properties.Resources.Settings;
            this.btnSettings.Iconimage_right = null;
            this.btnSettings.Iconimage_right_Selected = null;
            this.btnSettings.Iconimage_Selected = null;
            this.btnSettings.IconMarginLeft = 0;
            this.btnSettings.IconMarginRight = 0;
            this.btnSettings.IconRightVisible = true;
            this.btnSettings.IconRightZoom = 0D;
            this.btnSettings.IconVisible = true;
            this.btnSettings.IconZoom = 50D;
            this.btnSettings.IsTab = true;
            this.btnSettings.Location = new System.Drawing.Point(0, 145);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnSettings.OnHovercolor = System.Drawing.Color.Firebrick;
            this.btnSettings.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSettings.selected = false;
            this.btnSettings.Size = new System.Drawing.Size(166, 48);
            this.btnSettings.TabIndex = 12;
            this.btnSettings.Text = "     Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Textcolor = System.Drawing.Color.White;
            this.btnSettings.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnDownloads
            // 
            this.btnDownloads.Activecolor = System.Drawing.Color.Firebrick;
            this.btnDownloads.BackColor = System.Drawing.Color.Firebrick;
            this.btnDownloads.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDownloads.BorderRadius = 0;
            this.btnDownloads.ButtonText = "     Videos";
            this.btnDownloads.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloads.DisabledColor = System.Drawing.Color.White;
            this.btnDownloads.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDownloads.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDownloads.Iconimage = global::Simple_Youtube2Mp3.Properties.Resources.Video;
            this.btnDownloads.Iconimage_right = null;
            this.btnDownloads.Iconimage_right_Selected = null;
            this.btnDownloads.Iconimage_Selected = null;
            this.btnDownloads.IconMarginLeft = 0;
            this.btnDownloads.IconMarginRight = 0;
            this.btnDownloads.IconRightVisible = true;
            this.btnDownloads.IconRightZoom = 0D;
            this.btnDownloads.IconVisible = true;
            this.btnDownloads.IconZoom = 50D;
            this.btnDownloads.IsTab = true;
            this.btnDownloads.Location = new System.Drawing.Point(0, 97);
            this.btnDownloads.Name = "btnDownloads";
            this.btnDownloads.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnDownloads.OnHovercolor = System.Drawing.Color.Firebrick;
            this.btnDownloads.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDownloads.selected = true;
            this.btnDownloads.Size = new System.Drawing.Size(166, 48);
            this.btnDownloads.TabIndex = 11;
            this.btnDownloads.Text = "     Videos";
            this.btnDownloads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloads.Textcolor = System.Drawing.Color.White;
            this.btnDownloads.TextFont = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDownloads.Click += new System.EventHandler(this.btnDownloads_Click);
            // 
            // tmrFadeIn
            // 
            this.tmrFadeIn.Interval = 10;
            this.tmrFadeIn.Tick += new System.EventHandler(this.tmrFadeIn_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 560);
            this.Controls.Add(this.pnlContents);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlSide);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Free Youtube to mp3 converter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.pnlSide.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Panel pnlContents;
        private System.Windows.Forms.Panel pnlHeader;
        private Bunifu.Framework.UI.BunifuGradientPanel pnlSide;
        private System.Windows.Forms.PictureBox pbLogo;
        private Bunifu.Framework.UI.BunifuDragControl dragHeader;
        private Bunifu.Framework.UI.BunifuDragControl dragLogo;
        private Bunifu.Framework.UI.BunifuCustomLabel lblMinimize;
        private Bunifu.Framework.UI.BunifuCustomLabel lblExit;
        private Bunifu.Framework.UI.BunifuFlatButton btnHistory;
        private Bunifu.Framework.UI.BunifuFlatButton btnSettings;
        private Bunifu.Framework.UI.BunifuFlatButton btnDownloads;
        private System.Windows.Forms.Label lblTitle;
        private Bunifu.Framework.UI.BunifuDragControl dragTitle;
        private System.Windows.Forms.Label lblVersion;
        private Bunifu.Framework.UI.BunifuDragControl dragVersion;
        private System.Windows.Forms.Timer tmrFadeIn;
    }
}

