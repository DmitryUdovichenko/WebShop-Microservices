using WebShop.Aggregator.Extensions;
using WebShop.Aggregator.Models;

namespace WebShop.Aggregator.Services
{
    public class BasketService : IBasketService
    {
        private readonly HttpClient _client;

        public BasketService(HttpClient client)
        {
            _client = client;
        }
        public async Task<BasketModel> GetBasket(string UserName)
        {
            var response = await _client.GetAsync($"/api/v1/Basket/{UserName}");
            return await response.ReadContentAs<BasketModel>();
        }
    }
}
