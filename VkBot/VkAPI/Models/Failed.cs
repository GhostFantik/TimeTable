using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VkBot.VkAPI.Models
{
    class Failed
    {
        [JsonProperty("failed", Required = Required.Always)]
        int number;
        long ts;
    }
}
