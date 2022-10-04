using FluentValidation;

namespace Ordering.Application.Features.Orders.Commands.UpdateAddress;

public class UpdateAddressCommandValidator  : AbstractValidator<UpdateAddressCommand>
{
    public UpdateAddressCommandValidator()
    {
        RuleFor(c => c.UserId)
            .NotEmpty().WithMessage("{UserId} is required")
            .NotNull();
        RuleFor(c => c.FirstName)
            .NotEmpty().WithMessage("{FirstName} is required")
            .NotNull()
            .MinimumLength(3).WithMessage("{FirstName} min length 3")
            .MaximumLength(20).WithMessage("{FirstName} max length 20");
            
        RuleFor(c => c.LastName)
            .NotEmpty().WithMessage("{LastName} is required")
            .NotNull()
            .MinimumLength(3).WithMessage("{LastName} min length 3")
            .MaximumLength(20).WithMessage("{LastName} max length 20");
        RuleFor(c => c.ZipCode)
            .NotEmpty().WithMessage("{ZipCode} is required")
            .NotNull()
            .Matches("^\\d{5}$").WithMessage("Just 5 digits");
    }
}