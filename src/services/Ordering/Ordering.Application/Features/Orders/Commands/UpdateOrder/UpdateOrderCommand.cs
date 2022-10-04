using MediatR;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int AddressId { get; set; }
        public int Payment { get; set; }
    }
}
