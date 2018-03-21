using System;
using System.Collections.Generic;
using System.Text;

namespace VkBot.Models
{
    class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
