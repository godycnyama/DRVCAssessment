using Roulette.Application.Abstractions.Services;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Application.Exceptions;
using Roulette.Application.Features.SessionFeatures.Commands.DeleteSession;
using Roulette.Domain.Entities;

namespace Roulette.Infrastructure.Services;
public class SessionService : ISessionService
{
    private readonly IUnitOfWork _unitOfWork;
    public SessionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Session>> GetAllSessions()
    {
        return await _unitOfWork.SessionRepository.GetAllAsync();

    }
    public async Task<Session> GetSession(int id)
    {
        return await _unitOfWork.SessionRepository.GetAsync(item => item.SessionID == id);

    }
    public async Task<Session> CreateSession(Session session)
    {
        _unitOfWork.SessionRepository.Add(session);
        await _unitOfWork.CommitAsync();
        return session;
    }
    public async Task<Session> UpdateSession(Session session)
    {
        Session _session = await _unitOfWork.SessionRepository.GetAsync(item => item.SessionID == session.SessionID);
        if (_session == null)
        {
            throw new SessionNotFoundException(session.SessionID.ToString());
        }
        _unitOfWork.SessionRepository.Update(_session);
        await _unitOfWork.CommitAsync();
        return session;
    }

    public async Task<DeleteSessionResponse> DeleteSession(int id)
    {
        Session _session = await _unitOfWork.SessionRepository.GetAsync(item => item.SessionID == id);
        if (_session == null)
        {
            throw new SessionNotFoundException(id.ToString());
        }
        _unitOfWork.SessionRepository.Remove(_session);
        await _unitOfWork.CommitAsync();
        return new DeleteSessionResponse { Message = $"Session with id: {id} deleted successfully" };
    }
}
