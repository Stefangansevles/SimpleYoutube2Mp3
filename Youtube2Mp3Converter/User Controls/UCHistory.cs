using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Database.Entity;
using Business_Logic_Layer;
using System.Threading;

namespace Simple_Youtube2Mp3
{
    public partial class UCHistory : UserControl
    {
        private static List<DownloadItem> items;
        public UCHistory()
        {
            InitializeComponent();
            items = new List<DownloadItem>();
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
        private void UCHistory_Load(object sender, EventArgs e)
        {

            pnlVideos.AutoScrollPosition = new Point(pnlVideos.AutoScrollPosition.X, 0);
            new Thread(() =>
            {
                if (BLHistory.GetHistory().Count == 0)
                {
                    lblNoHistory.Invoke((MethodInvoker)(() =>
                    {
                        lblNoHistory.Visible = true;
                    }));
                   
                   
                }

                foreach (DownloadHistory history in BLHistory.GetHistory().OrderBy(d => Convert.ToDateTime(d.DownloadDate)))
                {
                    int y = 0;
                    if (items.Count > 0)
                        y = items.Count * items.Where(itm => !itm.IsDisposed).ToList()[0].Height;

                    DownloadItem toAddItem = new DownloadItem(history);
                    toAddItem.Location = new Point(toAddItem.Location.X, y);
                    items.Add(toAddItem);
                    

                    pnlVideos.Invoke((MethodInvoker)(() =>
                    {
                        toAddItem.Visible = true;
                        pnlVideos.Controls.Add(toAddItem);
                    }));
                }
               
            }).Start();                    
    }

        private void pnlVideos_ControlRemoved(object sender, ControlEventArgs e)
        {
            RepositionDownloadItems();
            lblNoHistory.Visible = pnlVideos.Controls.Count == 0;
        }
        public void AddHistory(DownloadItem vid)
        {            
            pnlVideos.Invoke((MethodInvoker)(() =>
            {
                if (BLHistory.GetHistory().Where(i => i.VideoId == vid.theVideo.Id).ToList().Count == 0) //No entry in the history yet. Add it to the panel.
                {
                    items.Add(vid);
                    pnlVideos.Controls.Add(vid);
                }
                
            }));          
        }
       

        private void pnlVideos_ControlAdded(object sender, ControlEventArgs e)
        {
            RepositionDownloadItems();

            lblNoHistory.Visible = pnlVideos.Controls.Count == 0;
        }
        public static void RepositionDownloadItems()
        {
            DownloadItemManager.RepositionDownloadItems(items);
        }
    }
}
