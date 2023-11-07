using Roulette.Application.Abstractions.Repositories;

namespace Roulette.Application.Abstractions.UnitOfWork;
public interface IUnitOfWork
{
    IBetRepository BetRepository { get; }
    IAccountRepository AccountRepository { get; }
    ISpinRepository SpinRepository { get; }
    IPayoutRepository PayoutRepository { get; }
    ISessionRepository SessionRepository { get; }
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}
