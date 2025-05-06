using System.Collections.Generic;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;

namespace TeachCloud.Service
{
    public class LessonService /*: ILessonService*/
    {
        private readonly ILessonRepository _lessonRepository;

        public LessonService(ILessonRepository lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public IEnumerable<Lesson> GetAllLessons() => _lessonRepository.GetAll();

        public Lesson? GetLessonById(int id) => _lessonRepository.GetById(id);

        public Lesson CreateLesson(Lesson lesson)
        {
            _lessonRepository.Add(lesson);
            _lessonRepository.Save();
            return lesson;
        }

        public bool UpdateLesson(int id, Lesson lesson)
        {
            var existing = _lessonRepository.GetById(id);
            if (existing == null) return false;

            existing.Title = lesson.Title;

            _lessonRepository.Save();
            return true;
        }

        public bool DeleteLesson(int id)
        {
            var lesson = _lessonRepository.GetById(id);
            if (lesson == null) return false;

            _lessonRepository.Delete(lesson);
            _lessonRepository.Save();
            return true;
        }
    }
}