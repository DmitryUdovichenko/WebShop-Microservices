using AutoMapper;
using Basket.API.Entities;
using Basket.API.GrpcServices;
using Basket.API.Repositories;
using EventBus.Messages.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketRepository _repository;
        private readonly DiscountGrpcService _discountGrpcService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public BasketController(IBasketRepository repository, DiscountGrpcService discountGrpcService, IMapper mapper, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _discountGrpcService = discountGrpcService;
            _mapper = mapper;
            _publishEndpoint = publishEndpoint;
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

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> Checkout([FromBody] CartCheckout cartCheckout)
        {
            var cart = await _repository.GetCart(cartCheckout.UserId);
            if (cart == null)
            {
                return BadRequest();
            }

            var eventMessage = _mapper.Map<BasketCheckoutEvent>(cartCheckout);
            eventMessage.TotalPrice = cart.TotalPrice;
            await _publishEndpoint.Publish(eventMessage);

            await _repository.DeleteCart(cart.UserId);

            return Accepted();
        }

    }
}
