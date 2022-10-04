using Microsoft.EntityFrameworkCore;
using Ordering.Application.Contracts.Persistence;
using Ordering.Domain.Entities.Payment;
using Ordering.Infrastructure.Persistence;

namespace Ordering.Infrastructure.Repositories
{

    public class PaymentRepository : BaseRepository<PaymentAttributes>, IPaymentRepository
    {
        public PaymentRepository(OrderContext _context) : base(_context)
        {
        }
        
        public async Task<IEnumerable<PaymentAttributes>> GetPaymentsByUserId(string userId)
        {
            var paymentList = await _context.PaymentAttributes.Where(o => o.UserId == userId).ToListAsync();
            return paymentList;
        }
    }
}