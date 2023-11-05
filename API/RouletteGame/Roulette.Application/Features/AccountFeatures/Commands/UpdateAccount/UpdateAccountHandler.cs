using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.UpdateAccount;
public sealed class UpdateAccountHandler : IRequestHandler<UpdateAccountRequest, UpdateAccountResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public UpdateAccountHandler(IMapper mapper, IAccountService accountService)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<UpdateAccountResponse> Handle(UpdateAccountRequest request, CancellationToken cancellationToken)
    {
        Account account = _mapper.Map<Account>(request);
        var response = await _accountService.UpdateAccount(account);
        return _mapper.Map<UpdateAccountResponse>(response);

    }
}
