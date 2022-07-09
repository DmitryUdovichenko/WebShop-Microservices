using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;

        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService)
        {
            _repository = repository;
            _discountGrpcService = discountGrpcService;
        }

        [HttpGet("{userId}", Name = "GetBasket")]
        public async Task<ActionResult<Cart>> Get(string userId)
        {
            var basket = await _repository.GetCart(userId);
            return Ok(basket ?? new Cart(userId));
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> Update([FromBody] Cart cart)
        {

            foreach(var item in cart.Items)
            {
                var coupon = await _discountGrpcService.GetDiscount(item.ProductId);
                item.Price -= coupon.Amount;
            }

            return Ok(await _repository.UpdateCart(cart));
        }

        [HttpDelete("{userId}", Name = "DeleteCart")]
        public async Task<IActionResult> Delete(string userId)
        {
            await _repository.DeleteCart(userId);
            return Ok();
        }

    }
}
