using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace TimeTableServer.Models.ViewModels
{
    public class LessonView
    {
        [Required]
        public Lesson lesson { get; set; }
        [Required]
        public string nameClass { get; set; }
        [Required]
        public string nameTeacher { get; set; }
    }
}
