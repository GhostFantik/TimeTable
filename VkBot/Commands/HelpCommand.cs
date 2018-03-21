using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VkBot.Commands
{
    class HelpCommand : ACommand
    {
        public HelpCommand()
        {
            Name = "/help";
        }
        public async override Task<string> Execute(string[] commandString)
        {
            StringBuilder builder = new StringBuilder();
            int i = 1;
            builder.Append("Мои команды: \n");
            foreach(ACommand command in ACommand.commands)
            {
                builder.Append($"{i}. {command.Name} \n");
                i++;
            }
            builder.Append("По всем вопросам: e.drushchenko@yandex.ru");
            return builder.ToString();
        }

        public override bool СanExecute(string[] commandString)
        {
            if (commandString[0] == Name) {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
