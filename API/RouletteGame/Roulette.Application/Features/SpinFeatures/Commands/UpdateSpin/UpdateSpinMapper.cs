using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.Commands.UpdateSpin;
public sealed class UpdateSpinMapper : Profile
{
    public UpdateSpinMapper()
    {
        CreateMap<UpdateSpinRequest, Spin>();
    }
}
