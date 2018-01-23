using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access_Layer
{
    public class DLHistory
    {
        private DLHistory() { }

        private static List<DownloadHistory> localHistory;

        /// <summary>
        /// Saves pending changes to the database, disposes it, and refreshes the local cache list
        /// </summary>
        /// <param name="db"></param>
        private static void SaveAndCloseDataBase(Youtube2Mp3DatabaseEntities db)
        {
            db.SaveChanges();
            RefreshCacheList();
            db.Dispose();
        }
        /// <summary>
        /// Gets all records in the database
        /// </summary>
        /// <returns></returns>
        public static List<DownloadHistory> GetHistory()
        {
            //If the list  is still null, it means GetHistory() hasn't been called yet. So, we give it a value once. Then, the list will only
            //be altered when the database changes. This way we minimize the amount of database calls
            if (localHistory == null)
                RefreshCacheList();

            //If the list was null, it now returns the list of reminders from the database.
            //If it wasn't null, it will return the list as it was last known, which should be how the database is.
            return localHistory;
        }
        private static void RefreshCacheList()
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                localHistory = (from s in db.DownloadHistory select s).ToList();
                db.Dispose();
            }
        }

        /// <summary>
        /// Insert a record into the database
        /// </summary>
        /// <param name="record">The record</param>
        public static void InsertRecord(DownloadHistory historyRecord)
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                if (db.DownloadHistory.Count() > 0)
                    historyRecord.Id = db.DownloadHistory.Max(i => i.Id) + 1;
                else
                    historyRecord.Id = 0;

                db.DownloadHistory.Add(historyRecord);
                SaveAndCloseDataBase(db);
            }
        }

        /// <summary>
        /// Removes a record from the database
        /// </summary>
        /// <param name="record">the record you want to remove</param>
        public static void RemoveRecord(DownloadHistory historyRecord)
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                db.DownloadHistory.Attach(historyRecord);
                db.DownloadHistory.Remove(historyRecord);
                SaveAndCloseDataBase(db);
            }
        }

        /// <summary>
        /// Removes multiple records from the database
        /// </summary>
        /// <param name="record">the record you want to remove</param>
        public static void RemoveRecords(List<DownloadHistory> historyRecords)
        {
            using (Youtube2Mp3DatabaseEntities db = new Youtube2Mp3DatabaseEntities())
            {
                //Go through the loop and add all the remove requests to the list
                foreach (DownloadHistory record in historyRecords)
                {
                    if (GetHistoryEntryById(record.Id) != null)
                    {
                        db.DownloadHistory.Attach(record);
                        db.DownloadHistory.Remove(record);
                    }
                }

                //Save all the remove requests and remove them from the database
                SaveAndCloseDataBase(db);
            }
        }

        /// <summary>
        /// Gets the history record from the database with the given id
        /// </summary>
        /// <param name="id">the unique id</param>
        /// <returns></returns>
        public static DownloadHistory GetHistoryEntryById(long id)
        {
            DownloadHistory historyItem;

            historyItem = (from s in localHistory select s).Where(i => i.Id == id).SingleOrDefault();

            return historyItem;
        }
    }
}
