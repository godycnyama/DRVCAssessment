using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
public sealed class CreateAccountHandler : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
{
    private readonly IAccountService _betService;
    private readonly IMapper _mapper;

    public CreateAccountHandler(IMapper mapper, IAccountService betService)
    {
        _betService = betService;
        _mapper = mapper;
    }

    public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
    {
        Account bet = _mapper.Map<Account>(request);
        return await _betService.CreateAccount(bet);
    }
}
