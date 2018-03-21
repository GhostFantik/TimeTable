using System;
using System.Collections.Generic;
using System.Text;

namespace VkBot.Models
{
    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
