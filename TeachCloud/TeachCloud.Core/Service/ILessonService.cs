using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface ILessonService
    {
        IEnumerable<Lesson> GetAllLessons();
        Lesson? GetLessonById(int id);
        Lesson CreateLesson(Lesson lesson);
        bool UpdateLesson(int id, Lesson lesson);
        bool DeleteLesson(int id);
    }
}