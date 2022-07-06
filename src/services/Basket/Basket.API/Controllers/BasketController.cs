using Basket.API.Entities;
using Basket.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;

        public BasketController(IBasketRepository repository)
        {
            _repository = repository;
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
