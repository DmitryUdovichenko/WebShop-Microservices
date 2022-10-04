using MediatR;

namespace Ordering.Application.Features.Orders.Commands.CreatePayment;

public class CreatePaymentCommand : IRequest<int>
{
    public string UserId { get; set; }
    public string CardName { get; set; }
    public string CardNumber { get; set; }
    public string Expiration { get; set; }
    public string CVV { get; set; }
}