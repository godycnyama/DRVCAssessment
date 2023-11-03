using Roulette.Application.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Application.Abstractions.UnitOfWork;
public interface IUnitOfWork
{
    IBetRepository BetRepository { get; }
    IDepositRepository DepositRepository { get; }
    ISpinRepository SpinRepository { get; }
    IPayoutRepository PayoutRepository { get; }
    void Commit();
    void Rollback();
    Task CommitAsync();
    Task RollbackAsync();
}
