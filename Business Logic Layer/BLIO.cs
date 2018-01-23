using Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLIO
    {
     
        public static readonly string rootFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Simple Youtube2Mp3";
        private static readonly string DB_FILE = rootFolder + "\\Simple Youtube2Mp3.db";
        public static readonly string errorLog = rootFolder + "\\ErrorLog.txt";
        private BLIO() { }

        /// <summary>
        ///  Writes an error to the errorlog.txt
        /// </summary>
        /// <param name="ex">The occured exception</param>
        /// <param name="message">A short message i.e "Error while loading reminders"</param>
        /// <param name="showErrorPopup">true to pop up an additional windows form to show the user that an error has occured</param>
        public static void WriteError(Exception ex, string message)
        {
            using (FileStream fs = new FileStream(errorLog, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("[" + DateTime.Now + "] - " + message + "\r\n" + ex.ToString() + "\r\n\r\n");
            }
        }

        public static void CreateDatabaseIfNotExist()
        {
            if (!System.IO.File.Exists(DB_FILE))
                DLDatabase.CreateDatabase();
            else
            {
                //great! the .db file exists. Now lets check if the user's .db file is up-to-date. let's see if the reminder table has all the required columns.
                if (DLDatabase.HasAllTables())
                {
                    if (!DLDatabase.HasAllColumns())
                        DLDatabase.InsertNewColumns(); //not up to date. insert !
                }
                else
                {
                    DLDatabase.InsertMissingTables();
                    //re-run the method, since the .db file **should** now have all the tables.
                    CreateDatabaseIfNotExist();
                }

            }
        }
    }
}
