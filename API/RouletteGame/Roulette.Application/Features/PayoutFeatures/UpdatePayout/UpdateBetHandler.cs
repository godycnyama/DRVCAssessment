using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.UpdateBet;
public sealed class UpdateBetHandler : IRequestHandler<UpdateBetRequest, UpdateBetResponse>
{
    private readonly IBetService _betService;
    private readonly IMapper _mapper;

    public UpdateBetHandler(IMapper mapper, IBetService betService)
    {
        _betService = betService;
        _mapper = mapper;
    }

    public async Task<UpdateBetResponse> Handle(UpdateBetRequest request, CancellationToken cancellationToken)
    {
        Bet bet = _mapper.Map<Bet>(request);
        return await _betService.UpdateBet(bet);
    }
}
