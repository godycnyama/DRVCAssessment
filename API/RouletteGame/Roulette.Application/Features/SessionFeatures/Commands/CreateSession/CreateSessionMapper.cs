using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SessionFeatures.Commands.CreateSession;
public sealed class CreateSessionMapper : Profile
{
    public CreateSessionMapper()
    {
        CreateMap<CreateSessionRequest, Session>();
    }
}
