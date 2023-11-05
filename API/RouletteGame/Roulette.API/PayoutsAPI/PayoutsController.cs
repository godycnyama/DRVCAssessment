
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.DeletePayout;
using Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
using Roulette.Application.Features.PayoutFeatures.Queries.GetPayout;
using Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.PayoutsAPI;
[Route("api/[controller]")]
[ApiController]
public class PayoutsController : ControllerBase
{
    private readonly IPayoutService _payoutsService;
    private readonly IMediator _mediator;

    public PayoutsController(IPayoutService payoutsService, IMediator mediator)
    {
        _payoutsService = payoutsService;
        _mediator = mediator;
    }

    //get all payouts
    [HttpGet]
    [Route("roulette/api/v1/payouts")]
    public async Task<IActionResult> GetAllPayouts()
    {
        try
        {
            var payouts = await _mediator.Send(new GetPayoutsRequest());

            if (payouts == null)
            {
                return NotFound("No payout records found");
            }
            return Ok(payouts);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //get payout by id
    [HttpGet]
    [Route("roulette/api/v1/payouts/{id}")]
    public async Task<IActionResult> GetPayout(int id)
    {
        try
        {
            var payout = await _mediator.Send(new GetPayoutRequest(id));
            if (payout == null)
            {
                return NotFound("Payout not found");
            }
            return Ok(payout);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //update payout
    [HttpPut]
    [Route("roulette/api/v1/payouts")]
    public async Task<IActionResult> UpdatePayout([FromBody] UpdatePayoutRequest updatePayoutRequest)
    {
        try
        {
            var response = await _mediator.Send(updatePayoutRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //create new payout
    [HttpPost]
    [Route("roulette/api/v1/payouts")]
    public async Task<IActionResult> CreatePayout([FromBody] CreatePayoutRequest createPayoutRequest)
    {
        try
        {
            var response = await _mediator.Send(createPayoutRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //delete payout given payout id
    [HttpDelete]
    [Route("roulette/api/payouts/{id}")]
    public async Task<IActionResult> DeletePayout(int id)
    {
        try
        {
            var response = await _mediator.Send(new DeletePayoutRequest(id));
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
