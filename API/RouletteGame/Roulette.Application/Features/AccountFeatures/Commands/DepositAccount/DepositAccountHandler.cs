using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.AccountFeatures.Commands.DepositAccount;
public sealed class DepositAccountHandler : IRequestHandler<DepositAccountRequest, DepositAccountResponse>
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public DepositAccountHandler(IMapper mapper, IAccountService accountService)
    {
        _accountService = accountService;
        _mapper = mapper;
    }

    public async Task<DepositAccountResponse> Handle(DepositAccountRequest request, CancellationToken cancellationToken)
    {
        var response = await _accountService.Deposit(request.Id, request.Amount);
        return _mapper.Map<DepositAccountResponse>(response);
    }
}
