using Arenda.WebAPI.Messages;
using FluentValidation;

namespace Arenda.WebAPI.Infrastructure.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserValidator()
        {
            RuleFor(x => x.UserId)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.FirstName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("First name must be greater 2 symbols")
                .MaximumLength(20)
                .WithMessage("First name must be shorter 20 symbols")
                .Matches("^[A-Z][a-z]")
                .WithMessage("First name must begin with a capital letter and include english letters");

            RuleFor(x => x.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Last name must be greater 2 symbols")
                .MaximumLength(20)
                .WithMessage("Last name must be shorter 20 symbols")
                .Matches("^[A-Z][a-z]")
                .WithMessage("Last name must begin with a capital letter and include english letters");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches(@"^\+375 \((17|29|33|44)\) [0-9]{3}-[0-9]{2}-[0-9]{2}$")
                .WithMessage("Phone number must match the template +375 (XX) XXX-XX-XX");
        }
    }
}
