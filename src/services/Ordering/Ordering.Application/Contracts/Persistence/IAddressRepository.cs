using Ordering.Domain.Entities.BillingAddress;

namespace Ordering.Application.Contracts.Persistence;

public interface IAddressRepository : IAsyncRepository<Address>
{
    Task<IEnumerable<Address>> GetAddressesByUserId(string userId);
}