using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.UpdateAddress
{

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateAddressCommandHandler> _logger;
        
        public UpdateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper, ILogger<UpdateAddressCommandHandler> logger)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var addressItem = await _addressRepository.GetByIdAsync(request.Id);
            if (addressItem == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }
            _mapper.Map(request, addressItem, typeof(UpdateAddressCommand), typeof(Order));
            await _addressRepository.UpdateAsync(addressItem);
            _logger.LogInformation($"Address {addressItem.Id} created");
            return Unit.Value;
        }
    }
}