using AutoMapper;
using Roulette.Domain.Entities;

namespace Roulette.Application.Features.SessionFeatures.Commands.UpdateSession;
public sealed class UpdateSessionMapper : Profile
{
    public UpdateSessionMapper()
    {
        CreateMap<UpdateSessionRequest, Session>();
    }
}
