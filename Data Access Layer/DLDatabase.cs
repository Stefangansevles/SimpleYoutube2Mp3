using Database.Entity;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLDatabase
    {
        private DLDatabase() { }

        private static readonly string DB_FILE = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Simple Youtube2Mp3\\Simple Youtube2Mp3.db";
        private const string TABLE_DOWNLOAD_HISTORY = "CREATE TABLE [DownloadHistory] ([Id] INTEGER NOT NULL, [Title]text NOT NULL, [ChannelTitle]text NOT NULL, [Duration]text NOT NULL, [ThumbnailLink]text NOT NULL, [DownloadDate]text NOT NULL, [VideoId]text NULL, CONSTRAINT[sqlite_master_PK_DownloadHistory] PRIMARY KEY([Id]));";
        private const string TABLE_SETTINGS = "CREATE TABLE [Settings] ([Id] INTEGER NOT NULL, [MP3Path]text NOT NULL, [VideoPath]text NOT NULL, [AutomaticDownload]text NOT NULL, [PlaySound]text NOT NULL, [SoundFile]text NULL, [CopyFromClipboard] text NOT NULL, [ShowNotification]text DEFAULT true NOT NULL, [KeepMp4] text NULL, [VideoFormat] text DEFAULT mp4 NOT NULL, [AudioFormat]text DEFAULT mp3 NOT NULL, CONSTRAINT[sqlite_master_PK_Settings] PRIMARY KEY([Id]));";

        /// <summary>
        /// Creates the database with associated tables
        /// </summary>
        public static void CreateDatabase()
        {
            SQLiteConnection conn = new SQLiteConnection();
            conn.ConnectionString = "data source = " + DB_FILE;
            conn.Open();

            SQLiteCommand tableDownloadHistory = new SQLiteCommand();
            SQLiteCommand tableSettings = new SQLiteCommand();


            tableDownloadHistory.CommandText = TABLE_DOWNLOAD_HISTORY;
            tableSettings.CommandText = TABLE_SETTINGS;


            tableDownloadHistory.Connection = conn;
            tableSettings.Connection = conn;

            tableDownloadHistory.ExecuteNonQuery();
            tableSettings.ExecuteNonQuery();

            conn.Close();
            conn.Dispose();

        }

        /// <summary>
        /// Checks if the database has the given table
        /// </summary>
        /// <param name="table"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        private static bool HasTable(string table, Youtube2Mp3DatabaseEntities db)
        {
            try
            {
                var result = db.Database.ExecuteSqlCommand("select * from " + table);
                return true;
            }
            catch (SQLiteException)
            {
                return false;
            }
        }

        /// <summary>
        /// Checks wether the table x has column x
        /// </summary>
        /// <param name="columnName">The column you want to check on</param>
        /// <param name="table">The table you want to check on</param>
        /// <returns></returns>
        public static bool HasColumn(string columnName, string table)
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                try
                {
                    var t = db.Database.SqlQuery<object>("SELECT " + columnName + " FROM " + table).ToList();
                    db.Dispose();
                    return true;
                }
                catch (SQLiteException ex)
                {
                    db.Dispose();
                    //if (ex.Message.ToLower().Contains("no such column"))
                    //{
                    return false;
                    //}                                        
                }
            }
        }

        /// <summary>
        /// Checks if the user's .db file has all the columns from the database model.
        /// </summary>
        /// <returns></returns>
        public static bool HasAllColumns()
        {
            var downloadHistoryNames = typeof(DownloadHistory).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in downloadHistoryNames)
            {
                if (!HasColumn(columnName, "DownloadHistory"))
                    return false; //aww damn! the user has an outdated .db file!                
            }

            var settingNames = typeof(Settings).GetProperties().Select(property => property.Name).ToList();

            foreach (string columnName in settingNames)
            {
                if (!HasColumn(columnName, "Settings"))
                    return false; //aww damn! the user has an outdated .db file!                
            }           

            return true;
        }

        /// <summary>
        /// Checks if the user's .db file has all the tables from the database model.
        /// </summary>
        /// <returns></returns>
        public static bool HasAllTables()
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                if (HasTable("settings", db) && HasTable("downloadhistory", db))
                    return true;
                else
                    return false;
            }

        }

        /// <summary>
        /// Inserts all missing tables into the user's .db file 
        /// </summary>
        public static void InsertMissingTables()
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {                
                SQLiteConnection conn = new SQLiteConnection();
                conn.ConnectionString = "data source = " + DB_FILE;
                conn.Open();

                SQLiteCommand tableDownloadHistory = new SQLiteCommand();
                SQLiteCommand tableSettings = new SQLiteCommand();


                tableDownloadHistory.CommandText = TABLE_DOWNLOAD_HISTORY;
                tableSettings.CommandText = TABLE_SETTINGS;


                tableDownloadHistory.Connection = conn;
                tableSettings.Connection = conn;
                

                if (!HasTable("DownloadHistory", db))
                    tableDownloadHistory.ExecuteNonQuery();

                if (!HasTable("Settings", db))
                    tableSettings.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                db.Dispose();
            }
        }

        /// <summary>
        /// This method will insert every missing column for each table into the database. Will only be called if HasallColumns() returns false. This means the user has an outdated .db file
        /// </summary>
        public static void InsertNewColumns()
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                //every column that SHOULD exist
                var downloadHistoryNames = typeof(DownloadHistory).GetProperties().Select(property => property.Name).ToArray();
                var settingNames = typeof(Settings).GetProperties().Select(property => property.Name).ToArray();                

                foreach (string column in downloadHistoryNames)
                {
                    if (!HasColumn(column, "DownloadHistory"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE DownloadHistory ADD COLUMN " + column + " " + GetDownloadHistoryColumnSqlType(column));
                }

                foreach (string column in settingNames)
                {
                    if (!HasColumn(column, "settings"))
                        db.Database.ExecuteSqlCommand("ALTER TABLE SETTINGS ADD COLUMN " + column + " " + GetSettingColumnSqlType(column));
                }

                db.SaveChanges();
                db.Dispose();
            }
        }

        /// <summary>
        /// Gets the SQLite data types of the settings columns, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetSettingColumnSqlType(string columnName)
        {
            //Yes, this is not really the "correct" way of dealing with a problem, but after a lot of searching it's quite a struggle
            //to get the data types of the sqlite columns, especially when they're nullable.
            switch (columnName)
            {                
                case "MP3Path": return "text NOT NULL";
                case "VideoPath": return "text NOT NULL";
                case "AutomaticDownload": return "text NOT NULL";
                case "PlaySound": return "text NOT NULL";
                case "SoundFile": return "text NULL";
                case "CopyFromClipboard": return "text NOT NULL";
                case "ShowNotification": return "text DEFAULT true NOT NULL";
                case "KeepMp4": return "text NULL";
                case "VideoFormat": return "text DEFAULT mp4 NOT NULL";
                case "AudioFormat": return "text DEFAULT mp3 NOT NULL";
                default: return "text NULL";
            }
        }
        /// <summary>
        /// Gets the SQLite data types of the settings columns, "text not null", "bigint null", etc
        /// </summary>
        /// <param name="columnName">The column you want to know the data type of</param>
        /// <returns>Data type of the column</returns>
        private static string GetDownloadHistoryColumnSqlType(string columnName)
        {
            //Yes, this is not really the "correct" way of dealing with a problem, but after a lot of searching it's quite a struggle
            //to get the data types of the sqlite columns, especially when they're nullable.
            switch (columnName)
            {                
                case "Title": return "text NOT NULL";
                case "ChannelTitle": return "numeric(53,0)  NOT NULL";
                case "Duration": return "text NOT NULL";
                case "ThumbnailLink": return "text NOT NULL";
                case "DownloadDate": return "text NOT NULL";
                case "VideoId": return "text NOT NULL";                    
                default: return "text NULL";
            }
        }
    }
}
