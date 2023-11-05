using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.SpinFeatures.Commands.DeleteSpin;
using Roulette.Application.Features.SpinFeatures.Queries.GetSpin;
using Roulette.Application.Features.SpinFeatures.Queries.GetSpins;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.SpinsAPI;
[Route("api/[controller]")]
[ApiController]
public class SpinsController : ControllerBase
{
    private readonly ISpinService _spinsService;
    private readonly IMediator _mediator;

    public SpinsController(ISpinService spinsService, IMediator mediator)
    {
        _spinsService = spinsService;
        _mediator = mediator;
    }

    //get all spins
    [HttpGet]
    [Route("roulette/api/v1/spins")]
    public async Task<IActionResult> GetAllSpins()
    {
        try
        {
            var spins = await _mediator.Send(new GetSpinsRequest());

            if (spins == null)
            {
                return NotFound("No spin records found");
            }
            return Ok(spins);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //get spin by id
    [HttpGet]
    [Route("roulette/api/v1/spins/{id}")]
    public async Task<IActionResult> GetSpin(int id)
    {
        try
        {
            var spin = await _mediator.Send(new GetSpinRequest(id));
            if (spin == null)
            {
                return NotFound("Spin not found");
            }
            return Ok(spin);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //delete spin given spin id
    [HttpDelete]
    [Route("roulette/api/spins/{id}")]
    public async Task<IActionResult> DeleteSpin(int id)
    {
        try
        {
            var response = await _mediator.Send(new DeleteSpinRequest(id));
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
