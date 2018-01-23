namespace Simple_Youtube2Mp3
{
    partial class UCDownloads
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSaveList = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bnLoadList = new Bunifu.Framework.UI.BunifuFlatButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDownloadAll = new Bunifu.Framework.UI.BunifuFlatButton();
            this.btnPaste = new Bunifu.Framework.UI.BunifuFlatButton();
            this.pnlVideos = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.swConvert = new Bunifu.Framework.UI.BunifuSwitch();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ctxPaste = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrClipboard = new System.Windows.Forms.Timer(this.components);
            this.tmrDownload = new System.Windows.Forms.Timer(this.components);
            this.pnlLoading = new System.Windows.Forms.PictureBox();
            this.lblLoading = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.ctxPaste.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSaveList);
            this.panel1.Controls.Add(this.bnLoadList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.btnDownloadAll);
            this.panel1.Controls.Add(this.btnPaste);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(704, 49);
            this.panel1.TabIndex = 0;
            // 
            // btnSaveList
            // 
            this.btnSaveList.Activecolor = System.Drawing.Color.IndianRed;
            this.btnSaveList.BackColor = System.Drawing.Color.IndianRed;
            this.btnSaveList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSaveList.BorderRadius = 0;
            this.btnSaveList.ButtonText = "Save";
            this.btnSaveList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveList.DisabledColor = System.Drawing.Color.Gray;
            this.btnSaveList.Iconcolor = System.Drawing.Color.Transparent;
            this.btnSaveList.Iconimage = global::Simple_Youtube2Mp3.Properties.Resources.text;
            this.btnSaveList.Iconimage_right = null;
            this.btnSaveList.Iconimage_right_Selected = null;
            this.btnSaveList.Iconimage_Selected = null;
            this.btnSaveList.IconMarginLeft = 0;
            this.btnSaveList.IconMarginRight = 0;
            this.btnSaveList.IconRightVisible = true;
            this.btnSaveList.IconRightZoom = 0D;
            this.btnSaveList.IconVisible = true;
            this.btnSaveList.IconZoom = 30D;
            this.btnSaveList.IsTab = false;
            this.btnSaveList.Location = new System.Drawing.Point(522, 12);
            this.btnSaveList.Name = "btnSaveList";
            this.btnSaveList.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnSaveList.OnHovercolor = System.Drawing.Color.Brown;
            this.btnSaveList.OnHoverTextColor = System.Drawing.Color.White;
            this.btnSaveList.selected = false;
            this.btnSaveList.Size = new System.Drawing.Size(70, 27);
            this.btnSaveList.TabIndex = 4;
            this.btnSaveList.Text = "Save";
            this.btnSaveList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveList.Textcolor = System.Drawing.Color.White;
            this.btnSaveList.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveList.Click += new System.EventHandler(this.btnSaveList_Click);
            // 
            // bnLoadList
            // 
            this.bnLoadList.Activecolor = System.Drawing.Color.IndianRed;
            this.bnLoadList.BackColor = System.Drawing.Color.IndianRed;
            this.bnLoadList.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bnLoadList.BorderRadius = 0;
            this.bnLoadList.ButtonText = "Load";
            this.bnLoadList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnLoadList.DisabledColor = System.Drawing.Color.Gray;
            this.bnLoadList.Iconcolor = System.Drawing.Color.Transparent;
            this.bnLoadList.Iconimage = global::Simple_Youtube2Mp3.Properties.Resources.text;
            this.bnLoadList.Iconimage_right = null;
            this.bnLoadList.Iconimage_right_Selected = null;
            this.bnLoadList.Iconimage_Selected = null;
            this.bnLoadList.IconMarginLeft = 0;
            this.bnLoadList.IconMarginRight = 0;
            this.bnLoadList.IconRightVisible = true;
            this.bnLoadList.IconRightZoom = 0D;
            this.bnLoadList.IconVisible = true;
            this.bnLoadList.IconZoom = 30D;
            this.bnLoadList.IsTab = false;
            this.bnLoadList.Location = new System.Drawing.Point(88, 12);
            this.bnLoadList.Name = "bnLoadList";
            this.bnLoadList.Normalcolor = System.Drawing.Color.IndianRed;
            this.bnLoadList.OnHovercolor = System.Drawing.Color.Brown;
            this.bnLoadList.OnHoverTextColor = System.Drawing.Color.White;
            this.bnLoadList.selected = false;
            this.bnLoadList.Size = new System.Drawing.Size(70, 27);
            this.bnLoadList.TabIndex = 3;
            this.bnLoadList.Text = "Load";
            this.bnLoadList.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bnLoadList.Textcolor = System.Drawing.Color.White;
            this.bnLoadList.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnLoadList.Click += new System.EventHandler(this.bnLoadList_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(173, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(339, 38);
            this.label1.TabIndex = 2;
            this.label1.Text = "           Press load to load a .txt list of videos\r\nPress save to save this list" +
    " so you can load it later";
            // 
            // btnDownloadAll
            // 
            this.btnDownloadAll.Activecolor = System.Drawing.Color.IndianRed;
            this.btnDownloadAll.BackColor = System.Drawing.Color.IndianRed;
            this.btnDownloadAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDownloadAll.BorderRadius = 0;
            this.btnDownloadAll.ButtonText = "Download";
            this.btnDownloadAll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadAll.DisabledColor = System.Drawing.Color.Gray;
            this.btnDownloadAll.Iconcolor = System.Drawing.Color.Transparent;
            this.btnDownloadAll.Iconimage = global::Simple_Youtube2Mp3.Properties.Resources.arrow_down_white;
            this.btnDownloadAll.Iconimage_right = null;
            this.btnDownloadAll.Iconimage_right_Selected = null;
            this.btnDownloadAll.Iconimage_Selected = null;
            this.btnDownloadAll.IconMarginLeft = 0;
            this.btnDownloadAll.IconMarginRight = 0;
            this.btnDownloadAll.IconRightVisible = true;
            this.btnDownloadAll.IconRightZoom = 0D;
            this.btnDownloadAll.IconVisible = true;
            this.btnDownloadAll.IconZoom = 40D;
            this.btnDownloadAll.IsTab = false;
            this.btnDownloadAll.Location = new System.Drawing.Point(598, 12);
            this.btnDownloadAll.Name = "btnDownloadAll";
            this.btnDownloadAll.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnDownloadAll.OnHovercolor = System.Drawing.Color.Brown;
            this.btnDownloadAll.OnHoverTextColor = System.Drawing.Color.White;
            this.btnDownloadAll.selected = false;
            this.btnDownloadAll.Size = new System.Drawing.Size(96, 27);
            this.btnDownloadAll.TabIndex = 1;
            this.btnDownloadAll.Text = "Download";
            this.btnDownloadAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDownloadAll.Textcolor = System.Drawing.Color.White;
            this.btnDownloadAll.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDownloadAll.Click += new System.EventHandler(this.btnDownloadAll_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.Activecolor = System.Drawing.Color.IndianRed;
            this.btnPaste.BackColor = System.Drawing.Color.IndianRed;
            this.btnPaste.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPaste.BorderRadius = 0;
            this.btnPaste.ButtonText = "Paste";
            this.btnPaste.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPaste.DisabledColor = System.Drawing.Color.Gray;
            this.btnPaste.Iconcolor = System.Drawing.Color.Transparent;
            this.btnPaste.Iconimage = global::Simple_Youtube2Mp3.Properties.Resources.clipboard;
            this.btnPaste.Iconimage_right = null;
            this.btnPaste.Iconimage_right_Selected = null;
            this.btnPaste.Iconimage_Selected = null;
            this.btnPaste.IconMarginLeft = 0;
            this.btnPaste.IconMarginRight = 0;
            this.btnPaste.IconRightVisible = true;
            this.btnPaste.IconRightZoom = 0D;
            this.btnPaste.IconVisible = true;
            this.btnPaste.IconZoom = 30D;
            this.btnPaste.IsTab = false;
            this.btnPaste.Location = new System.Drawing.Point(12, 12);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Normalcolor = System.Drawing.Color.IndianRed;
            this.btnPaste.OnHovercolor = System.Drawing.Color.Brown;
            this.btnPaste.OnHoverTextColor = System.Drawing.Color.White;
            this.btnPaste.selected = false;
            this.btnPaste.Size = new System.Drawing.Size(70, 27);
            this.btnPaste.TabIndex = 0;
            this.btnPaste.Text = "Paste";
            this.btnPaste.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaste.Textcolor = System.Drawing.Color.White;
            this.btnPaste.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // pnlVideos
            // 
            this.pnlVideos.AutoScroll = true;
            this.pnlVideos.Location = new System.Drawing.Point(1, 47);
            this.pnlVideos.Name = "pnlVideos";
            this.pnlVideos.Size = new System.Drawing.Size(700, 385);
            this.pnlVideos.TabIndex = 1;
            this.pnlVideos.Visible = false;
            this.pnlVideos.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlVideos_ControlAdded);
            this.pnlVideos.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlVideos_ControlRemoved);
            this.pnlVideos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlVideos_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(497, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Also download video";
            // 
            // swConvert
            // 
            this.swConvert.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.swConvert.BorderRadius = 0;
            this.swConvert.Cursor = System.Windows.Forms.Cursors.Hand;
            this.swConvert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.swConvert.Location = new System.Drawing.Point(643, 441);
            this.swConvert.Name = "swConvert";
            this.swConvert.Oncolor = System.Drawing.Color.IndianRed;
            this.swConvert.Onoffcolor = System.Drawing.Color.DarkGray;
            this.swConvert.Size = new System.Drawing.Size(51, 19);
            this.swConvert.TabIndex = 2;
            this.swConvert.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.swConvert.Value = false;
            this.swConvert.Click += new System.EventHandler(this.swConvert_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 10F);
            this.label3.ForeColor = System.Drawing.Color.Gray;
            this.label3.Location = new System.Drawing.Point(255, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 38);
            this.label3.TabIndex = 5;
            this.label3.Text = "Press paste or control + V \r\n  to paste your video url\r\n";
            // 
            // pnlPreview
            // 
            this.pnlPreview.Controls.Add(this.label4);
            this.pnlPreview.Controls.Add(this.pictureBox2);
            this.pnlPreview.Controls.Add(this.pictureBox1);
            this.pnlPreview.Controls.Add(this.label3);
            this.pnlPreview.Location = new System.Drawing.Point(1, 47);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(700, 385);
            this.pnlPreview.TabIndex = 6;
            this.pnlPreview.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pnlPreview_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 20F);
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(316, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 33);
            this.label4.TabIndex = 8;
            this.label4.Text = " + ";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Simple_Youtube2Mp3.Properties.Resources.computer_key_V;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(374, 178);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(74, 67);
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Simple_Youtube2Mp3.Properties.Resources.computer_key_Ctrl;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(231, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 67);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ctxPaste
            // 
            this.ctxPaste.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pasteToolStripMenuItem});
            this.ctxPaste.Name = "ctxPaste";
            this.ctxPaste.Size = new System.Drawing.Size(103, 26);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // tmrClipboard
            // 
            this.tmrClipboard.Tick += new System.EventHandler(this.tmrClipboard_Tick);
            // 
            // tmrDownload
            // 
            this.tmrDownload.Tick += new System.EventHandler(this.tmrDownload_Tick);
            // 
            // pnlLoading
            // 
            this.pnlLoading.Image = global::Simple_Youtube2Mp3.Properties.Resources.load25x25;
            this.pnlLoading.Location = new System.Drawing.Point(3, 435);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(25, 25);
            this.pnlLoading.TabIndex = 7;
            this.pnlLoading.TabStop = false;
            this.pnlLoading.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoading.Location = new System.Drawing.Point(31, 441);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(96, 17);
            this.lblLoading.TabIndex = 8;
            this.lblLoading.Text = "Receiving list...";
            this.lblLoading.Visible = false;
            // 
            // UCDownloads
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblLoading);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlVideos);
            this.Controls.Add(this.swConvert);
            this.Controls.Add(this.panel1);
            this.Name = "UCDownloads";
            this.Size = new System.Drawing.Size(704, 463);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlPreview.ResumeLayout(false);
            this.pnlPreview.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ctxPaste.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuFlatButton btnPaste;
        private Bunifu.Framework.UI.BunifuFlatButton btnDownloadAll;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuFlatButton bnLoadList;
        private Bunifu.Framework.UI.BunifuFlatButton btnSaveList;
        public System.Windows.Forms.Panel pnlVideos;
        private System.Windows.Forms.Label label2;
        private Bunifu.Framework.UI.BunifuSwitch swConvert;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnlPreview;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ContextMenuStrip ctxPaste;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.Timer tmrClipboard;
        private System.Windows.Forms.Timer tmrDownload;
        private System.Windows.Forms.PictureBox pnlLoading;
        private System.Windows.Forms.Label lblLoading;
    }
}
