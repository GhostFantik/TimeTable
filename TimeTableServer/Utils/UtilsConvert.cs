using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeTableServer.Utils
{
    public class UtilsConvert
    {
        public Dictionary<string, DayOfWeek> DayConvertParent = new Dictionary<string, DayOfWeek>
        {
            {"понедельник", DayOfWeek.Monday },
            {"вторник", DayOfWeek.Tuesday },
            {"среду", DayOfWeek.Wednesday },
            {"четверг", DayOfWeek.Thursday },
            {"пятницу", DayOfWeek.Friday },
            {"субботу", DayOfWeek.Saturday },
            {"воскресенье", DayOfWeek.Sunday }
        };

    }
}
