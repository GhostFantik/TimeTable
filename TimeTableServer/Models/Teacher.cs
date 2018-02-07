using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeTableServer.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public int Phone { get; set; }
        [Required]
        public string Specialization { get; set; }

        public List<Lesson> Lessons { get; set; }
    }
}
