using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;
using Ordering.Domain.Entities.BillingAddress;
using Ordering.Domain.Entities.Payment;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        private static string newUserGuid = new Guid().ToString();
        public static async Task SeedAsync(OrderContext context, ILogger<OrderContextSeed> logger)
        {
            if (!context.Orders.Any())
            {
                context.Orders.AddRange(GetPreconfiguredOrders());
                await context.SaveChangesAsync();
                logger.LogInformation("Seed db with context {ContextName}",typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order(newUserGuid,"UserName", 10, 1,1 ),
            };
        }
        
        private static IEnumerable<Address> GetPreconfiguredAddress()
        {
            return new List<Address>
            {
                new Address(newUserGuid,"FirstName", "LastName", "test@mail.com", "AddressLine", "Country", "State", "55555"),
            };
        }
        private static IEnumerable<PaymentAttributes> GetPreconfiguredPayments()
        {
            return new List<PaymentAttributes>
            {
                new PaymentAttributes(newUserGuid, "Card Name", "4444444444444444", "09/25", "000"),
            };
        }
    }
}
