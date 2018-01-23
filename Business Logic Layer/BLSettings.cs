using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLSettings
    {
        private BLSettings() { }
        public static Settings GetSettings()
        {
            return DLSettings.GetSettings();
        }
       
        public static void UpdateSettings(Settings set)
        {
            DLSettings.UpdateSettings(set);
        }


        public static bool IsAutomaticDownload
        {            
            get { return DLSettings.IsAutomaticDownload(); }
            set
            {
                Settings set = GetSettings();
                set.AutomaticDownload = value.ToString().ToLower();
                UpdateSettings(set);
            }
        }


        public static bool PlaySound
        {
            get { return DLSettings.IsPlaySound(); }
            set
            {
                Settings set = GetSettings();
                set.PlaySound = value.ToString().ToLower();
                UpdateSettings(set);
            }
        }
        public static bool ShowNotification
        {
            get { return DLSettings.IsShowNotification(); }
            set
            {
                Settings set = GetSettings();
                set.ShowNotification = value.ToString().ToLower();
                UpdateSettings(set);
            }
        }
        public static bool KeepMp4
        {
            get { return DLSettings.KeepMp4(); }
            set
            {
                Settings set = GetSettings();
                set.KeepMp4 = value.ToString().ToLower();
                UpdateSettings(set);
            }
        }
        public static bool IsCopyFromClipboard
        {
            get { return DLSettings.IsCopyFromClipboard(); }
            set
            {
                Settings set = GetSettings();
                set.CopyFromClipboard = value.ToString().ToLower();
                UpdateSettings(set);
            }
        }
        public static string VideoPath
        {
            get { return DLSettings.GetVideoPath(); }
            set
            {
                Settings set = GetSettings();
                set.VideoPath = value.ToString().ToLower();
                UpdateSettings(set);
            }
        }
        public static string MP3Path
        {
            get { return DLSettings.GetMP3Path(); }
            set
            {
                Settings set = GetSettings();
                set.MP3Path = value.ToString().ToLower();
                UpdateSettings(set);
            }
        }
        public static string SoundFile
        {
            get { return DLSettings.GetSoundFile(); }
            set
            {
                Settings set = GetSettings();

                if (value == null)
                    set.SoundFile = "";
                else
                    set.SoundFile = value.ToString().ToLower();

                UpdateSettings(set);
            }
        }
    }
}
