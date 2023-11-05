using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.PayoutFeatures.Commands.CreatePayout;
public sealed class CreatePayoutMapper : Profile
{
    public CreatePayoutMapper()
    {
        CreateMap<CreatePayoutRequest, Payout>();
    }
}
