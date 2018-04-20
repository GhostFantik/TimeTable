using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTableServer.Services;
using TimeTableServer.Models;
using TimeTableServer.Models.ViewModels;

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
        public async Task<IActionResult> Post([FromBody] LessonView item)
        {
            //Console.WriteLine("Запрос добавления урока: " + item.lesson.Name + " п " + item.nameClass);
            if (ModelState.IsValid)
            {
                Class bufferClass = await _timeTable.GetClassAsync(item.nameClass);
                Teacher bufferTeacher = await _timeTable.GetTeacherAsync(item.nameTeacher);
                Lesson buffer = new Lesson
                {
                    Name = item.lesson.Name,
                    Day = item.lesson.Day,
                    Number = item.lesson.Number,
                    Class = bufferClass,
                    Teacher = bufferTeacher
                };
                await _timeTable.AddLessonAsync(buffer);
                return Json(buffer);
            }
            return BadRequest("Ошибка валидации!");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _timeTable.RemoveLessonAsync(id);
            return Ok();
        }
    }
}