using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallpaper
{
    /// <summary>
    /// Wallpaper template
    /// </summary>
    public class WallpaperTemplate
    {
        public enum WallpaperSourceType
        {
            LocalFile, //Playing local file directly
            URL, //Streams video from url 
            YouTube //Streams video from youtube
        }

        public WallpaperSourceType SourceType { get; set; }
        public string Name { get; set; } = "New Template";
        public string Source { get; set; }
        public float Speed { get; set; } = 1.0f;

        private string previousDir = "-1";

        /// <summary>
        /// Loads wallpaper template from project name
        /// </summary>
        public static WallpaperTemplate FromJson(string json)
        {
            WallpaperTemplate wp = new WallpaperTemplate();
            wp = JsonConvert.DeserializeObject<WallpaperTemplate>(json);
            return wp;
        }

        /// <summary>
        /// Saves template to folder
        /// </summary>
        public void SaveTemplate()
        {
            string json = JsonConvert.SerializeObject(this);
            string path = Path.Combine(Global.SAVES_PATH, Name.Replace(" ", ""));

            if (Directory.Exists(Path.Combine(Global.SAVES_PATH, previousDir)))
            {
                Directory.Delete(Path.Combine(Global.SAVES_PATH, previousDir),true);
            }

            //Making sure all directories does exists
            if (!Directory.Exists(Global.SAVES_PATH))
                Directory.CreateDirectory(Global.SAVES_PATH);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            //And then writing to the template.json
            File.WriteAllText(Path.Combine(path,"template.json"), json);
            previousDir = path;
        }

        /// <summary>
        /// Deletes template's folder
        /// </summary>
        public void DeleteTemplate()
        {
            string path = Path.Combine(Global.SAVES_PATH, Name.Replace(" ", ""));
           
            if(Directory.Exists(path))
               Directory.Delete(path, true);
        }
    }
}
