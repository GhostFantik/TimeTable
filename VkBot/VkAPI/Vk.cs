using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using VkBot.VkAPI.Models;

namespace VkBot.VkAPI
{
    class Vk
    {
        private static Vk instanse;
        public static Vk GetInstanse()
        {
            if (instanse == null)
                instanse = new Vk();
            return instanse;
        }
        private async Task<string> Method(string name, Dictionary<string, string> param)
        {
            param.Add("v", "5.73");
            param.Add("access_token", Utils.Settings.GetInstanse().VkToken);
            string bufferParam = Utils.DictionaryToGetParams.Convert(param);
            string url = $"https://api.vk.com/method/{name}?{bufferParam}";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            Stream stream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string answer = await streamReader.ReadToEndAsync();
            streamReader.Close();
            response.Close();
            return answer;
        }
        public async Task<(string, string, string)> GetLongPollServer()
        {
            string response = await Method("groups.getLongPollServer", new Dictionary<string, string>() {
                {"group_id", "161170666" }
            } );
            var dataType = new { response = new {key = "", server = "", ts = "" } };
            var data = JsonConvert.DeserializeAnonymousType(response, dataType);
            return (data.response.key, data.response.server, data.response.ts);
        }
        public async Task<string> GetLongPollHistory(string key, string server, string ts)
        {
            Console.WriteLine($"составление запроса: {key} {server} {ts}");
            string url = $"{server}?act=a_check&key={key}&ts={ts}&wait=25";
            WebRequest request = WebRequest.Create(url);
            WebResponse response = await request.GetResponseAsync();
            StreamReader streamReader = new StreamReader(response.GetResponseStream());
            string answer = await streamReader.ReadToEndAsync();
            streamReader.Close();
            response.Close();
            Console.WriteLine($"Запрос окончен! Ответ: {answer}");
            return answer;
        }
        public async Task<string> SendMessage(string user_id, string message)
        {
            return await Method("messages.send", new Dictionary<string, string>()
            {
                   { "user_id", user_id },
                   { "message", message},
                   });
            }
    }
}
