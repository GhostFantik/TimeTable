using System;
using System.Collections.Generic;
using System.Text;

namespace VkBot.Utils
{
    public class UtilsConvert
    {
        private static UtilsConvert Instansee;
        public static UtilsConvert GetInstansee()
        {
            if (Instansee == null)
                return new UtilsConvert();
            else
            {
                return Instansee;
            }
        }
        public UtilsConvert()
        {
            Instansee = this;
        }
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
