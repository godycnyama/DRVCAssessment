using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SpinFeatures.Queries.GetSpins;
public sealed class GetSpinsMapper : Profile
{
    public GetSpinsMapper()
    {
        CreateMap<Spin, GetSpinsResponse>();
    }
}