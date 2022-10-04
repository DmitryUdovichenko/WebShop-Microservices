using AutoMapper;
using MediatR;
using Ordering.Application.Contracts.Persistence;

namespace Ordering.Application.Features.Orders.Queries.GetAddresesList
{

    public class GetAddressListQueryHandler : IRequestHandler<GetAddressListQuery, List<AddressDto>>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IMapper _mapper;

        public GetAddressListQueryHandler(IAddressRepository addressRepository, IMapper mapper)
        {
            _addressRepository = addressRepository;
            _mapper = mapper;
        }


        public async Task<List<AddressDto>> Handle(GetAddressListQuery request, CancellationToken cancellationToken)
        {
            var addressList = await _addressRepository.GetAddressesByUserId(request.UserId);
            return _mapper.Map<List<AddressDto>>(addressList);
        }
    }
}