using WebShop.Aggregator.Models;

namespace WebShop.Aggregator.Services
{
    public interface IBasketService
    {
        Task<BasketModel> GetBasket(string UserName);
    }
}
