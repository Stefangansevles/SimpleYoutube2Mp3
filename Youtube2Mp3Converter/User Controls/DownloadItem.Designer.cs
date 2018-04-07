namespace Simple_Youtube2Mp3
{
    partial class DownloadItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.lblExit = new Bunifu.Framework.UI.BunifuCustomLabel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pbDownload = new System.Windows.Forms.ProgressBar();
            this.tmrCheckProgress = new System.Windows.Forms.Timer(this.components);
            this.pbLoad = new System.Windows.Forms.PictureBox();
            this.btnDownload = new Bunifu.Framework.UI.BunifuImageButton();
            this.pbYoutubeThumbnail = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYoutubeThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this.pbYoutubeThumbnail;
            // 
            // lblExit
            // 
            this.lblExit.AutoSize = true;
            this.lblExit.BackColor = System.Drawing.Color.Transparent;
            this.lblExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblExit.Enabled = false;
            this.lblExit.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExit.ForeColor = System.Drawing.Color.Black;
            this.lblExit.Location = new System.Drawing.Point(656, 0);
            this.lblExit.Name = "lblExit";
            this.lblExit.Size = new System.Drawing.Size(22, 22);
            this.lblExit.TabIndex = 5;
            this.lblExit.Text = "X";
            this.lblExit.Click += new System.EventHandler(this.lblExit_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTitle.Location = new System.Drawing.Point(93, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(81, 17);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "Acquiring...";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Century Gothic", 9F);
            this.lblStatus.Location = new System.Drawing.Point(127, 36);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(74, 17);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Acquiring...";
            // 
            // pbDownload
            // 
            this.pbDownload.Location = new System.Drawing.Point(223, 32);
            this.pbDownload.Name = "pbDownload";
            this.pbDownload.Size = new System.Drawing.Size(361, 20);
            this.pbDownload.TabIndex = 11;
            // 
            // tmrCheckProgress
            // 
            this.tmrCheckProgress.Tick += new System.EventHandler(this.tmrCheckProgress_Tick);
            // 
            // pbLoad
            // 
            this.pbLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbLoad.Location = new System.Drawing.Point(96, 30);
            this.pbLoad.Name = "pbLoad";
            this.pbLoad.Size = new System.Drawing.Size(25, 25);
            this.pbLoad.TabIndex = 8;
            this.pbLoad.TabStop = false;
            // 
            // btnDownload
            // 
            this.btnDownload.BackColor = System.Drawing.Color.Transparent;
            this.btnDownload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDownload.Enabled = false;
            this.btnDownload.Image = global::Simple_Youtube2Mp3.Properties.Resources.arrow;
            this.btnDownload.ImageActive = null;
            this.btnDownload.Location = new System.Drawing.Point(601, 21);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(35, 35);
            this.btnDownload.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDownload.TabIndex = 6;
            this.btnDownload.TabStop = false;
            this.btnDownload.Zoom = 10;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // pbYoutubeThumbnail
            // 
            this.pbYoutubeThumbnail.BackColor = System.Drawing.Color.White;
            this.pbYoutubeThumbnail.Location = new System.Drawing.Point(10, 7);
            this.pbYoutubeThumbnail.Name = "pbYoutubeThumbnail";
            this.pbYoutubeThumbnail.Size = new System.Drawing.Size(60, 45);
            this.pbYoutubeThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbYoutubeThumbnail.TabIndex = 0;
            this.pbYoutubeThumbnail.TabStop = false;
            // 
            // DownloadItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pbDownload);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.pbLoad);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.lblExit);
            this.Controls.Add(this.pbYoutubeThumbnail);
            this.Name = "DownloadItem";
            this.Size = new System.Drawing.Size(679, 59);
            this.Load += new System.EventHandler(this.DownloadItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLoad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDownload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbYoutubeThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbYoutubeThumbnail;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private Bunifu.Framework.UI.BunifuCustomLabel lblExit;
        private Bunifu.Framework.UI.BunifuImageButton btnDownload;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.PictureBox pbLoad;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ProgressBar pbDownload;
        private System.Windows.Forms.Timer tmrCheckProgress;
    }
}
