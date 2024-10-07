using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nexgen.Application.Contracts.DTOs;
using nexgen.Application.Requests;
using nexgen.Shared.AppExceptions;

namespace nexgen.Web.RazorPages.Pages
{
    public class IndexModel : PageModel
    {
       

        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;

        public List<CourseResponseDTO> AllCourses { get; set; }

        public IndexModel(IMediator mediator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            var courseNotFoundMsg = "Course not found!";

            try
            {
                var getAllCourseReq = new GetAllCoursesRequest();
                AllCourses = await _mediator.Send(getAllCourseReq);

                if (AllCourses == null)
                {
                    ViewData["CoursesNotFound"] = courseNotFoundMsg;
                    return;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(_logger);
                ViewData["CoursesNotFound"] = courseNotFoundMsg;
            }
        }

    }
}
