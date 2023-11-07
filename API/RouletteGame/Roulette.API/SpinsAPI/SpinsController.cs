using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.SpinFeatures.Commands.CreateSpin;
using Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
using Roulette.Application.Features.SpinFeatures.Commands.UpdateSpin;
using Roulette.Application.Features.SpinFeatures.Queries.GetSpin;
using Roulette.Application.Features.SpinFeatures.Queries.GetSpins;

namespace Roulette.API.SpinsAPI;

[ApiController]
public class SpinsController : ControllerBase
{
    private readonly IMediator _mediator;
    public SpinsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //get all spins
    [HttpGet]
    [Route("roulette/api/v1/spins")]
    public async Task<IActionResult> GetAllSpins()
    {
        var spins = await _mediator.Send(new GetSpinsRequest());

        if (spins == null)
        {
            throw new SpinsNotFoundException();
        }
        return Ok(spins);
    }

    //get spin by id
    [HttpGet]
    [Route("roulette/api/v1/spins/{id}")]
    public async Task<IActionResult> GetSpin(int id)
    {
        var spin = await _mediator.Send(new GetSpinRequest(id));
        if (spin == null)
        {
            throw new SpinsNotFoundException(id.ToString());
        }
        return Ok(spin);
    }

    //update spin
    [HttpPut]
    [Route("roulette/api/v1/spins")]
    public async Task<IActionResult> UpdateSpin([FromBody] UpdateSpinRequest updateSpinRequest)
    {
        var response = await _mediator.Send(updateSpinRequest);
        return Ok(response);
    }

    //create new spin
    [HttpPost]
    [Route("roulette/api/v1/spins")]
    public async Task<IActionResult> CreateSpin([FromBody] CreateSpinRequest createSpinRequest)
    {
        var response = await _mediator.Send(createSpinRequest);
        return Ok(response);
    }

    //delete spin given spin id
    [HttpDelete]
    [Route("roulette/api/spins/{id}")]
    public async Task<IActionResult> DeleteSpin(int id)
    {
        var response = await _mediator.Send(new DeleteSpinRequest(id));
        return Ok(response);
    }
}
