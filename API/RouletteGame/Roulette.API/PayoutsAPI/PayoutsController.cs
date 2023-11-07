
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
using Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;
using Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.PayoutsAPI;

[ApiController]
public class PayoutsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PayoutsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //get all payouts
    [HttpGet]
    [Route("roulette/api/v1/payouts")]
    public async Task<IActionResult> GetAllPayouts()
    {
        var payouts = await _mediator.Send(new GetPayoutsRequest());

        if (payouts == null)
        {
            throw new PayoutsNotFoundException();
        }
        return Ok(payouts);
    }

    //get payout by id
    [HttpGet]
    [Route("roulette/api/v1/payouts/{id}")]
    public async Task<IActionResult> GetPayout(int id)
    {
        var payout = await _mediator.Send(new GetPayoutRequest(id));
        if (payout == null)
        {
            throw new PayoutNotFoundException(id.ToString());
        }
        return Ok(payout);
    }

    //update payout
    [HttpPut]
    [Route("roulette/api/v1/payouts")]
    public async Task<IActionResult> UpdatePayout([FromBody] UpdatePayoutRequest updatePayoutRequest)
    {
        var response = await _mediator.Send(updatePayoutRequest);
        return Ok(response);
    }

    //create new payout
    [HttpPost]
    [Route("roulette/api/v1/payouts")]
    public async Task<IActionResult> CreatePayout([FromBody] CreatePayoutRequest createPayoutRequest)
    {
        var response = await _mediator.Send(createPayoutRequest);
        return Ok(response);
    }

    //delete payout given payout id
    [HttpDelete]
    [Route("roulette/api/payouts/{id}")]
    public async Task<IActionResult> DeletePayout(int id)
    {
        var response = await _mediator.Send(new DeletePayoutRequest(id));
        return Ok(response);
    }
}
