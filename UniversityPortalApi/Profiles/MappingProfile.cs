using AutoMapper;
using UniversityPortal.Api.Models;
using UniversityPortalApi.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();

        CreateMap<Grade, GradeDto>();
        CreateMap<GradeDto, Grade>();

    
        CreateMap<Subject, SubjectDto>();
        CreateMap<SubjectDto, Subject>();

        CreateMap<News, NewsDto>();
        CreateMap<NewsDto, News>();

        CreateMap<Timetable, TimetableDto>().ReverseMap();
    }
}
