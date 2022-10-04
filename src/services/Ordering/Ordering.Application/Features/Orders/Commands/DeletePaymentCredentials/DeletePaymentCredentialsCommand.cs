using MediatR;

namespace Ordering.Application.Features.Orders.Commands.DeletePaymentCredentials
{

    public class DeletePaymentCredentialsCommand : IRequest
    {
        public int Id { get; set; }
    }
}