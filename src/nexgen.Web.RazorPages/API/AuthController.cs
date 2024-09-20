using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using nexgen.Application.Contracts.ApiResponse;
using nexgen.Application.Contracts.DTOs;
using nexgen.Application.Requests;
using nexgen.Domain.Consts;
using nexgen.Shared.AppExceptions;

namespace nexgen.Web.RazorPages.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AuthUserRequest> _validator;
        private readonly Serilog.ILogger _logger;

        public AuthController(IMediator mediator, IValidator<AuthUserRequest> validator, Serilog.ILogger logger)
        {
            _mediator = mediator;
            _validator = validator;
            _logger = logger;
        }

        [HttpPost(Name ="AuthUser")]
        [ValidateAntiForgeryToken]
        [EnableCors("AllowAll")]
        public async Task<ApiResponse<AuthUserResponseDTO>> AuthUser(AuthUserRequest authUserRequest)
        {
            try
            {
                var validationResult = _validator.Validate(authUserRequest);
                if (!validationResult.IsValid)
                {
                    var validationErrors = new List<ValidationError>();
                    validationErrors = validationResult.Errors.Select(e => new ValidationError() { Code = e.ErrorCode, Message = e.ErrorMessage }).ToList();
                    return ApiResponse<AuthUserResponseDTO>.IsFailed("validation error", "203", validationErrors);
                }

                var response = await _mediator.Send(authUserRequest);
                return ApiResponse<AuthUserResponseDTO>.IsSuccess(response, $"user authenticated {response}", ApiStatusCodes.Success.ToString());
            }
            catch (Exception ex)
            {
                ex.HandleException(_logger);
                return ApiResponse<AuthUserResponseDTO>.IsFailed($"error occued {ex.Message}", ApiStatusCodes.Error.ToString());
            }
        }

    }
}
