namespace Simple_Youtube2Mp3
{
    partial class UCHistory
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
            this.pnlVideos = new System.Windows.Forms.Panel();
            this.lblNoHistory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlVideos
            // 
            this.pnlVideos.AutoScroll = true;
            this.pnlVideos.Location = new System.Drawing.Point(0, 13);
            this.pnlVideos.Name = "pnlVideos";
            this.pnlVideos.Size = new System.Drawing.Size(704, 450);
            this.pnlVideos.TabIndex = 2;
            this.pnlVideos.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlVideos_ControlAdded);
            this.pnlVideos.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlVideos_ControlRemoved);
            // 
            // lblNoHistory
            // 
            this.lblNoHistory.AutoSize = true;
            this.lblNoHistory.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoHistory.ForeColor = System.Drawing.Color.Gray;
            this.lblNoHistory.Location = new System.Drawing.Point(283, 194);
            this.lblNoHistory.Name = "lblNoHistory";
            this.lblNoHistory.Size = new System.Drawing.Size(151, 24);
            this.lblNoHistory.TabIndex = 0;
            this.lblNoHistory.Text = "No history yet!";
            this.lblNoHistory.Visible = false;
            // 
            // UCHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoHistory);
            this.Controls.Add(this.pnlVideos);
            this.Name = "UCHistory";
            this.Size = new System.Drawing.Size(704, 463);
            this.Load += new System.EventHandler(this.UCHistory_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Panel pnlVideos;
        private System.Windows.Forms.Label lblNoHistory;
    }
}
