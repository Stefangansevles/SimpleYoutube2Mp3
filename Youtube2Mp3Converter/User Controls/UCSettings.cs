using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.IO;
using System.Threading;

namespace Simple_Youtube2Mp3
{
    public partial class UCSettings : UserControl
    {
        public UCSettings()
        {
            InitializeComponent();
        }
      
        private void pbMP3Path_Click(object sender, EventArgs e)
        {
            string path = FSManager.Folders.GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(path))
            {
                tbMp3Path.Text = path;
                Settings set = BLSettings.GetSettings();
                set.MP3Path = path;
                BLSettings.UpdateSettings(set);
            }
        }

        private void pbVideoPath_Click(object sender, EventArgs e)
        {
            string path = FSManager.Folders.GetSelectedFolderPath();
            if (!string.IsNullOrEmpty(path))
            {
                tbVideoPath.Text = path;
                Settings set = BLSettings.GetSettings();
                set.VideoPath = path;
                BLSettings.UpdateSettings(set);
            }
        }

        private void UCSettings_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                if (!string.IsNullOrEmpty(BLSettings.MP3Path))
                    setTextboxText(tbMp3Path,BLSettings.MP3Path);
                else
                    setTextboxText(tbMp3Path, Environment.GetFolderPath(Environment.SpecialFolder.MyMusic));

                if (!string.IsNullOrEmpty(BLSettings.VideoPath))
                    setTextboxText(tbVideoPath, BLSettings.VideoPath);
                else
                    setTextboxText(tbVideoPath, Environment.GetFolderPath(Environment.SpecialFolder.MyVideos));

                if (!string.IsNullOrEmpty(BLSettings.SoundFile) && File.Exists(BLSettings.SoundFile))
                    setTextboxText(tbSoundFile, BLSettings.SoundFile);
                else
                    setTextboxText(tbSoundFile, "default");

                setCheckboxValue(cbAutomaticDownload, BLSettings.IsAutomaticDownload);
                setCheckboxValue(cbAutomaticPaste, BLSettings.IsCopyFromClipboard);
                setCheckboxValue(cbPlaySound, BLSettings.PlaySound);
                setCheckboxValue(cbShowNotification, BLSettings.ShowNotification);
            }).Start();
            
        }
      
        private void setTextboxText(Bunifu.Framework.UI.BunifuMetroTextbox tb, string txt)
        {
            tb.Invoke((MethodInvoker)(() =>
            {
                tb.Text = txt;
            }));
        }
        private void setCheckboxValue(Bunifu.Framework.UI.BunifuCheckbox cb, bool value)
        {
            cb.Invoke((MethodInvoker)(() =>
            {
                cb.Checked = value;
            }));
        }
        private void btnSoundFile_Click(object sender, EventArgs e)
        {
            
        }
        //prevent flickering / improve performance by setting every control to double buffered
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams handleParam = base.CreateParams;
                handleParam.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED       
                return handleParam;
            }
        }
        private void pbSoundFile_Click(object sender, EventArgs e)
        {
            string file = FSManager.Files.GetSelectedFileWithPath("Wave File", "*.wav");
            if (!string.IsNullOrEmpty(file))
            {
                //Get the current settings
                Settings set = BLSettings.GetSettings();
                //Alter the sound file of the settings
                set.SoundFile = file;
                //Write it to the database
                BLSettings.UpdateSettings(set);

                tbSoundFile.Text = file;
            }
        }

        private void lblAutomaticDownload_Click(object sender, EventArgs e)
        {
            cbAutomaticDownload.Checked = !cbAutomaticDownload.Checked;
            cbAutomaticDownload_OnChange(sender, e);
        }

        private void lblAutomaticPaste_Click(object sender, EventArgs e)
        {
            cbAutomaticPaste.Checked = !cbAutomaticPaste.Checked;
            cbAutomaticPaste_OnChange(sender, e);
        }

        private void cbAutomaticDownload_OnChange(object sender, EventArgs e)
        {            
            BLSettings.IsAutomaticDownload = cbAutomaticDownload.Checked;
        }

        private void cbAutomaticPaste_OnChange(object sender, EventArgs e)
        {           
            BLSettings.IsCopyFromClipboard = cbAutomaticPaste.Checked;
        }

        private void cbPlaySound_OnChange(object sender, EventArgs e)
        {            
            BLSettings.PlaySound = cbPlaySound.Checked;            
        }

        private void cbShowNotification_OnChange(object sender, EventArgs e)
        {
            BLSettings.ShowNotification = cbShowNotification.Checked;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            cbPlaySound.Checked = !cbPlaySound.Checked;
            cbPlaySound_OnChange(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            cbShowNotification.Checked = !cbShowNotification.Checked;
            cbShowNotification_OnChange(sender, e);
        }

        private void pbResetSound_Click(object sender, EventArgs e)
        {
            BLSettings.SoundFile = null;
            if (!string.IsNullOrEmpty(BLSettings.SoundFile) && File.Exists(BLSettings.SoundFile))
                setTextboxText(tbSoundFile, BLSettings.SoundFile);
            else
                setTextboxText(tbSoundFile, "default");
        }
    }
}
