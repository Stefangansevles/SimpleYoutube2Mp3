using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Business_Logic_Layer
{
    public class BLVideo
    {
        //No instances allowed
        private BLVideo() { }
             

        /// <summary>
        /// Gets the thumbnail of a youtube video and sets it into a picturebox
        /// </summary>
        /// <param name="youtubeUrl">The url of the youtube video</param>        
        public static string GetYoutubeThumbnailUrl(string youtubeUrl)
        {
            //Determines if the video is part of a playlist, or not
            bool standAloneVideo = true;

            if (youtubeUrl.Contains("&")) //The youtube video is part of a playlist. watch?v=ID&(the rest)
                standAloneVideo = false;

            int startPosition = youtubeUrl.LastIndexOf("watch?v=") + "watch?v=".Length;

            //The id of the youtube video it is always after watch?v=ID
            string youtubeId;

            if (standAloneVideo)
                youtubeId = youtubeUrl.Substring(startPosition, (youtubeUrl.Length - startPosition));
            else
                youtubeId = youtubeUrl.Substring(startPosition, (youtubeUrl.IndexOf("&") - startPosition));

            //Finally, return the url
            return "http://img.youtube.com/vi/" + youtubeId + "/0.jpg";            
        }
    }
}
