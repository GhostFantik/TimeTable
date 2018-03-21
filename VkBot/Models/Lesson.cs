using System;
using System.Collections.Generic;
using System.Text;

namespace VkBot.Models
{
    public class Lesson : IComparable<Lesson>
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
     
        public int Number { get; set; }
        
        public DayOfWeek Day { get; set; }


        public int CompareTo(Lesson other)
        {
            if (Number > other.Number)
                return 1;
            else if (Number == other.Number)
                return 0;
            else
                return -1;
        }
    }
}
