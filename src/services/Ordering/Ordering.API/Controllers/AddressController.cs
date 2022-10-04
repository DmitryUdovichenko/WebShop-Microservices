using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CreateAddress;
using Ordering.Application.Features.Orders.Commands.DeleteAddress;
using Ordering.Application.Features.Orders.Commands.UpdateAddress;
using Ordering.Application.Features.Orders.Queries.GetAddresesList;

namespace Ordering.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IMediator _mediator;

        public AddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<AddressDto>>> Get(string userId)
        {
            var query = new GetAddressListQuery(userId);
            var list = await _mediator.Send(query);
            return Ok(list);
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreateAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateAddressCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteAddressCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}