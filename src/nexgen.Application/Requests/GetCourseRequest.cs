using MediatR;
using nexgen.Application.Contracts.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Application.Requests
{
    public class GetCourseRequest : IRequest<CourseResponseDTO>
    {
        public int CourseId { get; set; }

        public GetCourseRequest(int courseId)
        {
            CourseId = courseId;
        }
    }
}
