using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.Commands.CreateSpin;
public sealed class CreateSpinMapper : Profile
{
    public CreateSpinMapper()
    {
        CreateMap<CreateSpinRequest, Spin>();
    }
}
