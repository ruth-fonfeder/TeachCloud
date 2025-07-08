using AutoMapper;
using TeachCloud.Core.DTOs;
using TeachCloud.Core.Entities;
using FileEntity = TeachCloud.Core.Entities.File;

public class DtoMappingProfile : Profile
{
    public DtoMappingProfile()
    {
        // מיפויים קיימים
        CreateMap<Teacher, TeacherDto>();
        CreateMap<Course, CourseDto>()
            .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => src.Teacher.FullName));
        CreateMap<CourseDto, Course>();
        CreateMap<Course, TeacherDto.CourseSimpleDto>();

        //CreateMap<Group, GroupDto>()
        //    .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));
        //CreateMap<GroupDto, Group>();

        CreateMap<GroupDto, Group>()
    .ForMember(dest => dest.Course, opt => opt.Ignore());

        CreateMap<Group, GroupDto>()
            .ForMember(dest => dest.CourseName, opt => opt.MapFrom(src => src.Course.Name));

        // המיפוי החשוב שכנראה חסר לך
        CreateMap<GroupSimpleDto, Group>();
        CreateMap<Group, GroupSimpleDto>();

        CreateMap<AdminDto, Admin>();
        CreateMap<Admin, AdminDto>();

        CreateMap<StudentDto, Student>()
            .ForMember(dest => dest.StudyGroups,
                       opt => opt.Ignore()); // אנחנו נטפל בזה ידנית בשירות

        CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.StudyGroupIds,
                       opt => opt.MapFrom(src => src.StudyGroups.Select(g => g.Id)));


        CreateMap<Lesson, LessonDto>()
            .ForMember(dest => dest.StudyGroupName, opt => opt.MapFrom(src => src.StudyGroup.Name));

        CreateMap<FileEntity, LessonDto.FileDto>();


    }
}
