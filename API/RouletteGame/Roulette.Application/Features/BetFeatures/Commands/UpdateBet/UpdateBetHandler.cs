using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.UpdateBet;
public sealed class UpdateBetHandler : IRequestHandler<UpdateBetRequest, UpdateBetResponse>
{
    private readonly IBetService betService;
    private readonly IMapper mapper;

    public UpdateBetHandler(IMapper _mapper, IBetService _betService)
    {
        betService = _betService;
        mapper = _mapper;
    }

    public async Task<UpdateBetResponse> Handle(UpdateBetRequest request, CancellationToken cancellationToken)
    {
        Bet bet = mapper.Map<Bet>(request);
        return await betService.UpdateBet(bet);
    }
}
