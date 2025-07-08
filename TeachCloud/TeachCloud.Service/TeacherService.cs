﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using TeachCloud.Core.Entities;
using TeachCloud.Core.Repositories;
using TeachCloud.Core.Service;
using TeachCloud.Data;
namespace TeachCloud.Service
{
    public class TeacherService : ITeacherService
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly DataContext _context;

        public TeacherService(ITeacherRepository teacherRepository, DataContext context)
        {
            _teacherRepository = teacherRepository;
            _context = context;
        }

        public IEnumerable<Teacher> GetAllTeachers() => _teacherRepository.GetAll();

        public Teacher? GetTeacherById(int id) => _teacherRepository.GetById(id);

        public Teacher? GetTeacherByEmail(string email) => _context.Teachers.FirstOrDefault(t => t.Email == email);

        public List<Course> GetCoursesByTeacherId(int teacherId)
        {
            return _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .Include(c => c.StudyGroups)
                .ToList();
        }

        public Teacher CreateTeacher(Teacher teacher)
        {
            _teacherRepository.Add(teacher);
            _teacherRepository.Save();
            return teacher;
        }

        public bool UpdateTeacher(int id, Teacher teacher)
        {
            var existing = _teacherRepository.GetById(id);
            if (existing == null) return false;

            existing.FullName = teacher.FullName;
            existing.Email = teacher.Email;

            _teacherRepository.Save();
            return true;
        }

        public bool DeleteTeacher(int id)
        {
            var teacher = _teacherRepository.GetById(id);
            if (teacher == null) return false;

            _teacherRepository.Delete(teacher);
            _teacherRepository.Save();
            return true;
        }
        public List<Group> GetGroupsByTeacherId(int teacherId)
        {
            var courseIds = _context.Courses
                .Where(c => c.TeacherId == teacherId)
                .Select(c => c.Id)
                .ToList();

            var groups = _context.Groups
                .Where(g => courseIds.Contains(g.CourseId))
                .ToList();

            return groups;
        }

    }
}
