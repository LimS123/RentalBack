using Arenda.WebAPI.Messages;
using FluentValidation;

namespace Arenda.WebAPI.Infrastructure.Validators
{
    public class UpdateConstructionValidator : AbstractValidator<UpdateConstructionRequest>
    {
        public UpdateConstructionValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Price)
                .NotNull()
                .NotEmpty()
                .Must(x => x > 0 && x <= 10000)
                .WithMessage("Required price value between 1 and 10000");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Required name property must be greater 5 symbols")
                .MaximumLength(100)
                .WithMessage("Required name property must be shorter 100 symbols")
                .Matches("^([A-Z][a-z .,!?-]+|[А-Я][а-я .,!?-]+)")
                .WithMessage("Required name property must begin with a capital letter and include english of russian letters");

            RuleFor(x => x.Region)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Required region property must be greater 2 symbols")
                .MaximumLength(30)
                .WithMessage("Required region property must be shorter 30 symbols")
                .Matches("^([A-Z][a-z .]+|[А-Я][а-я .]+)")
                .WithMessage("Required region property must begin with a capital letter and include english of russian letters");

            RuleFor(x => x.City)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .WithMessage("Required city property must be greater 2 symbols")
               .MaximumLength(30)
               .WithMessage("Required city property must be shorter 30 symbols")
               .Matches("^([A-Z][a-z .-]+|[А-Я][а-я .-]+)")
               .WithMessage("Required city property must begin with a capital letter and include english of russian letters");

            RuleFor(x => x.Street)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .WithMessage("Required street property must be greater 2 symbols")
               .MaximumLength(30)
               .WithMessage("Required street property must be shorter 30 symbols")
               .Matches("^([A-Z][a-z .-]+|[А-Я][а-я .-]+)")
               .WithMessage("Required street property must begin with a capital letter and include english of russian letters");

            RuleFor(x => x.HouseNumber)
               .NotNull()
               .NotEmpty()
               .MinimumLength(2)
               .WithMessage("Required house number property must be greater 2 symbols")
               .MaximumLength(8)
               .WithMessage("Required house number property must be shorter 8 symbols")
               .Matches(@"^[0-9 .\\\/-]+")
               .WithMessage("Required street property must begin with a capital letter and include english of russian letters");

            RuleFor(x => x.Type)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.Square)
               .NotNull()
               .NotEmpty()
               .Must(x => x > 0.0 && x <= 10000.0)
               .WithMessage("Required square value between 1 and 10000");

            RuleFor(x => x.Year)
               .NotNull()
               .NotEmpty()
               .Must(x => x >= 1000 && x <= 2023)
               .WithMessage("Required year value between 1000 and 2023");

            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2)
                .WithMessage("Required description property must be greater 2 symbols")
                .MaximumLength(500)
                .WithMessage("Required description property must be shorter 500 symbols")
                .Matches("^[А-ЯA-Zа-яa-z0-9 .,!?+-]")
                .WithMessage("Required description property must begin with a capital letter and include english of russian letters");

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

            RuleFor(x => x.NewImages)
               .Must(x => x.Count() > 0 && x.Count() < 10)
               .WithMessage("Required number of images must be greater 0 and shorter less than 10")
               .When(x => x.NewImages != null);
        }
    }
}
