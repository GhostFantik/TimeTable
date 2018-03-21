using System;
using System.Collections.Generic;
using System.Text;

namespace VkBot.Utils
{
    static class DictionaryToGetParams
    {
        public static string Convert(Dictionary<string, string> dictionary)
        {
            Dictionary<string, string>.KeyCollection keyCollection = dictionary.Keys;
            StringBuilder builder = new StringBuilder();
            foreach (string key in keyCollection)
            {
                builder.Append($"{key}={dictionary[key]}&");
            }
            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }
    }
}
