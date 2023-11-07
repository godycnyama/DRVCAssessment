using Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;
using Roulette.Domain.Entities;

namespace Roulette.Application.Abstractions.Services;
public interface ISessionService
{
    Task<Session> CreateSession(Session bet);
    Task<DeleteSessionResponse> DeleteSession(int id);
    Task<IEnumerable<Session>> GetAllSessions();
    Task<Session> GetSession(int id);
    Task<Session> UpdateSession(Session bet);
}
