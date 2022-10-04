using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.CreatePayment;

public class CreatePaymentCommandValidator : AbstractValidator<CreatePaymentCommand>
{
    public CreatePaymentCommandValidator()
    {
        RuleFor(c => c.CardNumber)
            .NotEmpty().WithMessage("{CardNumber} is required")
            .NotNull()
            .Matches("^\\d{16}$").WithMessage("Just 16 digits");
        RuleFor(c => c.CVV)
            .NotEmpty().WithMessage("{CVV} is required")
            .NotNull()
            .Matches("^\\d{3}$").WithMessage("Just 3 digits");
        RuleFor(c => c.Expiration)
            .NotEmpty().WithMessage("{Expiration} is required")
            .NotNull();
    }
    
}