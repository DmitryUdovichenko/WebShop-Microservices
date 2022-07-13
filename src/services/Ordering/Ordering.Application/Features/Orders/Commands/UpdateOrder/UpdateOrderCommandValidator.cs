using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidator()
        {
            RuleFor(u => u.Id)
                .NotEmpty().WithMessage("{Id} is required.")
                .NotNull();

            RuleFor(u => u.UserName)
                .NotEmpty().WithMessage("{UserName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{UserName} max length 50 characters.");

            RuleFor(u => u.EmailAddress)
               .NotEmpty().WithMessage("{EmailAddress} is required.");

            RuleFor(u => u.TotalPrice)
                .NotEmpty().WithMessage("{TotalPrice} is required.")
                .GreaterThan(0).WithMessage("{TotalPrice} should be greater than zero.");
        }
    }
}
