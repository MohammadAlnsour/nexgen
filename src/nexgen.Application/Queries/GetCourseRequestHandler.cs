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
    public class GetCourseRequestHandler : IRequestHandler<GetCourseRequest, CourseResponseDTO>
    {
        private readonly ICoursesRepository coursesRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public GetCourseRequestHandler(ICoursesRepository coursesRepository, IMapper mapper, ILogger logger)
        {
            this.coursesRepository = coursesRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<CourseResponseDTO> Handle(GetCourseRequest request, CancellationToken cancellationToken)
        {
            if (request == null)
                return new CourseResponseDTO();

            try
            {
                var course = await coursesRepository.Get(request.CourseId);
                if (course == null) return new CourseResponseDTO();
                var response = mapper.Map<Course, CourseResponseDTO>(course);
                //var responseDto = new CourseResponseDTO() { };

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
