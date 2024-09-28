using AutoMapper;
using nexgen.Application.Contracts.DTOs;
using nexgen.Application.Requests;
using nexgen.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Application.Mapper
{
    public class AppMapperProfile : Profile
    {
        public AppMapperProfile()
        {

            CreateMap<CreateBookRequest, BookInfo>().ReverseMap();
            CreateMap<Book, BookReponseDTO>().ReverseMap();

            CreateMap<Lesson, LessonResponseDTO>()
                .ForMember(x => x.VideoDuration, dest => dest.MapFrom(src => src.VideoDuration))
                .ForMember(x => x.LessonName, dest => dest.MapFrom(src => src.LessonName))
                .ReverseMap();

            CreateMap<Chapter, ChapterResposeDTO>()
                .ForMember(x => x.ChapterName, dest => dest.MapFrom(src => src.ChapterName))
                .ForMember(x => x.Lessons, dest => dest.MapFrom(src => src.Lessons))
                .ReverseMap();

            CreateMap<Course, CourseResponseDTO>()
                .ForMember(x => x.EndDate, dest => dest.MapFrom(src => src.CourseEndDate))
                .ForMember(x => x.CreatedDate, dest => dest.MapFrom(src => src.CreatedDate))
                .ForMember(x => x.InstructorName, dest => dest.MapFrom(src => src.Instructor.InstructorName))
                .ForMember(x => x.CourseName, dest => dest.MapFrom(src => src.CourseName))
                .ForMember(x => x.CourseImage, dest => dest.MapFrom(src => src.CourseImage))
                .ForMember(x => x.StartDate, dest => dest.MapFrom(src => src.CourseStartDate))
                .ForMember(x => x.Chapters, dest => dest.MapFrom(src => src.Chapters))
                .ReverseMap();

        }
    }
}
