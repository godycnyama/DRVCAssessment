using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.PayoutFeatures.Commands.UpdatePayout;
public sealed class UpdatePayoutMapper : Profile
{
    public UpdatePayoutMapper()
    {
        CreateMap<UpdatePayoutRequest, Payout>();
    }
}
