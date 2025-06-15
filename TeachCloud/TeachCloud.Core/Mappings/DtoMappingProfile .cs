using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using AutoMapper;


namespace TeachCloud.Core.Mappings
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FullName));
            // אם השתמשת ב-TeacherDto.CourseSimpleDto כתת מחלקה, יש לעדכן כאן לפי הצורך
            CreateMap<Course, TeacherDto.CourseSimpleDto>();

            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));
            CreateMap<Group, CourseDto.GroupSimpleDto>();

            CreateMap<Student, StudentDto>();

            CreateMap<Lesson, LessonDto>()
                .ForMember(dest => dest.StudyGroupName, opt => opt.MapFrom(src => src.StudyGroup.Name));

            CreateMap<File, LessonDto.FileDto>();
        }
    }
}
