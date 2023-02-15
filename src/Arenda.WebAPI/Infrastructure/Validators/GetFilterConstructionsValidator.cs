using Arenda.WebAPI.Messages;
using FluentValidation;

namespace Arenda.WebAPI.Infrastructure.Validators
{
    public class GetFilterConstructionsValidator : AbstractValidator<GetFilterConstructionsRequest>
    {
        public GetFilterConstructionsValidator()
        {
            RuleFor(x => x.MinCost)
                .NotNull()
                .NotEmpty()
                .Must(x => x >= 0 && x < 10000)
                .WithMessage("Required minimal cost must be greater than 0 and less than 9999");

            RuleFor(x => x.MaxCost)
                .NotNull()
                .NotEmpty()
                .Must(x => x > 0 && x <= 10000)
                .WithMessage("Required maximal cost must be greater than 1 and less than 10000");

            RuleFor(x => x.MinSquare)
                .NotNull()
                .NotEmpty()
                .Must(x => x >= 0 && x < 10000)
                .WithMessage("Required minimal square must be greater than 0 and less than 9999");

            RuleFor(x => x.MaxSquare)
                .NotNull()
                .NotEmpty()
                .Must(x => x > 0 && x <= 10000)
                .WithMessage("Required maximal square must be greater than 1 and less than 10000");

            RuleFor(x => x.MinYear)
                .NotNull()
                .NotEmpty()
                .Must(x => x >= 1000 && x < 2023)
                .WithMessage("Required minimal year value must be greater than 1000 and less than 2023");

            RuleFor(x => x.MaxYear)
                .NotNull()
                .NotEmpty()
                .Must(x => x > 1000 && x <= 2023)
                .WithMessage("Required maximal year value must be greater than 1001 and less than 2024");

            RuleFor(x => x.NumberOfRooms)
               .NotNull()
               .Must(x => x > 0 && x <= 10)
               .WithMessage("Required number of rooms between 1 and 10")
               .When(x => x.NumberOfRooms.HasValue);

            RuleFor(x => x.Floor)
               .NotNull()
               .Must(x => x >= 0 && x <= 200)
               .WithMessage("Required floor value between 0 and 200")
               .When(x => x.Floor.HasValue);
        }
    }
}
