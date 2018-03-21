using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Net;
using VkBot.Models;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace VkBot
{
    public class API
    {
        string _url;
        public API(string url)
        {
            _url = url;
        }
        public static API Factory(string url)
        {
            return new API(url);
        }
        public async Task<Class> GetClassAsync(string name)
        {
            string url = _url + "api/" + "class/" + name;
            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string answer = await streamReader.ReadToEndAsync();
            streamReader.Close();
            response.Close();
            Class bufferClass = JsonConvert.DeserializeObject<Class>(answer);
            Console.WriteLine(answer);
            return bufferClass;
        }
    }
}
