using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
using Roulette.Application.Features.AccountFeatures.Commands.DeleteAccount;
using Roulette.Application.Features.AccountFeatures.Commands.DepositAccount;
using Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
using Roulette.Application.Features.AccountFeatures.Queries.GetAccount;
using Roulette.Application.Features.AccountFeatures.Queries.GetAccounts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Roulette.API.AccountAPI;

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

    //get all accounts
    [HttpGet]
    [Route("roulette/api/v1/accounts")]
    public async Task<IActionResult> GetAllAccounts()
    {
        try
        {
            var accounts = await _mediator.Send(new GetAccountsRequest());

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

    //get account by id
    [HttpGet]
    [Route("roulette/api/v1/accounts/{id}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        try
        {
            var account = await _mediator.Send(new GetAccountRequest(id));
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

    //update account
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

    //deposit money in account
    [HttpPut]
    [Route("roulette/api/v1/accounts/deposit")]
    public async Task<IActionResult> DepositAccount([FromBody] DepositAccountRequest depositAccountRequest)
    {
        try
        {
            var response = await _mediator.Send(depositAccountRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //create new account
    [HttpPost]
    [Route("roulette/api/v1/accounts")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
    {
        try
        {
            var response = await _mediator.Send(createAccountRequest);
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    //delete account given account id
    [HttpDelete]
    [Route("roulette/api/accounts/{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        try
        {
            var response = await _mediator.Send(new DeleteAccountRequest(id));
            return Ok(response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
