using AutoMapper;
using nexgen.Application.Contracts.DTOs;
using nexgen.Application.Requests;
using nexgen.Domain.Entities;
using nexgen.Shared.AppExceptions;
using MediatR;
using Newtonsoft.Json;
using Serilog;
using StackExchange.Redis;
using nexgen.Domain.Factories.Interfaces;
using nexgen.Infrastructure.Repositories.Interfaces;
using nexgen.Infrastructure.Repositories;
using nexgen.Shared.JwtHelper;

namespace nexgen.Application.Queries
{
    public class GetAllCoursesRequestHandler : IRequestHandler<GetAllCoursesRequest, List<CourseResponseDTO>>
    {
        private readonly ICoursesRepository coursesRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public GetAllCoursesRequestHandler(ICoursesRepository coursesRepository, IMapper mapper, ILogger logger)
        {
            this.coursesRepository = coursesRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<List<CourseResponseDTO>> Handle(GetAllCoursesRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new List<CourseResponseDTO>();

            try
            {
                var courses = await coursesRepository.GetAll();
                if (courses == null) return new List<CourseResponseDTO>();
                var response = mapper.Map<List<Course>, List<CourseResponseDTO>>(courses.ToList());

                
                return response;
            }
            catch (Exception ex)
            {
                ex.HandleException(logger);
                throw;
            }
        }
    }
}
