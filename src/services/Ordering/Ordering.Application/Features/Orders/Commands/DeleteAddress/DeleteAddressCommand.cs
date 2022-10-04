using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeleteAddress
{
    public class DeleteAddressCommand : IRequest
    {
        public int Id { get; set; }
    }
}

