using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.BetFeatures.CreateBet;
public sealed class CreateBetMapper : Profile
{
    public CreateBetMapper()
    {
        CreateMap<CreateBetRequest, Bet>();
    }
}
