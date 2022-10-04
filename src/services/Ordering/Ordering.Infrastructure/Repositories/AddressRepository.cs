using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities.BillingAddress;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories
{
    public class AddressRepository : BaseRepository<Address>, IAddressRepository
    {
        public AddressRepository(OrderContext _context) : base(_context)
        {
        }


        public async Task<IEnumerable<Address>> GetAddressesByUserId(string userId)
        {
            var addressList = await _context.Addresses.Where(o => o.UserId == userId).ToListAsync();
            return addressList;
        }
    }
}

