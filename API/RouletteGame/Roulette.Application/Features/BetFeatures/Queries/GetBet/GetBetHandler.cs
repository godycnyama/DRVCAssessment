using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.GetBet;
public sealed class GetBetHandler : IRequestHandler<GetBetRequest, GetBetResponse>
{
    private readonly IBetService betService;
    private readonly IMapper mapper;

    public GetBetHandler(IMapper _mapper, IBetService _betService)
    {
        betService = _betService;
        mapper = _mapper;
    }

    public async Task<GetBetResponse> Handle(GetBetRequest request, CancellationToken cancellationToken)
    {
        Bet bet =  await betService.GetBet(request.Id, cancellationToken);
        return mapper.Map<GetBetResponse>(bet);
    }
}
