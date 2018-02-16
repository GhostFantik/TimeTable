using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeTableServer.Models
{
    public class Lesson : IComparable<Lesson>
    {
        //TODO: кабинет реализовать
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public DayOfWeek Day { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

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
