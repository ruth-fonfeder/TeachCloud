using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using AutoMapper;
using FileEntity = TeachCloud.Core.Entities.File;


namespace TeachCloud.Core.Mappings
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Teacher, TeacherDto>();
            CreateMap<Course, CourseDto>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FullName));
            CreateMap<CourseDto, Course>();

            CreateMap<Course, TeacherDto.CourseSimpleDto>();

            CreateMap<Group, GroupDto>()
                .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));
            CreateMap<GroupDto, Group>();
            CreateMap<Group, GroupSimpleDto>();

            CreateMap<AdminDto, Admin>();//.ReverseMap();
            CreateMap<Admin, AdminDto>();

            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>();

            CreateMap<Lesson, LessonDto>()
                .ForMember(dest => dest.StudyGroupName, opt => opt.MapFrom(src => src.StudyGroup.Name));

            CreateMap<FileEntity, LessonDto.FileDto>();
        }
    }
}
