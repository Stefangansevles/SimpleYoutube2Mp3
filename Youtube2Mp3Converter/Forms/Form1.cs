using Business_Logic_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;

namespace Simple_Youtube2Mp3
{
    public partial class Form1 : Form
    {       
        UCDownloads ucDownloads;
        UCSettings ucSettings;
        UCHistory ucHistory;
        
        private static readonly string DB_FILE = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Simple Youtube2Mp3\\Simple Youtube2Mp3.db";
        public Form1()
        {
            InitializeComponent();
            tmrFadeIn.Start();
            AppDomain.CurrentDomain.SetData("DataDirectory", DB_FILE);
            Directory.CreateDirectory(BLIO.rootFolder);
            Directory.CreateDirectory(BLIO.rootFolder + "\\Video");
            BLIO.CreateDatabaseIfNotExist();
            this.Opacity = 0;
            ucDownloads = new UCDownloads();
            pnlContents.Controls.Add(ucDownloads);
            
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

        private void Form1_Load(object sender, EventArgs e)
        {
            new Thread(() =>
            {
                //Version number
                System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
                lblVersion.Invoke((MethodInvoker)(() =>
                {
                    lblVersion.Text = "Version " + fvi.FileVersion;
                }));

                ucSettings = new UCSettings();
                ucHistory = new UCHistory();
                



                //Clear the .mp4 files in the folder if the application has been exited during downloading/converting
                if (FSManager.Files.GetFileNamesInFolder(BLIO.rootFolder + "\\Video\\").Length > 0)
                {
                    FSManager.Folders.DeleteFilesInFolder(BLIO.rootFolder + "\\Video\\");
                }

                if (!File.Exists(BLSettings.SoundFile))
                {//Sound file from the database doesn't exist. Set to default
                    BLSettings.SoundFile = null;
                }

                
                LoadUserControls();                
                
                
            }).Start();


            

        }


        private void LoadUserControls()
        {            
            new Thread(() =>
            {
                try
                {                    
                    pnlContents.Invoke((MethodInvoker)(() =>
                    {                                                
                        pnlContents.Controls.Add(ucSettings);
                        pnlContents.Controls.Add(ucHistory);
                       
                        ucSettings.Invoke((MethodInvoker)(() =>
                        {
                            ucSettings.Visible = false;

                        }));
                        ucHistory.Invoke((MethodInvoker)(() =>
                        {
                            ucHistory.Visible = false;

                        }));                  
                    }));
                }
                catch(Exception)
                {
                    
                }
            }).Start();
        }
        #region exit/minimize label events
        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Transparent;
        }
        private void lblMinimize_MouseLeave(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.Transparent;            
        }


        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.DarkRed;
        }      
        private void lblMinimize_MouseEnter(object sender, EventArgs e)
        {
            lblMinimize.ForeColor = Color.CornflowerBlue;
        }
        #endregion

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //Capture ctrl+v events
            if (keyData == (Keys.Control | Keys.V) && btnDownloads.selected)
            {
                DownloadItemManager.AddDownloadItem(Clipboard.GetText(), ucDownloads.pnlVideos);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void lblMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblExit_Click(object sender, EventArgs e)
        {

            this.Dispose();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {            
            ShowUserControl(ucHistory);
        }
        private void ShowUserControl(UserControl uc)
        {
            if(uc == ucDownloads)
            {
                ucDownloads.Visible = true;
                ucHistory.Visible = false;
                ucSettings.Visible = false;
            }
            if (uc == ucSettings)
            {
                ucSettings.Visible = true;
                ucHistory.Visible = false;
                ucDownloads.Visible = false;
            }
            if (uc == ucHistory)
            {
                ucHistory.Visible = true;
                ucSettings.Visible = false;
                ucDownloads.Visible = false;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucSettings);           
        }
       
        private void btnDownloads_Click(object sender, EventArgs e)
        {
            ShowUserControl(ucDownloads);
        }

        private void tmrFadeIn_Tick(object sender, EventArgs e)
        {
            this.Opacity += 0.1;
            if (this.Opacity >= 1)
                tmrFadeIn.Stop();
        }
    }
}
