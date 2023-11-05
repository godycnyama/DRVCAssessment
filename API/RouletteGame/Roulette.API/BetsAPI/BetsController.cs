using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.BetFeatures.Commands.CreateBet;
using Roulette.Application.Features.BetFeatures.Commands.DeleteBet;
using Roulette.Application.Features.BetFeatures.Commands.UpdateBet;
using Roulette.Application.Features.BetFeatures.Queries.GetBet;
using Roulette.Application.Features.BetFeatures.Queries.GetBets;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.BetsAPI;
[Route("api/[controller]")]
[ApiController]
public class BetsController : ControllerBase
{
    private readonly IBetService _betsService;
    private readonly IMediator _mediator;

    public BetsController(IBetService betsService, IMediator mediator)
    {
        _betsService = betsService;
        _mediator = mediator;
    }

    //get all bets
    [HttpGet]
    [Route("roulette/api/v1/bets")]
    public async Task<IActionResult> GetAllBets()
    {
        var bets = await _mediator.Send(new GetBetsRequest());

        if (bets == null)
        {
            throw new BetsNotFoundException();
        }
        return Ok(bets);
    }

    //get bet by id
    [HttpGet]
    [Route("roulette/api/v1/bets/{id}")]
    public async Task<IActionResult> GetBet(int id)
    {
        var bet = await _mediator.Send(new GetBetRequest(id));
        if (bet == null)
        {
            throw new BetNotFoundException(id.ToString());
        }
        return Ok(bet);
    }

    //update bet
    [HttpPut]
    [Route("roulette/api/v1/bets")]
    public async Task<IActionResult> UpdateBet([FromBody] UpdateBetRequest updateBetRequest)
    {
        var response = await _mediator.Send(updateBetRequest);
        return Ok(response);
    }

    //create new bet
    [HttpPost]
    [Route("roulette/api/v1/bets")]
    public async Task<IActionResult> CreateBet([FromBody] CreateBetRequest createBetRequest)
    {
        var response = await _mediator.Send(createBetRequest);
        return Ok(response);
    }

    //delete bet given bet id
    [HttpDelete]
    [Route("roulette/api/bets/{id}")]
    public async Task<IActionResult> DeleteBet(int id)
    {
        var response = await _mediator.Send(new DeleteBetRequest(id));
        return Ok(response);
    }
}
