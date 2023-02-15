using Arenda.WebAPI.Messages;
using FluentValidation;

namespace Arenda.WebAPI.Infrastructure.Validators
{
    public class RefreshTokenValidator : AbstractValidator<RefreshRequest>
    {
        public RefreshTokenValidator()
        {
            RuleFor(e => e.RefreshToken)
                .NotNull()
                .NotEmpty();
        }
    }
}
