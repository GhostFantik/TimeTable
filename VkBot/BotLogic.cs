using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkBot.Models;
using Newtonsoft.Json;
using VkBot.VkAPI;
using VkBot.VkAPI.Models;
using VkBot.Commands;

namespace VkBot
{
    public class BotLogic
    {
        private static BotLogic instanse;
        public static BotLogic GetInstanse()
        {
            if (instanse == null)
                instanse = new BotLogic();
            return instanse;
        }
        Vk vk = Vk.GetInstanse();
        List<ACommand> commands = ACommand.commands;
        public BotLogic()
        {
            
        }
        public async Task StartListenMessage()
        {
            var (key, server, ts) = await vk.GetLongPollServer();
            while (true)
            {
                try
                {
                    string response = await vk.GetLongPollHistory(key, server, ts);
                    // TODO: сделать с объектом
                    // обработка ошибок от Вк
                    if(response == "{\"failed\":2}" || response == "{\"failed\":3}")
                    {
                        (key, server, ts) = await vk.GetLongPollServer();
                        continue;
                    }

                    LongPollEvent responseObj = JsonConvert.DeserializeObject<LongPollEvent>(response);
                    ts = responseObj.ts;
                    if(responseObj.updates.Count > 0)
                    {
                        if (responseObj.updates.Last().Object.Out == 0)
                        {
                            Console.WriteLine($"Пришло сообщение от {responseObj.updates.Last().Object.user_id}: " +
                               $"{responseObj.updates.Last().Object.body}");
                            await MessageHandle(responseObj.updates.Last().Object.user_id, responseObj.updates.Last().Object.body);
                        }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine("ОШИБКА!!! " + e);
                }
            }
        }
        private async Task MessageHandle(string user_id, string message)
        {
            string[] strings = message.Split(" ");
            string answer = "Мои команды: /help";
            foreach(ACommand command in commands)
            {
                if (command.СanExecute(strings))
                {
                    answer = await command.Execute(strings);
                    break;
                }
            }
            await vk.SendMessage(user_id, answer);
        }
    }
}
