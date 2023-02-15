using FluentValidation;

namespace Arenda.WebAPI.Infrastructure.Validators.ValidationRules
{
    public static class PasswordValidationRule
    {
        public static IRuleBuilderOptions<T, string> MustBeValidPassword<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            var builderOptions = ruleBuilder.MinimumLength(8)
                .WithMessage("Required minimum password length 8");

            builderOptions = builderOptions.Matches("[A-Z]")
                .WithMessage("Password must include at least one capital letter");

            builderOptions = builderOptions.Matches("[a-z]")
                .WithMessage("Password must include at least one lowercase letter");

            builderOptions = builderOptions.Matches("[0-9]")
                .WithMessage("Password must include at least one digit");

            return builderOptions;
        }
    }
}
