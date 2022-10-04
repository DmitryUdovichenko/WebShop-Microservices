using MediatR;

namespace Ordering.Application.Features.Orders.Queries.GetPaymentsList
{
    public class GetPaymentListQuery : IRequest<List<PaymentDto>>
    {
        public string UserId { get; private set; }

        public GetPaymentListQuery(string userId)
        {
            UserId = userId;
        }
    }
}