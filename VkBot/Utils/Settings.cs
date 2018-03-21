using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace VkBot.Utils
{
    class Settings
    {
        private static Settings current;
        public static Settings GetInstanse()
        {
            if (current == null)
                current = new Settings();
            return current;
        }
        public string VkToken;
        [JsonProperty("Asp.net server")]
        public string Server;
        public void Read()
        {
            StreamReader streamReader = new StreamReader("settings.json");
            string buffer = streamReader.ReadToEnd();
            current = JsonConvert.DeserializeObject<Settings>(buffer);
        }
    }
}
