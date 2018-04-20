using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using VkBot.Models;


namespace VkBot.Commands
{
    /// <summary>
    /// Class-Command for command "покажи"
    /// Example: покажи мне расписание 9А на среду
    /// </summary>
    public class ShowCommand : ACommand
    {
        public ShowCommand()
        {
            Name = "покажи мне расписание {класс} на {день недели}";
        }
        public async override Task<string> Execute(string[] commandString)
        {
            try
            {
                string nameClass = commandString[3];
                DayOfWeek day = Utils.UtilsConvert.GetInstansee().DayConvertParent[commandString[5]];
                Class bufferClass = await API.Factory(Utils.Settings.GetInstanse().Server).GetClassAsync(nameClass);
                List<Lesson> bufferLesson = bufferClass.Lessons.Where(t => t.Day == day).ToList();
                bufferLesson.Sort();
                StringBuilder stringBuilder = new StringBuilder();
                foreach (Lesson l in bufferLesson)
                {
                    Console.WriteLine(l.Name);
                    stringBuilder.Append($"{l.Number}. {l.Name}\n");
                }
                return stringBuilder.ToString();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            return "Не понимаю Вас! Список моих команд: /help";
        }

        public override bool СanExecute(string[] commandString)
        {
            if (commandString.Length == 6)
            {
                if (commandString[1] == "мне"
                   && commandString[2] == "расписание"
                   && commandString[4] == "на")
                {
                    if (Regex.IsMatch(commandString[3], "(\\d[а-я])"))
                    {
                        if (commandString[5].Length <= 11)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
