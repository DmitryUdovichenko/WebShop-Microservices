using Ordering.Domain.Common;

namespace Ordering.Domain.Entities.BillingAddress;

public partial class Address : BaseEntity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string AddressLine { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
}