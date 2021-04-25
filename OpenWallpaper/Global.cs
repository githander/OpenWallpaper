using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoLibrary;

namespace OpenWallpaper
{
    /// <summary>
    /// Basically this class stores all static trash ;)
    /// </summary>
    public static class Global
    {
        /// <summary>
        /// App version
        /// </summary>
        public const string VERSION = "v1.0 (Beta)";

        /// <summary>
        /// Path to templates directory
        /// </summary>
        public static string SAVES_PATH = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "OpenWallpaper");

        public static string GetVideoSource(WallpaperTemplate src)
        {
            try
            {
                switch (src.SourceType)
                {
                    //From local file or URL
                    case WallpaperTemplate.WallpaperSourceType.LocalFile:
                    case WallpaperTemplate.WallpaperSourceType.URL:
                        return src.Source;

                    //From youtube video
                    case WallpaperTemplate.WallpaperSourceType.YouTube:

                        /*
                         * This is weird one, i have no idea why but sometimes links doesn't work, 
                         * And somehow its related to audio.. So i had to check if audio bitrate is
                         * higher than 0 cuz only those videos are working fine... 
                         * Probably should switch to another library ;)
                        */

                        YouTube youtube = YouTube.Default;
                        var bestQuality = youtube.GetAllVideos(src.Source).Where(e => e.Resolution > 480 && e.AudioBitrate > 0);

                        YouTubeVideo best = null;
                        int bestRes = 0;

                        //Finding best quality one
                        foreach (var video in bestQuality)
                        {
                            if (video.Resolution > bestRes)
                            {
                                best = video;
                                bestRes = video.Resolution;
                            }
                        }

                        string url = best.GetUriAsync().Result;
                        return url;
                }
            }
            catch
            {
                return null;
            }

            return null;
        }

        public static Settings Settings;
    }
}
