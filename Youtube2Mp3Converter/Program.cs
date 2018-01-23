using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Youtube2Mp3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Embed bunifu.dll so that this application can use it, but it won't be copied to the target machine
            
            string resource1 = "Simple_Youtube2Mp3.Bunifu_UI_v1.5.3.dll";
            EmbeddedAssembly.Load(resource1, "Bunifu_UI_v1.5.3.dll");
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new Form1());
        }

        static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return EmbeddedAssembly.Get(args.Name);
        }

        private static void ShowError(Exception ex, string message, string description)
        {
            MessageFormManager.MakeMessagePopup("Error.", ex.GetType().ToString() + "\r\nWhoops! Something went wrong...\r\n" + message, 8);
        }
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            if (e.Exception is DirectoryNotFoundException)
            {
                DirectoryNotFoundException theException = (DirectoryNotFoundException)e.Exception;
                BLIO.WriteError(theException, "Folder not found.");
                ShowError(e.Exception, e.Exception.GetType().ToString(), theException.Message);
            }

            if (e.Exception is UnauthorizedAccessException)
            {
                UnauthorizedAccessException theException = (UnauthorizedAccessException)e.Exception;
                BLIO.WriteError(e.Exception, "Unauthorized!");
                ShowError(e.Exception, "Unauthorized!", "not authorized for this action.\r\nThis can be resolved by running in administrator-mode.");
            }

            //Here we just filter out some type of exceptions and give different messages, at the bottom is the super Exception, which can be anything.              
            else if (e.Exception is FileNotFoundException)
            {
                FileNotFoundException theException = (FileNotFoundException)e.Exception; //needs in instance to call .FileName
                BLIO.WriteError(theException, "converteruld not find the file located at \"" + theException.FileName);
                ShowError(e.Exception, "File not found.", "Could not find the file located at \"" + theException.FileName + "\"\r\nHave you moved,renamed or deleted the file?");
            }

            else if (e.Exception is System.Data.Entity.Core.EntityException)
            {
                BLIO.WriteError(e.Exception, "System.Data.Entity.Core.EntityException");
                ShowError(e.Exception, "System.Data.Entity.Core.EntityException", "There was a problem executing SQL!");
            }

            else if (e.Exception is ArgumentNullException)
            {
                BLIO.WriteError(e.Exception, "Null argument");
                ShowError(e.Exception, "Null argument", "Null argument exception! Whoops! this is not on your end!");
            }

            else if (e.Exception is NullReferenceException)
            {
                BLIO.WriteError(e.Exception, "Null reference");
                ShowError(e.Exception, "Null reference", "Null reference exception! Whoops! this is not on your end!");
            }

            else if (e.Exception is SQLiteException)
            {
                BLIO.WriteError(e.Exception, "SQLite Database exception");
                ShowError(e.Exception, "SQLite Database exception", "encountered a database error!\r\nThis might or might not be on your end. It can be on your end if you modified the database file");
            }

            else if (e.Exception is PathTooLongException)
            {
                BLIO.WriteError(e.Exception, "The path to the file is too long.");
                ShowError(e.Exception, "File Path too long.", "The path to the file is too long!.");
            }

                     
            else if (e.Exception is Exception)
            {
                BLIO.WriteError(e.Exception, "Unknown exception in main.");                
            }
        }
    }
}
