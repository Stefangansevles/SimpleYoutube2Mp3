using System;
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
    public partial class MsgBox : Form
    {
        private string description;
        private static DialogResult result;
        private static MsgBox newMessageBox;
        private MsgBox(string description, MsgBoxReason buttons)
        {
            InitializeComponent();

            if (buttons == MsgBoxReason.YesNo)
            {
                btnYes.Visible = true;
                btnNo.Visible = true;
            }
            else
                btnOk.Visible = true;


            this.description = description;

            this.Opacity = 0;
            tmrFadeIn.Start();
            lblText.MaximumSize = new Size((pnlMainGradient.Width - lblText.Location.X) - 10, 0);
            lblTitle.MaximumSize = new Size((pnlMainGradient.Width - lblTitle.Location.X) - 10, 0);


            lblText.Text = description;




            //Resize the form so that the entire text shows
            while (pnlMainGradient.Height < (lblText.Location.Y + lblText.Height))
                this.Height += 35;


            Form1 mainForm = (Form1)Application.OpenForms["Form1"];
            if (mainForm != null)
            {
                //Place the message box in the middle of the main form
                this.StartPosition = FormStartPosition.Manual;
                this.Location = new Point(mainForm.Location.X + ((mainForm.Width / 2) - this.Width / 2), mainForm.Location.Y + ((mainForm.Height / 2) - (this.Height / 2)));
            }
            else
                this.StartPosition = FormStartPosition.CenterScreen;
        }
        private MsgBox(string title, string description, MsgBoxReason buttons) : this(description,buttons)
        {
            lblTitle.Text = title;

            //Reposition the text label so that the title label wont overlap
            while (lblTitle.Location.Y + lblTitle.Height >= lblText.Location.Y)
                lblText.Location = new Point(lblText.Location.X, lblText.Location.Y + 20);

            //Resize the form so that the entire text shows
            while (pnlMainGradient.Height < (lblText.Location.Y + lblText.Height))
                this.Height += 35;

        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.06;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }

        public static DialogResult Show(string text)
        {
            newMessageBox = new MsgBox(text, MsgBoxReason.OK);
            newMessageBox.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, MsgBoxReason buttons)
        {
            newMessageBox = new MsgBox(text, buttons);
            newMessageBox.ShowDialog();
            return result;
        }
        public static DialogResult Show(string text, string title, MsgBoxReason buttons)
        {
            newMessageBox = new MsgBox(text, title, buttons);
            newMessageBox.ShowDialog();
            return result;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            newMessageBox.Close();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            newMessageBox.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            result = DialogResult.OK;
            newMessageBox.Close();
        }
    }
    public enum MsgBoxReason
    {
        /// <summary>
        /// The message box contains a yes and a no button
        /// </summary>
        YesNo,
        /// <summary>
        /// The message box contains a cancel button
        /// </summary>
        OK
    }
}
