using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTableServer.Services;
using TimeTableServer.Models;

namespace TimeTableServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class LessonController : Controller
    {
        ITimeTableService _timeTable;
        public LessonController(ITimeTableService timeTable)
        {
            _timeTable = timeTable;
        }
        [HttpGet("{day}")]
        public async Task<IActionResult> GetAll(DayOfWeek day)
        {
            return Json(await _timeTable.GetAllLessonAsync(day));
        }
        [HttpPost]
        public async Task<IActionResult> Post(Lesson lesson, string nameClass, string nameTeacher)
        {
            if (ModelState.IsValid)
            {
                Class bufferClass = await _timeTable.GetClassAsync(nameClass);
                Teacher bufferTeacher = await _timeTable.GetTeacherAsync(nameTeacher);
                Lesson buffer = new Lesson
                {
                    Name = lesson.Name,
                    Day = lesson.Day,
                    Number = lesson.Number,
                    Class = bufferClass,
                    Teacher = bufferTeacher
                };
                await _timeTable.AddLessonAsync(buffer);
                return Json(buffer);
            }
            return BadRequest("Ошибка валидации!");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Lesson lesson)
        {
            await _timeTable.RemoveLessonAsync(lesson);
            return Json(lesson);
        }
    }
}