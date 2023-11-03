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
    private readonly RouletteDataContext _dbContext;
    private IBetRepository _betRepository;
    private IDepositRepository _depositRepository;
    private ISpinRepository _spinRepository;
    private IPayoutRepository _payoutRepository;

    public UnitOfWork(RouletteDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IBetRepository BetRepository => _betRepository ??= new BetRepository(_dbContext);

    public IDepositRepository DepositRepository => _depositRepository ??= new DepositRepository(_dbContext);

    public ISpinRepository SpinRepository => _spinRepository ??= new SpinRepository(_dbContext);

    public IPayoutRepository PayoutRepository => _payoutRepository ??= new PayoutRepository(_dbContext);


    public void Commit()
        => _dbContext.SaveChanges();

    public async Task CommitAsync()
        => await _dbContext.SaveChangesAsync();

    public void Rollback()
        => _dbContext.Dispose();

    public async Task RollbackAsync()
        => await _dbContext.DisposeAsync();
}
