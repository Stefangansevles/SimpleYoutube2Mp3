using Business_Logic_Layer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Youtube2Mp3
{
    /// <summary>
    /// Manages the RemindMeMessageForm. Keeps track of active message forms and has methods
    /// </summary>
    public class MessageFormManager
    {
        //Keep track of all popupforms. There should only be one at a time, but if two are visible, the second one should be on top of the other one
        private static List<MessageForm> popupForms = new List<MessageForm>();
        private MessageFormManager() { }


  

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="popDelay">The amount of seconds to wait before the popup goes down again</param>
        public static void MakeMessagePopup(string message, int popDelay)
        {           
            MessageForm popupForm = new MessageForm(message, popDelay);
            popupForm.Show();
            popupForms.Add(popupForm); //Add the popupform      
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="popDelay">The amount of seconds to wait before the popup goes down again</param>
        public static void MakeMessagePopup(string title, string message, int popDelay)
        {            
            MessageForm popupForm = new MessageForm(title,message, popDelay);
            popupForm.Show();

            popupForms.Add(popupForm); //Add the popupform   
        }

        /// <summary>
        /// Get all currently visible popupforms. Usually there will be none.
        /// </summary>
        /// <returns></returns>
        public static List<MessageForm> GetPopupforms()
        {
            return popupForms.Where(frm => !frm.IsDisposed).ToList();
        }

        /// <summary>
        /// Reposition every (active) RemindMeMessageForms so that if the first(on the bottom) form disposes, the other forms should go down.
        /// </summary>
        public static void RepositionActivePopups()
        {
            int activeFormCount = GetPopupforms().Count;

            //No active popup forms? set it to default position
            if (activeFormCount == 1)
            {
                //Set the location to the bottom right corner of the user's screen and a little bit above the taskbar since there's only one left
                MessageForm form = GetPopupforms()[0];
                form.Location = new Point(Screen.GetWorkingArea(form).Width - form.Width - 5, Screen.GetWorkingArea(form).Height - form.Height - 5);
            }
            else
            {
                foreach (MessageForm form in GetPopupforms())
                {
                    //Do NOT move the form down if it is the bottom one
                    if (form.Location.Y != Screen.GetWorkingArea(form).Height - form.Height - 5)
                    {
                        //Check if there is one below you
                        if (!IsFormAt(new Point(form.Location.X, (form.Location.Y + form.Height) + 5)))
                        {
                            //Put all messageforms one down.
                            form.Location = new Point(form.Location.X, (form.Location.Y + form.Height) + 5);
                        }

                    }
                }
            }


            //Lets just clear the disposed forms
            List<MessageForm> toRemoveForms = new List<MessageForm>();
            foreach (MessageForm form in popupForms)
            {
                if (form.IsDisposed)
                    toRemoveForms.Add(form);
            }
            foreach (MessageForm form in toRemoveForms)
                popupForms.Remove(form);
        }

        /// <summary>
        /// Check if there is a message form at the given position
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private static bool IsFormAt(Point p)
        {
            foreach (MessageForm form in GetPopupforms())
            {
                if (form.Location == p)
                    return true;
            }
            return false;
        }
    }
}
