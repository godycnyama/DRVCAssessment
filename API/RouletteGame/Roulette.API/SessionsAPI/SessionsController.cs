using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.SessionFeatures.Commands.CreateSession;
using Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;
using Roulette.Application.Features.SessionFeatures.Commands.UpdateSession;
using Roulette.Application.Features.SessionFeatures.Queries.GetSession;
using Roulette.Application.Features.SessionFeatures.Queries.GetSessions;

namespace Roulette.API.SessionsAPI;

[ApiController]
public class SessionsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SessionsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //get all sessions
    [HttpGet]
    [Route("roulette/api/v1/sessions")]
    public async Task<IActionResult> GetAllSessions()
    {
        var sessions = await _mediator.Send(new GetSessionsRequest());

        if (sessions == null)
        {
            throw new SessionsNotFoundException();
        }
        return Ok(sessions);
    }

    //get session by id
    [HttpGet]
    [Route("roulette/api/v1/sessions/{id}")]
    public async Task<IActionResult> GetSession(int id)
    {
        var session = await _mediator.Send(new GetSessionRequest(id));
        if (session == null)
        {
            throw new SessionNotFoundException(id.ToString());
        }
        return Ok(session);
    }

    //update session
    [HttpPut]
    [Route("roulette/api/v1/sessions")]
    public async Task<IActionResult> UpdateSession([FromBody] UpdateSessionRequest updateSessionRequest)
    {
        var response = await _mediator.Send(updateSessionRequest);
        return Ok(response);
    }

    //create new session
    [HttpPost]
    [Route("roulette/api/v1/sessions")]
    public async Task<IActionResult> CreateSession([FromBody] CreateSessionRequest createSessionRequest)
    {
        var response = await _mediator.Send(createSessionRequest);
        return Ok(response);
    }

    //delete session given session id
    [HttpDelete]
    [Route("roulette/api/sessions/{id}")]
    public async Task<IActionResult> DeleteSession(int id)
    {
        var response = await _mediator.Send(new DeleteSessionRequest(id));
        return Ok(response);
    }
}
