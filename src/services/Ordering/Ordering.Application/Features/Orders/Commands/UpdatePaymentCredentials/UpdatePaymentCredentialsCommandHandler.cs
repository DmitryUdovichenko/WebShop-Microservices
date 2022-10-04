using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Application.Features.Orders.Commands.UpdateAddress;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.UpdatePaymentCredentials;

public class UpdatePaymentCredentialsCommandHandler  : IRequestHandler<UpdatePaymentCredentialsCommand>
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<UpdatePaymentCredentialsCommandHandler> _logger;
    
    public UpdatePaymentCredentialsCommandHandler(IPaymentRepository paymentRepository, IMapper mapper, ILogger<UpdatePaymentCredentialsCommandHandler> logger)
    {
        _paymentRepository = paymentRepository;
        _mapper = mapper;
        _logger = logger;
    }
    
    public async Task<Unit> Handle(UpdatePaymentCredentialsCommand request, CancellationToken cancellationToken)
    {
        var paymentItem = await _paymentRepository.GetByIdAsync(request.Id);
        if (paymentItem == null)
        {
            throw new NotFoundException(nameof(Order), request.Id);
        }
        _mapper.Map(request, paymentItem, typeof(UpdatePaymentCredentialsCommand), typeof(Order));
        await _paymentRepository.UpdateAsync(paymentItem);
        _logger.LogInformation($"Payment creds {paymentItem.Id} created");
        return Unit.Value;
    }
}