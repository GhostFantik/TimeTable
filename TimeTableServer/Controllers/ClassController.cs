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
    public class ClassController : Controller
    {
        ITimeTableService _timetable;
        public ClassController(ITimeTableService timetable)
        {
            _timetable = timetable;
        }
        [HttpPost]
        public async Task<IActionResult> Post(Class item)
        {
            if (ModelState.IsValid)
            {
                await _timetable.AddClassAsync(item);
                return Ok();
            }
            return BadRequest("Ошибка валидации!");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(await _timetable.GetAllClassAsync());
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> Get(string name)
        {
            return Json(await _timetable.GetClassAsync(name));
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(Class item)
        {
            await _timetable.RemoveClassAsync(item);
            return Ok();
        }
    }
}