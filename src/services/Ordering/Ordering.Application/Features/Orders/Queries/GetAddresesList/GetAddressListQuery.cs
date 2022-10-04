using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetAddresesList;

public class GetAddressListQuery : IRequest<List<AddressDto>>
{
    public string UserId { get; private set; }

    public GetAddressListQuery(string userId)
    {
        UserId = userId;
    }
}