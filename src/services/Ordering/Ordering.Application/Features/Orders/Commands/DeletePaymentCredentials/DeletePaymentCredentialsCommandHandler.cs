using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Application.Features.Orders.Commands.DeleteAddress;
using Ordering.Domain.Entities.Payment;

namespace Ordering.Application.Features.Orders.Commands.DeletePaymentCredentials;

public class DeletePaymentCredentialsCommandHandler : IRequestHandler<DeletePaymentCredentialsCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly ILogger<DeletePaymentCredentialsCommandHandler> _logger;
    
    public DeletePaymentCredentialsCommandHandler(IPaymentRepository paymentRepository, ILogger<DeletePaymentCredentialsCommandHandler> logger)
    {
        _paymentRepository = paymentRepository;
        _logger = logger;
    }
    public async Task<Unit> Handle(DeletePaymentCredentialsCommand request, CancellationToken cancellationToken)
    {
        var paymentItem =  await _paymentRepository.GetByIdAsync(request.Id);
        if(paymentItem == null)
        {
            throw new NotFoundException(nameof(PaymentAttributes), request.Id);
        }

        await _paymentRepository.DeleteAsync(paymentItem);
        _logger.LogInformation($"Payment {paymentItem.Id} deleted");

        return Unit.Value;
    }
}