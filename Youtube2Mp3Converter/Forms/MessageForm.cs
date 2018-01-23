﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Youtube2Mp3
{
    public partial class MessageForm : Form
    {
        int timeout = 0;
        int secondsPassed = 0;
        public MessageForm(string message, int timeout)
        {
            InitializeComponent();

            //Not visible                   
            this.Opacity = 0.0;
            //Make it so that the text won't go out of bounds horizontally, so the panel has to grow vertically
            lblText.MaximumSize = new Size(pnlText.Width - 15, 0);
            //Set the text
            lblText.Text = message;
            //Enlarge the panel if needed
            FitPanel(pnlText);


            //No active popup forms? set it to default position
            if (MessageFormManager.GetPopupforms().Count == 0)
            {
                //Set the location to the bottom right corner of the user's screen and a little bit above the taskbar    
                this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width - 5, Screen.GetWorkingArea(this).Height - this.Height - 5);
            }
            else
            {
                int alreadyActiveFormCount = MessageFormManager.GetPopupforms().Count;
                //Set the location to the bottom right corner of the user's screen, and above all other active popups
                this.Location = new Point(Screen.GetWorkingArea(this).Width - this.Width - 5, Screen.GetWorkingArea(this).Height - (this.Height * (alreadyActiveFormCount + 1)) - ((alreadyActiveFormCount + 1) * 5));
            }

            this.timeout = timeout;
            //Start the timer that will "slowly" make the form more transparent
            tmrFadein.Start();
        }
        public MessageForm(string title, string message, int timeout) : this(message, timeout)
        {
            lblTitle.Text = title;
        }

        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;

                handleParam.ExStyle |= WS_EX_NOACTIVATE; //This starts the form without activating it, meaning if you're playing a full-screen game, and you're holding down the w key, this form will not interrupt it. 
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                return handleParam;
            }
        }

        private void FitPanel(Panel pnl)
        {
            int maxright = 0;
            int maxbottom = 0;
            foreach (Control ctl in pnl.Controls)
            {
                maxright = (ctl.Right > maxright ? ctl.Right : maxright);
                maxbottom = (ctl.Bottom > maxbottom ? ctl.Bottom : maxbottom);
            }
            int deltabottom = pnl.Bottom - (pnl.Top + maxbottom);
            int deltaright = pnl.Right - (pnl.Left + maxright);
            Form frm = pnl.FindForm();
            frm.SuspendLayout();

            if (frm.Height - deltabottom > frm.Height) //Dont shrink, only enlarge
            {
                frm.Height = frm.Height - deltabottom;
                frm.Height += 10; //Enlarge it just a little bit more to make it look better
            }

            if (frm.Width - deltaright > frm.Width)     //Dont shrink, only enlarge
                frm.Width = frm.Width - deltaright;

            frm.ResumeLayout();
        }

             
      

        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            MessageFormManager.RepositionActivePopups();
        }

      

        private void tmrTimeout_Tick(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(MousePosition))
            {
                secondsPassed = 0;
            }
            else
            {
                secondsPassed++;

                if (secondsPassed >= timeout)
                {
                    tmrTimeout.Stop();
                    secondsPassed = 0;
                    tmrFadeout.Start();
                }
            }
        }

        private void MessageForm_Load(object sender, EventArgs e)
        {
            this.TopMost = true; //Popup will be always on top. no matter what you are doing, playing a game, watching a video, you will ALWAYS see the popup.
            this.TopLevel = true;
        }

        private void tmrFadeout_Tick(object sender, EventArgs e)
        {
            if (this.Bounds.Contains(MousePosition)) //Cursor in the message? reset opacity to 1 and restart timeout timer
            {
                this.Opacity = 1;
                secondsPassed = 0;
                tmrTimeout.Start();
            }
            else //Cursor out of the message? safely reduce opacity "slowly"
            {
                this.Opacity -= 0.02;
                if (this.Opacity <= 0)
                {
                    tmrFadeout.Stop();

                    tmrFadein.Dispose();
                    tmrFadeout.Dispose();
                    tmrTimeout.Dispose();
                    this.Dispose();
                    MessageFormManager.RepositionActivePopups();
                }
            }
        }

        private void tmrFadein_Tick(object sender, EventArgs e)
        {
             this.Opacity += 0.02;
            if (this.Opacity >= 1)
            {
                tmrFadein.Stop();
                tmrTimeout.Start();
            }
            if (this.Bounds.Contains(MousePosition))
            {
                tmrFadein.Stop();
                tmrTimeout.Start();
                this.Opacity = 1;
                secondsPassed = 0;
            }
        }
    }
}
