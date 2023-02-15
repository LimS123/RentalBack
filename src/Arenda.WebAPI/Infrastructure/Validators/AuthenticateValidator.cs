using Arenda.WebAPI.Infrastructure.Validators.ValidationRules;
using Arenda.WebAPI.Messages;
using FluentValidation;

namespace Arenda.WebAPI.Infrastructure.Validators
{
    public class AuthenticateValidator : AbstractValidator<AuthenticateRequest>
    {
        public AuthenticateValidator()
        {
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .EmailAddress();

            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .MustBeValidPassword();
        }
    }
}
