using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities.BillingAddress;

namespace Ordering.Application.Features.Orders.Commands.CreateAddress;

public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
{
    private readonly IAddressRepository _addressRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<CreateAddressCommandHandler> _logger;
    public CreateAddressCommandHandler(IAddressRepository addressRepository, IMapper mapper, ILogger<CreateAddressCommandHandler> logger)
    {
        _addressRepository = addressRepository;
        _mapper = mapper;
        _logger = logger;
    }
    public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
    {
        var addressEntity = _mapper.Map<Address>(request);
        var newAddres = await _addressRepository.AddAsync(addressEntity);
        _logger.LogInformation($"Address {newAddres.Id} is created");
        return newAddres.Id;
    }
}