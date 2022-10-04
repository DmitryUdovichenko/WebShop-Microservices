using Ordering.Domain.Common;
using Ordering.Domain.Entities.BillingAddress;
using Ordering.Domain.Entities.Payment;

namespace Ordering.Domain.Entities
{
    public partial class Order : BaseEntity
    {
        // public string UserId { get; set; }
        // public string UserName { get; set; }
        // public decimal TotalPrice { get; set; }
        //
        // // BillingAddress
        // public string FirstName { get; set; }
        // public string LastName { get; set; }
        // public string EmailAddress { get; set; }
        // public string AddressLine { get; set; }
        // public string Country { get; set; }
        // public string State { get; set; }
        // public string ZipCode { get; set; }
        //
        // // Payment
        // public string CardName { get; set; }
        // public string CardNumber { get; set; }
        // public string Expiration { get; set; }
        // public string CVV { get; set; }
        // public int PaymentMethod { get; set; }
        
        public string UserId { get; private set; }
        public string UserName { get; private set; }
        public decimal TotalPrice { get; private set; }
        public int  AddressId { get; private set; }
        public int PaymentId { get; private set; }
        public virtual Address Address { get; private set; }
        
        public virtual PaymentAttributes Payment { get; private set; }
    }
}
