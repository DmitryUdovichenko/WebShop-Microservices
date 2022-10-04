using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Application.Exceptions;
using Ordering.Domain.Entities;
using Ordering.Domain.Entities.BillingAddress;

namespace Ordering.Application.Features.Orders.Commands.DeleteAddress;

public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
{
    private readonly IAddressRepository _addressRepository;
    private readonly ILogger<DeleteAddressCommandHandler> _logger;
    
    public DeleteAddressCommandHandler(IAddressRepository addressRepository, ILogger<DeleteAddressCommandHandler> logger)
    {
        _addressRepository = addressRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
    {
        var addressItem =  await _addressRepository.GetByIdAsync(request.Id);
        if(addressItem == null)
        {
            throw new NotFoundException(nameof(Address), request.Id);
        }

        await _addressRepository.DeleteAsync(addressItem);
        _logger.LogInformation($"Address {addressItem.Id} deleted");

        return Unit.Value;
    }
}