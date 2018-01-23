using Data_Access_Layer;
using Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLHistory
    {
        private BLHistory() { }

        private static List<DownloadHistory> localHistory;

        
        /// <summary>
        /// Gets all records in the database
        /// </summary>
        /// <returns></returns>
        public static List<DownloadHistory> GetHistory()
        {
            return DLHistory.GetHistory();
        }
       

        /// <summary>
        /// Insert a record into the database
        /// </summary>
        /// <param name="record">The record</param>
        public static void InsertRecord(DownloadHistory historyRecord)
        {
            if(historyRecord != null && DLHistory.GetHistory().Where(v => v.VideoId == historyRecord.VideoId).ToList().Count <= 0)
                DLHistory.InsertRecord(historyRecord);
        }

        /// <summary>
        /// Removes a record from the database
        /// </summary>
        /// <param name="record">the record you want to remove</param>
        public static void RemoveRecord(DownloadHistory historyRecord)
        {
            if (historyRecord != null && DLHistory.GetHistoryEntryById(historyRecord.Id) != null)
                DLHistory.RemoveRecord(historyRecord);
        }

        /// <summary>
        /// Removes multiple records from the database
        /// </summary>
        /// <param name="record">the record you want to remove</param>
        public static void RemoveRecords(List<DownloadHistory> historyRecords)
        {
            if(historyRecords != null)
                DLHistory.RemoveRecords(historyRecords);
        }

        /// <summary>
        /// Gets the history record from the database with the given id
        /// </summary>
        /// <param name="id">the unique id</param>
        /// <returns></returns>
        public static DownloadHistory GetHistoryEntryById(long id)
        {
            return DLHistory.GetHistoryEntryById(id);
        }
    }
}
