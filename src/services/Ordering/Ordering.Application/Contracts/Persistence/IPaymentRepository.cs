using Ordering.Domain.Entities.Payment;

namespace Ordering.Application.Contracts.Persistence;

public interface IPaymentRepository : IAsyncRepository<PaymentAttributes>
{
    Task<IEnumerable<PaymentAttributes>> GetPaymentsByUserId(string userId);
}