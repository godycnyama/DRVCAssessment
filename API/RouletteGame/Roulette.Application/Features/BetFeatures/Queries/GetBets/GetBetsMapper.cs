using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.GetBets;
public sealed class GetBetsMapper : Profile
{
    public GetBetsMapper()
    {
        CreateMap<Bet, GetBetsResponse>();
    }
}