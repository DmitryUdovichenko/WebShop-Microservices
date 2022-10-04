using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Entities;
using Ordering.Domain.Entities.BillingAddress;
using Ordering.Domain.Entities.Payment;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<PaymentAttributes> PaymentAttributes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        
        public OrderContext()
        {
        }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }       

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                        entry.Entity.LastMidofiedDate = DateTime.Now;
                        entry.Entity.LastMidofiedBy = "test";
                        break;
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.Now;
                        entry.Entity.CreatedBy = "test";
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
