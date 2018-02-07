using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeTableServer.Models;
namespace TimeTableServer.Services
{
    public interface ITimeTableService
    {
        Task AddClassAsync(Class item);
        Task RemoveClassAsync(Class item);
        Task<IEnumerable<Class>> GetAllClassAsync();
        Task<Class> GetClassAsync(string name);

        Task AddTeacherAsync(Teacher item);
        Task RemoveTeacherAsync(Teacher item);
        Task<IEnumerable<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetTeacherAsync(string name);

        Task AddLessonAsync(Lesson item);
        Task RemoveLessonAsync(Lesson item);
        Task<IEnumerable<Lesson>> GetAllLessonAsync(DayOfWeek day);
    }
}
