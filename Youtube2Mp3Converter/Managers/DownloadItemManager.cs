using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExplode;

namespace Simple_Youtube2Mp3
{
    /// <summary>
    /// Manages the Download items. Keeps track of the pasted videos.
    /// </summary>
    public class DownloadItemManager
    {
        private static List<DownloadItem> downloadItems = new List<DownloadItem>();
        private static Timer tmrDelete;
        public static List<string> toDeleteFiles = new List<string>();
        private static bool timerIsRunning = false;
        private DownloadItemManager() { }

        public static void StartTimer()
        {
            if (!timerIsRunning)
            {
                timerIsRunning = true;
                tmrDelete = new Timer();
                tmrDelete.Interval = 1000;
                tmrDelete.Start();
                tmrDelete.Tick += tmrDelete_Tick;
            }            
        }

        private static void tmrDelete_Tick(object sender, EventArgs e)
        {
            timerIsRunning = true;
            if (toDeleteFiles.Count <= 0)
            {
                timerIsRunning = false;
                tmrDelete.Stop();
            }

            for(int i = toDeleteFiles.Count; i > 0; i--)
            {
                try
                {
                    File.Delete(toDeleteFiles[i-1]);
                    toDeleteFiles.Remove(toDeleteFiles[i-1]);
                }
                catch(Exception) {}
            }

        }

        /// <summary>
        /// Re-positions every DownloadItem when for example one has been removed.
        /// </summary>
        public static void RepositionDownloadItems()
        {
            
            if (downloadItems[0].IsDisposed && downloadItems.Count > 1) //The first one was removed!
                downloadItems[1].Location = new Point(downloadItems[0].Location.X, downloadItems[0].Location.Y); //Item removed? Set the 2nd item to that location

            //Go through the list, and remove all items that are disposed.
            for (int i = downloadItems.Count - 1; i >= 0; i--)
            {
                if (downloadItems[i].IsDisposed)
                    downloadItems.RemoveAt(i);
            }


            int y = 0;
            if (downloadItems.Count > 0)
            {
                y = downloadItems[0].Location.Y;  //DONT set it to y = 0; when scrolled down in the panel, 0 will not be where it was.
                foreach (DownloadItem item in downloadItems)
                {
                    item.Location = new Point(item.Location.X, y);
                    y += item.Height;
                }

            }
        }
        /// <summary>
        /// Re-positions every DownloadItem when for example one has been removed.
        /// </summary>
        public static void RepositionDownloadItems(List<DownloadItem> collection)
        {

            if (collection[0].IsDisposed && collection.Count > 1) //The first one was removed!
                collection[1].Location = new Point(collection[0].Location.X, collection[0].Location.Y); //Item removed? Set the 2nd item to that location

            //Go through the list, and remove all items that are disposed.
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                if (collection[i].IsDisposed)
                    collection.RemoveAt(i);
            }

            int y = 0;
            if (collection.Count > 0)
            {
                y = collection[0].Location.Y;  //DONT set it to y = 0; when scrolled down in the panel, 0 will not be where it was.
                foreach (DownloadItem item in collection)
                {
                    item.Location = new Point(item.Location.X, y);
                    y += item.Height;
                }

            }
        }



        private static async void AddDownloadItems(string url, Panel pnl)
        {
            try
            {
                YoutubeClient client = new YoutubeClient();

                //Get the playlist object from the id
                YoutubeExplode.Models.Playlist playList = await client.GetPlaylistAsync(url);
                
                //We now have a playlist with every video from that playlist. (.Videos)
                foreach (YoutubeExplode.Models.Video video in playList.Videos)
                {
                    DownloadItem item = new DownloadItem(video);
                    //Determines where to place the downloadItem
                    int y = 0;
                    if (downloadItems.Count > 0)
                        y = downloadItems[downloadItems.Count - 1].Location.Y + item.Height;


                    pnl.Controls.Add(item);
                    item.Location = new Point(item.Location.X, y);
                    downloadItems.Add(item);
                }
            }
            catch (Exception)
            {
                MessageFormManager.MakeMessagePopup("Something went wrong!", "Could not find a video with that youtube url!\r\nPlease try again.", 5);
            }
        }
        /// <summary>
        /// Adds a downloadItem to the panel
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pnl"></param>
        public static DownloadItem AddDownloadItem(string url,Panel pnl)
        {
            try
            {                
                string playlistId = "";
                string videoId = "";               
                YoutubeClient.TryParsePlaylistId(url, out playlistId);
                YoutubeClient.TryParseVideoId(url, out videoId);
                //VideoId AND playlistId valid? Then this is a song inside a playlist
                if (!string.IsNullOrEmpty(playlistId) && !string.IsNullOrEmpty(videoId)
                    && MsgBox.Show("Attention", "This video is part of a playlist. Do you wish to download the entire playlist?", MsgBoxReason.YesNo) == DialogResult.Yes)
                {
                    AddDownloadItems(playlistId, pnl);
                }
                else if (!string.IsNullOrEmpty(videoId))
                {
                    DownloadItem toAddItem = new DownloadItem(url);
                    if(downloadItems.Count > 0)
                        toAddItem.Location = new Point(0, downloadItems[downloadItems.Count-1].Location.Y + toAddItem.Height);
                    

                    downloadItems.Add(toAddItem);                                       
                    pnl.Controls.Add(toAddItem);                                       
                    return toAddItem;
                }
                else if (!string.IsNullOrEmpty(playlistId))
                {
                    AddDownloadItems(playlistId, pnl);
                    return null;
                }
            }
            catch (Exception)
            {
                MessageFormManager.MakeMessagePopup("Something went wrong!", "Could not find a video with that youtube url!\r\nPlease try again.", 5);
            }
            return null;
        }

        /// <summary>
        /// Adds a downloadItem to the panel
        /// </summary>
        /// <param name="item"></param>
        /// <param name="pnl"></param>
        public static DownloadItem AddDownloadItem(YoutubeExplode.Models.Video video,Panel pnl)
        {
            try
            {
                DownloadItem toAddItem = new DownloadItem(video);
                //Determines where to place the downloadItem
                int y = 0;
                if (downloadItems.Count > 0)
                {                    
                    y = downloadItems.Count * downloadItems.Where(itm => !itm.IsDisposed).ToList()[0].Height;
                }

                pnl.Invoke((MethodInvoker)(() =>
                {
                    pnl.Controls.Add(toAddItem);
                }));

                toAddItem.Invoke((MethodInvoker)(() =>
                {
                    toAddItem.Location = new Point(toAddItem.Location.X, y);
                }));
                
                downloadItems.Add(toAddItem);
                return toAddItem;
            }
            catch (Exception ex)
            {
                MessageFormManager.MakeMessagePopup("Something went wrong!", "Could not find a video with that youtube url!\r\nPlease try again.", 5);
            }
            return null;
        }

        /// <summary>
        /// Returns all (non-disposed)download items.
        /// </summary>
        /// <returns></returns>
        public static List<DownloadItem> GetDownloadItems()
        {
            return downloadItems.Where(itm => !itm.IsDisposed).ToList();
        }

        

    }
}
