using AutoMapper;
using UniversityPortal.Api.Models;
using UniversityPortalApi.Dto;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentDto, Student>();
        CreateMap<CreateStudentDto, Student>();

        CreateMap<Grade, GradeDto>();
        CreateMap<GradeDto, Grade>();
        CreateMap<CreateGradeDto,Grade>();

    
        CreateMap<Subject, SubjectDto>();
        CreateMap<SubjectDto, Subject>();
        CreateMap<CreateSubjectDto, Subject>();

        CreateMap<News, NewsDto>();
        CreateMap<NewsDto, News>();
        CreateMap<CreateNewsDto, News>();

        CreateMap<Timetable, TimetableDto>().ReverseMap();
        CreateMap<CreateTimetableDto, Timetable>();
    }
}
