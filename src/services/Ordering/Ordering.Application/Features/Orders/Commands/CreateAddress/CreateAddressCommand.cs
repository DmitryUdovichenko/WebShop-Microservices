using MediatR;

namespace Ordering.Application.Features.Orders.Commands.CreateAddress
{

    public class CreateAddressCommand : IRequest<int>
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}