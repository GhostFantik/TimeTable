using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTableServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TimeTableServer.Services
{
    public class TimeTableService : ITimeTableService
    {
        TimeTableContext _db;
        ILogger<TimeTableService> _logger;
        public TimeTableService(TimeTableContext db, ILogger<TimeTableService> logger)
        {
            _db = db;
            _logger = logger;
        }
        public async Task AddClassAsync(Class item)
        {
            await _db.Classes.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task AddLessonAsync(Lesson item)
        {
            await _db.Lessons.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task AddTeacherAsync(Teacher item)
        {
            await _db.Teachers.AddAsync(item);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Class>> GetAllClassAsync()
        {
            return await _db.Classes.ToListAsync();
        }

        public async Task<IEnumerable<Lesson>> GetAllLessonAsync(DayOfWeek day)
        {
            return await _db.Lessons.Where(p => p.Day == day).ToListAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync()
        {
            return await _db.Teachers.ToListAsync();
        }

        public async Task<Class> GetClassAsync(string name)
        {
            try
            {
                Console.WriteLine("GetClassAsync!  " + name);
                IQueryable<Class> buff = _db.Classes.Where(p => p.Name == name);
                Console.WriteLine("Where выполнен!");
                Class buffer = await buff.FirstOrDefaultAsync();
                Console.WriteLine("Конец выполнения GetClassAsync! " + buffer.Name);
                return buffer;
            }
            catch(Exception e)
            {
                _logger.LogError("Ошибка: " + e.Message);
                return null;
            }
        }

        public async Task<Teacher> GetTeacherAsync(string name)
        {
            return await _db.Teachers.Where(p => p.Name == name).FirstOrDefaultAsync();
        }

        public async Task RemoveClassAsync(Class item)
        {
            _db.Classes.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveLessonAsync(Lesson item)
        {
            _db.Lessons.Remove(item);
            await _db.SaveChangesAsync();
        }

        public async Task RemoveTeacherAsync(Teacher item)
        {
            _db.Teachers.Remove(item);
            await _db.SaveChangesAsync();
        }
    }
}
