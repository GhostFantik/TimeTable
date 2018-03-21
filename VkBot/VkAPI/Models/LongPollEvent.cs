using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
namespace VkBot.VkAPI.Models
{
    class LongPollEvent
    {
        public string ts;
        public List<Update> updates;
    }
    class Update
    {
        public string type;
        public ObjectMessage Object;
        public string group_id;
    }
    class ObjectMessage
    {
        public string id;
        public string date;
        [JsonProperty("out")]
        public int Out;
        public string user_id;
        public int read_state;
        public string title;
        public string body;

    }
}
