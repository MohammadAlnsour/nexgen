using FluentValidation;
using nexgen.Application.Requests;
using nexgen.Domain.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nexgen.Application.Validators
{
    public class AuthUserRequestValidator : AbstractValidator<AuthUserRequest>
    {
        public AuthUserRequestValidator()
        {
            RuleFor(x => x.Username).NotNull()
                .WithErrorCode(ApiErrorCodes.UsernameRequired.Key)
                .WithMessage(ApiErrorCodes.UsernameRequired.Value);

            RuleFor(x => x.PasswordHash).NotNull()
                .WithErrorCode(ApiErrorCodes.PasswordRequired.Key)
                .WithMessage(ApiErrorCodes.PasswordRequired.Value);

            RuleFor(x => x.PasswordHash).MinimumLength(8)
                .WithErrorCode(ApiErrorCodes.PasswordMinLength.Key)
                .WithMessage(ApiErrorCodes.PasswordMinLength.Value);

            RuleFor(x => x.Username).MinimumLength(8)
                .WithErrorCode(ApiErrorCodes.UsernameMinLength.Key)
                .WithMessage(ApiErrorCodes.UsernameMinLength.Value);


            RuleFor(x => x.PasswordHash).MaximumLength(50)
                .WithErrorCode(ApiErrorCodes.PasswordMaxLength.Key)
                .WithMessage(ApiErrorCodes.PasswordMaxLength.Value);


            RuleFor(x => x.Username).MaximumLength(50)
                .WithErrorCode(ApiErrorCodes.UsernameMaxLength.Key)
                .WithMessage(ApiErrorCodes.UsernameMaxLength.Value);
        }
    }
}
