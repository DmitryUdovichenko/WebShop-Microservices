using Ordering.Domain.Common;

namespace Ordering.Domain.Entities.BillingAddress;

public partial class Address : BaseEntity
{
    public string UserId { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string EmailAddress { get; private set; }
    public string AddressLine { get; private set; }
    public string Country { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }
    public Address(string userId, string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        UserId = userId;

        this.Update(firstName, lastName, emailAddress, addressLine, country, state, zipCode);
    }

    public void Update(string firstName, string lastName, string emailAddress, string addressLine, string country, string state, string zipCode)
    {
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        AddressLine = addressLine;
        Country = country;
        State = state;
        ZipCode = zipCode;
    }
}