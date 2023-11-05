using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.PayoutFeatures.Queries.GetPayouts;
public sealed class GetPayoutsMapper : Profile
{
    public GetPayoutsMapper()
    {
        CreateMap<Payout, GetPayoutsResponse>();
    }
}