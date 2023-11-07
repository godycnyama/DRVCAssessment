using Roulette.Application.Abstractions.Repositories;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Infrastructure.Persistence.Context;

namespace Roulette.Infrastructure.Persistence.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly RouletteDataContext dbContext;
    public IBetRepository BetRepository { get; }
    public IAccountRepository AccountRepository { get; }
    public ISpinRepository SpinRepository { get; }
    public IPayoutRepository PayoutRepository { get; }
    public ISessionRepository SessionRepository { get; }


    public UnitOfWork(RouletteDataContext _dbContext, IBetRepository _betRepository, IAccountRepository _accountRepository, ISpinRepository _spinRepository, IPayoutRepository _payoutRepository, ISessionRepository sessionRepository)
    {
        this.dbContext = _dbContext;
        this.BetRepository = _betRepository;
        this.AccountRepository = _accountRepository;
        this.SpinRepository = _spinRepository;
        this.PayoutRepository = _payoutRepository;
        this.SessionRepository=sessionRepository;
    }

    public void Commit()
        => dbContext.SaveChanges();

    public async Task CommitAsync()
        => await dbContext.SaveChangesAsync();

    public void Rollback()
        => dbContext.Dispose();

    public async Task RollbackAsync()
        => await dbContext.DisposeAsync();
}
