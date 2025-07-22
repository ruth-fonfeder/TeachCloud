﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachCloud.Core.Entities;

namespace TeachCloud.Core.Service
{
    public interface ICourseService
    {
        Course? GetById(int id); // <- זה מה שחסר לך!
        IEnumerable<Course> GetAllCourses();
        List<Course> GetAllCoursesWithGroups();
        Course? GetCourseById(int id);
        Course CreateCourse(Course course);
        bool UpdateCourse(int id, Course course);
        bool DeleteCourse(int id);
        IEnumerable<object> GetGroupsByCourse(int courseId);

    }
}
