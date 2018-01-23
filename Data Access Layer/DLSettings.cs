using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLSettings
    {
        private DLSettings() { }
        private static Settings settings;

        public static Settings GetSettings()
        {
            if (settings == null)
                RefreshSettings();

            return settings;
        }
        private static void RefreshSettings()
        {

            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                int count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count == 0)
                {
                    settings = new Settings();
                    settings.AutomaticDownload = "false";
                    settings.MP3Path = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                    settings.VideoPath = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
                    settings.SoundFile = "";
                    settings.PlaySound = "true";
                    settings.KeepMp4 = "false";
                    settings.ShowNotification = "true";
                    settings.CopyFromClipboard = "false";
                    
                    UpdateSettings(settings);
                }
                else
                    settings = (from s in db.Settings select s).ToList().FirstOrDefault();
                db.Dispose();
            }
        }
        public static void UpdateSettings(Settings set)
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {

                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {
                    db.Settings.Attach(set);
                    var entry = db.Entry(set);
                    entry.State = System.Data.Entity.EntityState.Modified; //Mark it for update                                
                    db.SaveChanges();                                      //push to database
                    db.Dispose();
                }
                else
                {//The settings table is still empty
                    db.Settings.Add(set);
                    db.SaveChanges();
                    db.Dispose();
                }
            }
        }

 
        public static bool IsAutomaticDownload()
        {
            string automaticDownload = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    automaticDownload = (from g in db.Settings select g.AutomaticDownload).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return automaticDownload == "true";
        }


        public static bool IsPlaySound()
        {
            string playSound = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    playSound = (from g in db.Settings select g.PlaySound).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return playSound == "true";
        }
        public static bool IsCopyFromClipboard()
        {
            string playSound = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    playSound = (from g in db.Settings select g.CopyFromClipboard).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return playSound == "true";
        }
        public static bool IsShowNotification()
        {
            string notification = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    notification = (from g in db.Settings select g.ShowNotification).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return notification == "true";
        }
        public static bool KeepMp4()
        {
            string keep = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    keep = (from g in db.Settings select g.KeepMp4).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return keep == "true";
        }

        public static string GetVideoPath()
        {
            string path = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    path = (from g in db.Settings select g.VideoPath).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return path;
        }
        public static string GetMP3Path()
        {
            string path = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    path = (from g in db.Settings select g.MP3Path).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return path;
        }
        public static string GetSoundFile()
        {
            string file = "";
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                var count = db.Settings.Where(o => o.Id >= 0).Count();
                if (count > 0)
                {

                    file = (from g in db.Settings select g.SoundFile).SingleOrDefault();
                    db.Dispose();
                }
                else
                {
                    RefreshSettings();
                }
            }
            return file;
        }
    }
}
