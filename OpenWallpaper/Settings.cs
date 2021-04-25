using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWallpaper
{
    public struct Settings
    {
        public bool GPUAccelerationEnabled { get; set; }

        public string DefaultWallpaper { get; set; }

        public static string SETTINGS_PATH = Path.Combine(Global.SAVES_PATH, "settings.json");

        public void Save()
        {
            if (!Directory.Exists(Global.SAVES_PATH))
                Directory.CreateDirectory(Global.SAVES_PATH);

            string json = JsonConvert.SerializeObject(this);

            File.WriteAllText(SETTINGS_PATH, json);
        }

        public static Settings Load()
        {
            if (!File.Exists(SETTINGS_PATH)) return new Settings();

            return JsonConvert.DeserializeObject<Settings>(File.ReadAllText(SETTINGS_PATH));
        }
    }
}
