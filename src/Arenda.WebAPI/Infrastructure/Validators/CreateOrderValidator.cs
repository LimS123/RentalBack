using Arenda.WebAPI.Messages;
using FluentValidation;

namespace Arenda.WebAPI.Infrastructure.Validators
{
    public class CreateOrderValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderValidator()
        {

        }
    }
}
