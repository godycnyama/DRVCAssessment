using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;

namespace Roulette.Application.Features.BetFeatures.Queries.GetBets;
public sealed class GetBetsHandler : IRequestHandler<GetBetsRequest, List<GetBetsResponse>>
{
    private readonly IBetService betService;
    private readonly IMapper mapper;

    public GetBetsHandler(IBetService _betService, IMapper _mapper)
    {
        betService = _betService;
        mapper = _mapper;
    }
    
    public async Task<List<GetBetsResponse>> Handle(GetBetsRequest request, CancellationToken cancellationToken)
    {
        var bets = await betService.GetAllBets();
        return mapper.Map<List<GetBetsResponse>>(bets);
    }
}