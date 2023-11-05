using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
public sealed class CreateAccountHandler : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public CreateAccountHandler(IMapper mapper, IAccountService accountService)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        Account account = _mapper.Map<Account>(request);
        var response = await _accountService.CreateAccount(account);
        return _mapper.Map<CreateAccountResponse>(response);
    }
}
