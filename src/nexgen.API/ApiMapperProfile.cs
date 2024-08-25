using AutoMapper;
using nexgen.Application.Contracts.DTOs;
using nexgen.Application.Requests;
using nexgen.Domain.Entities;
using Newtonsoft.Json;

namespace nexgen.API
{
    public class ApiMapperProfile : Profile
    {
        public ApiMapperProfile()
        {
            CreateMap<CreateBookRequest, BookInfo>().ReverseMap();
            CreateMap<Book, BookReponseDTO>().ReverseMap();
        }
    }
}
