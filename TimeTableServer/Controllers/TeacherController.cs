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
    public class TeacherController : Controller
    {
        ITimeTableService _timetable;
        public TeacherController(ITimeTableService timetable)
        {
            _timetable = timetable;
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Json(await _timetable.GetTeacherAsync(name));
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _timetable.GetAllTeacherAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Post(Teacher item)
        {
            if (ModelState.IsValid)
            {
                await _timetable.AddTeacherAsync(item);
                return Ok();
            }
            return BadRequest("Ошибка валидации");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Teacher item)
        {
            await _timetable.RemoveTeacherAsync(item);
            return Ok();
        }
    }
}