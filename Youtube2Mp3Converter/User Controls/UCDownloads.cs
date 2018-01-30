using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using YoutubeExplode;
using System.Runtime.InteropServices;
using Business_Logic_Layer;

namespace Simple_Youtube2Mp3
{
    public partial class UCDownloads : UserControl
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

        private IntPtr _clipboardViewerNext;

        private List<DownloadItem> toAutoDownloadVideos = new List<DownloadItem>();        
        string playlistId = "";

        public UCDownloads()
        {
            InitializeComponent();                     
            label2.Location = new Point(swConvert.Location.X - label2.Width - 5, label2.Location.Y);
            swConvert.Value = BLSettings.KeepMp4;
            _clipboardViewerNext = SetClipboardViewer(this.Handle);
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
        private const int WM_DRAWCLIPBOARD = 0x0308;        // WM_DRAWCLIPBOARD message       
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                try
                {
                    //call the paste button each time the user presses ctrl + C
                    IDataObject iData = Clipboard.GetDataObject();      // Clipboard's data
                   
                    if (iData.GetDataPresent(DataFormats.Text))
                    {
                        string text = (string)iData.GetData(DataFormats.Text);
                        if (BLSettings.IsCopyFromClipboard && !YoutubeClient.TryParsePlaylistId(text, out playlistId))
                            tmrClipboard.Start();
                    }
                }
                catch { }
            }
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {           
            DownloadItem item = DownloadItemManager.AddDownloadItem(Clipboard.GetText(), pnlVideos);
            if(item != null)
                toAutoDownloadVideos.Add(item);

            pnlLoading.Visible = false;
            lblLoading.Visible = false;

            if (BLSettings.IsAutomaticDownload)
                tmrDownload.Start();
        }

        private string GetSelectedPathWithFileName()
        {
            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {                                        
                    myStream.Close();
                    return saveFileDialog1.FileName;
                }
            }
            return null;
        }
        private void btnSaveList_Click(object sender, EventArgs e)
        {
            
            
            string commaSeperatedString = "";
            string path;
            foreach (DownloadItem video in DownloadItemManager.GetDownloadItems())
            {
                if(video.theVideo != null)
                    commaSeperatedString += "https://www.youtube.com/watch?v=" + video.theVideo.Id + ",";
            }
           
            if (!string.IsNullOrEmpty(commaSeperatedString))
            {
                path = GetSelectedPathWithFileName();
                if (!string.IsNullOrEmpty(path))
                {
                    commaSeperatedString = commaSeperatedString.Substring(0, commaSeperatedString.Length - 1);
                    File.WriteAllText(path, commaSeperatedString);
                }
            }
        }

        private void bnLoadList_Click(object sender, EventArgs e)
        {
            string path = FSManager.Files.GetSelectedFileWithPath("Text Files", "*.txt");

            if (!string.IsNullOrEmpty(path))
            {
                string commaSeperatedVideoUrls = File.ReadAllText(path);
                
                foreach (string url in commaSeperatedVideoUrls.Split(','))
                {
                    DownloadItemManager.AddDownloadItem(url, pnlVideos);
                }
            }

        }

        private async void btnDownloadAll_Click(object sender, EventArgs e)
        {
            foreach (DownloadItem item in DownloadItemManager.GetDownloadItems().Where(dl => !dl.isRunning && dl.isReady)) //Start all non-running ones
            {
                item.Download();                
            }
        }

        private void swConvert_Click(object sender, EventArgs e)
        {
            BLSettings.KeepMp4 = swConvert.Value;
        }

        private void pnlVideos_ControlAdded(object sender, ControlEventArgs e)
        {
            if(pnlVideos.Controls.Count > 0 )
            {
                pnlVideos.Visible = true;                
                pnlPreview.Visible = false;                
            }
        }

        private void pnlVideos_ControlRemoved(object sender, ControlEventArgs e)
        {
            if (pnlVideos.Controls.Count <= 0)
            {
                pnlVideos.Visible = false;
                pnlPreview.Visible = true;
            }
        }

       

        private void pnlVideos_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxPaste.Show(Cursor.Position);
            }
        }

        private void pnlPreview_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ctxPaste.Show(Cursor.Position);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnPaste_Click(sender, e);
        }

        private void tmrClipboard_Tick(object sender, EventArgs e)
        {
            //An ugly work-around for the fact that the clipboard event fires twice            
            btnPaste_Click(sender, e);
            tmrClipboard.Stop();            
        }

        private void tmrDownload_Tick(object sender, EventArgs e)
        {
            List<DownloadItem> toRemoveItems = new List<DownloadItem>();

            foreach (DownloadItem itm in toAutoDownloadVideos)
            {
                if (itm.isReady && BLSettings.IsAutomaticDownload)
                {
                    itm.Download();
                    toRemoveItems.Add(itm);
                }
            }
            foreach (DownloadItem itm in toRemoveItems)
            {
                toAutoDownloadVideos.Remove(itm);
            }

            if (toAutoDownloadVideos.Count <= 0)
                tmrDownload.Stop();
        }
    }
}
