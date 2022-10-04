using MediatR;

namespace Ordering.Application.Features.Orders.Commands.UpdatePaymentCredentials
{
    public class UpdatePaymentCredentialsCommand : IRequest
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string Expiration { get; set; }
        public string CVV { get; set; }
    }
}