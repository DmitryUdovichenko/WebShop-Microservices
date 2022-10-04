using MediatR;

namespace Ordering.Application.Features.Orders.Commands.CheckoutOrder
{
    public class CheckoutOrderCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalPrice { get; set; }
        public int AddressId { get; set; }
        public int Payment { get; set; }
    }
}
