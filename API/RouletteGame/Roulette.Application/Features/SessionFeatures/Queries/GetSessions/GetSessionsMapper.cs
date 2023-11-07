using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SessionFeatures.Queries.GetSessions;
public sealed class GetSessionsMapper : Profile
{
    public GetSessionsMapper()
    {
        CreateMap<Session, GetSessionsResponse>();
    }
}