using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Text;
using TimeTableServer.Utils;
using TimeTableServer.Models;
namespace TimeTableServer.Services.VK
{
    /// <summary>
    /// Class-Command for command "покажи"
    /// Example: покажи мне расписание 9А на среду
    /// </summary>
    public class ShowCommandcs : ACommand
    {
        ITimeTableService _timeTable;
        UtilsConvert _utilsConvert;
        public ShowCommandcs(ITimeTableService timeTable, UtilsConvert utilsConvert)
        {
            Name = "покажи";
            _timeTable = timeTable;
            _utilsConvert = utilsConvert;
        }
        public async override Task<string> Execute(string[] commandString)
        {
            if(commandString.Length == 6)
            {
                string nameClass = commandString[3];
                Console.WriteLine(commandString[3]);
                DayOfWeek dayClass = _utilsConvert.DayConvertParent[commandString[5]];
                Class bufferClass = await _timeTable.GetClassAsync(nameClass);
                Console.WriteLine("Имя класса: " + bufferClass.Name);
                List<Lesson> lessons = bufferClass.Lessons;
                lessons.Sort();
                StringBuilder stringBuilder = new StringBuilder();
                Console.WriteLine("ппп");
                foreach (Lesson lesson in lessons)
                {
                    stringBuilder.Append($"{lesson.Number}. {lesson.Name}\n");
                }
                Console.WriteLine("пп" + stringBuilder.ToString());
                return stringBuilder.ToString();
            }
            return "Не понимаю Вас! Список моих команд: /help";
        }

        public override bool СanExecute(string[] commandString)
        {
            if (commandString.Length == 6)
            {
                if (Regex.IsMatch(commandString[3], "(\\d[а-б])"))
                {
                    if (commandString[5].Length <= 11)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
