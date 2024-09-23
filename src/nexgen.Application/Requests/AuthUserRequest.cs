using MediatR;
using nexgen.Application.Contracts.DTOs;

namespace nexgen.Application.Requests
{
    public class AuthUserRequest : IRequest<AuthUserResponseDTO>
    {
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? AuthToken { get; set; }
    }
}
