using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
using Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
using Roulette.Application.Features.AccountFeatures.Queries.GetAccount;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.AccountAPI;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountsService;
    private readonly IMediator _mediator;

    public AccountController(IAccountService accountsService, IMediator mediator)
    {
        _accountsService = accountsService;
        _mediator = mediator;
    }

    [HttpGet]
    [Route("roulette/api/v1/accounts")]
    public async Task<IActionResult> GetAllAccount()
    {
        try
        {
            var accounts = await _accountsService.GetAllAccount();

            if (accounts == null)
            {
                return NotFound("No account records found");
            }
            return Ok(accounts);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    [Route("roulette/api/v1/accounts/{id}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        try
        {
            var response = await _mediator.Send(new GetAccountRequest { Id = id});
            return Ok(response);
            var account = await _accountsService.GetAccount(id);

            if (account == null)
            {
                return NotFound("Account not found");
            }
            return Ok(account);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut]
    [Route("roulette/api/v1/accounts")]
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountRequest updateAccountRequest)
    {
        try
        {
            var response = await _mediator.Send(updateAccountRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    [Route("roulette/api/accounts")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
    {
        try
        {
            var message = await _accountsService.CreateAccount(createAccountRequest);
            return Ok(message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete]
    [Route("roulette/api/accounts/{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        try
        {
            var message = await _accountsService.DeleteAccount(id);
            return Ok(message);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
