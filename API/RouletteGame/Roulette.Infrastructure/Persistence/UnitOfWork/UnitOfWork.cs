using Roulette.Application.Abstractions.Repositories;
using Roulette.Application.Abstractions.UnitOfWork;
using Roulette.Infrastructure.Persistence.Context;
using Roulette.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Infrastructure.Persistence.UnitOfWork;
public class UnitOfWork : IUnitOfWork
{
    private readonly RouletteDataContext dbContext;
    public IBetRepository BetRepository { get; }
    public IDepositRepository DepositRepository { get; }
    public ISpinRepository SpinRepository { get; }
    public IPayoutRepository PayoutRepository { get; }

    public UnitOfWork(RouletteDataContext _dbContext, IBetRepository _betRepository, IDepositRepository _depositRepository, ISpinRepository _spinRepository, IPayoutRepository _payoutRepository)
    {
        this.dbContext = _dbContext;
        this.BetRepository = _betRepository;
        this.DepositRepository = _depositRepository;
        this.SpinRepository = _spinRepository;
        this.PayoutRepository = _payoutRepository;

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
