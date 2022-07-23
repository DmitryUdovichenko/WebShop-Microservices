using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;

        public DiscountController(IDiscountRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{productId}", Name = "GetDiscount")]
        public async Task<ActionResult<Coupon>> Get(string productId)
        {
            var coupon = await _repository.Get(productId);
            return Ok(coupon);
        }

        [HttpPost]
        public async Task<ActionResult<Coupon>> Create(Coupon coupon)
        {
            await _repository.Create(coupon);
            return CreatedAtRoute("GetDiscount", new { productId = coupon.ProductId }, coupon);
        }

        [HttpPut]
        public async Task<ActionResult<Coupon>> Update([FromBody] Coupon coupon)
        {
            return Ok(await _repository.Update(coupon));
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _repository.Delete(id));
        }
    }
}
