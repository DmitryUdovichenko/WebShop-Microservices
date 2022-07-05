using Basket.API.Entities;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<Cart> GetCart(string userId);
        Task<Cart> UpdateCart(Cart cart);
        Task DeleteCart(string userId);
    }
}
