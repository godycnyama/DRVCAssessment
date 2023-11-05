using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccount;
public sealed class GetAccountHandler : IRequestHandler<GetAccountRequest, GetAccountResponse>
{
    private readonly IAccountService accountService;
    private readonly IMapper mapper;

    public GetAccountHandler(IMapper _mapper, IAccountService _accountService)
    {
        accountService = _accountService;
        mapper = _mapper;
    }

    public async Task<GetAccountResponse> Handle(GetAccountRequest request, CancellationToken cancellationToken)
    {
        Account account =  await accountService.GetAccount(request.Id, cancellationToken);
        return mapper.Map<GetAccountResponse>(account);
    }
}
