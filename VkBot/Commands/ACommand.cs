using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VkBot.Commands
{
    public abstract class ACommand
    {
        public string Name;
        public abstract Task<string> Execute(string[] commandString);
        public abstract bool СanExecute(string[] commandString);
        public static List<ACommand> commands;
    }
}
