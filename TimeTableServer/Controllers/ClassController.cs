using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeTableServer.Services;
using TimeTableServer.Models;
using Microsoft.Extensions.Logging;

namespace TimeTableServer.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class ClassController : Controller
    {
        ITimeTableService _timetable;
        ILogger<ClassController> _logger;
        public ClassController(ITimeTableService timetable, ILogger<ClassController> logger)
        {
            _timetable = timetable;
            _logger = logger;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Class item)
        {
            try
            {
                //_logger.LogError("Post запрос: " + item.Name + " Кол-во " + item.Amount);
                if (ModelState.IsValid)
                {
                    await _timetable.AddClassAsync(item);
                    return Ok();
                }
                return BadRequest("Ошибка валидации!");
            }
            catch(Exception e)
            {
                Console.WriteLine("Ошибка: " + e);
                return NotFound("Ошибка выполнения!");
            }
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