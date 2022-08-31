using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {
 
        private readonly IConnectionMultiplexer _redis;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task DeleteCart(string userId)
        {
            var db = _redis.GetDatabase();
            await db.KeyDeleteAsync(userId);
        }

        public async Task<Cart> GetCart(string userId)
        {
            var db = _redis.GetDatabase();

            var cart = await db.HashGetAsync("hashcart", userId);
            if (String.IsNullOrEmpty(cart))
                return null;

            return JsonConvert.DeserializeObject<Cart>(cart);

        }

        public async Task<Cart> UpdateCart(Cart cart)
        {

            if (cart == null)
                throw new ArgumentOutOfRangeException(nameof(cart));
            
            var db = _redis.GetDatabase();

            var serialPlat = JsonConvert.SerializeObject(cart);

            db.HashSet($"hashcart", new HashEntry[]
                {new HashEntry(cart.UserId, serialPlat)});

            return await GetCart(cart.UserId);
        }
    }
}
