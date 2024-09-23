using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using nexgen.Application.Contracts.DTOs;
using nexgen.Application.Requests;
using nexgen.Domain.Entities;
using nexgen.Domain.Factories.Interfaces;
using nexgen.Infrastructure.Repositories.Interfaces;
using nexgen.Shared.AppExceptions;
using nexgen.Shared.JwtHelper;
using Serilog;
using System.Text;

namespace nexgen.Application.Queries
{
    public class AuthUserQueryRequestHandler : IRequestHandler<AuthUserRequest, AuthUserResponseDTO>
    {
        private readonly IBookFactory bookFactory;
        private readonly IMapper mapper;
        private readonly IUserRepository userRepository;
        private readonly IValidator<AuthUserRequest> authUserValidator;
        private readonly JwtTokensUtility jwtTokensUtility;
        private readonly ILogger logger;

        public AuthUserQueryRequestHandler(
            IBookFactory bookFactory,
            IMapper mapper,
            IUserRepository userRepository,
            IValidator<AuthUserRequest> authUserValidator,
            JwtTokensUtility jwtTokensUtility,
            ILogger logger)
        {
            this.bookFactory = bookFactory;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.authUserValidator = authUserValidator;
            this.jwtTokensUtility = jwtTokensUtility;
            this.logger = logger;
        }
        public async Task<AuthUserResponseDTO> Handle(AuthUserRequest request, CancellationToken cancellationToken)
        {
            var validateResult = authUserValidator.Validate(request);
            if (!validateResult.IsValid)
                return new AuthUserResponseDTO() { IsAuthorized = false, Message = FormatFluentValidationErrors(validateResult.Errors), Token = string.Empty };

            try
            {
                var user = await userRepository.GetUserByUsernameAndPassword(request.Username, request.PasswordHash);
                if (user == null) return new AuthUserResponseDTO() { IsAuthorized = true, Message = "", Token = "" };
                //var response = mapper.Map<User, AuthUserResponseDTO>(user);

                var message = "Auth succeed";
                var token = jwtTokensUtility.GenerateToken(request.Username);
                
                var responseDto = new AuthUserResponseDTO() {  IsAuthorized = true, Message = message, Token = token }; 


                return responseDto;
            }
            catch (Exception ex)
            {
                ex.HandleException(logger);
                throw;
            }
        }

        private string FormatFluentValidationErrors(List<ValidationFailure> errors)
        {
            var formattedError = new StringBuilder();
            if (errors == null) { return string.Empty; }

            foreach (var error in errors)
                formattedError.AppendLine($"ErrorCode: {error.ErrorCode} , ErrorMessage: {error.ErrorMessage}");

            return formattedError.ToString();
        }
    }
}
