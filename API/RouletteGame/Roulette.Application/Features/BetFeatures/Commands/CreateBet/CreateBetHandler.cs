using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Application.Features.AccountFeatures.Commands.CreateAccount;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.Commands.CreateBet;
public sealed class CreateBetHandler : IRequestHandler<CreateBetRequest, CreateBetResponse>
{
    private readonly IBetService betService;
    private readonly IMapper mapper;

    public CreateBetHandler(IMapper _mapper, IBetService _betService)
    {
        betService = _betService;
        mapper = _mapper;
    }

    public async Task<CreateBetResponse> Handle(CreateBetRequest request, CancellationToken cancellationToken)
    {
        Bet bet = mapper.Map<Bet>(request);
        var response = await betService.CreateBet(bet);
        return mapper.Map<CreateBetResponse>(response);
    }
}
