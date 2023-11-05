using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.AccountFeatures.Queries.GetAccounts;
public sealed class GetAccountsHandler : IRequestHandler<GetAccountsRequest, List<GetAccountsResponse>>
{
    private readonly IAccountService accountService;
    private readonly IMapper mapper;

    public GetAccountsHandler(IAccountService _accountService, IMapper _mapper)
    {
        accountService = _accountService;
        mapper = _mapper;
    }
    
    public async Task<List<GetAccountsResponse>> Handle(GetAccountsRequest request, CancellationToken cancellationToken)
    {
        var accounts = await accountService.GetAllAccounts();
        return mapper.Map<List<GetAccountsResponse>>(accounts);
    }
}