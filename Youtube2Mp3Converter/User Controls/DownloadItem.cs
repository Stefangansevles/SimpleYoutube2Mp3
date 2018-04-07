using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeExtractor;
using System.Threading;
using Business_Logic_Layer;
using System.IO;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;
using System.Diagnostics;
using Database.Entity;
using System.Runtime.InteropServices;
using YoutubeExplode.Exceptions;
using System.Net.Http;

namespace Simple_Youtube2Mp3
{
    /// <summary>
    /// This is a download item. It contains the youtube thumbnail, the title and a download button
    /// </summary>
    public partial class DownloadItem : UserControl
    {
        public string youtubeUrl = "";
        private string pathToVideo = "";
        private string pathToSong = "";
        private bool canDownload = true; //If we could not succesfully obtain the video information, we certainly can't download it        
         
        public bool isReady = false;
        private bool isConverting = false;
        private bool isDownloading = false;
        private bool isHistory = false;
        //Cancellation token for the downloading progress
        CancellationTokenSource ctsDownload = new CancellationTokenSource();
        //Cancellation token for the converting progress
        CancellationTokenSource ctsConvert = new CancellationTokenSource();
        //The FFMPEG converter that converts video to mp3
        NReco.VideoConverter.FFMpegConverter FFMpegConverter;
        
        //Create a youtubeclient
        YoutubeClient client = new YoutubeClient();
        DownloadHistory historyRecord;
        public YoutubeExplode.Models.Video theVideo = null;
        public YoutubeExplode.Models.Playlist thePlaylist = null;

        Task downloadTask;
        Task convertTask;

        int retryCount = 0;
        public DownloadItem(string youtubeUrl)
        {            
            InitializeComponent();
                    
            this.youtubeUrl = youtubeUrl;           
        }
        public DownloadItem(YoutubeExplode.Models.Video theVideo)
        {
            InitializeComponent();
            this.theVideo = theVideo;
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
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        public bool IsActive(IntPtr handle)
        {
            IntPtr activeHandle = GetForegroundWindow();
            return (activeHandle == handle);
        }

        public DownloadItem(DownloadHistory history)
        {
            //When a new instance of DownloadItem is created with this constructor, it is being used to show it as history. There will not be a download button
            InitializeComponent();
            isHistory = true;
            historyRecord = history;
            
         

            new Thread(async () =>
            {
                try
                {
                    //Because for some reason assigning 5 to a property that already is 5 makes it work. ? It doesn't show the elipse radius without this.
                    bunifuElipse1.ElipseRadius = 5;
                    
                    pbYoutubeThumbnail.Load(history.ThumbnailLink);
                    theVideo = await client.GetVideoAsync(history.VideoId);                    
                }
                catch { }
            }).Start();

            
           

            lblStatus.Location = pbLoad.Location;
            lblStatus.Text = history.DownloadDate;
            btnDownload.Enabled = true;
            pbLoad.Visible = false;                        
            lblExit.Enabled = true;
            string completeString = "";
            string subAuthor = "";
            string subTitle = "";
            if (history.Title.Length > 33)
            {
                subTitle = history.Title.Substring(0, 33) + "...";
                completeString += subTitle + "   ";
            }
            else
            {
                completeString += history.Title + "   ";
            }


            if (history.ChannelTitle.Length > 23)
            {
                subAuthor = history.ChannelTitle.Substring(0, 23) + "...";
                completeString += subAuthor + "   ";
            }
            else
            {
                completeString += history.ChannelTitle + "   ";
            }



            completeString += history.Duration;
            lblTitle.Text = completeString;
        }


        #region Methods that change controls thread-safe
        private void setLabelText(Label lbl,string text)
        {
            try
            {
                lbl.Invoke((MethodInvoker)(() =>
                {
                    lbl.Text = text;
                }));
            }
            catch { }
        }
        private void setProgressbarValue(ProgressBar pb, int value)
        {
            try
            {
                pb.Invoke((MethodInvoker)(() =>
                {
                    pb.Value = value;
                }));
            }
            catch { }
        }
        #endregion



        /// <summary>
        /// Indicates if this is currently busy downloading/converting      
        /// </summary>
        public bool isRunning
        {
            get
            {                
                return (isDownloading || isConverting);
            }
        }


        private void ConvertToMp3(string filePath)
        {
            //Start converting into .mp3
            convertTask = Task.Factory.StartNew(async () =>
            {
                lblStatus.Invoke((MethodInvoker)(() =>
                {
                    isConverting = true;
                    pbLoad.BackgroundImage = null;
                    pbLoad.Image = Properties.Resources.load25x25;
                    lblStatus.Text = "Converting...";
                }));

                FFMpegConverter = new NReco.VideoConverter.FFMpegConverter();
                FFMpegConverter.FFMpegToolPath = BLIO.rootFolder + "\\Video\\";
                FFMpegConverter.ConvertProgress += (o, args) =>
                {                                                         
                    try
                    {                       
                        pbDownload.Invoke((MethodInvoker)(() =>
                        {                            
                            pbDownload.Value = (int)Math.Round((args.Processed.TotalMilliseconds / args.TotalDuration.TotalMilliseconds) * 100);
                            if(pbDownload.Value >= 99)
                                tmrCheckProgress.Start();
                        }));
                    }
                    catch (InvalidOperationException) { }//Thread aborted, can't do things with the controls anymore


                    Console.WriteLine(string.Format("Progress: {0} / {1}\r\n", args.Processed, args.TotalDuration));
                };


                pathToSong = GetValidFilePath(BLSettings.MP3Path,theVideo.Title, "." + BLSettings.AudioType);                

                try
                {
                    await Task.Run(() => FFMpegConverter.ConvertMedia(filePath, pathToSong,BLSettings.AudioType));
                    if(File.Exists(pathToSong))
                    {
                        DownloadHistory historyRecord = new DownloadHistory();
                        historyRecord.ChannelTitle = theVideo.Author;
                        historyRecord.DownloadDate = DateTime.Now.ToString();
                        historyRecord.Duration = theVideo.Duration.ToString();
                        historyRecord.ThumbnailLink = "http://img.youtube.com/vi/" + theVideo.Id + "/0.jpg";
                        historyRecord.Title = theVideo.Title;
                        historyRecord.VideoId = theVideo.Id;

                        UCHistory history = (UCHistory)this.Parent.Parent.Parent.Controls["ucHistory"];
                        DownloadItem item = new DownloadItem(historyRecord);
                        item.theVideo = theVideo;                        
                        history.AddHistory(item);

                        BLHistory.InsertRecord(historyRecord);


                   
                        if (BLSettings.KeepMp4)
                            File.Move(BLIO.rootFolder + "\\Video\\" + RemoveIllegalCharacters(Path.GetFileNameWithoutExtension(filePath)) + "." + BLSettings.VideoType, BLSettings.VideoPath + "\\" + RemoveIllegalCharacters(Path.GetFileNameWithoutExtension(filePath)) + "." + BLSettings.VideoType);
                        else
                            File.Delete(BLIO.rootFolder + "\\Video\\" + RemoveIllegalCharacters(filePath) + "." + BLSettings.VideoType);                                           
                    }
                }
                catch (NullReferenceException) { } //Nullreference exception occurs when aborting the convert task
           

            }, ctsConvert.Token);            
        }

        /// <summary>
        /// Gives a new name to a filename if the filename already exists
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string GetValidFilePath(string folder, string fileName,string extension)
        {
            string filePath = "";
            if (!File.Exists(folder + "\\" + RemoveIllegalCharacters(fileName) + extension))
                filePath = folder + "\\" + RemoveIllegalCharacters(fileName) + extension;
            else
            {
                int numbersToAdd = 1;
                if (File.Exists(folder + "\\" + RemoveIllegalCharacters(fileName) + " - " + numbersToAdd + extension))
                {
                    while (File.Exists(folder + "\\" + RemoveIllegalCharacters(fileName) + " - " + numbersToAdd + extension))
                    {
                        if (File.Exists(folder + "\\" + RemoveIllegalCharacters(fileName) + " - " + numbersToAdd + extension))
                            numbersToAdd++;
                        else
                            filePath = folder + "\\" + RemoveIllegalCharacters(fileName) + " - " + numbersToAdd + extension;
                    }
                    filePath = folder + "\\" + RemoveIllegalCharacters(fileName) + " - " + numbersToAdd + extension;
                }
                else
                    filePath = folder + "\\" + RemoveIllegalCharacters(fileName) + " - " + numbersToAdd + extension;
            }
            return filePath;
        }

        public async void Download()
        {
            try
            {

                isDownloading = true;                
                if (!canDownload)
                    return;

                pbLoad.Image = null;
                if (!downloadTask.IsCanceled)
                {
                    btnDownload.Enabled = false;
                    if (theVideo == null)
                    {
                        lblStatus.Location = pbLoad.Location;
                        MessageFormManager.MakeMessagePopup("Could not download that video!\r\nIt might be unavailable", 6);
                        return;
                    }
                    //Set the image to zzz - enqueue'd. Then, if it can download(if there aren't already a few threads downloading) it will change to downloading...
                    pbLoad.BackgroundImage = Properties.Resources.zzz;
                    lblStatus.Visible = true;
                    lblStatus.Text = "Enqueued.";
                    lblExit.Enabled = false;                    



                    MediaStreamInfoSet streamInfoSet = await client.GetVideoMediaStreamInfosAsync(theVideo.Id);
                    var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
                    if (BLSettings.KeepMp4) 
                    {//Audio only                        
                    }
                    else
                    {//Video too

                    }
                                      
                    pbLoad.BackgroundImage = null;
                    pbLoad.Image = Properties.Resources.load25x25;
                    lblStatus.Text = "Downloading...";


                    pathToVideo = GetValidFilePath(BLIO.rootFolder + "\\Video\\", theVideo.Title, "." + BLSettings.VideoType);

                    downloadTask = Task.Run(async () =>
                    {
                        lblExit.Invoke((MethodInvoker)(() =>
                        {
                            lblExit.Enabled = true;
                        }));
                       
                        ctsDownload.Token.ThrowIfCancellationRequested();
                        await client.DownloadMediaStreamAsync(streamInfo, pathToVideo, new Progress<double>(d => setProgressbarValue(pbDownload, (int)Math.Round(Convert.ToDouble(d.ToString()) * 100))), ctsDownload.Token);
                    }, ctsDownload.Token);

                    if (!downloadTask.IsCanceled)
                        await downloadTask;


                    pbLoad.Image = null;
                    pbLoad.BackgroundImage = Properties.Resources.load25x25;
                    lblStatus.Text = "Preparing...";

                    ConvertToMp3(pathToVideo);
                }
            }
            catch (System.Threading.Tasks.TaskCanceledException ex)
            {
                //Probably a timeout! multiple other threads downloading. gotta wait for them to finish, re-try this one.
                lblStatus.Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = "Failed.";
                }));
                Download();
            }
            catch (VideoUnavailableException ex)
            {

                if (ex.Code == 150) //Video not available in your country
                {
                    MessageFormManager.MakeMessagePopup(theVideo.Title + " Is not available in your country", 7);
                    lblStatus.Invoke((MethodInvoker)(() =>
                    {
                        lblStatus.Text = "Failed.";
                    }));
                }
                else
                {
                    //Re-try!
                    lblStatus.Invoke((MethodInvoker)(() =>
                    {
                        lblStatus.Text = "Retrying...";
                    }));
                    
                    Download();
                }
            }
            catch (HttpRequestException ex)
            {
                //Re-try!
                lblStatus.Invoke((MethodInvoker)(() =>
                {
                    lblStatus.Text = "Retrying...";
                }));

                Download();
            }
        }
        public async void Download(YoutubeExplode.Models.Video video)
        {
            try
            {                                
                if (!canDownload)
                    return;                

                isDownloading = true;

                //Set the image to zzz - enqueue'd. Then, if it can download(if there aren't already a few threads downloading) it will change to downloading...
                pbLoad.BackgroundImage = Properties.Resources.zzz;
                lblStatus.Visible = true;
                lblStatus.Text = "Enqueued.";
                pbLoad.Image = null;

            
                var streamInfoSet = await client.GetVideoMediaStreamInfosAsync(video.Id); //recursive?
                var streamInfo = streamInfoSet.Muxed.WithHighestVideoQuality();
                

                pbLoad.BackgroundImage = null;
                pbLoad.Image = Properties.Resources.load25x25;

                lblStatus.Text = "Downloading...";

                
                pathToVideo = GetValidFilePath(BLIO.rootFolder + "\\Video\\",video.Title, "." + BLSettings.VideoType);

                Task task = Task.Run(async () =>
                {
                    ctsDownload.Token.ThrowIfCancellationRequested();
                    await client.DownloadMediaStreamAsync(streamInfo, pathToVideo + RemoveIllegalCharacters(video.Title) + "." + BLSettings.VideoType, new Progress<double>(d => setProgressbarValue(pbDownload,(int)Math.Round(Convert.ToDouble(d.ToString()) * 100))),ctsDownload.Token);
                }, ctsDownload.Token);
                await task;                

                pbLoad.Image = null;
                pbLoad.BackgroundImage = Properties.Resources.load25x25;
                lblStatus.Text = "Preparing...";
                ConvertToMp3(video.Title);
            }
            catch (System.Threading.Tasks.TaskCanceledException ex)
            {
                //Probably a timeout! multiple other threads downloading. gotta wait for them to finish, re-try this one.               
                Download(video);
            }
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            if (isDownloading)
            {
                ctsDownload.Cancel(false);

                DownloadItemManager.toDeleteFiles.Add(pathToVideo);
                DownloadItemManager.StartTimer();
            }

            if (isConverting)
            {
                //Cancel the convert task
                ctsConvert.Cancel(false);
                FFMpegConverter.Abort();

                DownloadItemManager.toDeleteFiles.Add(pathToSong);
                DownloadItemManager.StartTimer();
            }



            this.Dispose();
            if (isHistory)
            {
                BLHistory.RemoveRecord(historyRecord);
                UCHistory.RepositionDownloadItems();
            }
            else
                DownloadItemManager.RepositionDownloadItems();
        }

       


        private void Progress_ProgressChanged(object sender, double e)
        {
            pbDownload.Value = (int)e * 100;
        }

        /// <summary>
        /// Removes illegal characters from a string. Windows files may not contain some characters.
        /// </summary>
        /// <param name="input">Input string which should be stripped of illegal characters</param>
        /// <returns>Returns the string without illegal characters</returns>
        private string RemoveIllegalCharacters(string input)
        {
            string blacklist = "<>:\"//\\|?*";
            foreach (char c in blacklist)
                input = input.Replace(c.ToString(), "");
            return input;
        }


        private void DownloadItem_Load(object sender, EventArgs e)
        {
            try
            {
                downloadTask = new Task(Download); //just so it isn't null and we can check on IsCanceled                                
                convertTask = new Task(Download); //just so it isn't null and we can check on IsCanceled                                

                YoutubeClient client = new YoutubeClient();
                pbLoad.Image = Properties.Resources.load25x25;

                //Attempt to get the single video id
                string singleVideoId = "";
                if (theVideo != null)
                    singleVideoId = theVideo.Id;
                else
                    YoutubeClient.TryParseVideoId(youtubeUrl, out singleVideoId);


                //Attempt to get the playlist id
                string playlistId = "";
                if (thePlaylist != null)
                    playlistId = thePlaylist.Id;
                else
                    YoutubeClient.TryParsePlaylistId(youtubeUrl, out playlistId);





                //Thread that handles playlists loading data
                Thread playlistThread = null;
                playlistThread = new Thread(async () =>
                {
                    if (!string.IsNullOrEmpty(playlistId))
                    {
                        if (thePlaylist == null)
                        {
                            thePlaylist = await client.GetPlaylistAsync(playlistId);                           
                        }                                          
                    }
                });
                playlistThread.IsBackground = true;
                playlistThread.Start();




                //Thread that handles loading single video data
                Thread singleVideoThread = new Thread(async () =>
                {
                    if (!string.IsNullOrEmpty(singleVideoId))
                    {
                        try
                        {
                            //Put the thumbnail into the picturebox
                            pbYoutubeThumbnail.Load("http://img.youtube.com/vi/" + singleVideoId + "/0.jpg");
                            //Get the video    
                            try
                            {
                                if (theVideo == null)
                                    theVideo = await client.GetVideoAsync(singleVideoId);
                            }
                            catch (Exception ex)
                            {
                                SetVideoUnavailableErrorText(ex);
                                return;
                            }




                            string title = theVideo.Title;
                            string author = theVideo.Author;
                            TimeSpan duration = theVideo.Duration;

                            string subTitle = "";
                            string subAuthor = "";

                            string completeString = ""; //The complete string containing title + author + duration


                            if (title.Length > 33)
                            {
                                subTitle = title.Substring(0, 33) + "...";
                                completeString += subTitle + "   ";
                            }
                            else
                            {
                                completeString += title + "   ";
                            }


                            if (author.Length > 23)
                            {
                                subAuthor = author.Substring(0, 23) + "...";
                                completeString += subAuthor + "   ";
                            }
                            else
                            {
                                completeString += author + "   ";
                            }

                            completeString += duration;

                            lblTitle.Invoke((MethodInvoker)(() =>
                            {
                                lblTitle.Text = completeString;
                                lblExit.Invoke((MethodInvoker)(() =>
                                {
                                    lblExit.Enabled = true;
                                }));
                                btnDownload.Invoke((MethodInvoker)(() =>
                                {
                                    btnDownload.Enabled = true;
                                }));
                                pbLoad.Invoke((MethodInvoker)(() =>
                                {
                                    pbLoad.Image = null;
                                    pbLoad.BackgroundImage = Properties.Resources.Check;
                                }));
                                lblStatus.Invoke((MethodInvoker)(() =>
                                {
                                    if (!isHistory)
                                        lblStatus.Text = "Ready.";
                                    isReady = true;
                                }));
                            }));
                        }
                        catch(System.Net.WebException ex)
                        {
                            SetVideoUnavailableErrorText(ex);
                        }
                    }
                });
                singleVideoThread.IsBackground = true;
                singleVideoThread.Start();
            }
            catch (Exception)
            {
                lblTitle.Text = "An error occured - Could not load this entry";
                lblStatus.Text = "Error.";
                canDownload = false;
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (lblStatus.Text == "Done.")
            {
                
                string argument = "/select, \"" + pathToSong + "\"";
                Process.Start("explorer.exe", argument);
            }
            else
            {
                if(isHistory)
                {
                    pbLoad.Visible = true;
                    lblStatus.Location = new Point(pbLoad.Location.X + pbLoad.Width + 6, lblStatus.Location.Y);
                }                                

                Download();
            }
        }

       
        private void SetVideoUnavailableErrorText(Exception ex)
        {
            string message = "";
            switch(ex.GetType().ToString())
            {
                case "YoutubeExplode.Exceptions.ParseException": message = "Error - Could not parse that video :(";
                    break;
                case "YoutubeExplode.Exceptions.VideoUnavailableException": message = "Error - Video not available in your country :(";
                    break;
                case "YoutubeExplode.Exceptions.VideoRequiresPurchaseException": message = "Error - Video requires purchase :(";
                    break;
                case "System.Net.WebException": message = "Error - That video is unavailable :(";
                    break;
                default: message = "Something went wrong :( [" + ex.GetType().ToString() + "]";
                    break;
            }
            lblTitle.Invoke((MethodInvoker)(() =>
            {
                lblTitle.Text = message;
                lblExit.Invoke((MethodInvoker)(() =>
                {
                    lblExit.Enabled = true;
                }));
                btnDownload.Invoke((MethodInvoker)(() =>
                {
                    btnDownload.Enabled = false;
                }));
                pbLoad.Invoke((MethodInvoker)(() =>
                {
                    pbLoad.Image = null;
                    pbLoad.BackgroundImage = Properties.Resources.error;
                }));
                lblStatus.Invoke((MethodInvoker)(() =>
                {
                    if (!isHistory)
                        lblStatus.Text = "Error.";
                    isReady = true;
                }));
            }));
        }

        private void tmrCheckProgress_Tick(object sender, EventArgs e)
        {
            if (convertTask.IsCompleted)
            {
                if (!isHistory)
                {
                    pbLoad.Image = null;
                    pbLoad.BackgroundImage = Properties.Resources.Check;

                    btnDownload.BackgroundImage = Properties.Resources.folderIcon;
                    btnDownload.Image = null;

                    lblStatus.Text = "Done.";
                    isConverting = false;
                    btnDownload.Enabled = true;

                    //Play the sound
                    if (BLSettings.PlaySound)
                    {
                        System.Media.SoundPlayer player;

                        if (File.Exists(BLSettings.SoundFile))                        
                            player = new System.Media.SoundPlayer(BLSettings.SoundFile);                                                    
                        else                        
                            player = new System.Media.SoundPlayer(Simple_Youtube2Mp3.Properties.Resources.DefaultNotification); // here WindowsFormsApplication1 is the namespace and Connect is the audio file name                                                  

                        player.Play();
                    }

                    if(!IsActive(Application.OpenForms["Form1"].Handle) && BLSettings.ShowNotification) //Form currently not on the foreground? show message form!
                        MessageFormManager.MakeMessagePopup("Download Complete",theVideo.Title + "." + BLSettings.AudioType + " Complete!", 2);
                }
                else
                {
                    MessageFormManager.MakeMessagePopup("Succesfully Re-Downloaded " + historyRecord.Title + "!",5);

                    lblStatus.Text = historyRecord.DownloadDate;
                    lblStatus.Location = pbLoad.Location;
                    btnDownload.Enabled = true;

                    pbLoad.Visible = false;
                    pbDownload.Value = 0;
                }
                tmrCheckProgress.Stop();
            }
        }
    }
}


