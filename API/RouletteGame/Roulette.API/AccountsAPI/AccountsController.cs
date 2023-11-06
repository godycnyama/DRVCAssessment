using MediatR;
using Microsoft.AspNetCore.Mvc;
using Roulette.Application.Exceptions;
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
    private readonly IMediator _mediator;

    public AccountController(IMediator mediator)
    {
        _mediator = mediator;
    }

    //get all accounts
    [HttpGet]
    [Route("roulette/api/v1/accounts")]
    public async Task<IActionResult> GetAllAccounts()
    {
        var accounts = await _mediator.Send(new GetAccountsRequest());

        if (accounts == null)
        {
            throw new AccountsNotFoundException();
        }
        return Ok(accounts);
    }

    //get account by id
    [HttpGet]
    [Route("roulette/api/v1/accounts/{id}")]
    public async Task<IActionResult> GetAccount(int id)
    {
        var account = await _mediator.Send(new GetAccountRequest(id));
        if (account == null)
        {
            throw new AccountNotFoundException(id.ToString());
        }
        return Ok(account);
    }

    //update account
    [HttpPut]
    [Route("roulette/api/v1/accounts")]
    public async Task<IActionResult> UpdateAccount([FromBody] UpdateAccountRequest updateAccountRequest)
    {
        var response = await _mediator.Send(updateAccountRequest);
        return Ok(response);
    }

    //deposit money in account
    [HttpPut]
    [Route("roulette/api/v1/accounts/deposit")]
    public async Task<IActionResult> DepositAccount([FromBody] DepositAccountRequest depositAccountRequest)
    {
        var response = await _mediator.Send(depositAccountRequest);
        return Ok(response);
    }

    //create new account
    [HttpPost]
    [Route("roulette/api/v1/accounts")]
    public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
    {
        var response = await _mediator.Send(createAccountRequest);
        return Ok(response);
    }

    //delete account given account id
    [HttpDelete]
    [Route("roulette/api/accounts/{id}")]
    public async Task<IActionResult> DeleteAccount(int id)
    {
        var response = await _mediator.Send(new DeleteAccountRequest(id));
        return Ok(response);
    }
}
