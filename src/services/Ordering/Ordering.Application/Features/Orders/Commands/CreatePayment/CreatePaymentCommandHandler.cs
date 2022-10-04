using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Features.Orders.Commands.CreateAddress;
using Ordering.Domain.Entities.Payment;

namespace Ordering.Application.Features.Orders.Commands.CreatePayment
{

    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, int>
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateAddressCommandHandler> _logger;
        
        public CreatePaymentCommandHandler(IPaymentRepository paymentRepository, IMapper mapper, ILogger<CreateAddressCommandHandler> logger)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<int> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var paymentEntity = _mapper.Map<PaymentAttributes>(request);
            var newPayment = await _paymentRepository.AddAsync(paymentEntity);
            _logger.LogInformation($"Payment creds {newPayment.Id} is created");
            return newPayment.Id;
        }
    }
}