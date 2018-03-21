using System;
using VkBot.Models;
using VkBot.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace VkBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //BotLogic.GetInstansee().StartAsync();
            //NLog.LogManager.GetCurrentClassLogger().Info("ГГ");
            Execute();
            Console.ReadLine();
        }
        static async Task Execute()
        {
            // download settings
            Utils.Settings.GetInstanse().Read();
            // init
            ACommand.commands = new List<ACommand>()
            {
                new ShowCommand(),
                new HelpCommand()
            };
            //
            await BotLogic.GetInstanse().StartListenMessage();
        }
    }
}
