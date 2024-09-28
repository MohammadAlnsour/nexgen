using MediatR;
using nexgen.Application.Contracts.DTOs;

namespace nexgen.Application.Requests
{
    public class GetAllCoursesRequest : IRequest<List<CourseResponseDTO>>
    {
        public GetAllCoursesRequest()
        {
        }
    }
}
