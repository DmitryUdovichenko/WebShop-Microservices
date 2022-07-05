using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redis;

        public BasketRepository(IDistributedCache redis)
        {
            _redis = redis;
        }

        public async Task DeleteCart(string userId)
        {
            await _redis.RemoveAsync(userId);
        }

        public async Task<Cart> GetCart(string userId)
        {
            var cart = await _redis.GetStringAsync(userId);
            if (String.IsNullOrEmpty(cart))
                return null;

            return JsonConvert.DeserializeObject<Cart>(cart);

        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            await _redis.SetStringAsync(cart.UserId, JsonConvert.SerializeObject(cart));
            return await GetCart(cart.UserId);
        }
    }
}
