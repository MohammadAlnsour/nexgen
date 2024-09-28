using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using nexgen.Application.Contracts.DTOs;
using nexgen.Application.Requests;
using nexgen.Shared;
using nexgen.Shared.AppExceptions;

namespace nexgen.Web.RazorPages.Pages
{
    public class CourseModel : PageModel
    {
        private readonly IMediator _mediator;
        private readonly Serilog.ILogger _logger;

        public CourseResponseDTO Course { get; set; }

        public CourseModel(IMediator mediator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public async Task OnGetAsync(int Id)
        {
            var courseNotFoundMsg = "Course not found!";
            if (Id <= 0)
            {
                ViewData["CourseNotFound"] = courseNotFoundMsg;
                return;
            }
            try
            {
                var getCourseReq = new GetCourseRequest(Id);
                Course = await _mediator.Send(getCourseReq);

                if (Course == null)
                {
                    ViewData["CourseNotFound"] = courseNotFoundMsg;
                    return;
                }

                ViewData["Title"] = $"Course - {Course.CourseName}";
                ViewData["CourseName"] = Course.CourseName;

            }
            catch (Exception ex)
            {
                ex.HandleException(_logger);
                ViewData["CourseNotFound"] = courseNotFoundMsg;
            }
        }
    }
}
