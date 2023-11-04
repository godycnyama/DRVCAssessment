using AutoMapper;
using MediatR;
using Roulette.Application.Abstractions.Services;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.CreateBet;
public sealed class CreateBetHandler : IRequestHandler<CreateBetRequest, CreateBetResponse>
{
    private readonly IBetService _betService;
    private readonly IMapper _mapper;

    public CreateBetHandler(IMapper mapper, IBetService betService)
    {
        _betService = betService;
        _mapper = mapper;
    }

    public async Task<CreateBetResponse> Handle(CreateBetRequest request, CancellationToken cancellationToken)
    {
        Bet bet = _mapper.Map<Bet>(request);
        return await _betService.CreateBet(bet);
    }
}
