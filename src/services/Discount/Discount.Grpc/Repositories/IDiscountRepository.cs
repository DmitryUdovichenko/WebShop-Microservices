using Discount.Grpc.Entities;

namespace Discount.Grpc.Repositories
{
    public interface IDiscountRepository
    {
        Task<Coupon> Get(string productId);
        Task<bool> Create(Coupon coupon);
        Task<bool> Update(Coupon coupon);
        Task<bool> Delete(int id);

    }
}
