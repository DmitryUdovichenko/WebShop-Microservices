using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CreatePayment;
using Ordering.Application.Features.Orders.Commands.DeletePaymentCredentials;
using Ordering.Application.Features.Orders.Commands.UpdatePaymentCredentials;
using Ordering.Application.Features.Orders.Queries.GetPaymentsList;

namespace Ordering.API.Controllers
{

    [Route("api/v1/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {
        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<PaymentDto>>> Get(string userId)
        {
            var query = new GetPaymentListQuery(userId);
            var list = await _mediator.Send(query);
            return Ok(list);
        }
        
        [HttpPost]
        public async Task<ActionResult<int>> Create([FromBody] CreatePaymentCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdatePaymentCredentialsCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeletePaymentCredentialsCommand() { Id = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}