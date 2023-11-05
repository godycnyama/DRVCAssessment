using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.GetSpins;
public sealed class GetSpinsMapper : Profile
{
    public GetSpinsMapper()
    {
        CreateMap<Spin, GetSpinsResponse>();
    }
}